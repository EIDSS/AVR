using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using bv.common.Core;
using bv.model.BLToolkit;
using DevExpress.Utils;
using DevExpress.XtraCharts;
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
    [NullableAdapters]
    public sealed partial class ComparativeSeveralYearsGGReport : BaseReport
    {
        private int m_RowNumber;

        public ComparativeSeveralYearsGGReport()
        {
            InitializeComponent();
        }

        public void SetParameters(ComparativeGGSeveralYearsSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            Utils.CheckNotNull(model, "model");
            Utils.CheckNotNullOrEmpty(model.Language, "lang");

            SetLanguage(model, manager);

            DateTimeCell.Text = ReportRebinder.ToDateTimeString(DateTime.Now);

            ShowWarningIfDataInArchive(manager, new DateTime(model.Year1, 1, 1), model.UseArchive);

            BindHeader(model);

            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_DataAdapter.Connection = connection;
                m_DataAdapter.Transaction = transaction;
                m_DataAdapter.CommandTimeout = CommandTimeout;
                m_DataSet.EnforceConstraints = false;

                m_DataAdapter.Fill(m_DataSet.ComparativeSeveralYears,
                    model.Language,
                    model.Year1, model.Year2,
                    FilterHelper.GetXmlFromList(model.CounterIds),
                    FilterHelper.GetXmlFromList(model.DiagnosesIds),
                    model.RegionId, model.RayonId,
                    model.SiteId);
            });
            FillDataTableWithArchive(action, 
                manager, archiveManager,
                m_DataSet.ComparativeSeveralYears,
                model.Mode,
                new[] {"strKey"}, new[] {"intYear", "intCounter"});

            CalculatePercent();

            if (model.CounterIds == null || model.CounterIds.Length ==0)
            {
                model.CounterIds = new[] {"1"};
            }
            var singleCounter = model.CounterIds.Length < 2;
            if (singleCounter)
            {
                m_DataSet.ComparativeSeveralYears.DefaultView.RowFilter = "intCounter = " + model.CounterIds[0];

                HeaderTable.BeginInit();
                DetailsTable.BeginInit();
                HeaderRow.DeleteCell(CounterHeaderCell);
                DetailsRow.DeleteCell(CounterCell);
                HeaderTable.EndInit();
                DetailsTable.EndInit();
            }
            m_DataSet.ComparativeSeveralYears.DefaultView.Sort = "intYear desc, intCounter";

            m_RowNumber = 0;

            RoundData();

            FillChartData(singleCounter);
        }

        private void CalculatePercent()
        {
            var rows = m_DataSet.ComparativeSeveralYears.Rows.Cast<ComparativeSeveralYearsGGDataSet.ComparativeSeveralYearsRow>().ToList();
            foreach (var r in rows)
            {
                Func<double, double, double> percentFunc = (val, total) => total < 1 ? 0 : 100 * val / total;

                m_DataSet.ComparativeSeveralYears.
                    AddComparativeSeveralYearsRow(string.Format("{0}_2", r.intYear),
                        r.intYear, 2,
                        percentFunc(r.intJanuary, r.intTotal),
                        percentFunc(r.intFebruary, r.intTotal),
                        percentFunc(r.intMarch, r.intTotal),
                        percentFunc(r.intApril, r.intTotal),
                        percentFunc(r.intMay, r.intTotal),
                        percentFunc(r.intJune, r.intTotal),
                        percentFunc(r.intJuly, r.intTotal),
                        percentFunc(r.intAugust, r.intTotal),
                        percentFunc(r.intSeptember, r.intTotal),
                        percentFunc(r.intOctober, r.intTotal),
                        percentFunc(r.intNovember, r.intTotal),
                        percentFunc(r.intDecember, r.intTotal),
                        100);
            }
        }

        private void BindHeader(ComparativeGGSeveralYearsSurrogateModel model)
        {
            Utils.CheckNotNull(model, "model");

            string years = string.Format("{1} - {0}", model.Year1, model.Year2);

            string country = string.Empty;
            if (m_BaseDataSet.sprepGetBaseParameters.Count > 0)
            {
                BaseDataSet.sprepGetBaseParametersRow row = m_BaseDataSet.sprepGetBaseParameters[0];
                country = row.CountryName;
            }

            string diagnosis = string.IsNullOrEmpty(model.DiagnosesName)
                ? EidssMessages.Get("msgBlankDiagnosisFilter", "Blank Diagnosis Filter")
                : model.DiagnosesName;

            string location = AddressModel.GetLocation(model.Language,
                country,
                model.RegionId, model.RegionName,
                model.RayonId, model.RayonName, true);

            HeaderLabelCell1.Text = string.Format(HeaderLabelCell1.Text, years, location, diagnosis);
        }

        private void YearCell_BeforePrint(object sender, PrintEventArgs e)
        {
            var cell = sender as XRTableCell;
            var data = m_DataSet.ComparativeSeveralYears.DefaultView;

            if (cell != null && m_RowNumber >= 0 && m_RowNumber < data.Count)
            {
                var row = data[m_RowNumber];

                if (m_RowNumber != 0 &&
                    ((int) data[m_RowNumber - 1]["intYear"] == (int) row["intYear"]))
                {
                    cell.Text = string.Empty;
                }
                cell.Borders = BorderSide.Left | BorderSide.Right;
                if (m_RowNumber == data.Count - 1 ||
                    ((int) data[m_RowNumber + 1]["intYear"] != (int) row["intYear"]))
                {
                    cell.Borders |= BorderSide.Bottom;
                }
                m_RowNumber++;
            }
        }

        private void MonthCell_BeforePrint(object sender, PrintEventArgs e)
        {
            var data = m_DataSet.ComparativeSeveralYears.DefaultView;
            if (m_RowNumber > 0 && m_RowNumber <= data.Count)
            {
                var row = data[m_RowNumber - 1];
                var cell = sender as XRTableCell;
                if ((int) row["intCounter"] == 1 && cell != null && cell.Text.Length > 3)
                {
                    cell.Text = cell.Text.Substring(0, cell.Text.Length - 3);
                }
            }
        }

        private void CounterCell_BeforePrint(object sender, PrintEventArgs e)
        {
            var cell = sender as XRTableCell;
            if (cell != null)
            {
                int counter;
                if (int.TryParse(cell.Text, out counter))
                {
                    cell.Text = GetCounterName(counter);
                }
            }
        }

        private void FillChartData(bool isCounterSingle)
        {
            var diagram = (Chart.Diagram as XYDiagram);
            if (diagram != null && diagram.SecondaryAxesY.Count > 0)
            {
                diagram.SecondaryAxesY[0].Visibility = isCounterSingle
                    ? DefaultBoolean.False
                    : DefaultBoolean.True;
            }
            if (m_DataSet.ComparativeSeveralYears.Rows.Count >= 2)
            {
                ((ISupportInitialize) (Chart)).BeginInit();
                ((ISupportInitialize) (Chart.Diagram)).BeginInit();

                foreach (KeyValuePair<int, string> month in GetMonthNames())
                {
                    var row = m_ChartDataSet.ChartData.NewChartDataRow();
                    row.Order = month.Key;
                    row.Month = month.Value;
                    m_ChartDataSet.ChartData.AddChartDataRow(row);
                }

                var seriesList = new List<Series>();
                var data = m_ChartDataSet.ChartData;
                var maxValues = new List<double>();
                int year = -1;

                var view = m_DataSet.ComparativeSeveralYears.DefaultView;
                for (int index = 0; index < view.Count; index++)
                {
                    DataRowView yearRow = view[index];
                    string valueColumnName = string.Format("Year{0}Value", index + 1);
                    if (!data.Columns.Contains(valueColumnName))
                    {
                        // Note: if exception throws, you need to add extra column to ComparativeSeveralYearsChartDataSet.ChartDataDataTable
                        throw new ArgumentOutOfRangeException(string.Format("Column {0} doesn't exist.", valueColumnName));
                    }
                    IList<double> monthValues = ChartHelperGG.GetMonthValues(yearRow);

                    for (int monthCount = 0; monthCount < data.Count; monthCount++)
                    {
                        var showValues = ((int) yearRow["intYear"]) < DateTime.Now.Year ||
                                         monthCount < DateTime.Now.Month ||
                                         monthValues[monthCount] > 0;
                        data[monthCount][valueColumnName] = showValues
                            ? (object) monthValues[monthCount]
                            : DBNull.Value;
                    }
                    bool firstSeriesOfYear = (int) yearRow["intYear"] != year;
                    if (firstSeriesOfYear)
                    {
                        maxValues.Add(monthValues.Max());
                        year = (int) yearRow["intYear"];
                    }
                    Color color = ReportChartColors.SeriesColor[index % ReportChartColors.SeriesColor.Length];
                    string seriesName = string.Format("{0} - {1}", yearRow["intYear"], GetCounterName((int) yearRow["intCounter"]));
                    Series series = ChartHelperGG.CreateLineSeriesForYear(seriesName, valueColumnName, color, firstSeriesOfYear);
                    seriesList.Add(series);
                }

                ChartHelper.DesignAxisY(Chart.Diagram as XYDiagram, maxValues.Max());

                Chart.SeriesSerializable = seriesList.ToArray();

                ((ISupportInitialize) (Chart.Diagram)).EndInit();
                ((ISupportInitialize) (Chart)).EndInit();
            }
        }

        private static string GetCounterName(int counter)
        {
            switch (counter)
            {
                case 1:
                    return EidssMessages.Instance.GetString("cbCounter0");

                case 2:
                    return EidssMessages.Instance.GetString("cbCounter1GG");
                default:
                    return "[Unsupported counter]";
            }
        }

        private Dictionary<int, string> GetMonthNames()
        {
            return new Dictionary<int, string>
            {
                {0, JanuaryHeaderCell.Text},
                {1, FebruaryHeaderCell.Text},
                {2, MarchHeaderCell.Text},
                {3, AprilHeaderCell.Text},
                {4, MayHeaderCell.Text},
                {5, JuneHeaderCell.Text},
                {6, JulyHeaderCell.Text},
                {7, AugustHeaderCell.Text},
                {8, SeptemberHeaderCell.Text},
                {9, OctoberHeaderCell.Text},
                {10, NovemberHeaderCell.Text},
                {11, DecemberHeaderCell.Text}
            };
        }

        private void RoundData()
        {
            foreach (var row in m_DataSet.ComparativeSeveralYears)
            {
                int digits = row.intCounter == 1 ? 0 : 2;

                row.intJanuary = Math.Round(row.intJanuary, digits);
                row.intFebruary = Math.Round(row.intFebruary, digits);
                row.intMarch = Math.Round(row.intMarch, digits);
                row.intApril = Math.Round(row.intApril, digits);
                row.intMay = Math.Round(row.intMay, digits);
                row.intJune = Math.Round(row.intJune, digits);
                row.intJuly = Math.Round(row.intJuly, digits);
                row.intAugust = Math.Round(row.intAugust, digits);
                row.intSeptember = Math.Round(row.intSeptember, digits);
                row.intOctober = Math.Round(row.intOctober, digits);
                row.intNovember = Math.Round(row.intNovember, digits);
                row.intDecember = Math.Round(row.intDecember, digits);
                row.intTotal = Math.Round(row.intTotal, digits);
            }
        }
    }
}