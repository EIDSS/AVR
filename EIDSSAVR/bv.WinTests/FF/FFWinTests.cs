using System.Data;
using System.Data.SqlClient;
using bv.common.win;
using bv.model.Model.Core;
using bv.tests.Core;
using bv.tests.db.tests;
using bv.winclient.BasePanel;
using EIDSS.FlexibleForms;
using EIDSS.FlexibleForms.DataBase;
using EIDSS.FlexibleForms.Helpers;
using eidss.model.Core;
using eidss.model.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using EIDSS4FF = eidss.winclient.FlexForms;

namespace bv.WinTests.FF
{
    [TestClass]
    public class FFWinTests : EidssEnvWithLogin
    {
        [TestMethod]
        public void FlexFormEditorTest()
        {
            object id = null;
            BaseFormManager.ShowModal(new FlexibleFormEditor(), null, ref id, null, null);
        }

        [TestMethod]
        public void FFDeterminantWindowTest()
        {
            EidssUserContext.Init();
           
            var dbService = new DbService();
            var transactionOpened = false;
            SqlTransaction transaction = null;
            try
            {
                if (dbService.Connection.State == ConnectionState.Closed) dbService.Connection.Open();
                Assert.IsTrue(dbService.Connection.State == ConnectionState.Open);

                dbService.LoadFormTypes();
                Assert.IsTrue(dbService.MainDataSet.FormTypes.Count > 0);

                dbService.LoadSections(null, null, null);
                Assert.IsTrue(dbService.MainDataSet.Sections.Count > 0);

                dbService.LoadParameters(null, null);
                Assert.IsTrue(dbService.MainDataSet.Parameters.Count > 0);

                var rowFormType =
                    Enumerable.Where(dbService.MainDataSet.FormTypes,
                                     c => c.idfsFormType == (long) FFTypeEnum.VectorTypeSpecificData).
                        SingleOrDefault();

                Assert.IsNotNull(rowFormType);

                #region Создаём новый шаблон

                var rowTemplate = dbService.MainDataSet.Templates.NewTemplatesRow();
                rowTemplate.idfsFormType = rowFormType.idfsFormType;
                //если это первый шаблон в своём типе формы, то сделаем его UNI
                rowTemplate.blnUNI = (dbService.GetTemplatesByFormType(rowFormType.idfsFormType).Length == 0);
                rowTemplate.DefaultName = "Template1";
                rowTemplate.NationalName = "Template1";
                rowTemplate.NationalLongName = "Template Long name 1";
                rowTemplate.langid = ModelUserContext.CurrentLanguage;
                dbService.MainDataSet.Templates.AddTemplatesRow(rowTemplate);

                #endregion

                var form = new FFDeterminants(dbService, rowTemplate);
                BaseFormManager.ShowModal(form, null);
                //BaseFormManager.ShowModal(form, null, ref id, null, null);
                Assert.IsNotNull(form.SelectedDeterminantsRow);

                //присваиваем шаблону выбранный детерминант
                var determinant = dbService.CreateTemplateDeterminantValuesRow(form.SelectedDeterminantsRow,
                                                                               rowTemplate.idfsFormTemplate,
                                                                               rowTemplate.idfsFormType);

                //сохраняем
                transaction = (SqlTransaction)dbService.Connection.BeginTransaction();
                transactionOpened = true;
                dbService.PostDetail(dbService.MainDataSet, 0, transaction);
                //
                Assert.IsTrue(determinant.idfDeterminantValue > -1);
                Assert.IsTrue(rowTemplate.idfsFormTemplate > -1);

                transaction.Commit();
                transactionOpened = false;

                //создаём новый датасервис, чтобы проверить, сохранились ли детерминанты
                var dbService2 = new DbService();
                
                dbService2.LoadTemplateDeterminants(rowTemplate.idfsFormTemplate);
                var determinantTemplate =
                    dbService2.MainDataSet.TemplateDeterminantValues.SingleOrDefault(c => c.idfDeterminantValue == determinant.idfDeterminantValue);
                Assert.IsNotNull(determinantTemplate);

                #region удаляем добавленные элементы

                dbService.DeleteDeterminantsFromTemplate(rowTemplate.idfsFormTemplate);
                rowTemplate.Delete();

                #endregion

                dbService.PostDetail(dbService.MainDataSet, 0, null);

                //transaction.Rollback();
                //transactionOpened = false;
            }
            finally
            {
                if ((transaction != null) && transactionOpened) transaction.Rollback();
                if (dbService.Connection.State != ConnectionState.Closed) dbService.Connection.Close();
            }

            EidssUserContext.Clear();
        }

        [TestMethod]
        public void FFPresenterWindowTest()
        {
            var session = VsSessionTest.GetTestSession();

            Assert.IsNotNull(session);
            Assert.IsTrue(session.Vectors.Count > 0);
            var vector = session.Vectors[0];
            Assert.IsNotNull(vector.FFPresenter);
            //задаём тип вектора

            var ffPresenter = new EIDSS4FF.FFPresenter(vector.FFPresenter) {Sizable = true};
            object id = null;
            ffPresenter.ShowFlexibleForm();
            BaseFormManager.ShowModal(ffPresenter, null, ref id, null, null, 500, 400);
        }
    }
}
