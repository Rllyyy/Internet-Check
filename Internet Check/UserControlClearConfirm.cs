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
    public partial class UserControlClearConfirm : UserControl
    {
        Form1 form1;
        public UserControlClearConfirm()
        {
            InitializeComponent();
            if (Properties.Settings.Default.SettingDarkmode == true)
            {
                UserControlClearConnfirmDarkmodeForm();
            }

        }
        private void UserControlClearConnfirmDarkmodeForm()
        {
            this.buttonNo.ForeColor = Color.FromArgb(233, 233, 233);
            this.buttonYes.ForeColor = Color.FromArgb(233, 233, 233);
            this.LabelSure.ForeColor = Color.FromArgb(233, 233, 233);
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            //Code when all clear
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            //Code when No
        }
    }
}
