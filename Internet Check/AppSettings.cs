﻿using Microsoft.Win32.TaskScheduler;
using System;
using System.Drawing;
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
            checkIfStartWithDarkmode();
        }

        public static class customColors
        {
            public static Color redDark = Color.FromArgb(135, 0, 2);
            public static Color text = Color.Black;
            public static Color backColorDark = Color.FromArgb(56, 55, 55);
            public static Color foreColorLight = Color.FromArgb(233, 233, 233);
        }

        public static class settingChanged
        {
            public static bool TaskSchedulerSettingsChanged = false;
            public static bool CollectingSettingsChanged = false;
        }

        private void setAppSettings()
        {
            //Load Settings
            this.checkBoxDarkmode.Checked = Properties.Settings.Default.SettingDarkmode;
            this.checkBoxHideWhenMin.Checked = Properties.Settings.Default.SettingHideWhenMin;
            this.checkBoxStartWithWindows.Checked = Properties.Settings.Default.SettingWindowsStart;

            //Load advanced Settings
            this.comboBoxDoubleCheckServer.SelectedItem = Properties.Settings.Default.SettingDoubleCheckServer;
            this.checkBoxUseAlternativePingMethod.Checked = Properties.Settings.Default.SettingUseAlternativePingMethod;
            this.checkBoxAllPingResults.Checked = Properties.Settings.Default.SettingCheckBoxAllPingResults;
            this.checkBoxShowMinimizedInfo.Checked = Properties.Settings.Default.SettingCheckBoxShowMinimizedInfo;
            this.textBoxTaskSchedulerStopTaskAfterDays.Text = Properties.Settings.Default.SettingTextBoxTaskSchedulerStopTaskAfterDays.ToString();
            this.checkBoxDisallowStartIfOnBatteries.Checked = Properties.Settings.Default.SettingCheckBoxDisallowStartIfOnBatteries;
            this.checkBoxStopIfGoingOnBatteries.Checked = Properties.Settings.Default.SettingCheckBoxStopIfGoingOnBatteries;
            this.checkBoxStopOnIdleEnd.Checked = Properties.Settings.Default.SettingCheckBoxStopOnIdleEnd;
        }

        private void checkIfStartWithDarkmode()
        {
            if (Properties.Settings.Default.SettingDarkmode)
            {
                AppSettingsDarkModeForm();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            checkDarkModeChanged();
            checkHideWhenMinChanged();

            checkUseAlternativePingMethodChanged();
            checkTaskSchedulerStopTaskAfterDays();



            AddOrRemoveTaskScheduler();
            checkCollectingSettingsChanged();
            Properties.Settings.Default.Save();

            
            this.Close();
        }

        //Define the default values. The user still needs to click Apply & Exit
        private void buttonDefault_Click(object sender, EventArgs e)
        {
            //Set default Settings
            this.checkBoxDarkmode.Checked = false;
            this.checkBoxHideWhenMin.Checked = false;
            this.checkBoxStartWithWindows.Checked = false;

            //Set default advanced Settings
            this.comboBoxDoubleCheckServer.SelectedItem = "Next";
            this.checkBoxUseAlternativePingMethod.Checked = false;
            this.checkBoxAllPingResults.Checked = false;
            this.checkBoxShowMinimizedInfo.Checked = true;
            this.textBoxTaskSchedulerStopTaskAfterDays.Text = 5.ToString();
            this.checkBoxDisallowStartIfOnBatteries.Checked = false;
            this.checkBoxStopIfGoingOnBatteries.Checked = false;
            this.checkBoxStopOnIdleEnd.Checked = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkDarkModeChanged()
        {
            if (this.checkBoxDarkmode.Checked != Properties.Settings.Default.SettingDarkmode)
            {
                Properties.Settings.Default.SettingDarkmode = this.checkBoxDarkmode.Checked;
                setColorInForm1();
            }
        }

        private void setColorInForm1()
        {
            if (this.checkBoxDarkmode.Checked)
            {
                f1.DarkmodeForm();
            } else
            {
                f1.LightmodeForm();
            }
        }

        private void checkHideWhenMinChanged()
        {
            if (this.checkBoxHideWhenMin.Checked != Properties.Settings.Default.SettingHideWhenMin)
            {
                Properties.Settings.Default.SettingHideWhenMin = this.checkBoxHideWhenMin.Checked;
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
                } catch
                {
                    Properties.Settings.Default.SettingTextBoxTaskSchedulerStopTaskAfterDays = 5;
                }
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
                    td.Settings.IdleSettings.StopOnIdleEnd = this.checkBoxStopOnIdleEnd.Checked;
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

        private void checkUseAlternativePingMethodChanged()
        {
            if (this.checkBoxUseAlternativePingMethod.Checked != Properties.Settings.Default.SettingUseAlternativePingMethod)
            {
                Properties.Settings.Default.SettingUseAlternativePingMethod = this.checkBoxUseAlternativePingMethod.Checked;
                settingChanged.CollectingSettingsChanged = true;
                //Stop current ping
                //form1 user message restart with alternative ping method
            }
        }

        private void checkBoxHideWhenMin_Click(object sender, EventArgs e)
        {
            if (this.checkBoxHideWhenMin.Checked && this.checkBoxStartWithWindows.Checked)
            {
                startWithWindowsAndHideWhenMinActive();
            }
        }

        private void checkBoxStartWithWindows_Click(object sender, EventArgs e)
        {
            if (this.checkBoxHideWhenMin.Checked && this.checkBoxStartWithWindows.Checked)
            {
                startWithWindowsAndHideWhenMinActive();
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

                //Pause the thread for 10 seconds to show the message
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
                MessageBox.Show("Removed and Added Task Scheduler");

            }
            else if (!settingChanged.TaskSchedulerSettingsChanged && this.checkBoxStartWithWindows.Checked && this.checkBoxStartWithWindows.Checked != Properties.Settings.Default.SettingWindowsStart)
            {
                addTaskScheduler();
                MessageBox.Show("Added Task Scheduler");
            }
            else if (!this.checkBoxStartWithWindows.Checked && this.checkBoxStartWithWindows.Checked != Properties.Settings.Default.SettingWindowsStart)
            {
                removeTaskScheduler();
                MessageBox.Show("Removed Task Scheduler");
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

        private void doInForm1()
        {
            f1.ErrorMessage("Because some collecting parameters changed the collecting process was restarted with the new settings");
        }

        private void AppSettingsDarkModeForm()
        {
            this.BackColor = customColors.backColorDark;
            this.ForeColor = customColors.foreColorLight;
            customColors.text = Color.FromArgb(233, 233, 233);
            customColors.redDark = Color.IndianRed;
        }

    }
}
