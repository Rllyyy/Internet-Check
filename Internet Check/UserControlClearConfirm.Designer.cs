namespace Internet_Check
{
    partial class UserControlClearConfirm
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
            this.LabelSure = new System.Windows.Forms.Label();
            this.panelSure = new System.Windows.Forms.Panel();
            this.buttonNo = new System.Windows.Forms.Button();
            this.buttonYes = new System.Windows.Forms.Button();
            this.panelSure.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelSure
            // 
            this.LabelSure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelSure.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSure.Location = new System.Drawing.Point(0, 0);
            this.LabelSure.Name = "LabelSure";
            this.LabelSure.Size = new System.Drawing.Size(332, 42);
            this.LabelSure.TabIndex = 0;
            this.LabelSure.Text = "Are you sure that you want to clear everything?";
            this.LabelSure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelSure
            // 
            this.panelSure.BackColor = System.Drawing.Color.White;
            this.panelSure.Controls.Add(this.LabelSure);
            this.panelSure.Location = new System.Drawing.Point(23, 7);
            this.panelSure.Name = "panelSure";
            this.panelSure.Size = new System.Drawing.Size(332, 42);
            this.panelSure.TabIndex = 1;
            // 
            // buttonNo
            // 
            this.buttonNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonNo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonNo.FlatAppearance.BorderSize = 0;
            this.buttonNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNo.Location = new System.Drawing.Point(5, 94);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(350, 30);
            this.buttonNo.TabIndex = 4;
            this.buttonNo.Text = "No";
            this.buttonNo.UseVisualStyleBackColor = true;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // buttonYes
            // 
            this.buttonYes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonYes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonYes.FlatAppearance.BorderSize = 0;
            this.buttonYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonYes.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonYes.Location = new System.Drawing.Point(5, 58);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(350, 30);
            this.buttonYes.TabIndex = 5;
            this.buttonYes.Text = "Yes, clear all";
            this.buttonYes.UseVisualStyleBackColor = true;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // UserControlClearConfirm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.panelSure);
            this.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Name = "UserControlClearConfirm";
            this.Size = new System.Drawing.Size(376, 129);
            this.panelSure.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelSure;
        private System.Windows.Forms.Panel panelSure;
        private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.Button buttonYes;
    }
}
