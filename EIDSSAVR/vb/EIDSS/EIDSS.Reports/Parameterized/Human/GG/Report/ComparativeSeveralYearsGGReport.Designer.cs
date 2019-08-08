using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using EIDSS.Reports.Parameterized.Human.AJ.DataSets;
using EIDSS.Reports.Parameterized.Human.GG.DataSet;
using EIDSS.Reports.Parameterized.Human.GG.DataSet.ComparativeSeveralYearsGGDataSetTableAdapters;

namespace EIDSS.Reports.Parameterized.Human.GG.Report
{
    partial class ComparativeSeveralYearsGGReport
    {

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComparativeSeveralYearsGGReport));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY1 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel2 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
            this.m_ChartDataSet = new EIDSS.Reports.Parameterized.Human.AJ.DataSets.ComparativeTwoYearsChartDataSet();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.ComparativeDetail = new DevExpress.XtraReports.UI.DetailBand();
            this.DetailsTable = new DevExpress.XtraReports.UI.XRTable();
            this.DetailsRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.YearCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.CounterCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.JanuaryCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.FebruaryCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.MarchCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.AprilCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.MayCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.JuneCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.JulyCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.AugustCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SeptemberCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.OctoberCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.NovemberCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.DecemberCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.TotalCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.ComparativeReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.HeaderLabelTable = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.HeaderLabelCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.HeaderTable = new DevExpress.XtraReports.UI.XRTable();
            this.HeaderRow = new DevExpress.XtraReports.UI.XRTableRow();
            this.MonthYearHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.CounterHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.JanuaryHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.FebruaryHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.MarchHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.AprilHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.MayHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.JuneHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.JulyHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.AugustHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.SeptemberHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.OctoberHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.NovemberHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.DecemberHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.TotalHeaderCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.m_DataAdapter = new EIDSS.Reports.Parameterized.Human.GG.DataSet.ComparativeSeveralYearsGGDataSetTableAdapters.ComparativeSeveralYearsTableAdapter();
            this.m_DataSet = new EIDSS.Reports.Parameterized.Human.GG.DataSet.ComparativeSeveralYearsGGDataSet();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.SignatureTable = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.OrganizationNameCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.DateTimeCell = new DevExpress.XtraReports.UI.XRTableCell();
            this.Chart = new DevExpress.XtraReports.UI.XRChart();
            ((System.ComponentModel.ISupportInitialize)(this.m_BaseDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ChartDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderLabelTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SignatureTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // cellLanguage
            // 
            this.cellLanguage.StylePriority.UseTextAlignment = false;
            // 
            // lblReportName
            // 
            this.lblReportName.StylePriority.UseBorders = false;
            this.lblReportName.StylePriority.UseBorderWidth = false;
            this.lblReportName.StylePriority.UseFont = false;
            this.lblReportName.StylePriority.UseTextAlignment = false;
            // 
            // Detail
            // 
            this.Detail.StylePriority.UseFont = false;
            this.Detail.StylePriority.UsePadding = false;
            // 
            // PageHeader
            // 
            resources.ApplyResources(this.PageHeader, "PageHeader");
            this.PageHeader.StylePriority.UseFont = false;
            this.PageHeader.StylePriority.UsePadding = false;
            // 
            // PageFooter
            // 
            this.PageFooter.StylePriority.UseBorders = false;
            resources.ApplyResources(this.PageFooter, "PageFooter");
            // 
            // ReportHeader
            // 
            this.ReportHeader.Expanded = false;
            resources.ApplyResources(this.ReportHeader, "ReportHeader");
            // 
            // xrPageInfo1
            // 
            resources.ApplyResources(this.xrPageInfo1, "xrPageInfo1");
            this.xrPageInfo1.StylePriority.UseBorders = false;
            // 
            // cellReportHeader
            // 
            this.cellReportHeader.StylePriority.UseBorders = false;
            this.cellReportHeader.StylePriority.UseFont = false;
            this.cellReportHeader.StylePriority.UseTextAlignment = false;
            // 
            // cellBaseSite
            // 
            this.cellBaseSite.StylePriority.UseBorders = false;
            this.cellBaseSite.StylePriority.UseFont = false;
            this.cellBaseSite.StylePriority.UseTextAlignment = false;
            // 
            // tableBaseHeader
            // 
            this.tableBaseHeader.StylePriority.UseBorders = false;
            this.tableBaseHeader.StylePriority.UseBorderWidth = false;
            this.tableBaseHeader.StylePriority.UseFont = false;
            this.tableBaseHeader.StylePriority.UsePadding = false;
            this.tableBaseHeader.StylePriority.UseTextAlignment = false;
            // 
            // m_ChartDataSet
            // 
            this.m_ChartDataSet.DataSetName = "ComparativeTwoYearsChartDataSet";
            this.m_ChartDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.ComparativeDetail,
            this.ComparativeReportHeader});
            this.DetailReport.DataAdapter = this.m_DataAdapter;
            this.DetailReport.DataMember = "ComparativeSeveralYears";
            this.DetailReport.DataSource = this.m_DataSet;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // ComparativeDetail
            // 
            this.ComparativeDetail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.DetailsTable});
            resources.ApplyResources(this.ComparativeDetail, "ComparativeDetail");
            this.ComparativeDetail.Name = "ComparativeDetail";
            this.ComparativeDetail.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.ComparativeDetail.StylePriority.UseFont = false;
            this.ComparativeDetail.StylePriority.UsePadding = false;
            this.ComparativeDetail.StylePriority.UseTextAlignment = false;
            // 
            // DetailsTable
            // 
            this.DetailsTable.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            resources.ApplyResources(this.DetailsTable, "DetailsTable");
            this.DetailsTable.Name = "DetailsTable";
            this.DetailsTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.DetailsRow});
            this.DetailsTable.StylePriority.UseBorders = false;
            // 
            // DetailsRow
            // 
            this.DetailsRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.YearCell,
            this.CounterCell,
            this.JanuaryCell,
            this.FebruaryCell,
            this.MarchCell,
            this.AprilCell,
            this.MayCell,
            this.JuneCell,
            this.JulyCell,
            this.AugustCell,
            this.SeptemberCell,
            this.OctoberCell,
            this.NovemberCell,
            this.DecemberCell,
            this.TotalCell});
            this.DetailsRow.Name = "DetailsRow";
            resources.ApplyResources(this.DetailsRow, "DetailsRow");
            // 
            // YearCell
            // 
            this.YearCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ComparativeSeveralYears.intYear")});
            this.YearCell.Name = "YearCell";
            this.YearCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.YearCell, "YearCell");
            this.YearCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.YearCell_BeforePrint);
            // 
            // CounterCell
            // 
            this.CounterCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ComparativeSeveralYears.intCounter")});
            this.CounterCell.Name = "CounterCell";
            this.CounterCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.CounterCell, "CounterCell");
            this.CounterCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.CounterCell_BeforePrint);
            // 
            // JanuaryCell
            // 
            this.JanuaryCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ComparativeSeveralYears.intJanuary", "{0:0.00}")});
            this.JanuaryCell.Name = "JanuaryCell";
            this.JanuaryCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.JanuaryCell, "JanuaryCell");
            this.JanuaryCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.MonthCell_BeforePrint);
            // 
            // FebruaryCell
            // 
            this.FebruaryCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ComparativeSeveralYears.intFebruary", "{0:0.00}")});
            this.FebruaryCell.Name = "FebruaryCell";
            this.FebruaryCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.FebruaryCell, "FebruaryCell");
            this.FebruaryCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.MonthCell_BeforePrint);
            // 
            // MarchCell
            // 
            this.MarchCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ComparativeSeveralYears.intMarch", "{0:0.00}")});
            this.MarchCell.Name = "MarchCell";
            this.MarchCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.MarchCell, "MarchCell");
            this.MarchCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.MonthCell_BeforePrint);
            // 
            // AprilCell
            // 
            this.AprilCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ComparativeSeveralYears.intApril", "{0:0.00}")});
            this.AprilCell.Name = "AprilCell";
            this.AprilCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.AprilCell, "AprilCell");
            this.AprilCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.MonthCell_BeforePrint);
            // 
            // MayCell
            // 
            this.MayCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ComparativeSeveralYears.intMay", "{0:0.00}")});
            this.MayCell.Name = "MayCell";
            this.MayCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.MayCell, "MayCell");
            this.MayCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.MonthCell_BeforePrint);
            // 
            // JuneCell
            // 
            this.JuneCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ComparativeSeveralYears.intJune", "{0:0.00}")});
            this.JuneCell.Name = "JuneCell";
            this.JuneCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.JuneCell, "JuneCell");
            this.JuneCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.MonthCell_BeforePrint);
            // 
            // JulyCell
            // 
            this.JulyCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ComparativeSeveralYears.intJuly", "{0:0.00}")});
            this.JulyCell.Name = "JulyCell";
            this.JulyCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.JulyCell, "JulyCell");
            this.JulyCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.MonthCell_BeforePrint);
            // 
            // AugustCell
            // 
            this.AugustCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ComparativeSeveralYears.intAugust", "{0:0.00}")});
            this.AugustCell.Name = "AugustCell";
            this.AugustCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.AugustCell, "AugustCell");
            this.AugustCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.MonthCell_BeforePrint);
            // 
            // SeptemberCell
            // 
            this.SeptemberCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ComparativeSeveralYears.intSeptember", "{0:0.00}")});
            this.SeptemberCell.Name = "SeptemberCell";
            this.SeptemberCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.SeptemberCell, "SeptemberCell");
            this.SeptemberCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.MonthCell_BeforePrint);
            // 
            // OctoberCell
            // 
            this.OctoberCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ComparativeSeveralYears.intOctober", "{0:0.00}")});
            this.OctoberCell.Name = "OctoberCell";
            this.OctoberCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.OctoberCell, "OctoberCell");
            this.OctoberCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.MonthCell_BeforePrint);
            // 
            // NovemberCell
            // 
            this.NovemberCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ComparativeSeveralYears.intNovember", "{0:0.00}")});
            this.NovemberCell.Name = "NovemberCell";
            this.NovemberCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.NovemberCell, "NovemberCell");
            this.NovemberCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.MonthCell_BeforePrint);
            // 
            // DecemberCell
            // 
            this.DecemberCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ComparativeSeveralYears.intDecember", "{0:0.00}")});
            this.DecemberCell.Name = "DecemberCell";
            this.DecemberCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.DecemberCell, "DecemberCell");
            this.DecemberCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.MonthCell_BeforePrint);
            // 
            // TotalCell
            // 
            this.TotalCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "ComparativeSeveralYears.intTotal", "{0:0.00}")});
            this.TotalCell.Name = "TotalCell";
            this.TotalCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.TotalCell, "TotalCell");
            this.TotalCell.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.MonthCell_BeforePrint);
            // 
            // ComparativeReportHeader
            // 
            this.ComparativeReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.HeaderLabelTable,
            this.HeaderTable});
            resources.ApplyResources(this.ComparativeReportHeader, "ComparativeReportHeader");
            this.ComparativeReportHeader.Name = "ComparativeReportHeader";
            this.ComparativeReportHeader.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.ComparativeReportHeader.StylePriority.UseFont = false;
            this.ComparativeReportHeader.StylePriority.UsePadding = false;
            this.ComparativeReportHeader.StylePriority.UseTextAlignment = false;
            // 
            // HeaderLabelTable
            // 
            resources.ApplyResources(this.HeaderLabelTable, "HeaderLabelTable");
            this.HeaderLabelTable.Name = "HeaderLabelTable";
            this.HeaderLabelTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.HeaderLabelTable.StylePriority.UseFont = false;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.HeaderLabelCell1});
            this.xrTableRow1.Name = "xrTableRow1";
            resources.ApplyResources(this.xrTableRow1, "xrTableRow1");
            // 
            // HeaderLabelCell1
            // 
            this.HeaderLabelCell1.Name = "HeaderLabelCell1";
            this.HeaderLabelCell1.StylePriority.UseFont = false;
            resources.ApplyResources(this.HeaderLabelCell1, "HeaderLabelCell1");
            // 
            // HeaderTable
            // 
            this.HeaderTable.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            resources.ApplyResources(this.HeaderTable, "HeaderTable");
            this.HeaderTable.Name = "HeaderTable";
            this.HeaderTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.HeaderRow});
            this.HeaderTable.StylePriority.UseBorders = false;
            // 
            // HeaderRow
            // 
            this.HeaderRow.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.MonthYearHeaderCell,
            this.CounterHeaderCell,
            this.JanuaryHeaderCell,
            this.FebruaryHeaderCell,
            this.MarchHeaderCell,
            this.AprilHeaderCell,
            this.MayHeaderCell,
            this.JuneHeaderCell,
            this.JulyHeaderCell,
            this.AugustHeaderCell,
            this.SeptemberHeaderCell,
            this.OctoberHeaderCell,
            this.NovemberHeaderCell,
            this.DecemberHeaderCell,
            this.TotalHeaderCell});
            this.HeaderRow.Name = "HeaderRow";
            resources.ApplyResources(this.HeaderRow, "HeaderRow");
            // 
            // MonthYearHeaderCell
            // 
            this.MonthYearHeaderCell.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.MonthYearHeaderCell.Name = "MonthYearHeaderCell";
            this.MonthYearHeaderCell.StylePriority.UseBorders = false;
            this.MonthYearHeaderCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.MonthYearHeaderCell, "MonthYearHeaderCell");
            // 
            // CounterHeaderCell
            // 
            this.CounterHeaderCell.Name = "CounterHeaderCell";
            this.CounterHeaderCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.CounterHeaderCell, "CounterHeaderCell");
            // 
            // JanuaryHeaderCell
            // 
            this.JanuaryHeaderCell.Name = "JanuaryHeaderCell";
            this.JanuaryHeaderCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.JanuaryHeaderCell, "JanuaryHeaderCell");
            // 
            // FebruaryHeaderCell
            // 
            this.FebruaryHeaderCell.Name = "FebruaryHeaderCell";
            this.FebruaryHeaderCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.FebruaryHeaderCell, "FebruaryHeaderCell");
            // 
            // MarchHeaderCell
            // 
            this.MarchHeaderCell.Name = "MarchHeaderCell";
            this.MarchHeaderCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.MarchHeaderCell, "MarchHeaderCell");
            // 
            // AprilHeaderCell
            // 
            this.AprilHeaderCell.Name = "AprilHeaderCell";
            this.AprilHeaderCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.AprilHeaderCell, "AprilHeaderCell");
            // 
            // MayHeaderCell
            // 
            this.MayHeaderCell.Name = "MayHeaderCell";
            this.MayHeaderCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.MayHeaderCell, "MayHeaderCell");
            // 
            // JuneHeaderCell
            // 
            this.JuneHeaderCell.Name = "JuneHeaderCell";
            this.JuneHeaderCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.JuneHeaderCell, "JuneHeaderCell");
            // 
            // JulyHeaderCell
            // 
            this.JulyHeaderCell.Name = "JulyHeaderCell";
            this.JulyHeaderCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.JulyHeaderCell, "JulyHeaderCell");
            // 
            // AugustHeaderCell
            // 
            this.AugustHeaderCell.Name = "AugustHeaderCell";
            this.AugustHeaderCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.AugustHeaderCell, "AugustHeaderCell");
            // 
            // SeptemberHeaderCell
            // 
            this.SeptemberHeaderCell.Name = "SeptemberHeaderCell";
            this.SeptemberHeaderCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.SeptemberHeaderCell, "SeptemberHeaderCell");
            // 
            // OctoberHeaderCell
            // 
            this.OctoberHeaderCell.Name = "OctoberHeaderCell";
            this.OctoberHeaderCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.OctoberHeaderCell, "OctoberHeaderCell");
            // 
            // NovemberHeaderCell
            // 
            this.NovemberHeaderCell.Name = "NovemberHeaderCell";
            this.NovemberHeaderCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.NovemberHeaderCell, "NovemberHeaderCell");
            // 
            // DecemberHeaderCell
            // 
            this.DecemberHeaderCell.Name = "DecemberHeaderCell";
            this.DecemberHeaderCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.DecemberHeaderCell, "DecemberHeaderCell");
            // 
            // TotalHeaderCell
            // 
            this.TotalHeaderCell.Name = "TotalHeaderCell";
            this.TotalHeaderCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.TotalHeaderCell, "TotalHeaderCell");
            // 
            // m_DataAdapter
            // 
            this.m_DataAdapter.ClearBeforeFill = true;
            // 
            // m_DataSet
            // 
            this.m_DataSet.DataSetName = "ComparativeDataSet";
            this.m_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.SignatureTable,
            this.Chart});
            resources.ApplyResources(this.ReportFooter, "ReportFooter");
            this.ReportFooter.Name = "ReportFooter";
            this.ReportFooter.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand;
            this.ReportFooter.StylePriority.UseFont = false;
            // 
            // SignatureTable
            // 
            resources.ApplyResources(this.SignatureTable, "SignatureTable");
            this.SignatureTable.Name = "SignatureTable";
            this.SignatureTable.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 100F);
            this.SignatureTable.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow7});
            this.SignatureTable.StylePriority.UseFont = false;
            this.SignatureTable.StylePriority.UsePadding = false;
            this.SignatureTable.StylePriority.UseTextAlignment = false;
            // 
            // xrTableRow7
            // 
            this.xrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.OrganizationNameCell,
            this.xrTableCell4,
            this.DateTimeCell});
            this.xrTableRow7.Name = "xrTableRow7";
            resources.ApplyResources(this.xrTableRow7, "xrTableRow7");
            // 
            // OrganizationNameCell
            // 
            this.OrganizationNameCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "sprepGetBaseParameters.SiteName")});
            this.OrganizationNameCell.Name = "OrganizationNameCell";
            this.OrganizationNameCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.OrganizationNameCell, "OrganizationNameCell");
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseFont = false;
            this.xrTableCell4.StylePriority.UseTextAlignment = false;
            resources.ApplyResources(this.xrTableCell4, "xrTableCell4");
            // 
            // DateTimeCell
            // 
            this.DateTimeCell.Name = "DateTimeCell";
            this.DateTimeCell.StylePriority.UseFont = false;
            resources.ApplyResources(this.DateTimeCell, "DateTimeCell");
            // 
            // Chart
            // 
            resources.ApplyResources(this.Chart, "Chart");
            this.Chart.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Chart.DataSource = this.m_ChartDataSet;
            xyDiagram1.AxisX.Label.Angle = ((int)(resources.GetObject("resource.Angle")));
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.MinorCount = 3;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.WholeRange.AutoSideMargins = false;
            xyDiagram1.AxisY.WholeRange.SideMarginsValue = 0D;
            xyDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.False;
            secondaryAxisY1.AxisID = 0;
            secondaryAxisY1.Name = "Secondary AxisY 1";
            secondaryAxisY1.VisibleInPanesSerializable = "-1";
            secondaryAxisY1.WholeRange.AutoSideMargins = false;
            secondaryAxisY1.WholeRange.SideMarginsValue = 0D;
            xyDiagram1.SecondaryAxesY.AddRange(new DevExpress.XtraCharts.SecondaryAxisY[] {
            secondaryAxisY1});
            this.Chart.Diagram = xyDiagram1;
            this.Chart.Name = "Chart";
            series1.ArgumentDataMember = "ChartData.Month";
            pointSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            pointSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Label = pointSeriesLabel1;
            resources.ApplyResources(series1, "series1");
            series1.ValueDataMembersSerializable = "ChartData.Year1Value";
            lineSeriesView1.Color = System.Drawing.Color.Blue;
            lineSeriesView1.LineMarkerOptions.BorderVisible = false;
            lineSeriesView1.LineMarkerOptions.Color = System.Drawing.Color.Blue;
            lineSeriesView1.LineMarkerOptions.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
            lineSeriesView1.LineMarkerOptions.Kind = DevExpress.XtraCharts.MarkerKind.Diamond;
            series1.View = lineSeriesView1;
            series2.ArgumentDataMember = "ChartData.Month";
            sideBySideBarSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            sideBySideBarSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Label = sideBySideBarSeriesLabel1;
            resources.ApplyResources(series2, "series2");
            series2.ValueDataMembersSerializable = "ChartData.Year2Value";
            sideBySideBarSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            sideBySideBarSeriesView1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
            sideBySideBarSeriesView1.Transparency = ((byte)(30));
            series2.View = sideBySideBarSeriesView1;
            this.Chart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            pointSeriesLabel2.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
            this.Chart.SeriesTemplate.Label = pointSeriesLabel2;
            this.Chart.SeriesTemplate.View = lineSeriesView2;
            // 
            // ComparativeSeveralYearsGGReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.PageHeader,
            this.PageFooter,
            this.ReportHeader,
            this.DetailReport,
            this.ReportFooter});
            this.Version = "15.1";
            this.Controls.SetChildIndex(this.ReportFooter, 0);
            this.Controls.SetChildIndex(this.DetailReport, 0);
            this.Controls.SetChildIndex(this.ReportHeader, 0);
            this.Controls.SetChildIndex(this.PageFooter, 0);
            this.Controls.SetChildIndex(this.PageHeader, 0);
            this.Controls.SetChildIndex(this.Detail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_BaseDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBaseHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_ChartDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderLabelTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeaderTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SignatureTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DetailReportBand DetailReport;
        private DetailBand ComparativeDetail;
        private ReportHeaderBand ComparativeReportHeader;
        private ComparativeSeveralYearsGGDataSet m_DataSet;
        private ComparativeSeveralYearsTableAdapter m_DataAdapter;
        private ReportFooterBand ReportFooter;
        private XRTable DetailsTable;
        private XRTableRow DetailsRow;
        private XRTableCell YearCell;
        private XRTableCell JanuaryCell;
        private XRTableCell FebruaryCell;
        private XRTableCell MarchCell;
        private XRTableCell AprilCell;
        private XRTableCell MayCell;
        private XRTableCell JuneCell;
        private XRTableCell JulyCell;
        private XRTableCell AugustCell;
        private XRTableCell SeptemberCell;
        private XRTableCell OctoberCell;
        private XRTableCell NovemberCell;
        private XRTableCell DecemberCell;
        private XRTableCell TotalCell;
        private XRTable HeaderTable;
        private XRTableRow HeaderRow;
        private XRTableCell MonthYearHeaderCell;
        private XRTableCell JanuaryHeaderCell;
        private XRTableCell FebruaryHeaderCell;
        private XRTableCell MarchHeaderCell;
        private XRTableCell AprilHeaderCell;
        private XRTableCell MayHeaderCell;
        private XRTableCell JuneHeaderCell;
        private XRTableCell JulyHeaderCell;
        private XRTableCell AugustHeaderCell;
        private XRTableCell SeptemberHeaderCell;
        private XRTableCell OctoberHeaderCell;
        private XRTableCell NovemberHeaderCell;
        private XRTableCell DecemberHeaderCell;
        private XRTableCell TotalHeaderCell;
        private XRChart Chart;
        private ComparativeTwoYearsChartDataSet m_ChartDataSet;
        private XRTable SignatureTable;
        private XRTableRow xrTableRow7;
        private XRTableCell OrganizationNameCell;
        private XRTableCell xrTableCell4;
        private XRTableCell DateTimeCell;
        private XRTable HeaderLabelTable;
        private XRTableRow xrTableRow1;
        private XRTableCell HeaderLabelCell1;
        private XRTableCell CounterCell;
        private XRTableCell CounterHeaderCell;
    }
}
