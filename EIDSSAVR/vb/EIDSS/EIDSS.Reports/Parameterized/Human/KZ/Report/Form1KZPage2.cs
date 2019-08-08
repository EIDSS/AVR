using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.KZ;
using eidss.model.Reports.KZ;
using EIDSS.Reports.Parameterized.Human.KZ.DataSet;
using eidss.model.Reports.Common;
using eidss.model.Core;
using eidss.model.Schema;

namespace EIDSS.Reports.Parameterized.Human.KZ
{
    [NullableAdapters]
    public partial class Form1KZPage2 : XtraReport
    {
        public Form1KZPage2()
        {
            InitializeComponent();
        }

        public void SetParameters(Form1KZSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {

            form1KZDataDataset1.EnforceConstraints = false;

            Form1KZDataDataset.spRepHumForm1KZDataDataTable dataTable =
                form1KZDataDataset1.spRepHumForm1KZData;

            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                spRepHumForm1KZDataTableAdapter.Connection = connection;
                spRepHumForm1KZDataTableAdapter.Transaction = transaction;
                spRepHumForm1KZDataTableAdapter.CommandTimeout = BaseReport.CommandTimeout;

                spRepHumForm1KZDataTableAdapter.Fill(
                    dataTable,
                    model.Language,
                    model.FormType,
                    model.Year,
                    model.StartMonth,
                    model.EndMonth,
                    model.RegionId,
                    model.RayonId
                    );
            });

            BaseReport.FillDataTableWithArchive(action,
                manager, archiveManager,
                dataTable,
                model.Mode,
                new[] { "intRowNum", "strDiagnosis", "strICD" });


            xrLabelDay.Text = DateTime.Today.Day.ToString();
            xrLabelMonth.Text = FilterHelper.GetMonthName(DateTime.Today.Month);
            xrLabelYear.Text = DateTime.Today.Year.ToString();

            Personnel p = Personnel.Accessor.Instance(null).SelectByKey(manager, model.EmployeeId);
            if (p != null) 
            {
                xrLabelName.Text = p.strFullName + " " + p.strContactPhone;
            }
        }
    }
}