using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls;
using EIDSS.Reports.BaseControls.Report;
using eidss.model.Reports.KZ;
using EIDSS.Reports.Parameterized.Human.KZ.DataSet;
using eidss.model.Resources;

namespace EIDSS.Reports.Parameterized.Human.KZ
{
    [NullableAdapters]
    public sealed partial class Form1KZPage1 : XtraReport
    {
        public Form1KZPage1()
        {
            InitializeComponent();
        }

        public void SetParameters(Form1KZSurrogateModel model, string countryName, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            ReportRebinder rebinder = this.GetDateRebinder(model.Language);
            spRepHumForm1KZHeaderTableAdapter.Connection = (SqlConnection) manager.Connection;
            spRepHumForm1KZHeaderTableAdapter.Transaction = (SqlTransaction)manager.Transaction;
            spRepHumForm1KZHeaderTableAdapter.CommandTimeout = BaseReport.CommandTimeout;
            form1KZHeaderDataset1.EnforceConstraints = false;

            bool isWholeYear = model.StartMonth == 1 && model.EndMonth == 12;

            spRepHumForm1KZHeaderTableAdapter.Fill(form1KZHeaderDataset1.spRepHumForm1KZHeader,
                model.Language,
                model.FormType,
                model.Year,
                isWholeYear ? null : FilterHelper.GetMonthName(model.StartMonth),
                isWholeYear ? null : FilterHelper.GetMonthName(model.EndMonth),
                model.RegionId,
                model.RayonId);

            if (form1KZHeaderDataset1.spRepHumForm1KZHeader.Rows.Count > 0)
            {
                var row = (Form1KZHeaderDataset.spRepHumForm1KZHeaderRow)form1KZHeaderDataset1.spRepHumForm1KZHeader.Rows[0];

                row.FormType = model.FormType.Value;
                row.PeriodicityType = model.FormType.Value == 1
                    ? EidssMessages.Instance.GetString("kzForm1ReportType")
                    : EidssMessages.Instance.GetString("kzForm2ReportType");

                xrLabelPeriod.Text = model.FormType.Value == 1
                    ? FilterHelper.GetMonthName(model.StartMonth)
                    : (!model.StartMonth.HasValue && !model.EndMonth.HasValue) 
                        ? "" 
                        : model.StartMonth == model.EndMonth 
                            ? FilterHelper.GetMonthName(model.StartMonth) 
                            : FilterHelper.GetMonthName(model.StartMonth) + " - " + FilterHelper.GetMonthName(model.EndMonth);
                xrLabelYear.Text = model.Year.ToString();

                xrLabelFor.Text = !model.RegionId.HasValue && !model.RayonId.HasValue
                    ? EidssMessages.Instance.GetString("kzFormCountry")
                    : (model.RayonId.HasValue
                        ? /*EidssMessages.Instance.GetString("kzFormRayon")*/ model.RegionName + ", " + model.RayonName
                        : /*EidssMessages.Instance.GetString("kzFormRegion")*/ model.RegionName);
            }

        }
    }
}