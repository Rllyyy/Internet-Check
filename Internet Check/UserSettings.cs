using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;

namespace Internet_Check
{
    public partial class UserSettings : UserControl
    {
        Form1 form1;
        

        public UserSettings()
        {
            InitializeComponent();
            this.checkBoxDarkmode.Checked = Properties.Settings.Default.SettingDarkmode;
            this.checkBoxHideWhenMin.Checked = Properties.Settings.Default.SettingHideWhenMin;
            this.checkBoxStartWithWindows.Checked = Properties.Settings.Default.SettingWindowsStart;
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
                {
                }

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
                {
                }
            }
        }
        private void checkBoxStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void checkBoxHideWhenMin_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxHideWhenMin.Checked == true)
            {
                Properties.Settings.Default.SettingHideWhenMin = true;
                Properties.Settings.Default.Save();
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
            form1.PanelSettings_Hide();

            if (this.checkBoxStartWithWindows.Checked != Properties.Settings.Default.SettingWindowsStart)
            {
                if (this.checkBoxStartWithWindows.Checked == true)
                {
                    using (TaskService ts = new TaskService())
                    {
                        try
                        {
                            TaskDefinition td = ts.NewTask();
                            td.RegistrationInfo.Description = "Launches Internet-Check with logon";
                            td.Triggers.Add(new LogonTrigger());
                            td.Actions.Add(new ExecAction(System.Reflection.Assembly.GetEntryAssembly().Location, null, null));
                            td.Principal.RunLevel = TaskRunLevel.Highest;
                            ts.RootFolder.RegisterTaskDefinition(@"Internet-Check", td);
                            Properties.Settings.Default.SettingWindowsStart = true;
                            Properties.Settings.Default.SettingTask = "Internet-Check";
                            Properties.Settings.Default.Save();
                        }
                        catch
                        {
                            try
                            {
                                form1.UserErrorMessage("Please restart the app with admin rights. \n Settings were not applied!", 3500);
                                this.checkBoxStartWithWindows.Checked = false;
                            }
                            catch
                            {
                            }
                        }

                    }

                }
                else
                {
                    Properties.Settings.Default.SettingWindowsStart = false;
                    Properties.Settings.Default.Save();
                    // Remove the task we just created
                    try
                    {
                        using (TaskService ts = new TaskService())
                        {
                            ts.RootFolder.DeleteTask(Properties.Settings.Default.SettingTask);
                        }
                        Properties.Settings.Default.SettingTask = "";
                        Properties.Settings.Default.Save();
                    }
                    catch
                    {
                        try
                        {
                            form1.UserErrorMessage("Please restart the app with admin rights. \n Settings were not applied!", 3500);
                            this.checkBoxStartWithWindows.Checked = true;
                        }
                        catch
                        {
                            //Form1 not ininitialized
                        }
                    }
                }
            }
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

        ////
    }
}
