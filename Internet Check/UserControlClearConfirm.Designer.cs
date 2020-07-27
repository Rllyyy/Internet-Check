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
            this.buttonReturn = new System.Windows.Forms.Button();
            this.buttonClearOnlyIrrelevant = new System.Windows.Forms.Button();
            this.buttonClearEverything = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonReturn
            // 
            this.buttonReturn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonReturn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonReturn.FlatAppearance.BorderSize = 0;
            this.buttonReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReturn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReturn.Location = new System.Drawing.Point(5, 96);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(350, 30);
            this.buttonReturn.TabIndex = 4;
            this.buttonReturn.Text = "Return";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // buttonClearOnlyIrrelevant
            // 
            this.buttonClearOnlyIrrelevant.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonClearOnlyIrrelevant.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonClearOnlyIrrelevant.FlatAppearance.BorderSize = 0;
            this.buttonClearOnlyIrrelevant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearOnlyIrrelevant.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearOnlyIrrelevant.Location = new System.Drawing.Point(5, 38);
            this.buttonClearOnlyIrrelevant.Name = "buttonClearOnlyIrrelevant";
            this.buttonClearOnlyIrrelevant.Size = new System.Drawing.Size(350, 30);
            this.buttonClearOnlyIrrelevant.TabIndex = 5;
            this.buttonClearOnlyIrrelevant.Text = "Clear Only Irrelevant Data";
            this.buttonClearOnlyIrrelevant.UseVisualStyleBackColor = true;
            this.buttonClearOnlyIrrelevant.Click += new System.EventHandler(this.buttonClearOnlyIrrelevant_Click);
            // 
            // buttonClearEverything
            // 
            this.buttonClearEverything.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonClearEverything.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonClearEverything.FlatAppearance.BorderSize = 0;
            this.buttonClearEverything.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearEverything.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearEverything.Location = new System.Drawing.Point(5, 0);
            this.buttonClearEverything.Name = "buttonClearEverything";
            this.buttonClearEverything.Size = new System.Drawing.Size(350, 30);
            this.buttonClearEverything.TabIndex = 6;
            this.buttonClearEverything.Text = "Clear Everything";
            this.buttonClearEverything.UseVisualStyleBackColor = true;
            this.buttonClearEverything.Click += new System.EventHandler(this.buttonClearEverything_Click);
            // 
            // UserControlClearConfirm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonClearEverything);
            this.Controls.Add(this.buttonClearOnlyIrrelevant);
            this.Controls.Add(this.buttonReturn);
            this.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Name = "UserControlClearConfirm";
            this.Size = new System.Drawing.Size(376, 129);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Button buttonClearOnlyIrrelevant;
        private System.Windows.Forms.Button buttonClearEverything;
    }
}
