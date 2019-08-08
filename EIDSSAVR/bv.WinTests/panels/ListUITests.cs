using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Validators;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using eidss.model.Resources;
using eidss.winclient.ActiveSurveillance;
using eidss.winclient.Administration;
using eidss.winclient.AggregateCase;
using eidss.winclient.Audit;
using eidss.winclient.Human;
using eidss.winclient.Lab;
using eidss.winclient.Outbreaks;
using eidss.winclient.RepositorySchemes;
using eidss.winclient.Security;
using eidss.winclient.VectorSurveillance;
using eidss.winclient.Vet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.WinTests.panels
{
    [TestClass]
    public class ListUITests
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));

            WinClientContext.FieldCaptions = EidssFields.Instance;
            RequiredValidator.FieldCaptions = EidssFields.Instance;
            ErrorForm.Messages = EidssMessages.Instance;
        }

        [TestMethod]
        // [Ignore]
        public void BatchListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new BatchListPanel());
        }

        [TestMethod]
        //[Ignore]
        public void TestListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new TestListPanel());
        }

        [TestMethod]
        // [Ignore]
        public void SampleListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new SampleListPanel());
        }

        [TestMethod]
        // [Ignore]
        public void SettlementListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new SettlementListPanel());
        }


        [TestMethod]
        //[Ignore]
        public void OutbreakListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new OutbreakListPanel());
        }

        [TestMethod]
        //[Ignore]
        public void AsCampaignListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new AsCampaignListPanel());
        }

        [TestMethod]
        // [Ignore]
        public void AsSessionListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new AsSessionListPanel());
        }

        [TestMethod]
        // [Ignore]
        public void SampleTransferListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new SampleTransferListPanel());
        }

        [TestMethod]
        // [Ignore]
        public void SampleDispositionListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new SampleDispositionListPanel());
        }

        [TestMethod]
        // [Ignore]
        public void RepositorySchemeListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new RepositorySchemeListPanel());
        }

        [TestMethod]
        //        [Ignore]
        public void UserGroupListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new UserGroupListPanel());
        }

        [TestMethod]
        //        [Ignore]
        public void SiteActivationServerListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new SiteListPanel());
        }

        [TestMethod]
        //[Ignore]
        public void VetCaseListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new VetCaseListPanel());
        }

        [TestMethod]
        //[Ignore]
        public void DataAuditListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new DataAuditListPanel());
        }

        [TestMethod]
        //[Ignore]
        public void EventLogListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new EventLogListPanel());
        }

        [TestMethod]
        //[Ignore]
        public void FarmListPanelTest()
        {
            BaseFormManager.ShowForSelection(new FarmListPanel(), new HumanCaseListPanel());
        }

        [TestMethod]
        //[Ignore]
        public void HumanCaseListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new HumanCaseListPanel());
        }

        [TestMethod]
        //[Ignore]
        public void NextNumbersListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new NextNumbersListPanel());
        }
        [TestMethod]
        //[Ignore]
        public void PatientListPanelTest()
        {
            BaseFormManager.ShowForSelection(new PatientListPanel(), new HumanCaseListPanel());
        }

        [TestMethod]
        //[Ignore]
        public void PersonListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new PersonListPanel());
        }

        [TestMethod]
        //[Ignore]
        public void OrganizationListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new OrganizationListPanel());
        }

        [TestMethod]
        //[Ignore]
        public void SecurityEventLogListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new SecurityEventLogListPanel());
        }
        //[TestMethod]
        ////[Ignore]
        //public void VsSessionListPanelTest()
        //{
        //    BaseFormManager.ShowSimpleFormModal(new VsSessionListPanel());
        //}

        [TestMethod]
        //[Ignore]
        public void HumanAggregateCaseListTest()
        {
            BaseFormManager.ShowSimpleFormModal(new HumanAggregateCaseList());
        }

        [TestMethod]
        //[Ignore]
        public void VetAggregateActionListTest()
        {
            BaseFormManager.ShowSimpleFormModal(new VetAggregateActionList());
        }

        [TestMethod]
        //[Ignore]
        public void VetAggregateCaseListTest()
        {
            BaseFormManager.ShowSimpleFormModal(new VetAggregateCaseList());
        }
        [TestMethod]
        //[Ignore]
        public void StatisticListPanelTest()
        {
            BaseFormManager.ShowSimpleFormModal(new StatisticListPanel());
        }
    }
}