namespace Internet_Check
{
    partial class UserSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxDarkmode = new System.Windows.Forms.CheckBox();
            this.checkBoxStartWithWindows = new System.Windows.Forms.CheckBox();
            this.checkBoxHideWhenMin = new System.Windows.Forms.CheckBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxDarkmode
            // 
            this.checkBoxDarkmode.AutoSize = true;
            this.checkBoxDarkmode.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.checkBoxDarkmode.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDarkmode.Location = new System.Drawing.Point(106, 8);
            this.checkBoxDarkmode.Name = "checkBoxDarkmode";
            this.checkBoxDarkmode.Size = new System.Drawing.Size(119, 21);
            this.checkBoxDarkmode.TabIndex = 0;
            this.checkBoxDarkmode.Text = "Use DarkMode";
            this.checkBoxDarkmode.UseVisualStyleBackColor = true;
            this.checkBoxDarkmode.CheckedChanged += new System.EventHandler(this.checkBoxDarkmode_CheckedChanged);
            // 
            // checkBoxStartWithWindows
            // 
            this.checkBoxStartWithWindows.AutoSize = true;
            this.checkBoxStartWithWindows.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxStartWithWindows.Location = new System.Drawing.Point(106, 39);
            this.checkBoxStartWithWindows.Name = "checkBoxStartWithWindows";
            this.checkBoxStartWithWindows.Size = new System.Drawing.Size(151, 21);
            this.checkBoxStartWithWindows.TabIndex = 1;
            this.checkBoxStartWithWindows.Text = "Start with Windows";
            this.checkBoxStartWithWindows.UseVisualStyleBackColor = true;
            this.checkBoxStartWithWindows.CheckedChanged += new System.EventHandler(this.checkBoxStartWithWindows_CheckedChanged);
            // 
            // checkBoxHideWhenMin
            // 
            this.checkBoxHideWhenMin.AutoSize = true;
            this.checkBoxHideWhenMin.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxHideWhenMin.Location = new System.Drawing.Point(106, 70);
            this.checkBoxHideWhenMin.Name = "checkBoxHideWhenMin";
            this.checkBoxHideWhenMin.Size = new System.Drawing.Size(178, 21);
            this.checkBoxHideWhenMin.TabIndex = 2;
            this.checkBoxHideWhenMin.Text = "Show only in Systemtray";
            this.checkBoxHideWhenMin.UseVisualStyleBackColor = true;
            this.checkBoxHideWhenMin.CheckedChanged += new System.EventHandler(this.checkBoxHideWhenMin_CheckedChanged);
            // 
            // buttonBack
            // 
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBack.Location = new System.Drawing.Point(6, 96);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(348, 30);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // UserSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.checkBoxHideWhenMin);
            this.Controls.Add(this.checkBoxStartWithWindows);
            this.Controls.Add(this.checkBoxDarkmode);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserSettings";
            this.Size = new System.Drawing.Size(376, 129);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxDarkmode;
        private System.Windows.Forms.CheckBox checkBoxStartWithWindows;
        private System.Windows.Forms.CheckBox checkBoxHideWhenMin;
        private System.Windows.Forms.Button buttonBack;
    }
}
