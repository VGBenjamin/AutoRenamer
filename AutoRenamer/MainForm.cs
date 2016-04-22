using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoRenamer.BOL.Config;
using AutoRenamer.BOL.Log4Net;
using AutoRenamer.BOL.Objects;
using AutoRenamer.BOL.Objects.TasksQueue;
using AutoRenamer.Panels;
using AutoRenamer.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace AutoRenamer
{
    public partial class MainForm : Form
    {
        #region variables
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private FiltersUserControl _filtersUserControl;
        private QueueUserControl _queueUserControl;
        private LogUserControl _logUserControl;
        private MainUserControl _mainUserControl;
        private TasksQueueManager _tasksQueueManager;

        public Synchronization CurrentSynchronization { get; set; }
        private SynchronizationFactory _synchronizationFactory;

        public int SelectedGridRow { get; set; }
        

        #region menu properties
        public ContextMenu GridContextMenu { get; set; }
        public MenuItem ExcludeMenuItem { get; set; }
        public MenuItem ResetStatusMenuItem { get; set; }
        public MenuItem ExploreMenuItem { get; set; }
        public MenuItem SynchronizeNow { get; set; }
        #endregion
        #endregion

        #region Loading
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            AddDocContents();
           
            InitializeComponent();
            log.Debug("Loading");
            InitSynchronizationFactory();
            LoadCurrentSynchronization();

            log.Debug($"Filebot expression: {AutoRenamerConfig.Instance.FilebotExpression.Value}");
        }

        private void InitSynchronizationFactory()
        {
            _synchronizationFactory = new SynchronizationFactory();
            _synchronizationFactory.OnFolderLoading += SynchronizationFactory_OnFolderLoading;
            _synchronizationFactory.OnFolderLoaded += SynchronizationFactory_OnFolderLoaded;
            _synchronizationFactory.OnFileLoaded += SynchronizationFactory_OnFileLoaded;
        }

        private void LoadCurrentSynchronization()
        {
            CurrentSynchronization =
                _synchronizationFactory.GetSynchronizationFromFileAndDisk(AutoRenamerConfig.Instance.TreatedXMlPath);

            _mainUserControl.CurrentSynchronization = CurrentSynchronization;
        }

        private void SynchronizationFactory_OnFileLoaded(object sender, BOL.Objects.EventArgs.FileLoadedEventArgs e)
        {
            IncrementProgress();
        }

        private void SynchronizationFactory_OnFolderLoaded(object sender, BOL.Objects.EventArgs.FolderLoadedEventArgs e)
        {
            if(e.CurrentFolderNumber == e.TotalNumberOfFolders)
                HideStatusText();
        }

        private void SynchronizationFactory_OnFolderLoading(object sender, BOL.Objects.EventArgs.FolderLoadingEventArgs e)
        {
            DisplayStatusText($"Loading files from folder {e.FolderPath} ({e.CurrentFolderNumber}/{e.TotalNumberOfFolders}", 0, e.NumberOfFiles);
        }

        private void AddDocContents()
        {
            _tasksQueueManager = new TasksQueueManager();

            var theme = new VS2012LightTheme();
            this.dockPanel.Theme = theme;
            this.dockPanel.DocumentStyle = DocumentStyle.DockingSdi;

            _queueUserControl = new QueueUserControl(_tasksQueueManager.TasksQueue);
            _queueUserControl.Show(this.dockPanel, DockState.DockRight);

            _logUserControl = new LogUserControl();
            _logUserControl.Show(this.dockPanel, DockState.DockBottom);

            _filtersUserControl = new FiltersUserControl();
            _filtersUserControl.Show(this.dockPanel, DockState.DockLeft);
            _filtersUserControl.OnFilterChanged += FiltersUserControlOnOnFilterChanged;

            _mainUserControl = new MainUserControl();
            _mainUserControl.Tasks = _tasksQueueManager.TasksQueue;
            _mainUserControl.Show(this.dockPanel, DockState.Document);
            _mainUserControl.OnSynchRebinded += _mainUserControl_OnSynchRebinded;
        }

        private void _mainUserControl_OnSynchRebinded(object sender, EventArgs e)
        {
            _filtersUserControl.FilterGrid(_mainUserControl.MainGrid);
        }

        private void FiltersUserControlOnOnFilterChanged(object sender, EventArgs eventArgs)
        {
            _filtersUserControl.FilterGrid(_mainUserControl.MainGrid);
        }

        #endregion

        #region status bar
        private void IncrementProgress()
        {
            tsslStatusProgressBar.Value++;
        }

        public void DisplayStatusText(string statusText, int min, int max)
        {
            tsslStatusText.Visible = true;
            tsslStatusProgressBar.Visible = true;
            tsslStatusText.Text = statusText;
            tsslStatusProgressBar.Minimum = min;
            tsslStatusProgressBar.Maximum = max;
            tsslStatusProgressBar.Value = min;
        }

        public void HideStatusText()
        {
            tsslStatusText.Visible = false;
            tsslStatusProgressBar.Visible = false;
        }
        #endregion


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CurrentSynchronization.Save();
            dockPanel.SaveAsXml(AutoRenamerConfig.Instance.);
        }

        private void tsRefresh_Click(object sender, EventArgs e)
        {
            
        }

        private void displayBaseSourceDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadCurrentSynchronization();
            _mainUserControl.RefreshGrid();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentSynchronization.Save();
        }

        private void sourceDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mainUserControl.DisplaySourceDirectory = sourceDirectoryToolStripMenuItem.Checked = !sourceDirectoryToolStripMenuItem.Checked;
        }

        private void destinationDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mainUserControl.DisplayDestinationDirectory = destinationDirectoryToolStripMenuItem.Checked = !destinationDirectoryToolStripMenuItem.Checked;
        }
    }
}
