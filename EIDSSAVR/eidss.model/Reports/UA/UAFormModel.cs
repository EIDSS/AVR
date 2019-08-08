using eidss.model.Reports.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidss.model.Reports.UA
{
    [Serializable]
    public class UAFormModel : BaseYearModel
    {
        public int? Month { get; set; }
        public long? RegionId { get; set; }
        public AddressModel Address {get; set;}

        public UAFormModel()
        {
            Address = new AddressModel();
        }

        public UAFormModel(long? regionId)
        {
            Address = new AddressModel(regionId, null);
        }

        public UAFormModel(string language, int year, int? month, long? regionId, bool useArchive)
            : base(language, year, useArchive)
        {
            Month = month;
            RegionId = regionId;
        }

        public List<SelectListItemSurrogate> SelectedCurrentMonthList
        {
            get { return FilterHelper.GetWebMonthList(DateTime.Now.Month, false); }
        }
    }
}
