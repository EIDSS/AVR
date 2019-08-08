using bv.common.db.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidss.model.Helpers
{
    class ThaiDistrictHelper
    {
        public static string FilterThaiDistricts(DbManagerProxy manager, Int64 regionID, Int64 rayonID)
        {
            manager.SetSpCommand("spRayon_SelectLookup"
                            , manager.Parameter("@RegionID", regionID)
                            , manager.Parameter("@ID", null)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage));

            List<RayonLookup> list = new List<RayonLookup>();

            List<RayonLookup> filterList = manager.ExecuteList<RayonLookup>();

            RayonLookup district = filterList.FirstOrDefault(c => c.idfsRayon == rayonID);

            List<string> districtID = new List<string>();


            list.AddRange(filterList.Where(c => (c.intRowStatus == 0 && c.idfsParent == rayonID) || (c.idfsRayon == district.idfsRayon) || (c.idfsRayon == LookupCache.EmptyLineKey)).ToList());
            list.ForEach(c => { districtID.Add(c.idfsRayon.ToString()); });            

            string results = string.Join(",", districtID);

            return results;
        }
    }
}
