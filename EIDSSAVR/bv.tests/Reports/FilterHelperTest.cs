using System;
using System.Collections.Generic;
using System.Globalization;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.tests.common;
using eidss.model.Core.CultureInfo;
using eidss.model.Enums;
using eidss.model.Reports.Common;
using eidss.model.Schema;

namespace bv.tests.Reports
{
    [TestClass]
    public class FilterHelperTest
    {
        [TestMethod]
        public void GetDefaultLocationTest()
        {
            BaseReportTests.InitDBAndLogin();
            using (new CultureInfoTransaction(new CultureInfo("en-US")))
            {
                long? regionId;
                long? rayonId;
                FilterHelper.GetDefaultLocation(out regionId, out rayonId);
                Assert.IsNotNull(regionId);
                // Note: commented because for Tbilisi rayon is NULL
                //   Assert.IsNotNull(rayonId);
            }
        }

        [TestMethod]
        public void GetHumanDiagnosisListTest()
        {
            BaseReportTests.InitDBAndLogin();
            List<SelectListItemSurrogate> humanDiagnosisList = FilterHelper.GetHumanDiagnosisList("en");
            Assert.IsNotNull(humanDiagnosisList);
            Assert.IsTrue(humanDiagnosisList.Count > 0, "Diagnosis lookup is empty");
            Assert.IsTrue(humanDiagnosisList.Exists(c => c.Text == "Botulism"), "Botulism diagnosis not found");
        }

        [TestMethod]
        public void GetGetKzFilterListTest()
        {
            BaseReportTests.InitDBAndLogin();
            foreach (ReportFilterType filter in Enum.GetValues(typeof(ReportFilterType)))
            {
                if (filter != ReportFilterType.None)
                {
                    List<SelectListItemSurrogate> list = FilterHelper.GetKzFilterList("en", filter);
                    Assert.IsNotNull(list);
                    Assert.IsTrue(list.Count > 0, string.Format("Lookup {0} is empty", filter));
                }
            }
        }

        [TestMethod]
        public void GetAllRayonsTest()
        {
            BaseReportTests.InitDBAndLogin();
            List<SelectListItemSurrogate> rayons = FilterHelper.GetAllRayons("en");
            Assert.IsNotNull(rayons);
            Assert.IsTrue(rayons.Count > 0, "Rayon lookup is empty");
            Assert.IsTrue(rayons.Exists(c => c.Text == "Gagra"), "Rayon Gagra not found");
        }

        [TestMethod]
        public void GetAllRegionsTest()
        {
            BaseReportTests.InitDBAndLogin();
            List<SelectListItemSurrogate> regions = FilterHelper.GetAllRegions("en");
            Assert.IsNotNull(regions);
            Assert.IsTrue(regions.Count > 0, "Region lookup is empty");
            Assert.IsTrue(regions.Exists(c => c.Text == "Abkhazia"), "Region Abkhazia not found");
        }

        [TestMethod]
        public void SupportedLanguagesTest()
        {
            using (new CultureInfoTransaction(new CultureInfo("en-US")))
            {
                AssertListItem(FilterHelper.GetSupportedLanguages, "English (English)");
            }
        }

        [TestMethod]
        public void ExportFormatsListTest()
        {
            AssertListItem(FilterHelper.GetExportFormats, 4, "Pdf");
        }

        [TestMethod]
        public void PageSizeListTest()
        {
            AssertListItem(FilterHelper.GetPageSizeList, 2, "A4");
        }

        [TestMethod]
        public void PeriodTypeCollectionTest()
        {
            using (new CultureInfoTransaction(new CultureInfo("en-US")))
            {
                AssertListItem(() => FilterHelper.GetWebPeriodTypeList(0), 4, "Month");
            }
            using (new CultureInfoTransaction(new CultureInfo("ru-RU")))
            {
                AssertListItem(() => FilterHelper.GetWebPeriodTypeList(0), 4, "Месяц");
            }
        }

        [TestMethod]
        public void CounterCollectionTest()
        {
            using (new CultureInfoTransaction(new CultureInfo("en-US")))
            {
                AssertListItem(() => FilterHelper.GetWebCounterList(1), 4, "Absolute number");
            }
            using (new CultureInfoTransaction(new CultureInfo("ru-RU")))
            {
                AssertListItem(() => FilterHelper.GetWebCounterList(1), 4, "Абсолютное число");
            }
        }

        [TestMethod]
        public void CreateHalfYearCollectionTest()
        {
            AssertListItem(() => FilterHelper.GetWebHalfYearList(1), 2, "I");
        }

        [TestMethod]
        public void CreateQuarterCollectionTest()
        {
            AssertListItem(() => FilterHelper.GetWebQuarterList(1), 4, "1");
        }

        [TestMethod]
        public void MonthListTest()
        {
            using (new CultureInfoTransaction(new CultureInfo("en-US")))
            {
                AssertListItem(() => FilterHelper.GetWebMonthList(0), 12, "January");
            }
            using (new CultureInfoTransaction(new CultureInfo("ru-RU")))
            {
                AssertListItem(() => FilterHelper.GetWebMonthList(0), 12, "Январь");
            }
        }

        [TestMethod]
        public void GetRayonIdTest()
        {
            long? rayonId = FilterHelper.GetRayonIdFromComplexId("123__456");
            Assert.IsNotNull(rayonId);
            Assert.AreEqual(456, rayonId);
        }

        [TestMethod]
        public void GetRegionIdTest()
        {
            long? regionId = FilterHelper.GetRegionIdFromComplexId("123__456");
            Assert.IsNotNull(regionId);
            Assert.AreEqual(123, regionId);
        }

        private static List<SelectListItemSurrogate> AssertListItem(Func<List<SelectListItemSurrogate>> getList, string itemText)
        {
            List<SelectListItemSurrogate> list = getList();
            Assert.IsNotNull(list);
            Assert.IsTrue(list.Exists(m => m.Text == itemText));
            return list;
        }

        private static List<SelectListItemSurrogate> AssertListItem(Func<List<SelectListItemSurrogate>> getList, int count, string itemText)
        {
            List<SelectListItemSurrogate> list = AssertListItem(getList, itemText);
            Assert.AreEqual(count, list.Count);
            return list;
        }

        [TestMethod]
        public void SelectedDiagnoses2NamesTest()
        {
            var lookup = new List<DiagnosesAndGroupsLookup>();
            //using (var manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                //var da = DiagnosesAndGroupsLookup.Accessor.Instance(null); //m_CS
                lookup.Add(AddDiagnosesAndGroupsLookupItem( 1, 0, "g1"));
                lookup.Add(AddDiagnosesAndGroupsLookupItem( 2, 1, "i2"));
                lookup.Add(AddDiagnosesAndGroupsLookupItem( 3, 1, "i3"));
                lookup.Add(AddDiagnosesAndGroupsLookupItem( 4, 1, "i4"));
                lookup.Add(AddDiagnosesAndGroupsLookupItem( 5, 0, "g5"));
                lookup.Add(AddDiagnosesAndGroupsLookupItem( 6, 5, "i6"));
                lookup.Add(AddDiagnosesAndGroupsLookupItem( 7, 5, "i7"));
                lookup.Add(AddDiagnosesAndGroupsLookupItem(8, null, "i8"));
                lookup.Add(AddDiagnosesAndGroupsLookupItem(9, null, "i9"));
            }
            string[] checkedItems = "2,3,4,6".Split(new[] { "," },StringSplitOptions.RemoveEmptyEntries);
            var result = FilterHelper.SelectedDiagnoses2Names(checkedItems, lookup);
            Assert.AreEqual("g1, i6", result);
            
            checkedItems = "3,4,6".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            result = FilterHelper.SelectedDiagnoses2Names(checkedItems, lookup);
            Assert.AreEqual("i3, i4, i6", result);

            checkedItems = "2,6,7".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            result = FilterHelper.SelectedDiagnoses2Names(checkedItems, lookup);
            Assert.AreEqual("i2, g5", result);
            
            checkedItems = "2,6,7,8,9".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            result = FilterHelper.SelectedDiagnoses2Names(checkedItems, lookup);
            Assert.AreEqual("i2, g5, i8, i9", result);
            
            checkedItems = "2,3,4,6,7,9".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            result = FilterHelper.SelectedDiagnoses2Names(checkedItems, lookup);
            Assert.AreEqual("g1, g5, i9", result);

            checkedItems = "2,4,6,7,9".Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            result = FilterHelper.SelectedDiagnoses2Names(checkedItems, lookup);
            Assert.AreEqual("i2, i4, g5, i9", result);
        }

        private DiagnosesAndGroupsLookup AddDiagnosesAndGroupsLookupItem
            (long id, long? groupId, string name)
        {
            var item = DiagnosesAndGroupsLookup.CreateInstance();
            item.idfsDiagnosisOrDiagnosisGroup = id;
            item.blnGroup = groupId.HasValue && groupId.Value == 0;
            item.idfsDiagnosisGroup = groupId;
            item.name = name;
            return item;
        }
    }
}