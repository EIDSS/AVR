using System;
using System.Windows.Forms;
using bv.common.Enums;
using bv.winclient.BasePanel;
using bv.winclient.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.WinTests.Core
{
    /// <summary>
    ///This is a test class for ErrorFormTest and is intended
    ///to contain all ErrorFormTest Unit Tests
    ///</summary>
    [TestClass]
    public class ErrorFormTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes

        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            ErrorForm.UnitTestMode = true;
        }

        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //

        #endregion

        /// <summary>
        ///A test for ErrorForm Constructor
        ///</summary>
        [TestMethod]
        [Ignore]
        public void ErrorFormConstructorTest()
        {
            var target = new ErrorForm();
        }

        /// <summary>
        ///A test for DefineButtonsVisibility
        ///</summary>
        //[TestMethod]
        //[DeploymentItem("bv.winclient.dll")]
        //public void DefineButtonsVisibilityTest()
        //{
        //    using (var frm = new ErrorForm())
        //    {
        //        frm.Show();
        //        try
        //        {
        //            var target = new ErrorForm_Accessor(new PrivateObject(frm)) {m_FormType = ErrorForm.FormType.Warning}; 
        //            // TODO: Initialize to an appropriate value
        //            target.DefineButtonsVisibility();
        //            Assert.IsFalse(target.pnDetails.Visible);
        //            Assert.IsFalse(target.cmdDetail.Visible);

        //            target.m_FormType = ErrorForm.FormType.Message;
        //            target.DefineButtonsVisibility();
        //            Assert.IsFalse(target.pnDetails.Visible);
        //            Assert.IsFalse(target.cmdDetail.Visible);

        //            target.m_FormType = ErrorForm.FormType.Error;
        //            target.DefineButtonsVisibility();
        //            Assert.IsFalse(target.pnDetails.Visible);
        //            Assert.IsFalse(target.cmdDetail.Visible);

        //            target.m_FormType = ErrorForm.FormType.Error;
        //            target.txtFullErrorText.Text = @"Some text";
        //            target.DefineButtonsVisibility();
        //            Assert.IsTrue(target.pnDetails.Visible);
        //            Assert.IsTrue(target.cmdDetail.Visible);
        //            target.DefineButtonsVisibility();
        //            Assert.IsFalse(target.pnDetails.Visible);
        //            Assert.IsTrue(target.cmdDetail.Visible);
        //        }
        //        finally
        //        {
        //            frm.Close();
        //        }
        //    }
        //}

        /// <summary>
        ///A test for Dispose
        ///</summary>
        //[TestMethod]
        //[DeploymentItem("bv.winclient.dll")]
        //public void DisposeTest()
        //{
        //    var target = new ErrorForm_Accessor(); // TODO: Initialize to an appropriate value
        //    const bool disposing = true;
        //    target.Dispose(disposing);
        //}

        /// <summary>
        ///A test for InitializeComponent
        ///</summary>
        //[TestMethod]
        //[DeploymentItem("bv.winclient.dll")]
        //public void InitializeComponentTest()
        //{
        //    var target = new ErrorForm_Accessor(); // TODO: Initialize to an appropriate value
        //    target.InitializeComponent();
        //}

        /// <summary>
        ///A test for OnResize
        ///</summary>
        //[TestMethod]
        //[DeploymentItem("bv.winclient.dll")]
        //public void OnResizeTest()
        //{
        //    using (var frm = new ErrorForm())
        //    {
        //        frm.Show();
        //        try
        //        {
        //            var target = new ErrorForm_Accessor(new PrivateObject(frm)); // TODO: Initialize to an appropriate value
        //            EventArgs e = null; // TODO: Initialize to an appropriate value
        //            target.OnResize(e);
        //        }
        //        finally
        //        {
        //            frm.Close();
        //        }
        //    }
        //}

        /// <summary>
        ///A test for ShowError
        ///</summary>
        [TestMethod]
        [Ignore]
        public void ShowErrorTest()
        {
            ErrorForm.UnitTestMode = false;
            var ex = new Exception("Test Exception"); // TODO: Initialize to an appropriate value
            ErrorForm.ShowError(StandardError.DatabaseError, ex);
            ErrorForm.ShowError(StandardError.DataRetrievingError, ex);
            ErrorForm.ShowError(StandardError.DataSavingtError, ex);
            ErrorForm.ShowError(StandardError.DataValidationError, ex);
            ErrorForm.ShowError(StandardError.InvalidLogin, ex);
            ErrorForm.ShowError(StandardError.SqlQueryError, ex);
            ErrorForm.ShowError(StandardError.StoredProcedureError, ex);
            ErrorForm.ShowError(StandardError.UnprocessedError, ex);
            ErrorForm.ShowError(StandardError.PermissionError, ex);
            ErrorForm.UnitTestMode = true;
        }

        /// <summary>
        ///A test for ShowError
        ///</summary>
        [TestMethod]
        [Ignore]
        public void ShowErrorTest1()
        {
            const string errResourceName = "ErrUserNotFound";
            const string errMsg = "Username Not Found.";
            ErrorForm.ShowError(errResourceName, errMsg);
        }

        /// <summary>
        ///A test for ShowError
        ///</summary>
        [TestMethod]
        [Ignore]
        public void ShowErrorTest2()
        {
            const string errResourceName = "errSqlServerNotFound";
            var args = new[] {"Sql2005"};
            ErrorForm.ShowError(errResourceName, null, args);
        }

        /// <summary>
        ///A test for ShowError
        ///</summary>
        [TestMethod]
        [Ignore]
        public void ShowErrorTest3()
        {
            var ex = new Exception("Test Exception");
            ErrorForm.ShowError(ex);
        }

        /// <summary>
        ///A test for ShowError
        ///</summary>
        [TestMethod]
        [Ignore]
        public void ShowErrorTest4()
        {
            const string errResourceName = "ErrUserNotFound";
            ErrorForm.ShowError(errResourceName);
        }

        /// <summary>
        ///A test for ShowErrorDirect
        ///</summary>
        [TestMethod]
        [Ignore]
        public void ShowErrorDirectTest()
        {
            const string errResourceName = "errSqlServerNotFound";
            var args = new[] {"Sql2005"};
            ErrorForm.ShowErrorDirect(errResourceName, args);
        }

        /// <summary>
        ///A test for ShowErrorDirect
        ///</summary>
        [TestMethod]
        [Ignore]
        public void ShowErrorDirectTest1()
        {
            using (var Owner = new Form())
            {
                Owner.Show();
                const string errResourceName = "errSqlServerNotFound";
                var args = new[] {"Sql2005"};
                ErrorForm.ShowErrorDirect(Owner, errResourceName, args);
            }
        }

        /// <summary>
        ///A test for ShowErrorThreadSafe
        ///</summary>
        [TestMethod]
        [Ignore]
        public void ShowErrorThreadSafeTest()
        {
            using (var owner = new Form())
            {
                owner.Show();
                BaseFormManager.Init(owner);
                var ex = new Exception("Test Exception");
                ErrorForm.ShowErrorThreadSafe(ex);
            }
        }

        /// <summary>
        ///A test for ShowMessage
        ///</summary>
        [TestMethod]
        [Ignore]
        public void ShowMessageTest()
        {
            const string errResourceName = "ErrUserNotFound";
            const string errMsg = "Username Not Found.";
            ErrorForm.ShowMessage(errResourceName, errMsg);
        }

        /// <summary>
        ///A test for ShowMessageDirect
        ///</summary>
        [TestMethod]
        [Ignore]
        public void ShowMessageDirectTest()
        {
            const string msg = "Username Not Found.";
            ErrorForm.ShowMessageDirect(msg);
        }

        /// <summary>
        ///A test for ShowMessageDirect
        ///</summary>
        //[TestMethod]
        //[DeploymentItem("bv.winclient.dll")]
        //public void ShowMessageDirectTest1()
        //{
        //    using (var owner = new Form())
        //    {
        //        const string msg = "Test Message";
        //        const ErrorForm.FormType fType = ErrorForm.FormType.Message;
        //        const string detailError = "Test detail error";
        //        ErrorForm_Accessor.ShowMessageDirect(owner, msg, fType, detailError);
        //    }
        //}

        /// <summary>
        ///A test for ShowMessageDirect
        ///</summary>
        //[TestMethod]
        //[DeploymentItem("bv.winclient.dll")]
        //public void ShowMessageDirectTest2()
        //{
        //    const string msg = "Test Message";
        //    const ErrorForm.FormType fType = ErrorForm.FormType.Message;
        //    const string detailError = "Test detail error";
        //    ErrorForm_Accessor.ShowMessageDirect(msg, fType, detailError);
        //}

        /// <summary>
        ///A test for ShowWarning
        ///</summary>
        [TestMethod]
        [Ignore]
        public void ShowWarningTest()
        {
            const string str = "ErrUserNotFound";
            const string defaultStr = "Username Not Found.";
            ErrorForm.ShowWarning(str, defaultStr);
        }

        /// <summary>
        ///A test for ShowWarningDirect
        ///</summary>
        [TestMethod]
        [Ignore]
        public void ShowWarningDirectTest()
        {
            const string str = "Test Warning";
            ErrorForm.ShowWarningDirect(str);
        }

        /// <summary>
        ///A test for cmdDetail_Click
        ///</summary>
        //[TestMethod]
        //[DeploymentItem("bv.winclient.dll")]
        //public void cmdDetail_ClickTest()
        //{
        //    using (var form = new ErrorForm())
        //    {
        //        form.Show();
        //        var target = new ErrorForm_Accessor(new PrivateObject(form));
        //        object sender = null;
        //        EventArgs e = null;
        //        target.cmdDetail_Click(sender, e);
        //    }
        //}

        /// <summary>
        ///A test for ErrorText
        ///</summary>
        [TestMethod]
        [Ignore]
        public void ErrorTextTest()
        {
            var target = new ErrorForm();
            const string expected = "test";
            target.ErrorText = expected;
            string actual = target.ErrorText;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for FullErrorText
        ///</summary>
        [TestMethod]
        [Ignore]
        public void FullErrorTextTest()
        {
            var target = new ErrorForm();
            const string expected = "test";
            target.FullErrorText = expected;
            string actual = target.FullErrorText;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Type
        ///</summary>
        [TestMethod]
        [Ignore]
        public void TypeTest()
        {
            var target = new ErrorForm();
            const ErrorForm.FormType expected = ErrorForm.FormType.Error;
            target.Type = expected;
            ErrorForm.FormType actual = target.Type;
            Assert.AreEqual(expected, actual);
        }
    }
}