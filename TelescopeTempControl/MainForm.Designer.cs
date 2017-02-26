namespace TelescopeTempControl
{
    partial class MainForm
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
            System.Windows.Forms.AGaugeRange aGaugeRange1 = new System.Windows.Forms.AGaugeRange();
            System.Windows.Forms.AGaugeRange aGaugeRange2 = new System.Windows.Forms.AGaugeRange();
            System.Windows.Forms.AGaugeRange aGaugeRange3 = new System.Windows.Forms.AGaugeRange();
            System.Windows.Forms.AGaugeRange aGaugeRange4 = new System.Windows.Forms.AGaugeRange();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine1 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine2 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine3 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine4 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine5 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine6 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnLog = new System.Windows.Forms.Button();
            this.aFanGauge = new System.Windows.Forms.AGauge();
            this.aHeaterGauge = new System.Windows.Forms.AGauge();
            this.trackBar_HeaterPWM = new System.Windows.Forms.TrackBar();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.txtFldTemp2 = new System.Windows.Forms.TextBox();
            this.txtFldTemp3 = new System.Windows.Forms.TextBox();
            this.txtFldTemp1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.logRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer_main = new System.Windows.Forms.Timer(this.components);
            this.timer_debug_changetext = new System.Windows.Forms.Timer(this.components);
            this.timer_debug_portread = new System.Windows.Forms.Timer(this.components);
            this.btnSimulate = new System.Windows.Forms.Button();
            this.trackBar_FanPWM = new System.Windows.Forms.TrackBar();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtControlFanPWM = new System.Windows.Forms.TextBox();
            this.txtControlHeaterPWM = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFldDTemp = new System.Windows.Forms.TextBox();
            this.txtDewPoint = new System.Windows.Forms.TextBox();
            this.txtFldHumidity = new System.Windows.Forms.TextBox();
            this.txtSecondaryDelta = new System.Windows.Forms.TextBox();
            this.txtMainDelta = new System.Windows.Forms.TextBox();
            this.gbGauge = new System.Windows.Forms.GroupBox();
            this.chkAutoHeatingControlling = new System.Windows.Forms.CheckBox();
            this.chkAutoFanControlling = new System.Windows.Forms.CheckBox();
            this.txtFldHeaterPWM = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFldRPM = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnOnOff = new System.Windows.Forms.Button();
            this.backgroundWorker_SocketServer = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_HeaterPWM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_FanPWM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbGauge.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(1136, 11);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(109, 35);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.toolTip1.SetToolTip(this.btnStart, "Start/stop program (start/stop reading/writing data to hardware module)");
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettings.Location = new System.Drawing.Point(1136, 151);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(109, 35);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Location = new System.Drawing.Point(1136, 314);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(109, 35);
            this.btnAbout.TabIndex = 5;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnLog
            // 
            this.btnLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLog.Location = new System.Drawing.Point(1136, 195);
            this.btnLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(109, 35);
            this.btnLog.TabIndex = 3;
            this.btnLog.Text = "Log";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // aFanGauge
            // 
            this.aFanGauge.BackColor = System.Drawing.SystemColors.Control;
            this.aFanGauge.BaseArcColor = System.Drawing.Color.Gray;
            this.aFanGauge.BaseArcRadius = 60;
            this.aFanGauge.BaseArcStart = 135;
            this.aFanGauge.BaseArcSweep = 270;
            this.aFanGauge.BaseArcWidth = 2;
            this.aFanGauge.Center = new System.Drawing.Point(165, 115);
            this.aFanGauge.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            aGaugeRange1.Color = System.Drawing.Color.Red;
            aGaugeRange1.EndValue = 1300F;
            aGaugeRange1.InnerRadius = 50;
            aGaugeRange1.InRange = false;
            aGaugeRange1.Name = "GaugeRange1";
            aGaugeRange1.OuterRadius = 60;
            aGaugeRange1.StartValue = 1000F;
            aGaugeRange2.Color = System.Drawing.Color.DimGray;
            aGaugeRange2.EndValue = 150F;
            aGaugeRange2.InnerRadius = 50;
            aGaugeRange2.InRange = false;
            aGaugeRange2.Name = "GaugeRange2";
            aGaugeRange2.OuterRadius = 60;
            aGaugeRange2.StartValue = 0F;
            aGaugeRange3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            aGaugeRange3.EndValue = 400F;
            aGaugeRange3.InnerRadius = 50;
            aGaugeRange3.InRange = false;
            aGaugeRange3.Name = "GaugeRange3";
            aGaugeRange3.OuterRadius = 60;
            aGaugeRange3.StartValue = 150F;
            this.aFanGauge.GaugeRanges.Add(aGaugeRange1);
            this.aFanGauge.GaugeRanges.Add(aGaugeRange2);
            this.aFanGauge.GaugeRanges.Add(aGaugeRange3);
            this.aFanGauge.Location = new System.Drawing.Point(6, 26);
            this.aFanGauge.MaxValue = 1300F;
            this.aFanGauge.MinValue = 0F;
            this.aFanGauge.Name = "aFanGauge";
            this.aFanGauge.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Gray;
            this.aFanGauge.NeedleColor2 = System.Drawing.Color.DimGray;
            this.aFanGauge.NeedleRadius = 60;
            this.aFanGauge.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.aFanGauge.NeedleWidth = 2;
            this.aFanGauge.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.aFanGauge.ScaleLinesInterInnerRadius = 53;
            this.aFanGauge.ScaleLinesInterOuterRadius = 60;
            this.aFanGauge.ScaleLinesInterWidth = 1;
            this.aFanGauge.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.aFanGauge.ScaleLinesMajorInnerRadius = 50;
            this.aFanGauge.ScaleLinesMajorOuterRadius = 60;
            this.aFanGauge.ScaleLinesMajorStepValue = 100F;
            this.aFanGauge.ScaleLinesMajorWidth = 2;
            this.aFanGauge.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.aFanGauge.ScaleLinesMinorInnerRadius = 55;
            this.aFanGauge.ScaleLinesMinorOuterRadius = 60;
            this.aFanGauge.ScaleLinesMinorTicks = 9;
            this.aFanGauge.ScaleLinesMinorWidth = 1;
            this.aFanGauge.ScaleNumbersColor = System.Drawing.Color.Black;
            this.aFanGauge.ScaleNumbersFormat = null;
            this.aFanGauge.ScaleNumbersRadius = 80;
            this.aFanGauge.ScaleNumbersRotation = 0;
            this.aFanGauge.ScaleNumbersStartScaleLine = 0;
            this.aFanGauge.ScaleNumbersStepScaleLines = 1;
            this.aFanGauge.Size = new System.Drawing.Size(250, 230);
            this.aFanGauge.TabIndex = 6;
            this.aFanGauge.TabStop = false;
            this.aFanGauge.Text = "aFanGauge";
            this.aFanGauge.Value = 0F;
            // 
            // aHeaterGauge
            // 
            this.aHeaterGauge.BackColor = System.Drawing.SystemColors.Control;
            this.aHeaterGauge.BaseArcColor = System.Drawing.Color.Gray;
            this.aHeaterGauge.BaseArcRadius = 60;
            this.aHeaterGauge.BaseArcStart = 135;
            this.aHeaterGauge.BaseArcSweep = 270;
            this.aHeaterGauge.BaseArcWidth = 2;
            this.aHeaterGauge.Center = new System.Drawing.Point(165, 115);
            this.aHeaterGauge.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            aGaugeRange4.Color = System.Drawing.Color.Red;
            aGaugeRange4.EndValue = 100F;
            aGaugeRange4.InnerRadius = 50;
            aGaugeRange4.InRange = false;
            aGaugeRange4.Name = "GaugeRange1";
            aGaugeRange4.OuterRadius = 60;
            aGaugeRange4.StartValue = 90F;
            this.aHeaterGauge.GaugeRanges.Add(aGaugeRange4);
            this.aHeaterGauge.Location = new System.Drawing.Point(281, 26);
            this.aHeaterGauge.MaxValue = 100F;
            this.aHeaterGauge.MinValue = 0F;
            this.aHeaterGauge.Name = "aHeaterGauge";
            this.aHeaterGauge.NeedleColor1 = System.Windows.Forms.AGaugeNeedleColor.Gray;
            this.aHeaterGauge.NeedleColor2 = System.Drawing.Color.DimGray;
            this.aHeaterGauge.NeedleRadius = 60;
            this.aHeaterGauge.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.aHeaterGauge.NeedleWidth = 2;
            this.aHeaterGauge.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.aHeaterGauge.ScaleLinesInterInnerRadius = 53;
            this.aHeaterGauge.ScaleLinesInterOuterRadius = 60;
            this.aHeaterGauge.ScaleLinesInterWidth = 1;
            this.aHeaterGauge.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.aHeaterGauge.ScaleLinesMajorInnerRadius = 50;
            this.aHeaterGauge.ScaleLinesMajorOuterRadius = 60;
            this.aHeaterGauge.ScaleLinesMajorStepValue = 10F;
            this.aHeaterGauge.ScaleLinesMajorWidth = 2;
            this.aHeaterGauge.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.aHeaterGauge.ScaleLinesMinorInnerRadius = 55;
            this.aHeaterGauge.ScaleLinesMinorOuterRadius = 60;
            this.aHeaterGauge.ScaleLinesMinorTicks = 9;
            this.aHeaterGauge.ScaleLinesMinorWidth = 1;
            this.aHeaterGauge.ScaleNumbersColor = System.Drawing.Color.Black;
            this.aHeaterGauge.ScaleNumbersFormat = null;
            this.aHeaterGauge.ScaleNumbersRadius = 75;
            this.aHeaterGauge.ScaleNumbersRotation = 0;
            this.aHeaterGauge.ScaleNumbersStartScaleLine = 2;
            this.aHeaterGauge.ScaleNumbersStepScaleLines = 1;
            this.aHeaterGauge.Size = new System.Drawing.Size(250, 230);
            this.aHeaterGauge.TabIndex = 7;
            this.aHeaterGauge.TabStop = false;
            this.aHeaterGauge.Text = "aFanGauge";
            this.aHeaterGauge.Value = 0F;
            // 
            // trackBar_HeaterPWM
            // 
            this.trackBar_HeaterPWM.LargeChange = 10;
            this.trackBar_HeaterPWM.Location = new System.Drawing.Point(341, 262);
            this.trackBar_HeaterPWM.Maximum = 255;
            this.trackBar_HeaterPWM.Name = "trackBar_HeaterPWM";
            this.trackBar_HeaterPWM.Size = new System.Drawing.Size(190, 69);
            this.trackBar_HeaterPWM.SmallChange = 5;
            this.trackBar_HeaterPWM.TabIndex = 7;
            this.trackBar_HeaterPWM.TickFrequency = 10;
            this.trackBar_HeaterPWM.ValueChanged += new System.EventHandler(this.trackBar_HeaterPWM_ValueChanged);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(558, 11);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(563, 461);
            this.txtLog.TabIndex = 8;
            this.txtLog.Text = "";
            // 
            // txtFldTemp2
            // 
            this.txtFldTemp2.BackColor = System.Drawing.SystemColors.Window;
            this.txtFldTemp2.Location = new System.Drawing.Point(20, 49);
            this.txtFldTemp2.Name = "txtFldTemp2";
            this.txtFldTemp2.ReadOnly = true;
            this.txtFldTemp2.Size = new System.Drawing.Size(64, 26);
            this.txtFldTemp2.TabIndex = 1;
            this.txtFldTemp2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFldTemp3
            // 
            this.txtFldTemp3.BackColor = System.Drawing.SystemColors.Window;
            this.txtFldTemp3.Location = new System.Drawing.Point(248, 49);
            this.txtFldTemp3.Name = "txtFldTemp3";
            this.txtFldTemp3.ReadOnly = true;
            this.txtFldTemp3.Size = new System.Drawing.Size(60, 26);
            this.txtFldTemp3.TabIndex = 3;
            this.txtFldTemp3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFldTemp1
            // 
            this.txtFldTemp1.BackColor = System.Drawing.Color.SkyBlue;
            this.txtFldTemp1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFldTemp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtFldTemp1.Location = new System.Drawing.Point(126, 49);
            this.txtFldTemp1.Name = "txtFldTemp1";
            this.txtFldTemp1.ReadOnly = true;
            this.txtFldTemp1.Size = new System.Drawing.Size(71, 25);
            this.txtFldTemp1.TabIndex = 2;
            this.txtFldTemp1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mirror temp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(214, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Secondary temp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Temp";
            // 
            // logRefreshTimer
            // 
            this.logRefreshTimer.Enabled = true;
            this.logRefreshTimer.Interval = 1500;
            this.logRefreshTimer.Tick += new System.EventHandler(this.logRefreshTimer_Tick);
            // 
            // timer_main
            // 
            this.timer_main.Interval = 5000;
            this.timer_main.Tick += new System.EventHandler(this.timer_main_Tick);
            // 
            // timer_debug_changetext
            // 
            this.timer_debug_changetext.Interval = 4400;
            this.timer_debug_changetext.Tick += new System.EventHandler(this.timer_debug_Tick);
            // 
            // timer_debug_portread
            // 
            this.timer_debug_portread.Tick += new System.EventHandler(this.timer_debug_portread_Tick);
            // 
            // btnSimulate
            // 
            this.btnSimulate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSimulate.Location = new System.Drawing.Point(1136, 271);
            this.btnSimulate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(109, 35);
            this.btnSimulate.TabIndex = 4;
            this.btnSimulate.Text = "Simulate";
            this.btnSimulate.UseVisualStyleBackColor = true;
            this.btnSimulate.Click += new System.EventHandler(this.btnSimulate_Click);
            // 
            // trackBar_FanPWM
            // 
            this.trackBar_FanPWM.LargeChange = 10;
            this.trackBar_FanPWM.Location = new System.Drawing.Point(66, 262);
            this.trackBar_FanPWM.Maximum = 255;
            this.trackBar_FanPWM.Name = "trackBar_FanPWM";
            this.trackBar_FanPWM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trackBar_FanPWM.RightToLeftLayout = true;
            this.trackBar_FanPWM.Size = new System.Drawing.Size(190, 69);
            this.trackBar_FanPWM.SmallChange = 5;
            this.trackBar_FanPWM.TabIndex = 3;
            this.trackBar_FanPWM.TickFrequency = 10;
            this.trackBar_FanPWM.ValueChanged += new System.EventHandler(this.trackBar_FanPWM_ValueChanged);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.Transparent;
            this.chart1.BorderlineColor = System.Drawing.Color.LightGray;
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 7;
            chartArea1.AxisX.LabelAutoFitMinFontSize = 7;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            chartArea1.AxisX.LabelStyle.Interval = 1D;
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea1.AxisX.MajorGrid.Interval = 1D;
            chartArea1.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MajorTickMark.Interval = 1D;
            chartArea1.AxisX.MajorTickMark.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.DarkRed;
            chartArea1.AxisX.MaximumAutoSize = 7F;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisX.MinorTickMark.LineColor = System.Drawing.Color.Yellow;
            chartArea1.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 7;
            chartArea1.AxisY.LabelAutoFitMinFontSize = 7;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorTickMark.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            stripLine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            stripLine1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            stripLine1.BackSecondaryColor = System.Drawing.Color.White;
            stripLine1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            stripLine1.IntervalOffset = 0.2D;
            stripLine1.StripWidth = 1.8D;
            stripLine2.BorderColor = System.Drawing.Color.Silver;
            stripLine3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            stripLine3.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            stripLine3.BackSecondaryColor = System.Drawing.SystemColors.Highlight;
            stripLine3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            stripLine3.IntervalOffset = -10D;
            stripLine3.StripWidth = 10.1D;
            chartArea1.AxisY.StripLines.Add(stripLine1);
            chartArea1.AxisY.StripLines.Add(stripLine2);
            chartArea1.AxisY.StripLines.Add(stripLine3);
            chartArea1.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea1.AxisY2.LabelAutoFitMaxFontSize = 7;
            chartArea1.AxisY2.LabelAutoFitMinFontSize = 7;
            chartArea1.AxisY2.MajorGrid.Enabled = false;
            chartArea1.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.Silver;
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 95F;
            chartArea1.InnerPlotPosition.Width = 92F;
            chartArea1.InnerPlotPosition.X = 4F;
            chartArea1.Name = "ChartArea1_main";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 30F;
            chartArea1.Position.Width = 100F;
            chartArea1.Position.Y = 3F;
            chartArea2.AlignWithChartArea = "ChartArea1_main";
            chartArea2.AxisX.LabelAutoFitMaxFontSize = 7;
            chartArea2.AxisX.LabelAutoFitMinFontSize = 7;
            chartArea2.AxisX.MajorGrid.Interval = 1D;
            chartArea2.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.MinorGrid.Enabled = true;
            chartArea2.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisY.LabelAutoFitMaxFontSize = 7;
            chartArea2.AxisY.LabelAutoFitMinFontSize = 7;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea2.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Silver;
            stripLine4.BackColor = System.Drawing.Color.White;
            stripLine4.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            stripLine4.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            stripLine4.StripWidth = 2D;
            stripLine5.BorderColor = System.Drawing.Color.Gray;
            stripLine6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            stripLine6.IntervalOffset = -2D;
            stripLine6.StripWidth = 2D;
            chartArea2.AxisY.StripLines.Add(stripLine4);
            chartArea2.AxisY.StripLines.Add(stripLine5);
            chartArea2.AxisY.StripLines.Add(stripLine6);
            chartArea2.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisY2.LabelAutoFitMaxFontSize = 7;
            chartArea2.AxisY2.LabelAutoFitMinFontSize = 7;
            chartArea2.AxisY2.MajorGrid.Enabled = false;
            chartArea2.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.BorderColor = System.Drawing.Color.Silver;
            chartArea2.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.InnerPlotPosition.Auto = false;
            chartArea2.InnerPlotPosition.Height = 100F;
            chartArea2.InnerPlotPosition.Width = 92F;
            chartArea2.InnerPlotPosition.X = 4F;
            chartArea2.Name = "ChartArea2_secondary";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 30F;
            chartArea2.Position.Width = 100F;
            chartArea2.Position.Y = 37F;
            chartArea3.AlignWithChartArea = "ChartArea1_main";
            chartArea3.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea3.AxisX.LabelAutoFitMaxFontSize = 7;
            chartArea3.AxisX.LabelAutoFitMinFontSize = 7;
            chartArea3.AxisX.MajorGrid.Interval = 1D;
            chartArea3.AxisX.MajorGrid.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Hours;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea3.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisX.MinorGrid.Enabled = true;
            chartArea3.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisX.MinorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea3.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea3.AxisY.Crossing = -1.7976931348623157E+308D;
            chartArea3.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea3.AxisY.LabelAutoFitMaxFontSize = 7;
            chartArea3.AxisY.LabelAutoFitMinFontSize = 7;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea3.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea3.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea3.AxisY2.LabelAutoFitMaxFontSize = 7;
            chartArea3.AxisY2.LabelAutoFitMinFontSize = 7;
            chartArea3.AxisY2.MajorGrid.Enabled = false;
            chartArea3.AxisY2.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            chartArea3.AxisY2.MajorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea3.BackColor = System.Drawing.Color.White;
            chartArea3.BorderColor = System.Drawing.Color.Silver;
            chartArea3.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea3.InnerPlotPosition.Auto = false;
            chartArea3.InnerPlotPosition.Height = 100F;
            chartArea3.InnerPlotPosition.Width = 92F;
            chartArea3.InnerPlotPosition.X = 4F;
            chartArea3.Name = "ChartArea3_temp";
            chartArea3.Position.Auto = false;
            chartArea3.Position.Height = 30F;
            chartArea3.Position.Width = 100F;
            chartArea3.Position.Y = 69F;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Location = new System.Drawing.Point(10, 477);
            this.chart1.Margin = new System.Windows.Forms.Padding(0);
            this.chart1.Name = "chart1";
            series1.BorderColor = System.Drawing.SystemColors.HotTrack;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1_main";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Color = System.Drawing.SystemColors.HotTrack;
            series1.Name = "Temp_main_delta";
            series2.ChartArea = "ChartArea1_main";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            series2.Name = "RPM";
            series2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series2.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea2_secondary";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Color = System.Drawing.Color.Red;
            series3.Name = "Temp_sec_delta";
            series4.ChartArea = "ChartArea2_secondary";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series4.Color = System.Drawing.Color.Green;
            series4.Name = "Heater";
            series4.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series5.BorderWidth = 3;
            series5.ChartArea = "ChartArea3_temp";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series5.Name = "Temp_ext";
            series5.ShadowOffset = 2;
            series5.ToolTip = "Temp1 (#VAL{F1} at #VALX{dd.MM.yyyy HH:mm})\\nlast value: #LAST{F1} \\nmin:#MIN{F1}" +
    " max:#MAX{F1} avg:#AVG{F1}\\n";
            series6.ChartArea = "ChartArea3_temp";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series6.Color = System.Drawing.Color.Blue;
            series6.Name = "Temp_main";
            series6.ToolTip = "Temp2 #VAL{F1} (at #VALX{dd.MM.yyyy HH:mm})\\nlast value: #LAST{F1} \\nmin:#MIN{F1}" +
    " max:#MAX{F1} avg:#AVG{F1}\\n";
            series7.ChartArea = "ChartArea3_temp";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series7.Color = System.Drawing.Color.Red;
            series7.Name = "Temp_sec";
            series7.ToolTip = "Temp3 (#VAL{F1} at #VALX{dd.MM.yyyy HH:mm})\\nlast value: #LAST{F1} \\nmin:#MIN{F1}" +
    " max:#MAX{F1} avg:#AVG{F1}\\n";
            series8.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            series8.ChartArea = "ChartArea3_temp";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series8.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            series8.Name = "Humidity";
            series8.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series9.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            series9.ChartArea = "ChartArea3_temp";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series9.Color = System.Drawing.Color.Aqua;
            series9.Name = "Dew_point";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Series.Add(series9);
            this.chart1.Size = new System.Drawing.Size(1238, 490);
            this.chart1.TabIndex = 25;
            this.chart1.TabStop = false;
            this.chart1.Text = "Sensors data";
            title1.DockedToChartArea = "ChartArea1_main";
            title1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title1.ForeColor = System.Drawing.Color.LightGray;
            title1.Name = "Main";
            title1.Text = "Main mirror";
            title2.DockedToChartArea = "ChartArea2_secondary";
            title2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title2.ForeColor = System.Drawing.Color.LightGray;
            title2.Name = "Secondary";
            title2.Text = "Secondary mirror";
            title3.DockedToChartArea = "ChartArea3_temp";
            title3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title3.ForeColor = System.Drawing.Color.LightGray;
            title3.Name = "Temp";
            title3.Text = "Temperature";
            this.chart1.Titles.Add(title1);
            this.chart1.Titles.Add(title2);
            this.chart1.Titles.Add(title3);
            // 
            // txtControlFanPWM
            // 
            this.txtControlFanPWM.BackColor = System.Drawing.SystemColors.Window;
            this.txtControlFanPWM.Location = new System.Drawing.Point(6, 262);
            this.txtControlFanPWM.Name = "txtControlFanPWM";
            this.txtControlFanPWM.Size = new System.Drawing.Size(43, 26);
            this.txtControlFanPWM.TabIndex = 2;
            this.txtControlFanPWM.TextChanged += new System.EventHandler(this.txtControlFanPWM_TextChanged);
            // 
            // txtControlHeaterPWM
            // 
            this.txtControlHeaterPWM.BackColor = System.Drawing.SystemColors.Window;
            this.txtControlHeaterPWM.Location = new System.Drawing.Point(281, 262);
            this.txtControlHeaterPWM.Name = "txtControlHeaterPWM";
            this.txtControlHeaterPWM.Size = new System.Drawing.Size(43, 26);
            this.txtControlHeaterPWM.TabIndex = 6;
            this.txtControlHeaterPWM.TextChanged += new System.EventHandler(this.txtControlHeaterPWM_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFldDTemp);
            this.groupBox1.Controls.Add(this.txtDewPoint);
            this.groupBox1.Controls.Add(this.txtFldTemp1);
            this.groupBox1.Controls.Add(this.txtFldHumidity);
            this.groupBox1.Controls.Add(this.txtFldTemp3);
            this.groupBox1.Controls.Add(this.txtSecondaryDelta);
            this.groupBox1.Controls.Add(this.txtMainDelta);
            this.groupBox1.Controls.Add(this.txtFldTemp2);
            this.groupBox1.Location = new System.Drawing.Point(10, 348);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 126);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Temperature";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Sec D";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Main D";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(371, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Temp DHT";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(371, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 20);
            this.label10.TabIndex = 7;
            this.label10.Text = "Dew Point";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(371, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Humidity";
            // 
            // txtFldDTemp
            // 
            this.txtFldDTemp.BackColor = System.Drawing.SystemColors.Window;
            this.txtFldDTemp.Location = new System.Drawing.Point(463, 21);
            this.txtFldDTemp.Name = "txtFldDTemp";
            this.txtFldDTemp.ReadOnly = true;
            this.txtFldDTemp.Size = new System.Drawing.Size(60, 26);
            this.txtFldDTemp.TabIndex = 6;
            // 
            // txtDewPoint
            // 
            this.txtDewPoint.BackColor = System.Drawing.SystemColors.Window;
            this.txtDewPoint.Location = new System.Drawing.Point(463, 85);
            this.txtDewPoint.Name = "txtDewPoint";
            this.txtDewPoint.ReadOnly = true;
            this.txtDewPoint.Size = new System.Drawing.Size(60, 26);
            this.txtDewPoint.TabIndex = 8;
            // 
            // txtFldHumidity
            // 
            this.txtFldHumidity.BackColor = System.Drawing.SystemColors.Window;
            this.txtFldHumidity.Location = new System.Drawing.Point(463, 53);
            this.txtFldHumidity.Name = "txtFldHumidity";
            this.txtFldHumidity.ReadOnly = true;
            this.txtFldHumidity.Size = new System.Drawing.Size(60, 26);
            this.txtFldHumidity.TabIndex = 7;
            // 
            // txtSecondaryDelta
            // 
            this.txtSecondaryDelta.BackColor = System.Drawing.Color.LightYellow;
            this.txtSecondaryDelta.Location = new System.Drawing.Point(192, 85);
            this.txtSecondaryDelta.Name = "txtSecondaryDelta";
            this.txtSecondaryDelta.ReadOnly = true;
            this.txtSecondaryDelta.Size = new System.Drawing.Size(64, 26);
            this.txtSecondaryDelta.TabIndex = 5;
            this.txtSecondaryDelta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMainDelta
            // 
            this.txtMainDelta.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtMainDelta.Location = new System.Drawing.Point(68, 85);
            this.txtMainDelta.Name = "txtMainDelta";
            this.txtMainDelta.ReadOnly = true;
            this.txtMainDelta.Size = new System.Drawing.Size(64, 26);
            this.txtMainDelta.TabIndex = 4;
            this.txtMainDelta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbGauge
            // 
            this.gbGauge.Controls.Add(this.chkAutoHeatingControlling);
            this.gbGauge.Controls.Add(this.chkAutoFanControlling);
            this.gbGauge.Controls.Add(this.txtFldHeaterPWM);
            this.gbGauge.Controls.Add(this.label9);
            this.gbGauge.Controls.Add(this.label8);
            this.gbGauge.Controls.Add(this.txtControlHeaterPWM);
            this.gbGauge.Controls.Add(this.txtFldRPM);
            this.gbGauge.Controls.Add(this.txtControlFanPWM);
            this.gbGauge.Controls.Add(this.trackBar_HeaterPWM);
            this.gbGauge.Controls.Add(this.aHeaterGauge);
            this.gbGauge.Controls.Add(this.aFanGauge);
            this.gbGauge.Controls.Add(this.trackBar_FanPWM);
            this.gbGauge.Location = new System.Drawing.Point(10, 2);
            this.gbGauge.Name = "gbGauge";
            this.gbGauge.Size = new System.Drawing.Size(542, 340);
            this.gbGauge.TabIndex = 6;
            this.gbGauge.TabStop = false;
            // 
            // chkAutoHeatingControlling
            // 
            this.chkAutoHeatingControlling.AutoSize = true;
            this.chkAutoHeatingControlling.Location = new System.Drawing.Point(281, 296);
            this.chkAutoHeatingControlling.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkAutoHeatingControlling.Name = "chkAutoHeatingControlling";
            this.chkAutoHeatingControlling.Size = new System.Drawing.Size(120, 24);
            this.chkAutoHeatingControlling.TabIndex = 8;
            this.chkAutoHeatingControlling.Text = "Autocontroll";
            this.chkAutoHeatingControlling.UseVisualStyleBackColor = true;
            this.chkAutoHeatingControlling.CheckedChanged += new System.EventHandler(this.chkAutoHeatingControlling_CheckedChanged);
            // 
            // chkAutoFanControlling
            // 
            this.chkAutoFanControlling.AutoSize = true;
            this.chkAutoFanControlling.Location = new System.Drawing.Point(6, 296);
            this.chkAutoFanControlling.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkAutoFanControlling.Name = "chkAutoFanControlling";
            this.chkAutoFanControlling.Size = new System.Drawing.Size(120, 24);
            this.chkAutoFanControlling.TabIndex = 4;
            this.chkAutoFanControlling.Text = "Autocontroll";
            this.chkAutoFanControlling.UseVisualStyleBackColor = true;
            this.chkAutoFanControlling.CheckedChanged += new System.EventHandler(this.chkAutoFanControlling_CheckedChanged);
            // 
            // txtFldHeaterPWM
            // 
            this.txtFldHeaterPWM.BackColor = System.Drawing.SystemColors.Control;
            this.txtFldHeaterPWM.Location = new System.Drawing.Point(379, 220);
            this.txtFldHeaterPWM.Name = "txtFldHeaterPWM";
            this.txtFldHeaterPWM.ReadOnly = true;
            this.txtFldHeaterPWM.Size = new System.Drawing.Size(55, 26);
            this.txtFldHeaterPWM.TabIndex = 5;
            this.txtFldHeaterPWM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(197, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Main mirror fan speed, rpm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(282, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(248, 20);
            this.label8.TabIndex = 27;
            this.label8.Text = "Secondary mirror heater power, %";
            // 
            // txtFldRPM
            // 
            this.txtFldRPM.BackColor = System.Drawing.SystemColors.Control;
            this.txtFldRPM.Location = new System.Drawing.Point(104, 220);
            this.txtFldRPM.Name = "txtFldRPM";
            this.txtFldRPM.ReadOnly = true;
            this.txtFldRPM.Size = new System.Drawing.Size(55, 26);
            this.txtFldRPM.TabIndex = 1;
            this.txtFldRPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnOnOff
            // 
            this.btnOnOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOnOff.Location = new System.Drawing.Point(1136, 69);
            this.btnOnOff.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOnOff.Name = "btnOnOff";
            this.btnOnOff.Size = new System.Drawing.Size(109, 35);
            this.btnOnOff.TabIndex = 1;
            this.btnOnOff.Text = "On";
            this.toolTip1.SetToolTip(this.btnOnOff, "Autocontorl on/off");
            this.btnOnOff.UseVisualStyleBackColor = true;
            this.btnOnOff.Click += new System.EventHandler(this.btnOnOff_Click);
            // 
            // backgroundWorker_SocketServer
            // 
            this.backgroundWorker_SocketServer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_SocketServer_DoWork);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1258, 969);
            this.Controls.Add(this.gbGauge);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnSimulate);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnOnOff);
            this.Controls.Add(this.btnStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1280, 1024);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Telescope Temp Control";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_HeaterPWM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_FanPWM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbGauge.ResumeLayout(false);
            this.gbGauge.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.AGauge aFanGauge;
        private System.Windows.Forms.AGauge aHeaterGauge;
        private System.Windows.Forms.TrackBar trackBar_HeaterPWM;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.TextBox txtFldTemp2;
        private System.Windows.Forms.TextBox txtFldTemp3;
        private System.Windows.Forms.TextBox txtFldTemp1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer logRefreshTimer;
        private System.IO.Ports.SerialPort serialPort1;
        internal System.Windows.Forms.Timer timer_main;
        public System.Windows.Forms.Timer timer_debug_changetext;
        private System.Windows.Forms.Timer timer_debug_portread;
        private System.Windows.Forms.Button btnSimulate;
        private System.Windows.Forms.TrackBar trackBar_FanPWM;
        internal System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox txtControlFanPWM;
        private System.Windows.Forms.TextBox txtControlHeaterPWM;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSecondaryDelta;
        private System.Windows.Forms.TextBox txtMainDelta;
        private System.Windows.Forms.GroupBox gbGauge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFldHumidity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFldDTemp;
        private System.Windows.Forms.TextBox txtFldRPM;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtFldHeaterPWM;
        private System.Windows.Forms.CheckBox chkAutoFanControlling;
        private System.Windows.Forms.CheckBox chkAutoHeatingControlling;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDewPoint;
        private System.Windows.Forms.Button btnOnOff;
        private System.ComponentModel.BackgroundWorker backgroundWorker_SocketServer;
    }
}

