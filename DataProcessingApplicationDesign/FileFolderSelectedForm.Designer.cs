namespace DataProcessingApplicationDesign
{
    partial class FileFolderSelectedForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
        private void InitializeComponent()
        {
            this.buttonFileBrowse = new System.Windows.Forms.Button();
            this.buttonFolderBrowse = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonFileBrowse
            // 
            this.buttonFileBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFileBrowse.Location = new System.Drawing.Point(12, 27);
            this.buttonFileBrowse.Name = "buttonFileBrowse";
            this.buttonFileBrowse.Size = new System.Drawing.Size(238, 32);
            this.buttonFileBrowse.TabIndex = 0;
            this.buttonFileBrowse.Text = "File";
            this.buttonFileBrowse.UseVisualStyleBackColor = true;
            this.buttonFileBrowse.Click += new System.EventHandler(this.buttonFileBrowse_Click);
            // 
            // buttonFolderBrowse
            // 
            this.buttonFolderBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFolderBrowse.Location = new System.Drawing.Point(12, 65);
            this.buttonFolderBrowse.Name = "buttonFolderBrowse";
            this.buttonFolderBrowse.Size = new System.Drawing.Size(238, 30);
            this.buttonFolderBrowse.TabIndex = 1;
            this.buttonFolderBrowse.Text = "Folder";
            this.buttonFolderBrowse.UseVisualStyleBackColor = true;
            this.buttonFolderBrowse.Click += new System.EventHandler(this.buttonFolderBrowse_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(92, 116);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FileFolderSelectedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 151);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonFolderBrowse);
            this.Controls.Add(this.buttonFileBrowse);
            this.Name = "FileFolderSelectedForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select File or Folder";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFileBrowse;
        private System.Windows.Forms.Button buttonFolderBrowse;
        private System.Windows.Forms.Button buttonCancel;
    }
}