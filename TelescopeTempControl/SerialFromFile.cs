using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TelescopeTempControl
{

        /// <summary>
        /// Class with method for working with Weather Station data, getting not from Serial Port, but from file
        /// </summary>
        public static class SerialFromFile
        {

            public static string SerialFileNameIn = "";
            public static string SerialFileNameOut = "";

            public static bool ConsideredOpen = false;

            public static UInt32 _MAX_MODIFICATION_TIMEOUT = 100;

            /// <summary>
            /// Open Serial File Emulation. For succes file must exists
            /// </summary>
            /// <returns>true if it can be opened</returns>
            public static bool Open()
            {
                Logging.AddLog("SerialFromFile Open enter", LogLevel.Debug);
                bool retIsOpened = false;

                if (File.Exists(SerialFileNameIn))
                {
                    retIsOpened = true;
                }
                else
                {
                    retIsOpened = false;
                }

                ConsideredOpen = retIsOpened;
                if (retIsOpened)
                {
                    Logging.AddLog("SerialFileNameIn [" + SerialFileNameIn + "] exists, considered port is opened", LogLevel.Debug);
                }
                else
                {
                    Logging.AddLog("SerialFileNameIn [" + SerialFileNameIn + "] doesn't exist, considered port can't be opened", LogLevel.Debug);
                }

                return retIsOpened;
            }


            /// <summary>
            /// Close Serial File Emulation
            /// </summary>
            /// <returns>true if it can be opened</returns>
            public static bool Close()
            {
                Logging.AddLog("SerialFromFile Close enter", LogLevel.Debug);
                bool retIsClosed = false;

                ConsideredOpen = retIsClosed;

                Logging.AddLog("SerialFromFile Close exit, state = " + retIsClosed, LogLevel.Debug);
                return retIsClosed;
            }



            /// <summary>
            /// Emulated read from port. Checks if file was modified...
            /// </summary>
            /// <returns>Buffer, or empty string if file wasn't modified or even exists</returns>
            public static string Read()
            {
                Logging.AddLog("SerialFromFile Read enter", LogLevel.Debug);
                string st = "";

                if (checkFileModification())
                {
                    st = getBufferFromFile();
                }

                Logging.AddLog("SerialFromFile Read exit", LogLevel.Debug);
                return st;
            }

            /// <summary>
            /// Seconds passed from last file modification
            /// </summary>
            /// <returns></returns>
            public static UInt32 SinceLastModification()
            {
                Logging.AddLog("SinceLastModification enter", LogLevel.Debug);
                UInt32 SinceLastModification_sec = UInt32.MaxValue;
                try
                {
                    if (File.Exists(SerialFileNameIn))
                    {
                        // Get the creation time.
                        DateTime dt = File.GetLastWriteTime(SerialFileNameIn);

                        TimeSpan SinceLastModification = DateTime.Now.Subtract(dt);
                        SinceLastModification_sec = (UInt32)Math.Round(SinceLastModification.TotalSeconds, 0);
                    }
                    else
                    {
                        SinceLastModification_sec = UInt32.MaxValue;
                        Logging.AddLog("Serial file emulation SinceLastModification error - file doesn't exist",LogLevel.Debug,Highlight.Error);
                    }
                }
                catch (Exception ex)
                {
                    Logging.AddLog("SinceLastModification error. " + "IOException source: " + ex.Data + " Mess: " + ex.Message, LogLevel.Important, Highlight.Error);
                }

                Logging.AddLog("SinceLastModification exit", LogLevel.Debug);
                return SinceLastModification_sec;
            }


            /// <summary>
            /// Check file modification date
            /// </summary>
            /// <returns></returns>
            public static bool checkFileModification()
            {
                Logging.AddLog("checkFileModification enter", LogLevel.Debug);
                bool retIsModified = false;

                try
                {
                    if (File.Exists(SerialFileNameIn))
                    {
                        UInt32 SinceLastModification_sec = SinceLastModification();

                        if (SinceLastModification_sec < _MAX_MODIFICATION_TIMEOUT)
                        {
                            retIsModified = true;
                            Logging.AddLog("Serial file emulation modification check ok. Was modified " + SinceLastModification_sec + " sec. ago", LogLevel.Debug);
                        }
                        else
                        {
                            retIsModified = false;
                            Logging.AddLog("Serial file emulation error - file haven't changed for too long (" + SinceLastModification_sec + " sec)",LogLevel.Debug);
                        }
                    }
                    else
                    {
                        retIsModified = false;
                        Logging.AddLog("Serial file emulation error - file doesn't exist",LogLevel.Debug);
                    }
                }
                catch (Exception ex)
                {
                    Logging.AddLog("checkFileModification error. " + "IOException source: " + ex.Data + " Mess: " + ex.Message,LogLevel.Important,Highlight.Error);
                }

                Logging.AddLog("checkFileModification exit", LogLevel.Debug);
                return retIsModified;
            }

            /// <summary>
            /// Get data from file
            /// </summary>
            /// <returns></returns>
            public static string getBufferFromFile()
            {
                Logging.AddLog("getBufferFromFile enter", LogLevel.Debug);
                string st = "";
                bool error = false;
                try
                {
                    if (File.Exists(SerialFileNameIn))
                    {
                        // Get the creation time.
                        st = File.ReadAllText(SerialFileNameIn);
                    }
                    else
                    {
                        Logging.AddLog("Serial File emulation error. File with serial output can't be found",LogLevel.Important,Highlight.Error);
                        error = true;
                    }
                }
                catch (Exception ex)
                {
                    Logging.AddLog("Serial File emulation error. File with serial output can't be read.  IOException source: " + ex.Data + " Mess: " + ex.Message, LogLevel.Important,Highlight.Error);
                    error = true;
                }

                Logging.AddLog("getBufferFromFile exit", LogLevel.Debug);
                return st;
            }

            /// <summary>
            /// Wrapper for writing data to serial port
            /// </summary>
            /// <param name="CommandSt">string with command, which should be sent to Arduino</param>
            public static bool WriteData(string CommandSt)
            {
                Logging.AddLog("SerialFromFile WriteData enter", LogLevel.Debug);

                bool error = false;

                try
                {
                    if (!File.Exists(SerialFileNameOut))
                    {
                        using (StreamWriter outfile = File.CreateText(SerialFileNameOut))
                        {
                            outfile.WriteLine(CommandSt);
                            error = false;
                            Logging.AddLog("Create file for Serial File Emaulation output command " + CommandSt, LogLevel.Debug);
                        }
                    }
                    else
                    {
                        using (StreamWriter outfile = File.AppendText(SerialFileNameOut))
                        {
                            outfile.WriteLine(CommandSt);
                            error = false;
                            Logging.AddLog("Append to existing file for Serial File Emaulation output command " + CommandSt, LogLevel.Debug);
                        }
                    }
                }
                catch
                {
                    Logging.AddLog("SerialFileEmulation [" + SerialFileNameOut + "] output error. Command " + CommandSt + " wasn't sent", LogLevel.Important, Highlight.Error);
                    error = true;
                }

                Logging.AddLog("SerialFromFile WriteData exit", LogLevel.Debug);
                return !error;
            }


        }
}
