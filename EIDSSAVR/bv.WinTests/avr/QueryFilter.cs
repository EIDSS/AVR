using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using EIDSS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bv.common.Configuration;
using bv.common.db.Core;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using eidss.avr.FilterForm;
using eidss.avr.QueryBuilder;
using eidss.avr.db.DBService.QueryBuilder;
using eidss.model.Core;
using eidss.model.Core.Security;

namespace bv.WinTests.avr
{
    [TestClass]
    public class QueryFilter
    {
        private const long QueryId = 49540070000000;
        private const long HumanCaseIdField = 49540120000000;
        private const long HumanCaseTestId = 10082008;
        private const long TestNameIdValue = 6618590000000;
        private const string StrValue1 = "AAA";
        private const string StrValue2 = "BBB";
        private const string CaseIDAlias = "sflHC_CaseID";
        private const string TestNameAlias = "sflHCTest_TestType";
        #region Setup/Teardown
        const string Organizaton = "NCDC&PH";
        const string Admin = "test_admin";
        const string User = "test_user";
        const string AdminPassword = "test";
        const string UserPassword = "test";
        private EidssSecurityManager Security;
        public ModelUserContext context { get; protected set; }


        //[ClassInitialize]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}

        //[TestInitialize]
        //public void SetUp()
        //{
        //    DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
        //    ConnectionManager.DefaultInstance.SetCredentials(Config.GetSetting("EidssConnectionString"));
        //    EidssUserContext.Init();
        //    context = ModelUserContext.Instance as EidssUserContext;
        //    Security = new EidssSecurityManager();
        //    int result = Security.LogIn(Organizaton, Admin, AdminPassword);
        //    Assert.AreEqual(0, result);
        //    EIDSS_LookupCacheHelper.Init();
        //}
        //[TestCleanup]
        //public void TearDown()
        //{
        //    if (Security != null)
        //    {
        //        Security.LogOut();
        //    }
        //    if (context != null)
        //    {
        //        context.Close();
        //        context = null;
        //    }
        //    EidssUserContext.Clear();

        //}

        #endregion
        [TestMethod]
        public void QueryFilterTest()
        {
            m_Filter = CreateFilterControl();
            GroupOperator aggrGroup, rootGroup;
            CreateFilterCondition1(m_Filter, out rootGroup, out aggrGroup);

            var form = m_Filter.FindForm();
            var btnFlash = new SimpleButton { Parent = form, Dock = DockStyle.Bottom, Text = "Flash" };
            btnFlash.BringToFront();
            btnFlash.Click += FlashClick;
            var btnReferesh = new SimpleButton { Parent = form, Dock = DockStyle.Bottom, Text = "Refresh" };
            btnReferesh.BringToFront();
            btnReferesh.Click += RefereshClick;
            form.ShowDialog();

            //querySearchObjectDb.Post(searchObjectsDs);

        }

        private QueryFilterControl m_Filter;
        private void FlashClick(object sender, EventArgs e)
        {
            m_Filter.Flush();
            m_Filter.Bind((long)m_Filter.QueryDataset.Tables[1].Rows[0]["idfQuerySearchObject"], m_Filter.QueryDataset);
        }
        private void RefereshClick(object sender, EventArgs e)
        {
            var row = m_Filter.QueryDataset.Tables[QuerySearchObject_DB.TasQuerySearchField].Rows.Find(HumanCaseIdField);
            if (row != null)
                row.Delete();
            //m_Filter.QueryDataset.Tables[QuerySearchObject_DB.tasQuerySearchField].Rows[0].Delete();
            m_Filter.RefreshNodes();
        }

        [TestMethod]
        public void QueryFilterFlashTest()
        {
            var filter = CreateFilterControl();
            GroupOperator aggrGroup, rootGroup;
            CreateFilterCondition1(filter, out rootGroup, out aggrGroup);
            filter.Flush();
            var searchCriteriaTable = filter.QueryDataset.Tables[QuerySearchObject_DB.TasQueryConditionGroup];
            Assert.AreEqual(4, searchCriteriaTable.Rows.Count);
            var querySearchObjectId = (long)filter.QueryDataset.Tables[QuerySearchObject_DB.TasQuerySearchObject].Rows[0]["idfQuerySearchObject"];
            CheckConditionRow(searchCriteriaTable.Rows[0], -1L, DBNull.Value, querySearchObjectId, 0, DBNull.Value, HumanCaseIdField, "Binary", 0, StrValue1);
            CheckConditionRow(searchCriteriaTable.Rows[1], -1L, DBNull.Value, querySearchObjectId, 1, DBNull.Value, HumanCaseIdField, "Binary", 0, StrValue2);
            CheckConditionRow(searchCriteriaTable.Rows[2], -2L, DBNull.Value, querySearchObjectId, 2, -1L, DBNull.Value, "Exists");
            CheckConditionRow(searchCriteriaTable.Rows[3], -3L, -2L, -1L, 0, DBNull.Value, -1L, "Binary", 0, TestNameIdValue);

            filter.Bind((long)filter.QueryDataset.Tables[1].Rows[0]["idfQuerySearchObject"], filter.QueryDataset);

            CheckConditionRow(searchCriteriaTable.Rows[0], -1L, DBNull.Value, querySearchObjectId, 0, DBNull.Value, HumanCaseIdField, "Binary", 0, StrValue1);
            CheckConditionRow(searchCriteriaTable.Rows[1], -1L, DBNull.Value, querySearchObjectId, 1, DBNull.Value, HumanCaseIdField, "Binary", 0, StrValue2);
            CheckConditionRow(searchCriteriaTable.Rows[2], -2L, DBNull.Value, querySearchObjectId, 2, -1L, DBNull.Value, "Exists");
            CheckConditionRow(searchCriteriaTable.Rows[3], -3L, -2L, -1L, 0, DBNull.Value, -1L, "Binary", 0, TestNameIdValue);

            var row = filter.QueryDataset.Tables[QuerySearchObject_DB.TasQuerySearchField].Rows.Find(HumanCaseIdField);
            if (row != null)
                row.Delete();
            filter.RefreshNodes();
            CheckConditionRow(searchCriteriaTable.Rows[0], -1L, DBNull.Value, querySearchObjectId, 0, -2L, DBNull.Value, "Exists");
            CheckConditionRow(searchCriteriaTable.Rows[1], -2L, -1L, -2L, 0, DBNull.Value, -2L, "Binary", 0, TestNameIdValue);

        }


        private void CheckConditionRow
            (DataRow row, long idfQueryConditionGroup, object idfParentQueryConditionGroup, long idfQuerySearchObject,
            int intOrder, object idfSubQuerySearchObject = null, object idfQuerySearchField = null,
            object strOperator = null, object intOperatorType = null, object varValue = null, object blnFieldConditionUseNot = null,
            object blnJoinByOr = null, bool blnUseNot = false)
        {
            if (idfSubQuerySearchObject == null) idfSubQuerySearchObject = DBNull.Value;
            if (idfQuerySearchField == null) idfQuerySearchField = DBNull.Value;
            if (strOperator == null) strOperator = DBNull.Value;
            if (intOperatorType == null) intOperatorType = DBNull.Value;
            if (varValue == null) varValue = DBNull.Value;
            if (blnFieldConditionUseNot == null) blnFieldConditionUseNot = DBNull.Value;
            if (blnJoinByOr == null) blnJoinByOr = DBNull.Value;
            Assert.AreEqual(idfQueryConditionGroup, row["idfQueryConditionGroup"]);
            Assert.AreEqual(idfParentQueryConditionGroup, row["idfParentQueryConditionGroup"]);
            Assert.AreEqual(idfQuerySearchObject, row["idfQuerySearchObject"]);
            Assert.AreEqual(intOrder, row["intOrder"]);
            Assert.AreEqual(blnJoinByOr, row["blnJoinByOr"]);
            Assert.AreEqual(blnUseNot, row["blnUseNot"]);
            Assert.AreEqual(idfSubQuerySearchObject, row["idfSubQuerySearchObject"]);
            Assert.AreEqual(idfQuerySearchField, row["idfQuerySearchField"]);
            Assert.AreEqual(strOperator, row["strOperator"]);
            Assert.AreEqual(intOperatorType, row["intOperatorType"]);
            Assert.AreEqual(varValue, row["varValue"]);
            Assert.AreEqual(blnFieldConditionUseNot, row["blnFieldConditionUseNot"]);
        }

        /*
         * AND
         *      Human Case ID = 'AAA'
         *      Human Case ID = 'BBB'
         *      Exists Human Case Test
         *          AND
         *              Human case Test Type = 6618590000000 ('Anaplasma test')
         */

        private void CreateFilterCondition1(QueryFilterControl filter, out GroupOperator rootGroup, out GroupOperator aggrGroup)
        {
            CriteriaOperator criteria;
            rootGroup = QueryFilterControl.AddGroupOperator(null, null, null, out criteria);
            QueryFilterControl.AddFieldOperator(rootGroup, CaseIDAlias, StrValue1, SearchOperator.Binary, BinaryOperatorType.Equal, false);
            QueryFilterControl.AddFieldOperator(rootGroup, CaseIDAlias, StrValue2, SearchOperator.Binary, BinaryOperatorType.Equal, false);
            AggregateOperand aggrOp = QueryFilterControl.AddAggregateOperand(rootGroup, "<Human Case Test>", false);
            CriteriaOperator aggrCriteria;
            aggrGroup = QueryFilterControl.AddGroupOperator(null, null, null, out aggrCriteria);
            QueryFilterControl.AddFieldOperator(aggrGroup, TestNameAlias, TestNameIdValue, SearchOperator.Binary, BinaryOperatorType.Equal,
                false);
            aggrOp.Condition = aggrCriteria;
            filter.FilterCriteria = criteria;
            filter.HasChanges = true;
        }

        private QueryFilterControl CreateFilterControl(string lang = "en")
        {
            DbManagerFactory.SetSqlFactory(Config.GetSetting("EidssConnectionString"));
            ConnectionManager.DefaultInstance.SetCredentials(Config.GetSetting("EidssConnectionString"));
            EidssUserContext.Init();
            context = ModelUserContext.Instance as EidssUserContext;
            Security = new EidssSecurityManager();
            int result = Security.LogIn(Organizaton, Admin, AdminPassword);
            Assert.AreEqual(0, result);
            EIDSS_LookupCacheHelper.Init();
            EidssUserContext.CurrentLanguage = lang;
            var queryDb = new Query_DB();
            var querySearchObjectDb = new QuerySearchObject_DB();
            var queryDs = queryDb.LoadDetailData(QueryId);
            DataRow row = queryDs.Tables[Query_DB.TasQueryObjectTree].Rows[0];
            var searchObjectsDs = querySearchObjectDb.LoadDetailData(row["idfQuerySearchObject"]);

            var form = new Form();
            var filter = new QueryFilterControl { Parent = form, Dock = DockStyle.Fill };
            filter.Init();
            filter.Bind((long)queryDs.Tables[1].Rows[0]["idfQuerySearchObject"], searchObjectsDs);
            return filter;

        }


    }
}
