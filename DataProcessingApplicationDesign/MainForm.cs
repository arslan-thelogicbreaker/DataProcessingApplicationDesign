using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DataProcessingApplicationDesign
{
    public partial class MainForm : Form
    {
        FileFolderSelectedForm objectForm;
        private System.Windows.Forms.Timer timer;
        private int progressValue;
        private bool isPaused;
 
        public MainForm()
        {
            objectForm = new FileFolderSelectedForm(this);

            InitializeComponent();
            InitializeProgressBar();
            isPaused = false;

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dataGridView.Rows[0].Cells[3].Value = "Browse";
            dataGridView.Columns[4].DefaultCellStyle.NullValue = "Clear";
            dataGridView.Columns[5].DefaultCellStyle.NullValue = "Start";
            dataGridView.Columns["columnClearCancelButton"].ReadOnly = false;
            dataGridView.Columns["columnStartPauseContinueButton"].ReadOnly = false;

            dataGridView.ReadOnly = false;
        }

        private void InitializeProgressBar()
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
            progressValue = 0;
        }

        private void StartProgressBar()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick;
            timer.Start();
            if (progressBar.Value == progressBar.Maximum)
            {
                progressBar.Text = @"Progress Completed";
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressValue < progressBar.Maximum)
            {
                progressValue++;
                progressBar.Value = progressValue;
            }
            else
            {
                StopProgressBar();
            }
        }

        private void PauseProgressBar()
        {
            timer.Stop();
            isPaused = true;
        }
        private void ContinueProgressBar()
        {
            timer.Start();
            isPaused = false;
        }
        private void StopProgressBar()
        {
            timer.Stop();
            progressValue = 0;
            progressBar.Value = progressValue;
            this.BackgroundImage = null;
        }


        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int imgaeRowIndex = e.RowIndex;
            int startIndex = e.RowIndex;
            int endIndex = startIndex + e.RowCount - 1;
            for (int rowIndex = startIndex; rowIndex <= endIndex; rowIndex++)
            {
                foreach (DataGridViewCell cell in dataGridView.Rows[rowIndex].Cells)
                {
                    cell.Style.BackColor = System.Drawing.Color.AliceBlue;
                    cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].Cells["columnSerialNumber"].Value = (i + 1).ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonSelectPath_Click(object sender, EventArgs e)
        {
            string filePath = textBoxSelectPath.Text.ToString();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save File";
            saveFileDialog.FileName = Path.GetFileName(filePath);
            saveFileDialog.Filter = "All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string destinationPath = saveFileDialog.FileName;
                File.Copy(filePath, destinationPath);
                textBoxSelectPath.Text = destinationPath;
                MessageBox.Show("File saved to the new location.");
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell selectedCell = dataGridView.Rows[e.RowIndex].Cells["columnFile"];
                string cellValue = selectedCell.Value?.ToString();
                textBoxSelectPath.Text = cellValue;
            }
        }

       

        private void checkBoxOriginalPath_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOriginalPath.Checked)
            {
                textBoxSelectPath.Text = "Default Path";
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if ((e.ColumnIndex == dataGridView.Columns["cmdBrowsRemove"].Index) && e.RowIndex >= 0)
            {
                string clickedCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (clickedCell != null)
                {
                    switch (clickedCell) {
                        case "Browse":
                            objectForm.ShowDialog();
                            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Remove";
                            dataGridView.Refresh();
                            break;
                        case "Remove":
                            dataGridView.Rows.RemoveAt(e.RowIndex);
                            dataGridView.Refresh();
                            break;
                    }
                }
            }

            if (e.ColumnIndex == dataGridView.Columns["columnClearCancelButton"].Index && e.RowIndex >= 0)
            {
                string clickedCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (clickedCell != null)
                {
                    switch (clickedCell) {
                        case "Clear":
                            dataGridView.Rows.RemoveAt(e.RowIndex);
                            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Cancel";
                            dataGridView.Refresh();
                            break;
                        case "Cancel":
                            this.Close();
                            break;
                    }
                }
            }

            if (e.ColumnIndex == dataGridView.Columns["columnStartPauseContinueButton"].Index && e.RowIndex >= 0)
            {
                string clickedCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                if (clickedCell != null)
                {
                    switch (clickedCell)
                    {
                        case "Start":
                            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Pause";
                            if (timer == null || !timer.Enabled)
                            {
                                StartProgressBar();
                                progressBar.Text = @"Started";
                            }
                            dataGridView.Refresh();
                            break;

                        case "Pause":
                            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Continue";
                            PauseProgressBar();
                            progressBar.Text = @"Paused";
                            MessageBox.Show("Operation Paused");
                            dataGridView.Refresh();
                            break;
                        case "Continue":
                            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Pause";
                            ContinueProgressBar();
                            progressBar.Text = @"Continued";
                            MessageBox.Show("Operation Continued");
                            dataGridView.Refresh();
                            break;
                    }
                }
            }
        }

    }
}
