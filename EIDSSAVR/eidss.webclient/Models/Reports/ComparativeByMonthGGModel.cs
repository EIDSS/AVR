using System;
using System.Collections.Generic;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Reports.GG;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class ComparativeByMonthGGModel: BaseModel
    {
        public ComparativeByMonthGGModel()
        {
            StartMonth = 1;
            EndMonth = DateTime.Now.Month;
            Address = new AddressModel(FilterHelper.GetDefaultRegion(), FilterHelper.GetDefaultRayon());
            YearModel = new FromYearToYearModel()
            {
                ValidationMessage = "msgComparativeReportGGCorrectYear",
                Year1Caption = "strFirstYear",
                Year2Caption = "strSecondYear",

            };
            YearModel.SetYearsIntervalFrom(2012, DateTime.Today.Year - 1);
            YearModel.SetYearsIntervalTo(2013, DateTime.Today.Year);
        }

        public ComparativeByMonthGGModel(AddressModel address)
            : this()
        {
            Address = address;
        }

        public AddressModel Address { get; set; }

        public FromYearToYearModel YearModel { get; set; }

        [LocalizedDisplayName("FromMonthGG")]
        public int? StartMonth { get; set; }

        [LocalizedDisplayName("ToMonthGG")]
        public int? EndMonth { get; set; }

        public List<SelectListItemSurrogate> SelectedCurrentMonthList
        {
            get { return FilterHelper.GetWebMonthList(DateTime.Now.Month, false); }
        }

        public List<SelectListItemSurrogate> SelectedJanuaryMonthList
        {
            get { return FilterHelper.GetWebMonthList(1, false); }
        }

        public static explicit operator ComparativeGGSurrogateModel(ComparativeByMonthGGModel model)
        {
            var result = new ComparativeGGSurrogateModel(model.Language,
                model.Address.RegionId, model.Address.RegionId.HasValue ? model.Address.RayonId : null,
                model.Address.RegionName(model.Language), model.Address.RegionId.HasValue ? model.Address.RayonName(model.Language) : null,
                model.YearModel.Year1, model.YearModel.Year2,
                model.StartMonth, model.EndMonth,
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