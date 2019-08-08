// temporary commented after migration to VS 2012

//using System;
//using System.Collections.Generic;
//using System.ComponentModel.Design;
//using System.Text.RegularExpressions;
//using System.Windows.Input;
//using System.Windows.Forms;
//using System.Drawing;
//using Microsoft.VisualStudio.TestTools.UITesting;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Microsoft.VisualStudio.TestTools.UITest.Extension;
//using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
//
//
//namespace bv.WinTests.TranslationUI
//{
//    /// <summary>
//    /// Summary description for CodedUITest1
//    /// </summary>
//    [CodedUITest]
//    public class ControlDesignerTests
//    {
//        public ControlDesignerTests()
//        {
//        }
//
//        [TestMethod]
//        public void ControlDesignerTest()
//        {
//            var f = new ControlDesignerForm();
//
//            // Create the DesignSurface and load it with a form 
//            //DesignSurface ds = new DesignSurface();
//            //ds.BeginLoad(typeof(Form));
//            //// Get the View of the DesignSurface, host it in a form, and show it 
//            //Control c = ds.View as Control;
//            //c.Parent = f;
//            //c.Dock = DockStyle.Fill;
//            f.ShowDialog();
//
//        }
//
//        #region Additional test attributes
//
//        // You can use the following additional attributes as you write your tests:
//
//        ////Use TestInitialize to run code before running each test 
//        //[TestInitialize()]
//        //public void MyTestInitialize()
//        //{        
//        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
//        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
//        //}
//
//        ////Use TestCleanup to run code after each test has run
//        //[TestCleanup()]
//        //public void MyTestCleanup()
//        //{        
//        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
//        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
//        //}
//
//        #endregion
//
//        /// <summary>
//        ///Gets or sets the test context which provides
//        ///information about and functionality for the current test run.
//        ///</summary>
//        public TestContext TestContext
//        {
//            get
//            {
//                return testContextInstance;
//            }
//            set
//            {
//                testContextInstance = value;
//            }
//        }
//        private TestContext testContextInstance;
//    }
//}
