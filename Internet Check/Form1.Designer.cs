namespace Internet_Check
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelRunning = new System.Windows.Forms.Label();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.labelInterval = new System.Windows.Forms.Label();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.panelError = new System.Windows.Forms.Panel();
            this.labelErrormessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelError.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.labelRunning);
            this.panel1.Controls.Add(this.textBoxInterval);
            this.panel1.Controls.Add(this.labelInterval);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 24);
            this.panel1.TabIndex = 2;
            // 
            // labelRunning
            // 
            this.labelRunning.AutoSize = true;
            this.labelRunning.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRunning.ForeColor = System.Drawing.Color.White;
            this.labelRunning.Location = new System.Drawing.Point(226, 3);
            this.labelRunning.Name = "labelRunning";
            this.labelRunning.Size = new System.Drawing.Size(82, 17);
            this.labelRunning.TabIndex = 0;
            this.labelRunning.Text = "Waiting . . .";
            this.labelRunning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.BackColor = System.Drawing.Color.Black;
            this.textBoxInterval.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxInterval.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxInterval.ForeColor = System.Drawing.Color.White;
            this.textBoxInterval.Location = new System.Drawing.Point(97, 3);
            this.textBoxInterval.MaxLength = 5;
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(81, 16);
            this.textBoxInterval.TabIndex = 1;
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInterval.ForeColor = System.Drawing.Color.White;
            this.labelInterval.Location = new System.Drawing.Point(3, 3);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(94, 17);
            this.labelInterval.TabIndex = 5;
            this.labelInterval.Text = "Interval (sec):";
            // 
            // buttonOpen
            // 
            this.buttonOpen.FlatAppearance.BorderSize = 0;
            this.buttonOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOpen.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpen.Location = new System.Drawing.Point(9, 38);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(299, 32);
            this.buttonOpen.TabIndex = 7;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.FlatAppearance.BorderSize = 0;
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear.Location = new System.Drawing.Point(9, 75);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(299, 32);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Internet Check";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(9, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(299, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "Start/Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelError
            // 
            this.panelError.Controls.Add(this.labelErrormessage);
            this.panelError.Location = new System.Drawing.Point(0, 0);
            this.panelError.Name = "panelError";
            this.panelError.Size = new System.Drawing.Size(314, 110);
            this.panelError.TabIndex = 8;
            this.panelError.Visible = false;
            // 
            // labelErrormessage
            // 
            this.labelErrormessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelErrormessage.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrormessage.Location = new System.Drawing.Point(0, 0);
            this.labelErrormessage.Name = "labelErrormessage";
            this.labelErrormessage.Size = new System.Drawing.Size(314, 110);
            this.labelErrormessage.TabIndex = 1;
            this.labelErrormessage.Text = "Errormessage";
            this.labelErrormessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(316, 135);
            this.Controls.Add(this.panelError);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(332, 174);
            this.MinimumSize = new System.Drawing.Size(332, 174);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Internet Check";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelError.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelRunning;
        private System.Windows.Forms.TextBox textBoxInterval;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelError;
        private System.Windows.Forms.Label labelErrormessage;
    }
}

