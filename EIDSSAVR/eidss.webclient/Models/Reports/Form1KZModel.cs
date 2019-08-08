using bv.common.Core;
using eidss.model.Core;
using eidss.model.Reports.Common;
using eidss.model.Reports.KZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eidss.webclient.Models.Reports
{
    [Serializable]
    public class Form1KZModel : BaseYearModel
    {
        public Form1KZModel()
        {
            Address = new AddressModel() { RegionLabelId = " Form1KZRegion" };
            EmployeeId = EidssUserContext.User.EmployeeID != null ? (long)EidssUserContext.User.EmployeeID : 0;
        }

        public Form1KZModel(long? regionId, long? rayonId)
        {
            Address = new AddressModel(regionId, rayonId){ RegionLabelId = " Form1KZRegion" };
            EmployeeId = EidssUserContext.User.EmployeeID != null ? (long)EidssUserContext.User.EmployeeID : 0;
        }

        public Form1KZModel
            (string language, int? formType, int year, int? startMonth, int? endMonth, long? regionId, long? rayonId, bool useArchive)
            : base(language, year, useArchive)
        {
            FormType = formType;
            StartMonth = startMonth;
            EndMonth = endMonth;
            PageSize = FilterHelper.PageSizeA3;
            Address = new AddressModel(regionId, rayonId);
            EmployeeId = EidssUserContext.User.EmployeeID != null ? (long)EidssUserContext.User.EmployeeID : 0;
        }

        public long? EmployeeId { get; set; }

        [LocalizedDisplayName("Form1KZFromMonth")]
        public int? StartMonth { get; set; }

        [LocalizedDisplayName("Form1KZToMonth")]
        public int? EndMonth { get; set; }

        [LocalizedDisplayName("PageSize")]
        public string PageSize { get; set; }

        [LocalizedDisplayName("Form1KZFormType")]
        public int? FormType { get; set; }
 
        public AddressModel Address { get; set; }

        [LocalizedDisplayName("EnteredByOrganization")]

        public List<SelectListItemSurrogate> SelectedJanuaryMonthList
        {
            get { return FilterHelper.GetWebMonthList(1, false); }
        }

        public List<SelectListItemSurrogate> SelectedCurrentMonthList
        {
            get { return FilterHelper.GetWebMonthList(DateTime.Now.Month, false); }
        }

        public List<SelectListItemSurrogate> KZFormTypeList
        {
            get { return FilterHelper.GetWebKZFormTypeList(); }
        }
        public static explicit operator Form1KZSurrogateModel(Form1KZModel model)
        {
            AddressModel address = model.Address ?? new AddressModel();
            var result = new Form1KZSurrogateModel(model.Language, model.FormType, model.Year, model.EmployeeId, model.StartMonth, model.EndMonth,
                address.RegionId, address.RayonId,
                address.RegionName(model.Language), address.RayonName(model.Language),
                model.ForbiddenGroups,
                model.UseArchive)
            {
                ExportFormat = model.ExportFormat,
                IsOpenInNewWindow = model.IsOpenInNewWindow
            };

            return result;
        }
    }
}