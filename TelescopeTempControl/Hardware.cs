using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace TelescopeTempControl
{
    public partial class Hardware
    {
        /// <summary>
        /// Command dictionary for interpretator
        /// </summary>
        public CommandInterpretator CommandParser;

        /// <summary>
        /// Serial Port name
        /// </summary>        
        public string PortName = "COM11";
        public bool UseFileEmulation = false;
        public string _WORK_WITH_FILE_SERIAL = "File Emulation"; //CONSTANT, CAN BE SET FROM EXTERNAL PARAMETERS
        public bool UseSocketRead = false;

        /// <summary>
        /// The SerialPort object, which is used for communicating through the RS-232 port
        /// </summary>        
        public SerialPort comport = new SerialPort();

        /// <summary>
        /// Buffer with data
        /// </summary>        
        public string SerialBuffer = "";
        public UInt32 MAX_BUFFER_LEN = 10000;

        /// <summary>
        /// Link to Socket class
        /// </summary>
        public SocketServerClass SocketServer;
        public string SerialBufferFromSocket = "";//serial buffer from socket server should be put here by external process

        /// <summary>
        /// Simulation mode vars
        /// </summary>
        public bool UseSimulation = false;
        public string SerialBufferFullSim = "";
        public int simBufferReadPos = 0;

        //Protocol delimeters
        #region Protocol delimeters
        const string DATAPROTOCOL_START = "[!";
        const string DATAPROTOCOL_END = "]";
        const string DATAPROTOCOL_SEPARATOR = ":";
        #endregion

        /// <summary>
        /// Last time data was read (WATCHDOG)
        /// </summary>        
        #region Internal WATCHDOG
        public bool WatchDog = true;
        public UInt32 MAX_WAIT_DATA_INTERVAL = 100; //how long to wait before restart
        public DateTime LastTimeDataRead;
        #endregion

        /// <summary>
        /// Relay and Heating settings
        /// </summary>
        #region Relay and Heating settings
        public int Relay1 = 0;
        public DateTime LastHeating1SwitchOn = new DateTime(2014, 1, 1, 0, 0, 1), LastHeating1SwitchOff = new DateTime(2014, 1, 1, 0, 0, 1);
        public int SinceLastHeating1;
        public bool CloudSensorNeedHeatingFlag = false;
        public int Heating1Off_SecondsPassed = 0, Heating1On_SecondsPassed = 0;

        public int Relay2 = 0;
        public DateTime LastHeating2SwitchOn = new DateTime(2014, 1, 1, 0, 0, 1), LastHeating2SwitchOff = new DateTime(2014, 1, 1, 0, 0, 1);
        public int SinceLastHeating2;
        public int Heating2Off_SecondsPassed = 0, Heating2On_SecondsPassed = 0;


        public double HEATER_CLOUDINDEX_MIN = 14.0;
        public double HEATER_CLOUDINDEX_MAX = 19.0;
        public int CS_NEEDHEATING_LOOKBACK_CYCLES = 5; //5 cycles per 5 min ~ 25 min
        public double CS_NEEDHEATING_MINDELTA = 0.0;
        public double CS_NEEDHEATING_MAXDELTA = 2.0;

        public int HEATER_CS_PAUSE = 1800;

        public Dictionary<String, ArduinoSettingsClass> ArduinoSettings = new Dictionary<String, ArduinoSettingsClass>();

        public double HEATER_MAX_TEMPERATURE_DELTA = 55.0;
        public int HEATER_MAX_DURATION = 600;
        public double HEATER_WET_START_THRESHOLD = 1010;
        #endregion

        public int MeasureCycleLen = 14530;

        public string SketchVersion = "";
        public string SketchVersionDate = "";

        /// <summary>
        /// Sensor arrays and different settings
        /// </summary>        
        #region Sensor arrays
        public Dictionary<String, SensorElement> SensorsList = new Dictionary<String, SensorElement>();
        public Dictionary<string, int> SensorsArrayHashArduino = new Dictionary<string, int>();

        public string BaseTempName = "Temp1";
        public int BaseTempIdx___ = -1;
        public double BaseTempVal = -100;

        public Dictionary<string, SensorTypeEnum> SensorTypeEnum_Dict = new Dictionary<string, SensorTypeEnum> {
            { "Temp", SensorTypeEnum.Temp },
            { "Press", SensorTypeEnum.Press },
            { "Hum", SensorTypeEnum.Hum },
            { "Illum", SensorTypeEnum.Illum },
            { "Wet", SensorTypeEnum.Wet },
            { "RGC", SensorTypeEnum.RGC },
            { "WSp", SensorTypeEnum.WSp },
            { "Relay", SensorTypeEnum.Relay }
        };
        #endregion


        /// <summary>
        /// Constructor ********************************************************************************
        /// </summary>        
        public Hardware(MainForm MF = null)
        {
            //if calling with parameter - using graphical form for displaying serial data
            //if (MF != null) ParentMainForm = MF; 
            

            CommandParser = new CommandInterpretator();
            InitComandInterpretator();

        }


        /// <summary>
        /// Attach event handler to serial port object
        /// </summary>        
        public void eventHandler()
        {
            comport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            //comport.PinChanged += new SerialPinChangedEventHandler(comport_PinChanged);
            Logging.AddLog("Comport DataReceived event handler was set", LogLevel.Debug);

        }

        /// <summary>
        /// Setting port settings
        /// </summary>        
        private void setPortSettings()
        {
            // Set the port's settings
            comport.BaudRate = int.Parse("9600");
            comport.DataBits = int.Parse("8");
            comport.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
            comport.Parity = (Parity)Enum.Parse(typeof(Parity), "None");
            comport.Handshake = Handshake.None;
            comport.PortName = PortName;
            comport.DtrEnable = true; //to reset Arduino on connect

            LastTimeDataRead = DateTime.Now;

            Logging.AddLog("Comport settings were set", LogLevel.Debug);

        }

        /// <summary>
        /// This method is called to start reading data
        /// </summary>        
        public bool startReadData()
        {
            bool error = false;
            Logging.AddLog("startReadData command issued", LogLevel.Debug);

            // If the port is not open
            if (!comport.IsOpen)
            {

                if (UseSocketRead)
                {
                    //nothing much to check...
                    sendParametersToSerial();
                    queryParametersFromSerial();
                    if (!error) Logging.AddLog("Socket data read was opened", LogLevel.Activity, Highlight.Normal, "startReadData");
                }
                else if (UseFileEmulation)
                {
                    error = !SerialFromFile.Open();
                    sendParametersToSerial();
                    queryParametersFromSerial();
                    if (!error) Logging.AddLog("FileEmulation was opened", LogLevel.Activity);
                }
                else
                {
                    try
                    {
                        setPortSettings();
                        eventHandler();

                        // Open the port
                        comport.Open();
                        Logging.AddLog("Comport was opened", LogLevel.Activity);

                        sendParametersToSerial();
                        queryParametersFromSerial();
                    }
                    catch (UnauthorizedAccessException) { error = true; }
                    catch (IOException) { error = true; }
                    catch (ArgumentException) { error = true; }
                }
            }
            if (error)
            {
                Logging.AddLog("Couldn't open comport", LogLevel.Critical, Highlight.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// This method is called to stop reading data
        /// </summary>  
        public bool stopReadData()
        {
            bool error = false;
            Logging.AddLog("stopReadData command issued", LogLevel.Debug);

            // If the port is open, close it.
            if (UseFileEmulation)
            {
                error = SerialFromFile.Close();
                if (!error) Logging.AddLog("FileEmulation was closed", LogLevel.Activity);
            }
            else if (UseSocketRead)
            {
                //if it was socket data - do nothing - data could be receiving even in stop mode (I think for now at least...)
                //error = !.Close();
                error = false;
                if (!error) Logging.AddLog("Socket read command was received, but no need to stop in this mode", LogLevel.Activity);
            }
            else
            {
                if (comport.IsOpen)
                {
                    try
                    {
                        // Close the port
                        comport.Close();
                        Logging.AddLog("Comport was closed", LogLevel.Activity);
                    }
                    catch (UnauthorizedAccessException) { error = true; }
                    catch (IOException) { error = true; }
                    catch (ArgumentException) { error = true; }
                }
            }
            if (error)
            {
                Logging.AddLog("Couldn't close comport", LogLevel.Critical, Highlight.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Event handler for DataReceived event
        /// </summary>        
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // If the com port has been closed, do nothing
            if (!comport.IsOpen) return;

            // This method will be called when there is data waiting in the port's buffer

            // Read all the data waiting in the buffer
            string data = comport.ReadExisting();

            SerialBuffer += data;
            //string[] lines = SerialBuffer.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            /// if using with VISUAL INTERFACE
            //if (ParentMainForm!=null) ParentMainForm.LogForm.AppendLogText(data);

            //Log serial data if needed
            if (Logging.SerialLogFileFlag) Logging.LogSerial(data);

            if (SerialBuffer.Length > MAX_BUFFER_LEN)
            {
                SerialBuffer = SerialBuffer.Substring((Int16)(SerialBuffer.Length - MAX_BUFFER_LEN));
                Logging.AddLog("SerialBuffer was cut to " + MAX_BUFFER_LEN, LogLevel.Debug);
            }

            Logging.AddLog("SerialBuffer data was received", LogLevel.Debug);
            LastTimeDataRead = DateTime.Now;
        }

        /// <summary>
        /// Simulated read in arbitrary portions from previously formed SerialBufferFullSim data into main Serial Buffer
        /// Full simulation! :)
        /// </summary>
        /// <returns></returns>
        public bool port_DataReceived_simulated()
        {
            if (simBufferReadPos < SerialBufferFullSim.Length)
            {
                // Read arbitrary nyum from predefined buffer
                Random rnd = new Random();
                int BuffReadLen = rnd.Next(4, 100);
                if ((simBufferReadPos + BuffReadLen) > SerialBufferFullSim.Length)
                {
                    BuffReadLen = SerialBufferFullSim.Length - simBufferReadPos;
                }
                string data = SerialBufferFullSim.Substring(simBufferReadPos, BuffReadLen);
                simBufferReadPos += BuffReadLen;

                SerialBuffer += data;

                //string[] lines = SerialBuffer.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                //Log serial data if needed
                if (Logging.SerialLogFileFlag) Logging.LogSerial(data);

                if (SerialBuffer.Length > MAX_BUFFER_LEN)
                {
                    SerialBuffer = SerialBuffer.Substring((Int16)(SerialBuffer.Length - MAX_BUFFER_LEN));
                    Logging.AddLog("SerialBuffer was cut to " + MAX_BUFFER_LEN, LogLevel.Debug);
                }

                Logging.AddLog("SerialBuffer data was received", LogLevel.Debug);
                LastTimeDataRead = DateTime.Now;

                return false;
            }
            else
            {
                //read complete
                return true;
            }
        }

        /// <summary>
        /// Wrapper for writing data to serial port
        /// </summary>
        /// <param name="CommandSt">string with command, which should be sent to Arduino</param>
        public bool WriteSerialData(string CommandSt)
        {
            string FullCommandSt = "(" + CommandSt + ")";
            bool error = false;


            if (UseSocketRead)
            {
                //error = !.WriteData(FullCommandSt);
                //if (!error) Logging.Log("Command to Serial File Emulation was sent: " + FullCommandSt);
                error = false;
                Logging.AddLog("Command to socket client isn't implemented yet: " + FullCommandSt, LogLevel.Debug);
                return !error;
            }
            else if (UseFileEmulation)
            {
                error = !SerialFromFile.WriteData(FullCommandSt);
                if (!error) Logging.AddLog("Command to Serial File Emulation was sent: " + FullCommandSt, LogLevel.Debug);
                return !error;
            }
            else
            {
                try
                {
                    comport.WriteLine(FullCommandSt);
                    Logging.AddLog("Command to serial sent: " + FullCommandSt, LogLevel.Activity);
                    return true;
                }
                catch
                {
                    Logging.AddLog("Error writing command " + FullCommandSt + " to serial", LogLevel.Critical, Highlight.Error);
                    return false;
                }
            }
        }

        /// <summary>
        /// Send current settings to Arduino. Overload with returning sent command string
        /// </summary>
        /// <returns>true - if all data was sent</returns>
        public bool sendParametersToSerial(out string CommandStr)
        {
            Logging.AddLog("sendParametersToSerial(overload) enter", LogLevel.Trace);

            String St = ""; CommandStr = "";
            //St = "!TD:" + Convert.ToString(HEATER_MAX_TEMPERATURE_DELTA);
            CommandStr += "out: " + St;
            bool retval1 = WriteSerialData(St);
            //St = "!WT:" + Convert.ToString(HEATER_WET_START_THRESHOLD);
            CommandStr += "out: " + St;
            bool retval2 = WriteSerialData(St);
            //St = "!RT:" + Convert.ToString(HEATER_MAX_DURATION);
            CommandStr += "out: " + St;
            bool retval3 = WriteSerialData(St);

            Logging.AddLog("sendParametersToSerial (overload) was sent", LogLevel.Trace);

            return (retval1 && retval2 && retval3);
        }

        /// <summary>
        /// Send current settings to Arduino
        /// </summary>
        /// <returns>true - if all data was sent</returns>
        public bool sendParametersToSerial()
        {
            Logging.AddLog("sendParametersToSerial enter", LogLevel.Trace);

            String St = ""; string StAll = "";
            //St = "!TD:" + Convert.ToString(HEATER_MAX_TEMPERATURE_DELTA); //Earlier: + ")" + Environment.NewLine
            StAll += St;
            bool retval1 = WriteSerialData(St);
            //St = "!WT:" + Convert.ToString(HEATER_WET_START_THRESHOLD);
            StAll += St;
            bool retval2 = WriteSerialData(St);
            //St = "!RT:" + Convert.ToString(HEATER_MAX_DURATION);
            StAll += St;
            bool retval3 = WriteSerialData(St);

            Logging.AddLog("sendParametersToSerial was sent", LogLevel.Trace);

            return (retval1 && retval2 && retval3);
        }

        /// <summary>
        /// Send command to Arduino to print current settings 
        /// </summary>
        /// <returns></returns>
        public bool queryParametersFromSerial()
        {
            bool retval1 = WriteSerialData("!?S");

            Logging.AddLog("getParametersToSerial command was sent", LogLevel.Debug);

            return retval1;
        }

        /// <summary>
        /// Send command to Arduino to print current settings. Overload with return string
        /// </summary>
        /// <returns></returns>
        public bool queryParametersFromSerial(out string CommandStr)
        {
            String St = "!?S"; CommandStr = St;
            bool retval1 = WriteSerialData(St);

            Logging.AddLog("getParametersToSerial command was sent", LogLevel.Debug);

            return retval1;
        }

        /// <summary>
        /// External method to check when was the last communication
        /// </summary>        
        public UInt32 SinceLastDataReceived()
        {
            UInt32 SinceLastRead_sec = UInt32.MaxValue;

            if (UseFileEmulation)
            {
                SinceLastRead_sec = SerialFromFile.SinceLastModification();
            }
            else if (UseSocketRead)
            {
                TimeSpan SinceLastRead = DateTime.Now.Subtract(SocketServer.LastTimeDataRead);
                SinceLastRead_sec = (UInt32)Math.Round(SinceLastRead.TotalSeconds, 0);
            }
            else
            {
                TimeSpan SinceLastRead = DateTime.Now.Subtract(LastTimeDataRead);
                SinceLastRead_sec = (UInt32)Math.Round(SinceLastRead.TotalSeconds, 0);
            }

            return SinceLastRead_sec;
        }

        /// <summary>
        /// External method to check when was last data received and restart communication (a la watchdog)
        /// </summary>        
        public void CheckIfDataReceiving()
        {
            uint PassedSinceReceiving = SinceLastDataReceived();
            if (PassedSinceReceiving > MAX_WAIT_DATA_INTERVAL)
            {
                //restart connection
                Logging.AddLog("Waiting too long for data (" + PassedSinceReceiving + "). Restarting connection to COM port...", LogLevel.Activity);
                stopReadData();
                System.Threading.Thread.Sleep(2000);
                startReadData();
            }
            else
            {
                Logging.AddLog("CheckIfDataReceiving is ok. Passed since last receive: " + PassedSinceReceiving + "", LogLevel.Debug);
            }
        }

        /// <summary>
        /// External interface to check if communication was started
        /// </summary>        
        public bool IsOpened()
        {
            bool ret = false;
            if (UseFileEmulation)
            {
                ret = SerialFromFile.ConsideredOpen;
            }
            else if (UseSocketRead)
            {
                ret = (SocketServer.listenerSocket.IsBound);
            }
            else
            {
                ret = comport.IsOpen;
            }
            return ret;

        }

        /// <summary>
        /// Method to stop communications
        /// </summary>        
        public void Close()
        {
            comport.Close();
        }

        /// <summary>
        /// External method for parsing buffer data and then make all needed calculations
        /// </summary>        
        public void LOOP_CYCLE(out string curSerBuffer)
        {
            //0.1 If Serial file emulation, read file
            if (UseFileEmulation && !UseSimulation) SerialBuffer = SerialFromFile.Read();

            //0.2. If use socket data mode, all data should be already put into var from MainForm
            if (UseSocketRead && !UseSimulation) SerialBuffer = SocketServer.SocketServerCommandBuffer;

            //1. PARSE BUFFER
            ParseBufferData();

            //Get out and clear buffer after parsing
            curSerBuffer = SerialBuffer;
            SerialBuffer = "";

            //2. MAKE CALCULATIONS
            //MakeSensorsCalculations();
        }

        /// <summary>
        /// Upgraded main method to parse received data
        /// Based on SensorArray
        /// Mast be called from external. Working asynchronously with data reading
        /// </summary>        
        internal void ParseBufferData()
        {
            string aLine = null;
            StringReader strReader = new StringReader(SerialBuffer);
            while (true)
            {
                aLine = strReader.ReadLine();
                if (aLine != null)
                {
                    //IS THIS DATA PROTOCOL LINE?
                    if (aLine.Trim().StartsWith(DATAPROTOCOL_START))
                    {

                        int tagStartPosition = DATAPROTOCOL_START.Length;
                        int tagEndPosition = aLine.IndexOf(DATAPROTOCOL_SEPARATOR);
                        int valEndPosition = aLine.IndexOf(DATAPROTOCOL_END);

                        // IS THIS A FULL LINE (WITH TAG AND DATA)?
                        if (tagEndPosition >= 0 && valEndPosition >= 0)
                        {
                            //0. PREPARE VALUES
                            string tagName = aLine.Substring(tagStartPosition, tagEndPosition - tagStartPosition);
                            string tagValue_raw = aLine.Substring(tagEndPosition + 1, valEndPosition - tagEndPosition - 1);

                            //0.1. Automatic decimal point correction
                            char Separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
                            char BadSeparator = '.';

                            if (Separator == '.') { BadSeparator = ','; }
                            if (Separator == ',') { BadSeparator = '.'; }

                            string tagValue_st = tagValue_raw.Replace(BadSeparator, Separator);

                            //0.2. Try to convert to double. 
                            double tagValue_dbl = -100.0;
                            try
                            {
                                tagValue_dbl = Convert.ToDouble(tagValue_st);
                            }
                            catch (Exception Ex)
                            {
                                //Note, that exception is not always an error - some values should state in string format, i.e. version info
                            }

                            //LINE PARSED TO tagName AND tagValue

                            //1. WRITE IT TO SENSOR VALUE
                            int SensIdx = -1;
                            foreach (SensorElement DataSensor in SensorsList.Values)
                            {
                                SensIdx++;
                                if (DataSensor != null)
                                {
                                    if (DataSensor.SensorArduinoField == tagName)
                                    {
                                        try
                                        {
                                            //Trim value if it is too lengthy (in case of Arduino malfunction)
                                            if (tagValue_st.Length > 20)
                                            {
                                                tagValue_st = tagValue_st.Substring(0, 20) + "[...]";
                                                Logging.AddLog("TagValue is too long in ParseBufferData for pair [" + tagName + "][" + tagValue_st + "]", LogLevel.Debug);
                                            }

                                            //Convert to Double
                                            if (CheckData(tagValue_dbl, DataSensor.SensorType))
                                            {
                                                SensorsList[DataSensor.SensorName].AddValue(tagValue_dbl);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Logging.AddLog("Exception in ParseBufferData for pair [" + tagName + "][" + tagValue_st + "], message: " + ex.Message + ". " + ex.ToString(), LogLevel.Critical, Highlight.Error);
                                        }
                                    }
                                }
                            }

                            //2. PARSING PARTICULAR CASES
                            if (tagName == "Obj")
                            {
                            }
                            else if (tagName == "RL1")
                            {
                                int Relay1_n = Convert.ToInt16(tagValue_dbl);
                                if (Relay1 == 0 && Relay1_n == 1)
                                {
                                    LastHeating1SwitchOn = DateTime.Now;
                                }
                                else if (Relay1 == 1 && Relay1_n == 0)
                                {
                                    LastHeating1SwitchOff = DateTime.Now;
                                }
                                Relay1 = Relay1_n;
                            }
                            else if (tagName == "!r")
                            {
                                MeasureCycleLen = Convert.ToInt32(tagValue_dbl);
                            }
                            else if (tagName == "!be")
                            {
                            }
                            else if (tagName == "ver")
                            {
                                SketchVersion = tagValue_st;
                                VersionData.HardwareVersionSt = SketchVersion;
                            }
                            else if (tagName == "ved")
                            {
                                SketchVersionDate = tagValue_st;
                                VersionData.HardwareCompileTimeSt = SketchVersionDate;
                            }
                            else if (tagName == "!en")
                            {

                            }
                            else if (tagName == "?TD")
                            {
                                ArduinoSettingsClass El = new ArduinoSettingsClass();
                                El.Value = tagValue_st;
                                El.ReadTime = DateTime.Now;
                                ArduinoSettings["TD"] = El;
                            }
                            else if (tagName == "?WT")
                            {
                                ArduinoSettingsClass El = new ArduinoSettingsClass();
                                El.Value = tagValue_st;
                                El.ReadTime = DateTime.Now;
                                ArduinoSettings["WT"] = El;
                            }
                            else if (tagName == "?RT")
                            {
                                ArduinoSettingsClass El = new ArduinoSettingsClass();
                                El.Value = tagValue_st;
                                El.ReadTime = DateTime.Now;
                                ArduinoSettings["RT"] = El;
                            }
                        }
                        else
                        //THE LINE IS INCOMPLETE
                        {
                            //write error log
                            Logging.AddLog("Incomplete protocol line: " + aLine, LogLevel.Debug);
                        }
                    }
                }
                else
                {
                    break;
                }
            }
        }

    }
}
