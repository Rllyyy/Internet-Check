
namespace Internet_Check
{
    partial class FormEditServers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditServers));
            this.tableLayoutPanelBottom = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelUserMessage = new System.Windows.Forms.Label();
            this.tableLayoutPanelServers = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxEnterServer = new System.Windows.Forms.TextBox();
            this.labelEditServers = new System.Windows.Forms.Label();
            this.tableLayoutPanelBottom.SuspendLayout();
            this.tableLayoutPanelServers.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelBottom
            // 
            this.tableLayoutPanelBottom.ColumnCount = 2;
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelBottom.Controls.Add(this.buttonCancel, 0, 2);
            this.tableLayoutPanelBottom.Controls.Add(this.buttonSave, 1, 2);
            this.tableLayoutPanelBottom.Controls.Add(this.buttonDelete, 0, 1);
            this.tableLayoutPanelBottom.Controls.Add(this.buttonAdd, 1, 1);
            this.tableLayoutPanelBottom.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanelBottom.Controls.Add(this.labelUserMessage, 0, 0);
            this.tableLayoutPanelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanelBottom.Location = new System.Drawing.Point(0, 62);
            this.tableLayoutPanelBottom.Name = "tableLayoutPanelBottom";
            this.tableLayoutPanelBottom.RowCount = 4;
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanelBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanelBottom.Size = new System.Drawing.Size(393, 110);
            this.tableLayoutPanelBottom.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(0, 55);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(196, 33);
            this.buttonCancel.TabIndex = 27;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(196, 55);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(197, 33);
            this.buttonSave.TabIndex = 29;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelete.Enabled = false;
            this.buttonDelete.FlatAppearance.BorderSize = 0;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(0, 22);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(196, 33);
            this.buttonDelete.TabIndex = 31;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAdd.FlatAppearance.BorderSize = 0;
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(196, 22);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(0);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(197, 33);
            this.buttonAdd.TabIndex = 30;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tableLayoutPanelBottom.SetColumnSpan(this.panel1, 2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 88);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 22);
            this.panel1.TabIndex = 28;
            // 
            // labelUserMessage
            // 
            this.labelUserMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelUserMessage.AutoSize = true;
            this.tableLayoutPanelBottom.SetColumnSpan(this.labelUserMessage, 2);
            this.labelUserMessage.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserMessage.Location = new System.Drawing.Point(78, 2);
            this.labelUserMessage.Name = "labelUserMessage";
            this.labelUserMessage.Size = new System.Drawing.Size(236, 20);
            this.labelUserMessage.TabIndex = 32;
            this.labelUserMessage.Text = "Please enter only an IP address";
            this.labelUserMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelUserMessage.Visible = false;
            // 
            // tableLayoutPanelServers
            // 
            this.tableLayoutPanelServers.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanelServers.ColumnCount = 1;
            this.tableLayoutPanelServers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelServers.Controls.Add(this.textBoxEnterServer, 0, 1);
            this.tableLayoutPanelServers.Controls.Add(this.labelEditServers, 0, 0);
            this.tableLayoutPanelServers.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelServers.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelServers.Name = "tableLayoutPanelServers";
            this.tableLayoutPanelServers.RowCount = 2;
            this.tableLayoutPanelServers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelServers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelServers.Size = new System.Drawing.Size(393, 61);
            this.tableLayoutPanelServers.TabIndex = 1;
            // 
            // textBoxEnterServer
            // 
            this.textBoxEnterServer.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxEnterServer.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEnterServer.Location = new System.Drawing.Point(3, 23);
            this.textBoxEnterServer.Name = "textBoxEnterServer";
            this.textBoxEnterServer.Size = new System.Drawing.Size(387, 26);
            this.textBoxEnterServer.TabIndex = 3;
            this.textBoxEnterServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelEditServers
            // 
            this.labelEditServers.AutoSize = true;
            this.labelEditServers.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelEditServers.Font = new System.Drawing.Font("Century Gothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditServers.Location = new System.Drawing.Point(3, 0);
            this.labelEditServers.Name = "labelEditServers";
            this.labelEditServers.Size = new System.Drawing.Size(387, 20);
            this.labelEditServers.TabIndex = 2;
            this.labelEditServers.Text = "Servers";
            this.labelEditServers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormEditServers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(393, 172);
            this.Controls.Add(this.tableLayoutPanelServers);
            this.Controls.Add(this.tableLayoutPanelBottom);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 211);
            this.Name = "FormEditServers";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Internet Check - Edit Servers";
            this.tableLayoutPanelBottom.ResumeLayout(false);
            this.tableLayoutPanelBottom.PerformLayout();
            this.tableLayoutPanelServers.ResumeLayout(false);
            this.tableLayoutPanelServers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBottom;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelServers;
        private System.Windows.Forms.Label labelEditServers;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxEnterServer;
        private System.Windows.Forms.Label labelUserMessage;
    }
}