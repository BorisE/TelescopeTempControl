using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TelescopeTempControl
{
    public partial class MainForm : Form
    {

        public Hardware Hardware;
        public AboutBox AboutForm;
        public SettingsForm SettingsObj;
        public LogForm LogFormObj;

        public bool SimulationMode;


        private bool bReadFanPWMValue = false;
        private bool bReadHeaterPWMValue = false;

        /// <summary>
        /// Socket server
        /// </summary>
        public SocketServerClass SocketServer;


        //For graphs
        private DateTime curX;
        public int maxNumberOfPointsInChart = 8640; //For 24h with 10sec interval
        public int MAX_LOG_LENGTH = 10000;

        /// <summary>
        /// Construction
        /// </summary>
        public MainForm()
        {
            Hardware = new Hardware(this);
            VersionData.initVersionData();
            AboutForm = new AboutBox();
            SettingsObj = new SettingsForm(this);
            LogFormObj = new LogForm(this);

            //Create SocketServer obj (even if it wouldn't run)
            SocketServer = new SocketServerClass(this);
            //Give a link to it for Harware class
            Hardware.SocketServer = SocketServer;

            //Sync consntans 
            SocketServer.MAX_BUFFER_LEN = Hardware.MAX_BUFFER_LEN;

            InitializeComponent();
        }

        /// <summary>
        /// Form load event
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            SettingsObj.LoadParams();
            Logging.AddLog("Settings were loaded", LogLevel.Activity);

            //Init power control values
            txtControlFanPWM.Text = Convert.ToString(Hardware.FanPWM);
            txtControlHeaterPWM.Text = Convert.ToString(Hardware.HeaterPWM);

            //Gauge tunning

            int W = gbGauge.Width;
            int H = gbGauge.Height;
            int FG_W = aFanGauge.Width;
            int FG_H = aFanGauge.Height;
            aFanGauge.Center = new Point((int)FG_W / 2, (int)FG_H / 2);

            int HG_W = aHeaterGauge.Width;
            int HG_H = aHeaterGauge.Height;
            aHeaterGauge.Center = new Point((int)HG_W / 2, (int)HG_H / 2);


            //chart tunning
            //chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Hours;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "HH:ii";
            chart1.ChartAreas[0].AxisX.MajorTickMark.IntervalType = DateTimeIntervalType.Hours;
            chart1.ChartAreas[0].AxisX.MinorTickMark.Interval = 1;
            chart1.ChartAreas[0].AxisX.MinorTickMark.IntervalType = DateTimeIntervalType.Minutes;
            chart1.ChartAreas[0].AxisX.MinorTickMark.Interval = 1;

            //Start tcp server
            if (bRunSocketServerFlag)
            {
                RunSocketServer();
            }


            // TEST Usual command LINE PARAMETERS
            bool autostart = false;
            string comport_over = string.Empty;
            AuxilaryProc.CheckStartParams(out autostart, out comport_over);

            //RESET COM PORT NAME
            if (!string.IsNullOrEmpty(comport_over))
            {
                Hardware.PortName = comport_over;
                Logging.AddLog("Override serial port name to [" + comport_over + "]", LogLevel.Activity, Highlight.Emphasize);
            }

            //AUTOSTART MONITORING
            if (autostart)
            {
                Logging.AddLog("Program autostart", LogLevel.Activity, Highlight.Emphasize);
                btnStart.PerformClick();
            }

        }

        public void RunSocketServer(Int32 PortNumber = 0)
        {
            StopSocketServer(); //try to stop if it was running
            backgroundWorker_SocketServer.RunWorkerAsync();
        }

        /// <summary>
        /// Actualy not working - need to implement Worker.CancellationPending, but it to complex cause also includes client threads management
        /// </summary>
        public void StopSocketServer()
        {
            if (backgroundWorker_SocketServer.IsBusy)
            //Stop if run before
            {
                backgroundWorker_SocketServer.CancelAsync();
            }
        }


        private void backgroundWorker_SocketServer_DoWork(object sender, DoWorkEventArgs e)
        {
            SocketServer.StartListenSocket();
        }


        #region Buttons handlers

        /// <summary>
        /// Start monitoring
        /// </summary>
        private void btnStart_Click(object sender, EventArgs e)
        {
            // If the port is open, close it.
            if ((Hardware.UseSocketRead && timer_main.Enabled) || (!Hardware.UseSocketRead && Hardware.IsOpened()))
            {
                if (!Hardware.stopReadData())
                {
                    Logging.AddLog("Could not close the COM port [" + Hardware.PortName + "]", LogLevel.Critical, Highlight.Error);
                    //LogForm.txtLog.AppendText("Could not close the COM port [" + Hardware.PortName + "]");
                    MessageBox.Show(this, "Could not close the COM port [" + Hardware.PortName + "]", "COM Port couldn't be closed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    //btnStart.Text = LocRM.GetString("Start");
                    timer_main.Enabled = false;
                    btnStart.Text = "Start";
                    Logging.AddLog("Monitoring on [" + Hardware.PortName + "] was stopped",LogLevel.Activity);
                    //LogForm.txtLog.AppendText("Monitoring on [" + Hardware.PortName + "] was stopped");
                    //Logging.CloseLogFile();
                }
            }
            else
            {
                if (!Hardware.startReadData())
                {
                    Logging.AddLog("Could not open the COM port [" + Hardware.PortName + "].  Most likely it is already in use, has been removed, or is unavailable.", LogLevel.Critical, Highlight.Error);
                    //LogForm.txtLog.AppendText("Could not open the COM port [" + Hardware.PortName + "].  Most likely it is already in use, has been removed, or is unavailable.");
                    MessageBox.Show(this, "Could not open the COM port [" + Hardware.PortName + "].  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    timer_main.Enabled = true;
                    Logging.AddLog("Monitoring on [" + Hardware.PortName + "] was started",LogLevel.Activity);
                    //LogForm.AppendLogText("Monitoring on [" + Hardware.PortName + "] was started");
                    //btnStart.Text = LocRM.GetString("Stop");
                    btnStart.Text = "Stop";

                }

            }
        }


        /// <summary>
        /// Monitoring Simulation start
        /// Starts two timer ticks:
        /// 1. Simulation of asynchroneous serial data read to buffer:
        ///     - first by timer_debug_changetext tick form BUFFER TEXT in SerialBufferFullSim
        ///     - then start fast timer_debug_portread tick, which emulates arbitrary number of incomingBuffer read to Serail Buffer
        /// 2. Working (as in case of productive cycle) with data from Serial Buffer
        /// </summary>
        private void btnSimulate_Click(object sender, EventArgs e)
        {
            if (timer_debug_changetext.Enabled)
            {
                //btnSimulate.Text = LocRM.GetString("SimulationStart");
                btnSimulate.Text = "Simulation Start";

                btnStart.Enabled = true;
                timer_main.Enabled = false;
                timer_debug_changetext.Enabled = false;
                timer_debug_portread.Enabled = false;
                SimulationMode = false;
                Hardware.UseSimulation = false;
                Logging.AddLog("Monitoring simulation was stopped",LogLevel.Activity);
            }
            else
            {
                timer_main.Enabled = true;
                timer_debug_changetext.Enabled = true;
                //timer_debug_portread.Enabled = true; //this timer is started by timer_debug_changetext tick
                Logging.AddLog("Monitoring simulation was started", LogLevel.Activity);
                SimulationMode = true;
                Hardware.UseSimulation = true;
                //btnSimulate.Text = LocRM.GetString("SimulationStop"); 
                btnSimulate.Text = "Simulation Stop"; 
                btnStart.Enabled = false;

            }
        }


        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutForm = new AboutBox();
            AboutForm.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsObj.ShowDialog();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            LogFormObj.Show();
            LogFormObj.BringToFront();
        }

#endregion Button handlers

#region Timer Ticks ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Timer to work with log information (save it, display, etc)
        /// </summary>
        private void logRefreshTimer_Tick(object sender, EventArgs e)
        {
            //add line to richtextbox
            Logging.AppendText(txtLog);

            //write to file
            Logging.DumpToFile();

        }
        
       
        /// <summary>
        /// Timer ticking - used to make all data manupalation and visualization at given interval
        /// </summary>
        private void timer_main_Tick(object sender, EventArgs e)
        {
            Logging.AddLog("Main working tick started", LogLevel.Trace);

            //Check if data receiving (whatchdog)
            if (Hardware.WatchDog && !SimulationMode) Hardware.CheckIfDataReceiving();

            //Get current buffer for logging
            string curSerialBuffer = "";

            //Parse data and make all calculation
            Hardware.LOOP_CYCLE(out curSerialBuffer);


            //Write CSV Data file
            /*            if (Properties.Settings.Default.CSVFileFlag)
                        {
                            Hardware.WriteCSV();
                      }
              */
            //output buffer to Log window
            LogFormObj.AppendLogText(curSerialBuffer);

            //Refresh form values
            RefreshFormFields2();

            //Refresh graph
            refreshGraphs();

            //Send data to web
            //SendDataToWeb2();

            Logging.AddLog("Main working tick ended", LogLevel.Trace);
        }

        /// <summary>
        /// Sumulation timer 1 - it genereates contents which is later read in portions in timer 2
        /// </summary>
        private void timer_debug_Tick(object sender, EventArgs e)
        {

            Random rand = new Random(DateTime.Now.Millisecond);

            ArduinoSettingsClass El = new ArduinoSettingsClass();

            string ArdSetTD = (Hardware.ArduinoSettings.TryGetValue("TD", out El) ? El.Value : "30");
            string ArdSetWT = (Hardware.ArduinoSettings.TryGetValue("WT", out El) ? El.Value : "1005");
            string ArdSetRT = (Hardware.ArduinoSettings.TryGetValue("RT", out El) ? El.Value : "300");


            int rpm = Convert.ToInt32(-0.011 * Hardware.FanPWM * Hardware.FanPWM - 2.3255 * Hardware.FanPWM + 1274.2+rand.Next(0,10));
            if (rpm < 150) rpm = 0;
            if (rpm > 1290) rpm = 1290;

            int heater = Hardware.HeaterPWM;

            Hardware.SerialBufferFullSim = @"Fan/Heater control v0.2sim
[!ver:0.2sim]
[!ved:08082015]
=== New cycle ===
[!!be:1]
Fan rotation: " + String.Format("{0:D0}", rpm) + @" rpm,    val:44
Fan PWM value: " + String.Format("{0:D0}", Hardware.FanPWM) + @"
[!RPM:" + String.Format("{0:D0}", rpm) + @"]
[!Pwm:" + String.Format("{0:D0}", Hardware.FanPWM) + @"]

Humidity: 49.50 %	
Temperature: 16.90 C  
Dew point: 6.28 /fast: 6.26 *C
[!DT1:" + String.Format("{0:N1}", 22.5 + rand.NextDouble() * 5) + @"]
[!DH1:" + String.Format("{0:N0}", 30 + rand.NextDouble() * 60) + @"]

External t: 17.06C Main mirror t: 17.19C Secondary mirror t: 17.31C 
[!Te1:" + String.Format("{0:N1}", 23.0 + rand.NextDouble() * 5) + @"]
[!Te2:" + String.Format("{0:N1}", 25.0 + rand.NextDouble() * 10) + @"]
[!Te3:" + String.Format("{0:N1}", 27.0 + rand.NextDouble() * 10) + @"]

Current HEATER PWM value: " + String.Format("{0:N0}", heater) + @"
[!Ht:" + String.Format("{0:N0}", heater) + @"]
[!!r:4507]
";
      
/*            
=== New cycle ===
[!!be:1]
Fan approx_rotation: 0 rpm,    raw cnt:0
Fan PWM value: 255
[!RPM:0]
[!Pwm:255]

Humidity: 59.20 %	
Temperature: 19.10 C  
Dew point: 10.97 /fast: 10.95 *C
[!DT1:19.1]
[!DH1:59.2]


12:53:48 06.09.15: External t: 19.56C Main mirror t: 18.31C Secondary mirror t: 18.94C 
[!Te1:19.6]
[!Te2:18.3]
[!Te3:18.9]

Current HEATER PWM value: 36
[!Ht:36]
[!!r:4545]
*/            
            
            
            Logging.AddLog("Simulated text created", LogLevel.Debug);
            Hardware.simBufferReadPos = 0;
            timer_debug_portread.Enabled = true; //starts read in portions timer ticks
        }

        /// <summary>
        /// Sumulation timer 2 - it simulates reading data from serial in arbitrary portions into Serial Buffer
        /// </summary>
        private void timer_debug_portread_Tick(object sender, EventArgs e)
        {
            if (Hardware.port_DataReceived_simulated())
            {
                timer_debug_portread.Enabled = false;
                Logging.AddLog("Simulated text parsed", LogLevel.Debug);
            }
        }
#endregion Timer Ticks ///////////////////////////////////////

    
        /// <summary>
        /// Refresh form fields
        /// </summary>
        private void RefreshFormFields2()
        {
            Logging.AddLog("Main.RefreshFormFields2 enter", LogLevel.Trace);

            //Include all sensor that needed to display
            int SensIdx = -1;
            foreach (SensorElement DataSensor in Hardware.SensorsList.Values)
            {
                SensIdx++;
                if (DataSensor != null)
                {
                    if (DataSensor.Enabled && DataSensor.SensorFormField != "")
                    {
                        try
                        {
                            TextBox SensVal = this.Controls.Find(DataSensor.SensorFormField, true)[0] as TextBox;
                            SensVal.Text = Convert.ToString(DataSensor.LastValue);
                        }
                        catch { }
                    }
                }
            }

            //FAN Gauge
            aFanGauge.Value = (float)Hardware.SensorsList["RPM"].LastValue;
            //HEATER Gauge
            aHeaterGauge.Value = (float)Hardware.HeaterPower;
            //Heater power instead of pwm value
            txtFldHeaterPWM.Text = Convert.ToString(Math.Round(Hardware.HeaterPower));
            
            //If still current fanpwm value wasn't read, try to read
            if (!bReadFanPWMValue || Hardware.AutoControl_FanSpeed)
            {
                if (Hardware.SensorsList["FPWM"].CheckLastValue())
                {
                    bAutomaticFanPWMChange = true; //temporary disable resending command to serial (will be autoreseted)
                    txtControlFanPWM.Text = Convert.ToString(Hardware.SensorsList["FPWM"].LastValue);
                    bReadFanPWMValue = true;
                }
            }
            
            //If still current fanpwm value wasn't read, try to read
            if (!bReadHeaterPWMValue || Hardware.AutoControl_Heater)
            {
                if (Hardware.SensorsList["Heater"].CheckLastValue())
                {
                    bAutomaticHeaterPWMChange = true; //temporary disable resending command to serial (will be autoreseted)
                    txtControlHeaterPWM.Text = Convert.ToString(Math.Round(Hardware.SensorsList["Heater"].LastValue));
                    bReadHeaterPWMValue = true;
                }
            }

            //Calculated fields (custom fields)
            txtMainDelta.Text = (Hardware.DeltaTemp_Main>=0?"+":"") + Convert.ToString(Math.Round(Hardware.DeltaTemp_Main,1));
            txtSecondaryDelta.Text = (Hardware.DeltaTemp_Secondary >= 0 ? "+" : "") + Convert.ToString(Math.Round(Hardware.DeltaTemp_Secondary, 1));

            txtDewPoint.Text = Convert.ToString(Math.Round(Hardware.DewPoint, 1));


            //Cloud index coloring
            /*
            Color CS_color = Color.Blue;
            string[] CS_Colors_arr = new String[9] {"#FF2200", "#DF2F20","#BF3C40", "#9F4860", "#805580", "#60629F", "#406FBF", "#207BDF", "#0088FF"};
            int CS_coloridx = 0;
            if (Hardware.CloudIdx > 20)
            {
                CS_coloridx=8;
            }
            else
            {
                CS_coloridx =  Convert.ToInt16(Math.Max(Math.Floor(Hardware.CloudIdx/3)+1,0));
            }
            CS_color = System.Drawing.ColorTranslator.FromHtml(CS_Colors_arr[CS_coloridx]);
            txtCloudIndex1.BackColor = CS_color;

*/
            Logging.AddLog("Main.RefreshFormFields2 exit", LogLevel.Trace);
        }

        /// <summary>
        /// Refresh graphical data, using data from SensorArray
        /// </summary>        
        private void refreshGraphs()
        {
            Logging.AddLog("Main.refreshGraphs enter", LogLevel.Trace);

            curX = DateTime.Now;
            //Graph1 (Main)
            if (Hardware.SensorsList["Temp1"].CheckLastValue() && Hardware.SensorsList["Temp2"].CheckLastValue())
            {
                addGraphicsPoint(chart1, "Temp_main_delta", curX, (Hardware.SensorsList["Temp2"].LastValue-Hardware.SensorsList["Temp1"].LastValue));
            }
            if (Hardware.SensorsList["RPM"].CheckLastValue())
            {
                addGraphicsPoint(chart1, "RPM", curX, Hardware.SensorsList["RPM"].LastValue);
            }

            //Graph2 (Secondary)
            if (Hardware.SensorsList["Temp1"].CheckLastValue() && Hardware.SensorsList["Temp3"].CheckLastValue())
            {
                addGraphicsPoint(chart1, "Temp_sec_delta", curX, (Hardware.SensorsList["Temp3"].LastValue - Hardware.SensorsList["Temp1"].LastValue));
            }
            if (Hardware.SensorsList["Heater"].CheckLastValue())
            {
                addGraphicsPoint(chart1, "Heater", curX, Hardware.HeaterPower);
            }

            //Graph3
            
            if (Hardware.SensorsList["Temp1"].CheckLastValue())
            {
                addGraphicsPoint(chart1, "Temp_ext", curX, Hardware.SensorsList["Temp1"].LastValue); //value for 3rd chart area
            }

            if (Hardware.SensorsList["Temp2"].CheckLastValue())
            {
                addGraphicsPoint(chart1, "Temp_main", curX, Hardware.SensorsList["Temp2"].LastValue);
            }
            if (Hardware.SensorsList["Temp3"].CheckLastValue())
            {
                addGraphicsPoint(chart1, "Temp_sec", curX, Hardware.SensorsList["Temp3"].LastValue);
            }
            if (Hardware.CheckData(Hardware.DewPoint,SensorTypeEnum.Temp))
            {
                addGraphicsPoint(chart1, "Dew_point", curX, Hardware.DewPoint);
            }

            changeYScale(chart1, chart1.ChartAreas["ChartArea3_temp"]);

            if (Hardware.SensorsList["Hum1"].CheckLastValue())
            {
                addGraphicsPoint(chart1, "Humidity", curX, Hardware.SensorsList["Hum1"].LastValue);
            }
/*            if (Hardware.SensorsList["FPWM"].CheckLastValue())
            {
                addGraphicsPoint(chart1, "FPWM", curX, Hardware.SensorsList["FPWM"].LastValue);
            }
 */

            Logging.AddLog("Main.refreshGraphs exit", LogLevel.Trace);
        }


        /// <summary>
        /// Add graphics point overload method - Series Name instead of Series Num
        /// </summary>
        /// <param name="CurChart"></param>
        /// <param name="serName">Series name</param>
        /// <param name="XVal"></param>
        /// <param name="YVal"></param>
        private void addGraphicsPoint(Chart CurChart, string serName, DateTime XVal, double YVal)
        {
            //curX=DateTime.Now;
            CurChart.Series[serName].Points.AddXY(XVal, YVal);

            // Keep a constant number of points by removing them from the left
            if (CurChart.Series[serName].Points.Count > maxNumberOfPointsInChart)
            {
                // Remove data points on the left side
                while (CurChart.Series[serName].Points.Count > maxNumberOfPointsInChart)
                {
                    CurChart.Series[serName].Points.RemoveAt(0);
                }

                // Adjust X axis scale
                //CurChart.ChartAreas[0].AxisX.Minimum = curX - maxNumberOfPointsInChart;
                //CurChart.ChartAreas[0].AxisX.Maximum = CurChart.ChartAreas[0].AxisX.Minimum + maxNumberOfPointsInChart;
            }

            // Adjust Y & X axis scale
            CurChart.ResetAutoValues();

            // Invalidate chart
            CurChart.Invalidate();
        }

        /// <summary>
        /// Change min max scale of chart area
        /// </summary>
        /// <param name="chart"></param>
        private void changeYScale(Chart curChart, ChartArea curChartArea)
        {
            double max = double.MinValue;
            double min = double.MaxValue;

            for (int s = 0; s < curChart.Series.Count(); s++)
            {
                if (curChart.Series[s].ChartArea == curChartArea.Name && curChart.Series[s].YAxisType==AxisType.Primary)
                {
                    foreach (DataPoint dp in curChart.Series[s].Points)
                    {
                        min = Math.Min(min, dp.YValues[0]);
                        max = Math.Max(max, dp.YValues[0]);
                    }
                }
            }
            curChartArea.AxisY.Maximum = (max == double.MinValue? Double.NaN : Math.Ceiling(max));
            curChartArea.AxisY.Minimum = (min == double.MaxValue ? Double.NaN : Math.Floor(min)); 
            //curChartArea.AxisY.Maximum = (Math.Ceiling((max / 10)) * 10);
            //curChartArea.AxisY.Minimum = (Math.Floor((min / 10)) * 10);
        }

        bool bAutomaticFanPWMChange = true;
        bool bAutomaticHeaterPWMChange = true;
        System.Threading.Timer FanPWM_ValueChanged_TimerObj = null;
        System.Threading.Timer HeaterPWM_ValueChanged_TimerObj = null;
        int ReactionDelay = 500;

        public bool bRunSocketServerFlag = true;

        /// <summary>
        /// Handle changing trackBar FanPWM
        /// </summary>
        private void trackBar_FanPWM_ValueChanged(object sender, EventArgs e)
        {
            txtControlFanPWM.Text = trackBar_FanPWM.Value.ToString();

            //Что бы избежать запусков метода при автоматической корректировке, проверить - было ли это автоматическое изменение
            if (bAutomaticFanPWMChange==false)
            {
                //Если таймер ожидания уже запущен - отложить его!
                if (FanPWM_ValueChanged_TimerObj != null)
                {
                    FanPWM_ValueChanged_TimerObj.Change(ReactionDelay, Timeout.Infinite);
                }
                else
                {
                    //Если таймер ожидания еще не запущен - запустить!
                    FanPWM_ValueChanged_TimerObj = new System.Threading.Timer((obj) =>
                                {
                                    int valtoset = -1;
                                    this.Invoke(new MethodInvoker(() => valtoset = trackBar_FanPWM.Value)); //так как доступ к элементам формы может быть осуществлен только из UI thread
                                    Hardware.SetFanPWM(valtoset);

                                    //уничтожить объект, чтобы следующий таймер запустился
                                    FanPWM_ValueChanged_TimerObj.Dispose();
                                    FanPWM_ValueChanged_TimerObj = null;
                                },
                            null, ReactionDelay, Timeout.Infinite);

                }
            }
            else
            {
                //сбросить флаг автоматического изменения (чтобы проходили ручные)
                bAutomaticFanPWMChange = false;
            }

        }

        /// <summary>
        /// Handling manual setting FnaPWM in text field
        /// </summary>
        private void txtControlFanPWM_TextChanged(object sender, EventArgs e)
        {
            TextBox TxtBox = sender as TextBox;
            Int32 nCI=0;
            if (Int32.TryParse(TxtBox.Text, out nCI) && (nCI>=trackBar_FanPWM.Minimum) && (nCI<=trackBar_FanPWM.Maximum))
            {
                trackBar_FanPWM.Value = nCI;
            }
        }


        /// <summary>
        /// Handle changing trackBar HeaterPWM
        /// </summary>
        private void trackBar_HeaterPWM_ValueChanged(object sender, EventArgs e)
        {
            txtControlHeaterPWM.Text = trackBar_HeaterPWM.Value.ToString();

            //Что бы избежать запусков метода при автоматической корректировке, проверить - было ли это автоматическое изменение
            if (bAutomaticHeaterPWMChange == false)
            {

                //Если таймер ожидания уже запущен - отложить его!
                if (HeaterPWM_ValueChanged_TimerObj != null)
                {
                    HeaterPWM_ValueChanged_TimerObj.Change(ReactionDelay, Timeout.Infinite);
                }
                else
                {
                    //Если таймер ожидания еще не запущен - запустить!
                    HeaterPWM_ValueChanged_TimerObj = new System.Threading.Timer((obj) =>
                    {
                        int valtoset = -1;
                        this.Invoke(new MethodInvoker(() => valtoset = trackBar_HeaterPWM.Value)); //так как доступ к элементам формы может быть осуществлен только из UI thread

                        this.Invoke(new MethodInvoker(() => aHeaterGauge.Value = Convert.ToSByte(trackBar_HeaterPWM.Value / 255.0 * 100.0))); //так как доступ к элементам формы может быть осуществлен только из UI thread


                        Hardware.SetHeaterPWM(valtoset);

                        //уничтожить объект, чтобы следующий таймер запустился
                        HeaterPWM_ValueChanged_TimerObj.Dispose();
                        HeaterPWM_ValueChanged_TimerObj = null;
                    },
                            null, ReactionDelay, Timeout.Infinite);

                }
            }
            else
            {
                //сбросить флаг автоматического изменения (чтобы проходили ручные)
                bAutomaticHeaterPWMChange = false;
            }
        }

        /// <summary>
        /// Handling manual setting Heater PWM in text field
        /// </summary>
        private void txtControlHeaterPWM_TextChanged(object sender, EventArgs e)
        {
            TextBox TxtBox = sender as TextBox;
            Int16 nCI;
            if (Int16.TryParse(TxtBox.Text, out nCI) && (nCI >= trackBar_HeaterPWM.Minimum) && (nCI <= trackBar_HeaterPWM.Maximum))
            {
                trackBar_HeaterPWM.Value = nCI;
            }
        }


        private void chkAutoFanControlling_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox Chk = sender as CheckBox;

            if (Chk.Checked)
            {
                trackBar_FanPWM.Enabled = false;
                txtControlFanPWM.ReadOnly = true;
                txtControlFanPWM.BackColor = SystemColors.Control;
                Hardware.AutoControl_FanSpeed = true;
            }
            else
            {
                trackBar_FanPWM.Enabled = true;
                txtControlFanPWM.ReadOnly = false;
                txtControlFanPWM.BackColor = SystemColors.Window;
                Hardware.AutoControl_FanSpeed = false;
            }
        }

        private void chkAutoHeatingControlling_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox Chk = sender as CheckBox;

            if (Chk.Checked)
            {
                trackBar_HeaterPWM.Enabled = false;
                txtControlHeaterPWM.ReadOnly = true;
                txtControlHeaterPWM.BackColor = SystemColors.Control;
                Hardware.AutoControl_Heater = true;
            }
            else
            {
                trackBar_HeaterPWM.Enabled = true;
                txtControlHeaterPWM.ReadOnly = false;
                txtControlHeaterPWM.BackColor = SystemColors.Window;
                Hardware.AutoControl_Heater = false;
            }
        }

        private void btnOnOff_Click(object sender, EventArgs e)
        {
            Button curBtn = (Button)sender;
            if (curBtn.Text == "On")
            {
                //start

                //start if it was stoped
                if (btnStart.Text == "Start") btnStart_Click(btnStart, e);
                
                //if start was success (or already started...)
                if (btnStart.Text == "Stop")
                {
                    Hardware.AutoControl_FanSpeed = true;
                    chkAutoFanControlling.Checked = true;

                    Hardware.AutoControl_Heater = true;
                    chkAutoHeatingControlling.Checked = true;

                    curBtn.Text = "Off";
                }
            }
            else if (curBtn.Text == "Off")
            {
                //stop
                txtControlFanPWM.Text = "255";
                Hardware.AutoControl_FanSpeed = false;
                chkAutoFanControlling.Checked = false;

                txtControlHeaterPWM.Text = "0";
                Hardware.AutoControl_Heater = false;
                chkAutoHeatingControlling.Checked = false;

                curBtn.Text = "On";
            }
        }
    }
}
