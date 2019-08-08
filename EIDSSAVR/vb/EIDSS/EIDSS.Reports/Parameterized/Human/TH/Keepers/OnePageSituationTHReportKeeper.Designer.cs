namespace EIDSS.Reports.Parameterized.Human.TH.Keepers
{
    partial class OnePageSituationTHReportKeeper
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OnePageSituationTHReportKeeper));
			this.DiagnosesFilter = new EIDSS.Reports.BaseControls.Filters.HumSingleDiagnosisFilter();
			this.ThaiZoneFilter = new EIDSS.Reports.BaseControls.Filters.ThaiZonesSingleFilter();
			this.pnlSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlSettings
			// 
			this.pnlSettings.Controls.Add(this.ThaiZoneFilter);
			this.pnlSettings.Controls.Add(this.DiagnosesFilter);
			resources.ApplyResources(this.pnlSettings, "pnlSettings");
			this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
			this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
			this.pnlSettings.Controls.SetChildIndex(this.DiagnosesFilter, 0);
			this.pnlSettings.Controls.SetChildIndex(this.ThaiZoneFilter, 0);
			// 
			// ceUseArchiveData
			// 
			resources.ApplyResources(this.ceUseArchiveData, "ceUseArchiveData");
			this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
			this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
			this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
			this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
			// 
			// GenerateReportButton
			// 
			resources.ApplyResources(this.GenerateReportButton, "GenerateReportButton");
			bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(OnePageSituationTHReportKeeper), out resources);
			// Form Is Localizable: True
			// 
			// DiagnosesFilter
			// 
			this.DiagnosesFilter.AdditionalFilter = null;
			this.DiagnosesFilter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("DiagnosesFilter.Appearance.Font")));
			this.DiagnosesFilter.Appearance.Options.UseFont = true;
			resources.ApplyResources(this.DiagnosesFilter, "DiagnosesFilter");
			this.DiagnosesFilter.Name = "DiagnosesFilter";
			// 
			// ThaiZoneFilter
			// 
			this.ThaiZoneFilter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ThaiZoneFilter.Appearance.Font")));
			this.ThaiZoneFilter.Appearance.Options.UseFont = true;
			this.ThaiZoneFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			resources.ApplyResources(this.ThaiZoneFilter, "ThaiZoneFilter");
			this.ThaiZoneFilter.Name = "ThaiZoneFilter";
			// 
			// OnePageSituationTHReportKeeper
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.HeaderHeight = 125;
			this.Name = "OnePageSituationTHReportKeeper";
			this.pnlSettings.ResumeLayout(false);
			this.pnlSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private BaseControls.Filters.HumSingleDiagnosisFilter DiagnosesFilter;
		private BaseControls.Filters.ThaiZonesSingleFilter ThaiZoneFilter;

	}
}
