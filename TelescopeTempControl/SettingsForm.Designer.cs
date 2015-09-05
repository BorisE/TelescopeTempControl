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
            this.tabPage_Modeling = new System.Windows.Forms.TabPage();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtSerialFileOut = new System.Windows.Forms.TextBox();
            this.txtSerialFileIn = new System.Windows.Forms.TextBox();
            this.chkWatchdog = new System.Windows.Forms.CheckBox();
            this.btnOpenWriteToFile = new System.Windows.Forms.Button();
            this.btnOpenReadFromFile = new System.Windows.Forms.Button();
            this.cmbPortList = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbLogLevel = new System.Windows.Forms.ComboBox();
            this.btnSerialLogPathBrowse = new System.Windows.Forms.Button();
            this.btnCSVPathBrowse = new System.Windows.Forms.Button();
            this.btnLogPathBrowse = new System.Windows.Forms.Button();
            this.txtLogFileLocation = new System.Windows.Forms.TextBox();
            this.txtSerialLogFileLocation = new System.Windows.Forms.TextBox();
            this.txtCSVFileLocation = new System.Windows.Forms.TextBox();
            this.chkSerialLogFileFlag = new System.Windows.Forms.CheckBox();
            this.chkCSVFileFlag = new System.Windows.Forms.CheckBox();
            this.chkLogFileFlag = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRefreshInterval = new System.Windows.Forms.TextBox();
            this.txtMaxLogWindowLines = new System.Windows.Forms.TextBox();
            this.txtMaxPoints = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCloudysky = new System.Windows.Forms.TextBox();
            this.txtClearsky = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage_General.SuspendLayout();
            this.tabPage_Modeling.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(808, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_General
            // 
            this.tabPage_General.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage_General.Controls.Add(this.groupBox6);
            this.tabPage_General.Controls.Add(this.groupBox3);
            this.tabPage_General.Controls.Add(this.groupBox1);
            this.tabPage_General.Location = new System.Drawing.Point(4, 25);
            this.tabPage_General.Name = "tabPage_General";
            this.tabPage_General.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_General.Size = new System.Drawing.Size(800, 421);
            this.tabPage_General.TabIndex = 0;
            this.tabPage_General.Text = "General";
            this.tabPage_General.UseVisualStyleBackColor = true;
            // 
            // tabPage_Modeling
            // 
            this.tabPage_Modeling.Controls.Add(this.groupBox4);
            this.tabPage_Modeling.Controls.Add(this.groupBox2);
            this.tabPage_Modeling.Location = new System.Drawing.Point(4, 25);
            this.tabPage_Modeling.Name = "tabPage_Modeling";
            this.tabPage_Modeling.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Modeling.Size = new System.Drawing.Size(800, 421);
            this.tabPage_Modeling.TabIndex = 1;
            this.tabPage_Modeling.Text = "Modeling";
            this.tabPage_Modeling.UseVisualStyleBackColor = true;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnReset.Location = new System.Drawing.Point(5, 459);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(147, 30);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset to Defaults";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCancel.Location = new System.Drawing.Point(700, 459);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOk.Location = new System.Drawing.Point(560, 459);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(105, 30);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
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
            this.groupBox1.Controls.Add(this.cmbPortList);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(409, 124);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial port";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label37.Location = new System.Drawing.Point(9, 91);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(79, 17);
            this.label37.TabIndex = 5;
            this.label37.Text = "Write to file";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label36.Location = new System.Drawing.Point(9, 58);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(96, 17);
            this.label36.TabIndex = 2;
            this.label36.Text = "Read from file";
            // 
            // txtSerialFileOut
            // 
            this.txtSerialFileOut.Enabled = false;
            this.txtSerialFileOut.Location = new System.Drawing.Point(127, 89);
            this.txtSerialFileOut.Margin = new System.Windows.Forms.Padding(4);
            this.txtSerialFileOut.Name = "txtSerialFileOut";
            this.txtSerialFileOut.Size = new System.Drawing.Size(229, 22);
            this.txtSerialFileOut.TabIndex = 6;
            // 
            // txtSerialFileIn
            // 
            this.txtSerialFileIn.Enabled = false;
            this.txtSerialFileIn.Location = new System.Drawing.Point(127, 55);
            this.txtSerialFileIn.Margin = new System.Windows.Forms.Padding(4);
            this.txtSerialFileIn.Name = "txtSerialFileIn";
            this.txtSerialFileIn.Size = new System.Drawing.Size(229, 22);
            this.txtSerialFileIn.TabIndex = 3;
            // 
            // chkWatchdog
            // 
            this.chkWatchdog.AutoSize = true;
            this.chkWatchdog.Checked = true;
            this.chkWatchdog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWatchdog.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkWatchdog.Location = new System.Drawing.Point(127, 23);
            this.chkWatchdog.Margin = new System.Windows.Forms.Padding(4);
            this.chkWatchdog.Name = "chkWatchdog";
            this.chkWatchdog.Size = new System.Drawing.Size(165, 21);
            this.chkWatchdog.TabIndex = 1;
            this.chkWatchdog.Text = "Connection watchdog";
            this.chkWatchdog.UseVisualStyleBackColor = true;
            // 
            // btnOpenWriteToFile
            // 
            this.btnOpenWriteToFile.Enabled = false;
            this.btnOpenWriteToFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOpenWriteToFile.Location = new System.Drawing.Point(365, 87);
            this.btnOpenWriteToFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenWriteToFile.Name = "btnOpenWriteToFile";
            this.btnOpenWriteToFile.Size = new System.Drawing.Size(36, 25);
            this.btnOpenWriteToFile.TabIndex = 7;
            this.btnOpenWriteToFile.Text = "...";
            this.btnOpenWriteToFile.UseVisualStyleBackColor = true;
            // 
            // btnOpenReadFromFile
            // 
            this.btnOpenReadFromFile.Enabled = false;
            this.btnOpenReadFromFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOpenReadFromFile.Location = new System.Drawing.Point(365, 54);
            this.btnOpenReadFromFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpenReadFromFile.Name = "btnOpenReadFromFile";
            this.btnOpenReadFromFile.Size = new System.Drawing.Size(36, 25);
            this.btnOpenReadFromFile.TabIndex = 4;
            this.btnOpenReadFromFile.Text = "...";
            this.btnOpenReadFromFile.UseVisualStyleBackColor = true;
            // 
            // cmbPortList
            // 
            this.cmbPortList.FormattingEnabled = true;
            this.cmbPortList.Location = new System.Drawing.Point(9, 23);
            this.cmbPortList.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPortList.Name = "cmbPortList";
            this.cmbPortList.Size = new System.Drawing.Size(95, 24);
            this.cmbPortList.TabIndex = 0;
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
            this.groupBox3.Location = new System.Drawing.Point(7, 139);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(409, 143);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Log data";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(5, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 17);
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
            this.cmbLogLevel.Location = new System.Drawing.Point(149, 50);
            this.cmbLogLevel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbLogLevel.Name = "cmbLogLevel";
            this.cmbLogLevel.Size = new System.Drawing.Size(171, 24);
            this.cmbLogLevel.TabIndex = 4;
            this.cmbLogLevel.Text = "1 - Common messages";
            // 
            // btnSerialLogPathBrowse
            // 
            this.btnSerialLogPathBrowse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSerialLogPathBrowse.Location = new System.Drawing.Point(365, 82);
            this.btnSerialLogPathBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnSerialLogPathBrowse.Name = "btnSerialLogPathBrowse";
            this.btnSerialLogPathBrowse.Size = new System.Drawing.Size(36, 25);
            this.btnSerialLogPathBrowse.TabIndex = 7;
            this.btnSerialLogPathBrowse.Text = "...";
            this.btnSerialLogPathBrowse.UseVisualStyleBackColor = true;
            // 
            // btnCSVPathBrowse
            // 
            this.btnCSVPathBrowse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCSVPathBrowse.Location = new System.Drawing.Point(365, 110);
            this.btnCSVPathBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnCSVPathBrowse.Name = "btnCSVPathBrowse";
            this.btnCSVPathBrowse.Size = new System.Drawing.Size(36, 25);
            this.btnCSVPathBrowse.TabIndex = 10;
            this.btnCSVPathBrowse.Text = "...";
            this.btnCSVPathBrowse.UseVisualStyleBackColor = true;
            // 
            // btnLogPathBrowse
            // 
            this.btnLogPathBrowse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnLogPathBrowse.Location = new System.Drawing.Point(365, 23);
            this.btnLogPathBrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogPathBrowse.Name = "btnLogPathBrowse";
            this.btnLogPathBrowse.Size = new System.Drawing.Size(36, 25);
            this.btnLogPathBrowse.TabIndex = 2;
            this.btnLogPathBrowse.Text = "...";
            this.btnLogPathBrowse.UseVisualStyleBackColor = true;
            // 
            // txtLogFileLocation
            // 
            this.txtLogFileLocation.Location = new System.Drawing.Point(149, 25);
            this.txtLogFileLocation.Margin = new System.Windows.Forms.Padding(4);
            this.txtLogFileLocation.Name = "txtLogFileLocation";
            this.txtLogFileLocation.Size = new System.Drawing.Size(207, 22);
            this.txtLogFileLocation.TabIndex = 1;
            // 
            // txtSerialLogFileLocation
            // 
            this.txtSerialLogFileLocation.Location = new System.Drawing.Point(149, 82);
            this.txtSerialLogFileLocation.Margin = new System.Windows.Forms.Padding(4);
            this.txtSerialLogFileLocation.Name = "txtSerialLogFileLocation";
            this.txtSerialLogFileLocation.Size = new System.Drawing.Size(207, 22);
            this.txtSerialLogFileLocation.TabIndex = 6;
            // 
            // txtCSVFileLocation
            // 
            this.txtCSVFileLocation.Location = new System.Drawing.Point(149, 111);
            this.txtCSVFileLocation.Margin = new System.Windows.Forms.Padding(4);
            this.txtCSVFileLocation.Name = "txtCSVFileLocation";
            this.txtCSVFileLocation.Size = new System.Drawing.Size(207, 22);
            this.txtCSVFileLocation.TabIndex = 9;
            // 
            // chkSerialLogFileFlag
            // 
            this.chkSerialLogFileFlag.AutoSize = true;
            this.chkSerialLogFileFlag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkSerialLogFileFlag.Location = new System.Drawing.Point(9, 86);
            this.chkSerialLogFileFlag.Margin = new System.Windows.Forms.Padding(4);
            this.chkSerialLogFileFlag.Name = "chkSerialLogFileFlag";
            this.chkSerialLogFileFlag.Size = new System.Drawing.Size(111, 21);
            this.chkSerialLogFileFlag.TabIndex = 5;
            this.chkSerialLogFileFlag.Text = "Serial log file";
            this.chkSerialLogFileFlag.UseVisualStyleBackColor = true;
            // 
            // chkCSVFileFlag
            // 
            this.chkCSVFileFlag.AutoSize = true;
            this.chkCSVFileFlag.Checked = true;
            this.chkCSVFileFlag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCSVFileFlag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkCSVFileFlag.Location = new System.Drawing.Point(9, 114);
            this.chkCSVFileFlag.Margin = new System.Windows.Forms.Padding(4);
            this.chkCSVFileFlag.Name = "chkCSVFileFlag";
            this.chkCSVFileFlag.Size = new System.Drawing.Size(113, 21);
            this.chkCSVFileFlag.TabIndex = 8;
            this.chkCSVFileFlag.Text = "Data CSV file";
            this.chkCSVFileFlag.UseVisualStyleBackColor = true;
            // 
            // chkLogFileFlag
            // 
            this.chkLogFileFlag.AutoSize = true;
            this.chkLogFileFlag.Checked = true;
            this.chkLogFileFlag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLogFileFlag.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkLogFileFlag.Location = new System.Drawing.Point(9, 27);
            this.chkLogFileFlag.Margin = new System.Windows.Forms.Padding(4);
            this.chkLogFileFlag.Name = "chkLogFileFlag";
            this.chkLogFileFlag.Size = new System.Drawing.Size(129, 21);
            this.chkLogFileFlag.TabIndex = 0;
            this.chkLogFileFlag.Text = "Program log file";
            this.chkLogFileFlag.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label39);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.txtRefreshInterval);
            this.groupBox6.Controls.Add(this.txtMaxLogWindowLines);
            this.groupBox6.Controls.Add(this.txtMaxPoints);
            this.groupBox6.Location = new System.Drawing.Point(8, 290);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(409, 103);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Productivity settings";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label32.Location = new System.Drawing.Point(273, 23);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(53, 17);
            this.label32.TabIndex = 2;
            this.label32.Text = "millisec";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(5, 23);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "Main tick interval";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label39.Location = new System.Drawing.Point(5, 75);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(138, 17);
            this.label39.TabIndex = 3;
            this.label39.Text = "Max log window lines";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(5, 49);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(136, 17);
            this.label15.TabIndex = 3;
            this.label15.Text = "Max points on graph";
            // 
            // txtRefreshInterval
            // 
            this.txtRefreshInterval.Location = new System.Drawing.Point(197, 20);
            this.txtRefreshInterval.Margin = new System.Windows.Forms.Padding(4);
            this.txtRefreshInterval.Name = "txtRefreshInterval";
            this.txtRefreshInterval.Size = new System.Drawing.Size(69, 22);
            this.txtRefreshInterval.TabIndex = 1;
            this.txtRefreshInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMaxLogWindowLines
            // 
            this.txtMaxLogWindowLines.Location = new System.Drawing.Point(197, 71);
            this.txtMaxLogWindowLines.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaxLogWindowLines.Name = "txtMaxLogWindowLines";
            this.txtMaxLogWindowLines.Size = new System.Drawing.Size(69, 22);
            this.txtMaxLogWindowLines.TabIndex = 4;
            this.txtMaxLogWindowLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMaxPoints
            // 
            this.txtMaxPoints.Location = new System.Drawing.Point(197, 46);
            this.txtMaxPoints.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaxPoints.Name = "txtMaxPoints";
            this.txtMaxPoints.Size = new System.Drawing.Size(69, 22);
            this.txtMaxPoints.TabIndex = 4;
            this.txtMaxPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtCloudysky);
            this.groupBox2.Controls.Add(this.txtClearsky);
            this.groupBox2.Location = new System.Drawing.Point(7, 7);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(411, 83);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Main mirror fan control";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(9, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cloudy/Very cloudy sky threshold";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clear/Cloudy sky threshold";
            // 
            // txtCloudysky
            // 
            this.txtCloudysky.Location = new System.Drawing.Point(257, 50);
            this.txtCloudysky.Margin = new System.Windows.Forms.Padding(4);
            this.txtCloudysky.Name = "txtCloudysky";
            this.txtCloudysky.Size = new System.Drawing.Size(69, 22);
            this.txtCloudysky.TabIndex = 3;
            this.txtCloudysky.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtClearsky
            // 
            this.txtClearsky.Location = new System.Drawing.Point(257, 20);
            this.txtClearsky.Margin = new System.Windows.Forms.Padding(4);
            this.txtClearsky.Name = "txtClearsky";
            this.txtClearsky.Size = new System.Drawing.Size(69, 22);
            this.txtClearsky.TabIndex = 1;
            this.txtClearsky.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Location = new System.Drawing.Point(7, 98);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(411, 83);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Secondary mirror heater control";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(9, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cloudy/Very cloudy sky threshold";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(9, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Clear/Cloudy sky threshold";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(257, 50);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(69, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(257, 20);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(69, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(810, 493);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_General.ResumeLayout(false);
            this.tabPage_Modeling.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.ComboBox cmbPortList;
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
    }
}