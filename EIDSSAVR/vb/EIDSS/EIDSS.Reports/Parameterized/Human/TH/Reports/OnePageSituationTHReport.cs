using System;
using System.Data.SqlClient;
using bv.model.BLToolkit;
using eidss.model.Reports.TH;
using EIDSS.Reports.BaseControls.Report;

namespace EIDSS.Reports.Parameterized.Human.TH.Reports
{
    public sealed partial class OnePageSituationTHReport : BaseReport
    {
        public OnePageSituationTHReport()
        {
            InitializeComponent();
            HideBaseHeader();
        }
        public void SetParameters(OnePageSituationTHModel model, DbManagerProxy manager, DbManagerProxy archiveManager)
        {
            SetLanguage(model, manager);
            Action<SqlConnection, SqlTransaction> action = ((connection, transaction) =>
            {
                m_Adapter.Connection = connection;
                m_Adapter.Transaction = transaction;
                m_Adapter.CommandTimeout = CommandTimeout;
                m_Dataset.EnforceConstraints = false;

                m_Adapter.Fill(m_Dataset.OnePageSituation,
                    model.idfsDiagnosis, model.idfsZone, model.Language);
            });
            FillDataTableWithArchive(action,
                manager, archiveManager,
                m_Dataset.OnePageSituation,
                model.Mode);
        }
    }
}
