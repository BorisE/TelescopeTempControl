using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace TelescopeTempControl
{
    public class LogRecord
    {
        public DateTime Time;
        public LogLevel LogLevel = LogLevel.Activity;
        public string Procedure = "";
        public string Message = "";
        public Highlight Highlight = 0;
        public string Caller = "";
        public bool dumpedToFile = false;
        public bool displayed = false;
    }

    public enum Highlight
    {
        Normal = 0,
        Error = 1,
        Emphasize = 2,
        Debug = 3
    }

    public enum LogLevel
    {
        Critical = 0,
        Activity = 1,
        Debug = 2,
        Chat = 3,
        Trace = 4,
        All = 999
    }

    public class Logging
    {
        /// <summary>
        /// Log text
        /// </summary>
        internal static List<LogRecord> LOGLIST;


        public static bool LogFileFlag = true;
        public static string LogFilePath = "";
        public static string LogFileName = "observatory_"; //Text log
        public static string LogFileExt = "log"; //Text log

        //DEBUG LEVEL
        public static LogLevel DEBUG_LEVEL = LogLevel.All;

        public static Int32 _MAX_DIPSLAYED_PROG_LOG_LINES = 100;

        static Logging()
        {
            LOGLIST = new List<LogRecord>();
        }

        /// <summary>
        /// Error log procedures
        /// </summary>
        private static string LogFileFullName
        {
            get
            {
                if (LogFilePath == "") LogFilePath = Application.StartupPath;
                return Path.Combine(LogFilePath, LogFileName + DateTime.Now.ToString("yyyy-MM-dd") + "." + LogFileExt);
            }
        }

        /// <summary>
        /// Add log record to DataBase (LOGLIST LIST)
        /// </summary>
        /// <param name="logMessage"></param>
        /// <param name="LogLevel"></param>
        /// <param name="ColorHoghlight"></param>
        public static void AddLog(string logMessage, LogLevel LogLevel = LogLevel.Critical, Highlight ColorHighlight = Highlight.Normal, string logProcedure = "")
        {
            //Add to list
            LogRecord LogRec = new LogRecord();
            LogRec.Time = DateTime.Now;
            LogRec.Procedure = logProcedure;
            LogRec.Message = logMessage;
            LogRec.LogLevel = LogLevel;
            LogRec.Highlight = ColorHighlight;
            LOGLIST.Add(LogRec);
        }

        /// <summary>
        /// Dump to file Log Contents (LOGLIST LIST)
        /// </summary>
        public static void DumpToFile(LogLevel LogLevel = LogLevel.All)
        {
            List<LogRecord> LogListNew = new List<LogRecord>();

            //sort new (not saved) records
            for (var i = 0; i < LOGLIST.Count; i++)
            {
                // if current line wasn't written to file
                if (!LOGLIST[i].dumpedToFile)
                {
                    LogListNew.Add(LOGLIST[i]); //add to newrecords array
                    LOGLIST[i].dumpedToFile = true; //mark as written
                }
            }

            //Save new (not saved) records
            if (LogListNew.Count > 0)
            {
                try
                {
                    using (StreamWriter LogFile = new StreamWriter(LogFileFullName, true))
                    {
                        for (var i = 0; i < LogListNew.Count; i++)
                        {
                            // if current log level is less then DebugLevel
                            if (LogListNew[i].LogLevel <= LogLevel)
                            {
                                //time
                                LogFile.Write("{0,-12}{1,-14}", LogListNew[i].Time.ToString("yyyy-MM-dd"), LogListNew[i].Time.ToString("HH:mm:ss.fff"));
                                //LogLevel
                                LogFile.Write("{0,-10}", LogListNew[i].LogLevel.ToString());
                                //message
                                LogFile.Write("{0}\t", LogListNew[i].Message);
                                LogFile.WriteLine();
                            }
                        }
                    }

                    try
                    {
                        //Clean LOGFILE from records already dumped
                        for (var i = 0; i < LOGLIST.Count; i++)
                        {
                            if (LOGLIST[i].dumpedToFile)
                            {
                                // if current line was written to file remove it
                                LOGLIST.RemoveAt(i);
                            }
                        }
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show("Log write error during cleanup [" + Ex.Message + "]");
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show("Log write error [" + Ex.Message + "]\n\n" + Ex.ToString());
                }
            }

        }

        /// <summary>
        /// Dump to screen Log Contents
        /// </summary>
        public static string DumpToString(LogLevel LogLevel = LogLevel.Activity)
        {
            string RetStr = "";
            for (var i = 0; i < LOGLIST.Count; i++)
            {
                // if current line wasn't written to file
                if (!LOGLIST[i].displayed)
                {
                    // if current log level is less then DebugLevel
                    if (LOGLIST[i].LogLevel <= LogLevel)
                    {
                        RetStr += String.Format("{0} {1}", LOGLIST[i].Time.ToString("yyyy-MM-dd"), LOGLIST[i].Time.ToString("HH:mm:ss"));
                        RetStr += String.Format(": {0}", LOGLIST[i].Message) + Environment.NewLine;
                    }
                    LOGLIST[i].displayed = true;
                }
            }
            return RetStr;
        }

        /// <summary>
        /// Dump to screen Log Contents
        /// </summary>
        public static void AppendText(RichTextBox LogTextBox, LogLevel LogLevel = LogLevel.Activity)
        {
            List<LogRecord> LogListNew = new List<LogRecord>();

            //sort new (not saved) records
            for (var i = 0; i < LOGLIST.Count; i++)
            {
                // if current line wasn't displayed
                if (!LOGLIST[i].displayed)
                {
                    LogListNew.Add(LOGLIST[i]); //add to newrecords array
                    LOGLIST[i].displayed = true; //mark as written
                }
            }

            //check - if logtextbox is too large
            if (LogTextBox.Lines.Length > _MAX_DIPSLAYED_PROG_LOG_LINES)
            {
                string[] lines = LogTextBox.Lines;
                var newLines = lines.Skip(LogTextBox.Lines.Length - _MAX_DIPSLAYED_PROG_LOG_LINES);
                LogTextBox.Lines = newLines.ToArray();                
            }

            string RetStr = "";
            //Save new (not saved) records
            if (LogListNew.Count > 0)
            {
                for (var i = 0; i < LogListNew.Count; i++)
                {
                    // if current log level is less then DebugLevel
                    if (LogListNew[i].LogLevel <= LogLevel)
                    {
                        //set cursor to the end
                        LogTextBox.SelectionStart = LogTextBox.TextLength;
                        LogTextBox.SelectionLength = 0;

                        if (LogListNew[i].Highlight == Highlight.Error)
                        {
                            LogTextBox.SelectionColor = Color.Red;
                        }

                        RetStr = String.Format("{0} {1}", LogListNew[i].Time.ToString("yyyy-MM-dd"), LogListNew[i].Time.ToString("HH:mm:ss"));
                        RetStr += String.Format(": {0}", LogListNew[i].Message) + Environment.NewLine;
                        LogTextBox.AppendText(RetStr);

                        LogTextBox.SelectionColor = LogTextBox.ForeColor;

                        //set cursor to the end
                        LogTextBox.SelectionStart = LogTextBox.TextLength;
                        LogTextBox.SelectionLength = 0;
                        LogTextBox.ScrollToCaret();
                    }
                }
            }
        }

        private static TextWriter SerialLogFile = null;
        public static string SerialLogFileName = "telescope_temp_control_serial_"; //Serial log file
        public static string serialLogExt = ".log";
        public static string SerialLogFilePath = "";
        public static bool SerialLogFileFlag = true;

        private static string ApplicationFilePath
        {
            get { return Application.StartupPath + "\\"; }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Serial log procedures
        /// </summary>
        #region Serial log section
        public static void OpenSerialLogFile()
        {
            if (SerialLogFilePath == "") SerialLogFilePath = ApplicationFilePath;

            string FullFileName = SerialLogFilePath + SerialLogFileName + DateTime.Now.ToString("yyyy-MM-dd") + serialLogExt;

            try
            {
                if (!File.Exists(FullFileName))
                {
                    SerialLogFile = File.CreateText(FullFileName);
                }
                else
                {
                    SerialLogFile = File.AppendText(FullFileName);
                }
            }
            catch
            {
                Logging.AddLog("Cannot open serial log file", LogLevel.Critical, Highlight.Error);
            }
        }

        public static void CloseSerialLogFile()
        {
            try
            {
                SerialLogFile.Close();
            }
            catch
            {
                Logging.AddLog("Cannot close serial log file", LogLevel.Critical, Highlight.Error);
            }

            SerialLogFile = null;
        }

        public static void LogSerial(string logMessage)
        {
            if (SerialLogFile == null)
            {
                OpenSerialLogFile();
            }

            try
            {
                SerialLogFile.Write("{0} {1}", DateTime.Now.ToShortDateString(), DateTime.Now.ToLongTimeString());
                SerialLogFile.WriteLine(": {0}", logMessage);
            }
            catch
            {
                Logging.AddLog("Cannot write serial log file", LogLevel.Critical, Highlight.Error);
            }

        }
        #endregion




    }
}
