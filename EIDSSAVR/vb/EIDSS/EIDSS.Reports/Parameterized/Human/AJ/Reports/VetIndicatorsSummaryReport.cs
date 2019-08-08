using System;
using System.Data.SqlClient;
using bv.common.Core;
using bv.model.BLToolkit;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Resources;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Human.AJ.Reports
{
    
    public sealed partial class VetIndicatorsSummaryReport : BaseReport
    {
        //private int m_LineCounter;

        public VetIndicatorsSummaryReport()
        {
            InitializeComponent();
        }

        public void SetParameters(VetIndicatorsSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(model.Language, "model.Language");

            //m_LineCounter = 0;
            SetLanguage(model, manager);

            DateTimeCell.Text = ReportRebinder.ToDateTimeString(DateTime.Now);

            ShowWarningIfDataInArchive(manager, new DateTime(model.StartYear, 1, 1), model.UseArchive);

            var table = m_DataSet.VetIndicatorsSummary;
            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.Transaction = transaction;
                m_Adapter.CommandTimeout = CommandTimeout;
                m_DataSet.EnforceConstraints = false;

                m_Adapter.Fill(table, model.Language,
                    model.StartYear, model.EndYear,
                    model.StartMonth, model.EndMonth,
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

//        private void DiseaseCell_BeforePrint(object sender, PrintEventArgs e)
//        {
//            if (m_DataSet.VetIndicatorsSummary.Rows.Count > m_LineCounter)
//            {
//                var row = m_DataSet.VetIndicatorsSummary[m_LineCounter];
//                DiseaseCell.TextAlignment = (row.blnIsSubdisease)
//                    ? TextAlignment.MiddleRight
//                    : TextAlignment.MiddleLeft;
//                m_LineCounter++;
//            }
//        }
    }
}