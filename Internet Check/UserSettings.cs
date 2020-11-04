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
                            TimeSpan interval = new TimeSpan(TaskschedulerStopTaskAfterDays(), 0, 0, 0);
                            TaskDefinition td = ts.NewTask();
                            td.RegistrationInfo.Description = "Launches Internet-Check with logon";
                            td.Triggers.Add(new LogonTrigger());
                            td.Actions.Add(new ExecAction(System.Reflection.Assembly.GetEntryAssembly().Location, null, null));
                            td.RegistrationInfo.Author = "Niklas Fischer";
                            td.Principal.RunLevel = TaskRunLevel.Highest;
                            td.Settings.DisallowStartIfOnBatteries = boolAdvancedSettings("DisallowStartIfOnBatteries", false);
                            td.Settings.StopIfGoingOnBatteries = boolAdvancedSettings("StopIfGoingOnBatteries", false);
                            td.Settings.IdleSettings.StopOnIdleEnd = boolAdvancedSettings("StopOnIdleEnd", false);
                            td.Settings.ExecutionTimeLimit = interval;
                            ts.RootFolder.RegisterTaskDefinition(@"Internet-Check", td);

                        } catch
                        {
                            form1.UserErrorMessage("Please restart the app with admin rights. \n Settings were not applied!", 4000);
                            this.checkBoxStartWithWindows.Checked = false;
                            errorsCaught = true;
                        }

                        if (!errorsCaught)
                        {
                            //If everything is ok
                            Properties.Settings.Default.SettingTask = "Internet-Check";
                            Properties.Settings.Default.SettingWindowsStart = true;
                            Properties.Settings.Default.Save();

                            // If Hide whe Minimized and start with windows are both enabled and heckBoxStartWithWindows.Checked is still false(manipulated by the above try/catch, the user will get an ErrorMessage
                            if (Properties.Settings.Default.SettingHideWhenMin == true & this.checkBoxStartWithWindows.Checked == true && Properties.Settings.Default.SettingWindowsStart == true)
                            {
                                form1.UserErrorMessage("On Windows boot the application will start \n running in the background and you won't see it! \n You can access the program through the systemtray.", 8000);
                            }
                        }
                    }

                } else if (this.checkBoxStartWithWindows.Checked == false) {

                    using (TaskService ts = new TaskService())
                    {
                        try
                        {
                            ts.RootFolder.DeleteTask(Properties.Settings.Default.SettingTask);
                            Properties.Settings.Default.SettingTask = "";
                        }
                        catch
                        {
                            form1.UserErrorMessage("Please restart the app with admin rights. \n Settings were not applied!", 3500);
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

        private int TaskschedulerStopTaskAfterDays()
        {
            int days = 5;

            //https://stackoverflow.com/questions/2875674/how-to-ignore-comments-when-reading-a-xml-file-into-a-xmldocument
            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.IgnoreComments = true;

            using (XmlReader reader = XmlReader.Create(AppDomain.CurrentDomain.BaseDirectory + "AdvancedSettings.xml", readerSettings))
            {
                XmlDocument myData = new XmlDocument();
                myData.Load(reader);

                foreach (XmlNode node in myData.DocumentElement)
                {
                    string settingName = node.Attributes[0].InnerText;
                    if (settingName == "TaskschedulerStopTaskAfterDays")
                    {
                        foreach (XmlNode child in node.ChildNodes)
                        {
                            string value = child.InnerText;
                            try
                            {
                                days = Int16.Parse(value);
                            } catch
                            {
                                MessageBox.Show($"The value {value.ToString()} inside the child node of TaskschedulerStopTaskAfterDays of AdvancedSettings.xml was invalid. The standard value of 5 days was used.","Invalid Syntax",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        break;
                    }
                }
                reader.Dispose();
            }
            
            return days;
        }

        private bool boolAdvancedSettings(string settingNameInherited, bool standardValue)
        {
            bool boolSetting = standardValue;

            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.IgnoreComments = true;

            using (XmlReader reader = XmlReader.Create(AppDomain.CurrentDomain.BaseDirectory + "AdvancedSettings.xml", readerSettings))
            {
                XmlDocument myData = new XmlDocument();
                myData.Load(reader);

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
                                MessageBox.Show($"The value {settingValue.ToString()} inside of {settingNameInherited} in AdvancedSettings.xml was invalid. The standard value {standardValue.ToString().ToLower()} was used.","Invalid Syntax", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        break;
                    }
                }
                reader.Dispose();
            }
            return boolSetting;
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
