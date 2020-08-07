using Model.Support;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace ViewModel
{
    public class SupportViewModel : AViewModel
    {
        private static String s_titre = "Support";

        public override string _treatmentsHeader { get { return s_titre; } }

        #region constructor
        public SupportViewModel()
        {

        }

        protected override void TreatmentLaunch()
        {
            SupportFile supportFile = new SupportFile(this.DataFilePath);
            supportFile.worker = worker;
            supportFile.ExportFile();
            //supportFile.ExportFile(worker.ReportProgress);
        }

        protected override void OnBrowshDataPathCommand()
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.DataFilePath = openFileDialog.FileName;
                this.OutputPathName = Path.GetFullPath(FilePathManager.getInstance().getPathName(DataType.Support, DataFilePath));
            }
            /*FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                this.InputPathName = String.Format("{0}\\", dialog.SelectedPath);
                */
        }


        #endregion
    }
}
