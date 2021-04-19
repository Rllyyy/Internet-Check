using System;
using System.Windows.Forms;

namespace Internet_Check
{
    public partial class AppSettings : Form
    {
        public AppSettings()
        {
            InitializeComponent();
            setAppSettings();
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
    }
}
