using bv.model.BLToolkit;
using bv.winclient.Core;
using bv.winclient.Layout;
using eidss.model.Core;
using eidss.model.Reports.Common;
using eidss.model.Reports.KZ;
using eidss.model.Reports.OperationContext;
using eidss.model.Resources;
using EIDSS.Reports.BaseControls.Filters;
using EIDSS.Reports.BaseControls.Keeper;
using EIDSS.Reports.BaseControls.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EIDSS.Reports.Parameterized.Human.KZ
{
	public partial class Form1KZKeeper : BaseDateKeeper
	{
		private List<ItemWrapper> m_ReportFormCollection;

		public Form1KZKeeper()
		{
			ReportType = typeof(Form1KZReport);
			InitializeComponent();

			MinYear = 2001;
			MaxYear = DateTime.Now.Year;

			LayoutCorrector.SetStyleController(ReportFormLookUp, LayoutCorrector.MandatoryStyleController);
		}

		#region Properties

		[Browsable(false)]
		private int? ReportFormParam
		{
			get
			{
				return (ReportFormLookUp.EditValue == null)
					? (int?)null
					: ((ItemWrapper)ReportFormLookUp.EditValue).Number;
			}
		}

		[Browsable(false)]
		private long? RegionIdParam
		{
			get { return regionFilter.RegionId > 0 ? (long?)regionFilter.RegionId : null; }
		}

		[Browsable(false)]
		private long? RayonIdParam
		{
			get { return rayonFilter.RayonId > 0 ? (long?)rayonFilter.RayonId : null; }
		}

		private List<ItemWrapper> ReportFormCollection
		{
			get { return m_ReportFormCollection ?? (m_ReportFormCollection = FilterHelper.GetWinKZFormTypeList()); }
		}

		#endregion

		protected override BaseReport GenerateReport(DbManagerProxy manager, DbManagerProxy archiveManager)
		{
			if (WinUtils.IsComponentInDesignMode(this))
			{
				return new BaseReport();
			}

			long? employeeId = null;

			if (EidssUserContext.User.EmployeeID != null)
			{
				long tempId;
				if (long.TryParse(EidssUserContext.User.EmployeeID.ToString(), out tempId))
					employeeId = tempId;
			}

			var model = new Form1KZSurrogateModel(CurrentCulture.ShortName, ReportFormParam, YearParam, employeeId,
				StartMonthParam, EndMonthParam, RegionIdParam, RayonIdParam, regionFilter.SelectedText,
				rayonFilter.SelectedText, EidssUserContext.User.ForbiddenPersonalDataGroups,
				UseArchive);

			dynamic reportKz = CreateReportObject();
			reportKz.SetParameters(model, manager, archiveManager);
			return reportKz;
		}

		protected internal override void ApplyResources(DbManagerProxy manager)
		{
			try
			{
				IsResourceLoading = true;
				m_HasLoad = false;

				base.ApplyResources(manager);

				regionFilter.DefineBinding();
				rayonFilter.DefineBinding();

				ApplyLookupResources(ReportFormLookUp, ReportFormCollection, ReportFormParam, ReportFormLabel.Text);

				if (ContextKeeper.ContainsContext(ContextValue.ReportKeeperFirstLoading))
				{
					LocationHelper.SetDefaultFilters(manager, ContextKeeper, regionFilter, rayonFilter);
				}

				SetControlsVisibility();

				ReportFormLabel.Text = EidssFields.Get("Form1KZFormType");
				label1.Text = EidssFields.Get("YearForAggr");
				regionFilter.Caption = EidssFields.Get("Form1KZRegion");
				rayonFilter.Caption = EidssFields.Get("idfsRayon");
				MonthLabel.Text = EidssFields.Get("MonthForAggr");
				label2.Text = EidssFields.Get("MonthForAggr");
				StartMonthLabel.Text = EidssFields.Get("Form1KZFromMonth");
				EndMonthLabel.Text = EidssFields.Get("Form1KZToMonth");
			}
			finally
			{
				m_HasLoad = true;
				IsResourceLoading = false;
			}
		}

		private void SetControlsVisibility()
		{
			var visibility = ReportFormParam.HasValue;
			spinEdit.Visible = visibility;
			label1.Visible = visibility;
			regionFilter.Visible = visibility;
			rayonFilter.Visible = visibility;
			label2.Visible = visibility;
			cbMonth.Visible = visibility;
			GenerateReportButton.Visible = visibility;

			if (!visibility)
				return;

			if (ReportFormParam.Value == 1)
			{
				SetCurrentStartMonth();
				IsMonthRange = false;
			}
			else
			{
				IsMonthRange = true;
				SetMonth(cbMonth, 1);
				SetCurrentMonth(cbMonthEnd);
			}
		}

		private void regionFilter_ValueChanged(object sender, SingleFilterEventArgs e)
		{
			using (ContextKeeper.CreateNewContext(ContextValue.ReportFilterResetting))
			{
				LocationHelper.RegionFilterValueChanged(regionFilter, rayonFilter, e);
			}

			rayonFilter.Enabled = RegionIdParam.HasValue;
		}

		private void ReportFormLookUp_EditValueChanged(object sender, System.EventArgs e)
		{
			SetControlsVisibility();
		}
	}
}
