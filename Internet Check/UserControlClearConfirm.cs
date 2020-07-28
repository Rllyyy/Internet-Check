using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;

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
                UserControlClearConfirmDarkmodeForm();
            } else
            {
                UserControlClearConfirmLightmodeForm();
            }

        }
        public void UserControlClearConfirmDarkmodeForm()
        {
            this.buttonReturn.ForeColor = Color.FromArgb(233, 233, 233);
            this.buttonClearOnlyIrrelevant.ForeColor = Color.FromArgb(233, 233, 233);
            this.buttonClearEverything.ForeColor = Color.FromArgb(233, 233, 233);
            this.BackColor = Color.FromArgb(56, 55, 55);
            
        }

        public void UserControlClearConfirmLightmodeForm()
        {
            this.buttonReturn.ForeColor = Color.Black;
            this.buttonClearOnlyIrrelevant.ForeColor = Color.Black;
            this.buttonClearEverything.ForeColor = Color.Black;
            this.BackColor = Color.White;
        }

        public void setForm1(Form1 f)
        {
            form1 = f;
        }

        private void buttonClearEverything_Click(object sender, EventArgs e)
        {
            form1.ClearEverything();
            this.Hide();
            this.SendToBack();
            this.Visible = false;
        }

        private void buttonClearOnlyIrrelevant_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/7276158/skip-lines-that-contain-semi-colon-in-text-file


            using (var reader = new System.IO.StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\connection issues.txt"))
            {
                while (!reader.EndOfStream)
                {
                    //https://stackoverflow.com/questions/31338833/c-sharp-txt-file-reading-a-substring-in-next-line-if-previous-line-contains-x
                    var line = reader.ReadLine();
                    var nextLine = reader.ReadLine();

                    if (line.StartsWith("#"))
                        {
                        if (nextLine.StartsWith("#"))
                        {
                            MessageBox.Show(line + nextLine);
                        }
                    }
                }

                reader.Close();
            }

        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.SendToBack();
            this.Visible = false;
        }
    }
}
