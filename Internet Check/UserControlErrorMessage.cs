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
    public partial class UserControlErrorMessage : UserControl
    {
        public UserControlErrorMessage()
        {
            InitializeComponent();
        }

        public void setErrorMessageText(string errorMessage)
        {
            this.BringToFront();
            this.Visible = true;
            this.labelErrorMessage.Text = errorMessage;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.SendToBack();
            this.Visible = false;
            this.labelErrorMessage.Text = "Error Message";
        }
    }
}
