using bv.common.db.Core;
using bv.winclient.Core;
using eidss.model.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace EIDSS.Reports.BaseControls.Filters
{
	public partial class HumSingleDiagnosisFilter : BaseLookupFilter
	{
		private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof(HumSingleDiagnosisFilter));

		public HumSingleDiagnosisFilter()
		{
			InitializeComponent();
		}

		public string AdditionalFilter { get; set; }

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DiagnosisUsingTypeEnum? DiagnosisUsingType { get; set; }

		protected override string KeyColumnName
		{
			get { return "idfsDiagnosis"; }
		}

		protected override string ValueColumnName
		{
			get { return "name"; }
		}

		protected override string LookupCaption
		{
			get { return lblLookupName.Text; }
		}

		protected override DataView CreateDataSource()
		{
			if (WinUtils.IsComponentInDesignMode(this))
			{
				return new DataView();
			}

			DataView view;

			if (DiagnosisUsingType.HasValue)
			{
				var prm = new Dictionary<string, object> { { "@DiagnosisUsingType", (long)DiagnosisUsingType.Value } };
				view = LookupCache.Get(LookupTables.HumanDiagnoses, 0, prm);
			}
			else
				view = LookupCache.Get(LookupTables.HumanDiagnoses);


			view.RowFilter = string.IsNullOrEmpty(AdditionalFilter)
				? "intRowStatus <> 1"
				: string.Format("(intRowStatus <> 1) AND({0})", AdditionalFilter);
			view.Sort = "name";

			return view;
		}

		protected override void ApplyResources()
		{
			base.ApplyResources();

			lblLookupName.Text = m_Resources.GetString("lblLookupName.Text");
		}
	}
}