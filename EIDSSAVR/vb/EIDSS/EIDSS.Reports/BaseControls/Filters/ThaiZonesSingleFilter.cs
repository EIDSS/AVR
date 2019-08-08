using bv.common.db.Core;
using System.ComponentModel;
using System.Data;

namespace EIDSS.Reports.BaseControls.Filters
{
	public sealed partial class ThaiZonesSingleFilter : BaseLookupFilter
	{
		private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof(ThaiZonesSingleFilter));

		public ThaiZonesSingleFilter()
		{
			InitializeComponent();
		}

		protected override string LookupCaption
		{
			get { return lblLookupName.Text; }
		}

		protected override string KeyColumnName
		{
			get { return "idfsBaseReference"; }
		}

		protected override string ValueColumnName
		{
			get { return "name"; }
		}

		protected override DataView CreateDataSource()
		{
			DataView view = LookupCache.Get(LookupTables.ThaiZones);
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