using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoRenamer.BOL.Log4Net;
using log4net;
using WeifenLuo.WinFormsUI.Docking;

namespace AutoRenamer.Panels
{
    public partial class LogUserControl : DockContent
    {
        private readonly LogWatcher _logWatcher;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LogUserControl()
        {
            _logWatcher = new LogWatcher();
            _logWatcher.Updated += LogWatcherOnUpdated;

            InitializeComponent();                        
        }


        #region Logs
        private void LogWatcherOnUpdated(object sender, EventArgs eventArgs)
        {
            UpdateLogTextbox(_logWatcher.LogContent);
        }

        public void UpdateLogTextbox(string value)
        {
            // Check whether invoke is required and then invoke as necessary
            if (InvokeRequired)
            {

                this.BeginInvoke(new Action<string>(UpdateLogTextbox), new object[] { value });
                return;
            }

            // Set the textbox value
            rtbLog.Text = value;
        }
        private void rtbLog_TextChanged(object sender, EventArgs e)
        {
            rtbLog.ScrollToCaret();
        }
        #endregion
    }
}
