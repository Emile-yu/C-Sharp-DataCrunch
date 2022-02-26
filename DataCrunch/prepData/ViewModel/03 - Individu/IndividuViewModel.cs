using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace ViewModel
{
    public class IndividuViewModel : AViewModel
    {
        private static String s_titre = "Individu";

        public override string _treatmentsHeader { get { return s_titre; } }

        #region Binding

        private String _begin;
        public String Begin
        {
            get { return this._begin; }
            set
            {
                this._begin = value;
                this.RaisePropertyChanged();
            }
        }
        private String _end;
        public String End
        {
            get { return this._end; }
            set
            {
                this._end = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

        #region constructor
        public IndividuViewModel()
        {

        }

        #endregion

        #region operations override
        protected override void TreatmentLaunch()
        {
            IndividuFile individuFile = new IndividuFile(this.DataFilePath, worker, Int32.Parse(this.Begin), Int32.Parse(this.End));
            individuFile.ExportFile();

        }

        protected override void OnBrowshDataPathCommand(object parmater)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.DataFilePath = openFileDialog.FileName;
                this.OutputPathName = Path.GetFullPath(FilePathManager.getInstance().getPathName(DataType.Individu, this.DataFilePath));

            }
        }
        #endregion
    }
}
