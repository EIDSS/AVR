using System;
using System.Data.SqlClient;
using System.Drawing.Printing;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using eidss.model.Resources;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.GG.DataSet;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    [CanWorkWithArchive]
    public sealed partial class 
        ComparativeGGReport : BaseReport
    {
        private int m_LineCounter;

        public ComparativeGGReport()
        {
            InitializeComponent();
        }

        public void SetParameters(ComparativeGGSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(model.Language, "model.Language");

            m_LineCounter = 0;
            SetLanguage(model, manager);

            DateTimeCell.Text = ReportRebinder.ToDateTimeString(DateTime.Now);

            ShowWarningIfDataInArchive(manager, new DateTime(model.Year1, 1, 1), model.UseArchive);

            var table = m_DataSet.Comparative;
            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.Transaction = transaction;
                m_Adapter.CommandTimeout = CommandTimeout;
                m_DataSet.EnforceConstraints = false;

                m_Adapter.Fill(table, model.Language,
                    model.Year1, model.Year2,
                    model.StartMonth, model.EndMonth,
                    model.RegionId, model.RayonId, model.SiteId);
            });
            FillDataTableWithArchive(action,
                manager, archiveManager,
                table,
                model.Mode,
                new[] {"idfsBaseReference", "strDisease"},
                new[] {"intOrder"});
            table.DefaultView.Sort = "intOrder";

            BindHeaderCells(model);

            PrepareYearVariables(table);
            PrepareTotalGrowthVariables(table);
        }

        private void BindHeaderCells(ComparativeGGSurrogateModel model)
        {
            string country = string.Empty;
            if (m_BaseDataSet.sprepGetBaseParameters.Count > 0)
            {
                BaseDataSet.sprepGetBaseParametersRow row = m_BaseDataSet.sprepGetBaseParameters[0];
                country = row.CountryName;
            }
            string location = AddressModel.GetLocation(model.Language,
                country,
                model.RegionId, model.RegionName,
                model.RayonId, model.RayonName, true);

            string years = string.Format("{0} - {1}", model.Year1, model.Year2);
            string monthes = GetPeriodText(model);
            HeaderCell.Text = string.Format(HeaderCell.Text, monthes, years, location);

            Header12MonthYear1Cell.Text = string.Format(Header12MonthYear1Cell.Text, monthes, model.Year1);
            Header12MonthYear2Cell.Text = string.Format(Header12MonthYear2Cell.Text, monthes, model.Year2);
        }

        public static string GetPeriodText(ComparativeGGSurrogateModel model)
        {
            string period;

            if (model.StartMonth.HasValue && model.EndMonth.HasValue)
            {
                var startMonthName = FilterHelper.GetMonthName(model.StartMonth.Value);
                var endMonthName = FilterHelper.GetMonthName(model.EndMonth.Value);
                period = model.StartMonth == model.EndMonth
                    ? startMonthName
                    : string.Format("{0} - {1}", startMonthName, endMonthName);
            }
            else
            {
                period = string.Format("{0} - {1}", FilterHelper.GetMonthName(1), FilterHelper.GetMonthName(12));
            }

            return period;
        }

        private void DiseaseCell_BeforePrint(object sender, PrintEventArgs e)
        {
            if (m_DataSet.Comparative.Rows.Count > m_LineCounter)
            {
                var row = m_DataSet.Comparative[m_LineCounter];
                DiseaseCell.TextAlignment = (row.blnIsSubdisease)
                    ? TextAlignment.MiddleRight
                    : TextAlignment.MiddleLeft;
                m_LineCounter++;
            }
        }

        private void PopulationCell_BeforePrint(object sender, PrintEventArgs e)
        {
            var na = EidssMessages.Get("strReportNA", "N/A");
            var label = sender as XRLabel;
            if (label != null && string.IsNullOrEmpty(label.Text))
            {
                label.Text = na;
            }
        }

        private static void PrepareYearVariables(ComparativeGGDataSet.ComparativeDataTable table)
        {
            foreach (ComparativeGGDataSet.ComparativeRow row in table)
            {
                if (row.IsdblTotal_By100000_Y1Null() || row.IsdblTotal_By100000_Y2Null())
                {
                    if (!row.IsintTotal_Abs_Y1Null() && !row.IsintTotal_Abs_Y2Null())
                    {
                        row.dblTotal_V_Y1 = row.intTotal_Abs_Y1;
                        row.dblTotal_V_Y2 = row.intTotal_Abs_Y2;
                    }
                }
                else
                {
                    row.dblTotal_V_Y1 = row.dblTotal_By100000_Y1;
                    row.dblTotal_V_Y2 = row.dblTotal_By100000_Y2;
                }

                if (row.IsdblChildren_By100000_Y1Null() || row.IsdblChildren_By100000_Y2Null())
                {
                    if (!row.IsintChildren_Abs_Y1Null() && !row.IsintChildren_Abs_Y2Null())
                    {
                        row.dblChilderen_V_Y1 = row.intChildren_Abs_Y1;
                        row.dblChilderen_V_Y2 = row.intChildren_Abs_Y2;
                    }
                }
                else
                {
                    row.dblChilderen_V_Y1 = row.dblChildren_By100000_Y1;
                    row.dblChilderen_V_Y2 = row.dblChildren_By100000_Y2;
                }
            }
        }

        private static void PrepareTotalGrowthVariables(ComparativeGGDataSet.ComparativeDataTable table)
        {
            foreach (ComparativeGGDataSet.ComparativeRow row in table)
            {
                if (row.IsdblTotal_V_Y1Null() || row.IsdblTotal_V_Y2Null())
                {
                    row.strTotal_Growth = EidssMessages.Get("strReportNA", "N/A");
                }
                else
                {
                    row.strTotal_Growth = GetTotalGrowth(row.dblTotal_V_Y1, row.dblTotal_V_Y2);
                }
            }
            foreach (ComparativeGGDataSet.ComparativeRow row in table)
            {
                if (row.IsdblChilderen_V_Y1Null() || row.IsdblChilderen_V_Y1Null())
                {
                    row.strChildren_Growth = EidssMessages.Get("strReportNA", "N/A");
                }
                else
                {
                    row.strChildren_Growth = GetTotalGrowth(row.dblChilderen_V_Y1, row.dblChilderen_V_Y2);
                }
            }
        }

        private static string GetTotalGrowth(decimal v1, decimal v2)
        {
            string strTotalGrowth;

            //b
            if (v1 == v2)
            {
                strTotalGrowth = "0.0";
            }
            //c
            else if (v2 == 0)
            {
                strTotalGrowth = "-100.0";
            }
            //d
            else if (v1 == 0)
            {
                strTotalGrowth = "+100.0";
            }
            //e
            else
            {
                var result = 100 * (v2 - v1) / v1;
                strTotalGrowth = string.Format("{0}{1:0.0}%", result > 0 ? "+" : "", result);
            }

            return strTotalGrowth;
        }
    }
}