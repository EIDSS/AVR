using System;
using System.Collections.Generic;
using bv.common.Core;
using eidss.model.Core;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class FormNo1Model : BaseYearModel
    {
        public FormNo1Model()
        {
            Address = new AddressModel();
        }

        public FormNo1Model(long? regionId, long? rayonId)
        {
            Address = new AddressModel(regionId, rayonId);
        }

        public FormNo1Model
            (string language, int year, int? startMonth, int? endMonth, bool isA3Format, long? regionId, long? rayonId, bool useArchive)
            : base(language, year, useArchive)
        {
            StartMonth = startMonth;
            EndMonth = endMonth;
            PageSize = isA3Format
                ? FilterHelper.PageSizeA3
                : FilterHelper.PageSizeA4;
            Address = new AddressModel(regionId, rayonId);
        }

        [LocalizedDisplayName("FromMonth")]
        public int? StartMonth { get; set; }

        [LocalizedDisplayName("ToMonth")]
        public int? EndMonth { get; set; }

        [LocalizedDisplayName("PageSize")]
        public string PageSize { get; set; }

        public bool IsA3Format
        {
            get { return PageSize == FilterHelper.PageSizeA3; }
        }

        public AddressModel Address { get; set; }

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

        public List<SelectListItemSurrogate> PageSizeList
        {
            get { return FilterHelper.GetPageSizeList(); }
        }

        public List<SelectListItemSurrogate> SelectedJanuaryMonthList
        {
            get { return FilterHelper.GetWebMonthList(1, false); }
        }

        public List<SelectListItemSurrogate> SelectedCurrentMonthList
        {
            get { return FilterHelper.GetWebMonthList(DateTime.Now.Month, false); }
        }

        public List<SelectListItemSurrogate> OrganizationList
        {
            get { return FilterHelper.GetHumOrganizationList(Localizer.CurrentCultureLanguageID); }
        }

        public static explicit operator FormNo1SurrogateModel(FormNo1Model model)
        {
            AddressModel address = model.Address ?? new AddressModel();
            var result = new FormNo1SurrogateModel(model.Language, model.Year, model.StartMonth, model.EndMonth, model.IsA3Format,
                address.RegionId, address.RayonId,
                address.RegionName(model.Language), address.RayonName(model.Language),
                model.OrganizationCHE, model.OrganizationCHEName,
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