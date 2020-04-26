using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;

namespace Internet_Check
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.textBoxInterval.Text = Properties.Settings.Default.SettingInterval.ToString();
            notifyIcon1.Visible = true;
            //this.textBoxInterval.TabStop = false; //to disable the highlight in textBoxInterval which sometimes occure
            textBoxInterval.SelectionStart = 0;
            textBoxInterval.SelectionLength = textBoxInterval.Text.Length;
        }
        public static int countclick = 0;
        private System.Threading.Timer timer;
        private void button1_Click(object sender, EventArgs e)
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
                            this.labelErrormessage.BeginInvoke((MethodInvoker)delegate () { this.labelErrormessage.Text = "Please enter only positve numbers that are smaller than 32767 but bigger than 4."; ; });
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
                //MessageBox.Show("Enter an intervall.", "Interval Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

                //this.labelErrormessage.Text = "Please enter an intervall.";
                //this.panelError.Visible = true;
                
                this.panelError.BringToFront();
                new Thread(() =>
                {
                    this.labelErrormessage.BeginInvoke((MethodInvoker)delegate () { this.labelErrormessage.Text = "Please enter an intervall." ; ; });
                    this.panelError.BeginInvoke((MethodInvoker)delegate () { this.panelError.Visible = true; ; });
                    Thread.Sleep(2700);
                    Thread.CurrentThread.IsBackground = true;
                    this.panelError.BeginInvoke((MethodInvoker)delegate () { this.panelError.Visible = false; ; });

                }).Start();
                
            }
            
        }   

        private void tTimer()
        {
            DateTime jetzt = DateTime.Now;
            if (countclick % 2 == 1)
            {
                this.textBoxInterval.Enabled = false;
                this.buttonClear.Enabled = false;
                jetzt = DateTime.Now;
                var startTimeSpan = TimeSpan.Zero;
                var periodTimeSpan = TimeSpan.FromSeconds(Properties.Settings.Default.SettingInterval);
                File.AppendAllText("Internetabbrüche.txt", "########### Program started at " + jetzt.ToString() + " ###########" + Environment.NewLine);
                this.labelRunning.Text = "Running . . .";
                timer = new System.Threading.Timer((d) =>
                {
                    Checker();
                }, null, startTimeSpan, periodTimeSpan);
            }
            else
            {
                timer.Dispose();
                File.AppendAllText("Internetabbrüche.txt", "########### Program stopped at " + jetzt.ToString() + " ###########" + Environment.NewLine + Environment.NewLine);
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
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }
    }
}
