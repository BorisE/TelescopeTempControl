using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace TelescopeTempControl
{
    static class Program
    {

        /// <summary>
        /// Mutex for controlling one app instance
        /// </summary>
        public static Mutex mutex = new Mutex(true, "{eebfa9bc-4c14-4c6b-9f69-efe0f0011833}");
        
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
        
            if(mutex.WaitOne(TimeSpan.Zero, true)) 
            {
                //If program isn't already run...
                
                //Import settings from previously compiled versions
                AuxilaryProc.UpgradeSettings();

                //If it is first run chek for setup
                AuxilaryProc.CreateAutoStartLink();

                if (Environment.OSVersion.Version.Major >= 6) SetProcessDPIAware();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
                mutex.ReleaseMutex();
            }
            else
            {
                //if already run - set window to foreground
                Utils.SetCurrentWindowToForeground();
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}
