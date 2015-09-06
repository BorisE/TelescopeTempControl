namespace TelescopeTempControl
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_General = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbLogLevel = new System.Windows.Forms.ComboBox();
            this.btnSerialLogPathBrowse = new System.Windows.Forms.Button();
            this.btnCSVPathBrowse = new System.Windows.Forms.Button();
            this.btnLogPathBrowse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtSerialFileOut = new System.Windows.Forms.TextBox();
            this.txtSerialFileIn = new System.Windows.Forms.TextBox();
            this.btnOpenWriteToFile = new System.Windows.Forms.Button();
            this.btnOpenReadFromFile = new System.Windows.Forms.Button();
            this.tabPage_Modeling = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCloudysky = new System.Windows.Forms.TextBox();
            this.txtClearsky = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtRefreshInterval = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtMaxLogWindowLines = new System.Windows.Forms.TextBox();
            this.txtMaxPoints = new System.Windows.Forms.TextBox();
            this.txtLogFileLocation = new System.Windows.Forms.TextBox();
            this.txtSerialLogFileLocation = new System.Windows.Forms.TextBox();
            this.txtCSVFileLocation = new System.Windows.Forms.TextBox();
            this.chkSerialLogFileFlag = new System.Windows.Forms.CheckBox();
            this.chkCSVFileFlag = new System.Windows.Forms.CheckBox();
            this.chkLogFileFlag = new System.Windows.Forms.CheckBox();
            this.chkWatchdog = new System.Windows.Forms.CheckBox();
            this.COM11 = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage_General.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage_Modeling.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage_General);
            this.tabControl1.Controls.Add(this.tabPage_Modeling);
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(606, 366);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_General
            // 
            this.tabPage_General.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage_General.Controls.Add(this.groupBox6);
            this.tabPage_General.Controls.Add(this.groupBox3);
            this.tabPage_General.Controls.Add(this.groupBox1);
            this.tabPage_General.Location = new System.Drawing.Point(4, 22);
            this.tabPage_General.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_General.Name = "tabPage_General";
            this.tabPage_General.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage_General.Size = new System.Drawing.Size(598, 340);
            this.tabPage_General.TabIndex = 0;
            this.tabPage_General.Text = "General";
            this.tabPage_General.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label39);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.txtRefreshInterval);
            this.groupBox6.Controls.Add(this.textBox3);
            this.groupBox6.Controls.Add(this.txtMaxLogWindowLines);
            this.groupBox6.Controls.Add(this.txtMaxPoints);
            this.groupBox6.Location = new System.Drawing.Point(6, 236);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(307, 84);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Productivity settings";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label32.Location = new System.Drawing.Point(205, 19);
            this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(40, 13);
            this.label32.TabIndex = 2;
            this.label32.Text = "millisec";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(4, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Main tick interval";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label39.Location = new System.Drawing.Point(4, 61);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(107, 13);
            this.label39.TabIndex = 3;
            this.label39.Text = "Max log window lines";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(4, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(103, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Max points on graph";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cmbLogLevel);
            this.groupBox3.Controls.Add(this.btnSerialLogPathBrowse);
            this.groupBox3.Controls.Add(this.btnCSVPathBrowse);
            this.groupBox3.Controls.Add(this.btnLogPathBrowse);
            this.groupBox3.Controls.Add(this.txtLogFileLocation);
            this.groupBox3.Controls.Add(this.txtSerialLogFileLocation);
            this.groupBox3.Controls.Add(this.txtCSVFileLocation);
            this.groupBox3.Controls.Add(this.chkSerialLogFileFlag);
            this.groupBox3.Controls.Add(this.chkCSVFileFlag);
            this.groupBox3.Controls.Add(this.chkLogFileFlag);
            this.groupBox3.Location = new System.Drawing.Point(5, 113);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(307, 116);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log data";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(4, 46);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Logging level";
            // 
            // cmbLogLevel
            // 
            this.cmbLogLevel.FormattingEnabled = true;
            this.cmbLogLevel.Items.AddRange(new object[] {
            "1 - Common messages",
            "2 - Prog activity",
            "3 - All debug info"});
            this.cmbLogLevel.Location = new System.Drawing.Point(112, 41);
            this.cmbLogLevel.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLogLevel.Name = "cmbLogLevel";
            this.cmbLogLevel.Size = new System.Drawing.Size(129, 21);
            this.cmbLogLevel.TabIndex = 4;
            this.cmbLogLevel.Text = "1 - Common messages";
            // 
            // btnSerialLogPathBrowse
            // 
            this.btnSerialLogPathBrowse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSerialLogPathBrowse.Location = new System.Drawing.Point(274, 67);
            this.btnSerialLogPathBrowse.Name = "btnSerialLogPathBrowse";
            this.btnSerialLogPathBrowse.Size = new System.Drawing.Size(27, 20);
            this.btnSerialLogPathBrowse.TabIndex = 7;
            this.btnSerialLogPathBrowse.Text = "...";
            this.btnSerialLogPathBrowse.UseVisualStyleBackColor = true;
            // 
            // btnCSVPathBrowse
            // 
            this.btnCSVPathBrowse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCSVPathBrowse.Location = new System.Drawing.Point(274, 89);
            this.btnCSVPathBrowse.Name = "btnCSVPathBrowse";
            this.btnCSVPathBrowse.Size = new System.Drawing.Size(27, 20);
            this.btnCSVPathBrowse.TabIndex = 10;
            this.btnCSVPathBrowse.Text = "...";
            this.btnCSVPathBrowse.UseVisualStyleBackColor = true;
            // 
            // btnLogPathBrowse
            // 
            this.btnLogPathBrowse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLogPathBrowse.Location = new System.Drawing.Point(274, 19);
            this.btnLogPathBrowse.Name = "btnLogPathBrowse";
            this.btnLogPathBrowse.Size = new System.Drawing.Size(27, 20);
            this.btnLogPathBrowse.TabIndex = 2;
            this.btnLogPathBrowse.Text = "...";
            this.btnLogPathBrowse.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label37);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.txtSerialFileOut);
            this.groupBox1.Controls.Add(this.txtSerialFileIn);
            this.groupBox1.Controls.Add(this.chkWatchdog);
            this.groupBox1.Controls.Add(this.btnOpenWriteToFile);
            this.groupBox1.Controls.Add(this.btnOpenReadFromFile);
            this.groupBox1.Controls.Add(this.COM11);
            this.groupBox1.Location = new System.Drawing.Point(5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 101);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial port";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label37.Location = new System.Drawing.Point(7, 74);
            this.label37.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(60, 13);
            this.label37.TabIndex = 5;
            this.label37.Text = "Write to file";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(7, 47);
            this.label36.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(72, 13);
            this.label36.TabIndex = 2;
            this.label36.Text = "Read from file";
            // 
            // txtSerialFileOut
            // 
            this.txtSerialFileOut.Enabled = false;
            this.txtSerialFileOut.Location = new System.Drawing.Point(95, 72);
            this.txtSerialFileOut.Name = "txtSerialFileOut";
            this.txtSerialFileOut.Size = new System.Drawing.Size(173, 20);
            this.txtSerialFileOut.TabIndex = 6;
            // 
            // txtSerialFileIn
            // 
            this.txtSerialFileIn.Enabled = false;
            this.txtSerialFileIn.Location = new System.Drawing.Point(95, 45);
            this.txtSerialFileIn.Name = "txtSerialFileIn";
            this.txtSerialFileIn.Size = new System.Drawing.Size(173, 20);
            this.txtSerialFileIn.TabIndex = 3;
            // 
            // btnOpenWriteToFile
            // 
            this.btnOpenWriteToFile.Enabled = false;
            this.btnOpenWriteToFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOpenWriteToFile.Location = new System.Drawing.Point(274, 71);
            this.btnOpenWriteToFile.Name = "btnOpenWriteToFile";
            this.btnOpenWriteToFile.Size = new System.Drawing.Size(27, 20);
            this.btnOpenWriteToFile.TabIndex = 7;
            this.btnOpenWriteToFile.Text = "...";
            this.btnOpenWriteToFile.UseVisualStyleBackColor = true;
            // 
            // btnOpenReadFromFile
            // 
            this.btnOpenReadFromFile.Enabled = false;
            this.btnOpenReadFromFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOpenReadFromFile.Location = new System.Drawing.Point(274, 44);
            this.btnOpenReadFromFile.Name = "btnOpenReadFromFile";
            this.btnOpenReadFromFile.Size = new System.Drawing.Size(27, 20);
            this.btnOpenReadFromFile.TabIndex = 4;
            this.btnOpenReadFromFile.Text = "...";
            this.btnOpenReadFromFile.UseVisualStyleBackColor = true;
            // 
            // tabPage_Modeling
            // 
            this.tabPage_Modeling.Controls.Add(this.groupBox4);
            this.tabPage_Modeling.Controls.Add(this.groupBox2);
            this.tabPage_Modeling.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Modeling.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage_Modeling.Name = "tabPage_Modeling";
            this.tabPage_Modeling.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage_Modeling.Size = new System.Drawing.Size(598, 340);
            this.tabPage_Modeling.TabIndex = 1;
            this.tabPage_Modeling.Text = "Modeling";
            this.tabPage_Modeling.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Location = new System.Drawing.Point(5, 80);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(308, 67);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Secondary mirror heater control";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(7, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cloudy/Very cloudy sky threshold";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(7, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Clear/Cloudy sky threshold";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(193, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(53, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(193, 16);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(53, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtCloudysky);
            this.groupBox2.Controls.Add(this.txtClearsky);
            this.groupBox2.Location = new System.Drawing.Point(5, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 67);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Main mirror fan control";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(7, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cloudy/Very cloudy sky threshold";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clear/Cloudy sky threshold";
            // 
            // txtCloudysky
            // 
            this.txtCloudysky.Location = new System.Drawing.Point(193, 41);
            this.txtCloudysky.Name = "txtCloudysky";
            this.txtCloudysky.Size = new System.Drawing.Size(53, 20);
            this.txtCloudysky.TabIndex = 3;
            this.txtCloudysky.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtClearsky
            // 
            this.txtClearsky.Location = new System.Drawing.Point(193, 16);
            this.txtClearsky.Name = "txtClearsky";
            this.txtClearsky.Size = new System.Drawing.Size(53, 20);
            this.txtClearsky.TabIndex = 1;
            this.txtClearsky.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReset.Location = new System.Drawing.Point(4, 373);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(110, 24);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset to Defaults";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(525, 373);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOk.Location = new System.Drawing.Point(420, 373);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(79, 24);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtRefreshInterval
            // 
            this.txtRefreshInterval.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "RefreshInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtRefreshInterval.Location = new System.Drawing.Point(148, 16);
            this.txtRefreshInterval.Name = "txtRefreshInterval";
            this.txtRefreshInterval.Size = new System.Drawing.Size(53, 20);
            this.txtRefreshInterval.TabIndex = 1;
            this.txtRefreshInterval.Text = global::TelescopeTempControl.Properties.Settings.Default.RefreshInterval;
            this.txtRefreshInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox3
            // 
            this.textBox3.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "MaxProgLogLines", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox3.Location = new System.Drawing.Point(238, 58);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(53, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = global::TelescopeTempControl.Properties.Settings.Default.MaxProgLogLines;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMaxLogWindowLines
            // 
            this.txtMaxLogWindowLines.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "MaxLogLines", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMaxLogWindowLines.Location = new System.Drawing.Point(148, 58);
            this.txtMaxLogWindowLines.Name = "txtMaxLogWindowLines";
            this.txtMaxLogWindowLines.Size = new System.Drawing.Size(53, 20);
            this.txtMaxLogWindowLines.TabIndex = 4;
            this.txtMaxLogWindowLines.Text = global::TelescopeTempControl.Properties.Settings.Default.MaxLogLines;
            this.txtMaxLogWindowLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMaxPoints
            // 
            this.txtMaxPoints.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "MaxPointsOnGraph", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMaxPoints.Location = new System.Drawing.Point(148, 37);
            this.txtMaxPoints.Name = "txtMaxPoints";
            this.txtMaxPoints.Size = new System.Drawing.Size(53, 20);
            this.txtMaxPoints.TabIndex = 4;
            this.txtMaxPoints.Text = global::TelescopeTempControl.Properties.Settings.Default.MaxPointsOnGraph;
            this.txtMaxPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtLogFileLocation
            // 
            this.txtLogFileLocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "logFileLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtLogFileLocation.Location = new System.Drawing.Point(112, 20);
            this.txtLogFileLocation.Name = "txtLogFileLocation";
            this.txtLogFileLocation.Size = new System.Drawing.Size(156, 20);
            this.txtLogFileLocation.TabIndex = 1;
            this.txtLogFileLocation.Text = global::TelescopeTempControl.Properties.Settings.Default.logFileLocation;
            // 
            // txtSerialLogFileLocation
            // 
            this.txtSerialLogFileLocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "SerialLogFileLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSerialLogFileLocation.Location = new System.Drawing.Point(112, 67);
            this.txtSerialLogFileLocation.Name = "txtSerialLogFileLocation";
            this.txtSerialLogFileLocation.Size = new System.Drawing.Size(156, 20);
            this.txtSerialLogFileLocation.TabIndex = 6;
            this.txtSerialLogFileLocation.Text = global::TelescopeTempControl.Properties.Settings.Default.SerialLogFileLocation;
            // 
            // txtCSVFileLocation
            // 
            this.txtCSVFileLocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "CSVFileLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCSVFileLocation.Location = new System.Drawing.Point(112, 90);
            this.txtCSVFileLocation.Name = "txtCSVFileLocation";
            this.txtCSVFileLocation.Size = new System.Drawing.Size(156, 20);
            this.txtCSVFileLocation.TabIndex = 9;
            this.txtCSVFileLocation.Text = global::TelescopeTempControl.Properties.Settings.Default.CSVFileLocation;
            // 
            // chkSerialLogFileFlag
            // 
            this.chkSerialLogFileFlag.AutoSize = true;
            this.chkSerialLogFileFlag.Checked = global::TelescopeTempControl.Properties.Settings.Default.SerialLogFileFlag;
            this.chkSerialLogFileFlag.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TelescopeTempControl.Properties.Settings.Default, "SerialLogFileFlag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkSerialLogFileFlag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkSerialLogFileFlag.Location = new System.Drawing.Point(7, 70);
            this.chkSerialLogFileFlag.Name = "chkSerialLogFileFlag";
            this.chkSerialLogFileFlag.Size = new System.Drawing.Size(85, 17);
            this.chkSerialLogFileFlag.TabIndex = 5;
            this.chkSerialLogFileFlag.Text = "Serial log file";
            this.chkSerialLogFileFlag.UseVisualStyleBackColor = true;
            // 
            // chkCSVFileFlag
            // 
            this.chkCSVFileFlag.AutoSize = true;
            this.chkCSVFileFlag.Checked = global::TelescopeTempControl.Properties.Settings.Default.CSVFileFlag;
            this.chkCSVFileFlag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCSVFileFlag.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TelescopeTempControl.Properties.Settings.Default, "CSVFileFlag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkCSVFileFlag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkCSVFileFlag.Location = new System.Drawing.Point(7, 93);
            this.chkCSVFileFlag.Name = "chkCSVFileFlag";
            this.chkCSVFileFlag.Size = new System.Drawing.Size(89, 17);
            this.chkCSVFileFlag.TabIndex = 8;
            this.chkCSVFileFlag.Text = "Data CSV file";
            this.chkCSVFileFlag.UseVisualStyleBackColor = true;
            // 
            // chkLogFileFlag
            // 
            this.chkLogFileFlag.AutoSize = true;
            this.chkLogFileFlag.Checked = global::TelescopeTempControl.Properties.Settings.Default.logFileFlag;
            this.chkLogFileFlag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLogFileFlag.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TelescopeTempControl.Properties.Settings.Default, "logFileFlag", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkLogFileFlag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkLogFileFlag.Location = new System.Drawing.Point(7, 22);
            this.chkLogFileFlag.Name = "chkLogFileFlag";
            this.chkLogFileFlag.Size = new System.Drawing.Size(98, 17);
            this.chkLogFileFlag.TabIndex = 0;
            this.chkLogFileFlag.Text = "Program log file";
            this.chkLogFileFlag.UseVisualStyleBackColor = true;
            // 
            // chkWatchdog
            // 
            this.chkWatchdog.AutoSize = true;
            this.chkWatchdog.Checked = global::TelescopeTempControl.Properties.Settings.Default.ComWatchdog;
            this.chkWatchdog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWatchdog.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TelescopeTempControl.Properties.Settings.Default, "ComWatchdog", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.chkWatchdog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkWatchdog.Location = new System.Drawing.Point(95, 19);
            this.chkWatchdog.Name = "chkWatchdog";
            this.chkWatchdog.Size = new System.Drawing.Size(130, 17);
            this.chkWatchdog.TabIndex = 1;
            this.chkWatchdog.Text = "Connection watchdog";
            this.chkWatchdog.UseVisualStyleBackColor = true;
            // 
            // COM11
            // 
            this.COM11.DataBindings.Add(new System.Windows.Forms.Binding("Name", global::TelescopeTempControl.Properties.Settings.Default, "comport", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.COM11.FormattingEnabled = true;
            this.COM11.Location = new System.Drawing.Point(7, 19);
            this.COM11.Name = global::TelescopeTempControl.Properties.Settings.Default.comport;
            this.COM11.Size = new System.Drawing.Size(72, 21);
            this.COM11.TabIndex = 0;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(608, 401);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_General.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage_Modeling.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_General;
        private System.Windows.Forms.TabPage tabPage_Modeling;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRefreshInterval;
        private System.Windows.Forms.TextBox txtMaxLogWindowLines;
        private System.Windows.Forms.TextBox txtMaxPoints;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbLogLevel;
        private System.Windows.Forms.Button btnSerialLogPathBrowse;
        private System.Windows.Forms.Button btnCSVPathBrowse;
        private System.Windows.Forms.Button btnLogPathBrowse;
        private System.Windows.Forms.TextBox txtLogFileLocation;
        private System.Windows.Forms.TextBox txtSerialLogFileLocation;
        private System.Windows.Forms.TextBox txtCSVFileLocation;
        private System.Windows.Forms.CheckBox chkSerialLogFileFlag;
        private System.Windows.Forms.CheckBox chkCSVFileFlag;
        private System.Windows.Forms.CheckBox chkLogFileFlag;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtSerialFileOut;
        private System.Windows.Forms.TextBox txtSerialFileIn;
        private System.Windows.Forms.CheckBox chkWatchdog;
        private System.Windows.Forms.Button btnOpenWriteToFile;
        private System.Windows.Forms.Button btnOpenReadFromFile;
        private System.Windows.Forms.ComboBox COM11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCloudysky;
        private System.Windows.Forms.TextBox txtClearsky;
        private System.Windows.Forms.TextBox textBox3;
    }
}