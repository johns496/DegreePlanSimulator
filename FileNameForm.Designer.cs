namespace CurricularAnalytics
{
    partial class FileNameForm
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
            this.listBoxFileList = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonProceed = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxFileList
            // 
            this.listBoxFileList.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxFileList.FormattingEnabled = true;
            this.listBoxFileList.ItemHeight = 15;
            this.listBoxFileList.Location = new System.Drawing.Point(0, 0);
            this.listBoxFileList.Name = "listBoxFileList";
            this.listBoxFileList.Size = new System.Drawing.Size(405, 379);
            this.listBoxFileList.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonProceed);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 401);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 49);
            this.panel1.TabIndex = 1;
            // 
            // buttonProceed
            // 
            this.buttonProceed.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonProceed.Location = new System.Drawing.Point(117, 13);
            this.buttonProceed.Name = "buttonProceed";
            this.buttonProceed.Size = new System.Drawing.Size(94, 25);
            this.buttonProceed.TabIndex = 0;
            this.buttonProceed.Text = "Proceed";
            this.buttonProceed.UseVisualStyleBackColor = true;
            // 
            // FileNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBoxFileList);
            this.Name = "FileNameForm";
            this.Text = "FileNameForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox listBoxFileList;
        private Panel panel1;
        private Button buttonProceed;
    }
}