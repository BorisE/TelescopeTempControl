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


        }
    }
}
