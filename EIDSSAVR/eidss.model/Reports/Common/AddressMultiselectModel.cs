using System;
using System.Collections.Generic;
using System.Linq;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class AddressMultiselectModel : AddressModel
    {
        public string RegionsSelected { get; set; }

        //TODO нужны ли эти методы или можно без них обойтись?
        public string[] Regions { get; set; }

        public string[] Rayons { get; set; }

        public List<SelectListItemSurrogate> GetRayons(string lang, string regionsList)
        {
            var list = new List<SelectListItemSurrogate>();
            var regions = regionsList.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var region in regions)
            {
                InternalAddress(lang).Region =
                    InternalAddress(lang).RegionLookup.SingleOrDefault(c => c.idfsRegion == Convert.ToInt64(region));
                var defaultRayonId = FilterHelper.GetDefaultRayon();
                list.AddRange(InternalAddress(lang).RayonLookup.Select(rayon => new SelectListItemSurrogate
                    {
                        Text = rayon.strRayonName,
                        Value = (rayon.idfsRayon > 0)
                                    ? rayon.idfsRayon.ToString()
                                    : null,
                        Selected = (rayon.idfsRayon == defaultRayonId)
                    }));
            }
            for (var i = list.Count - 1; i >= 0; i--)
            {
                if (list[i].Text.Length == 0) list.RemoveAt(i);
            }
            return list;
        }
    }
}