using System;
using System.Collections.Generic;
using bv.common.Core;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Schema;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class DataQualityIndicatorsModel : BaseYearModel
    {
        public DataQualityIndicatorsModel()
        {
            Address = new TransportCHEModel(true);
            DiagOrGroupLookup = new List<DiagnosesAndGroupsLookup>();
            LoadDiagnosesList();

        }

        [LocalizedDisplayName("FromMonth")]
        public int? StartMonth { get; set; }

        [LocalizedDisplayName("ToMonth")]
        public int? EndMonth { get; set; }

        [LocalizedDisplayName("EnteredByOrganization")]
        public long? OrganizationCHE { get; set; }

        public string OrganizationCHEName
        {
            get
            {
                return !OrganizationCHE.HasValue
                    ? string.Empty
                    : FilterHelper.GetHumOrganizationName(OrganizationCHE.Value,
                        Localizer.CurrentCultureLanguageID);
            }
        }

        public TransportCHEModel Address { get; set; }
        //multiple diagnosis tree support properties
        [LocalizedDisplayName("idfsShowDiagnosis")]
        public string SelectedDiagnoses { get; set; }
        public List<DiagnosesAndGroupsLookup> DiagOrGroupLookup { get; set; }
        public long Key
        {
            get { return GetHashCode(); }
        }

        public void LoadDiagnosesList()
        {
            FilterHelper.LoadDiagnosesAndGroupsLookup(DiagOrGroupLookup, HACode.Human, (long)DiagnosisUsingTypeEnum.StandardCase,
                (long)BaseReferenceType.rftDiagnosisGroup);
        }

        public bool ArrangeRayonsAlphabetically { get; set; }
        public bool ShowRayonFilter { get; set; }

        public List<SelectListItemSurrogate> UnselectedMonthList
        {
            get { return FilterHelper.GetWebMonthList(-1, false); }
        }

        public List<SelectListItemSurrogate> SelectedMonthList
        {
            get { return FilterHelper.GetWebMonthList(DateTime.Now.Month, false); }
        }

        public List<SelectListItemSurrogate> OrganizationList
        {
            get { return FilterHelper.GetHumOrganizationList(Localizer.CurrentCultureLanguageID); }
        }

        public static explicit operator DataQualityIndicatorsSurrogateModel(DataQualityIndicatorsModel model)
        {
            string[] checkedItems = null;
            if (!string.IsNullOrEmpty(model.SelectedDiagnoses))
                checkedItems = model.SelectedDiagnoses.Split(new[] { "," },
                    StringSplitOptions.RemoveEmptyEntries);
            var selectedDiagnosesNames = FilterHelper.SelectedDiagnoses2Names(checkedItems, model.DiagOrGroupLookup);
            TransportCHEModel transportChe = model.Address ?? new TransportCHEModel();
            var result = new DataQualityIndicatorsSurrogateModel(model.Language,
                checkedItems, selectedDiagnosesNames,
                model.Year, model.StartMonth, model.EndMonth,
                transportChe.RegionId, transportChe.RayonId,
                transportChe.RegionName, transportChe.RayonName,
                model.ArrangeRayonsAlphabetically,
                model.OrganizationId,
                model.ForbiddenGroups, model.UseArchive)
            {
                ExportFormat = model.ExportFormat,
                IsOpenInNewWindow = model.IsOpenInNewWindow
            };

            return result;
        }
    }
}