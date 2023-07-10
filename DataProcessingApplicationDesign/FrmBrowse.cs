using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace DataProcessingApplicationDesign
{
    public partial class FrmBrowse : Form
    {
        public DataGridView dataGridView;
        public TextBox textBoxSelectPath;
        FrmMain objectMainForm;
        private int row_count = 1;
        private bool[] isRowPaused;

        public FrmBrowse(FrmMain objectSecondForm)
        {
            this.objectMainForm = objectSecondForm;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFileBrowse_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files (*.*)|*.*";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;
                    Icon fileIcon = Icon.ExtractAssociatedIcon(selectedFile);
                    Bitmap fileIconBitmap = fileIcon.ToBitmap();
                    string fileName = Path.GetFileName(selectedFile);
                    FileInfo fileInfo = new FileInfo(selectedFile);
                    long fileSize = fileInfo.Length;
                    DataGridViewImageColumn iconColumn = (DataGridViewImageColumn)objectMainForm.dataGridView.Columns[1];

                    objectMainForm.dataGridView.Rows.Add(null, fileIconBitmap, fileName, null, null, null, fileSize);
                    objectMainForm.dataGridView.Rows[0].Visible = true;
                    objectMainForm.textBoxSelectPath.Text = fileName;
                }
                this.Close();
            }
        }
        private void btnFolderBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderbrowserdialog = new FolderBrowserDialog();

            Icon foldericon = new Icon(@"c:\users\openai\source\repos\dataprocessingapplicationdesign\dataprocessingapplicationdesign\properties\icon.ico");
            if (folderbrowserdialog.ShowDialog() == DialogResult.OK && !string.IsNullOrWhiteSpace(folderbrowserdialog.SelectedPath))
            {
                string folderpath = folderbrowserdialog.SelectedPath;
                string[] filepaths = Directory.GetDirectories(folderpath);
                DirectoryInfo directoryinfo = new DirectoryInfo(folderpath);
                long foldersize = 0;
                foreach (FileInfo fileinfo in directoryinfo.GetFiles("*", SearchOption.AllDirectories))
                {
                    foldersize += fileinfo.Length;
                }
                objectMainForm.dataGridView.Rows.Add(null, foldericon.ToBitmap(), folderpath, null, null, null, foldersize);
                objectMainForm.textBoxSelectPath.Text = folderpath;
            }
            this.Close();
        }
    }
}
