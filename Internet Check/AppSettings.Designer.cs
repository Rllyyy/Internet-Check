namespace Internet_Check
{
    partial class AppSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppSettings));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxDarkmode = new System.Windows.Forms.CheckBox();
            this.checkBoxStartWithWindows = new System.Windows.Forms.CheckBox();
            this.checkBoxHideWhenMin = new System.Windows.Forms.CheckBox();
            this.labelSettings = new System.Windows.Forms.Label();
            this.labelAdvancedSettings = new System.Windows.Forms.Label();
            this.comboBoxDoubleCheckServer = new System.Windows.Forms.ComboBox();
            this.labelDoubleCheckServer = new System.Windows.Forms.Label();
            this.checkBoxUseAlternativePingMethod = new System.Windows.Forms.CheckBox();
            this.checkBoxAllPingResults = new System.Windows.Forms.CheckBox();
            this.checkBoxShowMinimizedInfo = new System.Windows.Forms.CheckBox();
            this.labelTaskSchedulerStopTaskAfterDays = new System.Windows.Forms.Label();
            this.textBoxTaskSchedulerStopTaskAfterDays = new System.Windows.Forms.TextBox();
            this.checkBoxDisallowStartIfOnBatteries = new System.Windows.Forms.CheckBox();
            this.checkBoxStopIfGoingOnBatteries = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxUseCustomServers = new System.Windows.Forms.CheckBox();
            this.labelUserMessage = new System.Windows.Forms.Label();
            this.buttonEditServers = new System.Windows.Forms.Button();
            this.checkBoxDisableUpdateNotifications = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(0, 0);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(289, 33);
            this.buttonCancel.TabIndex = 5;
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
            this.buttonSave.Location = new System.Drawing.Point(578, 0);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(290, 33);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save && Exit";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDefault
            // 
            this.buttonDefault.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDefault.FlatAppearance.BorderSize = 0;
            this.buttonDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDefault.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDefault.Location = new System.Drawing.Point(289, 0);
            this.buttonDefault.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(289, 33);
            this.buttonDefault.TabIndex = 7;
            this.buttonDefault.Text = "Default Values";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.tableLayoutPanel2.SetColumnSpan(this.panel1, 3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 22);
            this.panel1.TabIndex = 8;
            // 
            // checkBoxDarkmode
            // 
            this.checkBoxDarkmode.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxDarkmode.AutoSize = true;
            this.checkBoxDarkmode.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.checkBoxDarkmode.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDarkmode.Location = new System.Drawing.Point(10, 34);
            this.checkBoxDarkmode.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.checkBoxDarkmode.Name = "checkBoxDarkmode";
            this.checkBoxDarkmode.Size = new System.Drawing.Size(138, 24);
            this.checkBoxDarkmode.TabIndex = 9;
            this.checkBoxDarkmode.Text = "Use DarkMode";
            this.checkBoxDarkmode.UseVisualStyleBackColor = true;
            // 
            // checkBoxStartWithWindows
            // 
            this.checkBoxStartWithWindows.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxStartWithWindows.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxStartWithWindows, 3);
            this.checkBoxStartWithWindows.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxStartWithWindows.Location = new System.Drawing.Point(572, 34);
            this.checkBoxStartWithWindows.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.checkBoxStartWithWindows.Name = "checkBoxStartWithWindows";
            this.checkBoxStartWithWindows.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxStartWithWindows.Size = new System.Drawing.Size(286, 24);
            this.checkBoxStartWithWindows.TabIndex = 10;
            this.checkBoxStartWithWindows.Text = "Start with Windows (Task Scheduler)";
            this.checkBoxStartWithWindows.UseVisualStyleBackColor = true;
            this.checkBoxStartWithWindows.Click += new System.EventHandler(this.checkBoxStartWithWindows_Click);
            // 
            // checkBoxHideWhenMin
            // 
            this.checkBoxHideWhenMin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxHideWhenMin.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxHideWhenMin, 2);
            this.checkBoxHideWhenMin.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxHideWhenMin.Location = new System.Drawing.Point(10, 65);
            this.checkBoxHideWhenMin.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.checkBoxHideWhenMin.Name = "checkBoxHideWhenMin";
            this.checkBoxHideWhenMin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkBoxHideWhenMin.Size = new System.Drawing.Size(194, 24);
            this.checkBoxHideWhenMin.TabIndex = 11;
            this.checkBoxHideWhenMin.Text = "Minimize to System Tray";
            this.checkBoxHideWhenMin.UseVisualStyleBackColor = true;
            this.checkBoxHideWhenMin.Click += new System.EventHandler(this.checkBoxHideWhenMin_Click);
            // 
            // labelSettings
            // 
            this.labelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSettings.AutoSize = true;
            this.labelSettings.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettings.Location = new System.Drawing.Point(320, 0);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(225, 31);
            this.labelSettings.TabIndex = 12;
            this.labelSettings.Text = "Settings";
            this.labelSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelAdvancedSettings
            // 
            this.labelAdvancedSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAdvancedSettings.AutoSize = true;
            this.labelAdvancedSettings.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdvancedSettings.Location = new System.Drawing.Point(320, 94);
            this.labelAdvancedSettings.Name = "labelAdvancedSettings";
            this.labelAdvancedSettings.Size = new System.Drawing.Size(225, 46);
            this.labelAdvancedSettings.TabIndex = 13;
            this.labelAdvancedSettings.Text = "Advanced Settings";
            this.labelAdvancedSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxDoubleCheckServer
            // 
            this.comboBoxDoubleCheckServer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxDoubleCheckServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDoubleCheckServer.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxDoubleCheckServer.FormattingEnabled = true;
            this.comboBoxDoubleCheckServer.Items.AddRange(new object[] {
            "None",
            "Same",
            "Next"});
            this.comboBoxDoubleCheckServer.Location = new System.Drawing.Point(187, 148);
            this.comboBoxDoubleCheckServer.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.comboBoxDoubleCheckServer.Name = "comboBoxDoubleCheckServer";
            this.comboBoxDoubleCheckServer.Size = new System.Drawing.Size(71, 25);
            this.comboBoxDoubleCheckServer.TabIndex = 14;
            // 
            // labelDoubleCheckServer
            // 
            this.labelDoubleCheckServer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelDoubleCheckServer.AutoSize = true;
            this.labelDoubleCheckServer.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDoubleCheckServer.Location = new System.Drawing.Point(6, 150);
            this.labelDoubleCheckServer.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelDoubleCheckServer.Name = "labelDoubleCheckServer";
            this.labelDoubleCheckServer.Size = new System.Drawing.Size(166, 20);
            this.labelDoubleCheckServer.TabIndex = 15;
            this.labelDoubleCheckServer.Text = "Double Check Server";
            this.labelDoubleCheckServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxUseAlternativePingMethod
            // 
            this.checkBoxUseAlternativePingMethod.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxUseAlternativePingMethod.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxUseAlternativePingMethod, 2);
            this.checkBoxUseAlternativePingMethod.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxUseAlternativePingMethod.Location = new System.Drawing.Point(10, 185);
            this.checkBoxUseAlternativePingMethod.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.checkBoxUseAlternativePingMethod.Name = "checkBoxUseAlternativePingMethod";
            this.checkBoxUseAlternativePingMethod.Size = new System.Drawing.Size(237, 24);
            this.checkBoxUseAlternativePingMethod.TabIndex = 16;
            this.checkBoxUseAlternativePingMethod.Text = "Use alternative Ping Method";
            this.checkBoxUseAlternativePingMethod.UseVisualStyleBackColor = true;
            // 
            // checkBoxAllPingResults
            // 
            this.checkBoxAllPingResults.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxAllPingResults.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxAllPingResults, 2);
            this.checkBoxAllPingResults.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAllPingResults.Location = new System.Drawing.Point(10, 219);
            this.checkBoxAllPingResults.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.checkBoxAllPingResults.Name = "checkBoxAllPingResults";
            this.checkBoxAllPingResults.Size = new System.Drawing.Size(175, 24);
            this.checkBoxAllPingResults.TabIndex = 17;
            this.checkBoxAllPingResults.Text = "Show all Ping Results";
            this.checkBoxAllPingResults.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowMinimizedInfo
            // 
            this.checkBoxShowMinimizedInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxShowMinimizedInfo.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxShowMinimizedInfo, 2);
            this.checkBoxShowMinimizedInfo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxShowMinimizedInfo.Location = new System.Drawing.Point(10, 254);
            this.checkBoxShowMinimizedInfo.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.checkBoxShowMinimizedInfo.Name = "checkBoxShowMinimizedInfo";
            this.checkBoxShowMinimizedInfo.Size = new System.Drawing.Size(258, 24);
            this.checkBoxShowMinimizedInfo.TabIndex = 18;
            this.checkBoxShowMinimizedInfo.Text = "Show Ballon Tip when minimized";
            this.checkBoxShowMinimizedInfo.UseVisualStyleBackColor = true;
            // 
            // labelTaskSchedulerStopTaskAfterDays
            // 
            this.labelTaskSchedulerStopTaskAfterDays.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelTaskSchedulerStopTaskAfterDays.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelTaskSchedulerStopTaskAfterDays, 2);
            this.labelTaskSchedulerStopTaskAfterDays.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTaskSchedulerStopTaskAfterDays.Location = new System.Drawing.Point(550, 150);
            this.labelTaskSchedulerStopTaskAfterDays.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.labelTaskSchedulerStopTaskAfterDays.Name = "labelTaskSchedulerStopTaskAfterDays";
            this.labelTaskSchedulerStopTaskAfterDays.Size = new System.Drawing.Size(262, 20);
            this.labelTaskSchedulerStopTaskAfterDays.TabIndex = 19;
            this.labelTaskSchedulerStopTaskAfterDays.Text = "Task Scheduler Stop Task after Days";
            this.labelTaskSchedulerStopTaskAfterDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxTaskSchedulerStopTaskAfterDays
            // 
            this.textBoxTaskSchedulerStopTaskAfterDays.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBoxTaskSchedulerStopTaskAfterDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTaskSchedulerStopTaskAfterDays.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTaskSchedulerStopTaskAfterDays.Location = new System.Drawing.Point(815, 147);
            this.textBoxTaskSchedulerStopTaskAfterDays.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.textBoxTaskSchedulerStopTaskAfterDays.Name = "textBoxTaskSchedulerStopTaskAfterDays";
            this.textBoxTaskSchedulerStopTaskAfterDays.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxTaskSchedulerStopTaskAfterDays.Size = new System.Drawing.Size(43, 26);
            this.textBoxTaskSchedulerStopTaskAfterDays.TabIndex = 20;
            this.textBoxTaskSchedulerStopTaskAfterDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // checkBoxDisallowStartIfOnBatteries
            // 
            this.checkBoxDisallowStartIfOnBatteries.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxDisallowStartIfOnBatteries.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxDisallowStartIfOnBatteries, 3);
            this.checkBoxDisallowStartIfOnBatteries.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDisallowStartIfOnBatteries.Location = new System.Drawing.Point(523, 185);
            this.checkBoxDisallowStartIfOnBatteries.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.checkBoxDisallowStartIfOnBatteries.Name = "checkBoxDisallowStartIfOnBatteries";
            this.checkBoxDisallowStartIfOnBatteries.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxDisallowStartIfOnBatteries.Size = new System.Drawing.Size(335, 24);
            this.checkBoxDisallowStartIfOnBatteries.TabIndex = 21;
            this.checkBoxDisallowStartIfOnBatteries.Text = "Task Scheduler disallow Start if on Batteries";
            this.checkBoxDisallowStartIfOnBatteries.UseVisualStyleBackColor = true;
            // 
            // checkBoxStopIfGoingOnBatteries
            // 
            this.checkBoxStopIfGoingOnBatteries.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxStopIfGoingOnBatteries.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxStopIfGoingOnBatteries, 3);
            this.checkBoxStopIfGoingOnBatteries.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxStopIfGoingOnBatteries.Location = new System.Drawing.Point(540, 219);
            this.checkBoxStopIfGoingOnBatteries.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.checkBoxStopIfGoingOnBatteries.Name = "checkBoxStopIfGoingOnBatteries";
            this.checkBoxStopIfGoingOnBatteries.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxStopIfGoingOnBatteries.Size = new System.Drawing.Size(318, 24);
            this.checkBoxStopIfGoingOnBatteries.TabIndex = 22;
            this.checkBoxStopIfGoingOnBatteries.Text = "Task Scheduler Stop if going on Batteries";
            this.checkBoxStopIfGoingOnBatteries.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.57275F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.9971F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.67668F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.52995F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.336406F));
            this.tableLayoutPanel1.Controls.Add(this.checkBoxUseCustomServers, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelSettings, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxDarkmode, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelAdvancedSettings, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelDoubleCheckServer, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxDoubleCheckServer, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxUseAlternativePingMethod, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxAllPingResults, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxShowMinimizedInfo, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelTaskSchedulerStopTaskAfterDays, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTaskSchedulerStopTaskAfterDays, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxDisallowStartIfOnBatteries, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxStopIfGoingOnBatteries, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelUserMessage, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxStartWithWindows, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxHideWhenMin, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonEditServers, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxDisableUpdateNotifications, 3, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(868, 397);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // checkBoxUseCustomServers
            // 
            this.checkBoxUseCustomServers.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxUseCustomServers.AutoSize = true;
            this.checkBoxUseCustomServers.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxUseCustomServers.Location = new System.Drawing.Point(10, 288);
            this.checkBoxUseCustomServers.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.checkBoxUseCustomServers.Name = "checkBoxUseCustomServers";
            this.checkBoxUseCustomServers.Size = new System.Drawing.Size(171, 24);
            this.checkBoxUseCustomServers.TabIndex = 26;
            this.checkBoxUseCustomServers.Text = "Use Custom Servers";
            this.checkBoxUseCustomServers.UseVisualStyleBackColor = true;
            this.checkBoxUseCustomServers.CheckedChanged += new System.EventHandler(this.checkBoxUseCustomServers_CheckedChanged);
            // 
            // labelUserMessage
            // 
            this.labelUserMessage.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelUserMessage.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelUserMessage, 5);
            this.labelUserMessage.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.labelUserMessage.Location = new System.Drawing.Point(377, 353);
            this.labelUserMessage.Name = "labelUserMessage";
            this.labelUserMessage.Size = new System.Drawing.Size(113, 20);
            this.labelUserMessage.TabIndex = 24;
            this.labelUserMessage.Text = "Error Message";
            this.labelUserMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelUserMessage.Visible = false;
            // 
            // buttonEditServers
            // 
            this.buttonEditServers.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonEditServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonEditServers.FlatAppearance.BorderSize = 0;
            this.buttonEditServers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditServers.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditServers.Location = new System.Drawing.Point(187, 283);
            this.buttonEditServers.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEditServers.Name = "buttonEditServers";
            this.buttonEditServers.Size = new System.Drawing.Size(130, 34);
            this.buttonEditServers.TabIndex = 26;
            this.buttonEditServers.Text = "Edit Servers";
            this.buttonEditServers.UseVisualStyleBackColor = true;
            this.buttonEditServers.Visible = false;
            this.buttonEditServers.Click += new System.EventHandler(this.buttonEditServers_Click);
            // 
            // checkBoxDisableUpdateNotifications
            // 
            this.checkBoxDisableUpdateNotifications.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxDisableUpdateNotifications.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxDisableUpdateNotifications, 2);
            this.checkBoxDisableUpdateNotifications.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxDisableUpdateNotifications.Location = new System.Drawing.Point(623, 65);
            this.checkBoxDisableUpdateNotifications.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.checkBoxDisableUpdateNotifications.Name = "checkBoxDisableUpdateNotifications";
            this.checkBoxDisableUpdateNotifications.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxDisableUpdateNotifications.Size = new System.Drawing.Size(235, 24);
            this.checkBoxDisableUpdateNotifications.TabIndex = 27;
            this.checkBoxDisableUpdateNotifications.Text = "Disable Update Notifications";
            this.checkBoxDisableUpdateNotifications.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.Controls.Add(this.buttonCancel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonDefault, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonSave, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 402);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(868, 55);
            this.tableLayoutPanel2.TabIndex = 25;
            // 
            // AppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(868, 457);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Internet Check - Settings";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDefault;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBoxDarkmode;
        private System.Windows.Forms.CheckBox checkBoxStartWithWindows;
        private System.Windows.Forms.CheckBox checkBoxHideWhenMin;
        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.Label labelAdvancedSettings;
        private System.Windows.Forms.ComboBox comboBoxDoubleCheckServer;
        private System.Windows.Forms.Label labelDoubleCheckServer;
        private System.Windows.Forms.CheckBox checkBoxUseAlternativePingMethod;
        private System.Windows.Forms.CheckBox checkBoxAllPingResults;
        private System.Windows.Forms.CheckBox checkBoxShowMinimizedInfo;
        private System.Windows.Forms.Label labelTaskSchedulerStopTaskAfterDays;
        private System.Windows.Forms.TextBox textBoxTaskSchedulerStopTaskAfterDays;
        private System.Windows.Forms.CheckBox checkBoxDisallowStartIfOnBatteries;
        private System.Windows.Forms.CheckBox checkBoxStopIfGoingOnBatteries;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelUserMessage;
        private System.Windows.Forms.CheckBox checkBoxUseCustomServers;
        private System.Windows.Forms.Button buttonEditServers;
        private System.Windows.Forms.CheckBox checkBoxDisableUpdateNotifications;
    }
}