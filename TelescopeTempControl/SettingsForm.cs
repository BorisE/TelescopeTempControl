﻿using System;
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
            COM11.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
                COM11.Items.Add(s);

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


        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Logging.AddLog("Settings save starting...", LogLevel.Trace);

            try
            {
                //Debuglevel combobox
                Properties.Settings.Default.LogLevel = (cmbLogLevel.SelectedIndex + 1).ToString();

                Logging.AddLog("Settings were saved", LogLevel.Activity);

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
                ParentMainForm.LogFormObj.MAX_LOG_LINES = Convert.ToInt32(Properties.Settings.Default.MaxLogLines);
                Logging._MAX_DIPSLAYED_PROG_LOG_LINES = Convert.ToInt32(Properties.Settings.Default.MaxProgLogLines);


                Logging.LogFilePath = Properties.Settings.Default.logFileLocation;
                //Logging.DataFilePath = Properties.Settings.Default.CSVFileLocation;
                Logging.SerialLogFilePath = Properties.Settings.Default.SerialLogFileLocation;

                Logging.LogFileFlag = Properties.Settings.Default.logFileFlag;
                //Logging.DataFileFlag = Properties.Settings.Default.CSVFileFlag;
                Logging.SerialLogFileFlag = Properties.Settings.Default.SerialLogFileFlag;


                //Modeling
                ParentMainForm.Hardware.TempDelta_Main_Target = Utils.ConvertToDouble(Properties.Settings.Default.TempDelta_Main_Target);
                ParentMainForm.Hardware.TempDelta_Main_MaxEffortZone = Utils.ConvertToDouble(Properties.Settings.Default.TempDelta_Main_MaxEffort);

                ParentMainForm.Hardware.TempDelta_Secondary_Target = Utils.ConvertToDouble(Properties.Settings.Default.TempDelta_Second_Target);
                ParentMainForm.Hardware.TempDelta_Secondary_MaxEffortZone = Utils.ConvertToDouble(Properties.Settings.Default.TempDelta_Second_MaxEffort);


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

                Logging.AddLog(FullMessage, LogLevel.Critical, Highlight.Error);
                MessageBox.Show("Error loading settings [" + ex.Message + "]. Not all settings was loaded. Please check your settings, first of all decimal points!" + Environment.NewLine + Environment.NewLine + ex.ToString());
            }
            Logging.AddLog("Loading saved parameters end", LogLevel.Trace);

        }
    
    }
}
