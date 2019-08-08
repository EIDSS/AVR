using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Core;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.UA;
using eidss.winclient.Reports;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.UA.DataSets;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace EIDSS.Reports.Parameterized.Human.UA.Reports
{
    [CanWorkWithArchive]
    public partial class FormNo1 : BaseReport
    {
        public FormNo1()
        {
            InitializeComponent();
        }

        public void SetParameters(UAFormModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            SetLanguage(model, manager);

            string format = (new CultureInfo("uk-UA")).DateTimeFormat.ShortDatePattern;

            ReportRebinder rebinder = this.GetDateRebinder(model.Language);

            FooterTime.Text = string.Format("{0}", rebinder.ToTimeString(DateTime.Now));
            //FooterDate.Text = string.Format("{0}", rebinder.ToDateString(DateTime.Now));
            FooterDate.Text = DateTime.Now.ToString(format, Thread.CurrentThread.CurrentCulture);
            lblMonth.Text = GetMonthName(model);
            lblYear.Text = string.Format("{0}", model.Year);

            uaReportDataSet1.EnforceConstraints = false;

            EIDSS_UA_Seed_GISDataSet.USP_Rpt_Hum_Form1DataTable dataTable = uaReportDataSet1.USP_Rpt_Hum_Form1;

            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                usP_Rpt_Hum_Form1TableAdapter1.Connection = connection;
                usP_Rpt_Hum_Form1TableAdapter1.Transaction = transaction;
                usP_Rpt_Hum_Form1TableAdapter1.CommandTimeout = BaseReport.CommandTimeout;

                usP_Rpt_Hum_Form1TableAdapter1.Fill(dataTable, model.Language, model.Year, model.Month, model.RegionId);
            });

            BaseReport.FillDataTableWithArchive(action,
                manager, archiveManager,
                dataTable,
                model.Mode,
                new[] { "strDiseaseName", "intRowNumber", "strICD10", "intTotal", "intAge_0_17", "intAge_0_1", "intAge_1_4", "intAge_5_9", "intAge_10_14", "intAge_15_17" }, null, null, null);
        }

        private string GetMonthName(UAFormModel model)
        {
            return model.Month.HasValue ? string.Format("{0}", FilterHelper.GetMonthName(model.Month.Value)) : model.Year.ToString();
        }
    }
}
