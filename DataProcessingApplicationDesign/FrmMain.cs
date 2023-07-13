
using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace DataProcessingApplicationDesign
{
    public delegate void LoopStatusCallback(int status);

    public partial class FrmMain : Form
    {
        [DllImport("MainFileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void ShowMessageBox(string message, string title);

        [DllImport("MainFileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PerformLoop(int iterations, LoopStatusCallback callback);

        static void LoopStatusHandler(int status)
        {
            FrmMain form = Application.OpenForms[0] as FrmMain;
            form.UpdateRichTextBox("Loop status: " + status + Environment.NewLine);
        }

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
            dataGridView.ReadOnly = true;

        }
        public void UpdateRichTextBox(string text)
        {
            if (richTextBox.InvokeRequired)
            {
                richTextBox.Invoke(new Action<string>(UpdateRichTextBox), text);
            }
            else
            {
                richTextBox.AppendText(text);
            }
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

        private void dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int i = e.RowIndex; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].Cells["colSrNo"].Value = (i + 1).ToString();
            }
        }

        private void dataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["cmdBrowsRemove"].Value = "Browse";
            e.Row.Cells["cmdClearCancel"].Value = "Clear";
            e.Row.Cells["cmdStartPauseContinue"].Value = "Start";
        }

        public void UpdateStatusRichTextBox(string status, int number)
        {
            if (richTextBox.InvokeRequired)
            {
                richTextBox.Invoke(new Action<string, int>(UpdateStatusRichTextBox), status);

            }
            else
            {
                richTextBox.AppendText(status + + number + Environment.NewLine);
                richTextBox.ScrollToCaret();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateStatusRichTextBox(@"Application started and status is : ", 0);
            dataGridView.AllowUserToAddRows = true;
           
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
                ShowMessageBox("File saved to the new location!", "Information");
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
                        UpdateStatusRichTextBox(@"Selecting file/folder at row : ", e.RowIndex + 1);
                        objectForm.ShowDialog();
                        dataGridView.Refresh();
                    }
                    else if (clickedCell.Value.ToString() == "Remove")
                    {
                            dataGridView.Rows.RemoveAt(e.RowIndex);
                    }
                }
                else if (clickedCell.OwningColumn.Name == "cmdClearCancel")
                {
                    if (clickedCell.Value.ToString() == "Clear")
                    {
                        if (e.RowIndex > 0) {
                            dataGridView.Rows.Clear();
                            dataGridView.Rows[0].Cells[3].Value = "Browse";
                            dataGridView.Rows[0].Cells[4].Value = "Cancel";
                            dataGridView.Rows[0].Cells[5].Value = "Start";
                            dataGridView.Refresh();
                            ShowMessageBox("Data Cleared!", "Information"); 
                        }
                        else
                        {
                            ShowMessageBox("Data is Already Cleared!", "Information");
                        }
                    }
                    
                    else if (clickedCell.Value.ToString() == "Cancel")
                    {
                        if (progressBar.Value > 0)
                        {
                            StopProgressBar();
                            progressBar.Value = 0;
                            dataGridView.Rows[e.RowIndex].Cells[5].Value = "Start";
                            progressBar.Text = "Stoped";
                            dataGridView.Refresh();
                        }
                        else {
                            ShowMessageBox("Progress is not Running!", "Information");
                            
                        }
                        
                    }
                }
                else if (clickedCell.OwningColumn.Name == "cmdStartPauseContinue")
                {
                        if (clickedCell.Value.ToString() == "Start")
                        {
                                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                                DataGridViewCell textCell = row.Cells["colFileName"];

                                if (textCell.Value != null && !string.IsNullOrEmpty(textCell.Value.ToString()))
                                {
                                    if (timer == null || !timer.Enabled)
                                    {
                                        StartProgressBar();
                                        clickedCell.Value = "Pause";
                                        UpdateStatusRichTextBox(@"Started thread at row : ", e.RowIndex + 1);
                                        dataGridView.Refresh();
                                    }
                                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Pause";
                                }
                            else
                            {
                            ShowMessageBox("No Data to Process!", "Information");
                            }
                        }
                    else if (clickedCell.Value.ToString() == "Pause")
                    {
                        if (timer != null && timer.Enabled)
                        {
                            PauseProgressBar();
                            UpdateStatusRichTextBox(@"Paused thread at row : ", e.RowIndex + 1);
                        }
                        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Continue";
                        dataGridView.Refresh();
                    }
                    else if (clickedCell.Value.ToString() == "Continue")
                    {
                        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Pause";
                        ContinueProgressBar();
                        UpdateStatusRichTextBox(@"Continued thread at row : ", e.RowIndex + 1);
                    }
                }

                dataGridView.Refresh();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PerformLoop(10, LoopStatusHandler);
        }
    }
}
