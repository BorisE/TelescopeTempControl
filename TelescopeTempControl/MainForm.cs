﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //For graphs
        private DateTime curX;
        public int maxNumberOfPointsInChart = 8640; //For 24h with 10sec interval
        public int MAX_LOG_LENGTH = 10000;

        public MainForm()
        {
            Hardware = new Hardware(this);
            VersionData.initVersionData();
            AboutForm = new AboutBox();
            SettingsObj = new SettingsForm(this);
            LogFormObj = new LogForm(this);

            InitializeComponent();
        }




#region Button handlers

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
#endregion Button handlers

#region Timer Ticks ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Timer to work with log information (save it, display, etc)
        /// </summary>
        private void logRefreshTimer_Tick(object sender, EventArgs e)
        {
            //add line to richtextbox
            Logging.AppendText(txtLog, LogLevel.Trace);

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
[!RPM:" + String.Format("{0:D0}", rpm) + @"]
Fan PWM value: 0
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

            //Gauge
            aFanGauge.Value = (float)Hardware.SensorsList["RPM"].LastValue;
            txtFPWM.Text = Convert.ToString(Hardware.SensorsList["FPWM"].LastValue);

            aHeaterGauge.Value = (float)Hardware.SensorsList["Heater"].LastValue;
            txtHPWM.Text = Convert.ToString(Hardware.SensorsList["Heater"].LastValue); 
            

            //Calculated fields (custom fields)
            txtMainDelta.Text = Convert.ToString(Math.Round(Hardware.DeltaTemp_Main,1));
            txtSecondaryDelta.Text = Convert.ToString(Math.Round(Hardware.DeltaTemp_Secondary, 1));
            

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
                addGraphicsPoint(chart1, "Heater", curX, Hardware.SensorsList["Heater"].LastValue);
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

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void trackBar_FanPWM_ValueChanged(object sender, EventArgs e)
        {
            txtFPWM.Text = trackBar_FanPWM.Value.ToString();

            Hardware.FanPWM = trackBar_FanPWM.Value;
        }

        private void trackBar_HeaterPWM_ValueChanged(object sender, EventArgs e)
        {
            txtHPWM.Text = trackBar_HeaterPWM.Value.ToString();
            aHeaterGauge.Value = Convert.ToSByte(trackBar_HeaterPWM.Value / 255.0 * 100.0);
            txtFldHeaterPWM.Text = trackBar_HeaterPWM.Value.ToString();

            Hardware.HeaterPWM = trackBar_HeaterPWM.Value;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
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

   
    }
}
