using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;
using System.Xml;

namespace Internet_Check
{
    public partial class UserSettings : UserControl
    {
        Form1 form1;
        public UserSettings()
        {
            InitializeComponent();
            //Set Checkboxes to the settings
            this.checkBoxDarkmode.Checked = Properties.Settings.Default.SettingDarkmode;
            this.checkBoxHideWhenMin.Checked = Properties.Settings.Default.SettingHideWhenMin;
            this.checkBoxStartWithWindows.Checked = Properties.Settings.Default.SettingWindowsStart;

            //Start the Form in DarkMode
            if (Properties.Settings.Default.SettingDarkmode == true)
            {
                UserSettingsDarkmodeForm();
            }
        }

        private void checkBoxDarkmode_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxDarkmode.Checked == true)
            {
                Properties.Settings.Default.SettingDarkmode = true;
                Properties.Settings.Default.Save();
               
                try
                {
                    form1.DarkmodeForm();
                    UserSettingsDarkmodeForm(); 
                }
                catch
                {}
            }
            else
            {
                Properties.Settings.Default.SettingDarkmode = false;
                Properties.Settings.Default.Save();
                try
                {
                    form1.LightmodeForm();
                    UserSettingsLightmodeForm();  
                }
                catch
                {}
            }
        }

        private void checkBoxStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            bool errorsCaught = false;

            if (this.checkBoxStartWithWindows.Checked != Properties.Settings.Default.SettingWindowsStart)
            {
                if (this.checkBoxStartWithWindows.Checked == true)
                {
                    using (TaskService ts = new TaskService())
                    {
                        try
                        {
                            //TaskSceduler by https://github.com/dahall/TaskScheduler
                            TaskDefinition td = ts.NewTask();
                            td.Triggers.Add(new LogonTrigger());
                            td.Actions.Add(new ExecAction(System.Reflection.Assembly.GetEntryAssembly().Location,"fromTask", null));
                            td.RegistrationInfo.Description = "Launches Internet-Check with login";
                            td.RegistrationInfo.Author = "Niklas Fischer";
                            td.Principal.RunLevel = TaskRunLevel.Highest;

                            //get the XML Settings. XML Reader is in form1; Interval XML reader is in this class (UserSettings.cs)
                            td.Settings.DisallowStartIfOnBatteries = form1.boolAdvancedSettings("DisallowStartIfOnBatteries", false);
                            td.Settings.StopIfGoingOnBatteries = form1.boolAdvancedSettings("StopIfGoingOnBatteries", false);
                            td.Settings.IdleSettings.StopOnIdleEnd = form1.boolAdvancedSettings("StopOnIdleEnd", false);
                            TimeSpan interval = new TimeSpan(form1.intAdvancedSettings("TaskSchedulerStopTaskAfterDays", 5), 0, 0, 0);
                            td.Settings.ExecutionTimeLimit = interval;
                            ts.RootFolder.RegisterTaskDefinition(@"Internet-Check", td);

                        }
                        catch
                        {
                            form1.ErrorMessage("Please restart the app with admin rights. \n Settings were not applied!");
                            this.checkBoxStartWithWindows.Checked = false;
                            errorsCaught = true;
                        }

                        if (!errorsCaught)
                        {
                            //If everything is ok
                            Properties.Settings.Default.SettingTask = "Internet-Check";
                            Properties.Settings.Default.SettingWindowsStart = true;
                            Properties.Settings.Default.Save();
                            this.checkBoxStartWithWindows.Checked = true;

                            // If Hide when Minimized and start with windows are both enabled and heckBoxStartWithWindows.Checked is still false(manipulated by the above try/catch, the user will get an ErrorMessage
                            if (Properties.Settings.Default.SettingHideWhenMin == true & this.checkBoxStartWithWindows.Checked == true && Properties.Settings.Default.SettingWindowsStart == true)
                            {
                                form1.ErrorMessage("On Windows boot the application will start \n running in the background and you won't see it! \n You can access the program through the System Tray.");
                            }
                        }
                    }

                }
                else if (this.checkBoxStartWithWindows.Checked == false)
                {
                    using (TaskService ts = new TaskService())
                    {
                        try
                        {
                            ts.RootFolder.DeleteTask(Properties.Settings.Default.SettingTask);
                            Properties.Settings.Default.SettingTask = "";
                        }
                        catch
                        {
                            form1.ErrorMessage("Please restart the app with admin rights. \n Settings were not applied!");
                            this.checkBoxStartWithWindows.Checked = true;
                            errorsCaught = true;
                        }

                        if (!errorsCaught)
                        {
                            //if everything is ok
                            Properties.Settings.Default.SettingWindowsStart = false;
                            Properties.Settings.Default.Save();
                        }
                    }
                }
            }
        }

        private void checkBoxHideWhenMin_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxHideWhenMin.Checked == true)
            {
                Properties.Settings.Default.SettingHideWhenMin = true;
                Properties.Settings.Default.Save();

                if (Properties.Settings.Default.SettingHideWhenMin == true & this.checkBoxStartWithWindows.Checked == true && Properties.Settings.Default.SettingWindowsStart == true)
                {
                    form1.ErrorMessage("On Windows boot the application will start \n running in the background and you won't see it! \n You can access the program through the System Tray.");
                }
            }
            else
            {
                Properties.Settings.Default.SettingHideWhenMin = false;
                Properties.Settings.Default.Save();
            }
        }

        private void UserSettingsDarkmodeForm()
        {
            this.checkBoxDarkmode.ForeColor = Color.FromArgb(233, 233, 233);
            this.checkBoxStartWithWindows.ForeColor = Color.FromArgb(233, 233, 233);
            this.checkBoxHideWhenMin.ForeColor = Color.FromArgb(233, 233, 233);
            this.buttonBack.ForeColor = Color.FromArgb(233, 233, 233);
        }
        private void UserSettingsLightmodeForm()
        {
            this.checkBoxDarkmode.ForeColor = Color.Black;
            this.checkBoxStartWithWindows.ForeColor = Color.Black;
            this.checkBoxHideWhenMin.ForeColor = Color.Black;
            this.buttonBack.ForeColor = Color.Black;
        }
        
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.SendToBack();
            this.Visible = false;
        }

        //Kollege -Ole regelt
        public void setForm1 (Form1 f)
        {
            form1 = f;
        }
        private void doInForm1 ()
        {
            form1.DarkmodeForm();
        }
    }
}
