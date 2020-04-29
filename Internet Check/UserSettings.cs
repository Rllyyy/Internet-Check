using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Internet_Check
{
    public partial class UserSettings : UserControl
    {
        public UserSettings()
        {
            InitializeComponent();
            this.checkBoxDarkmode.Checked = Properties.Settings.Default.SettingDarkmode;
            if (Properties.Settings.Default.SettingDarkmode == true)
            {
                DarkmodeForm();
            }
        }

        private void checkBoxDarkmode_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxDarkmode.Checked == true)
            {
                Properties.Settings.Default.SettingDarkmode = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.SettingDarkmode = false;
                Properties.Settings.Default.Save();
            }
        }
        private void checkBoxStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
           
        }
        private void checkBoxHideWhenMin_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxHideWhenMin.Checked == true)
            {

            }
        }

        private void DarkmodeForm()
        {
            //this.BackColor = Color.FromArgb(56, 55, 55);
            //this.checkBoxDarkmode.ForeColor = Color.FromArgb(233, 233, 233);

            this.checkBoxDarkmode.ForeColor = Color.FromArgb(233, 233, 233);
            this.checkBoxStartWithWindows.ForeColor = Color.FromArgb(233, 233, 233);
            this.checkBoxHideWhenMin.ForeColor = Color.FromArgb(233, 233, 233);
            this.buttonBack.ForeColor = Color.FromArgb(233, 233, 233);

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.SendToBack();
            this.Visible = false;
        }


    }
}
