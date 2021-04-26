using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Internet_Check
{
    public partial class FormEditServers : Form
    {
        public FormEditServers()
        {
            InitializeComponent();
            this.textBoxEnterServer.Select();
            fillServerList();
        }

        private void fillServerList()
        {
            foreach (string serverName in Properties.Settings.Default.SettingCustomServersCollection)
            {
                tableLayoutPanelServers.Height += 30;
                this.Height += 30;
                tableLayoutPanelServers.RowCount++;
                tableLayoutPanelServers.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
                tableLayoutPanelServers.Controls.Add(customLabel(serverName), 0, tableLayoutPanelServers.RowCount - 2);
                tableLayoutPanelServers.SetRow(textBoxEnterServer, tableLayoutPanelServers.RowCount - 1);
                this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y - 15);
            }
        }

        public static int i = 1;

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxEnterServer.Text == "") return;
            tableLayoutPanelServers.Height += 30;
            this.Height += 30;
            tableLayoutPanelServers.RowCount++;
            tableLayoutPanelServers.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
            tableLayoutPanelServers.Controls.Add(customLabel(textBoxEnterServer.Text), 0, tableLayoutPanelServers.RowCount - 2);
            tableLayoutPanelServers.SetRow(textBoxEnterServer, tableLayoutPanelServers.RowCount - 1);

            textBoxEnterServer.Text = "";
            
            this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y - 15);
            this.textBoxEnterServer.Select();
            this.textBoxEnterServer.Focus();
        }

        private void lbl_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            if (lbl.BackColor == Color.White)
            {
                lbl.BackColor = Color.LightBlue;
                this.buttonDelete.Enabled = true;
            } else
            {
                lbl.BackColor = Color.White;
                if (intGetCurrentHighlighted() == 0)
                {
                    this.buttonDelete.Enabled = false;
                }
            }
        }

        //If there is no label highlighted (aka blue) the delete button is not enabled
        private int intGetCurrentHighlighted()
        {
            int highlightedServers = 0;
            foreach(Control lbl in tableLayoutPanelServers.Controls)
            {
                if (lbl is System.Windows.Forms.Label && lbl.BackColor == Color.LightBlue)
                {
                    highlightedServers++;
                }
            }
            return highlightedServers;
        }

        //Create custom Label with given server name
        private Label customLabel(string serverName)
        {
            Label lbl = new Label();
            lbl.Name = $"labelServer{i}";
            lbl.Height = 30;
            lbl.Dock = DockStyle.Fill;
            lbl.Text = serverName;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Font = new Font("Century Gothic", 11, FontStyle.Regular);
            lbl.Click += new EventHandler(lbl_Click);
            i++;
            return lbl;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            List<string> serverList = new List<string>();
            //Add all Servers that aren't selected blue and shouldn't be deleted to the list serverList
            foreach (Control ctr in this.tableLayoutPanelServers.Controls)
            {
                if (ctr.BackColor != Color.LightBlue && ctr is Label && ctr.Name.StartsWith("labelServer"))
                {
                    serverList.Add(ctr.Text);
                }
            }

            int serversBefore = 0;
            //Delete all server labels
            //5000 IQ iterating backwards of the controls because the collection would break with a normal positive iterator
            //(The for fails because you are only removing every other item; consider: i=0, you remove the zeroth item.
            //Now the item that was item 1 is item 0 - so when you remove item 1 (next loop iteration) you have jumped one)
            //Source: https://stackoverflow.com/a/8466378/14602331 ; https://stackoverflow.com/questions/8466343/why-controls-do-not-want-to-get-removed
            for (int controlItem = this.tableLayoutPanelServers.Controls.Count - 1; controlItem >= 0; controlItem--)
            {
                if (this.tableLayoutPanelServers.Controls[controlItem] is Label && this.tableLayoutPanelServers.Controls[controlItem].Name.StartsWith("labelServer"))
                {
                    this.tableLayoutPanelServers.Controls[controlItem].Dispose();
                    serversBefore++;
                }
            }

            //Reset the tablelayout to 2 rows
            this.tableLayoutPanelServers.SetRow(textBoxEnterServer, 1);
            this.tableLayoutPanelServers.RowCount = 2;
            this.tableLayoutPanelServers.Height = this.tableLayoutPanelServers.Height - (serversBefore * 30);
            this.Height -= (serversBefore * 30);
            this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y + (15*serversBefore));

            //Add all items form the serverList to the tablelayout 
            foreach (string serverName in serverList)
            {
                tableLayoutPanelServers.Height += 30;
                this.Height += 30;
                tableLayoutPanelServers.RowCount++;
                tableLayoutPanelServers.RowStyles.Add(new RowStyle(SizeType.Absolute, 30f));
                tableLayoutPanelServers.Controls.Add(customLabel(serverName), 0, tableLayoutPanelServers.RowCount - 2);
                tableLayoutPanelServers.SetRow(textBoxEnterServer, tableLayoutPanelServers.RowCount - 1);
                this.Location = new System.Drawing.Point(this.Location.X, this.Location.Y - 15);
            }
            serverList = null;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(textBoxEnterServer.Text))
            {
                buttonAdd_Click(sender, e);
            }
            Properties.Settings.Default.SettingCustomServersCollection.Clear();

            //http://csharphelper.com/blog/2016/06/use-a-string-collection-setting-in-c/
            foreach (Control lbl in tableLayoutPanelServers.Controls)
            {
                if(lbl is System.Windows.Forms.Label && lbl.Name.StartsWith("labelServer"))
                {
                    Properties.Settings.Default.SettingCustomServersCollection.Add(lbl.Text);
                }
            }
            Properties.Settings.Default.Save();
            this.Close();
            this.Dispose();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
