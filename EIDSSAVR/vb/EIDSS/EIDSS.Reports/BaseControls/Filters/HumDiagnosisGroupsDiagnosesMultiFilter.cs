using System.ComponentModel;
using System.Data;
using bv.common.db.Core;
using bv.common.Resources;
using eidss.model.Resources;

namespace EIDSS.Reports.BaseControls.Filters
{
    public sealed partial class HumDiagnosisGroupsDiagnosesMultiFilter : GroupsMultiFilter
    {
        private readonly ComponentResourceManager m_Resources = new ComponentResourceManager(typeof (HumDiagnosisGroupsDiagnosesMultiFilter));

        public HumDiagnosisGroupsDiagnosesMultiFilter()
        {
            InitializeComponent();
            FilterType = HumDiagnosisGroupsType.DiagnosesAndGroupsHuman;
            ShowCheckBoxes = true;
        }

        public HumDiagnosisGroupsType FilterType { get; set; }

        protected override string KeyColumnName
        {
            get { return "idfsDiagnosisOrDiagnosisGroup"; }
        }

        protected override string ValueColumnName
        {
            get { return "name"; }
        }

        protected override string ParentColumnName
        {
            get { return "idfsDiagnosisGroup"; }
        }

        protected override string SecondColumnName
        {
            get { return "strIDC10"; }
        }

        protected override string SecondColumnCaption
        {
            get { return EidssMessages.Get("colIDC10"); }
        }

        protected override string CheckedComboBoxName
        {
            get { return m_Resources.GetString("lblcheckedComboBoxName.Text"); }
        }

        public override string GetDisplayText()
        {
            return m_GroupDisplayText;
        }

        protected override DataView CreateDataSource()
        {
            DataView view = new DataView();

            switch (FilterType)
            {
                case HumDiagnosisGroupsType.DiagnosesAndGroupsHuman:
                    view = LookupCache.Get(LookupTables.DiagnosesAndGroupsHuman);
                    break;
                case HumDiagnosisGroupsType.DiagnosesAndGroupsHumanStandard:
                    view = LookupCache.Get(LookupTables.DiagnosesAndGroupsHumanStandard);
                    break;
                case HumDiagnosisGroupsType.DiagnosesAndGroupsHumanGGComparative:
                    view = LookupCache.Get(LookupTables.DiagnosesAndGroupsHumanGGComparative);
                    break;
            }

            if (!view.Table.Rows.Contains(0))
            {
                view.Table.Rows.Add(0, -1, "(" + BvMessages.Get("strSelectAll_Id") + ")", "", "", 2, 0);
            }

            switch (FilterType)
            {
                case HumDiagnosisGroupsType.DiagnosesAndGroupsHuman:
                    view.Sort = "blnGroup Desc, name";
                    view.RowFilter = "intRowStatus <> 1";
                    break;
                case HumDiagnosisGroupsType.DiagnosesAndGroupsHumanStandard:
                    view.Sort = "blnGroup Desc, name";
                    view.RowFilter = "intRowStatus <> 1";
                    break;
                case HumDiagnosisGroupsType.DiagnosesAndGroupsHumanGGComparative:
                    view.Sort = "intOrder, name";
                    view.RowFilter = "intRowStatus <> 1";
                    break;
            }

            return view;
        }
    }
}