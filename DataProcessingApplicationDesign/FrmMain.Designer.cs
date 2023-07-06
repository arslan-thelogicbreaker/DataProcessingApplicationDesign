using System.Drawing;

namespace DataProcessingApplicationDesign
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.colSrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdBrowsRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cmdClearCancel = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cmdStartPauseContinue = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxOriginalPath = new System.Windows.Forms.CheckBox();
            this.textBoxSelectPath = new System.Windows.Forms.TextBox();
            this.buttonSelectPath = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.progressBar = new CircularProgressBar.CircularProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSrNo,
            this.colIcon,
            this.colFileName,
            this.cmdBrowsRemove,
            this.cmdClearCancel,
            this.cmdStartPauseContinue,
            this.colFileSize});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Location = new System.Drawing.Point(21, 50);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView.Size = new System.Drawing.Size(841, 282);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_CellBeginEdit);
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            this.dataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView_RowsAdded);
            // 
            // colSrNo
            // 
            this.colSrNo.HeaderText = "Sr. No.";
            this.colSrNo.Name = "colSrNo";
            this.colSrNo.ReadOnly = true;
            this.colSrNo.Width = 70;
            // 
            // colIcon
            // 
            this.colIcon.HeaderText = "";
            this.colIcon.Name = "colIcon";
            this.colIcon.ReadOnly = true;
            this.colIcon.Width = 80;
            // 
            // colFileName
            // 
            this.colFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFileName.HeaderText = "File";
            this.colFileName.Name = "colFileName";
            this.colFileName.ReadOnly = true;
            // 
            // cmdBrowsRemove
            // 
            this.cmdBrowsRemove.HeaderText = "";
            this.cmdBrowsRemove.Name = "cmdBrowsRemove";
            this.cmdBrowsRemove.ReadOnly = true;
            this.cmdBrowsRemove.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmdBrowsRemove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cmdBrowsRemove.Text = "Browse";
            this.cmdBrowsRemove.ToolTipText = "Browse/Remove";
            this.cmdBrowsRemove.UseColumnTextForButtonValue = true;
            this.cmdBrowsRemove.Width = 80;
            // 
            // cmdClearCancel
            // 
            this.cmdClearCancel.HeaderText = "";
            this.cmdClearCancel.Name = "cmdClearCancel";
            this.cmdClearCancel.ReadOnly = true;
            this.cmdClearCancel.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmdClearCancel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cmdClearCancel.Text = "Clear";
            this.cmdClearCancel.ToolTipText = "Clear/Cancel";
            this.cmdClearCancel.UseColumnTextForButtonValue = true;
            this.cmdClearCancel.Width = 80;
            // 
            // cmdStartPauseContinue
            // 
            this.cmdStartPauseContinue.HeaderText = "";
            this.cmdStartPauseContinue.Name = "cmdStartPauseContinue";
            this.cmdStartPauseContinue.ReadOnly = true;
            this.cmdStartPauseContinue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cmdStartPauseContinue.Text = "Start";
            this.cmdStartPauseContinue.ToolTipText = "Start/Pause/Continue";
            this.cmdStartPauseContinue.UseColumnTextForButtonValue = true;
            this.cmdStartPauseContinue.Width = 80;
            // 
            // colFileSize
            // 
            this.colFileSize.HeaderText = "Size";
            this.colFileSize.Name = "colFileSize";
            this.colFileSize.ReadOnly = true;
            this.colFileSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colFileSize.Width = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(277, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data Processing Application Design";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Save Path:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(129, 432);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Save on Original Path";
            // 
            // checkBoxOriginalPath
            // 
            this.checkBoxOriginalPath.AutoSize = true;
            this.checkBoxOriginalPath.Location = new System.Drawing.Point(108, 431);
            this.checkBoxOriginalPath.Name = "checkBoxOriginalPath";
            this.checkBoxOriginalPath.Size = new System.Drawing.Size(15, 14);
            this.checkBoxOriginalPath.TabIndex = 4;
            this.checkBoxOriginalPath.UseVisualStyleBackColor = true;
            this.checkBoxOriginalPath.CheckedChanged += new System.EventHandler(this.checkBoxOriginalPath_CheckedChanged);
            // 
            // textBoxSelectPath
            // 
            this.textBoxSelectPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSelectPath.Location = new System.Drawing.Point(108, 388);
            this.textBoxSelectPath.Name = "textBoxSelectPath";
            this.textBoxSelectPath.Size = new System.Drawing.Size(366, 20);
            this.textBoxSelectPath.TabIndex = 5;
            // 
            // buttonSelectPath
            // 
            this.buttonSelectPath.Location = new System.Drawing.Point(480, 388);
            this.buttonSelectPath.Name = "buttonSelectPath";
            this.buttonSelectPath.Size = new System.Drawing.Size(75, 20);
            this.buttonSelectPath.TabIndex = 6;
            this.buttonSelectPath.Text = "Select";
            this.buttonSelectPath.UseVisualStyleBackColor = true;
            this.buttonSelectPath.Click += new System.EventHandler(this.buttonSelectPath_Click);
            // 
            // progressBar
            // 
            this.progressBar.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.progressBar.AnimationSpeed = 300;
            this.progressBar.BackColor = System.Drawing.Color.Transparent;
            this.progressBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.progressBar.InnerColor = System.Drawing.Color.Transparent;
            this.progressBar.InnerMargin = 2;
            this.progressBar.InnerWidth = -1;
            this.progressBar.Location = new System.Drawing.Point(718, 338);
            this.progressBar.MarqueeAnimationSpeed = 2000;
            this.progressBar.Name = "progressBar";
            this.progressBar.OuterColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.progressBar.OuterMargin = -25;
            this.progressBar.OuterWidth = 25;
            this.progressBar.ProgressColor = System.Drawing.Color.Blue;
            this.progressBar.ProgressWidth = 15;
            this.progressBar.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressBar.Size = new System.Drawing.Size(135, 114);
            this.progressBar.StartAngle = 270;
            this.progressBar.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.progressBar.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.progressBar.SubscriptText = "";
            this.progressBar.SuperscriptColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.progressBar.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.progressBar.SuperscriptText = "";
            this.progressBar.TabIndex = 7;
            this.progressBar.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.progressBar.Value = 68;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(891, 464);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonSelectPath);
            this.Controls.Add(this.textBoxSelectPath);
            this.Controls.Add(this.checkBoxOriginalPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Name = "FrmMain";
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Data Processing Application Design";
            this.Text = "Data Processing Application Design";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox checkBoxOriginalPath;
        public System.Windows.Forms.Button buttonSelectPath;
        public System.Windows.Forms.DataGridView dataGridView;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.TextBox textBoxSelectPath;
        public CircularProgressBar.CircularProgressBar progressBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSrNo;
        private System.Windows.Forms.DataGridViewImageColumn colIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewButtonColumn cmdBrowsRemove;
        private System.Windows.Forms.DataGridViewButtonColumn cmdClearCancel;
        private System.Windows.Forms.DataGridViewButtonColumn cmdStartPauseContinue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileSize;
    }
}

