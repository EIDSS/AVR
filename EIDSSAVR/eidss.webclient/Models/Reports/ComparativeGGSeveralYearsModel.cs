using System;
using System.Collections.Generic;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;
using eidss.model.Schema;

namespace eidss.webclient.Models.Reports
{
    public class ComparativeGGSeveralYearsModel : BaseModel
    {
        public ComparativeGGSeveralYearsModel()
        {
            Address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            YearModel = new FromYearToYearModel();
            YearModel.SetYearsIntervalFrom(2012, DateTime.Today.Year - 1, DateTime.Today.Year - 1);
            YearModel.SetYearsIntervalTo(2013, DateTime.Today.Year, DateTime.Today.Year);
            YearModel.YearsCaptionsSpecial = true;
            Counter = new MultipleGGCounterModel() { IsRequired = true };
            DiagOrGroupLookup = new List<DiagnosesAndGroupsLookup>();
            LoadDiagnosesList();
        }

        public ComparativeGGSeveralYearsModel(AddressModel address)
            : this()
        {
            Address = address;
            YearModel = new FromYearToYearModel();
            YearModel.SetYearsIntervalFrom(2012, DateTime.Today.Year - 1, DateTime.Today.Year - 1);
            YearModel.SetYearsIntervalTo(2013, DateTime.Today.Year, DateTime.Today.Year);
            Counter = new MultipleGGCounterModel() { IsRequired = true };
            DiagOrGroupLookup = new List<DiagnosesAndGroupsLookup>();
            LoadDiagnosesList();
        }

        public AddressModel Address { get; set; }
        public FromYearToYearModel YearModel { get; set; }
        [LocalizedDisplayName("FunctionName")]
        public MultipleGGCounterModel Counter { get; set; }

        public string MultipleCounterFilter_CheckedItems { get; set; }
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
            FilterHelper.LoadDiagnosesAndGroupsGGLookup(DiagOrGroupLookup);
        }

        public static explicit operator ComparativeGGSeveralYearsSurrogateModel(ComparativeGGSeveralYearsModel model)
        {
            string[] checkedDiagnoses = null;
            if (!string.IsNullOrEmpty(model.SelectedDiagnoses))
                checkedDiagnoses = model.SelectedDiagnoses.Split(new[] { "," },
                    StringSplitOptions.RemoveEmptyEntries);
            var selectedDiagnosesNames = FilterHelper.SelectedDiagnoses2Names(checkedDiagnoses, model.DiagOrGroupLookup);
            string[] checkedCounters = null;
            if (!string.IsNullOrEmpty(model.MultipleCounterFilter_CheckedItems))
                checkedCounters = model.MultipleCounterFilter_CheckedItems.Split(new[] { "," },
                    StringSplitOptions.RemoveEmptyEntries);

            var address = model.Address ?? new AddressModel();
            var result = new ComparativeGGSeveralYearsSurrogateModel(model.Language,
                model.YearModel.Year1, model.YearModel.Year2,
                checkedCounters,
                checkedDiagnoses, selectedDiagnosesNames,
                address.RegionId,
                address.RegionId.HasValue ? address.RayonId : null,
                address.RegionName(model.Language),
                address.RegionId.HasValue ? address.RayonName(model.Language) : null,
                model.OrganizationId, model.ForbiddenGroups,
                model.UseArchive)
            {
                ExportFormat = model.ExportFormat,
                IsOpenInNewWindow = model.IsOpenInNewWindow
            };

            return result;
        }
    }
}