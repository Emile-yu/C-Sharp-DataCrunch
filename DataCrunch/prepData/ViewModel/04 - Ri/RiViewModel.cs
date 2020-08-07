using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tools;

namespace ViewModel
{
    public class RiViewModel : AViewModel
    {
        private static String s_titre = "Ri";

        public override string _treatmentsHeader { get { return s_titre; } }

        #region Binging

        private String _descrFilePath;
        public String DescrFilePath
        {
            get { return this._descrFilePath; }
            set
            {
                this._descrFilePath = value;
                this.RaisePropertyChanged();
            }
        }

        private ICommand _browseInputDescrFilePathCommand;
        public ICommand BrowseInputDescrFilePathCommand
        {
            get { return this._browseInputDescrFilePathCommand; }
            set
            {
                this._browseInputDescrFilePathCommand = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion



        #region constructor

        public RiViewModel()
        {

            this.BrowseInputDescrFilePathCommand = new ActionCommand(OnBrowshDescrFilePathCommand);
        }
        #endregion


        #region operation
        private void OnBrowshDescrFilePathCommand()
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.DescrFilePath = openFileDialog.FileName;
                this.OutputPathName = Path.GetFullPath(FilePathManager.getInstance().getPathName(DataType.Ri, this.DescrFilePath));
            }
        }
        #endregion

        #region operations override
        protected override void OnBrowshDataPathCommand()
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.DataFilePath = openFileDialog.FileName;

            }
        }

        protected override bool IsPathName()
        {
            return !String.IsNullOrEmpty(this.DescrFilePath) && !String.IsNullOrEmpty(this.DataFilePath);
        }

        protected override void TreatmentLaunch()
        {
            RiFile file = new RiFile(this.DescrFilePath, this.DataFilePath);
            file.worker = worker;
            file.ExportFile();
        }

        #endregion

    }
}
