using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.UA;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.UA.DataSets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace EIDSS.Reports.Parameterized.Human.UA.Reports
{
    [CanWorkWithArchive]
    public partial class FormNo2 : BaseReport
    {
        public FormNo2()
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
            lblYear.Text = string.Format("{0}", model.Year);

            uaReportDataSet1.EnforceConstraints = false;

            EIDSS_UA_Seed_GISDataSet2.USP_Rpt_Hum_Form2_Table1DataTable dataTable1 = uaReportDataSet1.USP_Rpt_Hum_Form2_Table1;
            EIDSS_UA_Seed_GISDataSet2.USP_Rpt_Hum_Form2_Table2DataTable dataTable2 = uaReportDataSet1.USP_Rpt_Hum_Form2_Table2;
            EIDSS_UA_Seed_GISDataSet2.USP_Rpt_Hum_Form2_Table3DataTable dataTable3 = uaReportDataSet1.USP_Rpt_Hum_Form2_Table3;

            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                uSP_Rpt_Hum_Form2_Table1TableAdapter.Connection = connection;
                uSP_Rpt_Hum_Form2_Table1TableAdapter.Transaction = transaction;
                uSP_Rpt_Hum_Form2_Table1TableAdapter.CommandTimeout = BaseReport.CommandTimeout;

                uSP_Rpt_Hum_Form2_Table1TableAdapter.Fill(dataTable1, model.Language, model.Year, model.RegionId);
            });

            Action<SqlConnection, SqlTransaction> action2 = ((connection, transaction) =>
            {
                uSP_Rpt_Hum_Form2_Table2TableAdapter.Connection = connection;
                uSP_Rpt_Hum_Form2_Table2TableAdapter.Transaction = transaction;
                uSP_Rpt_Hum_Form2_Table2TableAdapter.CommandTimeout = BaseReport.CommandTimeout;

                uSP_Rpt_Hum_Form2_Table2TableAdapter.Fill(dataTable2, model.Language, model.Year, model.RegionId);
            });

            Action<SqlConnection, SqlTransaction> action3 = ((connection, transaction) =>
            {
                uSP_Rpt_Hum_Form2_Table3TableAdapter.Connection = connection;
                uSP_Rpt_Hum_Form2_Table3TableAdapter.Transaction = transaction;
                uSP_Rpt_Hum_Form2_Table3TableAdapter.CommandTimeout = BaseReport.CommandTimeout;

                uSP_Rpt_Hum_Form2_Table3TableAdapter.Fill(dataTable3, model.Language, model.Year, model.RegionId);
            });

            BaseReport.FillDataTableWithArchive(action,
                manager, archiveManager,
                dataTable1,
                model.Mode,
                new[] { "strDiseaseName", "intRowNumber", "strICD10", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X", "XI", "XII" }, null, null, null);

            BaseReport.FillDataTableWithArchive(action2,
                manager, archiveManager,
                dataTable2,
                model.Mode,
                new[] { "strDiseaseName", "intRowNumber", "strICD10", "IntTotal", "intAge_0_17", "intAge_0_1", "intAge_1_4", "intAge_5_9", "intAge_10_14", "intAge_15_17",
                         "IntRuralTotal", "IntRuralAge_0_17" }, null, null, null);

            BaseReport.FillDataTableWithArchive(action3,
                manager, archiveManager,
                dataTable3,
                model.Mode,
                new[] { "strDiseaseName", "intRowNumber", "strICD10", "IntTotal", "IntAge_0_17", "IntAge_1Mon", "IntAge_1M1Y" }, null, null, null);

        }

        private string GetMonthName(UAFormModel model)
        {
            return model.Month.HasValue ? string.Format("{0}", FilterHelper.GetMonthName(model.Month.Value)) : model.Year.ToString();
        }
    }
}
