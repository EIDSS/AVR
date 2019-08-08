namespace EIDSS.Reports.BaseControls.Keeper
{
    partial class BaseDateRegionKeeper
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
            this.Region = new System.Windows.Forms.Label();
            this.cbRegion = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonthEnd.Properties)).BeginInit();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRegion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(452, 13);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(308, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // spinEdit
            // 
            this.spinEdit.Location = new System.Drawing.Point(312, 34);
            this.spinEdit.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit.Properties.Mask.EditMask = "\\d{1,5}";
            this.spinEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.spinEdit.Size = new System.Drawing.Size(99, 24);
            // 
            // cbMonth
            // 
            this.cbMonth.Location = new System.Drawing.Point(456, 34);
            this.cbMonth.Margin = new System.Windows.Forms.Padding(4);
            this.cbMonth.Size = new System.Drawing.Size(160, 24);
            // 
            // cbMonthEnd
            // 
            this.cbMonthEnd.Location = new System.Drawing.Point(665, 34);
            this.cbMonthEnd.Margin = new System.Windows.Forms.Padding(4);
            this.cbMonthEnd.Size = new System.Drawing.Size(160, 24);
            // 
            // EndMonthLabel
            // 
            this.EndMonthLabel.Location = new System.Drawing.Point(661, 13);
            this.EndMonthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // StartMonthLabel
            // 
            this.StartMonthLabel.Location = new System.Drawing.Point(576, 13);
            this.StartMonthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // MonthLabel
            // 
            this.MonthLabel.Location = new System.Drawing.Point(531, 13);
            this.MonthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.cbRegion);
            this.pnlSettings.Controls.Add(this.Region);
            this.pnlSettings.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSettings.Size = new System.Drawing.Size(1159, 142);
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.label1, 0);
            this.pnlSettings.Controls.SetChildIndex(this.label2, 0);
            this.pnlSettings.Controls.SetChildIndex(this.spinEdit, 0);
            this.pnlSettings.Controls.SetChildIndex(this.cbMonth, 0);
            this.pnlSettings.Controls.SetChildIndex(this.EndMonthLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.cbMonthEnd, 0);
            this.pnlSettings.Controls.SetChildIndex(this.StartMonthLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.MonthLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.Region, 0);
            this.pnlSettings.Controls.SetChildIndex(this.cbRegion, 0);
            // 
            // ceUseArchiveData
            // 
            this.ceUseArchiveData.Location = new System.Drawing.Point(456, 92);
            this.ceUseArchiveData.Margin = new System.Windows.Forms.Padding(4);
            this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.ceUseArchiveData.Size = new System.Drawing.Size(668, 21);
            // 
            // GenerateReportButton
            // 
            this.GenerateReportButton.Location = new System.Drawing.Point(41, 86);
            this.GenerateReportButton.Margin = new System.Windows.Forms.Padding(4);
            this.GenerateReportButton.Size = new System.Drawing.Size(369, 30);
            // Form Is Localizable: False
            // 
            // Region
            // 
            this.Region.AutoSize = true;
            this.Region.Location = new System.Drawing.Point(869, 10);
            this.Region.Name = "Region";
            this.Region.Size = new System.Drawing.Size(57, 17);
            this.Region.TabIndex = 1902;
            this.Region.Text = "Region:";
            // 
            // cbRegion
            // 
            this.cbRegion.Location = new System.Drawing.Point(872, 34);
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbRegion.Size = new System.Drawing.Size(155, 24);
            this.cbRegion.TabIndex = 60;
            // 
            // BaseDateRegionKeeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.HeaderHeight = 170;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BaseDateRegionKeeper";
            this.Size = new System.Drawing.Size(1163, 994);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonthEnd.Properties)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbRegion.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Region;
        protected DevExpress.XtraEditors.LookUpEdit cbRegion;
    }
}
