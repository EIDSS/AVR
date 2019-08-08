namespace AUM
{
    partial class UpdateForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.gbReport = new System.Windows.Forms.GroupBox();
            this.lbReport = new System.Windows.Forms.ListBox();
            this.bClose = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.TimerStartUpdate = new System.Windows.Forms.Timer(this.components);
            this.TimerWaitingClose = new System.Windows.Forms.Timer(this.components);
            this.bDetails = new System.Windows.Forms.Button();
            this.gbReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbReport
            // 
            this.gbReport.AccessibleDescription = null;
            this.gbReport.AccessibleName = null;
            resources.ApplyResources(this.gbReport, "gbReport");
            this.gbReport.BackgroundImage = null;
            this.gbReport.Controls.Add(this.lbReport);
            this.gbReport.Font = null;
            this.gbReport.Name = "gbReport";
            this.gbReport.TabStop = false;
            // 
            // lbReport
            // 
            this.lbReport.AccessibleDescription = null;
            this.lbReport.AccessibleName = null;
            resources.ApplyResources(this.lbReport, "lbReport");
            this.lbReport.BackgroundImage = null;
            this.lbReport.Font = null;
            this.lbReport.FormattingEnabled = true;
            this.lbReport.Name = "lbReport";
            // 
            // bClose
            // 
            this.bClose.AccessibleDescription = null;
            this.bClose.AccessibleName = null;
            resources.ApplyResources(this.bClose, "bClose");
            this.bClose.BackgroundImage = null;
            this.bClose.Font = null;
            this.bClose.Name = "bClose";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.OnBCloseClick);
            // 
            // progressBar
            // 
            this.progressBar.AccessibleDescription = null;
            this.progressBar.AccessibleName = null;
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.BackgroundImage = null;
            this.progressBar.Font = null;
            this.progressBar.Maximum = 10;
            this.progressBar.Name = "progressBar";
            this.progressBar.Step = 1;
            // 
            // TimerStartUpdate
            // 
            this.TimerStartUpdate.Interval = 10000;
            this.TimerStartUpdate.Tick += new System.EventHandler(this.OnTimerStartUpdateTick);
            // 
            // TimerWaitingClose
            // 
            this.TimerWaitingClose.Interval = 1000;
            this.TimerWaitingClose.Tick += new System.EventHandler(this.OnTimerWaitingCloseTick);
            // 
            // bDetails
            // 
            this.bDetails.AccessibleDescription = null;
            this.bDetails.AccessibleName = null;
            resources.ApplyResources(this.bDetails, "bDetails");
            this.bDetails.BackgroundImage = null;
            this.bDetails.Font = null;
            this.bDetails.Name = "bDetails";
            this.bDetails.UseVisualStyleBackColor = true;
            this.bDetails.Click += new System.EventHandler(this.OnBDetailsClick);
            // 
            // UpdateForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.bDetails);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.gbReport);
            this.Font = null;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.Load += new System.EventHandler(this.OnUpdateFormLoad);
            this.gbReport.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbReport;
        private System.Windows.Forms.ListBox lbReport;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer TimerStartUpdate;
        private System.Windows.Forms.Timer TimerWaitingClose;
        private System.Windows.Forms.Button bDetails;
    }
}

