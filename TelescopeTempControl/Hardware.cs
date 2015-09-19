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
        /// Relay and Heating
        /// </summary>
        #region Relay and Heating
        public int Relay1 = 0;
        public DateTime LastHeating1SwitchOn = new DateTime(2014, 1, 1, 0, 0, 1), LastHeating1SwitchOff = new DateTime(2014, 1, 1, 0, 0, 1);
        public int SinceLastHeating1;
        public bool CloudSensorNeedHeatingFlag = false;
        public int Heating1Off_SecondsPassed = 0, Heating1On_SecondsPassed = 0;
        #endregion


        /// <summary>
        /// Particlular sensors
        /// </summary>
        #region Particlular sensors
        public int FanPWM = 255;
        public int HeaterPWM = 0; //0-255

        public double HeaterPower = 0.0; //0-100

        public bool AutoControl_FanSpeed = false;
        public bool AutoControl_Heater = false;

        public DateTime AutoControl_LastCorrection;
        public UInt32 AutoControl_Loop_Interval;

        public double DeltaTemp_Main = -100.0;
        public double DeltaTemp_Secondary = -100.0;

        public List<double> DeltaTemp_Main_List = new List<double>();
        public List<double> DeltaTemp_Secondary_List = new List<double>();

        public const int SENSOR_HISTORY_LENGTH = 10;
        #endregion


        /// <summary>
        /// Speed to PWM second order polynom equation coeffients 
        /// int pwm = Convert.ToInt32(FanCurve_a * speedval * speedval - FanCurve_b * speedval + FanCurve_c);
        /// pwm = Math.Min(pwm, 255);
        /// pwm = Math.Max(pwm, 0);
        /// </summary>
        double FanCurve_a = -8E-05;
        double FanCurve_b = 0.0862;
        double FanCurve_c = 246.15;

        /// <summary>
        /// Arduino settings
        /// </summary>
        #region Arduino settings
        public Dictionary<String, ArduinoSettingsClass> ArduinoSettings = new Dictionary<String, ArduinoSettingsClass>();

        public double HEATER_MAX_TEMPERATURE_DELTA = 15.0;

        public int MeasureCycleLen = 4450;

        public string SketchVersion = "";
        public string SketchVersionDate = "";
        #endregion Arduino settings

        /// <summary>
        /// Sensor arrays and different settings
        /// </summary>        
        #region Sensor arrays
        public Dictionary<String, SensorElement> SensorsList = new Dictionary<String, SensorElement>();
        public Dictionary<string, int> SensorsArrayHashArduino = new Dictionary<string, int>();

        #endregion



        /// <summary>
        /// Constructor ********************************************************************************
        /// </summary>        
        public Hardware(MainForm MF = null)
        {
            //if calling with parameter - using graphical form for displaying serial data
            //if (MF != null) ParentMainForm = MF; 

            initSensorList();

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
            MakeSensorsCalculations();
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
                            if (!double.TryParse(tagValue_st, out tagValue_dbl))
                            {
                                tagValue_dbl = -100.0;
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
                            else if (tagName == "Ht")
                            {
                                tagValue_dbl = Math.Max(tagValue_dbl,0);
                                tagValue_dbl = Math.Min(tagValue_dbl, 255);
                            }
                            else if (tagName == "Pwm")
                            {
                                tagValue_dbl = Math.Max(tagValue_dbl, 0);
                                tagValue_dbl = Math.Min(tagValue_dbl, 255);
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


        /// <summary>
        /// Calculate some data based on current sensor values
        /// </summary>
        private void MakeSensorsCalculations()
        {
            DeltaTemp_Main = (SensorsList["Temp2"].LastValue - SensorsList["Temp1"].LastValue);
            DeltaTemp_Main_Add(DeltaTemp_Main);
            DeltaTemp_Secondary = (SensorsList["Temp3"].LastValue - SensorsList["Temp1"].LastValue);
            DeltaTemp_Secondary_Add(DeltaTemp_Secondary);

            HeaterPWM = Convert.ToInt16(SensorsList["Heater"].LastValue);
            HeaterPower = (double)HeaterPWM / 255.0 * 100.0;

            AutoControl_CYCLE();

            //check temp difference
            if (DeltaTemp_Secondary > HEATER_MAX_TEMPERATURE_DELTA)
            {
                Logging.AddLog("Secondary temp delta is too high. Switching heater off", LogLevel.Activity, Highlight.Emphasize);
                SetHeaterPWM(0);
            }
        }

        /// <summary>
        /// Method to check data validity for different sensors type
        /// </summary>      
        public static bool CheckData(double TagVal, SensorTypeEnum checkDataType)
        {
            switch (checkDataType)
            {
                case SensorTypeEnum.Temp:
                    if (TagVal < -80 || TagVal > 80)
                        return false;
                    break;
                case SensorTypeEnum.Hum:
                    if (TagVal <= 0 || TagVal >= 100)
                        return false;
                    break;
                case SensorTypeEnum.Press:
                    if (TagVal <= 0 || TagVal >= 800)
                        return false;
                    break;
                case SensorTypeEnum.Illum:
                    if (TagVal < 0 || TagVal >= 100000)
                        return false;
                    break;
                case SensorTypeEnum.Wet:
                    if (TagVal <= 0 || TagVal >= 1024)
                        return false;
                    break;
                case SensorTypeEnum.RGC:
                    if (TagVal < 0 || TagVal >= 1000) //maximum value I have ever seen was 237
                        return false;
                    break;
                case SensorTypeEnum.Relay:
                    if (TagVal < 0 || TagVal > 1) //only 2 values allowed: 0 and 1
                        return false;
                    break;
                case SensorTypeEnum.WSp:
                    if (TagVal < 0 || TagVal > 1023) //Actually it is AnalogUnits. 1023 - max value, corresponds to MaxSpeed (def 32.4 m/s). Hurricane > 32
                        return false;
                    break;
                case SensorTypeEnum.PWM:
                    if (TagVal < 0 || TagVal > 255) //0 to 255 analog counts
                        return false;
                    break;
                case SensorTypeEnum.RPM:
                    if (TagVal < 0 || TagVal > 4000) //Don't know more rapid coolers
                        return false;
                    break;
                default:
                    throw new System.ArgumentException("Sensor type is out of range", "checkDataType");
            }
            return true;
        }

        /// <summary>
        /// Method to check data validity for different sensors type
        /// Specail for working with SensorArray
        /// </summary>      
        public static bool CheckData(SensorElement Sensor)
        {
            double TagVal = Sensor.LastValue;
            return CheckData(TagVal, Sensor.SensorType);
        }

        /// <summary>
        /// Set fan pwm value
        /// </summary>
        /// <param name="pwmval">0-255 pwm value, 255 - off, 0 -full throttle</param>
        internal void SetFanPWM(int pwmval)
        {
            Logging.AddLog("Setting Fan PWM to " + pwmval, LogLevel.Activity);
            if (UseSimulation)
            {
                FanPWM = pwmval;
            }
            else
            {
                WriteSerialData("!FN:" + pwmval.ToString());
            }
        }
        /// <summary>
        /// Get PWM value on fan speed value
        /// </summary>
        /// <param name="speedval">160-1300 pwm value, 255 - off, 0 -full throttle</param>
        internal int GetPWM_byFanSpeed(int speedval)
        {
            int pwm = Convert.ToInt32(FanCurve_a * speedval * speedval - FanCurve_b * speedval + FanCurve_c);
            pwm = Math.Min(pwm, 255);
            pwm = Math.Max(pwm, 0);

            return pwm;
        }


        /// <summary>
        /// Set heater pwm value
        /// </summary>
        /// <param name="pwmval">0-255 pwm value</param>
        internal void SetHeaterPWM(int pwmval)
        {
            Logging.AddLog("Setting Heater PWM to " + pwmval, LogLevel.Activity);
            if (UseSimulation)
            {
                HeaterPWM = pwmval;
            }
            else
            {
                WriteSerialData("!HT:" + pwmval.ToString());
            }
        }



        /// <summary>
        /// Make AutoControl CYCLE
        /// </summary>
        public void AutoControl_CYCLE()
        {
            TimeSpan SinceLast_Correction = DateTime.Now.Subtract(AutoControl_LastCorrection);
            UInt32 SinceLast_Correction_sec = (UInt32)Math.Round(SinceLast_Correction.TotalSeconds, 0);

            if (SinceLast_Correction_sec >= AutoControl_Loop_Interval)
            {
                if (AutoControl_FanSpeed) ControlMainDelta();
                if (AutoControl_Heater) ControlSecondaryDelta();

                AutoControl_LastCorrection = DateTime.Now;
            }
        }


        /// <summary>
        /// Main mirror temp delta reaction parameters
        /// </summary>
        public double TempDelta_Main_Target = 0.2; // min temp delta where fan swithced off
        public double TempDelta_Main_MaxEffortZone = 2; // max temp delta where fan swithced fully on
        public double TempDelta_Main_DewZone = 0.1; //dew risk zone

        public int FAN_MaxRotationSpeed = 1300;
        public int FAN_MinRotationSpeed = 160;
        public double FanRotationPowerCurve_a = 28.57;
        public double FanRotationPowerCurve_b = -7.14;
        public double FanRotationPowerCurve_c = -0.003;

        /// <summary>
        /// Procedure to automatically set FanSpeed based on DeltaTemp
        /// </summary>
        public void ControlMainDelta()
        {
            double AvgDeltaTemp_Main = DeltaTemp_Main_List.Average(); 
            int setpwm = 255;

            if (AvgDeltaTemp_Main <= TempDelta_Main_DewZone)
            {
                setpwm = 0; //switch fully on
                Logging.AddLog(String.Format("Main_Tempdelta avg({0:0.00}) is in dew risk zone. Set fan to null", AvgDeltaTemp_Main, setpwm), LogLevel.Activity);
            }
            else if (AvgDeltaTemp_Main <= TempDelta_Main_Target)
            {
                setpwm = 255; //switch off
                Logging.AddLog(String.Format("Main_Tempdelta avg({0:0.00}) is in still zone. Set fan to null", AvgDeltaTemp_Main, setpwm), LogLevel.Activity);
            }
            else if (AvgDeltaTemp_Main >= TempDelta_Main_MaxEffortZone)
            {
                setpwm = 0; //switch fully on
                Logging.AddLog(String.Format("Main_Tempdelta avg({0:0.00}) is too high. Set fan to full", AvgDeltaTemp_Main, setpwm), LogLevel.Activity);
            }
            else
            {
                double power = FanRotationPowerCurve_a * AvgDeltaTemp_Main * AvgDeltaTemp_Main +FanRotationPowerCurve_b * AvgDeltaTemp_Main +FanRotationPowerCurve_c;
                power = Math.Min(power,100);
                power = Math.Max(power,0);

                double approx_rotation = power/100.0 * FAN_MaxRotationSpeed; //calculate approximate fan speed
                if (approx_rotation>0) approx_rotation = Math.Max(approx_rotation, FAN_MinRotationSpeed); //if calculated speed >0 but less min speed, set to min speed

                setpwm = GetPWM_byFanSpeed(Convert.ToInt32(approx_rotation));

                Logging.AddLog(String.Format("Main_Tempdelta avg" + SENSOR_HISTORY_LENGTH + " is {0:0.00}. Set fan to power: {1:0.0}%, target rotation speed: {2:0}rpm, PWM: {3:0}", AvgDeltaTemp_Main, power, approx_rotation, setpwm), LogLevel.Activity);
            
            }
            SetFanPWM(setpwm); 
        }


        
        /// <summary>
        /// Secondary mirror heater reaction parameters
        /// </summary>
        public double TempDelta_Secondary_Target = 2.0; // target temp delta
        public double TempDelta_Secondary_MaxEffortZone = 0.1; // min delta value after which heating is set to 100%
        public double HeatingPowerCurve_a = 22.7;
        public double HeatingPowerCurve_b = -104.5;
        public double HeatingPowerCurve_c = 120.0;
         

        /// <summary>
        /// Procedure to automatically set Heater power based on DeltaTemp
        /// </summary>
        public void ControlSecondaryDelta()
        {
            double DeltaTemp_Second = DeltaTemp_Secondary_List.Average(); 
            int setpwm = 0;

            if (DeltaTemp_Second >= TempDelta_Secondary_Target)
            {
                setpwm = 0; //switch off
                Logging.AddLog(String.Format("Second_Tempdelta avg ({0:0.00}) is enough. Set heater to null", DeltaTemp_Second, setpwm), LogLevel.Activity);
            }
            else if (DeltaTemp_Second <= TempDelta_Secondary_MaxEffortZone)
            {
                setpwm = 255; //switch fully on
                Logging.AddLog(String.Format("Second_Tempdelta avg ({0:0.00}) is too low. Set heater to full", DeltaTemp_Second, setpwm), LogLevel.Activity);
            }
            else
            {
                double power = HeatingPowerCurve_a * DeltaTemp_Second * DeltaTemp_Second + HeatingPowerCurve_b * DeltaTemp_Second + HeatingPowerCurve_c;
                power = Math.Min(power, 100);
                power = Math.Max(power, 0);

                setpwm = Convert.ToInt32(power / 100.0 * 255.0);    //calculate heater pwm
                Logging.AddLog(String.Format("Second_Tempdelta avg" + SENSOR_HISTORY_LENGTH + " is {0:0.00}. Set heater to power: {1:0.0}%, PWM: {2:0}", DeltaTemp_Second, power, setpwm), LogLevel.Activity);
            }
            SetHeaterPWM(setpwm);
        }

        /// <summary>
        /// Save current delta value into list for averaging later
        /// </summary>
        /// <param name="NewValue"></param>
        public void DeltaTemp_Main_Add(double NewValue)
        {
            if (CheckData(NewValue, SensorTypeEnum.Temp))
            { 
                //Add to LastValuesArray
                int startIdx;
                if (DeltaTemp_Main_List.Count < SENSOR_HISTORY_LENGTH)
                {
                    startIdx = DeltaTemp_Main_List.Count() - 1;
                    DeltaTemp_Main_List.Add(-100.0);
                }
                else
                {
                    startIdx = DeltaTemp_Main_List.Count() - 2;
                }
                for (int i = startIdx; i >= 0; i--)
                {
                    DeltaTemp_Main_List[i + 1] = DeltaTemp_Main_List[i];
                }
                DeltaTemp_Main_List[0] = NewValue;
            }
        }

        /// <summary>
        /// Save current delta value into list for averaging later
        /// </summary>
        /// <param name="NewValue"></param>
        public void DeltaTemp_Secondary_Add(double NewValue)
        {
            if (CheckData(NewValue, SensorTypeEnum.Temp))
            { 
                //Add to LastValuesArray
                int startIdx;
                if (DeltaTemp_Secondary_List.Count < SENSOR_HISTORY_LENGTH)
                {
                    startIdx = DeltaTemp_Secondary_List.Count() - 1;
                    DeltaTemp_Secondary_List.Add(-100.0);
                }
                else
                {
                    startIdx = DeltaTemp_Secondary_List.Count() - 2;
                }
                for (int i = startIdx; i >= 0; i--)
                {
                    DeltaTemp_Secondary_List[i + 1] = DeltaTemp_Secondary_List[i];
                }
                DeltaTemp_Secondary_List[0] = NewValue;
            }
        }    
    
    }
}
