namespace AUM
{
    partial class TerminateProcessesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TerminateProcessesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lNowConnected = new System.Windows.Forms.Label();
            this.TimerListener = new System.Windows.Forms.Timer(this.components);
            this.bCancelUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lNowConnected
            // 
            resources.ApplyResources(this.lNowConnected, "lNowConnected");
            this.lNowConnected.Name = "lNowConnected";
            // 
            // TimerListener
            // 
            this.TimerListener.Interval = 3000;
            this.TimerListener.Tick += new System.EventHandler(this.OnTimerListenerTick);
            // 
            // bCancelUpdate
            // 
            resources.ApplyResources(this.bCancelUpdate, "bCancelUpdate");
            this.bCancelUpdate.Name = "bCancelUpdate";
            this.bCancelUpdate.UseVisualStyleBackColor = true;
            this.bCancelUpdate.Click += new System.EventHandler(this.OnBCancelUpdateClick);
            // 
            // TerminateProcessesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.bCancelUpdate);
            this.Controls.Add(this.lNowConnected);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TerminateProcessesForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lNowConnected;
        private System.Windows.Forms.Timer TimerListener;
        private System.Windows.Forms.Button bCancelUpdate;
    }
}