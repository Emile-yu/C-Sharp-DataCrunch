using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tools;

namespace ViewModel
{
    public abstract class AViewModel : ViewModelBase
    {
        #region Binging
        public String TreatmentsSelectionHeader
        {
            get { return _treatmentsHeader; }
        }

        private String _dataFilePath;
        public String DataFilePath
        {
            get { return this._dataFilePath; }
            set
            {
                this._dataFilePath = value;
                this.RaisePropertyChanged();
            }
        }

        private String _outputPathName;
        public String OutputPathName
        {
            get { return this._outputPathName; }
            set
            {
                this._outputPathName = value;
                this.RaisePropertyChanged();
            }
        }

        private bool _isFinish;
        public bool IsFinish
        {
            get { return this._isFinish; }
            set
            {
                this._isFinish = value;
                this.RaisePropertyChanged();
            }
        }

        private ICommand _browseInputDataPathCommand;
        public ICommand BrowseInputDataPathCommand
        {
            get { return this._browseInputDataPathCommand; }
            set
            {
                this._browseInputDataPathCommand = value;
                this.RaisePropertyChanged();
            }
        }

        private ICommand _browseOutputPathCommand;
        public ICommand BrowseOutputPathCommand
        {
            get { return this._browseOutputPathCommand; }
            set
            {
                this._browseOutputPathCommand = value;
                this.RaisePropertyChanged();
            }
        }

        private ICommand _treatmentLaunchCommand;
        public ICommand TreatmentLaunchCommand
        {
            get { return this._treatmentLaunchCommand; }
            set
            {
                this._treatmentLaunchCommand = value;
                this.RaisePropertyChanged();
            }
        }

        private ObservableCollection<LogItem> _phaseLogs = new ObservableCollection<LogItem>();
        public ObservableCollection<LogItem> PhaseLogs
        {
            get { return _phaseLogs; }
            set
            {
                _phaseLogs = value;
                this.RaisePropertyChanged();
            }
        }

        public String PhasesLoggerTitle
        {
            get { return s_phasesLoggerTitle; }
        }

        public String TreatmentLaunchButtonTitle
        {
            get { return s_treatmentLaunchButtonTitle; }
        }
        #endregion

        #region membres private
        protected readonly BackgroundWorker worker = new BackgroundWorker();
        #endregion

        #region membres static

        private static String s_phasesLoggerTitle = "Traitements en cours";
        private static String s_treatmentLaunchButtonTitle = "Lancer le traitement";

        #endregion

        #region constructor
        public AViewModel()
        {

            worker.WorkerReportsProgress = true;
            worker.DoWork += WorkerDoWork;
            worker.ProgressChanged += WorkerProgressChanged;
            worker.RunWorkerCompleted += WorkerCompleted;

            this.BrowseInputDataPathCommand = new ActionCommand(OnBrowshDataPathCommand);
            this.TreatmentLaunchCommand = new ActionCommand(OnStart, this.IsPathName);
            //this.SplitCommand = new QueryCommand(OnSplitCommand, this.IsPathName);
            this.IsFinish = false;


        }


        #endregion

        #region abstract membre
        public abstract String _treatmentsHeader { get; }
        #endregion

        #region abstract operation

        protected abstract void TreatmentLaunch();

        protected abstract void OnBrowshDataPathCommand(object parmater);

        #endregion

        #region operations

        private void OnStart(object parmater)
        {
            worker.RunWorkerAsync();
        }

        private void WorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.PhaseLogs.Add(new LogItem("Le traitement est terminé"));
        }

        private void WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            DataLogs logData = e.UserState as DataLogs;

            if (logData != null)
            {
                switch (logData.Type)
                {
                    case LogType.None:
                        this.PhaseLogs.Add(new LogItem(logData.Message));
                        break;
                    case LogType.Success:
                        if (this.PhaseLogs.Count > 0)
                            this.PhaseLogs[PhaseLogs.Count - 1] = new LogItem(logData.Message);
                        break;
                    default:
                        break;
                }
                
            }
        }


        private void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            TreatmentLaunch();

        }

        public void Dispose()
        {
            worker.Dispose();
            GC.SuppressFinalize(this);
        }


        protected virtual bool IsPathName(object parmater)
        {
            return !String.IsNullOrEmpty(this.DataFilePath) && this.IsFinish == false;
        }

        #endregion
    }
}
