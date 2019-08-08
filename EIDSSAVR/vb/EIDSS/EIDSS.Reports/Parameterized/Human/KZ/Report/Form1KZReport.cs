using System.Collections.Generic;
using System.Drawing.Printing;
using bv.model.BLToolkit;
using DevExpress.XtraReports.UI;
using eidss.model.Reports;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using EIDSS.Reports.BaseControls.Report;
using eidss.model.Reports.KZ;

namespace EIDSS.Reports.Parameterized.Human.KZ
{
    [CanWorkWithArchive]
    [NullableAdapters]
    public sealed partial class Form1KZReport : BaseDateReport
    {
        private const int DeltaPageWidth = 820;

        private readonly Form1KZPage1 formN1Header1;
        private readonly Form1KZPage2 formN1InfectiousDiseases1;

        public Form1KZReport()
        {
            InitializeComponent();
            formN1Header1 = (Form1KZPage1)subreportHeader.ReportSource;
            formN1InfectiousDiseases1 = (Form1KZPage2)subreportPage2InfectiousDiseases.ReportSource;
        }

        public void SetParameters(Form1KZSurrogateModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            SetParameters((BaseDateModel) model, manager, archiveManager);

            formN1Header1.SetParameters(model, m_BaseDataSet.sprepGetBaseParameters[0].CountryName, manager, archiveManager);
            formN1InfectiousDiseases1.SetParameters(model, manager, archiveManager);
        }

        //private static void MovePage(DetailBand firstPage, DetailBand secondPage, bool shiftFirstPage)
        //{
        //    DetailBand pageToShift = (shiftFirstPage) ? firstPage : secondPage;
        //    foreach (XRControl control in pageToShift.Controls)
        //    {
        //        control.Left += DeltaPageWidth;
        //    }

        //    var page4Controls = new List<XRControl>();
        //    foreach (XRControl control in secondPage.Controls)
        //    {
        //        page4Controls.Add(control);
        //    }
        //    foreach (XRControl control in page4Controls)
        //    {
        //        secondPage.Controls.Remove(control);
        //        firstPage.Controls.Add(control);
        //    }
        //}
    }
}