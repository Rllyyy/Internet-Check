using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml;

namespace Internet_Check
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //Get the ammount of instances running and exit if the count is greater than 1
            //https://stackoverflow.com/questions/6392031/how-to-check-if-another-instance-of-the-application-is-running
            var MultipleInstances = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1;

            if (MultipleInstances)
            {
                //Exit the Application if multiple instances are detected and tell the other process to focus again
                MultipleInstancesDetected();
                this.Close();
                Application.Exit();
            }
            else
            {
                //Begin to watch the MultipleInstancesDetected file, if it changes this programm will come to front again
                watchFiles(AppDomain.CurrentDomain.BaseDirectory + "MultipleInstancesDetected.txt");

                //Start the form
                formStart();
                CheckIfStartedWithWindows();

                /*
                List<string> test = serverList();
                MessageBox.Show(String.Join(",", test)); */
            }
        }

        private void formStart()
        {
            InitializeComponent();
            PrepareUIElements();
        }

        private void PrepareUIElements()
        {
            //Prepare UI Elements
            this.textBoxInterval.Text = Properties.Settings.Default.SettingInterval.ToString();
            notifyIcon1.Visible = true;
            this.button1.Text = "Start";
            this.panelSeetings.SendToBack();
            this.userControlClearConfirm1.SendToBack();
            this.userControlClearConfirm1.Visible = false;

            //removes the border from buttonOpen on an click event
            buttonOpen.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            //Higlighting the Intervall Box
            //this.textBoxInterval.TabStop = false; //to disable the highlight in textBoxInterval which sometimes occure
            textBoxInterval.SelectionStart = 0;
            textBoxInterval.SelectionLength = textBoxInterval.Text.Length;

            //Initialise DarkMode
            if (Properties.Settings.Default.SettingDarkmode == true)
            {
                DarkmodeForm();
            }
        }

        public static int countclick = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            ClickEvent();
        }
        private void ClickEvent()
        {
            if (!string.IsNullOrEmpty(this.textBoxInterval.Text))
            {
                if (this.textBoxInterval.Text != Properties.Settings.Default.SettingInterval.ToString())
                {
                    //Give the user an Error if the intervall that was provided is a not number, bigger than 32767 or smaller than 4
                    if (System.Text.RegularExpressions.Regex.IsMatch(textBoxInterval.Text, "[^0-9]") || Int32.Parse(textBoxInterval.Text) >= 32767 || Int32.Parse(textBoxInterval.Text) <= 4)
                    {
                        UserErrorMessage("Please enter only positve numbers that are inbetween 4 and 32766", 4200);
                        textBoxInterval.Text = textBoxInterval.Text.Remove(textBoxInterval.Text.Length - 1);
                    }
                    else
                    {
                        try
                        {
                            Properties.Settings.Default.SettingInterval = Int16.Parse(this.textBoxInterval.Text);
                            Properties.Settings.Default.Save();
                        }
                        catch
                        {}
                        countclick++;
                        tTimer();
                    }
                }
                else
                {
                    countclick++;
                    tTimer();
                }
            }
            else
            {
                //Give the User an error if he enters no intervall
                UserErrorMessage("Please enter an intervall.", 2700);
            }
        }

        private System.Threading.Timer timer;
        private void tTimer()
        {
            DateTime now;
            //TODO: Make countclick into bool
            if (countclick % 2 == 1)
            {   
                //Prepare UI Elemts
                this.button1.Text = "Stop";
                this.textBoxInterval.Enabled = false;
                this.buttonClear.Enabled = false;
                this.labelRunning.Text = "Running . . .";

                //Write starting info into the text file
                now = DateTime.Now;
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "connection issues.txt", $"############ Program started at {now.ToString()} with an intervall of {this.textBoxInterval.Text} seconds ############{Environment.NewLine}");
                
                //Prepare variables for timer
                
                var startTimeSpan = TimeSpan.Zero;
                var periodTimeSpan = TimeSpan.FromSeconds(Properties.Settings.Default.SettingInterval);
                List<string> serverList = getServersFromXML();
                int currentPositionInList = 0;

                //timer executes onence every periodTimeSpan seconds
                //https://stackoverflow.com/questions/6381878/how-to-pass-the-multiple-parameters-to-the-system-threading-timer
                timer = new System.Threading.Timer((d) =>
                {
                    //Give the CheckAndWrite method the current server as a string
                    CheckAndWrite(serverList[currentPositionInList]);

                    //Increment the value of currentPostionInList by one to get the next server
                    currentPositionInList++;

                    //Go to the beginning of the list if the value is bigger than the lenght of the list
                    if (currentPositionInList >= serverList.Count())
                    {
                        currentPositionInList -= serverList.Count();
                    }
                    
                }, (currentPositionInList, serverList), startTimeSpan, periodTimeSpan);
                
            }
            else
            {
                now = DateTime.Now;

                //Dispose the timer
                timer.Dispose();

                //Write text if clicked on stop
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "connection issues.txt", $"############ Program stopped at {now.ToString()} with an intervall of {this.textBoxInterval.Text} seconds ############{Environment.NewLine}{Environment.NewLine}");

                //Reset the UI elements to starting values
                this.button1.Text = "Start";
                this.textBoxInterval.Enabled = true;
                this.buttonClear.Enabled = true;
                this.labelRunning.Text = "Waiting . . .";
            }
        }

        private void CheckAndWrite(string currentServer)
        {
            DateTime now = DateTime.Now;

            if (ping(currentServer) == false)
            {
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "connection issues.txt", $"{now.ToString()} The server did not respond. Your internet connection might be down! (Error: {currentServer} failed ping){Environment.NewLine}");
            } else
            {
                //Uncomment the next line if every ping should be written into the file
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "connection issues.txt", $"{now.ToString()} The server did respond. Your internet connection is working fine! (Message: {currentServer} answered ping){Environment.NewLine}");
            }
        }

        //https://stackoverflow.com/questions/2031824/what-is-the-best-way-to-check-for-internet-connectivity-using-net
        private bool ping(string currentServer)
        {
            try
            {
                Ping myPing = new Ping();
                String host = currentServer;

                //bytesitze = 1 Byte or 8 Bits
                byte[] buffer = new byte[1];
                //server has 2500 ms to respond
                int timeout = 2500;

                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);

                myPing.Dispose();
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.userControlClearConfirm1.BringToFront();
            this.userControlClearConfirm1.Visible = true;

            //Pass Form1 to ClearConfirm
            userControlClearConfirm1.setForm1(this);
        }


        //readonly List<string> listServer = new List<string>() { "8.8.8.8", "8.8.4.4", "1.1.1.1"};
        private List<string> getServersFromXML()
        {
            List<string> xmlServerList = new List<string>();

            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.IgnoreComments = true;

            using (XmlReader reader = XmlReader.Create(AppDomain.CurrentDomain.BaseDirectory + "AdvancedSettings.xml", readerSettings))
            {
                XmlDocument myData = new XmlDocument();
                try
                {
                    myData.Load(reader);
                } catch
                {
                    MessageBox.Show("Could not find AdvancedSettings.xml");
                    return xmlServerList;
                }
                

                foreach (XmlNode node in myData.DocumentElement)
                {
                    string settingName = node.Attributes[0].InnerText;
                    if (settingName == "servers")
                    {
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            string server = child.InnerText;
                            try
                            {
                                xmlServerList.Add((string)server);
                            }
                            catch
                            {
                                MessageBox.Show("Could not add server from XML file to internal server list. The server was ignored.");
                            }
                        }
                    }
                }
                reader.Dispose();
            }
            return xmlServerList;
        }

        public void ClearEverything()
        {   
            //Triggered by UsercontrolClearConfirm
            string originalText = this.labelRunning.Text;
            new Thread(() =>
            {
                this.labelRunning.BeginInvoke((MethodInvoker)delegate () { this.labelRunning.Text = "Clearing . . ."; ; });
                Thread.CurrentThread.IsBackground = true;
                File.WriteAllText((AppDomain.CurrentDomain.BaseDirectory + "connection issues.txt"), String.Empty);
                Thread.Sleep(2500);
                this.labelRunning.BeginInvoke((MethodInvoker)delegate () { this.labelRunning.Text = originalText; ; });
            }).Start();
        }

        //Opens connection issues.txt and check if the file exists
        private void buttonOpen_Click(object sender, EventArgs e)
        {

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "connection issues.txt"))
            {
                CheckEditorAlreadyOpen();
                //Editor is opened where it was last closed
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + "connection issues.txt");
                //Go to the end of the Editor file
                GoToEndOfConnectionIssueTXT();

            } else
            {   
                //If the textfile doesn't exists, the program creates one, dispoeses the filecreator and opens the textfile
                File.CreateText(AppDomain.CurrentDomain.BaseDirectory + "connection issues.txt").Dispose();
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + "connection issues.txt");
                //Go to the end of the document
                GoToEndOfConnectionIssueTXT();
            } 
        }

        //Called by buttonOpen_Click. Waits 100ms before going to the end of the file, so the relevant information is at the bottom.
        private void GoToEndOfConnectionIssueTXT()
        {
            new Thread(() =>
            {
                //Waits X milliseconds before hitting the keys to scroll down, so the editor can be opened before hitting CTRL + END
                //High-end pc can be given a low value of 25ms but the value depends on the load of the cpu and harddrive. 
                //100 ms should give the cpu enough time to process the request and not be too visible to the user.
                
                Thread.Sleep(100);              //Wait 100ms before executing the code, so the pc has time to open the file and focus it
                SendKeys.SendWait("^{END}");    //Key CTRL + END
            }).Start();
        }

        /// <summary>
        /// Search through all processes and fokus notepad if already opened.
        /// </summary>
        private void CheckEditorAlreadyOpen()
        {
            //https://stackoverflow.com/questions/7268302/get-the-titles-of-all-open-windows
            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle) && process.MainWindowTitle == "connection issues - Editor")
                {
                    process.Kill();
                    break;
                }
            }
        }

        /// <summary>
        /// Sets the editor to the foreground if already opened but in the background. https://stackoverflow.com/questions/25578305/c-sharp-focus-window-of-a-runing-program
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow); //ShowWindow needs an IntPtr
        private static void FocusEditor(Process process)
        {
            IntPtr hWnd;
            hWnd = process.MainWindowHandle;
            ShowWindow(hWnd, 9);
            SetForegroundWindow(hWnd); //set to topmost
        }

        //Writes the end Date to the textfile if the programm is currently pinging and closed by the user. Also works if windows is shut down.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //gets the Time of now 
            DateTime now = DateTime.Now;

            if (this.labelRunning.Text == "Running . . .")
            {
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "connection issues.txt", $"############ Program stopped at {now.ToString()} with an intervall of {this.textBoxInterval.Text} seconds ############{Environment.NewLine}{Environment.NewLine}");
                try
                {
                    timer.Dispose();
                    watcher.Dispose();
                }
                catch
                {
                }
            }
        }

        //Maximizes the applicaiton if click on in the systemtray
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.TopMost = true;
            Show();
            WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.TopMost = false;
        }

        /// <summary>
        /// Sets the visibity to false if the user set visibilty to hidden in the settings menu and form is minimized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SettingHideWhenMin == true && WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
            }
        }


        public static FileSystemWatcher watcher = new FileSystemWatcher();
        /// <summary>
        /// Method watches MultipleInstancesDetected.txt and if changed by another process
        /// https://docs.microsoft.com/en-us/dotnet/api/system.io.filesystemwatcher?redirectedfrom=MSDN&view=netcore-3.1
        /// https://stackoverflow.com/questions/721714/notification-when-a-file-changes
        /// declare the watcher out of the method to make it run all the time??
        /// </summary>
        /// <param name="path"></param>
        public void watchFiles(string path)
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "MultipleInstancesDetected.txt"))
            {
                File.CreateText("MultipleInstancesDetected.txt").Dispose();
            }

            new Thread(() =>
            {
                if (watcher != null)
                {
                    watcher.EnableRaisingEvents = false;
                    watcher.Created -= new FileSystemEventHandler(OnChanged);
                }
                /*watcher = new FileSystemWatcher();*/
                watcher.Path = Path.GetDirectoryName(path); 
                watcher.Filter = Path.GetFileName(path);
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.EnableRaisingEvents = true;
            }).Start();
        }

        // OnChange eventhandler makes the already running Form1 visible again. Called by watchFiles().
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            MethodInvoker Form1WindowStateNormal = () => this.WindowState = FormWindowState.Normal;
            MethodInvoker Form1topMostTrue = () => this.TopMost = true;
            MethodInvoker Form1Visible = () => this.Visible = true;                                     //not needed?
            MethodInvoker Form1toFront = () => this.BringToFront();                                     //not needed?
            MethodInvoker Form1Show = () => this.Show();                                                //not needed?
            MethodInvoker Form1Activate = () => this.Activate();                                        //Icon blinks in Taskbar
            MethodInvoker Form1ShowInTaskbar = () => this.ShowInTaskbar = true;                                        
            MethodInvoker Form1topMostFalse = () => this.TopMost = false;
            /*MethodInvoker SetForegroundWindow = () => this.SetForegroundWindow(this);*/

            this.BeginInvoke(Form1Visible);
            this.BeginInvoke(Form1topMostTrue);
            this.BeginInvoke(Form1WindowStateNormal);
            this.BeginInvoke(Form1toFront);
            this.BeginInvoke(Form1Show);
            this.BeginInvoke(Form1ShowInTaskbar);
            this.BeginInvoke(Form1topMostFalse);
            this.BeginInvoke(Form1Activate);
        }

        //Makes UI-Elements Dark
        public void DarkmodeForm()
        {     
            this.BackColor = Color.FromArgb(56, 55, 55);
            this.button1.ForeColor = Color.FromArgb(233, 233, 233);
            this.buttonOpen.ForeColor = Color.FromArgb(233, 233, 233);
            this.buttonClear.ForeColor = Color.FromArgb(233, 233, 233);
            this.labelErrormessage.ForeColor = Color.FromArgb(233, 233, 233);
            this.button2.ForeColor = Color.FromArgb(233, 233, 233);
            this.userSettings1.BackColor = Color.FromArgb(56, 55, 55);
            this.userControlClearConfirm1.UserControlClearConfirmDarkmodeForm();
        }

        //Makes UI Elements Light
        public void LightmodeForm()
        {
            this.BackColor = Color.White;
            this.button1.ForeColor = Color.Black;
            this.buttonOpen.ForeColor = Color.Black;
            this.buttonClear.ForeColor = Color.Black;
            this.labelErrormessage.ForeColor = Color.Black;
            this.button2.ForeColor = Color.Black;
            this.userSettings1.BackColor = Color.White;
            this.userControlClearConfirm1.BackColor = Color.White;
            this.userControlClearConfirm1.UserControlClearConfirmLightmodeForm();
        }
        
        //Enter starts and stops the application
        private void textBoxInterval_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter) 
            {
                ClickEvent();
            }
        }

        //Opens the settings-form
        private void button2_Click(object sender, EventArgs e)
        {
            //Opens the settings
            this.userSettings1.BringToFront();
            this.userSettings1.Visible = true;
            this.userSettings1.Show();
            this.panelSeetings.Show();
            this.panelSeetings.Visible = true;
            this.panelSeetings.BringToFront();
            userSettings1.setForm1(this);
        }

        //Hides the Settings-Panel
        public void PanelSettings_Hide()
        {
            this.panel2.BringToFront();
            this.panel2.Visible = true;
            this.panel2.Show();
            this.panelSeetings.SendToBack();
        }


        //UI-Elements for ClearOnlyIrrelevant. Called from UserControlClearConfirm.cs
        public void ClearOnlyIrrelevant()
        {
            string originalText = this.labelRunning.Text;
            new Thread(() =>
            {
                this.labelRunning.BeginInvoke((MethodInvoker)delegate () { this.labelRunning.Text = "Clearing . . ."; ; });
                this.button1.BeginInvoke((MethodInvoker)delegate () { this.button1.Enabled = false; ; });
                this.buttonOpen.BeginInvoke((MethodInvoker)delegate () { this.buttonOpen.Enabled = false; ; });
                Thread.CurrentThread.IsBackground = true;
                WriteDataToNewFile();
                Thread.Sleep(2000);
                this.button1.BeginInvoke((MethodInvoker)delegate () { this.button1.Enabled = true; ; });
                this.buttonOpen.BeginInvoke((MethodInvoker)delegate () { this.buttonOpen.Enabled = true; ; });
                this.labelRunning.BeginInvoke((MethodInvoker)delegate () { this.labelRunning.Text = originalText; ; });
            }).Start();
        }

        //Writes Data to new file if Clear Only Irrelevant Data is selected. Caled from Form1.ClearOnlyIrrelevant()
        private void WriteDataToNewFile() 
        {
            //Copies lines starting with a number to backup file
            //https://stackoverflow.com/questions/7276158/skip-lines-that-contain-semi-colon-in-text-file
            //https://stackoverflow.com/questions/1245243/delete-specific-line-from-a-text-file#:~:text=The%20best%20way%20to%20do,line%20you%20want%20to%20delete.
            //https://stackoverflow.com/questions/6480058/remove-blank-lines-in-a-text-file
            //https://asp-net-example.blogspot.com/2013/10/c-example-string-starts-with-number.html

            //Original file
            using (var reader = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + "connection issues.txt"))

            //Temporary new file, Could also be a string or array
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "connection issues - copy.txt"))
            
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    try
                    {
                        //If the line does not start with a # and the line is not empty, the writer writes the line into a new file
                        if(!line.StartsWith("#")&& !string.IsNullOrEmpty(line))
                        {
                            writer.WriteLine(line);
                        }
                    }
                    catch
                    {}
                }

                writer.Close();
                reader.Close();
            }

            DeleteOldFile();
            RenameOldFileToNew();
        }
        //Deletes the old file connection issues. Called by WriteDataToNewFile().
        private void DeleteOldFile()
        {
            string FilepathToDelete = AppDomain.CurrentDomain.BaseDirectory + "connection issues.txt";
            File.Delete(FilepathToDelete);
        }

        //Renames the new file from "connection issues - copy.txt" to "connection issues.txt". Called by WriteDataToNewFile().
        private void RenameOldFileToNew()
        {
            //source: https://stackoverflow.com/questions/3218910/rename-a-file-in-c-sharp
            string oldFilePath = AppDomain.CurrentDomain.BaseDirectory + "connection issues - copy.txt";
            string newFilePath = AppDomain.CurrentDomain.BaseDirectory + "connection issues.txt";
            
            File.Move(oldFilePath, newFilePath );
        }

        //UserErrorMessages. Method takes the ErrorText by string and time for how long the errormessage is visible by int (1000 = 1 sec)
        public void UserErrorMessage(string ErrorText, int TimeErrorVisible)
        {
            new Thread(() =>
            {
                this.labelErrormessage.BeginInvoke((MethodInvoker)delegate () { this.labelErrormessage.Text = ErrorText; ; });
                this.labelErrormessage.BeginInvoke((MethodInvoker)delegate () { this.labelErrormessage.Visible = true; ; });
                this.labelErrormessage.BeginInvoke((MethodInvoker)delegate () { this.labelErrormessage.BringToFront(); ; });
                Thread.Sleep(TimeErrorVisible);
                Thread.CurrentThread.IsBackground = true;
                this.labelErrormessage.BeginInvoke((MethodInvoker)delegate () { this.labelErrormessage.Visible = false; ; });
            }).Start();
        }

        //Writes current date to file if the User tries to open the applicaiton more than onece. The original application watches this file and if changes brings itself back to the front.
        private void MultipleInstancesDetected()
        {
            DateTime now = DateTime.Now;
            File.WriteAllText((AppDomain.CurrentDomain.BaseDirectory + "MultipleInstancesDetected.txt"), now.ToString());
        }

        /// <summary>
        /// Check if the application was started by windows. https://stackoverflow.com/questions/972105/retrieve-system-uptime-using-c-sharp
        /// </summary>
        /// <returns></returns>
        //
        [DllImport("kernel32")]
        extern static UInt64 GetTickCount64();
        private void CheckIfStartedWithWindows()
        {
            //Start collecting data if StartWithWindows is true and time since boot is smaller or equal to 9 minutes. Windows update might interfier with this.
            TimeSpan time = new TimeSpan(0, 0, 9, 0, 0);
            TimeSpan TimeSinceWindowsStart = TimeSpan.FromMilliseconds(GetTickCount64());

            if (TimeSinceWindowsStart <= time && Properties.Settings.Default.SettingWindowsStart == true)
            {
                if (Properties.Settings.Default.SettingHideWhenMin == true)
                {
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;
                    this.Visible = false;
                }
                ClickEvent();
            }
        }
    }
}

