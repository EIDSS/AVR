using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.model.Core;
using eidss.model.Resources;
using eidss.model.Schema;
using eidss.model.Core.CultureInfo;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class AddressModel
    {
        public const long OtherRayonsId = 1344340000000;
        public const long TransportCheId = 10300053;
        public const long BakuId = 1344330000000;

        public bool IsRequired { get; set; }

        private static readonly long[] m_CityList =
        {
            1344470000000,
            1344650000000,
            1344830000000,
            1344890000000,
            1344920000000
        };

        private Dictionary<string, Address> m_InternalAddresses = new Dictionary<string,Address>();

        public AddressModel()
        {
            RegionLabelId = "idfsRegion";
        }

        public AddressModel(long? regionId, long? rayonId, long? settlementId = null)
            : this()
        {
            RegionLabelId = "idfsRegion";
            RegionId = regionId;
            RayonId = rayonId;
            SettlementId = settlementId;
            IsSettlementVisible = false;
        }

        public bool IsSettlementVisible { get; set; }
        public string RegionLabelId { get; set; }
        public string RegionLabel
        {
            get
            {
                return EidssFields.Get(RegionLabelId);
            }
        }
        [LocalizedDisplayName("idfsRegion")]
        public long? RegionId { get; set; }

        [LocalizedDisplayName("idfsRayon")]
        public long? RayonId { get; set; }

        [LocalizedDisplayName("idfsSettlement")]
        public long? SettlementId { get; set; }

        internal Address InternalAddress(string lang)
        {
            lock (m_InternalAddresses)
            {
                if (!m_InternalAddresses.ContainsKey(lang ?? ""))
                {
                    if (lang == null)
                    {
                        using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                        {
                            m_InternalAddresses.Add("", Address.Accessor.Instance(null).CreateNewT(manager, null));
                        }
                    }
                    else
                    {
                        using (new CultureInfoTransaction(new CultureInfo(CustomCultureHelper.SupportedLanguages[lang])))
                        {
                            using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                            {
                                m_InternalAddresses.Add(lang, Address.Accessor.Instance(null).CreateNewT(manager, null));
                            }
                        }
                    }
                }
            }
            return m_InternalAddresses[lang ?? ""];
        }

        private string RegionNameInternal(string lang)
        {
            var selectedRegon = InternalAddress(lang).RegionLookup.FirstOrDefault(r => r.idfsRegion == RegionId);
            return (selectedRegon == null)
                        ? string.Empty
                        : selectedRegon.strRegionName;
        }

        public string RegionName(string lang)
        {
            if (lang == null)
            {
                return RegionNameInternal(lang);
            }
            else
            {
                using (new CultureInfoTransaction(new CultureInfo(CustomCultureHelper.SupportedLanguages[lang])))
                {
                    return RegionNameInternal(lang);
                }
            }
        }

        private string RayonNameInternal(string lang)
        {
            InternalAddress(lang).Region = InternalAddress(lang).RegionLookup.SingleOrDefault(c => c.idfsRegion == RegionId);
            var selectedRayon = InternalAddress(lang).RayonLookup.SingleOrDefault(r => r.idfsRayon == RayonId);
            return (selectedRayon == null)
                        ? string.Empty
                        : selectedRayon.strRayonName;
        }

        public string RayonName(string lang)
        {
            if (lang == null)
            {
                return RayonNameInternal(lang);
            }
            else
            {
                using (new CultureInfoTransaction(new CultureInfo(CustomCultureHelper.SupportedLanguages[lang])))
                {
                    return RayonNameInternal(lang);
                }
            }
        }

        private string SettlementNameInternal(string lang)
        {
            InternalAddress(lang).Rayon = InternalAddress(lang).RayonLookup.SingleOrDefault(c => c.idfsRayon == RayonId);
            InternalAddress(lang).Settlement = InternalAddress(lang).SettlementLookup.SingleOrDefault(c => c.idfsSettlement == SettlementId);
            var selectedSettlement = InternalAddress(lang).SettlementLookup.SingleOrDefault(r => r.idfsSettlement == SettlementId);
            return (selectedSettlement == null)
                        ? String.Empty
                        : selectedSettlement.strSettlementName;
        }

        public string SettlementName(string lang)
        {
            if (lang == null)
            {
                return SettlementNameInternal(lang);
            }
            else
            {
                using (new CultureInfoTransaction(new CultureInfo(CustomCultureHelper.SupportedLanguages[lang])))
                {
                    return SettlementNameInternal(lang);
                }
            }

        }

        #region Helper Methods

        public void ResetAddressLookup()
        {
            lock (m_InternalAddresses)
            {
                m_InternalAddresses.Clear();
            }
        }

        public List<SelectListItemSurrogate> GetSelectedRegions(string lang)
        {
            return GetInternalRegions(lang, true);
        }

        public List<SelectListItemSurrogate> GetUnselectedRegions(string lang)
        {
            return GetInternalRegions(lang, false);
        }

        private List<SelectListItemSurrogate> GetInternalRegions(string lang, bool isSelected)
        {
            var defaultRegionId = FilterHelper.GetDefaultRegion();
            return InternalAddress(lang).RegionLookup.Select(region => new SelectListItemSurrogate
                {
                    Text = region.strRegionName,
                    Value = (region.idfsRegion > 0)
                                ? region.idfsRegion.ToString()
                                : null,
                    Selected = isSelected && (region.idfsRegion == defaultRegionId)
                }).ToList();
        }

        public List<SelectListItemSurrogate> GetRayons(string lang)
        {
            InternalAddress(lang).Region = InternalAddress(lang).RegionLookup.SingleOrDefault(c => c.idfsRegion == RegionId);
            var defaultRayonId = FilterHelper.GetDefaultRayon();
            return InternalAddress(lang).RayonLookup.Select(rayon => new SelectListItemSurrogate
                {
                    Text = rayon.strRayonName,
                    Value = (rayon.idfsRayon > 0)
                                ? rayon.idfsRayon.ToString()
                                : null,
                    Selected = (rayon.idfsRayon == defaultRayonId)
                }).ToList();
        }

        public List<SelectListItemSurrogate> GetSettlements(string lang)
        {
            InternalAddress(lang).Region = InternalAddress(lang).RegionLookup.SingleOrDefault(c => c.idfsRegion == RegionId);
            InternalAddress(lang).Rayon = InternalAddress(lang).RayonLookup.SingleOrDefault(c => c.idfsRayon == RayonId);
            return InternalAddress(lang).SettlementLookup.Select(s => new SelectListItemSurrogate
            {
                Text = s.strSettlementName,
                Value = (s.idfsSettlement > 0)
                            ? s.idfsSettlement.ToString()
                            : null
                //,Selected = (s.idfsRayon == RayonId)
            }).ToList();
        }

        public static string GetLocation
           (string language, string countryName, long? regionId, string regionName, long? rayonId, string rayonName, bool swapRegionRayon = false, bool useRayonSuffix = true)
        {
            string location;
            if (regionId.HasValue)
            {
                if (rayonId.HasValue)
                {
                    if (useRayonSuffix && language == Localizer.lngRu && !m_CityList.Contains(rayonId.Value))
                    {
                        rayonName += (" " + EidssMessages.Get("report_rayon_suffix").Trim());
                    }
                    string regionRayonFormat = (swapRegionRayon && regionId.Value != BakuId) ? "{1}, {0}" : "{0}, {1}";
                    location = regionId.Value == OtherRayonsId || regionId.Value == TransportCheId
                        ? rayonName
                        : string.Format(regionRayonFormat, regionName, rayonName);
                }
                else
                {
                    location = regionName;
                }
            }
            else
            {
                location = countryName;
            }
            return location;
        }

        public static string GetLocation
            (string language, long? regionId, string regionName, long? rayonId, string rayonName, string settlementName)
        {
            var location = GetLocation(language, string.Empty, regionId, regionName, rayonId, rayonName);
            if (string.IsNullOrEmpty(location))
            {
                return settlementName;
            }
            if (string.IsNullOrEmpty(settlementName))
            {
                return location;
            }
            return string.Format("{0}, {1}", location, settlementName);
        }



        #endregion

        public override string ToString()
        {
            return string.Format("Region={0}, Rayon={1}, Settlement={2}", RegionName("en"), RayonName("en"), SettlementName("en"));
        }
    }
}