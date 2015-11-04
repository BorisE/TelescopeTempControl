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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_General = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSendDataToSerialInterval = new System.Windows.Forms.TextBox();
            this.txtRefreshInterval = new System.Windows.Forms.TextBox();
            this.txtMaxPoints = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbLogLevel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSerialLogPathBrowse = new System.Windows.Forms.Button();
            this.label39 = new System.Windows.Forms.Label();
            this.btnCSVPathBrowse = new System.Windows.Forms.Button();
            this.btnLogPathBrowse = new System.Windows.Forms.Button();
            this.txtProgLogMaxLines = new System.Windows.Forms.TextBox();
            this.txtLogFileLocation = new System.Windows.Forms.TextBox();
            this.txtMaxLogWindowLines = new System.Windows.Forms.TextBox();
            this.txtSerialLogFileLocation = new System.Windows.Forms.TextBox();
            this.txtCSVFileLocation = new System.Windows.Forms.TextBox();
            this.chkSerialLogFileFlag = new System.Windows.Forms.CheckBox();
            this.chkCSVFileFlag = new System.Windows.Forms.CheckBox();
            this.chkLogFileFlag = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtSerialFileOut = new System.Windows.Forms.TextBox();
            this.txtSerialFileIn = new System.Windows.Forms.TextBox();
            this.chkWatchdog = new System.Windows.Forms.CheckBox();
            this.btnOpenWriteToFile = new System.Windows.Forms.Button();
            this.btnOpenReadFromFile = new System.Windows.Forms.Button();
            this.cmbPortList = new System.Windows.Forms.ComboBox();
            this.tabPage_Modeling = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCurve_Second_c = new System.Windows.Forms.TextBox();
            this.txtCurve_Second_b = new System.Windows.Forms.TextBox();
            this.txtCurve_Second_a = new System.Windows.Forms.TextBox();
            this.chartSecondCurve = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTempDelta_Second_MaxEffort = new System.Windows.Forms.TextBox();
            this.txtTempTargetDelta_Second = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRedraw = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCurve_Main_c = new System.Windows.Forms.TextBox();
            this.txtCurve_Main_b = new System.Windows.Forms.TextBox();
            this.txtCurve_Main_a = new System.Windows.Forms.TextBox();
            this.chartMainCurve = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTempDelta_Main_DewRiskZone = new System.Windows.Forms.TextBox();
            this.txtTempDelta_Main_MaxEffort = new System.Windows.Forms.TextBox();
            this.txtTempTargetDelta_Main = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage_General.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage_Modeling.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSecondCurve)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMainCurve)).BeginInit();
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
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.txtSendDataToSerialInterval);
            this.groupBox6.Controls.Add(this.txtRefreshInterval);
            this.groupBox6.Controls.Add(this.txtMaxPoints);
            this.groupBox6.Location = new System.Drawing.Point(318, 10);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(273, 97);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Productivity settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(206, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "sec";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(4, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Send data to serial interval";
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
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(6, 69);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(103, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Max points on graph";
            // 
            // txtSendDataToSerialInterval
            // 
            this.txtSendDataToSerialInterval.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "SendDataInterval", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSendDataToSerialInterval.Location = new System.Drawing.Point(148, 40);
            this.txtSendDataToSerialInterval.Name = "txtSendDataToSerialInterval";
            this.txtSendDataToSerialInterval.Size = new System.Drawing.Size(53, 20);
            this.txtSendDataToSerialInterval.TabIndex = 1;
            this.txtSendDataToSerialInterval.Text = global::TelescopeTempControl.Properties.Settings.Default.SendDataInterval;
            this.txtSendDataToSerialInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.txtSendDataToSerialInterval, "Make corrections every stated seconds");
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
            // txtMaxPoints
            // 
            this.txtMaxPoints.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "MaxPointsOnGraph", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMaxPoints.Location = new System.Drawing.Point(148, 66);
            this.txtMaxPoints.Name = "txtMaxPoints";
            this.txtMaxPoints.Size = new System.Drawing.Size(53, 20);
            this.txtMaxPoints.TabIndex = 4;
            this.txtMaxPoints.Text = global::TelescopeTempControl.Properties.Settings.Default.MaxPointsOnGraph;
            this.txtMaxPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cmbLogLevel);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnSerialLogPathBrowse);
            this.groupBox3.Controls.Add(this.label39);
            this.groupBox3.Controls.Add(this.btnCSVPathBrowse);
            this.groupBox3.Controls.Add(this.btnLogPathBrowse);
            this.groupBox3.Controls.Add(this.txtProgLogMaxLines);
            this.groupBox3.Controls.Add(this.txtLogFileLocation);
            this.groupBox3.Controls.Add(this.txtMaxLogWindowLines);
            this.groupBox3.Controls.Add(this.txtSerialLogFileLocation);
            this.groupBox3.Controls.Add(this.txtCSVFileLocation);
            this.groupBox3.Controls.Add(this.chkSerialLogFileFlag);
            this.groupBox3.Controls.Add(this.chkCSVFileFlag);
            this.groupBox3.Controls.Add(this.chkLogFileFlag);
            this.groupBox3.Location = new System.Drawing.Point(5, 113);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(307, 175);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(7, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Max program log display lines";
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
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label39.Location = new System.Drawing.Point(7, 123);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(107, 13);
            this.label39.TabIndex = 3;
            this.label39.Text = "Max log window lines";
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
            // txtProgLogMaxLines
            // 
            this.txtProgLogMaxLines.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "MaxProgLogLines", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtProgLogMaxLines.Location = new System.Drawing.Point(248, 146);
            this.txtProgLogMaxLines.Name = "txtProgLogMaxLines";
            this.txtProgLogMaxLines.Size = new System.Drawing.Size(53, 20);
            this.txtProgLogMaxLines.TabIndex = 4;
            this.txtProgLogMaxLines.Text = global::TelescopeTempControl.Properties.Settings.Default.MaxProgLogLines;
            this.txtProgLogMaxLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // txtMaxLogWindowLines
            // 
            this.txtMaxLogWindowLines.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "MaxLogLines", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtMaxLogWindowLines.Location = new System.Drawing.Point(248, 120);
            this.txtMaxLogWindowLines.Name = "txtMaxLogWindowLines";
            this.txtMaxLogWindowLines.Size = new System.Drawing.Size(53, 20);
            this.txtMaxLogWindowLines.TabIndex = 4;
            this.txtMaxLogWindowLines.Text = global::TelescopeTempControl.Properties.Settings.Default.MaxLogLines;
            this.txtMaxLogWindowLines.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            // cmbPortList
            // 
            this.cmbPortList.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "comport", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbPortList.FormattingEnabled = true;
            this.cmbPortList.Location = new System.Drawing.Point(7, 19);
            this.cmbPortList.Name = "cmbPortList";
            this.cmbPortList.Size = new System.Drawing.Size(72, 21);
            this.cmbPortList.TabIndex = 0;
            this.cmbPortList.Text = global::TelescopeTempControl.Properties.Settings.Default.comport;
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
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.chartSecondCurve);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtTempDelta_Second_MaxEffort);
            this.groupBox4.Controls.Add(this.txtTempTargetDelta_Second);
            this.groupBox4.Location = new System.Drawing.Point(304, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(287, 329);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Secondary mirror heater control";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.txtCurve_Second_c);
            this.groupBox5.Controls.Add(this.txtCurve_Second_b);
            this.groupBox5.Controls.Add(this.txtCurve_Second_a);
            this.groupBox5.Location = new System.Drawing.Point(6, 103);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(275, 49);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Intermediate curve parameters";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(149, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "c";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(77, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(13, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "b";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(211, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "Redraw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(8, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(13, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "a";
            // 
            // txtCurve_Second_c
            // 
            this.txtCurve_Second_c.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "Curve_Second_c", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCurve_Second_c.Location = new System.Drawing.Point(168, 19);
            this.txtCurve_Second_c.Name = "txtCurve_Second_c";
            this.txtCurve_Second_c.Size = new System.Drawing.Size(37, 20);
            this.txtCurve_Second_c.TabIndex = 1;
            this.txtCurve_Second_c.Text = global::TelescopeTempControl.Properties.Settings.Default.Curve_Second_c;
            this.txtCurve_Second_c.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCurve_Second_b
            // 
            this.txtCurve_Second_b.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "Curve_Second_b", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCurve_Second_b.Location = new System.Drawing.Point(96, 19);
            this.txtCurve_Second_b.Name = "txtCurve_Second_b";
            this.txtCurve_Second_b.Size = new System.Drawing.Size(47, 20);
            this.txtCurve_Second_b.TabIndex = 1;
            this.txtCurve_Second_b.Text = global::TelescopeTempControl.Properties.Settings.Default.Curve_Second_b;
            this.txtCurve_Second_b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCurve_Second_a
            // 
            this.txtCurve_Second_a.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "Curve_Second_a", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCurve_Second_a.Location = new System.Drawing.Point(27, 19);
            this.txtCurve_Second_a.Name = "txtCurve_Second_a";
            this.txtCurve_Second_a.Size = new System.Drawing.Size(42, 20);
            this.txtCurve_Second_a.TabIndex = 1;
            this.txtCurve_Second_a.Text = global::TelescopeTempControl.Properties.Settings.Default.Curve_Second_a;
            this.txtCurve_Second_a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chartSecondCurve
            // 
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 6;
            chartArea1.AxisX.MajorGrid.Interval = 0D;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MinorTickMark.Enabled = true;
            chartArea1.AxisX.MinorTickMark.Interval = 0.1D;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.Title = "Temp delta";
            chartArea1.AxisY.Interval = 20D;
            chartArea1.AxisY.IntervalOffset = 5D;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 6;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.Maximum = 110D;
            chartArea1.AxisY.Minimum = -5D;
            chartArea1.AxisY.Title = "Power, %";
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 94F;
            chartArea1.Position.Width = 99F;
            chartArea1.Position.Y = 3F;
            this.chartSecondCurve.ChartAreas.Add(chartArea1);
            this.chartSecondCurve.Location = new System.Drawing.Point(3, 157);
            this.chartSecondCurve.Name = "chartSecondCurve";
            this.chartSecondCurve.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Name = "curve";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "maxzone";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Name = "minzone";
            this.chartSecondCurve.Series.Add(series1);
            this.chartSecondCurve.Series.Add(series2);
            this.chartSecondCurve.Series.Add(series3);
            this.chartSecondCurve.Size = new System.Drawing.Size(282, 168);
            this.chartSecondCurve.TabIndex = 2;
            this.chartSecondCurve.Text = "chartMainCurve";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(7, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Max effort zone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(7, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Target delta";
            // 
            // txtTempDelta_Second_MaxEffort
            // 
            this.txtTempDelta_Second_MaxEffort.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "TempDelta_Second_MaxEffort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTempDelta_Second_MaxEffort.Location = new System.Drawing.Point(193, 41);
            this.txtTempDelta_Second_MaxEffort.Name = "txtTempDelta_Second_MaxEffort";
            this.txtTempDelta_Second_MaxEffort.Size = new System.Drawing.Size(53, 20);
            this.txtTempDelta_Second_MaxEffort.TabIndex = 3;
            this.txtTempDelta_Second_MaxEffort.Text = global::TelescopeTempControl.Properties.Settings.Default.TempDelta_Second_MaxEffort;
            this.txtTempDelta_Second_MaxEffort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTempTargetDelta_Second
            // 
            this.txtTempTargetDelta_Second.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "TempDelta_Second_Target", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTempTargetDelta_Second.Location = new System.Drawing.Point(193, 16);
            this.txtTempTargetDelta_Second.Name = "txtTempTargetDelta_Second";
            this.txtTempTargetDelta_Second.Size = new System.Drawing.Size(53, 20);
            this.txtTempTargetDelta_Second.TabIndex = 1;
            this.txtTempTargetDelta_Second.Text = global::TelescopeTempControl.Properties.Settings.Default.TempDelta_Second_Target;
            this.txtTempTargetDelta_Second.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox7);
            this.groupBox2.Controls.Add(this.chartMainCurve);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtTempDelta_Main_DewRiskZone);
            this.groupBox2.Controls.Add(this.txtTempDelta_Main_MaxEffort);
            this.groupBox2.Controls.Add(this.txtTempTargetDelta_Main);
            this.groupBox2.Location = new System.Drawing.Point(5, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(287, 329);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Main mirror fan control";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.btnRedraw);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Controls.Add(this.txtCurve_Main_c);
            this.groupBox7.Controls.Add(this.txtCurve_Main_b);
            this.groupBox7.Controls.Add(this.txtCurve_Main_a);
            this.groupBox7.Location = new System.Drawing.Point(6, 103);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(275, 49);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Intermediate curve parameters";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(149, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "c";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(75, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "b";
            // 
            // btnRedraw
            // 
            this.btnRedraw.Location = new System.Drawing.Point(211, 16);
            this.btnRedraw.Name = "btnRedraw";
            this.btnRedraw.Size = new System.Drawing.Size(58, 25);
            this.btnRedraw.TabIndex = 3;
            this.btnRedraw.Text = "Redraw";
            this.btnRedraw.UseVisualStyleBackColor = true;
            this.btnRedraw.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(8, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "a";
            // 
            // txtCurve_Main_c
            // 
            this.txtCurve_Main_c.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "Curve_Main_c", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCurve_Main_c.Location = new System.Drawing.Point(168, 19);
            this.txtCurve_Main_c.Name = "txtCurve_Main_c";
            this.txtCurve_Main_c.Size = new System.Drawing.Size(37, 20);
            this.txtCurve_Main_c.TabIndex = 1;
            this.txtCurve_Main_c.Text = global::TelescopeTempControl.Properties.Settings.Default.Curve_Main_c;
            this.txtCurve_Main_c.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCurve_Main_b
            // 
            this.txtCurve_Main_b.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "Curve_Main_b", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCurve_Main_b.Location = new System.Drawing.Point(96, 19);
            this.txtCurve_Main_b.Name = "txtCurve_Main_b";
            this.txtCurve_Main_b.Size = new System.Drawing.Size(37, 20);
            this.txtCurve_Main_b.TabIndex = 1;
            this.txtCurve_Main_b.Text = global::TelescopeTempControl.Properties.Settings.Default.Curve_Main_b;
            this.txtCurve_Main_b.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCurve_Main_a
            // 
            this.txtCurve_Main_a.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "Curve_Main_a", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtCurve_Main_a.Location = new System.Drawing.Point(27, 19);
            this.txtCurve_Main_a.Name = "txtCurve_Main_a";
            this.txtCurve_Main_a.Size = new System.Drawing.Size(37, 20);
            this.txtCurve_Main_a.TabIndex = 1;
            this.txtCurve_Main_a.Text = global::TelescopeTempControl.Properties.Settings.Default.Curve_Main_a;
            this.txtCurve_Main_a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chartMainCurve
            // 
            chartArea2.AxisX.LabelAutoFitMaxFontSize = 6;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisX.MinorGrid.Enabled = true;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea2.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisX.MinorTickMark.Enabled = true;
            chartArea2.AxisX.MinorTickMark.Interval = 0.1D;
            chartArea2.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX.Title = "Temp delta";
            chartArea2.AxisY.Interval = 20D;
            chartArea2.AxisY.IntervalOffset = 5D;
            chartArea2.AxisY.LabelAutoFitMaxFontSize = 6;
            chartArea2.AxisY.MajorGrid.Interval = 20D;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisY.Maximum = 105D;
            chartArea2.AxisY.Minimum = -5D;
            chartArea2.AxisY.Title = "Power, %";
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 94F;
            chartArea2.Position.Width = 99F;
            chartArea2.Position.Y = 3F;
            this.chartMainCurve.ChartAreas.Add(chartArea2);
            this.chartMainCurve.Location = new System.Drawing.Point(3, 158);
            this.chartMainCurve.Margin = new System.Windows.Forms.Padding(1);
            this.chartMainCurve.Name = "chartMainCurve";
            this.chartMainCurve.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Name = "curve";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Name = "maxzone";
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Name = "minzone";
            this.chartMainCurve.Series.Add(series4);
            this.chartMainCurve.Series.Add(series5);
            this.chartMainCurve.Series.Add(series6);
            this.chartMainCurve.Size = new System.Drawing.Size(282, 168);
            this.chartMainCurve.TabIndex = 2;
            this.chartMainCurve.Text = "chartMainCurve";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(7, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Dew risk zone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(7, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max effort zone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Target delta";
            // 
            // txtTempDelta_Main_DewRiskZone
            // 
            this.txtTempDelta_Main_DewRiskZone.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "TempDelta_Main_DewRiskZone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTempDelta_Main_DewRiskZone.Location = new System.Drawing.Point(193, 67);
            this.txtTempDelta_Main_DewRiskZone.Name = "txtTempDelta_Main_DewRiskZone";
            this.txtTempDelta_Main_DewRiskZone.Size = new System.Drawing.Size(53, 20);
            this.txtTempDelta_Main_DewRiskZone.TabIndex = 3;
            this.txtTempDelta_Main_DewRiskZone.Text = global::TelescopeTempControl.Properties.Settings.Default.TempDelta_Main_DewRiskZone;
            this.txtTempDelta_Main_DewRiskZone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTempDelta_Main_MaxEffort
            // 
            this.txtTempDelta_Main_MaxEffort.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "TempDelta_Main_MaxEffort", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTempDelta_Main_MaxEffort.Location = new System.Drawing.Point(193, 41);
            this.txtTempDelta_Main_MaxEffort.Name = "txtTempDelta_Main_MaxEffort";
            this.txtTempDelta_Main_MaxEffort.Size = new System.Drawing.Size(53, 20);
            this.txtTempDelta_Main_MaxEffort.TabIndex = 3;
            this.txtTempDelta_Main_MaxEffort.Text = global::TelescopeTempControl.Properties.Settings.Default.TempDelta_Main_MaxEffort;
            this.txtTempDelta_Main_MaxEffort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTempTargetDelta_Main
            // 
            this.txtTempTargetDelta_Main.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TelescopeTempControl.Properties.Settings.Default, "TempDelta_Main_Target", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTempTargetDelta_Main.Location = new System.Drawing.Point(193, 16);
            this.txtTempTargetDelta_Main.Name = "txtTempTargetDelta_Main";
            this.txtTempTargetDelta_Main.Size = new System.Drawing.Size(53, 20);
            this.txtTempTargetDelta_Main.TabIndex = 1;
            this.txtTempTargetDelta_Main.Text = global::TelescopeTempControl.Properties.Settings.Default.TempDelta_Main_Target;
            this.txtTempTargetDelta_Main.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSecondCurve)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMainCurve)).EndInit();
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
        private System.Windows.Forms.TextBox txtTempDelta_Second_MaxEffort;
        private System.Windows.Forms.TextBox txtTempTargetDelta_Second;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTempDelta_Main_MaxEffort;
        private System.Windows.Forms.TextBox txtTempTargetDelta_Main;
        private System.Windows.Forms.TextBox txtProgLogMaxLines;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSendDataToSerialInterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnRedraw;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMainCurve;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCurve_Main_b;
        private System.Windows.Forms.TextBox txtCurve_Main_a;
        private System.Windows.Forms.TextBox txtCurve_Main_c;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTempDelta_Main_DewRiskZone;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCurve_Second_c;
        private System.Windows.Forms.TextBox txtCurve_Second_b;
        private System.Windows.Forms.TextBox txtCurve_Second_a;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSecondCurve;
    }
}