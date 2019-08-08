using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EIDSS.Reports.BaseControls.Keeper;
using bv.model.BLToolkit;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.UA.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.UA;
using eidss.model.Reports.OperationContext;
using EIDSS.Reports.BaseControls.Filters;

namespace EIDSS.Reports.Parameterized.Human.UA.Keepers
{
    public partial class UAFormKeeper : BaseDateKeeper
    {
        internal UAFormKeeper(string type)
        {
            switch (type)
            {
                case "FormNo1":
                    ReportType = typeof(FormNo1);
                    break;

                case "FormNo2":
                    ReportType = typeof(FormNo2);
                    cbMonth.Visible = false;
                    label2.Visible = false;
                    break;
            }
            InitializeComponent();
            SetCurrentStartMonth();
            SetMandatory();

            MinYear = 2010;
            MaxYear = DateTime.Now.Year;
        }

        [Browsable(false)]
        private long? RegionID
        {
            get { return regionFilter.RegionId > 0 ? (long?)regionFilter.RegionId : null; }
        }

        protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            dynamic report = CreateReportObject();
            UAFormModel model = new UAFormModel(CurrentCulture.ShortName, YearParam, StartMonthParam, RegionID, UseArchive);

            report.SetParameters(model, manager, archiveManager);
            return (BaseReport)report;
        }

        protected internal override void ApplyResources(DbManagerProxy manager)
        {
            base.ApplyResources(manager);

            regionFilter.DefineBinding();

            if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
            {
                LocationHelper.SetDefaultFilters(manager, ContextKeeper, regionFilter);
            }
        }
    }
}
