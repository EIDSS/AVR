using bv.model.BLToolkit;
using bv.winclient.Core;
using eidss.model.Enums;
using eidss.model.Reports.OperationContext;
using eidss.model.Reports.TH;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using EIDSS.Reports.Parameterized.Human.TH.Reports;
using System.Collections.Generic;
using System.ComponentModel;

namespace EIDSS.Reports.Parameterized.Human.TH.Keepers
{
	public partial class OnePageSituationTHReportKeeper : BaseReportKeeper
	{
		private readonly ComponentResourceManager m_Resources =
			new ComponentResourceManager(typeof(OnePageSituationTHReportKeeper));

		public OnePageSituationTHReportKeeper()
			: base(new Dictionary<string, string>())
		{
			ReportType = typeof(OnePageSituationTHReport);
			InitializeComponent();

			DiagnosesFilter.DiagnosisUsingType = DiagnosisUsingTypeEnum.StandardCase;
			DiagnosesFilter.SetMandatory();

			using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
			{
			}

			m_HasLoad = true;
		}
		protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
		{
			if (WinUtils.IsComponentInDesignMode(this))
			{
				return new BaseReport();
			}
		    var model = new OnePageSituationTHModel(CurrentCulture.ShortName, Diagnosis, DiagnosesFilter.SelectedText, Zone);

			dynamic reportTh = CreateReportObject();
			reportTh.SetParameters(model, manager, archiveManager);
			return reportTh;
		}

		protected internal override void ApplyResources(DbManagerProxy manager)
		{
			try
			{
				IsResourceLoading = true;
				m_HasLoad = false;

				base.ApplyResources(manager);

				m_Resources.ApplyResources(pnlSettings, "pnlSettings");

				DiagnosesFilter.DefineBinding();
				ThaiZoneFilter.DefineBinding();

				if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
				{
				}
			}
			finally
			{
				m_HasLoad = true;
				IsResourceLoading = false;
			}
		}
		[Browsable(false)]
		protected long? Zone
		{
			get
			{
				return ThaiZoneFilter.EditValueId > 0 ? (long?)ThaiZoneFilter.EditValueId : null;
			}
		}
		[Browsable(false)]
		protected long Diagnosis
		{
			get
			{
				return DiagnosesFilter.EditValueId > 0 ? DiagnosesFilter.EditValueId : 0;
			}
		}
	}
}
