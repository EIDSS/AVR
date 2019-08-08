using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using DevExpress.Utils;
using DevExpress.XtraCharts;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    public static class ChartHelperGG
    {
        internal static Series CreateLineSeriesForYear(string seriesName, string valueColumnName, Color color, bool isPrimaryAxis = true)
        {
            var series = new Series();
            var point = new PointSeriesLabel();
            var view = new LineSeriesView();
            ((ISupportInitialize) (series)).BeginInit();
            ((ISupportInitialize) (point)).BeginInit();
            ((ISupportInitialize) (view)).BeginInit();

            series.Name = seriesName;
            series.ArgumentDataMember = "ChartData.Month";
            series.ValueDataMembersSerializable = "ChartData." + valueColumnName;

            point.Border.Visibility = DefaultBoolean.False;
            point.LineVisibility = DefaultBoolean.True;
            series.Label = point;

            view.Color = color;
            view.LineMarkerOptions.BorderVisible = false;
            view.LineMarkerOptions.Color = color;
            view.LineMarkerOptions.FillStyle.FillMode = FillMode.Solid;
            view.LineMarkerOptions.Kind = MarkerKind.Diamond;
            if (!isPrimaryAxis)
            {
                view.AxisYName = "Secondary AxisY 1";
            }
            series.View = view;

            ((ISupportInitialize) (point)).EndInit();
            ((ISupportInitialize) (view)).EndInit();
            ((ISupportInitialize) (series)).EndInit();
            return series;
        }

        internal static IList<double> GetMonthValues(DataRowView row)
        {
            return new List<double>
            {
                (double) row["intJanuary"],
                (double) row["intFebruary"],
                (double) row["intMarch"],
                (double) row["intApril"],
                (double) row["intMay"],
                (double) row["intJune"],
                (double) row["intJuly"],
                (double) row["intAugust"],
                (double) row["intSeptember"],
                (double) row["intOctober"],
                (double) row["intNovember"],
                (double) row["intDecember"]
            };
        }
    }
}