using System;
using System.Collections.Generic;
using System.Globalization;
using EIDSS.Reports.BaseControls.Form;
using EIDSS.Reports.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.Core;
using bv.tests.common;
using eidss.model.Reports;

namespace bv.WinTests.Reports
{
    [TestClass]
    public class ReportFactoryTests
    {
        #region Setup/Teardown

        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            BaseReportTests.InitDBAndLogin();
            BaseReportTests.LoadAssemblies();
            m_Factory = new ReportFactory();
        }

        [TestInitialize]
        public void SetUp()
        {
            InitReportForm(false);
        }

        #endregion

        private static IReportFactory m_Factory;

        private static void InitReportForm(bool isFake)
        {
            ReportFactory.CreateReportFormHandler = (isFake)
                                                        ? (CreateReportFormDelegate)
                                                          (() => new FakeReportForm())
                                                        : (() => new ReportForm());
        }

        [TestMethod]
        public void SessionForm()
        {
            m_Factory.VetActiveSurveillanceSampleCollected(712900000000);
        }

        [TestMethod]
        public void EventLog()
        {
            m_Factory.AdmEventLog();
        }

        [TestMethod]
        public void HumAccessionIn()
        {
            m_Factory.LimAccessionIn(128420000000);
        }

        [TestMethod]
        public void HumCaseInvestigationForm()
        {
            m_Factory.HumCaseInvestigation(44550000204, 128950000002, 128960000002, 580000000);
        }

        [TestMethod]
        public void HumDiagnosisToChangedDiagnosis()
        {
            m_Factory.HumDiagnosisToChangedDiagnosis();
        }

        [TestMethod]
        public void HumEmergencyNotification()
        {
            m_Factory.HumUrgentyNotification(44550000204);
        }

        [TestMethod]
        public void HumFormN1A3()
        {
            m_Factory.HumFormN1A3();
        }

        [TestMethod]
        public void HumFormN1A4()
        {
            m_Factory.HumFormN1A4();
        }

        [TestMethod]
        public void HumMonthlyMorbidityAndMortality()

        {
            m_Factory.HumMonthlyMorbidityAndMortality();
        }


        [TestMethod]
        public void HumAggregateCase()
        {
            m_Factory.HumAggregateCase(new AggregateReportParameters(11770000241, 0, 11780000241));
        }

        [TestMethod]
        public void HumAggregateCaseSummary()
        {
            m_Factory.HumAggregateCaseSummary(
                new AggregateSummaryReportParameters(
                    @"<?xml version=""1.0"" encoding=""UTF-16""?><ROOT><AdminLevel AreaType=""Country""><AdminUnit AdminUnitID=""170000000"" /></AdminLevel><TimeInterval PeriodType=""Year""><TimeIntervalUnit StartDate=""2009-01-01"" FinishDate=""2010-12-31"" /><TimeIntervalUnit StartDate=""2008-01-01"" FinishDate=""2008-12-31"" /></TimeInterval></ROOT>",
                    new[] {11540000241, 11780000241}));
        }

        [TestMethod]
        public void VetAggregateCase()
        {
            m_Factory.VetAggregateCase(new AggregateReportParameters(12360000241, 0, 12370000241));
        }

        [TestMethod]
        public void VetAggregateCaseActions()
        {
            m_Factory.VetAggregateCaseActions(new AggregateActionsParameters(5300360000000, 0, 5300370000000, 0, 5300380000000, 0,
                                                                             5300390000000, GetLabels()));
        }

        [TestMethod]
        public void VetAggregateCaseActionsSummary()
        {
            m_Factory.VetAggregateCaseActionsSummary(
                new AggregateActionsSummaryParameters(
                    @"<?xml version=""1.0"" encoding=""UTF-16""?><ROOT><AdminLevel AreaType=""Country""><AdminUnit AdminUnitID=""170000000"" /></AdminLevel><TimeInterval PeriodType=""Year""><TimeIntervalUnit StartDate=""2009-01-01"" FinishDate=""2009-12-31"" /><TimeIntervalUnit StartDate=""2008-01-01"" FinishDate=""2010-12-31"" /></TimeInterval></ROOT>",
                    new[] {12730000241, 12737000000},
                    new[] {12740000241, 12738000000},
                    new[] {12750000241, 12739000000},
                    GetLabels()));
        }

        private static Dictionary<string, string> GetLabels()
        {
            var labels = new Dictionary<string, string>();
            foreach (string lang in Localizer.SupportedLanguages.Keys)
            {
                labels.Add("@diagnosticText" + lang, "xtpDiagnosticAction.Text" + lang);
                labels.Add("@prophylacticText" + lang, "xtpProphilacticAction.Text" + lang);
                labels.Add("@sanitaryText" + lang, "xtpSanitaryAction.Text" + lang);
            }
            return labels;
        }

        [TestMethod]
        public void VetAggregateCaseSummary()
        {
            m_Factory.VetAggregateCaseSummary(
                new AggregateSummaryReportParameters(
                    @"<?xml version=""1.0"" encoding=""UTF-16""?><ROOT><AdminLevel AreaType=""Country""><AdminUnit AdminUnitID=""170000000"" /></AdminLevel><TimeInterval PeriodType=""Year""><TimeIntervalUnit StartDate=""2009-01-01"" FinishDate=""2009-12-31"" /><TimeIntervalUnit StartDate=""2008-01-01"" FinishDate=""2008-12-31"" /></TimeInterval></ROOT>",
                    new[] {12370000241}));
        }

        [TestMethod]
        public void VetAvianInvestigationForm()
        {
            m_Factory.VetAvianInvestigation(4970000002, 2480000000, false);
        }

        [TestMethod]
        public void VetLivestockInvestigationForm()
        {
            m_Factory.VetLivestockInvestigation(4970000002, 2480000000, false);
        }

        [TestMethod]
        public void VetSamplesCount()
        {
            m_Factory.VetSamplesCount();
        }

        [TestMethod]
        public void VetSamplesReportBySampleType()
        {
            m_Factory.VetSamplesBySampleType();
        }

        [TestMethod]
        public void VetSamplesReportBySampleTypesWithinRegions()
        {
            m_Factory.VetSamplesBySampleTypesWithinRegions();
        }

        [TestMethod]
        public void VetYearlySituation()
        {
            m_Factory.VetYearlySituation();
        }

        [TestMethod]
        public void HumSerologyResearchCard()
        {
            m_Factory.HumSerologyResearchCard();
        }

        [TestMethod]
        public void HumMicrobiologyResearchCard()
        {
            m_Factory.HumMicrobiologyResearchCard();
        }

        [TestMethod]
        public void HumAntibioticResistanceCard()
        {
            m_Factory.HumAntibioticResistanceCard();
        }

        [TestMethod]
        public void Journal60BReportCard()
        {
            m_Factory.Hum60BJournal();
        }

        [TestMethod]
        public void HumInfectiousDiseaseMonth()
        {
            m_Factory.HumMonthInfectiousDiseaseV6();
        }

        [TestMethod]
        public void HumInfectiousDiseaseIntermediateMonth()
        {
            m_Factory.HumIntermediateMonthInfectiousDiseaseV6();
        }

        [TestMethod]
        public void HumInfectiousDiseaseYear()
        {
            m_Factory.HumAnnualInfectiousDisease();
        }

        [TestMethod]
        public void HumInfectiousDiseaseIntermediateYear()
        {
            m_Factory.HumIntermediateAnnualInfectiousDisease();
        }

        [TestMethod]
        public void LimBatchTest()
        {
            Console.WriteLine((new CultureInfo("en-US")).DateTimeFormat.ShortDatePattern);
            Console.WriteLine((new CultureInfo("ru-RU")).DateTimeFormat.ShortDatePattern);
            Console.WriteLine((new CultureInfo("ka-GE")).DateTimeFormat.ShortDatePattern);
            Console.WriteLine((new CultureInfo("az-Latn-AZ")).DateTimeFormat.ShortDatePattern);
            Console.WriteLine((new CultureInfo("kk-KZ")).DateTimeFormat.ShortDatePattern);

            m_Factory.LimBatchTest(1780000241, 40580000000);
        }

        [TestMethod]
        public void LimCaseTest()
        {
            m_Factory.LimTest(20580000243, true);
        }

        [TestMethod]
        public void LimContainerContent()
        {
            m_Factory.LimContainerContent(9190000002, null);
            m_Factory.LimContainerContent(null, 9190000002);
        }

        [TestMethod]
        public void LimContainerDetails()
        {
            m_Factory.LimSample(1);
        }

        [TestMethod]
        public void LimSampleTransferForm()
        {
            m_Factory.LimSampleTransfer(8800000002);
        }

        [TestMethod]
        public void LimTestResult()
        {
            m_Factory.LimTestResult(1, 2, 3);
        }

        [TestMethod]
        public void UniOutbreak()
        {
            m_Factory.Outbreak(12430000004);
        }

        [TestMethod]
        public void VetRegionPreventiveMeasures()
        {
            m_Factory.VetOblastPreventiveMeasures();
        }

        [TestMethod]
        public void VetCountryPreventiveMeasures()
        {
            m_Factory.VetCountryPreventiveMeasures();
        }

        [TestMethod]
        public void VetCountryProphilacticMeasures()
        {
            m_Factory.VetCountrySanitaryMeasures();
        }

        [TestMethod]
        public void VetRegionProphilacticMeasures()
        {
            m_Factory.VetOblastSanitaryMeasures();
        }

        [TestMethod]
        public void VetCountryPlannedDiagnosticTests()
        {
            m_Factory.VetCountryPlannedDiagnosticTests();
        }

        [TestMethod]
        public void VetRegionPlannedDiagnosticTests()
        {
            m_Factory.VetOblastPlannedDiagnosticTests();
        }
    }
}
