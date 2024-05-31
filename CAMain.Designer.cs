namespace CurricularAnalytics
{
    partial class CAMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLeft = new System.Windows.Forms.Panel();
            this.buttonGenReportFull = new System.Windows.Forms.Button();
            this.buttonGenReport = new System.Windows.Forms.Button();
            this.buttonCoreqStats = new System.Windows.Forms.Button();
            this.buttonPrereqStats = new System.Windows.Forms.Button();
            this.buttonFailCalc2 = new System.Windows.Forms.Button();
            this.buttonCoreq = new System.Windows.Forms.Button();
            this.buttonPrereq = new System.Windows.Forms.Button();
            this.textBoxDegreePlans = new System.Windows.Forms.TextBox();
            this.buttonDegreePlans = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.buttonGenReportFull);
            this.panelLeft.Controls.Add(this.buttonGenReport);
            this.panelLeft.Controls.Add(this.buttonCoreqStats);
            this.panelLeft.Controls.Add(this.buttonPrereqStats);
            this.panelLeft.Controls.Add(this.buttonFailCalc2);
            this.panelLeft.Controls.Add(this.buttonCoreq);
            this.panelLeft.Controls.Add(this.buttonPrereq);
            this.panelLeft.Controls.Add(this.textBoxDegreePlans);
            this.panelLeft.Controls.Add(this.buttonDegreePlans);
            this.panelLeft.Controls.Add(this.buttonLoad);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(118, 450);
            this.panelLeft.TabIndex = 0;
            // 
            // buttonGenReportFull
            // 
            this.buttonGenReportFull.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGenReportFull.Location = new System.Drawing.Point(0, 184);
            this.buttonGenReportFull.Name = "buttonGenReportFull";
            this.buttonGenReportFull.Size = new System.Drawing.Size(118, 23);
            this.buttonGenReportFull.TabIndex = 9;
            this.buttonGenReportFull.Text = "Gen Report Full";
            this.buttonGenReportFull.UseVisualStyleBackColor = true;
            this.buttonGenReportFull.Click += new System.EventHandler(this.buttonGenReportFull_Click);
            // 
            // buttonGenReport
            // 
            this.buttonGenReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonGenReport.Location = new System.Drawing.Point(0, 161);
            this.buttonGenReport.Name = "buttonGenReport";
            this.buttonGenReport.Size = new System.Drawing.Size(118, 23);
            this.buttonGenReport.TabIndex = 8;
            this.buttonGenReport.Text = "Gen Report";
            this.buttonGenReport.UseVisualStyleBackColor = true;
            this.buttonGenReport.Click += new System.EventHandler(this.buttonGenReport_Click);
            // 
            // buttonCoreqStats
            // 
            this.buttonCoreqStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCoreqStats.Location = new System.Drawing.Point(0, 138);
            this.buttonCoreqStats.Name = "buttonCoreqStats";
            this.buttonCoreqStats.Size = new System.Drawing.Size(118, 23);
            this.buttonCoreqStats.TabIndex = 7;
            this.buttonCoreqStats.Text = "Coreq Stats";
            this.buttonCoreqStats.UseVisualStyleBackColor = true;
            this.buttonCoreqStats.Click += new System.EventHandler(this.buttonCoreqStats_Click);
            // 
            // buttonPrereqStats
            // 
            this.buttonPrereqStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPrereqStats.Location = new System.Drawing.Point(0, 115);
            this.buttonPrereqStats.Name = "buttonPrereqStats";
            this.buttonPrereqStats.Size = new System.Drawing.Size(118, 23);
            this.buttonPrereqStats.TabIndex = 6;
            this.buttonPrereqStats.Text = "Prereq Stats";
            this.buttonPrereqStats.UseVisualStyleBackColor = true;
            this.buttonPrereqStats.Click += new System.EventHandler(this.buttonPrereqStats_Click);
            // 
            // buttonFailCalc2
            // 
            this.buttonFailCalc2.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonFailCalc2.Location = new System.Drawing.Point(0, 92);
            this.buttonFailCalc2.Name = "buttonFailCalc2";
            this.buttonFailCalc2.Size = new System.Drawing.Size(118, 23);
            this.buttonFailCalc2.TabIndex = 5;
            this.buttonFailCalc2.Text = "Fail Calc 2";
            this.buttonFailCalc2.UseVisualStyleBackColor = true;
            this.buttonFailCalc2.Click += new System.EventHandler(this.buttonFailCalc2_Click);
            // 
            // buttonCoreq
            // 
            this.buttonCoreq.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonCoreq.Location = new System.Drawing.Point(0, 69);
            this.buttonCoreq.Name = "buttonCoreq";
            this.buttonCoreq.Size = new System.Drawing.Size(118, 23);
            this.buttonCoreq.TabIndex = 4;
            this.buttonCoreq.Text = "Coreq";
            this.buttonCoreq.UseVisualStyleBackColor = true;
            this.buttonCoreq.Click += new System.EventHandler(this.buttonCoreq_Click);
            // 
            // buttonPrereq
            // 
            this.buttonPrereq.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPrereq.Location = new System.Drawing.Point(0, 46);
            this.buttonPrereq.Name = "buttonPrereq";
            this.buttonPrereq.Size = new System.Drawing.Size(118, 23);
            this.buttonPrereq.TabIndex = 3;
            this.buttonPrereq.Text = "Prereq";
            this.buttonPrereq.UseVisualStyleBackColor = true;
            this.buttonPrereq.Click += new System.EventHandler(this.buttonPrereq_Click);
            // 
            // textBoxDegreePlans
            // 
            this.textBoxDegreePlans.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBoxDegreePlans.Location = new System.Drawing.Point(0, 427);
            this.textBoxDegreePlans.Name = "textBoxDegreePlans";
            this.textBoxDegreePlans.Size = new System.Drawing.Size(118, 23);
            this.textBoxDegreePlans.TabIndex = 2;
            this.textBoxDegreePlans.Text = "0";
            // 
            // buttonDegreePlans
            // 
            this.buttonDegreePlans.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonDegreePlans.Location = new System.Drawing.Point(0, 23);
            this.buttonDegreePlans.Name = "buttonDegreePlans";
            this.buttonDegreePlans.Size = new System.Drawing.Size(118, 23);
            this.buttonDegreePlans.TabIndex = 1;
            this.buttonDegreePlans.Text = "Degree Plans";
            this.buttonDegreePlans.UseVisualStyleBackColor = true;
            this.buttonDegreePlans.Click += new System.EventHandler(this.buttonDegreePlans_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLoad.Location = new System.Drawing.Point(0, 0);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(118, 23);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxOutput.Location = new System.Drawing.Point(118, 0);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(682, 450);
            this.richTextBoxOutput.TabIndex = 1;
            this.richTextBoxOutput.Text = "";
            // 
            // CAMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBoxOutput);
            this.Controls.Add(this.panelLeft);
            this.Name = "CAMain";
            this.Text = "CurricularAnalytics";
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelLeft;
        private Button buttonLoad;
        private RichTextBox richTextBoxOutput;
        private Button buttonDegreePlans;
        private TextBox textBoxDegreePlans;
        private Button buttonPrereq;
        private Button buttonCoreq;
        private Button buttonFailCalc2;
        private Button buttonPrereqStats;
        private Button buttonCoreqStats;
        private Button buttonGenReport;
        private Button buttonGenReportFull;
    }
}