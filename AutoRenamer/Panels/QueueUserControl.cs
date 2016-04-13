using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using WeifenLuo.WinFormsUI.Docking;

namespace AutoRenamer.Panels
{
    public partial class QueueUserControl : DockContent
    {
        public ILog Log { get; set; }

        public QueueUserControl()
        {
            InitializeComponent();
        }

    }
}
