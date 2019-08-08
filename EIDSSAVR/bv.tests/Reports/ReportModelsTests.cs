using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.tests.common;
using eidss.model.Reports.AZ;
using eidss.model.Reports.Common;
using eidss.model.Schema;
using eidss.webclient.Models.Reports;

namespace bv.tests.Reports
{
    [TestClass]
    public class ReportModelsTests
    {
        [TestMethod]
        public void AFPModelYearTest()
        {
            var model = new AFPModel {PeriodType = 0, Year = 2012};
            Assert.AreEqual(new DateTime(2012, 01, 01), model.StartDate);
            Assert.AreEqual(new DateTime(2012, 12, 31), model.EndDate);
        }

        [TestMethod]
        public void AFPModelHalfYearTest()
        {
            var model = new AFPModel {PeriodType = 1, Period = 0, Year = 2012};
            Assert.AreEqual(new DateTime(2012, 01, 01), model.StartDate);
            Assert.AreEqual(new DateTime(2012, 06, 30), model.EndDate);

            model = new AFPModel {PeriodType = 1, Period = 1, Year = 2012};
            Assert.AreEqual(new DateTime(2012, 07, 01), model.StartDate);
            Assert.AreEqual(new DateTime(2012, 12, 31), model.EndDate);
        }

        [TestMethod]
        public void AFPModelQuarterTest()
        {
            var model = new AFPModel {PeriodType = 2, Period = 0, Year = 2012};
            Assert.AreEqual(new DateTime(2012, 01, 01), model.StartDate);
            Assert.AreEqual(new DateTime(2012, 03, 31), model.EndDate);

            model = new AFPModel {PeriodType = 2, Period = 1, Year = 2012};
            Assert.AreEqual(new DateTime(2012, 04, 01), model.StartDate);
            Assert.AreEqual(new DateTime(2012, 06, 30), model.EndDate);

            model = new AFPModel {PeriodType = 2, Period = 2, Year = 2012};
            Assert.AreEqual(new DateTime(2012, 07, 01), model.StartDate);
            Assert.AreEqual(new DateTime(2012, 09, 30), model.EndDate);

            model = new AFPModel {PeriodType = 2, Period = 3, Year = 2012};
            Assert.AreEqual(new DateTime(2012, 10, 01), model.StartDate);
            Assert.AreEqual(new DateTime(2012, 12, 31), model.EndDate);
        }

        [TestMethod]
        public void AFPModelMonthTest()
        {
            var model = new AFPModel {PeriodType = 3, Period = 0, Year = 2012};
            Assert.AreEqual(new DateTime(2012, 01, 01), model.StartDate);
            Assert.AreEqual(new DateTime(2012, 01, 31), model.EndDate);

            model = new AFPModel {PeriodType = 3, Period = 1, Year = 2012};
            Assert.AreEqual(new DateTime(2012, 02, 01), model.StartDate);
            Assert.AreEqual(new DateTime(2012, 02, 29), model.EndDate);

            model = new AFPModel {PeriodType = 3, Period = 11, Year = 2012};
            Assert.AreEqual(new DateTime(2012, 12, 01), model.StartDate);
            Assert.AreEqual(new DateTime(2012, 12, 31), model.EndDate);
        }

        [TestMethod]
        public void AddressModelInternalTest()
        {
            BaseReportTests.InitDBAndLogin();

            var model = new AddressModel();
            Assert.IsNotNull(model.InternalAddress(null));
            Assert.IsNotNull(model.InternalAddress(null).RegionLookup);
            Assert.IsTrue(model.InternalAddress(null).RegionLookup.Count > 1);
            RegionLookup anyRegion = model.InternalAddress(null).RegionLookup.First(r => r.idfsRegion > 0);

            Assert.IsTrue(model.InternalAddress(null).RayonLookup.Count == 1);
            model.InternalAddress(null).Region = anyRegion;
            Assert.IsTrue(model.InternalAddress(null).RayonLookup.Count > 1);
        }

        [TestMethod]
        public void AddressModelRegionRayonTest()
        {
            BaseReportTests.InitDBAndLogin();

            var model = new AddressModel();
            List<SelectListItemSurrogate> regions = model.GetSelectedRegions(null);

            Assert.IsNotNull(regions);
            Assert.IsTrue(regions.Count > 1);
            RegionLookup anyRegion = model.InternalAddress(null).RegionLookup.First(r => r.idfsRegion > 0);

            Assert.IsTrue(model.GetRayons(null).Count == 1);
            model.RegionId = anyRegion.idfsRegion;
            Assert.IsTrue(model.GetRayons(null).Count > 1);
        }

        [TestMethod]
        public void FormN1ModelTest()
        {
            BaseReportTests.InitDBAndLogin();

            var model = new FormNo1Model();
            Assert.IsNotNull(model.SelectedCurrentMonthList);
            Assert.AreEqual(13, model.SelectedCurrentMonthList.Count);
            Assert.IsNotNull(model.SelectedJanuaryMonthList);
            Assert.AreEqual(13, model.SelectedJanuaryMonthList.Count);
            Assert.IsNotNull(model.PageSizeList);
            Assert.AreEqual(2, model.PageSizeList.Count);
        }
    }
}