using EIDSS.Reports.BaseControls.Filters;

namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    partial class ComparativeSeveralYearsGGReportKeeper
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComparativeSeveralYearsGGReportKeeper));
            this.Year1SpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.Year2SpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.regionFilter = new EIDSS.Reports.BaseControls.Filters.RegionAZFilter();
            this.rayonFilter = new EIDSS.Reports.BaseControls.Filters.RayonFilter();
            this.DiagnosisFilter = new EIDSS.Reports.BaseControls.Filters.HumDiagnosisGroupsDiagnosesMultiFilter();
            this.FromLabel = new System.Windows.Forms.Label();
            this.ToLabel = new System.Windows.Forms.Label();
            this.CounterFilter = new EIDSS.Reports.BaseControls.Filters.CounterMultiFilter();
            this.pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year1SpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year2SpinEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Controls.Add(this.CounterFilter);
            this.pnlSettings.Controls.Add(this.DiagnosisFilter);
            this.pnlSettings.Controls.Add(this.regionFilter);
            this.pnlSettings.Controls.Add(this.rayonFilter);
            this.pnlSettings.Controls.Add(this.Year2SpinEdit);
            this.pnlSettings.Controls.Add(this.Year1SpinEdit);
            this.pnlSettings.Controls.Add(this.ToLabel);
            this.pnlSettings.Controls.Add(this.FromLabel);
            this.pnlSettings.Controls.SetChildIndex(this.FromLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ToLabel, 0);
            this.pnlSettings.Controls.SetChildIndex(this.ceUseArchiveData, 0);
            this.pnlSettings.Controls.SetChildIndex(this.Year1SpinEdit, 0);
            this.pnlSettings.Controls.SetChildIndex(this.Year2SpinEdit, 0);
            this.pnlSettings.Controls.SetChildIndex(this.rayonFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.regionFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.DiagnosisFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.CounterFilter, 0);
            this.pnlSettings.Controls.SetChildIndex(this.GenerateReportButton, 0);
            // 
            // ceUseArchiveData
            // 
            resources.ApplyResources(this.ceUseArchiveData, "ceUseArchiveData");
            this.ceUseArchiveData.Properties.AccessibleDescription = resources.GetString("ceUseArchiveData.Properties.AccessibleDescription");
            this.ceUseArchiveData.Properties.AccessibleName = resources.GetString("ceUseArchiveData.Properties.AccessibleName");
            this.ceUseArchiveData.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.Appearance.Font")));
            this.ceUseArchiveData.Properties.Appearance.FontSizeDelta = ((int)(resources.GetObject("ceUseArchiveData.Properties.Appearance.FontSizeDelta")));
            this.ceUseArchiveData.Properties.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("ceUseArchiveData.Properties.Appearance.FontStyleDelta")));
            this.ceUseArchiveData.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("ceUseArchiveData.Properties.Appearance.GradientMode")));
            this.ceUseArchiveData.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("ceUseArchiveData.Properties.Appearance.Image")));
            this.ceUseArchiveData.Properties.Appearance.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceDisabled.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.AppearanceDisabled.Font")));
            this.ceUseArchiveData.Properties.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("ceUseArchiveData.Properties.AppearanceDisabled.FontSizeDelta")));
            this.ceUseArchiveData.Properties.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("ceUseArchiveData.Properties.AppearanceDisabled.FontStyleDelta")));
            this.ceUseArchiveData.Properties.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("ceUseArchiveData.Properties.AppearanceDisabled.GradientMode")));
            this.ceUseArchiveData.Properties.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("ceUseArchiveData.Properties.AppearanceDisabled.Image")));
            this.ceUseArchiveData.Properties.AppearanceDisabled.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceFocused.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.AppearanceFocused.Font")));
            this.ceUseArchiveData.Properties.AppearanceFocused.FontSizeDelta = ((int)(resources.GetObject("ceUseArchiveData.Properties.AppearanceFocused.FontSizeDelta")));
            this.ceUseArchiveData.Properties.AppearanceFocused.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("ceUseArchiveData.Properties.AppearanceFocused.FontStyleDelta")));
            this.ceUseArchiveData.Properties.AppearanceFocused.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("ceUseArchiveData.Properties.AppearanceFocused.GradientMode")));
            this.ceUseArchiveData.Properties.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("ceUseArchiveData.Properties.AppearanceFocused.Image")));
            this.ceUseArchiveData.Properties.AppearanceFocused.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Font = ((System.Drawing.Font)(resources.GetObject("ceUseArchiveData.Properties.AppearanceReadOnly.Font")));
            this.ceUseArchiveData.Properties.AppearanceReadOnly.FontSizeDelta = ((int)(resources.GetObject("ceUseArchiveData.Properties.AppearanceReadOnly.FontSizeDelta")));
            this.ceUseArchiveData.Properties.AppearanceReadOnly.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("ceUseArchiveData.Properties.AppearanceReadOnly.FontStyleDelta")));
            this.ceUseArchiveData.Properties.AppearanceReadOnly.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("ceUseArchiveData.Properties.AppearanceReadOnly.GradientMode")));
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Image = ((System.Drawing.Image)(resources.GetObject("ceUseArchiveData.Properties.AppearanceReadOnly.Image")));
            this.ceUseArchiveData.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.ceUseArchiveData.Properties.AutoHeight = ((bool)(resources.GetObject("ceUseArchiveData.Properties.AutoHeight")));
            this.ceUseArchiveData.Properties.Caption = resources.GetString("ceUseArchiveData.Properties.Caption");
            this.ceUseArchiveData.Properties.DisplayValueChecked = resources.GetString("ceUseArchiveData.Properties.DisplayValueChecked");
            this.ceUseArchiveData.Properties.DisplayValueGrayed = resources.GetString("ceUseArchiveData.Properties.DisplayValueGrayed");
            this.ceUseArchiveData.Properties.DisplayValueUnchecked = resources.GetString("ceUseArchiveData.Properties.DisplayValueUnchecked");
            // 
            // GenerateReportButton
            // 
            resources.ApplyResources(this.GenerateReportButton, "GenerateReportButton");
            bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(ComparativeSeveralYearsGGReportKeeper), out resources);
            // Form Is Localizable: True
            // 
            // Year1SpinEdit
            // 
            resources.ApplyResources(this.Year1SpinEdit, "Year1SpinEdit");
            this.Year1SpinEdit.Name = "Year1SpinEdit";
            this.Year1SpinEdit.Properties.AccessibleDescription = resources.GetString("Year1SpinEdit.Properties.AccessibleDescription");
            this.Year1SpinEdit.Properties.AccessibleName = resources.GetString("Year1SpinEdit.Properties.AccessibleName");
            this.Year1SpinEdit.Properties.AutoHeight = ((bool)(resources.GetObject("Year1SpinEdit.Properties.AutoHeight")));
            this.Year1SpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Year1SpinEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("Year1SpinEdit.Properties.Mask.AutoComplete")));
            this.Year1SpinEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("Year1SpinEdit.Properties.Mask.BeepOnError")));
            this.Year1SpinEdit.Properties.Mask.EditMask = resources.GetString("Year1SpinEdit.Properties.Mask.EditMask");
            this.Year1SpinEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("Year1SpinEdit.Properties.Mask.IgnoreMaskBlank")));
            this.Year1SpinEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("Year1SpinEdit.Properties.Mask.MaskType")));
            this.Year1SpinEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("Year1SpinEdit.Properties.Mask.PlaceHolder")));
            this.Year1SpinEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("Year1SpinEdit.Properties.Mask.SaveLiteral")));
            this.Year1SpinEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("Year1SpinEdit.Properties.Mask.ShowPlaceHolders")));
            this.Year1SpinEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("Year1SpinEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.Year1SpinEdit.Properties.MaxValue = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.Year1SpinEdit.Properties.MinValue = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.Year1SpinEdit.Properties.NullValuePrompt = resources.GetString("Year1SpinEdit.Properties.NullValuePrompt");
            this.Year1SpinEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("Year1SpinEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.Year1SpinEdit.EditValueChanged += new System.EventHandler(this.seYear1_EditValueChanged);
            // 
            // Year2SpinEdit
            // 
            resources.ApplyResources(this.Year2SpinEdit, "Year2SpinEdit");
            this.Year2SpinEdit.Name = "Year2SpinEdit";
            this.Year2SpinEdit.Properties.AccessibleDescription = resources.GetString("Year2SpinEdit.Properties.AccessibleDescription");
            this.Year2SpinEdit.Properties.AccessibleName = resources.GetString("Year2SpinEdit.Properties.AccessibleName");
            this.Year2SpinEdit.Properties.AutoHeight = ((bool)(resources.GetObject("Year2SpinEdit.Properties.AutoHeight")));
            this.Year2SpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.Year2SpinEdit.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("Year2SpinEdit.Properties.Mask.AutoComplete")));
            this.Year2SpinEdit.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("Year2SpinEdit.Properties.Mask.BeepOnError")));
            this.Year2SpinEdit.Properties.Mask.EditMask = resources.GetString("Year2SpinEdit.Properties.Mask.EditMask");
            this.Year2SpinEdit.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("Year2SpinEdit.Properties.Mask.IgnoreMaskBlank")));
            this.Year2SpinEdit.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("Year2SpinEdit.Properties.Mask.MaskType")));
            this.Year2SpinEdit.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("Year2SpinEdit.Properties.Mask.PlaceHolder")));
            this.Year2SpinEdit.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("Year2SpinEdit.Properties.Mask.SaveLiteral")));
            this.Year2SpinEdit.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("Year2SpinEdit.Properties.Mask.ShowPlaceHolders")));
            this.Year2SpinEdit.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("Year2SpinEdit.Properties.Mask.UseMaskAsDisplayFormat")));
            this.Year2SpinEdit.Properties.MaxValue = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.Year2SpinEdit.Properties.MinValue = new decimal(new int[] {
            2001,
            0,
            0,
            0});
            this.Year2SpinEdit.Properties.NullValuePrompt = resources.GetString("Year2SpinEdit.Properties.NullValuePrompt");
            this.Year2SpinEdit.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("Year2SpinEdit.Properties.NullValuePromptShowForEmptyValue")));
            this.Year2SpinEdit.EditValueChanged += new System.EventHandler(this.seYear2_EditValueChanged);
            // 
            // regionFilter
            // 
            resources.ApplyResources(this.regionFilter, "regionFilter");
            this.regionFilter.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("regionFilter.Appearance.Font")));
            this.regionFilter.Appearance.FontSizeDelta = ((int)(resources.GetObject("regionFilter.Appearance.FontSizeDelta")));
            this.regionFilter.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("regionFilter.Appearance.FontStyleDelta")));
            this.regionFilter.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("regionFilter.Appearance.GradientMode")));
            this.regionFilter.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("regionFilter.Appearance.Image")));
            this.regionFilter.Appearance.Options.UseFont = true;
            this.regionFilter.Name = "regionFilter";
            this.regionFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.regionFilter_ValueChanged);
            // 
            // rayonFilter
            // 
            resources.ApplyResources(this.rayonFilter, "rayonFilter");
            this.rayonFilter.Appearance.FontSizeDelta = ((int)(resources.GetObject("rayonFilter.Appearance.FontSizeDelta")));
            this.rayonFilter.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("rayonFilter.Appearance.FontStyleDelta")));
            this.rayonFilter.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("rayonFilter.Appearance.GradientMode")));
            this.rayonFilter.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("rayonFilter.Appearance.Image")));
            this.rayonFilter.Appearance.Options.UseFont = true;
            this.rayonFilter.Name = "rayonFilter";
            this.rayonFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.SingleFilterEventArgs>(this.rayonFilter_ValueChanged);
            // 
            // DiagnosisFilter
            // 
            resources.ApplyResources(this.DiagnosisFilter, "DiagnosisFilter");
            this.DiagnosisFilter.Appearance.FontSizeDelta = ((int)(resources.GetObject("DiagnosisFilter.Appearance.FontSizeDelta")));
            this.DiagnosisFilter.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("DiagnosisFilter.Appearance.FontStyleDelta")));
            this.DiagnosisFilter.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("DiagnosisFilter.Appearance.GradientMode")));
            this.DiagnosisFilter.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("DiagnosisFilter.Appearance.Image")));
            this.DiagnosisFilter.Appearance.Options.UseFont = true;
            this.DiagnosisFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.DiagnosisFilter.FilterType = EIDSS.Reports.BaseControls.Filters.HumDiagnosisGroupsType.DiagnosesAndGroupsHuman;
            this.DiagnosisFilter.Name = "DiagnosisFilter";
            this.DiagnosisFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.DiagnosisFilter_ValueChanged);
            // 
            // FromLabel
            // 
            resources.ApplyResources(this.FromLabel, "FromLabel");
            this.FromLabel.ForeColor = System.Drawing.Color.Black;
            this.FromLabel.Name = "FromLabel";
            // 
            // ToLabel
            // 
            resources.ApplyResources(this.ToLabel, "ToLabel");
            this.ToLabel.ForeColor = System.Drawing.Color.Black;
            this.ToLabel.Name = "ToLabel";
            // 
            // CounterFilter
            // 
            resources.ApplyResources(this.CounterFilter, "CounterFilter");
            this.CounterFilter.Appearance.FontSizeDelta = ((int)(resources.GetObject("CounterFilter.Appearance.FontSizeDelta")));
            this.CounterFilter.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("CounterFilter.Appearance.FontStyleDelta")));
            this.CounterFilter.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("CounterFilter.Appearance.GradientMode")));
            this.CounterFilter.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("CounterFilter.Appearance.Image")));
            this.CounterFilter.Appearance.Options.UseFont = true;
            this.CounterFilter.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CounterFilter.Name = "CounterFilter";
            this.CounterFilter.ValueChanged += new System.EventHandler<EIDSS.Reports.BaseControls.Filters.MultiFilterEventArgs>(this.CounterFilter_ValueChanged);
            this.CounterFilter.ItemCheck += new System.EventHandler<DevExpress.XtraEditors.Controls.ItemCheckEventArgs>(this.CounterFilter_ItemCheck);
            // 
            // ComparativeSeveralYearsGGReportKeeper
            // 
            resources.ApplyResources(this, "$this");
            this.HeaderHeight = 180;
            this.Name = "ComparativeSeveralYearsGGReportKeeper";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ceUseArchiveData.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year1SpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Year2SpinEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SpinEdit Year1SpinEdit;
        private DevExpress.XtraEditors.SpinEdit Year2SpinEdit;
        private RegionAZFilter regionFilter;
        private RayonFilter rayonFilter;
        private HumDiagnosisGroupsDiagnosesMultiFilter DiagnosisFilter;
        private System.Windows.Forms.Label ToLabel;
        private System.Windows.Forms.Label FromLabel;
        private CounterMultiFilter CounterFilter;
    }
}