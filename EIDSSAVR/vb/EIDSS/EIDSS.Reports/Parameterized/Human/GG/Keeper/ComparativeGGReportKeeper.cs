using System;
using System.Collections.Generic;
using System.ComponentModel;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.winclient.Core;
using bv.winclient.Layout;
using DevExpress.XtraEditors.Controls;
using eidss.model.Core;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.Report;

namespace EIDSS.Reports.Parameterized.Human.GG.Keeper
{
    public partial class ComparativeGGReportKeeper : BaseReportKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (ComparativeGGReportKeeper));
        private List<ItemWrapper> m_MonthCollection;

        public ComparativeGGReportKeeper()
            : base(new Dictionary<string, string>())
        {
            ReportType = typeof (ComparativeGGReport);
            InitializeComponent();
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterLoading))
            {
                SetMandatory();

                Year1SpinEdit.Value = DateTime.Now.Year - 1;
                Year1SpinEdit.Properties.MaxValue = DateTime.Now.Year - 1;
                Year1SpinEdit.Properties.MinValue = 2012;

                Year2SpinEdit.Value = DateTime.Now.Year;
                Year2SpinEdit.Properties.MaxValue = DateTime.Now.Year;
                Year2SpinEdit.Properties.MinValue = 2013;

                BindLookup(StartMonthLookUp, MonthCollection, StartMonthLabel.Text);
                StartMonthLookUp.EditValue = MonthCollection[0];

                BindLookup(EndMonthLookUp, MonthCollection, EndMonthLabel.Text);
                EndMonthLookUp.EditValue = MonthCollection[DateTime.Now.Month - 1];
            }

            m_HasLoad = true;
        }

        #region Properties

        [Browsable(false)]
        protected int Year1Param
        {
            get { return (int) Year1SpinEdit.Value; }
        }

        [Browsable(false)]
        protected int Year2Param
        {
            get { return (int) Year2SpinEdit.Value; }
        }

        [Browsable(false)]
        protected int? StartMonthParam
        {
            get
            {
                return (StartMonthLookUp.EditValue == null)
                    ? (int?) null
                    : ((ItemWrapper) StartMonthLookUp.EditValue).Number;
            }
        }

        [Browsable(false)]
        protected int? EndMonthParam
        {
            get
            {
                return (EndMonthLookUp.EditValue == null)
                    ? (int?) null
                    : ((ItemWrapper) EndMonthLookUp.EditValue).Number;
            }
        }

        protected List<ItemWrapper> MonthCollection
        {
            get { return m_MonthCollection ?? (m_MonthCollection = FilterHelper.GetWinMonthList()); }
        }

        #endregion

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            long? firstRegionID = region1Filter.RegionId > 0 ? (long?) region1Filter.RegionId : null;
            long? firstRayonID = rayon1Filter.RayonId > 0 ? (long?) rayon1Filter.RayonId : null;

            var model = new ComparativeGGSurrogateModel(CurrentCulture.ShortName,
                firstRegionID, firstRayonID,
                region1Filter.SelectedText, rayon1Filter.SelectedText,
                Year1Param, Year2Param, StartMonthParam, EndMonthParam,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups,
                UseArchive);

            var report = (ComparativeGGReport) CreateReportObject();
            report.SetParameters(model, manager, archiveManager);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            try
            {
                IsResourceLoading = true;
                m_MonthCollection = null;
                m_HasLoad = false;
                base.ApplyResources(manager);

                m_Resources.ApplyResources(StartYearLabel, "StartYearLabel");
                m_Resources.ApplyResources(EndYearLabel, "EndYearLabel");
                m_Resources.ApplyResources(StartMonthLabel, "StartMonthLabel");
                m_Resources.ApplyResources(EndMonthLabel, "EndMonthLabel");

                ApplyLookupResources(StartMonthLookUp, MonthCollection, StartMonthParam, StartMonthLabel.Text);
                ApplyLookupResources(EndMonthLookUp, MonthCollection, EndMonthParam, EndMonthLabel.Text);

                region1Filter.DefineBinding();
                rayon1Filter.DefineBinding();
                region1Filter.Top = rayon1Filter.Top + 1;

                if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
                {
                    LocationHelper.SetDefaultFilters(manager, ContextKeeper, region1Filter, rayon1Filter);
                }
            }
            finally
            {
                m_HasLoad = true;
                IsResourceLoading = false;
            }
        }

        public void SetMandatory()
        {
            LayoutCorrector.SetStyleController(Year1SpinEdit, LayoutCorrector.MandatoryStyleController);
            LayoutCorrector.SetStyleController(Year2SpinEdit, LayoutCorrector.MandatoryStyleController);
        }

        private void seYear1_EditValueChanged(object sender, EventArgs e)
        {
            CorrectYearRange(true);
        }

        private void seYear2_EditValueChanged(object sender, EventArgs e)
        {
            CorrectYearRange(false);
        }

        private void CorrectYearRange(bool isYear1)
        {
            if (Year2Param <= Year1Param)
            {
                if (!ContextKeeper.ContainsContext(ContextValue.ReportFilterResetting))
                {
                    if (!Utils.IsReportsServiceRunning && !Utils.IsAvrServiceRunning)
                    {
                        ErrorForm.ShowWarning("msgComparativeReportGGCorrectYear",
                            @": The Year selected in the “First Year” filter shall be less than the Year selected in the “Second Year” filter");
                    }
                }
                using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
                {
                    if (isYear1)
                    {
                        Year1SpinEdit.EditValue = Year2Param - 1;
                    }
                    else
                    {
                        Year2SpinEdit.EditValue = Year1Param + 1;
                    }
                }
            }
        }

        private void MonthLookUp_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ClearLookUpButtonClick(sender, e, StartMonthLookUp, EndMonthLookUp);
        }

        private void StartMonthLookUp_EditValueChanged(object sender, EventArgs e)
        {
            CorrectLookupRange(StartMonthLookUp, EndMonthLookUp, MonthLookupEnum.Start);
        }

        private void EndMonthLookUp_EditValueChanged(object sender, EventArgs e)
        {
            CorrectLookupRange(StartMonthLookUp, EndMonthLookUp, MonthLookupEnum.End);
        }

        private void Region_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RegionFilterValueChanged(region1Filter, rayon1Filter, e);
            }
        }

        private void Rayon_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            if (ContextKeeper.ContainsContext(ContextValue.ReportFilterResetting))
            {
                return;
            }
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RayonFilterValueChanged(region1Filter, rayon1Filter, e);
            }
        }
    }
}