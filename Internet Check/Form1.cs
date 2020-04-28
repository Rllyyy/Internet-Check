using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading;
using System.Linq;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Internet_Check
{
    public partial class Form1 : Form
    {
        public Form1()
        {   
            var MultipleInstances = Process.GetProcessesByName(Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1; //https://stackoverflow.com/questions/6392031/how-to-check-if-another-instance-of-the-application-is-running
            if (MultipleInstances)
            {
                Run();
                Application.Exit();
            } 
            else
            {
                formStart();
            }
              
        }
        private void formStart ()
        {
            InitializeComponent();
            this.textBoxInterval.Text = Properties.Settings.Default.SettingInterval.ToString();
            notifyIcon1.Visible = true;
            this.button1.Text = "Start";

            //this.textBoxInterval.TabStop = false; //to disable the highlight in textBoxInterval which sometimes occure
            textBoxInterval.SelectionStart = 0;
            textBoxInterval.SelectionLength = textBoxInterval.Text.Length;
            bool Darkmode = false;
            if (Darkmode)
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
                        //MessageBox.Show("Please enter only positve numbers that are smaller than 32767 but bigger than 4");
                        this.panelError.BringToFront();
                        new Thread(() =>
                        {
                            this.labelErrormessage.BeginInvoke((MethodInvoker)delegate () { this.labelErrormessage.Text = "Please enter only positve numbers that inbetween 4 and 32766"; ; });
                            this.panelError.BeginInvoke((MethodInvoker)delegate () { this.panelError.Visible = true; ; });
                            Thread.Sleep(5000);
                            Thread.CurrentThread.IsBackground = true;
                            this.panelError.BeginInvoke((MethodInvoker)delegate () { this.panelError.Visible = false; ; });

                        }).Start();
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
                this.panelError.BringToFront();
                new Thread(() =>
                {
                    this.labelErrormessage.BeginInvoke((MethodInvoker)delegate () { this.labelErrormessage.Text = "Please enter an intervall."; ; });
                    this.panelError.BeginInvoke((MethodInvoker)delegate () { this.panelError.Visible = true; ; });
                    Thread.Sleep(2700);
                    Thread.CurrentThread.IsBackground = true;
                    this.panelError.BeginInvoke((MethodInvoker)delegate () { this.panelError.Visible = false; ; });
                }).Start();
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
                File.AppendAllText("Internetabbrüche.txt", "########### Program started at " + now.ToString() + " ###########" + Environment.NewLine);
                this.labelRunning.Text = "Running . . .";
                timer = new System.Threading.Timer((d) =>
                {
                    Checker();
                }, null, startTimeSpan, periodTimeSpan);
            }
            else
            {
                this.button1.Text = "Start";
                timer.Dispose();
                File.AppendAllText("Internetabbrüche.txt", "########### Program stopped at " + now.ToString() + " ###########" + Environment.NewLine + Environment.NewLine);
                this.textBoxInterval.Enabled = true;
                this.buttonClear.Enabled = true;
                this.labelRunning.Text = "Waiting . . .";
            }
        }

        private void Checker()
        {
            DateTime jetzt = DateTime.Now;
            if (ping() == false)
            {
                File.AppendAllText("Internetabbrüche.txt", jetzt.ToString() + " " + "Google DNS-Server (8.8.8.8) could not be reached" + Environment.NewLine);
            }
            else
            {
                //Activate this if every ping should be written into the file
                //File.AppendAllText("Internetabbrüche.txt", jetzt.ToString() + " " + "Internet ist da" + Environment.NewLine);
            }
        }
        public bool ping()
        {

            try
            {
                //https://stackoverflow.com/questions/2031824/what-is-the-best-way-to-check-for-internet-connectivity-using-net
                Ping myPing = new Ping();
                String host = "8.8.8.8";
                byte[] buffer = new byte[32];
                int timeout = 2000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);

            }
            catch (Exception)
            {
                return false;
            }

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            string originalText = this.labelRunning.Text;


            new Thread(() =>
            {
                this.labelRunning.BeginInvoke((MethodInvoker)delegate () { this.labelRunning.Text = "Clearing . . ."; ; });
                Thread.Sleep(1100);
                Thread.CurrentThread.IsBackground = true;
                File.WriteAllText(("Internetabbrüche.txt"), String.Empty);
                this.labelRunning.BeginInvoke((MethodInvoker)delegate () { this.labelRunning.Text = originalText; ; });

            }).Start();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (File.Exists("Internetabbrüche.txt"))
            {
                Process.Start("Internetabbrüche.txt"); 
            } else
            {
                File.CreateText("Internetabbrüche.txt");
                Process.Start("Internetabbrüche.txt");
            } 
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DateTime jetzt = DateTime.Now;

            if (this.labelRunning.Text == "Running . . .")
            {
                File.AppendAllText("Internetabbrüche.txt", "########### Program stopped at " + jetzt.ToString() + " ###########" + Environment.NewLine + Environment.NewLine);
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
            /*
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
            */
            
        }
       //Author unknown
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int ShowWindowFuntion = 9;
        private void Run()
        {
            Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist.Where(process => process.ProcessName == "Internet Check"))
            {
                ShowWindow(Process.GetProcessById(process.Id).MainWindowHandle, ShowWindowFuntion); //https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-showwindow
                WindowHelper.BringProcessToFront(process);
                this.Close();
            }
        }

        private void DarkmodeForm()
        {     
            this.BackColor = Color.FromArgb(56, 55, 55);
            this.button1.ForeColor = Color.FromArgb(233, 233, 233);
            this.buttonOpen.ForeColor = Color.FromArgb(233, 233, 233);
            this.buttonClear.ForeColor = Color.FromArgb(233, 233, 233);
            this.labelErrormessage.ForeColor = Color.FromArgb(233, 233, 233);
        }

        public static class WindowHelper
        {
            //https://stackoverflow.com/questions/2636721/bring-another-processes-window-to-foreground-when-it-has-showintaskbar-false
            public static void BringProcessToFront(Process process)
            {
                IntPtr handle = process.MainWindowHandle;
                if (IsIconic(handle))
                {
                    ShowWindow(handle, SW_RESTORE);
                }

                SetForegroundWindow(handle);
            }

            const int SW_RESTORE = 9;

            [System.Runtime.InteropServices.DllImport("User32.dll")]
            private static extern bool SetForegroundWindow(IntPtr handle);
            [System.Runtime.InteropServices.DllImport("User32.dll")]
            private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
            [System.Runtime.InteropServices.DllImport("User32.dll")]
            private static extern bool IsIconic(IntPtr handle);
        }
        /*
        private void textBoxInterval_TextChanged(object sender, EventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                ClickEvent();
            }
            else
            {

            }
        }
        */
    }
}

