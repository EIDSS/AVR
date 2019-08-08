using bv.common.db.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using EIDSS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

namespace eidss.model.Reports.TH
{
    public class MultipleDistrictTHModel : BaseMultipleModel
    {
        public MultipleDistrictTHModel()
        {
            CheckedItems = new string[0];
        }

        public MultipleDistrictTHModel(string[] checkedItems)
        {
            CheckedItems = checkedItems ?? new string[0];
        }

        public static List<RayonLookup> GetDataSource()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return RayonLookup.Accessor.Instance(null).SelectList(manager, null, null);
            }
        }

        public override List<SelectListItemSurrogate> LoadItemList()
        {
            //Currently this method is used in web only
            //If it will be used in desktop too, it will be needed to make Select All item adding optional
            var result = new List<SelectListItemSurrogate>
            {
                FilterHelper.SelectAllItem
            };
            result.AddRange(
                GetDataSource().Select(rayon => new SelectListItemSurrogate
                {
                    Value = rayon.idfsRayon.ToString(CultureInfo.InvariantCulture),
                    Text = rayon.strRayonName,
                    Selected = false
                })
                );
            return result;
        }

        public List<SelectListItemSurrogate> DistrictList(string[] regions)
        {
            DataView rayons = LookupCache.Get(LookupTables.Rayon);
            if (regions == null || regions.Length == 0)
            {
                //DataSource.RowFilter = "0=1";
                throw new NotImplementedException();
            }
            else
            {
                var sbFilter = new StringBuilder(string.Format("(idfsCountry = {0} OR idfsCountry = {1})", EidssSiteContext.Instance.CountryID, -101));
                sbFilter.Append(" AND (");
                bool firstRegion = true;
                foreach (string region in regions)
                {
                    if (!firstRegion)
                    {
                        sbFilter.Append(" OR ");
                    }
                    sbFilter.AppendFormat("idfsRegion = {0}", region);
                    firstRegion = false;
                }
                sbFilter.Append(") AND (idfsRayon = idfsParent)");
                rayons.RowFilter = sbFilter.ToString();
            }

            DataTable ray = rayons.ToTable();

            var result = new List<SelectListItemSurrogate>
            {
                FilterHelper.SelectAllItem
            };

            foreach (DataRow row in ray.Rows)
            {
                result.Add(new SelectListItemSurrogate
                {
                    Value = row["idfsRayon"].ToString(),
                    Text = row["strRayonName"].ToString(),
                    Selected = false
                });
            }

            return result;
        }
    }
}
