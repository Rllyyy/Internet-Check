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
using System.Net;
using Octokit;
using System.Reflection;

namespace Internet_Check
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            //Check if any other instances of the program are running
            checkForMultipleInstances();
            //Start the form if only one instance is detected
            formStart();
            CheckIfStartedByTaskScheduler();
        }

        private void checkForMultipleInstances()
        {
            //Get the amount of instances running and exit if the count is greater than 1
            //https://stackoverflow.com/questions/6392031/how-to-check-if-another-instance-of-the-application-is-running
            bool MultipleInstances = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1;

            if (MultipleInstances)
            {
                //Exit the Application if multiple instances are detected and tell the other process to focus again
                MultipleInstancesDetected();
                this.Close();
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                //Begin to watch the MultipleInstancesDetected file, if it changes this program will come to front again
                watchFiles(AppDomain.CurrentDomain.BaseDirectory + "MultipleInstancesDetected.txt");
            }
        }

        private void formStart()
        {
            InitializeComponent();
            PrepareUIElementsAsync();
        }

        private void CheckIfStartedByTaskScheduler()
        {
            if (Environment.GetCommandLineArgs().Contains(@"fromTask"))
            {
                if (Properties.Settings.Default.SettingHideWhenMin == true)
                {
                    startInSystemTray();
                }
                startCollecting();
            }
        }

        private async System.Threading.Tasks.Task PrepareUIElementsAsync()
        {
            this.Text += getAssemblyFileVersion();

            //Pass Form1 to the other classes
            userSettings1.setForm1(this);
            userControlClearConfirm1.setForm1(this);

            //Prepare UI Elements
            this.textBoxInterval.Text = Properties.Settings.Default.SettingInterval.ToString();
            this.notifyIcon1.Visible = false;
            this.button1.Text = "Start";
            this.notifyIcon1.Icon = Properties.Resources.InternetSymbolYellowSVG;
            this.userSettings1.SendToBack();
            this.userControlClearConfirm1.SendToBack();
            this.userControlErrorMessage1.SendToBack();
            this.userControlClearConfirm1.Visible = false;

            //removes the border from buttonOpen/button1 (startButton) on click event
            buttonOpen.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            button1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            //Highlight the interval Box
            //this.textBoxInterval.TabStop = false; //to disable the highlight in textBoxInterval
            textBoxInterval.SelectionStart = 0;
            textBoxInterval.SelectionLength = textBoxInterval.Text.Length;

            //Initialize DarkMode
            if (Properties.Settings.Default.SettingDarkmode == true)
            {
                DarkmodeForm();
            }
            await CheckGitHubNewerVersionAsync();
        }

        /// <summary>
        /// Get the assembly FileVersion from Properties/assemblyInfo.cs
        /// </summary>
        /// <returns></returns>
        private string getAssemblyFileVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string fileVerison = fvi.FileVersion.Substring(0, 5);
            return fileVerison;
        }
        
        /// <summary>
        /// Check if the application was started by windows. https://stackoverflow.com/questions/972105/retrieve-system-uptime-using-c-sharp
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32")]
        extern static UInt64 GetTickCount64();
        private bool StartedInLast9Minutes()
        {
            //Return if windows was started in the last 9 Minutes
            TimeSpan time = new TimeSpan(0, 0, 9, 0, 0);
            TimeSpan TimeSinceWindowsStart = TimeSpan.FromMilliseconds(GetTickCount64());

            if (TimeSinceWindowsStart <= time)
            {
                return true;
            }
            return false;
        }

        private void startInSystemTray()
        {
            if (Properties.Settings.Default.SettingHideWhenMin == true)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
                this.Visible = false;
            }
        }

        /// <summary>
        /// Method for the stop or start Button depended on the current state of the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.button1.Text == "Start")
            {
                checkIfIntervallCorrect();
            }
            else
            {
                stopCollecting();
            }
        }

        private void checkIfIntervallCorrect()
        {
            if (!string.IsNullOrEmpty(this.textBoxInterval.Text))
            {
                if (this.textBoxInterval.Text != Properties.Settings.Default.SettingInterval.ToString())
                {
                    //Give the user an Error if the interval that was provided is a not number, bigger than 32767 or smaller than 4
                    if (System.Text.RegularExpressions.Regex.IsMatch(textBoxInterval.Text, "[^0-9]") || Int32.Parse(textBoxInterval.Text) >= 32767 || Int32.Parse(textBoxInterval.Text) <= 4)
                    {
                        this.ErrorMessage("Please enter only positive numbers that are in-between 4 and 32766");
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
                        startCollecting();
                    }
                }
                else
                {
                    startCollecting();
                }
            }
            else
            {
               //Give the User an error if he enters no interval
               this.ErrorMessage("Please enter an interval.");
            }
        }

        private System.Threading.Timer timer;
        private void startCollecting()
        {
            //Prepare UI Elements
            this.button1.Text = "Stop";
            this.textBoxInterval.Enabled = false;
            this.buttonClear.Enabled = false;
            this.labelRunning.Text = "Running . . .";
            this.notifyIcon1.Icon = Properties.Resources.InternetSymbolGreenSVG;

            //Write starting info into the text file
            DateTime now = DateTime.Now;
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "connection_issues.txt", $"############ Program started at {now.ToString()} with an interval of {this.textBoxInterval.Text} seconds ############{Environment.NewLine}");
                
            //Prepare variables for timer
            TimeSpan startTimeSpan = TimeSpan.Zero;
            TimeSpan periodTimeSpan = TimeSpan.FromSeconds(Properties.Settings.Default.SettingInterval);
            List<string> serverList = getServersFromXML();
            bool writeSuccessfulPings = boolAdvancedSettings("ShowAllPingResults", false);
            int currentPositionInList = 0;

            bool useAlternativePingMethod = boolAdvancedSettings("UseAlternativePingMethod", false);
            //Decides which ping method is used. The standard
            if (!useAlternativePingMethod)
            {
                checkWithStandardPingProtocol(startTimeSpan, periodTimeSpan, serverList, writeSuccessfulPings, currentPositionInList);
            } 
            else
            {
                checkWithWebClient(startTimeSpan, periodTimeSpan, writeSuccessfulPings);
            }
        }

        private void stopCollecting ()
        {
            //Dispose the timer created in checkWithStandardPingProtocol
            try
            {
                timer.Dispose();
            } catch
            {}

            //Write text if clicked on stop
            DateTime now = DateTime.Now;
            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "connection_issues.txt", $"############ Program stopped at {now.ToString()} with an interval of {this.textBoxInterval.Text} seconds ############{Environment.NewLine}{Environment.NewLine}");

            //Reset the UI elements to starting values
            this.button1.Text = "Start";
            this.textBoxInterval.Enabled = true;
            this.buttonClear.Enabled = true;
            this.labelRunning.Text = "Waiting . . .";
            this.notifyIcon1.Icon = Properties.Resources.InternetSymbolYellowSVG;
        }

        private void checkWithStandardPingProtocol(TimeSpan startTimeSpan, TimeSpan periodTimeSpan, List<string> serverList, bool writeSuccessfulPings, int currentPositionInList)
        {
            //timer executes once every periodTimeSpan seconds
            //https://stackoverflow.com/questions/6381878/how-to-pass-the-multiple-parameters-to-the-system-threading-timer
            timer = new System.Threading.Timer((d) =>
            {
                //Give the CheckAndWrite method the current server as a string
                CheckAndWrite(serverList[currentPositionInList], writeSuccessfulPings);

                //Increment the value of currentPostionInList by one to get the next server
                currentPositionInList++;

                //Go to the beginning of the list if the value is bigger than the length of the list
                if (currentPositionInList >= serverList.Count())
                {
                    currentPositionInList -= serverList.Count();
                }
            }, (currentPositionInList, serverList, writeSuccessfulPings), startTimeSpan, periodTimeSpan);
        }

        private void CheckAndWrite(string currentServer, bool writeSuccessfulPings)
        {
            bool serverPingedBack = ping(currentServer);

            if (!serverPingedBack)
            {
                DateTime now = DateTime.Now;
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "connection_issues.txt", $"{now.ToString()} The server did not respond. Your internet connection might be down! (Error: {currentServer} failed ping){Environment.NewLine}");
                this.notifyIcon1.Icon = Properties.Resources.InternetSymbolRedSVG;
            }
            else
            {
                this.notifyIcon1.Icon = Properties.Resources.InternetSymbolGreenSVG;

                if (writeSuccessfulPings)
                {
                    DateTime now = DateTime.Now;
                    File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "connection_issues.txt", $"{now.ToString()} The server did respond. Your internet connection is working fine! (Message: {currentServer} answered ping){Environment.NewLine}");
                }
            }
        }

        //https://stackoverflow.com/questions/2031824/what-is-the-best-way-to-check-for-internet-connectivity-using-net
        private bool ping(string currentServer)
        {
            //This is the standard ping method which uses the ping protocol
            try
            {
                Ping myPing = new Ping();

                //bytesitze = 1 Byte or 8 Bits
                byte[] buffer = new byte[1];
                //server has 2500 ms to respond
                int timeout = 2500;
                String host = currentServer;

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

        //This is the alternative to the check() method and combines it with the alternative to the CheckAndWrite Method.
        private void checkWithWebClient(TimeSpan startTimeSpan, TimeSpan periodTimeSpan, bool writeSuccessfulPings)
        {
            //timer executes once every periodTimeSpan seconds
            //https://stackoverflow.com/questions/6381878/how-to-pass-the-multiple-parameters-to-the-system-threading-timer
            timer = new System.Threading.Timer((d) =>
            {
                bool serverPingedBack = pingWithWebClient();

                if (!serverPingedBack)
                {
                    DateTime now = DateTime.Now;
                    File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "connection_issues.txt", $"{now.ToString()} The server did not respond. Your internet connection might be down! (Error: www.google.com failed ping){Environment.NewLine}");
                    this.notifyIcon1.Icon = Properties.Resources.InternetSymbolRedSVG;
                }
                else
                {
                    this.notifyIcon1.Icon = Properties.Resources.InternetSymbolGreenSVG;

                    if (writeSuccessfulPings)
                    {
                        DateTime now = DateTime.Now;
                        File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "connection_issues.txt", $"{now.ToString()} The server did respond. Your internet connection is working fine! (Message: google.com answered ping){Environment.NewLine}");
                    }
                }

            }, writeSuccessfulPings, startTimeSpan, periodTimeSpan);
        }

        //This is the alternative to the ping method which relies on the webClient instead of the ping protocol. Can be activated by setting UseAlternativePingMethod in the XML file to true.
        //https://stackoverflow.com/questions/2031824/what-is-the-best-way-to-check-for-internet-connectivity-using-net
        private bool pingWithWebClient()
        {
            try
            {
                using (var client = new WebClient()) 
                using (client.OpenRead("http://google.com/generate_204")) 
                    client.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.userControlClearConfirm1.BringToFront();
            this.userControlClearConfirm1.Visible = true;
        }

        private List<string> getServersFromXML()
        {
            List<string> xmlServerList = new List<string>();

            //Define reader settings to ignore comments
            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.IgnoreComments = true;

            XmlDocument myData = new XmlDocument();
            XmlReader reader;
            try
            {
                reader = XmlReader.Create(AppDomain.CurrentDomain.BaseDirectory + "AdvancedSettings.xml", readerSettings);
                myData.Load(reader);
            } catch
            {
                this.ErrorMessage("Could not find AdvancedSettings.xml.The following servers were used: 8.8.8.8, 8.8.4.4 and 1.1.1.1! Please reinstall the program or create the file yourself");
                return xmlServerList = new List<string>{"8.8.8.8", "8.8.4.4", "1.1.1.1"};
            }

            //Search through the XML file if there is no error found
            foreach (XmlNode node in myData.DocumentElement)
            {
                string settingName = node.Attributes[0].InnerText;
                if (settingName == "Servers")
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        string server = child.InnerText;
                        if (!string.IsNullOrWhiteSpace(server))
                        {
                            try
                            {
                                xmlServerList.Add((string)server);
                            }
                            catch
                            {
                                this.ErrorMessage($"Could not add the server {server.ToString()} from XML file to internal server list. The server was ignored.");
                            }
                        } else
                        {
                            this.ErrorMessage($"There is an empty server inside the server list of AdvancedSettings.xml! The server was ignored.");
                        }
                    }
                    //Break out of the loop if the value is found
                    break;
                }
            }

            myData = null;
            reader.Dispose();
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
                File.WriteAllText((AppDomain.CurrentDomain.BaseDirectory + "connection_issues.txt"), String.Empty);
                Thread.Sleep(2500);
                this.labelRunning.BeginInvoke((MethodInvoker)delegate () { this.labelRunning.Text = originalText; ; });
            }).Start();
        }

        //Opens connection_issues.txt and check if the file exists
        private void buttonOpen_Click(object sender, EventArgs e)
        {

            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "connection_issues.txt"))
            {
                CheckEditorAlreadyOpen();
                //Editor is opened where it was last closed
                Process.Start("notepad.exe", AppDomain.CurrentDomain.BaseDirectory + "connection_issues.txt");
                /*
                Process foo = new Process();
                foo.StartInfo.UseShellExecute = true;
                foo.StartInfo.FileName = AppDomain.CurrentDomain.BaseDirectory + "connection_issues.txt";
                //foo.StartInfo.Arguments = "code";
                foo.Start();
                */
                //Go to the end of the Editor file
                GoToEndOfConnectionIssueTXT();

            } 
            else
            {   
                //If the text file doesn't exists, the program creates one, disposes the file-creator and opens the text file
                File.CreateText(AppDomain.CurrentDomain.BaseDirectory + "connection_issues.txt").Dispose();
                Process.Start("notepad.exe", AppDomain.CurrentDomain.BaseDirectory + "connection_issues.txt");
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
                //High-end pc can be given a low value of 25ms but the value depends on the load of the cpu and hard drive. 
                //100 ms should give the cpu enough time to process the request and not be too visible to the user.
                
                Thread.Sleep(100);              //Wait 100ms before executing the code, so the pc has time to open the file and focus it
                SendKeys.SendWait("^{END}");    //Key CTRL + END
            }).Start();
        }

        /// <summary>
        /// Search through all processes and focus notepad if already opened.
        /// </summary>
        private void CheckEditorAlreadyOpen()
        {
            //https://stackoverflow.com/questions/7268302/get-the-titles-of-all-open-windows
            Process[] processlist = Process.GetProcesses();
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle) && process.MainWindowTitle == "connection_issues - Editor")
                {
                    process.Kill();
                    break;
                }
            }
        }

        //Writes the end Date to the text file if the program is currently pinging and closed by the user. Also works if windows is shut down.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.labelRunning.Text == "Running . . .")
            {
                //gets the Time of now 
                DateTime now = DateTime.Now;

                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "connection_issues.txt", $"############ Program stopped at {now.ToString()} with an interval of {this.textBoxInterval.Text} seconds ############{Environment.NewLine}{Environment.NewLine}");
                try
                {
                    timer.Dispose();
                    watcher.Dispose();
                }
                catch
                {}
            }
        }

        //Maximizes the application if click on in the System Tray
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.TopMost = true;
            Show();
            WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.TopMost = false;
            this.notifyIcon1.Visible = false;
        }

        /// <summary>
        /// Sets the visibility to false if the user set visibility to hidden in the settings menu and form is minimized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SettingHideWhenMin == true && WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                this.notifyIcon1.Visible = true;
                if(boolAdvancedSettings("ShowMinimizedInfo",true) == true && StartedInLast9Minutes() == false)
                {
                    this.notifyIcon1.ShowBalloonTip(17000, "Internet Check minimized", "The application was moved to the System Tray and will continue running in the background.", ToolTipIcon.None);
                }
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
                watcher.Path = Path.GetDirectoryName(path); 
                watcher.Filter = Path.GetFileName(path);
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.EnableRaisingEvents = true;
            }).Start();
        }

        // OnChange Event Handler makes the already running Form1 visible again. Called by watchFiles().
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            MethodInvoker Form1WindowStateNormal = () => this.WindowState = FormWindowState.Normal;
            MethodInvoker Form1topMostTrue = () => this.TopMost = true;
            MethodInvoker Form1Visible = () => this.Visible = true;                                     //not needed?
            MethodInvoker Form1toFront = () => this.BringToFront();                                     //not needed?
            MethodInvoker Form1Show = () => this.Show();                                                //not needed?
            MethodInvoker Form1Activate = () => this.Activate();                                        //Icon blinks in Task bar
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
            this.userControlErrorMessage1.BackColor = Color.FromArgb(56, 55, 55);
            this.userControlErrorMessage1.ForeColor = Color.FromArgb(233, 233, 233);
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
            this.userControlErrorMessage1.ForeColor = Color.Black;
            this.button2.ForeColor = Color.Black;
            this.userSettings1.BackColor = Color.White;
            this.userControlErrorMessage1.BackColor = Color.White;
            this.userControlErrorMessage1.ForeColor = Color.Black;
            this.userControlClearConfirm1.BackColor = Color.White;
            this.userControlClearConfirm1.UserControlClearConfirmLightmodeForm();
        }
        
        //Enter starts and stops the application
        private void textBoxInterval_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter) 
            {
                checkIfIntervallCorrect();
            }
        }

        //Opens the settings-form
        private void button2_Click(object sender, EventArgs e)
        {
            //Opens the settings
            this.userSettings1.BringToFront();
            this.userSettings1.Visible = true;
            this.userSettings1.Show();
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
                //WriteDataToNewFile();
                writeRelevantData();
                Thread.Sleep(2000);
                this.button1.BeginInvoke((MethodInvoker)delegate () { this.button1.Enabled = true; ; });
                this.buttonOpen.BeginInvoke((MethodInvoker)delegate () { this.buttonOpen.Enabled = true; ; });
                this.labelRunning.BeginInvoke((MethodInvoker)delegate () { this.labelRunning.Text = originalText; ; });
            }).Start();
        }

        /// <summary>
        /// Writes Data to new file if Clear Only Irrelevant Data is selected. Called from Form1.ClearOnlyIrrelevant()
        /// https://stackoverflow.com/questions/7276158/skip-lines-that-contain-semi-colon-in-text-file
        /// https://stackoverflow.com/questions/1245243/delete-specific-line-from-a-text-file#:~:text=The%20best%20way%20to%20do,line%20you%20want%20to%20delete.
        /// https://stackoverflow.com/questions/6480058/remove-blank-lines-in-a-text-file
        /// https://asp-net-example.blogspot.com/2013/10/c-example-string-starts-with-number.html
        /// </summary>
        private void writeRelevantData()
        {
            //connection_issues.txt save location
            string connection_issuesSaveLocation = AppDomain.CurrentDomain.BaseDirectory + "connection_issues.txt";

            //Create list with lines that don't contain a #, are empty or end with "answered ping)"
            List<string> relevantData = new List<string>(getRelevantLines(connection_issuesSaveLocation));

            //Delete all (old) lines
            File.WriteAllText(connection_issuesSaveLocation, String.Empty);

            //Write relevantData list to .txt file
            using (TextWriter writer = new StreamWriter(connection_issuesSaveLocation))
            {
                foreach (String relevantLine in relevantData)
                {
                    writer.WriteLine(relevantLine);
                }  
            }
        }

        //Return a List with all lines in connection_issues.txt that don't begin with #, are empty or end with a successful ping. Called by Form1.writeRelevantData()
        private List<string> getRelevantLines(string connection_issuesSaveLocation)
        {
            List<string> relevantData = new List<string>();
            using (StreamReader reader = new StreamReader(connection_issuesSaveLocation))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        //If the line does not start with a # and the line is not empty, the writer writes the line into a new file
                        if (!line.StartsWith("#") && !string.IsNullOrEmpty(line) && !line.EndsWith("answered ping)"))
                        {
                            //push to List
                            relevantData.Add(line);
                        }
                    }
                    catch
                    { }
                }
            }
            return relevantData;
        }

        //Gives the class UserControllErrorMessage the error Text and can be called from outside of this class.
        public void ErrorMessage(string errorText)
        {
            userControlErrorMessage1.setErrorMessageText(errorText);
        }

        //Writes current date to file if the User tries to open the application more than once. The original application watches this file and if changes brings itself back to the front.
        private void MultipleInstancesDetected()
        {
            DateTime now = DateTime.Now;
            File.WriteAllText((AppDomain.CurrentDomain.BaseDirectory + "MultipleInstancesDetected.txt"), now.ToString());
        }

        public bool boolAdvancedSettings(string settingNameInherited, bool standardValue)
        {
            bool boolSetting = standardValue;

            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.IgnoreComments = true;

            XmlReader reader = null;
            XmlDocument myData = new XmlDocument();

            try
            {
                reader = XmlReader.Create(AppDomain.CurrentDomain.BaseDirectory + "AdvancedSettings.xml", readerSettings);
                myData.Load(reader);
            } catch (Exception e)
            {
                this.ErrorMessage(e.Message);
                return standardValue;
            }

            foreach (XmlNode node in myData.DocumentElement)
            {
                string settingName = node.Attributes[0].InnerText;
                if (settingName == settingNameInherited)
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        string settingValue = child.InnerText;
                        try
                        {
                            boolSetting = bool.Parse(settingValue);
                        }
                        catch
                        {
                            this.ErrorMessage($"The value {settingValue.ToString()} of {settingNameInherited} in AdvancedSettings.xml is invalid. The standard value {standardValue.ToString().ToLower()} was used.");
                        }
                    }
                    break;
                }
            }
            readerSettings = null;
            reader.Dispose();
            myData = null;
            return boolSetting;
        }
        //TaskSchedulerStopTaskAfterDays
        public int intAdvancedSettings(string settingNameInherited, int standardValue)
        {
            int returnValue = standardValue;

            //https://stackoverflow.com/questions/2875674/how-to-ignore-comments-when-reading-a-xml-file-into-a-xmldocument
            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.IgnoreComments = true;

            XmlReader reader = null;
            XmlDocument myData = new XmlDocument();
            try
            {
                reader = XmlReader.Create(AppDomain.CurrentDomain.BaseDirectory + "AdvancedSettings.xml", readerSettings);
                myData.Load(reader);
            }
            catch (Exception e)
            {
                this.ErrorMessage(e.Message);
                return standardValue;
            }

            //If the file is found, loop through it to find the relevant data
            foreach (XmlNode node in myData.DocumentElement)
            {
                string settingName = node.Attributes[0].InnerText;
                if (settingName == settingNameInherited)
                {
                    foreach (XmlNode child in node.ChildNodes)
                    {
                        string value = child.InnerText;
                        try
                        {
                            returnValue = Int16.Parse(value);
                        }
                        catch
                        {
                            this.ErrorMessage($"The value {value.ToString()} of ${settingNameInherited} in AdvancedSettings.xml is invalid. The standard value of ${standardValue.ToString()} days was used.");
                        }
                    }
                    break;
                }
            }
            reader.Dispose();
            myData = null;
            return returnValue;
        }

        private async System.Threading.Tasks.Task CheckGitHubNewerVersionAsync()
        {
            int UpdateNotificationsLeft = intAdvancedSettings("UpdateNotificationsLeft", 0);
            if (UpdateNotificationsLeft > 0)
            {
                //Downloading all GitHub releases from one repository
                //https://octokitnet.readthedocs.io/en/latest/getting-started/
                GitHubClient client = new GitHubClient(new ProductHeaderValue("Internet-Check"));
                IReadOnlyList<Release> releases = await client.Repository.Release.GetAll("Rllyyy", "Internet-Check");

                //Check the GitHub API rate limit
                //GitHubAPIRateInformation(client);

                //Setup the versions
                Version latestGitHubVersion = new Version(releases[0].TagName);
                Version localVersion = new Version(getAssemblyFileVersion());

                //Compare the Versions
                //source: https://stackoverflow.com/questions/7568147/compare-version-numbers-without-using-split-function
                int versionComparison = localVersion.CompareTo(latestGitHubVersion);
                if (versionComparison < 0)
                {
                    DecreaseUpdateNotifcationsLeft(UpdateNotificationsLeft);
                    //The Version on GitHub is more up to date. Prompt the user to update. This is done by the ErrorMessage class as all user Messages are delivered by that class. Kinda ugly :/
                    this.ErrorMessage($"Please visit www.github.com/Rllyyy/Internet-Check/releases/latest to update to the latest version ({latestGitHubVersion}). \n This notification will be shown {UpdateNotificationsLeft-1} more times.");
                }
                else if (versionComparison > 0)
                {
                    //localVersion is greater than the Version on GitHub. No action needed.
                }
                else
                {
                    //This local Version and the Version on GitHub are equal
                }
            }
        }

        private void DecreaseUpdateNotifcationsLeft(int UpdateNotificationsLeft)
        {
            //Decrease variable
            UpdateNotificationsLeft -= 1;
            
            //Open and load XML File
            XmlDocument document = new XmlDocument();
            document.Load(AppDomain.CurrentDomain.BaseDirectory + "AdvancedSettings.xml");

            //Update inner Text and save
            document.SelectSingleNode("//setting[@name='UpdateNotificationsLeft']/value").InnerText = UpdateNotificationsLeft.ToString();
            document.Save(AppDomain.CurrentDomain.BaseDirectory + "AdvancedSettings.xml");
            document = null;
        }

        private void GitHubAPIRateInformation(GitHubClient client)
        {
            var apiInfo = client.GetLastApiInfo();

            // If the ApiInfo isn't null, there will be a property called RateLimit
            var rateLimit = apiInfo?.RateLimit;

            var howManyRequestsCanIMakePerHour = rateLimit?.Limit;
            var howManyRequestsDoIHaveLeft = rateLimit?.Remaining;
            var whenDoesTheLimitReset = rateLimit?.Reset;

            MessageBox.Show($"Maximum request per hour: {howManyRequestsCanIMakePerHour}\nRequest left this hour: {howManyRequestsDoIHaveLeft}\nLimit reset time (UTC): {whenDoesTheLimitReset}", "GitHub API Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

