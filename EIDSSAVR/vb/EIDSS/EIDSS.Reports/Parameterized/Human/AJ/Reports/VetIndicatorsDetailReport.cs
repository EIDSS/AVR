using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Resources;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    public sealed partial class VetIndicatorsDetailReport : BaseReport
    {
        private int m_LineCounter;

        public VetIndicatorsDetailReport()
        {
            InitializeComponent();
        }

        public void SetParameters(VetIndicatorsSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(model.Language, "model.Language");

            m_LineCounter = 0;
            SetLanguage(model, manager);

            DateTimeCell.Text = ReportRebinder.ToDateTimeString(DateTime.Now);

            ShowWarningIfDataInArchive(manager, new DateTime(model.StartYear, 1, 1), model.UseArchive);

            var table = m_DataSet.VetIndicatorsDetail;
            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.Transaction = transaction;
                m_Adapter.CommandTimeout = CommandTimeout;
                m_DataSet.EnforceConstraints = false;

                m_Adapter.Fill(table, model.Language,
                    model.StartYear, model.EndYear,
                    model.StartMonth, model.EndMonth,
                    model.OrganizationEnteredById,
                    model.OrganizationId, model.SiteId);
            });
            FillDataTableWithArchive(action,
                manager, archiveManager,
                table,
                model.Mode,
                new[] {"idfsBaseReference", "strDisease"},
                new[] {"intOrder"});
            table.DefaultView.Sort = "intOrder";

            var organization = model.OrganizationEnteredById.HasValue
                ? model.OrganizationEnteredByName
                : EidssMessages.Get("strVeterinaryOrganizations", "Veterinary organizations");
            string datePeriod = GetPeriodText(model);
            SecondHeaderCell.Text = string.Format(SecondHeaderCell.Text, organization, datePeriod);

            var totalPoints = table.DefaultView.ToTable(true, "dblTotalPoints");
            var sum = totalPoints.AsEnumerable().Sum(r => (double)r["dblTotalPoints"]);
            GrandTotalPointsCell.Text = sum.ToString("0.00");
        }

        public static string GetPeriodText(VetIndicatorsSurrogateModel model)
        {
            string period;
            if (model.StartYear == model.EndYear)
            {
                if (model.StartMonth == model.EndMonth)
                {
                    period = model.StartMonth.HasValue
                        ? string.Format("{0} {1}", FilterHelper.GetMonthName(model.StartMonth.Value), model.StartYear)
                        : model.StartYear.ToString();
                }
                else
                {
                    period = model.StartMonth.HasValue && model.EndMonth.HasValue
                        ? string.Format("{0} - {1} {2}",
                            FilterHelper.GetMonthName(model.StartMonth.Value), FilterHelper.GetMonthName(model.EndMonth.Value),
                            model.StartYear)
                        : model.StartYear.ToString();
                }
            }
            else
            {
                period = model.StartMonth.HasValue && model.EndMonth.HasValue
                    ? string.Format("{0} {1} - {2} {3}",
                        FilterHelper.GetMonthName(model.StartMonth.Value), model.StartYear, FilterHelper.GetMonthName(model.EndMonth.Value),
                        model.EndYear)
                    : string.Format("{0} - {1}", model.StartYear, model.EndYear);
            }
            return period;
        }

        private void IndicatorNameCell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (m_DataSet.VetIndicatorsDetail.Rows.Count > m_LineCounter)
            {
                var row = m_DataSet.VetIndicatorsDetail[m_LineCounter];
                IndicatorNameCell.Font = (row.blnGroup)
                        ? new Font(IndicatorNameCell.Font, FontStyle.Italic)
                        : new Font(IndicatorNameCell.Font, FontStyle.Regular);
                m_LineCounter++;
            }
        }
    }
}