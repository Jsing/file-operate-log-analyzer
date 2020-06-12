namespace FileLogAnalyzer
{
    partial class AnalyzeFileOperateLogForm
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
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.closedButTryingWriteReport = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.handledByMulithreadReport = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.btStart = new Infragistics.Win.Misc.UltraButton();
            this.opendButNotClosedReporter = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.outputView = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.btClearView = new Infragistics.Win.Misc.UltraButton();
            this.logPathView = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.closedButTryingWriteReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.handledByMulithreadReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opendButNotClosedReporter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputView)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraLabel2
            // 
            this.ultraLabel2.Font = new System.Drawing.Font("Malgun Gothic", 9.75F);
            this.ultraLabel2.Location = new System.Drawing.Point(12, 193);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(285, 23);
            this.ultraLabel2.TabIndex = 8;
            this.ultraLabel2.Text = "[ Opened, but not Closed (OBNC) ]";
            // 
            // closedButTryingWriteReport
            // 
            this.closedButTryingWriteReport.Location = new System.Drawing.Point(10, 370);
            this.closedButTryingWriteReport.Multiline = true;
            this.closedButTryingWriteReport.Name = "closedButTryingWriteReport";
            this.closedButTryingWriteReport.ReadOnly = true;
            this.closedButTryingWriteReport.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.closedButTryingWriteReport.Size = new System.Drawing.Size(808, 113);
            this.closedButTryingWriteReport.TabIndex = 18;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Font = new System.Drawing.Font("Malgun Gothic", 9.75F);
            this.ultraLabel1.Location = new System.Drawing.Point(10, 346);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(285, 23);
            this.ultraLabel1.TabIndex = 17;
            this.ultraLabel1.Text = "[ Closed, but trying to Write (CBTW) ]";
            // 
            // handledByMulithreadReport
            // 
            this.handledByMulithreadReport.Location = new System.Drawing.Point(10, 525);
            this.handledByMulithreadReport.Multiline = true;
            this.handledByMulithreadReport.Name = "handledByMulithreadReport";
            this.handledByMulithreadReport.ReadOnly = true;
            this.handledByMulithreadReport.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.handledByMulithreadReport.Size = new System.Drawing.Size(808, 113);
            this.handledByMulithreadReport.TabIndex = 20;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.Font = new System.Drawing.Font("Malgun Gothic", 9.75F);
            this.ultraLabel3.Location = new System.Drawing.Point(10, 501);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(285, 23);
            this.ultraLabel3.TabIndex = 19;
            this.ultraLabel3.Text = "[ Handled by Multithreaded (HBM) ]";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(12, 12);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 23;
            this.btStart.Text = "Start";
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // opendButNotClosedReporter
            // 
            this.opendButNotClosedReporter.Location = new System.Drawing.Point(12, 217);
            this.opendButNotClosedReporter.Multiline = true;
            this.opendButNotClosedReporter.Name = "opendButNotClosedReporter";
            this.opendButNotClosedReporter.ReadOnly = true;
            this.opendButNotClosedReporter.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.opendButNotClosedReporter.Size = new System.Drawing.Size(806, 118);
            this.opendButNotClosedReporter.TabIndex = 26;
            // 
            // ultraLabel5
            // 
            this.ultraLabel5.Font = new System.Drawing.Font("Malgun Gothic", 9.75F);
            this.ultraLabel5.Location = new System.Drawing.Point(12, 42);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(285, 23);
            this.ultraLabel5.TabIndex = 27;
            this.ultraLabel5.Text = "[ Output ]";
            // 
            // outputView
            // 
            this.outputView.Location = new System.Drawing.Point(12, 66);
            this.outputView.MaxLength = 52767;
            this.outputView.Multiline = true;
            this.outputView.Name = "outputView";
            this.outputView.ReadOnly = true;
            this.outputView.Scrollbars = System.Windows.Forms.ScrollBars.Both;
            this.outputView.Size = new System.Drawing.Size(806, 116);
            this.outputView.TabIndex = 28;
            // 
            // btClearView
            // 
            this.btClearView.Location = new System.Drawing.Point(93, 12);
            this.btClearView.Name = "btClearView";
            this.btClearView.Size = new System.Drawing.Size(75, 23);
            this.btClearView.TabIndex = 29;
            this.btClearView.Text = "Clear";
            this.btClearView.Click += new System.EventHandler(this.btClearView_Click);
            // 
            // logPathView
            // 
            this.logPathView.Font = new System.Drawing.Font("Malgun Gothic", 9.75F);
            this.logPathView.Location = new System.Drawing.Point(174, 13);
            this.logPathView.Name = "logPathView";
            this.logPathView.Size = new System.Drawing.Size(644, 23);
            this.logPathView.TabIndex = 30;
            this.logPathView.Text = "Log Path : ";
            // 
            // AnalyzeFileLogForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 653);
            this.Controls.Add(this.logPathView);
            this.Controls.Add(this.btClearView);
            this.Controls.Add(this.outputView);
            this.Controls.Add(this.ultraLabel5);
            this.Controls.Add(this.opendButNotClosedReporter);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.handledByMulithreadReport);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.closedButTryingWriteReport);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.ultraLabel2);
            this.Name = "AnalyzeFileLogForm";
            this.Text = "File Log Analyzer";
            ((System.ComponentModel.ISupportInitialize)(this.closedButTryingWriteReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.handledByMulithreadReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opendButNotClosedReporter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor closedButTryingWriteReport;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor handledByMulithreadReport;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private Infragistics.Win.Misc.UltraButton btStart;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor opendButNotClosedReporter;
        private Infragistics.Win.Misc.UltraLabel ultraLabel5;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor outputView;
        private Infragistics.Win.Misc.UltraButton btClearView;
        private Infragistics.Win.Misc.UltraLabel logPathView;
    }
}

