using Microsoft.Win32.TaskScheduler;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace Internet_Check
{
    public partial class AppSettings : Form
    {
        Form1 f1;
        public AppSettings(Form1 fe)
        {
            InitializeComponent();
            setAppSettings();
            accessForm1(fe);
            setDefaults();
            checkIfStartWithDarkmode();
        }

        private void setDefaults()
        {
            //custom Colors
            customColors.redDark = Color.FromArgb(135, 0, 2);
            customColors.text = Color.Black;
            customColors.backColorDark = Color.FromArgb(56, 55, 55);
            customColors.foreColorLight = Color.FromArgb(233, 233, 233);

            //Settings Changed
            settingChanged.TaskSchedulerSettingsChanged = false;
            settingChanged.CollectingSettingsChanged = false;

            //UIs
            //Remove the border when the button is clicked an the appSettings UI thread is paused
            buttonEditServers.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            if (this.checkBoxUseCustomServers.Checked) this.buttonEditServers.Visible = true;
            setLinkLabelDownloadLateste();

        }

        public static class customColors
        {
            public static Color redDark;
            public static Color text;
            public static Color backColorDark;
            public static Color foreColorLight;
        }

        public static class settingChanged
        {
            public static bool TaskSchedulerSettingsChanged;
            public static bool CollectingSettingsChanged;
        }

        private void setLinkLabelDownloadLateste()
        {
            this.linkLabelDownloadLatest.Text = $"Local Version: {f1.getAssemblyFileVersion()}";
            if (!String.IsNullOrEmpty(f1.newerDownloadLink))
            {
                int lenghtBefore = this.linkLabelDownloadLatest.Text.Length;
                this.linkLabelDownloadLatest.Text += $" | Install latest Update ({f1.githubLatestReleaseTag})";
                this.linkLabelDownloadLatest.LinkArea = new LinkArea(lenghtBefore + 3, this.linkLabelDownloadLatest.Text.Length);
            }
        }

        private void checkIfStartWithDarkmode()
        {
            if (Properties.Settings.Default.SettingDarkmode)
            {
                AppSettingsDarkModeForm();
            } else
            {
                customColors.text = Color.FromArgb(0, 0, 0);
            }
        }

        private void setAppSettings()
        {
            //Load Settings
            this.checkBoxDarkmode.Checked = Properties.Settings.Default.SettingDarkmode;
            this.checkBoxHideWhenMin.Checked = Properties.Settings.Default.SettingHideWhenMin;
            this.checkBoxShowMinimizedInfo.Checked = Properties.Settings.Default.SettingCheckBoxShowMinimizedInfo;
            this.checkBoxStartWithWindows.Checked = Properties.Settings.Default.SettingWindowsStart;
            this.checkBoxConnectionNotification.Checked = Properties.Settings.Default.SettingConnectionNotification;
            this.checkBoxDisableUpdateNotifications.Checked = Properties.Settings.Default.SettingDisableUpdateNotifications;

            //Load advanced Settings
            this.comboBoxDoubleCheckServer.SelectedItem = Properties.Settings.Default.SettingDoubleCheckServer;
            this.checkBoxUseAlternativePingMethod.Checked = Properties.Settings.Default.SettingUseAlternativePingMethod;
            this.checkBoxAllPingResults.Checked = Properties.Settings.Default.SettingCheckBoxAllPingResults;
            this.checkBoxUseCustomServers.Checked = Properties.Settings.Default.SettingUseCustomServers;
            this.textBoxTaskSchedulerStopTaskAfterDays.Text = Properties.Settings.Default.SettingTextBoxTaskSchedulerStopTaskAfterDays.ToString();
            this.checkBoxDisallowStartIfOnBatteries.Checked = Properties.Settings.Default.SettingCheckBoxDisallowStartIfOnBatteries;
            this.checkBoxStopIfGoingOnBatteries.Checked = Properties.Settings.Default.SettingCheckBoxStopIfGoingOnBatteries; 
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //Basic Settings apart from Task Scheduler
            checkDarkModeChanged();
            checkHideWhenMinChanged();
            checkShowMinimizedInfoChanged();
            checkConnectionNotificationChanged();
            checkDisableUpdateNotificationsChanged();

            //Advanced Settings
            checkDoubleCheckServerChanged();
            checkUseAlternativePingMethodChanged();
            checkAllPingResultsChanged();
            checkUseCustomServersChanged();

            //Task Scheduler Settings
            checkTaskSchedulerStopTaskAfterDays();
            checkDisallowStartIfOnBatteries();
            checkStopIfGoingOnBatteries();

            AddOrRemoveTaskScheduler();
            checkCollectingSettingsChanged();
            Properties.Settings.Default.Save();

            this.Close();
            this.Dispose();
        }

        //Define the default values. The user still needs to click Apply & Exit
        private void buttonDefault_Click(object sender, EventArgs e)
        {
            //Set default Settings
            this.checkBoxDarkmode.Checked = false;
            this.checkBoxHideWhenMin.Checked = false;
            this.checkBoxShowMinimizedInfo.Checked = true;
            this.checkBoxStartWithWindows.Checked = false;
            this.checkBoxConnectionNotification.Checked = true;
            this.checkBoxDisableUpdateNotifications.Checked = false;

            //Set default advanced Settings
            this.comboBoxDoubleCheckServer.SelectedItem = "Next";
            this.checkBoxUseAlternativePingMethod.Checked = false;
            this.checkBoxAllPingResults.Checked = false;
            this.checkBoxUseCustomServers.Checked = false;
            
            //Set default Task Scheduler Settings
            this.textBoxTaskSchedulerStopTaskAfterDays.Text = 5.ToString();
            this.checkBoxDisallowStartIfOnBatteries.Checked = false;
            this.checkBoxStopIfGoingOnBatteries.Checked = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void checkDarkModeChanged()
        {
            if (this.checkBoxDarkmode.Checked != Properties.Settings.Default.SettingDarkmode)
            {
                Properties.Settings.Default.SettingDarkmode = this.checkBoxDarkmode.Checked;
                setColorInForm1();
            }
        }

        private void checkHideWhenMinChanged()
        {
            if (this.checkBoxHideWhenMin.Checked != Properties.Settings.Default.SettingHideWhenMin)
            {
                Properties.Settings.Default.SettingHideWhenMin = this.checkBoxHideWhenMin.Checked;
            }
        }

        private void checkShowMinimizedInfoChanged()
        {
            if (this.checkBoxShowMinimizedInfo.Checked != Properties.Settings.Default.SettingCheckBoxShowMinimizedInfo)
            {
                Properties.Settings.Default.SettingCheckBoxShowMinimizedInfo = this.checkBoxShowMinimizedInfo.Checked;
            }
        }

        private void checkConnectionNotificationChanged()
        {
            if (this.checkBoxConnectionNotification.Checked != Properties.Settings.Default.SettingConnectionNotification)
            {
                Properties.Settings.Default.SettingConnectionNotification = this.checkBoxConnectionNotification.Checked;
            }
        }

        private void checkDisableUpdateNotificationsChanged()
        {
            if (this.checkBoxDisableUpdateNotifications.Checked != Properties.Settings.Default.SettingDisableUpdateNotifications)
            {
                Properties.Settings.Default.SettingDisableUpdateNotifications = this.checkBoxDisableUpdateNotifications.Checked;
            }
        }

        private void checkDoubleCheckServerChanged()
        {
            if (comboBoxDoubleCheckServer.SelectedItem.ToString() != Properties.Settings.Default.SettingDoubleCheckServer)
            {
                Properties.Settings.Default.SettingDoubleCheckServer = comboBoxDoubleCheckServer.SelectedItem.ToString();
                settingChanged.CollectingSettingsChanged = true;
            }
        }

        private void checkUseAlternativePingMethodChanged()
        {
            if (this.checkBoxUseAlternativePingMethod.Checked != Properties.Settings.Default.SettingUseAlternativePingMethod)
            {
                Properties.Settings.Default.SettingUseAlternativePingMethod = this.checkBoxUseAlternativePingMethod.Checked;
                settingChanged.CollectingSettingsChanged = true;
            }
        }

        private void checkAllPingResultsChanged()
        {
            if (this.checkBoxAllPingResults.Checked != Properties.Settings.Default.SettingCheckBoxAllPingResults)
            {
                Properties.Settings.Default.SettingCheckBoxAllPingResults = this.checkBoxAllPingResults.Checked;
                settingChanged.CollectingSettingsChanged = true;
            }
        }

        private void checkUseCustomServersChanged()
        {
            if (this.checkBoxUseCustomServers.Checked != Properties.Settings.Default.SettingUseCustomServers)
            {
                Properties.Settings.Default.SettingUseCustomServers = this.checkBoxUseCustomServers.Checked;
                settingChanged.CollectingSettingsChanged = true;
            }
        }

        private void checkTaskSchedulerStopTaskAfterDays()
        {
            if (this.textBoxTaskSchedulerStopTaskAfterDays.Text != Properties.Settings.Default.SettingTextBoxTaskSchedulerStopTaskAfterDays.ToString())
            {
                settingChanged.TaskSchedulerSettingsChanged = true;

                try
                {
                    Properties.Settings.Default.SettingTextBoxTaskSchedulerStopTaskAfterDays = Int32.Parse(this.textBoxTaskSchedulerStopTaskAfterDays.Text);
                }
                catch
                {
                    Properties.Settings.Default.SettingTextBoxTaskSchedulerStopTaskAfterDays = 5;
                }
            }
        }

        private void checkDisallowStartIfOnBatteries()
        {
            if (this.checkBoxDisallowStartIfOnBatteries.Checked != Properties.Settings.Default.SettingCheckBoxDisallowStartIfOnBatteries)
            {
                Properties.Settings.Default.SettingCheckBoxDisallowStartIfOnBatteries = this.checkBoxDisallowStartIfOnBatteries.Checked;
                settingChanged.TaskSchedulerSettingsChanged = true;
            }
        }

        private void checkStopIfGoingOnBatteries()
        {
            if (this.checkBoxStopIfGoingOnBatteries.Checked != Properties.Settings.Default.SettingCheckBoxStopIfGoingOnBatteries)
            {
                Properties.Settings.Default.SettingCheckBoxStopIfGoingOnBatteries = checkBoxStopIfGoingOnBatteries.Checked;
                settingChanged.TaskSchedulerSettingsChanged = true;
            }
        }

        private void addTaskScheduler()
        {
            bool caughtError = false;

            //Check if already exit? is this a problem??

            using (TaskService ts = new TaskService())
            {
                try
                {
                    //TaskSceduler by https://github.com/dahall/TaskScheduler
                    //The task scheduler takes the settings from the form and not properties.settings.default because they are changed when the use clicks apply & exit
                    TaskDefinition td = ts.NewTask();
                    td.Triggers.Add(new LogonTrigger());
                    td.Actions.Add(new ExecAction(System.Reflection.Assembly.GetEntryAssembly().Location, "fromTask", null));
                    td.RegistrationInfo.Description = "Launches Internet-Check with login";
                    td.RegistrationInfo.Author = "Niklas Fischer";
                    td.Principal.RunLevel = TaskRunLevel.Highest;

                    //Get the Settings from the form
                    td.Settings.DisallowStartIfOnBatteries = this.checkBoxDisallowStartIfOnBatteries.Checked;
                    td.Settings.StopIfGoingOnBatteries = this.checkBoxStopIfGoingOnBatteries.Checked;
                    td.Settings.IdleSettings.StopOnIdleEnd = false;
                    TimeSpan interval = new TimeSpan(Int32.Parse(this.textBoxTaskSchedulerStopTaskAfterDays.Text), 0, 0, 0);
                    td.Settings.ExecutionTimeLimit = interval;
                    ts.RootFolder.RegisterTaskDefinition(@"Internet-Check", td);
                }
                catch (Exception e)
                {
                    caughtError = true;
                    this.labelUserMessage.Visible = true;
                    this.labelUserMessage.Text = $"There was an Error with adding the Task Scheduler.\nPlease contact the developer here: https://github.com/Rllyyy/Internet-Check/issues with a screenshot of the following message:\n {e}";
                    this.checkBoxStartWithWindows.Checked = !this.checkBoxStartWithWindows.Checked;
                }
            }

            if (!caughtError)
            {
                //If everything is ok
                Properties.Settings.Default.SettingTask = "Internet-Check";
                Properties.Settings.Default.SettingWindowsStart = true;
            }
        }

        private void removeTaskScheduler()
        {
            bool caughtError = false;

            //TaskSceduler by https://github.com/dahall/TaskScheduler
            using (TaskService ts = new TaskService())
            {
                try
                {
                    ts.RootFolder.DeleteTask(Properties.Settings.Default.SettingTask);
                }
                catch (Exception e)
                {
                    caughtError = true;
                    this.labelUserMessage.Visible = true;
                    MessageBox.Show($"You may need to remove the task manually. Click the windows key and type Task Scheduler. Right click on Internet-Check in the Task Scheduler Settings and delete the task. Please also contact the developer here: https://github.com/Rllyyy/Internet-Check/issues with a screenshot of the following message:\n {e}");
                    this.checkBoxStartWithWindows.Checked = !this.checkBoxStartWithWindows.Checked;
                }
            }

            if (!caughtError)
            {
                Properties.Settings.Default.SettingWindowsStart = false;
                Properties.Settings.Default.SettingTask = "";
            }
        }

        private void checkBoxHideWhenMin_Click(object sender, EventArgs e)
        {
            //Show Warning if booth hide when minimized and start with windows are checked
            if (this.checkBoxHideWhenMin.Checked && this.checkBoxStartWithWindows.Checked)
            {
                startWithWindowsAndHideWhenMinActive();
            }
        }

        private void checkBoxStartWithWindows_Click(object sender, EventArgs e)
        {
            //Guard
            if (!isAdministrator()) 
            {
                //Reset the Checkbox to the original state
                this.checkBoxStartWithWindows.Checked = !this.checkBoxStartWithWindows.Checked;
                //Show User message and highlight checkBox on thread for 18 seconds
                new Thread(() =>
                {
                    //Set UI elements for message
                    this.labelUserMessage.BeginInvoke((MethodInvoker)delegate () { this.labelUserMessage.Visible = true; });
                    this.labelUserMessage.BeginInvoke((MethodInvoker)delegate () { this.labelUserMessage.Text = "Please restart the application with Admin privileges"; });
                    this.checkBoxStartWithWindows.BeginInvoke((MethodInvoker)delegate () { this.checkBoxStartWithWindows.ForeColor = customColors.redDark; });

                    //Pause the thread for 18 seconds to show the message
                    Thread.Sleep(18000);

                    //Catch Error if the user closes the form before thread returned from sleep
                    try
                    {
                        //Reset the colors
                        this.checkBoxStartWithWindows.BeginInvoke((MethodInvoker)delegate () { this.checkBoxStartWithWindows.ForeColor = customColors.text; });
                        this.labelUserMessage.BeginInvoke((MethodInvoker)delegate () { this.labelUserMessage.Visible = false; });
                    }
                    catch
                    { }
                }).Start();
                return;
            }
            
            //Show Warning if booth hide when minimized and start with windows are checked and the user has admin privileges
            if (this.checkBoxHideWhenMin.Checked && this.checkBoxStartWithWindows.Checked)
            {
                startWithWindowsAndHideWhenMinActive();
            }

            //Enable or disable task scheduler settings for the user
            if (this.checkBoxStartWithWindows.Checked)
            {
                //Activate settings
                this.textBoxTaskSchedulerStopTaskAfterDays.Enabled = true;
                this.checkBoxDisallowStartIfOnBatteries.Enabled = true;
                this.checkBoxStopIfGoingOnBatteries.Enabled = true;
                this.labelTaskSchedulerStopTaskAfterDays.Enabled = true;
            } else
            {
                //Disable settings
                this.textBoxTaskSchedulerStopTaskAfterDays.Enabled = false;
                this.checkBoxDisallowStartIfOnBatteries.Enabled = false;
                this.checkBoxStopIfGoingOnBatteries.Enabled = false;
            }
        }

        private void startWithWindowsAndHideWhenMinActive()
        {
            new Thread(() =>
            {
                //Set UI elements for message
                this.labelUserMessage.BeginInvoke((MethodInvoker)delegate () { this.labelUserMessage.Visible = true; });
                this.labelUserMessage.BeginInvoke((MethodInvoker)delegate () { this.labelUserMessage.Text = "Warning: On Windows boot the application will start running in the background and you won't see it! \n You can access the program through the System Tray or by clicking on the Application again."; });
                this.checkBoxStartWithWindows.BeginInvoke((MethodInvoker)delegate () { this.checkBoxStartWithWindows.ForeColor = customColors.redDark; });
                this.checkBoxHideWhenMin.BeginInvoke((MethodInvoker)delegate () { this.checkBoxHideWhenMin.ForeColor = customColors.redDark; });

                //Pause the thread for 18 seconds to show the message
                Thread.Sleep(18000);

                //Catch Error if the user closes the form before thread returned from sleep
                try
                {
                    //Reset the colors
                    this.checkBoxStartWithWindows.BeginInvoke((MethodInvoker)delegate () { this.checkBoxStartWithWindows.ForeColor = customColors.text; });
                    this.checkBoxHideWhenMin.BeginInvoke((MethodInvoker)delegate () { this.checkBoxHideWhenMin.ForeColor = customColors.text; });
                    this.labelUserMessage.BeginInvoke((MethodInvoker)delegate () { this.labelUserMessage.Visible = false; });
                } catch
                {}
            }).Start();
        }

        private void AddOrRemoveTaskScheduler()
        {
            //Check if was active and task Scheduler settings changed then remove it
            if (settingChanged.TaskSchedulerSettingsChanged && this.checkBoxStartWithWindows.Checked)
            {
                removeTaskScheduler();
                addTaskScheduler();

            }
            else if (!settingChanged.TaskSchedulerSettingsChanged && this.checkBoxStartWithWindows.Checked && this.checkBoxStartWithWindows.Checked != Properties.Settings.Default.SettingWindowsStart)
            {
                addTaskScheduler();
            }
            else if (!this.checkBoxStartWithWindows.Checked && this.checkBoxStartWithWindows.Checked != Properties.Settings.Default.SettingWindowsStart)
            {
                removeTaskScheduler();
            }
        }

        private void setColorInForm1()
        {
            if (this.checkBoxDarkmode.Checked)
            {
                f1.DarkmodeForm();
            }
            else
            {
                f1.LightmodeForm();
            }
        }

        private void checkCollectingSettingsChanged()
        {
            if (settingChanged.CollectingSettingsChanged)
            {
                if (f1.labelRunning.Text == "Running . . .")
                {
                    f1.stopCollecting();
                    f1.startCollecting(); //No need to check the input (aka f1.checkIfIntervallCorrect) because program was already collecting and UI thread is blocked while settings are open.
                    f1.ErrorMessage("Because some collecting parameters changed the collecting process was restarted with the new settings");
                }
            }
        }

        public void accessForm1(Form1 fe)
        {
            f1 = fe;
        }

        private void AppSettingsDarkModeForm()
        {
            this.BackColor = customColors.backColorDark;
            this.ForeColor = customColors.foreColorLight;
            this.linkLabelDownloadLatest.LinkColor = Color.FromArgb(57, 132, 221);
            customColors.text = Color.FromArgb(233, 233, 233);
            customColors.redDark = Color.IndianRed;
        }
        private void checkBoxUseCustomServers_Click(object sender, EventArgs e)
        {
            if (checkBoxUseCustomServers.Checked)
            {
                this.buttonEditServers.Visible = true;
            }
            else
            {
                this.buttonEditServers.Visible = false;
                if (this.comboBoxDoubleCheckServer.SelectedItem.ToString() == "Google")
                {
                    customServersGoogleError();
                }
            }
        }

        private void checkBoxUseAlternativePingMethod_Click(object sender, EventArgs e)
        {
            //Check if next Next or "Google"
            if (checkBoxUseAlternativePingMethod.Checked)
            {
                checkIfUsingGoogleOrNext();
            }
        }

        private void checkIfUsingGoogleOrNext()
        {
            if (this.comboBoxDoubleCheckServer.SelectedItem.ToString() == "Google" || this.comboBoxDoubleCheckServer.SelectedItem.ToString() == "Next")
            {
                alternativePingSelectedDoubleCheckError();
            }
        }

        private void buttonEditServers_Click(object sender, EventArgs e)
        {
            FormEditServers f3 = new FormEditServers(f1);
            f3.ShowDialog();
        }

        /// <summary>
        /// Return if user has started process with admin privileges
        /// https://stackoverflow.com/questions/3600322/check-if-the-current-user-is-administrator
        /// </summary>
        /// <returns></returns>
        private bool isAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        /// <summary>
        /// SelectionChangeCommitted only fires when the user makes changes in the combo box not if done programmatically
        /// Source: https://stackoverflow.com/questions/1066057/c-sharp-combo-box-value-change-what-event-should-i-use-to-write-update-the-regi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxDoubleCheckServer_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBoxDoubleCheckServer.SelectedItem.ToString() == "Google")
            {
                if (this.checkBoxUseAlternativePingMethod.Checked)
                {
                    alternativePingSelectedDoubleCheckError();
                    return;
                }

                if (!Properties.Settings.Default.SettingUseCustomServers && !this.checkBoxUseCustomServers.Checked)
                {
                    customServersGoogleError();

                } else if (Properties.Settings.Default.SettingUseCustomServers && !this.checkBoxUseCustomServers.Checked)
                {
                    customServersGoogleError();
                }
            }
            else if (comboBoxDoubleCheckServer.SelectedItem.ToString() == "Next")
            {
                if (this.checkBoxUseAlternativePingMethod.Checked)
                {
                    alternativePingSelectedDoubleCheckError();
                }
            }
        }

        private void customServersGoogleError()
        {
            this.comboBoxDoubleCheckServer.SelectedItem = "None";
            new Thread(() =>
            {
                //Set UI elements for message
                this.labelUserMessage.BeginInvoke((MethodInvoker)delegate () { this.labelUserMessage.Visible = true; });
                this.labelUserMessage.BeginInvoke((MethodInvoker)delegate () { this.labelUserMessage.Text = "Double checking Google servers is only allowed when using custom servers"; });
                this.checkBoxStartWithWindows.BeginInvoke((MethodInvoker)delegate () { this.labelDoubleCheckServer.ForeColor = customColors.redDark; });
                this.checkBoxStartWithWindows.BeginInvoke((MethodInvoker)delegate () { this.checkBoxUseCustomServers.ForeColor = customColors.redDark; });

                //Pause the thread for 18 seconds to show the message
                Thread.Sleep(18000);

                //Catch Error if the user closes the form before thread returned from sleep
                try
                {
                    //Reset the colors
                    this.checkBoxHideWhenMin.BeginInvoke((MethodInvoker)delegate () { this.checkBoxUseCustomServers.ForeColor = customColors.text; });
                    this.checkBoxHideWhenMin.BeginInvoke((MethodInvoker)delegate () { this.labelDoubleCheckServer.ForeColor = customColors.text; });
                    this.labelUserMessage.BeginInvoke((MethodInvoker)delegate () { this.labelUserMessage.Visible = false; });
                }
                catch
                { }
            }).Start();
        }

        private void linkLabelDownloadLatest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string updateDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\Updates";

            if (!Directory.Exists(updateDirectory))
            {
                Directory.CreateDirectory(updateDirectory);
            }

            downloadFileAsync(updateDirectory);
        }

        private async System.Threading.Tasks.Task downloadFileAsync(string updateDirectory)
        {
            bool downloadError = false;
            try
            {
                using (WebClient client = new WebClient())
                {
                    byte[] bytes = await client.DownloadDataTaskAsync(new Uri(f1.newerDownloadLink));
                    File.WriteAllBytes(updateDirectory + $@"\Internet-Check-v{f1.githubLatestReleaseTag}.Setup.msi", bytes);
                }
            }
            catch
            {
                //Show Error message on exception if file failed to download (18 sec.)
                new Thread(() =>
                {
                    //Set UI elements for message
                    this.labelUserMessage.BeginInvoke((MethodInvoker)delegate () { this.labelUserMessage.Visible = true; });
                    this.labelUserMessage.BeginInvoke((MethodInvoker)delegate () { this.labelUserMessage.Text = "Failed to download the Update"; });

                    //Pause the thread for 18 seconds to show the message
                    Thread.Sleep(18000);

                    //Catch Error if the user closes the form before thread returned from sleep
                    try
                    {
                        //Hide the userMessage error
                        this.labelUserMessage.BeginInvoke((MethodInvoker)delegate () { this.labelUserMessage.Visible = false; });
                    }
                    catch
                    { }
                }).Start();

                downloadError = true;
            }

            if (!downloadError)
            {
                startSetup(updateDirectory);
            }
        }

        private void startSetup(string updateDirectory)
        {
            Process.Start(updateDirectory + $@"\Internet-Check-v{f1.githubLatestReleaseTag}.Setup.msi");
            //The (old) application will exit and close if the new version is installed. After Installation the new application will be automatically opened. 
        }

        private void alternativePingSelectedDoubleCheckError()
        {
            string prevSelectedItem = this.comboBoxDoubleCheckServer.SelectedItem.ToString();
            this.comboBoxDoubleCheckServer.SelectedItem = "None";
            new Thread(() =>
            {
                //Set UI elements for message
                this.labelUserMessage.BeginInvoke((MethodInvoker)delegate () { this.labelUserMessage.Visible = true; });
                this.labelUserMessage.BeginInvoke((MethodInvoker)delegate () { this.labelUserMessage.Text = $"Double checking {prevSelectedItem} is not allowed when using the alternative ping method. Read the documentation for more information."; });
                this.checkBoxStartWithWindows.BeginInvoke((MethodInvoker)delegate () { this.labelDoubleCheckServer.ForeColor = customColors.redDark; });
                this.checkBoxStartWithWindows.BeginInvoke((MethodInvoker)delegate () { this.checkBoxUseAlternativePingMethod.ForeColor = customColors.redDark; });

                //Pause the thread for 20 seconds to show the message
                Thread.Sleep(20000);

                //Catch Error if the user closes the form before thread returned from sleep
                try
                {
                    //Hide the userMessage error
                    this.checkBoxStartWithWindows.BeginInvoke((MethodInvoker)delegate () { this.labelDoubleCheckServer.ForeColor = customColors.text; });
                    this.checkBoxStartWithWindows.BeginInvoke((MethodInvoker)delegate () { this.checkBoxUseAlternativePingMethod.ForeColor = customColors.text; });
                    this.labelUserMessage.BeginInvoke((MethodInvoker)delegate () { this.labelUserMessage.Visible = false; });
                }
                catch
                { }
            }).Start();
        }
    }
}
