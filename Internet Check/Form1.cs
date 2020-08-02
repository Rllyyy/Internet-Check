using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

namespace Internet_Check
{
    public partial class Form1 : Form
    {
        public Form1()
        {   
            //Get the ammount of instances running and exit if the count is greater than 1
            var MultipleInstances = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1; //https://stackoverflow.com/questions/6392031/how-to-check-if-another-instance-of-the-application-is-running
            if (MultipleInstances)
            {
                ChangeConfig();
                this.Close();
                Application.Exit();
                
            } 
            else
            {
                watchFiles(AppDomain.CurrentDomain.BaseDirectory + @"\config.txt");
                formStart();
            }       
        }
        private void formStart ()
        {
            InitializeComponent();

            //Prepare UI Elements
            this.textBoxInterval.Text = Properties.Settings.Default.SettingInterval.ToString();
            notifyIcon1.Visible = true;
            this.button1.Text = "Start";
            this.panelSeetings.SendToBack();
            this.userControlClearConfirm1.SendToBack();
            this.userControlClearConfirm1.Visible = false;

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
        private System.Threading.Timer timer;
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

                    if (System.Text.RegularExpressions.Regex.IsMatch(textBoxInterval.Text, "[^0-9]") || Int32.Parse(textBoxInterval.Text) >= 32767 || Int32.Parse(textBoxInterval.Text) <= 4)
                    {
                        UserErrorMessage("Please enter only positve numbers that are inbetween 4 and 32766",4700);
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
                        {
                        }
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
                UserErrorMessage("Please enter an intervall.", 2700);
            }
        }
        private void tTimer()
        {
            DateTime now = DateTime.Now;
            if (countclick % 2 == 1)
            {
                this.button1.Text = "Stop";
                this.textBoxInterval.Enabled = false;
                this.buttonClear.Enabled = false;
                now = DateTime.Now;
                var startTimeSpan = TimeSpan.Zero;
                var periodTimeSpan = TimeSpan.FromSeconds(Properties.Settings.Default.SettingInterval);
                File.AppendAllText("connection issues.txt", "########### Program started at " + now.ToString() + " ###########" + Environment.NewLine);
                this.labelRunning.Text = "Running . . .";
                timer = new System.Threading.Timer((d) =>
                {
                    Checker();
                }, null, startTimeSpan, periodTimeSpan);
            }
            else
            {
                this.button1.Text = "Start";
                timer.Dispose(); //needed???
                File.AppendAllText("connection issues.txt", "########### Program stopped at " + now.ToString() + " ###########" + Environment.NewLine + Environment.NewLine);
                this.textBoxInterval.Enabled = true;
                this.buttonClear.Enabled = true;
                this.labelRunning.Text = "Waiting . . .";
            }
        }

        int i = 0;
        private void Checker()
        {
            DateTime now = DateTime.Now;

            if (ping() == false)
            {
                File.AppendAllText("connection issues.txt", now.ToString() +" The server ("+ GetHost() + ")could not be reached. Your internetconnection might be down." + Environment.NewLine);
            }
            else
            {
                //Uncomment this if every ping should be written into the file
                //File.AppendAllText("connection issues.txt", jetzt.ToString() + " The server (" + GetHost() +") is responing. Internet is up." + Environment.NewLine);
            }
            
            i++;
            if (i >= listServer.Count())
            {
                i -= listServer.Count();
            }
        }
        
        public bool ping()
        {
            try
            {
                //https://stackoverflow.com/questions/2031824/what-is-the-best-way-to-check-for-internet-connectivity-using-net
                Ping myPing = new Ping();
                String host = GetHost();
                byte[] buffer = new byte[32];
                int timeout = 2000;
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

        //readonly list insted of just a list?? Just add a string to the end of the list. Other methods do not need to be changed
        readonly List<string> listServer = new List<string>() { "8.8.8.8", "www.GitHub.com", "www.google.de" };
        private string GetHost()
        {
            string name = listServer[i]; // Index is 0-based
            return name;
        }

        public void ClearEverything()
        {   
            //Triggered by UsercontrolClearConfirm
            string originalText = this.labelRunning.Text;
            new Thread(() =>
            {
                this.labelRunning.BeginInvoke((MethodInvoker)delegate () { this.labelRunning.Text = "Clearing . . ."; ; });
                Thread.CurrentThread.IsBackground = true;
                File.WriteAllText(("connection issues.txt"), String.Empty);
                Thread.Sleep(2500);
                this.labelRunning.BeginInvoke((MethodInvoker)delegate () { this.labelRunning.Text = originalText; ; });
            }).Start();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (File.Exists("connection issues.txt"))
            {
                //Opens the textfile
                Process.Start("connection issues.txt"); 
            } else
            {   
                //If the textfile doesn't exists, the program creates one, dispoeses the filecreator and opens the textfile
                File.CreateText("connection issues.txt").Dispose();
                Process.Start("connection issues.txt");  
            } 
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //gets the Time of now 
            DateTime now = DateTime.Now;

            if (this.labelRunning.Text == "Running . . .")
            {
                File.AppendAllText("connection issues.txt", "########### Program stopped at " + now.ToString() + " ###########" + Environment.NewLine + Environment.NewLine);
                try
                {
                    timer.Dispose();
                }
                catch
                {
                }
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.TopMost = true;
            Show();
            WindowState = FormWindowState.Normal;
            this.TopMost = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.SettingHideWhenMin == true && WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
            }
        }

        //Method watches config.txt and if changed by another process
        //https://stackoverflow.com/questions/721714/notification-when-a-file-changes
        //https://docs.microsoft.com/en-us/dotnet/api/system.io.filesystemwatcher?redirectedfrom=MSDN&view=netcore-3.1

        //declare the watcher out of the method to make it run all the time??
        private static FileSystemWatcher watcher;
        public void watchFiles(string path)
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "config.txt"))
            {
                File.CreateText("config.txt").Dispose();
            }

            new Thread(() =>
            {
                if (watcher != null)
                {
                    watcher.EnableRaisingEvents = false;
                    watcher.Created -= new FileSystemEventHandler(OnChanged);
                }
                watcher = new FileSystemWatcher();
                watcher.Path = Path.GetDirectoryName(path); 
                watcher.Filter = Path.GetFileName(path);
                watcher.Changed += new FileSystemEventHandler(OnChanged);
                watcher.EnableRaisingEvents = true;
            }).Start();
        }

        // OnChange eventhandler makes the already running Form1 visible again
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            MethodInvoker Form1Visible = () => this.Visible = true;
            MethodInvoker Form1WindowStateNormal = () => this.WindowState = FormWindowState.Normal;
            
            this.BeginInvoke(Form1Visible);
            this.BeginInvoke(Form1WindowStateNormal);
        }

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
            else
            {
            }
        }

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

        public void PanelSettings_Hide()
        {
            this.panel2.BringToFront();
            this.panel2.Visible = true;
            this.panel2.Show();
            this.panelSeetings.SendToBack();
        }

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
        private void WriteDataToNewFile() 
        {
            //Copies lines starting with a number to backup file
            //https://stackoverflow.com/questions/7276158/skip-lines-that-contain-semi-colon-in-text-file
            //https://stackoverflow.com/questions/1245243/delete-specific-line-from-a-text-file#:~:text=The%20best%20way%20to%20do,line%20you%20want%20to%20delete.
            //https://stackoverflow.com/questions/6480058/remove-blank-lines-in-a-text-file
            //https://asp-net-example.blogspot.com/2013/10/c-example-string-starts-with-number.html

            //Original file
            using (var reader = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\connection issues.txt"))

            //Temporary new file, Could also be a string or array
            using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\connection issues - copy.txt"))
            
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
        private void DeleteOldFile()
        {
            string FilepathToDelete = AppDomain.CurrentDomain.BaseDirectory + @"\connection issues.txt";
            File.Delete(FilepathToDelete);
        }
        private void RenameOldFileToNew()
        {
            //source: https://stackoverflow.com/questions/3218910/rename-a-file-in-c-sharp
            string oldFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\connection issues - copy.txt";
            string newFilePath = AppDomain.CurrentDomain.BaseDirectory + @"\connection issues.txt";
            
            System.IO.File.Move(oldFilePath, newFilePath );
        }

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

        private void ChangeConfig()
        {
            DateTime now = DateTime.Now;
            File.WriteAllText(("config.txt"), now.ToString());
        }

    }
}

