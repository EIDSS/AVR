namespace EIDSS.Reports.Parameterized.Human.UA.Keepers
{
    partial class UAFormKeeper
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
            this.regionFilter = new EIDSS.Reports.BaseControls.Filters.RegionFilter();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonthEnd.Properties)).BeginInit();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(453, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(276, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // spinEdit
            // 
            this.spinEdit.Location = new System.Drawing.Point(279, 26);
            this.spinEdit.Margin = new System.Windows.Forms.Padding(4);
            this.spinEdit.Properties.Mask.EditMask = "\\d{1,5}";
            this.spinEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.spinEdit.Size = new System.Drawing.Size(99, 24);
            // 
            // cbMonth
            // 
            this.cbMonth.Location = new System.Drawing.Point(455, 26);
            this.cbMonth.Margin = new System.Windows.Forms.Padding(4);
            this.cbMonth.Size = new System.Drawing.Size(160, 24);
            // 
            // cbMonthEnd
            // 
            this.cbMonthEnd.Location = new System.Drawing.Point(456, 112);
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
            this.StartMonthLabel.Location = new System.Drawing.Point(453, 75);
            this.StartMonthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // MonthLabel
            // 
            this.MonthLabel.Location = new System.Drawing.Point(526, 10);
            this.MonthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.regionFilter);
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
            this.pnlSettings.Controls.SetChildIndex(this.regionFilter, 0);
            // 
            // ceUseArchiveData
            // 
            this.ceUseArchiveData.Location = new System.Drawing.Point(698, 112);
            this.ceUseArchiveData.Margin = new System.Windows.Forms.Padding(4);
            this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.ceUseArchiveData.Size = new System.Drawing.Size(247, 21);
            // 
            // GenerateReportButton
            // 
            this.GenerateReportButton.Location = new System.Drawing.Point(31, 103);
            this.GenerateReportButton.Margin = new System.Windows.Forms.Padding(4);
            this.GenerateReportButton.Size = new System.Drawing.Size(369, 30);
            // Form Is Localizable: False
            // 
            // regionFilter
            // 
            this.regionFilter.Appearance.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regionFilter.Appearance.Options.UseFont = true;
            this.regionFilter.Location = new System.Drawing.Point(676, 10);
            this.regionFilter.Margin = new System.Windows.Forms.Padding(6);
            this.regionFilter.Name = "regionFilter";
            this.regionFilter.Size = new System.Drawing.Size(166, 39);
            this.regionFilter.TabIndex = 400;
            // 
            // UAFormKeeper
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.HeaderHeight = 170;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UAFormKeeper";
            this.Size = new System.Drawing.Size(1163, 994);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMonthEnd.Properties)).EndInit();
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected BaseControls.Filters.RegionFilter regionFilter;
    }
}
