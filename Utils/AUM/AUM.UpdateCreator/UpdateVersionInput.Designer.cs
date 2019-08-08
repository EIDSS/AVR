namespace AUM.UpdateCreator
{
    partial class UpdateVersionInput
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbVersion = new System.Windows.Forms.TextBox();
            this.bVersionCompare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbVersion
            // 
            this.tbVersion.Enabled = false;
            this.tbVersion.Location = new System.Drawing.Point(3, 3);
            this.tbVersion.Name = "tbVersion";
            this.tbVersion.Size = new System.Drawing.Size(65, 20);
            this.tbVersion.TabIndex = 0;
            // 
            // bVersionCompare
            // 
            this.bVersionCompare.Location = new System.Drawing.Point(74, 3);
            this.bVersionCompare.Name = "bVersionCompare";
            this.bVersionCompare.Size = new System.Drawing.Size(40, 20);
            this.bVersionCompare.TabIndex = 1;
            this.bVersionCompare.Text = "set";
            this.bVersionCompare.UseVisualStyleBackColor = true;
            this.bVersionCompare.Click += new System.EventHandler(this.OnBVersionCompareClick);
            // 
            // UpdateVersionInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bVersionCompare);
            this.Controls.Add(this.tbVersion);
            this.Name = "UpdateVersionInput";
            this.Size = new System.Drawing.Size(121, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbVersion;
        private System.Windows.Forms.Button bVersionCompare;
    }
}
