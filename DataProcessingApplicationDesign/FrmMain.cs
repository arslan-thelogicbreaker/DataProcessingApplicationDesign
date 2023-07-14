
//Code structure has following details
//Pivot is MainForm_Load function I am using to manage structure for easy to understand
//Sequence is according: -
    //Top of the MainForm_Load
        // 1- Initialization
        // 2- All functions and methods
    //Bottom of MainForm_Load
        // 1- DataGridView events/methods
        // 2- All click events

using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DataProcessingApplicationDesign
{
    
    public delegate void LoopStatusCallback(int status);

    public partial class FrmMain : Form
    {
        //Declaring object for second form where file or folder is being selected
        FrmBrowse objectForm;

        //Variable declaration for progress bar
        private System.Windows.Forms.Timer timer;
        private int progressValue;
        private bool isPaused;
        public bool IsPaused { get => isPaused; set => isPaused = value; }


        //importing dll file for message box
        [DllImport("MainFileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void ShowMessageBox(string message, string title);

        //importing dll file for call back function
        [DllImport("MainFileDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PerformLoop(int iterations, LoopStatusCallback callback);

        //Handling call back function calling from dll
        static void LoopStatusHandler(int status)
        {
            FrmMain form = Application.OpenForms[0] as FrmMain;
            form.UpdateRichTextBox("Processing...: " + status + Environment.NewLine);
        }

        public FrmMain()
        {
            //Created object for second form where file or folder is being selected
            objectForm = new FrmBrowse(this);

            InitializeComponent();
            InitializeProgressBar();
            isPaused = false;

            //Implemented some default properties on DataGridView 
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.AliceBlue;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ReadOnly = true;
        }

        //Initialiazing default values for progress bar/process
        private void InitializeProgressBar()
        {
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
            progressValue = 0;
        }

        //Function to start progress bar/process
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

        //Function to pause progress bar/process
        private void PauseProgressBar()
        {
            timer.Stop();
            isPaused = true;
        }

        //Function to continue progress bar/process
        private void ContinueProgressBar()
        {
            timer.Start();
            isPaused = false;
        }

        //Function to stop progress bar/process
        private void StopProgressBar()
        {
            timer.Stop();
            progressValue = 0;
            progressBar.Value = progressValue;
            this.BackgroundImage = null;
        }

        //timer event for progress bar/process
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressValue < progressBar.Maximum)
            {
                progressValue++;
                progressBar.Value = progressValue;
                //calling call back function from dll and passing timer value as progressValue
                PerformLoop(progressValue, LoopStatusHandler);
            }
            else
            {
                StopProgressBar();
            }
        }

        //function to update/apend call back value from dll to the Rich Text Box
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

        //function to update/apend overall application processes in Rich Text Box
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

        //Main Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateStatusRichTextBox(@"Application started and status is : ", 0);
            dataGridView.AllowUserToAddRows = true; 
        }

        //Data Grid View event to perform adding row with default values and structure
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

        //Data Grid View event to perform on remove row with default values and structure
        private void dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int i = e.RowIndex; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].Cells["colSrNo"].Value = (i + 1).ToString();
            }
        }

        //Data Grid View event to assign default values to the columns
        private void dataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["colIcon"].Value = null;
            e.Row.Cells["colIcon"].Style.NullValue = null;

            e.Row.Cells["cmdBrowsRemove"].Value = "Browse";
            e.Row.Cells["cmdClearCancel"].Value = "Clear";
            e.Row.Cells["cmdStartPauseContinue"].Value = "Start";
        }

        //Data Grid View event to perform operations on file/folder
        //Main event to select file/folder or remove
        //Main event for process start, pause, continue, stop
        //Main event to clear data grid view or cancel process
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                //Selecting value from clicked cell
                DataGridViewCell clickedCell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];

                //Checking condition and performing operation according to fetched value from clicked cell in clickedCell
                if (clickedCell.OwningColumn.Name == "cmdBrowsRemove")
                {
                    //Selecting file/folder
                    if (clickedCell.Value.ToString().Contains("Browse"))
                    {
                        UpdateStatusRichTextBox(@"Selecting file/folder at row : ", e.RowIndex + 1);
                        objectForm.ShowDialog();
                        dataGridView.Refresh();
                    }
                    //Removing file/folder
                    else if (clickedCell.Value.ToString() == "Remove")
                    {
                            dataGridView.Rows.RemoveAt(e.RowIndex);
                    }
                }
                else if (clickedCell.OwningColumn.Name == "cmdClearCancel")
                {
                    //Clear datagridview and assigning new values on buttons
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
                    //Canceling current process if running 
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
                        //Starting process if file/folder selected
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
                                    //Changing button name from start to pause
                                    dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Pause";
                                }
                            else
                            {
                            ShowMessageBox("No Data to Process!", "Information");
                            }
                        }
                    //Pause current thread if started
                    else if (clickedCell.Value.ToString() == "Pause")
                    {
                        if (timer != null && timer.Enabled)
                        {
                            PauseProgressBar();
                            UpdateStatusRichTextBox(@"Paused thread at row : ", e.RowIndex + 1);
                        }
                        //Changing button name from pause to continue
                        dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Continue";
                        dataGridView.Refresh();
                    }
                    //Continuing current thread if paused
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

        //Data Grid View event to select file/folder address by clicking on it show in Path Text Box
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewCell selectedCell = dataGridView.Rows[e.RowIndex].Cells["colFileName"];
                string cellValue = selectedCell.Value?.ToString();
                textBoxSelectPath.Text = cellValue;
            }
        }

        //Check Box event if checked then default address will be appear
        private void checkBoxOriginalPath_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOriginalPath.Checked)
            {
                textBoxSelectPath.Text = "Default Path";
            }
        }

        //Save Button event to save file on new or default location
        private void buttonSelectPath_Click(object sender, EventArgs e)
        {
            if (textBoxSelectPath.Text != "")
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
            else
            {
                ShowMessageBox("File is not selected.", "Select file!");
            }
        }
    }
}
