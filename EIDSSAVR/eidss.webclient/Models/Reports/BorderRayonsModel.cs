using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Resources;
using eidss.model.Schema;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class BorderRayonsModel : BaseYearModel
    {
        public BorderRayonsModel()
        {
            Address = new AddressModel();
            Year = DateTime.Now.Year;
            FromMonthToMonthModel = new FromMonthToMonthModel();
            FromMonthToMonthModel.StartMonth = FromMonthToMonthModel.EndMonth = DateTime.Now.Month;
            DiagOrGroupLookup = new List<DiagnosesAndGroupsLookup>();
            Counter = new MultipleCounterModel() { IsRequired = true };
        }

        public void LoadDiagnosesList()
        {
            FilterHelper.LoadDiagnosesAndGroupsLookup(DiagOrGroupLookup, HACode.Human, null, (long)BaseReferenceType.rftDiagnosisGroup);
        }


        [LocalizedDisplayName("FromMonth")]
        public int? StartMonth { get; set; }

        [LocalizedDisplayName("ToMonth")]
        public int? EndMonth { get; set; }

        public AddressModel Address { get; set; }

        [LocalizedDisplayName("Counter")]
        public MultipleCounterModel Counter { get; set; }
        public string MultipleCounterFilter_CheckedItems { get; set; }

        //multiple diagnosis tree support properties
        [LocalizedDisplayName("idfsShowDiagnosis")]
        public string SelectedDiagnoses { get; set; }
        public List<DiagnosesAndGroupsLookup> DiagOrGroupLookup { get; set; }

        public static explicit operator BorderRayonsSurrogateModel(BorderRayonsModel model)
        {
            string[] checkedItems = null;
            if (!string.IsNullOrEmpty(model.SelectedDiagnoses))
                checkedItems = model.SelectedDiagnoses.Split(new[] { "," },
                    StringSplitOptions.RemoveEmptyEntries);
            var result = new BorderRayonsSurrogateModel(model.Language,
                model.Year, model.StartMonth, model.EndMonth,
                model.Address.RegionId, model.Address.RayonId,
                model.Address.RegionName(model.Language), model.Address.RayonName(model.Language),
                checkedItems,
                model.Counter.CheckedItems,
                model.OrganizationId, model.ForbiddenGroups, model.UseArchive)
            {
                ExportFormat = model.ExportFormat,
                IsOpenInNewWindow = model.IsOpenInNewWindow
            };

            return result;
        }

        public FromMonthToMonthModel FromMonthToMonthModel { get; set; }

        public List<SelectListItemSurrogate> CounterList
        {
            get { return FilterHelper.GetWebCounterList(1); }
        }

        public long Key
        {
            get { return GetHashCode(); }
        }

    }
}