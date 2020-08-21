using System;
using System.Drawing;
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
                            //TaskSceduler by https://github.com/dahall/TaskScheduler
                            TaskDefinition td = ts.NewTask();
                            td.RegistrationInfo.Description = "Launches Internet-Check with logon";
                            td.Triggers.Add(new LogonTrigger());
                            td.Actions.Add(new ExecAction(System.Reflection.Assembly.GetEntryAssembly().Location, null, null));
                            td.RegistrationInfo.Author = "Niklas Fischer";
                            td.Principal.RunLevel = TaskRunLevel.Highest;
                            ts.RootFolder.RegisterTaskDefinition(@"Internet-Check", td);

                            //Accept new properties
                            Properties.Settings.Default.SettingWindowsStart = true;
                            Properties.Settings.Default.SettingTask = "Internet-Check";
                            Properties.Settings.Default.Save();

                        }
                        catch
                        {
 
                            //Give the User an errormessage if the app is not startet with admin rights. Errormessages are stored in form1
                            form1.UserErrorMessage("Please restart the app with admin rights. \n Settings were not applied!", 3500);
                            this.checkBoxStartWithWindows.Checked = false;
                        }
                    }
                    //If Hide whe Minimized and start with windows are both enabled and heckBoxStartWithWindows.Checked is still false (manipulated by the above try/catch, the user will get an ErrorMessage
                    if (Properties.Settings.Default.SettingHideWhenMin == true & this.checkBoxStartWithWindows.Checked == true)
                    {
                        form1.UserErrorMessage("On Windows boot the application will start \n running in the background and you won't see it! \n You can access the program through the systemtray.", 8000);
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
                        form1.UserErrorMessage("Please restart the app with admin rights. \n Settings were not applied!", 3500);
                        this.checkBoxStartWithWindows.Checked = true;
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
    }
}
