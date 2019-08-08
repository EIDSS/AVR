using System;
using System.ComponentModel;
using bv.model.BLToolkit;
using bv.winclient.Core;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.AJ.Reports;

namespace EIDSS.Reports.Parameterized.Human.AJ.Keepers
{
    public partial class DataQualityIndicatorsKeeper : BaseDateKeeper
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (DataQualityIndicatorsKeeper));
        private string[] m_DiagnosisItems = new string[0];
        private readonly bool m_IsByRayons;

        public DataQualityIndicatorsKeeper(bool isByRayons)
        {
            m_IsByRayons = isByRayons;
            ReportType = m_IsByRayons
                ? typeof (DataQualityIndicatorsRayonsReport)
                : typeof (DataQualityIndicatorsReport);
            MonthEndFollowsMonth = true;

            InitializeComponent();

            SetCurrentStartMonth();

            //    RemoveClearButtonMonthEnd();

            if (m_IsByRayons)
            {
                HeaderHeight = 130;
                diagnosisFilter.Width = 277;
                GenerateReportButton.Top = 70;
                GenerateReportButton.Left = 649;
                ceArrangeRayons.Top = 73;
                ceArrangeRayons.Left = 342;
                rayonFilter.Visible = false;
                regionFilter.Visible = false;
            }
            regionFilter.ShowTransportCHE = true;
            rayonFilter.ShowTransportCHE = true;
            MaxYear = DateTime.Now.Year;
            MinYear = 2000;

            m_HasLoad = true;
        }

        [Browsable(false)]
        private long? RegionIdParam
        {
            get { return regionFilter.RegionId > 0 ? (long?) regionFilter.RegionId : null; }
        }

        [Browsable(false)]
        private long? RayonIdParam
        {
            get { return rayonFilter.RayonId > 0 ? (long?) rayonFilter.RayonId : null; }
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            var model = new DataQualityIndicatorsSurrogateModel(CurrentCulture.ShortName,
                m_DiagnosisItems, diagnosisFilter.GetDisplayText(),
                YearParam, StartMonthParam, EndMonthParam,
                m_IsByRayons ? null : RegionIdParam, m_IsByRayons ? null : RayonIdParam,
                regionFilter.SelectedText, rayonFilter.SelectedText,
                ceArrangeRayons.Checked,
                Convert.ToInt64(EidssUserContext.User.OrganizationID),
                EidssUserContext.User.ForbiddenPersonalDataGroups, UseArchive);

            dynamic report = CreateReportObject();

            report.SetParameters(model, manager, archiveManager);
            return report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);
            m_Resources.ApplyResources(pnlSettings, "pnlSettings");
            ceArrangeRayons.Text = m_Resources.GetString("ceArrangeRayons.Properties.Caption");
            diagnosisFilter.FilterType = HumDiagnosisGroupsType.DiagnosesAndGroupsHumanStandard;
            diagnosisFilter.DefineBinding();
            regionFilter.DefineBinding();
            rayonFilter.DefineBinding();
            if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
            {
                LocationHelper.SetDefaultFilters(manager, ContextKeeper, regionFilter, rayonFilter);
            }
        }

        protected override bool CheckBusinessRules(bool printException)
        {
            if (m_DiagnosisItems.Length > 12)
            {
                const string defaultFormat =
                    "Too many diagnoses are selected for displaying in the report. The number of selected diagnoses shall not exceed twelve. Please clear some diagnoses and try to generate the report again.";
                ErrorForm.ShowWarning("msgTooManyDiagnosis12", defaultFormat);
                return false;
            }
            return true;
        }

        private void diagnosisFilter1_ValueChanged(object sender, MultiFilterEventArgs e)
        {
            m_DiagnosisItems = e.KeyArray;
        }

        private void regionFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RegionFilterValueChanged(regionFilter, rayonFilter, e);
            }
        }

        private void rayonFilter_ValueChanged(object sender, SingleFilterEventArgs e)
        {
            using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
            {
                LocationHelper.RayonFilterValueChanged(regionFilter, rayonFilter, e);
            }
        }
    }
}