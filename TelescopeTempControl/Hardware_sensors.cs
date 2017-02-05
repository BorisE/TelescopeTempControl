using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelescopeTempControl
{
    /// <summary>
    /// Custom data types
    /// </summary>
    #region Custom data types for Sensors, Boltwood and so on

    /// <summary>
    /// Sensor type
    /// </summary>
    public enum SensorTypeEnum { Temp, Press, Hum, Illum, Wet, RGC, Relay, WSp, Heater, RPM, PWM};

    /// <summary>
    /// Sensor element class
    /// </summary>
    public class SensorElement
    {
        public string SensorName = "";        //Sensor Name
        public SensorTypeEnum SensorType;   //Sensor Type
        public bool Enabled = true;         //Sensor Enabled flag
        public bool SendToWebFlag = true;
        public bool SendToNarodMon = false;
        public string SensorArduinoField = "";
        public string WebCustomName = "";
        public string NarodMonID = "";
        public string SensorFormField = "";

        public double LastValue = -100.0;
        public DateTime LastValueReadTime = DateTime.MinValue;

        public double MinValue = Int32.MaxValue;
        public DateTime MinValueSetTime = DateTime.MinValue;
        public double MaxValue = Int32.MinValue;
        public DateTime MaxValueSetTime = DateTime.MinValue;

        private const byte SENSOR_HISTORY_LENGTH = 25; //approx 5 min (25 * 14.3 sec)
        public List<double> ValuesLastFiveMin = new List<double>();
        public double AverageHistoryValues = -100.0;
        public int ValuesCount = 0;

        public double AverageBetweenDataSend_Narodmon_SUM = 0.0;
        public int AverageBetweenDataSend_Narodmon_COUNT = 0;

        public double AverageBetweenDataSend_Web_SUM = 0.0;
        public int AverageBetweenDataSend_Web_COUNT = 0;

        //Method for adding values
        public void AddValue(double NewValue)
        {
            //LastValue
            LastValue = NewValue;
            LastValueReadTime = DateTime.Now;
            ValuesCount++;

            //Add to LastValuesArray
            int startIdx;
            if (ValuesLastFiveMin.Count < SENSOR_HISTORY_LENGTH)
            {
                startIdx = ValuesLastFiveMin.Count() - 1;
                ValuesLastFiveMin.Add(-100.0);
            }
            else
            {
                startIdx = ValuesLastFiveMin.Count() - 2;
            }
            for (int i = startIdx; i >= 0; i--)
            {
                ValuesLastFiveMin[i + 1] = ValuesLastFiveMin[i];
            }
            ValuesLastFiveMin[0] = NewValue;

            //check if extreme values?
            if (NewValue < MinValue)
            {
                MinValue = NewValue;
                MinValueSetTime = DateTime.Now;
            }
            if (NewValue > MaxValue)
            {
                MaxValue = NewValue;
                MaxValueSetTime = DateTime.Now;
            }

            //Average in last stored values
            AverageHistoryValues = ValuesLastFiveMin.Average();

            //Average between sendings Web
            AverageBetweenDataSend_Web_SUM += NewValue;
            AverageBetweenDataSend_Web_COUNT++;

            //Average between sendings Narodmon
            AverageBetweenDataSend_Narodmon_SUM += NewValue;
            AverageBetweenDataSend_Narodmon_COUNT++;
        }

        //Method for clearing data between sendings WEB
        public void ClearValuesWeb()
        {
            AverageBetweenDataSend_Web_SUM = 0;
            AverageBetweenDataSend_Web_COUNT = 0;
        }

        //Method for clearing data between sendings NARODMON
        public void ClearValuesNarodmon()
        {
            AverageBetweenDataSend_Narodmon_SUM = 0;
            AverageBetweenDataSend_Narodmon_COUNT = 0;
        }
        //Note, that Last Five Min - approximate value, it can be changed
        public double AverageLastFiveMin()
        {
            //return ValuesLastFiveMin.Average();
            return 0;
        }


        /// <summary>
        /// Method to check data validity for different sensors type
        /// </summary>      
        public bool CheckLastValue()
        {
            double TagVal = LastValue;
            return Hardware.CheckData(LastValue, SensorType);
        }
    }

    /// <summary>
    /// Settings element (TD, WT, RT)
    /// </summary>
    public class ArduinoSettingsClass
    {
        public string Value = "";
        public DateTime ReadTime = new DateTime();
    }

    #endregion

    /// <summary>
    /// TelescopeTempControl data fields
    /// </summary>        
    public class TelescopeTempControlData
    {
        public DateTime LastTimeDataParsed;

        public double FAN_RPM = -1; //rpm 0 - 1300
        public double FAN_FPWM = -1; //0-255
        public double HeaterPower = -1; //0-100
        public double HeaterPWM = -1; //0-255
        public bool AutoControl_FanSpeed = false;
        public bool AutoControl_Heater = false;

        public double Temp = -100.0;
        public double Humidity = -1.0;
        public double DHT_Temp = -100.0;

        public double MainMirrorTemp = -100.0;
        public double SecondMirrorTemp = -100.0;

        public double DeltaTemp_Main = -100.0;
        public double DeltaTemp_Secondary = -100.0;
        public double DewPoint = -100.0;
    }

    public partial class Hardware
    {
        public void initSensorList()
        {
            Logging.AddLog("initSensorList enter", LogLevel.Trace);

            //Clear current values
            SensorsList.Clear();

            SensorElement SensorEl = new SensorElement();

            //DHT22_1
            SensorEl = new SensorElement();
            SensorEl.SensorName = "Hum1";
            SensorEl.SensorType = SensorTypeEnum.Hum;
            SensorEl.Enabled = true;
            SensorEl.SendToWebFlag = true;
            SensorEl.SendToNarodMon = true;
            SensorEl.SensorFormField = "txtFldHumidity";
            SensorEl.SensorArduinoField = "DH1";
            SensorEl.WebCustomName = "dh";
            SensorsList.Add(SensorEl.SensorName, SensorEl);

            SensorEl = new SensorElement();
            SensorEl.SensorName = "DTemp1";
            SensorEl.SensorType = SensorTypeEnum.Temp;
            SensorEl.Enabled = true;
            SensorEl.SendToWebFlag = true;
            SensorEl.SendToNarodMon = false;
            SensorEl.SensorFormField = "txtFldDTemp";
            SensorEl.SensorArduinoField = "DT1";
            SensorEl.WebCustomName = "dt";
            SensorsList.Add(SensorEl.SensorName, SensorEl);

            //OneWire temp
            SensorEl = new SensorElement();
            SensorEl.SensorName = "Temp1";
            SensorEl.SensorType = SensorTypeEnum.Temp;
            SensorEl.Enabled = true;
            SensorEl.SendToWebFlag = true;
            SensorEl.SendToNarodMon = true;
            SensorEl.SensorFormField = "txtFldTemp1";
            SensorEl.SensorArduinoField = "Te1";
            SensorEl.WebCustomName = "owt1";
            SensorsList.Add(SensorEl.SensorName, SensorEl);

            SensorEl = new SensorElement();
            SensorEl.SensorName = "Temp2";
            SensorEl.SensorType = SensorTypeEnum.Temp;
            SensorEl.Enabled = true;
            SensorEl.SendToWebFlag = true;
            SensorEl.SendToNarodMon = true;
            SensorEl.SensorFormField = "txtFldTemp2";
            SensorEl.SensorArduinoField = "Te2";
            SensorEl.WebCustomName = "owt2";
            SensorsList.Add(SensorEl.SensorName, SensorEl);

            SensorEl = new SensorElement();
            SensorEl.SensorName = "Temp3";
            SensorEl.SensorType = SensorTypeEnum.Temp;
            SensorEl.Enabled = true;
            SensorEl.SendToWebFlag = true;
            SensorEl.SendToNarodMon = true;
            SensorEl.SensorFormField = "txtFldTemp3";
            SensorEl.SensorArduinoField = "Te3";
            SensorEl.WebCustomName = "owt3";
            SensorsList.Add(SensorEl.SensorName, SensorEl);

            //Relay1
            SensorEl = new SensorElement();
            SensorEl.SensorName = "RL1";
            SensorEl.SensorType = SensorTypeEnum.Relay;
            SensorEl.Enabled = true;
            SensorEl.SendToWebFlag = true;
            SensorEl.SendToNarodMon = true;
            SensorEl.SensorFormField = "";
            SensorEl.SensorArduinoField = "RL1";
            SensorEl.WebCustomName = "rl1";
            SensorsList.Add(SensorEl.SensorName, SensorEl);

            //RPM
            SensorEl = new SensorElement();
            SensorEl.SensorName = "RPM";
            SensorEl.SensorType = SensorTypeEnum.RPM;
            SensorEl.Enabled = true;
            SensorEl.SendToWebFlag = true;
            SensorEl.SendToNarodMon = true;
            SensorEl.SensorFormField = "txtFldRPM";
            SensorEl.SensorArduinoField = "RPM";
            SensorEl.WebCustomName = "RPM";
            SensorsList.Add(SensorEl.SensorName, SensorEl);

            //PWM
            SensorEl = new SensorElement();
            SensorEl.SensorName = "FPWM";
            SensorEl.SensorType = SensorTypeEnum.PWM;
            SensorEl.Enabled = true;
            SensorEl.SendToWebFlag = true;
            SensorEl.SendToNarodMon = true;
            SensorEl.SensorFormField = "";
            SensorEl.SensorArduinoField = "Pwm";
            SensorEl.WebCustomName = "FPWM";
            SensorsList.Add(SensorEl.SensorName, SensorEl);

            //Heater
            SensorEl = new SensorElement();
            SensorEl.SensorName = "Heater";
            SensorEl.SensorType = SensorTypeEnum.PWM;
            SensorEl.Enabled = true;
            SensorEl.SendToWebFlag = true;
            SensorEl.SendToNarodMon = true;
            SensorEl.SensorFormField = "txtFldHeaterPWM";
            SensorEl.SensorArduinoField = "Ht";
            SensorEl.WebCustomName = "Ht";
            SensorsList.Add(SensorEl.SensorName, SensorEl);


            //Make hash tables
            int SensIdx = -1;
            SensorsArrayHashArduino.Clear();
            foreach (SensorElement DataSensor in SensorsList.Values)
            {
                SensIdx++;
                if (DataSensor != null)
                {
                    SensorsArrayHashArduino.Add(DataSensor.SensorArduinoField, SensIdx);
                }
            }

            //set base temp
            //BaseTempVal = SensorsList[BaseTempName].LastValue;

            Logging.AddLog("initSensorList exit", LogLevel.Trace);

        }


        /// <summary>
        /// Init command interpretator
        /// </summary>
        public void InitComandInterpretator()
        {
            Logging.AddLog("InitComandInterpretator enter", LogLevel.Trace);

            string[] Params = new string[0];

            //CommandParser.Commands.Add("GET_BASETEMP", () => this.getBaseTemp());
            //CommandParser.Commands.Add("GET_SENSOR_VALUES", () => this.getSensorsString());
            CommandParser.Commands.Add("GET_DATA_JSON", (a) => this.getDataJSONString());

            CommandParser.Commands.Add("SET_FAN", (a) => this.setFanPWR_FromSocket(a));
            CommandParser.Commands.Add("SET_HEATER", (a) => this.setHeaterPWR_FromSocket(a));

            CommandParser.Commands.Add("SET_FAN_AUTOCONTROL", (a) => this.setFanControl_FromSocket(a));
            CommandParser.Commands.Add("SET_HEATER_AUTOCONTROL", (a) => this.setHeaterControl_FromSocket(a));


            CommandParser.Commands.Add("HELP", (a) => CommandParser.ListCommands());
            CommandParser.Commands.Add("VERSION", (a) => VersionData.getVersionString());

            Logging.AddLog("InitComandInterpretator exit", LogLevel.Trace);
        }

    }

}
