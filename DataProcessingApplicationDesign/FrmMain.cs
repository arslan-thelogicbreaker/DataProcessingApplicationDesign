using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DataProcessingApplicationDesign
{
    public partial class FrmMain : Form
    {
        FrmBrowse objectForm;
        private System.Windows.Forms.Timer timer;
        private int progressValue;
        private bool isPaused;
 
        public FrmMain()
        {
            objectForm = new FrmBrowse(this);

            InitializeComponent();
            InitializeProgressBar();
            isPaused = false;

            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
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
                dataGridView.Rows[i].Cells["colSrNo"].Value = (i + 1).ToString();
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
                DataGridViewCell selectedCell = dataGridView.Rows[e.RowIndex].Cells["colFileName"];
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
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell clickedCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (clickedCell.OwningColumn.Name == "cmdBrowsRemove")
                {
                    if (clickedCell.Value.ToString().Contains("Browse"))
                    {
                        objectForm.ShowDialog();
                        clickedCell.Value = "Remove";
                        dataGridView.Refresh();
                    }
                    else if (clickedCell.Value.ToString() == "Remove")
                    {
                        if (e.RowIndex > 0 && e.ColumnIndex > 0)
                        {
                            dataGridView.Rows.RemoveAt(e.RowIndex - 1);
                        }
                        else {
                            MessageBox.Show("No Row/s found!");
                            clickedCell.Value = "Browse";
                            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Browse";
                            dataGridView.Refresh();
                        } 
                    }
                }
                else if (clickedCell.OwningColumn.Name == "cmdClearCancel")
                {
                    if (clickedCell.Value.ToString() == "Clear")
                    {
                        MessageBox.Show("Cleared");
                        dataGridView.Rows[0].Cells[3].Value = "Browse";
                        dataGridView.Rows[0].Cells[4].Value = "Cancel";
                        dataGridView.Rows[0].Cells[5].Value = "Start";
                        dataGridView.Refresh();
                    }
                    else if (clickedCell.Value.ToString() == "Cancel")
                    {
                        StopProgressBar();
                        clickedCell.Value = "Clear";
                    }
                }
                else if (clickedCell.OwningColumn.Name == "cmdStartPauseContinue")
                {
                    if (clickedCell.Value.ToString() == "Start")
                    {
                            if (timer == null || !timer.Enabled)
                            {
                                StartProgressBar();
                                progressBar.Text = "Started...";
                                clickedCell.Value = "Pause";

                            dataGridView.Refresh();
                            }
                        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Pause";
                    }
                    else if (clickedCell.Value.ToString() == "Pause")
                    {
                        if (timer != null && timer.Enabled)
                        {
                            PauseProgressBar();
                            progressBar.Text = "Paused...";
                        }
                        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Continue";
                        dataGridView.Refresh();
                    }
                    else if (clickedCell.Value.ToString() == "Continue")
                    {
                        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Pause";
                        ContinueProgressBar();
                        progressBar.Text = "Continued...";
                    }
                }

                dataGridView.Refresh();
            }
        }

        private void dataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["cmdBrowsRemove"].Value = "Browse";
            e.Row.Cells["cmdClearCancel"].Value = "Clear";
            e.Row.Cells["cmdStartPauseContinue"].Value = "Start";
        }
    }
}
