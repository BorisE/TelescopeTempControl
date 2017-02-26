using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO.Ports;
using System.IO;

using System.Reflection;
using System.Diagnostics;

namespace TelescopeTempControl
{
    public partial class SettingsForm : Form
    {
        private MainForm ParentMainForm;
        
        
        public SettingsForm(MainForm MF)
        {
            ParentMainForm = MF;
            
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            Logging.AddLog("Settings Form load starting...", LogLevel.Trace);

            //READ COM PORT LIST
            cmbPortList.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
                cmbPortList.Items.Add(s);

            //POPULATE LogLevel combobox
            cmbLogLevel.Items.Clear(); int nI = 0;
            foreach (LogLevel s in Enum.GetValues(typeof(LogLevel)))
            {
                cmbLogLevel.Items.Add(s);
                if (s == Logging.DEBUG_LEVEL) cmbLogLevel.SelectedIndex = nI;
                nI++;
            }

            //set comboboxes


            //Workaround about "Controls contained in a TabPage are not created until the tab page is shown, and any data bindings in these controls are not activated until the tab page is shown."
            foreach (TabPage tp in tabControl1.TabPages)
            {
                tp.Show();
            }

            Redraw_MainMirrorCurve();
            Redraw_SecondaryMirrorCurve();

        }

        /// <summary>
        /// Click ok button - save settings
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            Logging.AddLog("Settings save starting...", LogLevel.Trace);

            try
            {
                //Comport combobox
                string t = Properties.Settings.Default.comport;

                //Debuglevel combobox
                Properties.Settings.Default.LogLevel = (cmbLogLevel.SelectedIndex + 1).ToString();


                //Commit changes
                Properties.Settings.Default.Save(); 
                Logging.AddLog("Settings were saved", LogLevel.Activity);

                //Reload settings into working variables
                LoadParams();
                Logging.AddLog("Settings were reloaded into program", LogLevel.Activity);

                this.Close();
            }
            catch (FormatException ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame[] frames = st.GetFrames();
                string messstr = "";

                // Iterate over the frames extracting the information you need
                foreach (StackFrame frame in frames)
                {
                    messstr += String.Format("{0}:{1}({2},{3})", frame.GetFileName(), frame.GetMethod().Name, frame.GetFileLineNumber(), frame.GetFileColumnNumber());
                }

                string FullMessage = "Some of the fields has invalid values" + Environment.NewLine;
                FullMessage += Environment.NewLine + "Hint: look for incorrect decimal point ( \".\" instead of \",\" ) or a accidential letter in textbox";
                FullMessage += Environment.NewLine + "Hint 2: clicking in every field could help";
                FullMessage += Environment.NewLine + Environment.NewLine + "Debug information:" + Environment.NewLine + "IOException source: " + ex.Data + " " + ex.Message
                        + Environment.NewLine + Environment.NewLine + messstr;
                MessageBox.Show(this, FullMessage, "Invalid value", MessageBoxButtons.OK);

                Logging.AddLog(FullMessage, LogLevel.Debug);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to reset all settings to their default values (this can't be undone)?", "Reset to default values", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                Properties.Settings.Default.Reset();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Redraw_MainMirrorCurve();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Redraw_SecondaryMirrorCurve();
        }


        private void Redraw_MainMirrorCurve()
        {
            double curTempDelta_Main_Target = Utils.ConvertToDouble(txtTempTargetDelta_Main.Text);
            double curTempDelta_Main_MaxEffortZone = Utils.ConvertToDouble(txtTempDelta_Main_MaxEffort.Text);
            double curTempDelta_Main_DewRiskZone = Utils.ConvertToDouble(txtTempDelta_Main_DewRiskZone.Text);

            double curMainA = Utils.ConvertToDouble(txtCurve_Main_a.Text);
            double curMainB = Utils.ConvertToDouble(txtCurve_Main_b.Text);
            double curMainC = Utils.ConvertToDouble(txtCurve_Main_c.Text);

            double stepx = 0.05;
            double y = 0.0;

            //clear all points
            foreach (var series in chartMainCurve.Series)
            {
                series.Points.Clear();
            }

            //add intermediate curve
            for (double x = Math.Max(curTempDelta_Main_DewRiskZone, curTempDelta_Main_Target); x <= curTempDelta_Main_MaxEffortZone + 0.001; x += stepx)
            {
                y = curMainA * x * x + curMainB * x + curMainC;
                chartMainCurve.Series["curve"].Points.AddXY(x, y);
            }

            //add late part
            for (double x = curTempDelta_Main_MaxEffortZone; x <= curTempDelta_Main_MaxEffortZone + stepx * 2; x += stepx)
            {
                y = 100;
                chartMainCurve.Series["maxzone"].Points.AddXY(x, y);
            }

            //add early part
            for (double x = 0; x <= Math.Max(curTempDelta_Main_DewRiskZone, curTempDelta_Main_Target) + 0.001; x += stepx)
            {
                x = Math.Round(x, 3);
                if (x < curTempDelta_Main_DewRiskZone)
                {
                    y = 100;
                }
                else if (x == curTempDelta_Main_DewRiskZone)
                {
                    chartMainCurve.Series["minzone"].Points.AddXY(x, 100); //add one more point for better rendering this part
                    y = 0;
                }
                else
                {
                    y = 0;
                }
                chartMainCurve.Series["minzone"].Points.AddXY(x, y);
            }
            //chartMainCurve.Series["minzone"].Points.AddXY(x, 0);

            // Adjust Y & X axis scale
            chartMainCurve.ResetAutoValues();

            // Invalidate chart
            chartMainCurve.Invalidate();
        }


        private void Redraw_SecondaryMirrorCurve()
        {
            double curTempDelta_Second_Target = Utils.ConvertToDouble(txtTempTargetDelta_Second.Text);
            double curTempDelta_Second_MaxEffortZone = Utils.ConvertToDouble(txtTempDelta_Second_MaxEffort.Text);

            double curSecondA = Utils.ConvertToDouble(txtCurve_Second_a.Text);
            double curSecondB = Utils.ConvertToDouble(txtCurve_Second_b.Text);
            double curSecondC = Utils.ConvertToDouble(txtCurve_Second_c.Text);

            double stepx = 0.05;
            double y = 0.0;

            //clear all points
            foreach (var series in chartSecondCurve.Series)
            {
                series.Points.Clear();
            }

            //add intermediate curve
            for (double x = curTempDelta_Second_MaxEffortZone; x <= curTempDelta_Second_Target + 0.001; x += stepx)
            {
                y = curSecondA * x * x + curSecondB * x + curSecondC;
                chartSecondCurve.Series["curve"].Points.AddXY(x, y);
            }

            //add late part
            for (double x = curTempDelta_Second_Target; x <= curTempDelta_Second_Target + 0.001 + stepx * 2; x += stepx)
            {
                y = 0;
                chartSecondCurve.Series["maxzone"].Points.AddXY(x, y);
            }

            //add early part
            for (double x = 0; x <= curTempDelta_Second_MaxEffortZone + 0.001; x += stepx)
            {
                y = 100;
                chartSecondCurve.Series["minzone"].Points.AddXY(x, y);
            }

            // Adjust Y & X axis scale
            chartSecondCurve.ResetAutoValues();

            // Invalidate chart
            chartSecondCurve.Invalidate();
        }


        public void LoadParams()
        {
            Logging.AddLog("Loading params into program", LogLevel.Debug);
            
            try{

                ParentMainForm.Hardware.PortName = Properties.Settings.Default.comport;
                ParentMainForm.Hardware.WatchDog = Properties.Settings.Default.ComWatchdog;

                Logging.DEBUG_LEVEL = (LogLevel)(Convert.ToInt16(Properties.Settings.Default.LogLevel));

                ParentMainForm.maxNumberOfPointsInChart = Convert.ToInt16(Properties.Settings.Default.MaxPointsOnGraph);
                ParentMainForm.timer_main.Interval = Convert.ToInt16(Properties.Settings.Default.RefreshInterval);
                ParentMainForm.timer_debug_changetext.Interval = Convert.ToInt16(Properties.Settings.Default.RefreshInterval);

                ParentMainForm.Hardware.AutoControl_Loop_Interval = Convert.ToUInt32(Properties.Settings.Default.SendDataInterval);

                ParentMainForm.LogFormObj.MAX_LOG_LINES = Convert.ToInt32(Properties.Settings.Default.MaxLogLines);
                Logging._MAX_DIPSLAYED_PROG_LOG_LINES = Convert.ToInt32(Properties.Settings.Default.MaxProgLogLines);


                Logging.LogFilePath = Properties.Settings.Default.logFileLocation;
                //Logging.DataFilePath = Properties.Settings.Default.CSVFileLocation;
                Logging.SerialLogFilePath = Properties.Settings.Default.SerialLogFileLocation;

                Logging.LogFileFlag = Properties.Settings.Default.logFileFlag;
                //Logging.DataFileFlag = Properties.Settings.Default.CSVFileFlag;
                Logging.SerialLogFileFlag = Properties.Settings.Default.SerialLogFileFlag;

                //Socket server
                ParentMainForm.SocketServer.serverPort = Convert.ToInt32(Properties.Settings.Default.SocketServerPort);

                //Modeling
                ParentMainForm.Hardware.TempDelta_Main_Target = Utils.ConvertToDouble(Properties.Settings.Default.TempDelta_Main_Target);
                ParentMainForm.Hardware.TempDelta_Main_MaxEffortZone = Utils.ConvertToDouble(Properties.Settings.Default.TempDelta_Main_MaxEffort);
                ParentMainForm.Hardware.TempDelta_Main_DewZone = Utils.ConvertToDouble(Properties.Settings.Default.TempDelta_Main_DewRiskZone);

                ParentMainForm.Hardware.FanRotationPowerCurve_a= Utils.ConvertToDouble(Properties.Settings.Default.Curve_Main_a);
                ParentMainForm.Hardware.FanRotationPowerCurve_b = Utils.ConvertToDouble(Properties.Settings.Default.Curve_Main_b);
                ParentMainForm.Hardware.FanRotationPowerCurve_c = Utils.ConvertToDouble(Properties.Settings.Default.Curve_Main_c);

                ParentMainForm.Hardware.TempDelta_Secondary_Target = Utils.ConvertToDouble(Properties.Settings.Default.TempDelta_Second_Target);
                ParentMainForm.Hardware.TempDelta_Secondary_MaxEffortZone = Utils.ConvertToDouble(Properties.Settings.Default.TempDelta_Second_MaxEffort);

                ParentMainForm.Hardware.HeatingPowerCurve_a = Utils.ConvertToDouble(Properties.Settings.Default.Curve_Second_a);
                ParentMainForm.Hardware.HeatingPowerCurve_b = Utils.ConvertToDouble(Properties.Settings.Default.Curve_Second_b);
                ParentMainForm.Hardware.HeatingPowerCurve_c = Utils.ConvertToDouble(Properties.Settings.Default.Curve_Second_c);


                //Draw striplines
                ParentMainForm.chart1.ChartAreas["ChartArea1_main"].AxisY.StripLines[0].StripWidth = ParentMainForm.Hardware.TempDelta_Main_MaxEffortZone - ParentMainForm.Hardware.TempDelta_Main_Target;
                ParentMainForm.chart1.ChartAreas["ChartArea1_main"].AxisY.StripLines[0].IntervalOffset =ParentMainForm.Hardware.TempDelta_Main_Target;

                ParentMainForm.chart1.ChartAreas["ChartArea1_main"].AxisY.StripLines[2].StripWidth = ParentMainForm.Hardware.TempDelta_Main_MaxEffortZone - ParentMainForm.Hardware.TempDelta_Main_Target;
                ParentMainForm.chart1.ChartAreas["ChartArea1_main"].AxisY.StripLines[2].IntervalOffset = -ParentMainForm.Hardware.TempDelta_Main_MaxEffortZone;


            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame[] frames = st.GetFrames();
                string messstr = "";

                // Iterate over the frames extracting the information you need
                foreach (StackFrame frame in frames)
                {
                    messstr += String.Format("{0}:{1}({2},{3})", frame.GetFileName(), frame.GetMethod().Name, frame.GetFileLineNumber(), frame.GetFileColumnNumber());
                }

                string FullMessage = "Error loading settings. ";
                FullMessage += "IOException source: " + ex.Data + " | " + ex.Message + " | " + messstr;

                Logging.AddLog(FullMessage, LogLevel.Important, Highlight.Error);
                MessageBox.Show("Error loading settings [" + ex.Message + "]. Not all settings was loaded. Please check your settings, first of all decimal points!" + Environment.NewLine + Environment.NewLine + ex.ToString());
            }
            Logging.AddLog("Loading saved parameters end", LogLevel.Trace);

        }


    }
}
