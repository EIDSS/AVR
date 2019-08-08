using System;
using System.Diagnostics;
using System.IO;
using bv.common;
using bv.model.Helpers;
using bv.tests.Core;
using eidss.model.Helpers;
using eidss.model.Resources;
using eidss.model.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using eidss.model.Core;
using bv.model.BLToolkit;
using bv.common.Configuration;
using System.Collections.Generic;

namespace bv.tests.db.tests
{
    [TestClass]
    public class Upload506Tests : EidssEnvWithLogin
    {
        private Upload506Master.Accessor accessor;
        private Upload506Master master;
        [TestInitialize]
        public override void MyTestInitialize()
        {
            base.MyTestInitialize();
            accessor = Upload506Master.Accessor.Instance(null);
            master = accessor.CreateNewT(manager, null);
            Assert.IsNotNull(master);
        }

        [TestCleanup]
        public override void TestCleanup()
        {
            accessor = null;
            master = null;
            base.TestCleanup();
        }

        [TestMethod]
        public void LoadExcelFileTest()
        {
            string path = PathToTestFolder.Get(TestFolders.Db) + "Data\\";



            Assert.AreEqual(Upload506MasterState.ReadyForUpload, master.GetState());

            var result = master.GetItems(path + "506FileUploadGood.xlsx");
            Assert.AreEqual(Upload506FileError.Success, result);
            Assert.AreEqual(4, master.Items.Count);
            Assert.AreEqual(Upload506MasterState.ReadyForValidation, master.GetState());
            int i = 1;
            var rand = new Random();
            foreach (var item in master.Items)
            {
                item.strCaseID = string.Format("00000{0}", i++);
                item.Resolution = rand.Next(3);
            }
            master.WriteResultToFile(path + "506FileUploadResult.xlsx");
            result = master.GetItems(path + "506FileUploadExample.xlsx");

            result = master.GetItems(path + "506FileUploadGood.xls");
            Assert.AreEqual(Upload506FileError.Success, result);
            Assert.AreEqual(4, master.Items.Count);
            Assert.AreEqual(Upload506MasterState.ReadyForValidation, master.GetState());

            foreach (var item in master.Items)
            {
                item.strCaseID = string.Format("00000{0}", i++);
                item.Resolution = rand.Next(3);
            }
            master.WriteResultToFile(path + "506FileUploadResult.xls");

            result = master.GetItems(path + "506FileUploadBadHeader1.xlsx");
            Assert.AreEqual(Upload506FileError.IvalidHeaderFormat, result);
            Assert.AreEqual(0, master.Items.Count);
            Assert.AreEqual(Upload506MasterState.HasErrors, master.GetState());
            result = master.GetItems(path + "506FileUploadBadHeader2.xlsx");
            Assert.AreEqual(Upload506FileError.IvalidHeaderFormat, result);
            Assert.AreEqual(0, master.Items.Count);
            Assert.AreEqual(Upload506MasterState.HasErrors, master.GetState());
            result = master.GetItems(path + "UnexisitngFile.xlsx");
            Assert.AreEqual(Upload506FileError.NullFile, result);
            Assert.AreEqual(Upload506MasterState.HasErrors, master.GetState());
            result = master.GetItems(path + "506FileUploadBadCellFormat.xlsx");
            master.Items[0].AddError("DISEASE", "Mandatory field in column DISEASE cannot be empty.");
            master.Items[2].AddError("ADDRESS", "Test Error1");
            master.Items[2].AddError("ADDRESS", "Test Error2");
            master.Items[0].AddError("Duplicate", "The record is a duplicate of the record in row 4.");
            master.Items[2].AddError("Duplicate", "The record is a duplicate of the record in row 2.");
            Assert.AreEqual(Upload506FileError.IncorrectDataFormat, result);
            Assert.AreEqual(4, master.Items.Count);
            Assert.AreEqual(4, master.Items[0].validationErrors.Count);
            Assert.AreEqual("SEX", master.Items[0].validationErrors[0].Item1);
            Assert.AreEqual(string.Format(EidssMessages.Get("msg506DataTypeError"), "SEX"), master.Items[0].validationErrors[0].Item2);
            Assert.AreEqual("DATEDEATH", master.Items[0].validationErrors[1].Item1);
            Assert.AreEqual(string.Format(EidssMessages.Get("msg506DataTypeError"), "DATEDEATH"), master.Items[0].validationErrors[1].Item2);
            Assert.AreEqual(1, master.Items[1].validationErrors.Count);
            Assert.AreEqual("ADDRCODE", master.Items[1].validationErrors[0].Item1);
            Assert.AreEqual(string.Format(EidssMessages.Get("msg506MaxLengthError"), "ADDRCODE"), master.Items[1].validationErrors[0].Item2);
            Assert.AreEqual(2, master.Items[2].validationErrors.Count);
            Assert.AreEqual("ADDRESS", master.Items[2].validationErrors[0].Item1);
            Assert.AreEqual("Test Error1\r\nTest Error2", master.Items[2].validationErrors[0].Item2);
            WriteErrorsToFile(path + "506FileUploadErrors.xlsx");
            result = master.GetItems(path + "506FileUploadGood.tmp");
            Assert.AreEqual(Upload506FileError.UsupportedExtension, result);
        }

        //There is the bug in npoi 2.1.3 - Writing workbook with comments to stream can be performed only ones 
        //All other writings corrupts output file adding duplicated comments to the same cell
        //This is the workaround for this bug
        private void WriteErrorsToFile(string path)
        {
            if (master.ErrorsFile != null)
                File.WriteAllBytes(path, master.ErrorsFile.ToArray());
            else
                master.WriteErrorsToFile(path);
        }
        [TestMethod]
        public void LoadExcelFilePerformanceTest()
        {
            string path = PathToTestFolder.Get(TestFolders.Db) + "Data\\";
            var timer = new PerformanceTimer("100 records loading", 0);
            var result = master.GetItems(path + "506File100records.xlsx");
            timer.Stop();
            var t = timer.Time();
            Debug.WriteLine("100 records loading time: {0}", t);
            //Assert.IsTrue(t < 0.5, "100 record loading time is {0}", t);
            timer = new PerformanceTimer("1000 records loading", 0);
            result = master.GetItems(path + "506File1000records.xlsx");
            timer.Stop();
            t = timer.Time();
            Debug.WriteLine("1000 records loading time: {0}", t);
            Assert.IsTrue(t < 1, "1000 record loading time is {0}", t);
            timer = new PerformanceTimer("10000 records loading", 0);
            result = master.GetItems(path + "506File10000records.xlsx");
            timer.Stop();
            t = timer.Time();
            Debug.WriteLine("10000 records loading time: {0}", t);
            //Assert.IsTrue(t < 10, "1000 record loading time is {0}", t);

            timer = new PerformanceTimer("20000 records loading", 0);
            result = master.GetItems(path + "506FileUploadExample.xlsx");
            timer.Stop();
            t = timer.Time();
            Debug.WriteLine("20000 records loading time: {0}", t);
            //Assert.IsTrue(t < 15, "20000 record loading time is {0}", t);
            timer = new PerformanceTimer("20000 records validation", 0);
            var validate = master.ValidateItems();
            Assert.IsFalse(validate);
            timer.Stop();
            t = timer.Time();
            Debug.WriteLine("20000 records validation time: {0}", t);
            //Assert.IsTrue(t < 10, "20000 record validation time is {0}", t);
            timer = new PerformanceTimer("20000 example records errors writing", 0);
            WriteErrorsToFile(path + "506FileUploadExampleErrors.xlsx");
            timer.Stop();
            t = timer.Time();
            Debug.WriteLine("20000 example records errors writing: {0}", t);

            timer = new PerformanceTimer("100 example records loading", 0);
            result = master.GetItems(path + "506FileUploadExample100.xlsx");
            timer.Stop();
            t = timer.Time();
            Debug.WriteLine("100 example records loading time: {0}", t);
            //Assert.IsTrue(t < 5, "100 example record loading time is {0}", t);
            timer = new PerformanceTimer("100 example records validation", 0);
            validate = master.ValidateItems();
            Assert.IsTrue(validate);
            timer.Stop();
            t = timer.Time();
            Debug.WriteLine("100 example records validation time: {0}", t);
            //Assert.IsTrue(t < 5, "100 example record validation time is {0}", t);
            timer = new PerformanceTimer("100 example records errors writing", 0);
            WriteErrorsToFile(path + "506FileUploadExample100Errors.xlsx");
            timer.Stop();
            t = timer.Time();
            Debug.WriteLine("100 example records errors writing: {0}", t);
        }

        [TestMethod]
        public void DuplicateValidationTest()
        {
            string path = PathToTestFolder.Get(TestFolders.Db) + "Data\\";
            Assert.AreEqual(Upload506MasterState.ReadyForUpload, master.GetState());
            var result = master.GetItems(path + "506FileUploadDuplicate2.xlsx");
            Assert.AreEqual(Upload506FileError.Success, result);
            Assert.AreEqual(5, master.Items.Count);
            var validated = master.ValidateItems();
            Assert.IsFalse(validated);
            Assert.AreEqual(Upload506MasterState.HasErrors, master.GetState());
            WriteErrorsToFile(path + "506FileUploadDuplicate2Errors.xlsx");

            result = master.GetItems(path + "506FileUploadDuplicate4.xlsx");
            Assert.AreEqual(Upload506FileError.Success, result);
            Assert.AreEqual(7, master.Items.Count);
            validated = master.ValidateItems();
            Assert.IsFalse(validated);
            Assert.AreEqual(Upload506MasterState.HasErrors, master.GetState());
            WriteErrorsToFile(path + "506FileUploadDuplicate4Errors.xlsx");

        }
        [TestMethod, Ignore]
        public void VisualizeIndexedColors()
        {
            string path = PathToTestFolder.Get(TestFolders.Db) + "Data\\";
            var excelFileWrapper = new ExcelFileWrapper(new HSSFWorkbook());
            var sheet = excelFileWrapper.Workbook.CreateSheet();
            for (short i = 0; i < 64; i++)
            {
                var row = sheet.CreateRow(i);
                var cell = row.CreateCell(0);
                var style = excelFileWrapper.Workbook.CreateCellStyle();
                style.FillPattern = FillPattern.SolidForeground;
                style.FillForegroundColor = i;
                cell.CellStyle = style;
                cell.SetCellValue(i);
            }
            excelFileWrapper.Save(path + "IndexedColors.xls");
        }
        [TestMethod]
        public void ExcelReaderTest()
        {
            var excelFileWrapper = new ExcelFileWrapper();
            string path = PathToTestFolder.Get(TestFolders.Db) + "Data\\";
            excelFileWrapper.Read(path + "506FileUploadGood.xlsx");
            var sheet = excelFileWrapper.Workbook.GetSheetAt(0);
            for (int rowNum = sheet.FirstRowNum; rowNum <= sheet.LastRowNum; rowNum++)
            {
                var row = sheet.GetRow(rowNum);
                excelFileWrapper.SetupErrorCell(row.Cells[rowNum], "Comment " + rowNum + "\r\nComment 2\r\nComment 3 line long long long long long long long long");
                foreach (var cell in row.Cells)
                {
                    var value = excelFileWrapper.GetCellValue(cell);
                    var str = excelFileWrapper.GetCellText(cell);
                }
                if(rowNum%2!=0)
                    excelFileWrapper.SetupErrorRow(row, "Test comment");
            }
            excelFileWrapper.Save(path + "test.xlsx");
        }

        [TestMethod]
        public void CancelTest()
        {
            master.Cancel();
            Assert.AreEqual(Upload506MasterState.Canceled, master.GetState());
        }

        [TestMethod]
        public void PostTest()
        {
            var item = Upload506Item.Accessor.Instance(null).CreateNewForTest(manager, master, 22);
            item.Resolution = (int)Upload506Resolution.Created;
            master.Items.Add(item);
            Assert.AreEqual(item.idfCase, 0);
            Assert.IsTrue(master.ValidateItems());
            Assert.IsTrue(accessor.Post(manager, master));
            Assert.AreNotEqual(item.idfCase, 0);
            HumanCase hc = HumanCase.Accessor.Instance(null).SelectByKey(manager, item.idfCase);
            Assert.IsNotNull(hc);
            Assert.AreEqual(item.idfCase, hc.idfCase);
            Assert.AreEqual(item.strCaseID, hc.strCaseID);
            Assert.AreEqual(item.iDISEASE, (int)master.DiagnosisRefs.FirstOrDefault(i => i.idfsTentativeDiagnosis == hc.idfsTentativeDiagnosis, i => i.DISEASE));
            Assert.AreEqual(item.NAME, hc.Patient.strName);
            Assert.AreEqual(item.HN, hc.strLocalIdentifier);
            Assert.AreEqual(item.SEX, (int)master.HumanGenderRefs.FirstOrDefault(i => i.idfsHumanGender == hc.Patient.idfsHumanGender, i => i.SEX));
            Assert.AreEqual(item.YEAR, hc.intPatientAge);
            Assert.AreEqual(item.MARIETAL, (int)master.MaritalStatusRefs.FirstOrDefault(
                i => i.idfsMaritalStatus == (long)hc.FFPresenterEpi.ActivityParameters[1].varValue, i => i.MARIETAL));
            Assert.AreEqual(item.RACE, (int)master.NationalityRefs.FirstOrDefault(i => i.idfsNationality == hc.Patient.idfsNationality, i => i.RACE));
            Assert.AreEqual(item.RACE1, (int)master.ForeignerTypeRefs.FirstOrDefault(
                i => i.idfsForeignerType == (long)hc.FFPresenterEpi.ActivityParameters[5].varValue, i => i.RACE1));
            Assert.AreEqual(item.OCCUPAT, (int)master.OccupationTypeRefs.FirstOrDefault(i => i.idfsOccupationType == hc.idfsOccupationType, i => i.OCCUPAT));
            Assert.AreEqual(item.ADDRESS, hc.Patient.CurrentResidenceAddress.strHouse);
            Assert.AreEqual(item.PROVINCE + item.ADDRCODE, hc.Patient.CurrentResidenceAddress.strBuilding);
            Assert.AreEqual(item.METROPOL, (int)master.MunicipalityRefs.FirstOrDefault(
                i => i.idfsMunicipality == (long)hc.FFPresenterEpi.ActivityParameters[3].varValue, i => i.METROPOL));
            Assert.AreEqual(item.HOSPITAL, (int)master.HospitalizationRefs.FirstOrDefault(
                i => i.idfsHospitalization == (long)hc.FFPresenterEpi.ActivityParameters[0].varValue, i => i.HOSPITAL));
            Assert.AreEqual(item.TYPE, (int)master.PatientTypeRefs.FirstOrDefault(
                i => i.idfsPatientType == (long)hc.FFPresenterEpi.ActivityParameters[4].varValue, i => i.TYPE));
            Assert.AreEqual(item.RESULT, (int)master.OutcomeRefs.FirstOrDefault(i => i.idfsOutcome == hc.idfsOutcome, i => i.RESULT));
            Assert.AreEqual(item.DATESICK, hc.datOnSetDate);
            Assert.AreEqual(item.DATEDEFINE, hc.datTentativeDiagnosisDate);
            Assert.AreEqual(item.DATERECORD, hc.datNotificationDate);
            Assert.AreEqual(item.DATEDEATH, hc.datDateOfDeath);
            Assert.AreEqual(item.iCOMPLICA, (int)master.ComplicationRefs.FirstOrDefault(
                i => i.idfsComplication == (long)hc.FFPresenterEpi.ActivityParameters[2].varValue, i => i.COMPLICA));

            var duplicate = Upload506Duplicate.Accessor.Instance(null).SelectByItem(manager, item);
            Assert.IsNotNull(duplicate);
            Assert.AreEqual(duplicate.strTentativeDiagnosisEIDSS, duplicate.strTentativeDiagnosis506);
            Assert.AreEqual(duplicate.strLocalIdentifierEIDSS, duplicate.strLocalIdentifier506);
            Assert.AreEqual(duplicate.strPatientNameEIDSS, duplicate.strPatientName506);
            Assert.AreEqual(duplicate.strHumanGenderEIDSS, duplicate.strHumanGender506);
            Assert.AreEqual(duplicate.datDateofBirthEIDSS, duplicate.datDateofBirth506);
            Assert.AreEqual(duplicate.intPatientAgeEIDSS, duplicate.intPatientAge506);
            Assert.AreEqual(duplicate.strHumanAgeTypeEIDSS, duplicate.strHumanAgeType506);
            Assert.AreEqual(duplicate.strNationalityEIDSS, duplicate.strNationality506);
            Assert.AreEqual(duplicate.strOccupationTypeEIDSS, duplicate.strOccupationType506);
            Assert.AreEqual(duplicate.strAddrCodeEIDSS, duplicate.strAddrCode506);
            Assert.AreEqual(duplicate.strAddressEIDSS, duplicate.strAddress506);
            Assert.AreEqual(duplicate.strRegionEIDSS, duplicate.strRegion506);
            Assert.AreEqual(duplicate.strRayonEIDSS, duplicate.strRayon506);
            Assert.AreEqual(duplicate.strSettlementEIDSS, duplicate.strSettlement506);
            Assert.AreEqual(duplicate.strTypeEIDSS, duplicate.strType506);
            Assert.AreEqual(duplicate.strOutcomeEIDSS, duplicate.strOutcome506);
            Assert.AreEqual(duplicate.strSentByOfficeEIDSS, duplicate.strSentByOffice506);
            Assert.AreEqual(duplicate.strEmployerNameEIDSS, duplicate.strEmployerName506);
            Assert.AreEqual(duplicate.datSickEIDSS, duplicate.datSick506);
            Assert.AreEqual(duplicate.datDefineEIDSS, duplicate.datDefine506);
            Assert.AreEqual(duplicate.datDeathEIDSS, duplicate.datDeath506);
            Assert.AreEqual(duplicate.datRecordEIDSS, duplicate.datRecord506);
            Assert.AreEqual(duplicate.strComplicaEIDSS, duplicate.strComplica506);
            Assert.AreEqual(duplicate.strMarietalEIDSS, duplicate.strMarietal506);
            Assert.AreEqual(duplicate.strForeignEIDSS, duplicate.strForeign506);
            Assert.AreEqual(duplicate.strMunicipalityEIDSS, duplicate.strMunicipality506);
            Assert.AreEqual(duplicate.strHospitalizationEIDSS, duplicate.strHospitalization506);

            item.NAME = "BBB CCCCCC";
            item.HN = "AAAAAA";
            item.SEX = 2;
            item.YEAR = 50;
            item.MARIETAL = 2;
            item.RACE = 6;
            item.RACE1 = 2;
            item.OCCUPAT = 2;
            item.ADDRESS = "63/98";
            item.ADDRCODE = "020902";
            item.PROVINCE = "12";
            item.METROPOL = 2;
            item.HOSPITAL = 1;
            item.TYPE = 2;
            item.RESULT = 3;
            item.HSERV = "010420";
            item.DATESICK = new DateTime(2015, 5, 11);
            item.DATEDEFINE = new DateTime(2015, 5, 13);
            item.DATERECORD = new DateTime(2015, 5, 17);
            item.COMPLICA = "2";
            item.Resolution = (int)Upload506Resolution.Updated;
            Assert.IsTrue(master.ValidateItems());
            Assert.IsTrue(accessor.Post(manager, master));
            hc = HumanCase.Accessor.Instance(null).SelectByKey(manager, item.idfCase);
            Assert.AreEqual(item.idfCase, hc.idfCase);
            Assert.AreEqual(item.strCaseID, hc.strCaseID);
            Assert.AreEqual(item.iDISEASE, (int)master.DiagnosisRefs.FirstOrDefault(i => i.idfsTentativeDiagnosis == hc.idfsTentativeDiagnosis, i => i.DISEASE));
            Assert.AreEqual(item.NAME, hc.Patient.strName);
            Assert.AreEqual(item.HN, hc.strLocalIdentifier);
            Assert.AreEqual(item.SEX, (int)master.HumanGenderRefs.FirstOrDefault(i => i.idfsHumanGender == hc.Patient.idfsHumanGender, i => i.SEX));
            Assert.AreEqual(item.YEAR, hc.intPatientAge);
            Assert.AreEqual(item.MARIETAL, (int)master.MaritalStatusRefs.FirstOrDefault(
                i => i.idfsMaritalStatus == (long)hc.FFPresenterEpi.ActivityParameters[1].varValue, i => i.MARIETAL));
            Assert.AreEqual(item.RACE, (int)master.NationalityRefs.FirstOrDefault(i => i.idfsNationality == hc.Patient.idfsNationality, i => i.RACE));
            Assert.AreEqual(item.RACE1, (int)master.ForeignerTypeRefs.FirstOrDefault(
                i => i.idfsForeignerType == (long)hc.FFPresenterEpi.ActivityParameters[5].varValue, i => i.RACE1));
            Assert.AreEqual(item.OCCUPAT, (int)master.OccupationTypeRefs.FirstOrDefault(i => i.idfsOccupationType == hc.idfsOccupationType, i => i.OCCUPAT));
            Assert.AreEqual(item.ADDRESS, hc.Patient.CurrentResidenceAddress.strHouse);
            Assert.AreEqual(item.PROVINCE + item.ADDRCODE, hc.Patient.CurrentResidenceAddress.strBuilding);
            Assert.AreEqual(item.METROPOL, (int)master.MunicipalityRefs.FirstOrDefault(
                i => i.idfsMunicipality == (long)hc.FFPresenterEpi.ActivityParameters[3].varValue, i => i.METROPOL));
            Assert.AreEqual(item.HOSPITAL, (int)master.HospitalizationRefs.FirstOrDefault(
                i => i.idfsHospitalization == (long)hc.FFPresenterEpi.ActivityParameters[0].varValue, i => i.HOSPITAL));
            Assert.AreEqual(item.TYPE, (int)master.PatientTypeRefs.FirstOrDefault(
                i => i.idfsPatientType == (long)hc.FFPresenterEpi.ActivityParameters[4].varValue, i => i.TYPE));
            Assert.AreEqual(item.RESULT, (int)master.OutcomeRefs.FirstOrDefault(i => i.idfsOutcome == hc.idfsOutcome, i => i.RESULT));
            Assert.AreEqual(item.DATESICK, hc.datOnSetDate);
            Assert.AreEqual(item.DATEDEFINE, hc.datTentativeDiagnosisDate);
            Assert.AreEqual(item.DATERECORD, hc.datNotificationDate);
            Assert.AreEqual(item.DATEDEATH, hc.datDateOfDeath);
            Assert.AreEqual(item.iCOMPLICA, (int)master.ComplicationRefs.FirstOrDefault(
                i => i.idfsComplication == (long)hc.FFPresenterEpi.ActivityParameters[2].varValue, i => i.COMPLICA));

        }

        [TestMethod]
        public void PostTest2()
        {
            var item = Upload506Item.Accessor.Instance(null).CreateNewForTest2(manager, master);
            item.Resolution = (int)Upload506Resolution.Created;
            master.Items.Add(item);
            Assert.AreEqual(item.idfCase, 0);
            Assert.IsTrue(master.ValidateItems());
            Assert.IsTrue(accessor.Post(manager, master));
            Assert.AreNotEqual(item.idfCase, 0);
            HumanCase hc = HumanCase.Accessor.Instance(null).SelectByKey(manager, item.idfCase);
            Assert.IsNotNull(hc);
            Assert.AreEqual(item.idfCase, hc.idfCase);
            Assert.AreEqual(item.strCaseID, hc.strCaseID);
            Assert.AreEqual(item.iDISEASE, (int)master.DiagnosisRefs.FirstOrDefault(i => i.idfsTentativeDiagnosis == hc.idfsTentativeDiagnosis, i => i.DISEASE));
            Assert.AreEqual(item.NAME, hc.Patient.strName);
            Assert.AreEqual(item.HN, hc.strLocalIdentifier);
            Assert.AreEqual(item.SEX, (int)master.HumanGenderRefs.FirstOrDefault(i => i.idfsHumanGender == hc.Patient.idfsHumanGender, i => i.SEX));
            Assert.AreEqual(item.YEAR, hc.intPatientAge);
            Assert.AreEqual(item.MARIETAL, (int)master.MaritalStatusRefs.FirstOrDefault(
                i => i.idfsMaritalStatus == (long)hc.FFPresenterEpi.ActivityParameters[1].varValue, i => i.MARIETAL));
            Assert.AreEqual(item.RACE, (int)master.NationalityRefs.FirstOrDefault(i => i.idfsNationality == hc.Patient.idfsNationality, i => i.RACE));
            Assert.AreEqual(item.RACE1, (int)master.ForeignerTypeRefs.FirstOrDefault(
                i => i.idfsForeignerType == (long)hc.FFPresenterEpi.ActivityParameters[5].varValue, i => i.RACE1));
            Assert.AreEqual(item.OCCUPAT, (int)master.OccupationTypeRefs.FirstOrDefault(i => i.idfsOccupationType == hc.idfsOccupationType, i => i.OCCUPAT));
            Assert.AreEqual(item.ADDRESS, hc.Patient.CurrentResidenceAddress.strHouse);
            Assert.AreEqual(item.PROVINCE + item.ADDRCODE, hc.Patient.CurrentResidenceAddress.strBuilding);
            Assert.AreEqual(item.METROPOL, (int)master.MunicipalityRefs.FirstOrDefault(
                i => i.idfsMunicipality == (long)hc.FFPresenterEpi.ActivityParameters[3].varValue, i => i.METROPOL));
            Assert.AreEqual(item.HOSPITAL, (int)master.HospitalizationRefs.FirstOrDefault(
                i => i.idfsHospitalization == (long)hc.FFPresenterEpi.ActivityParameters[0].varValue, i => i.HOSPITAL));
            Assert.AreEqual(item.TYPE, (int)master.PatientTypeRefs.FirstOrDefault(
                i => i.idfsPatientType == (long)hc.FFPresenterEpi.ActivityParameters[4].varValue, i => i.TYPE));
            Assert.AreEqual(item.RESULT, (int)master.OutcomeRefs.FirstOrDefault(i => i.idfsOutcome == hc.idfsOutcome, i => i.RESULT));
            Assert.AreEqual(item.DATESICK, hc.datOnSetDate);
            Assert.AreEqual(item.DATEDEFINE, hc.datTentativeDiagnosisDate);
            Assert.AreEqual(item.DATERECORD, hc.datNotificationDate);
            Assert.AreEqual(item.DATEDEATH, hc.datDateOfDeath);
            Assert.AreEqual(item.iCOMPLICA, (int)master.ComplicationRefs.FirstOrDefault(
                i => i.idfsComplication == (long)hc.FFPresenterEpi.ActivityParameters[2].varValue, i => i.COMPLICA));

        }

        [TestMethod]
        public void TimingTest()
        {
            // avoid impacting of first initialization time
            Upload506Item.Accessor.Instance(null).CreateNewForTest(manager, master, 71);

            int test_count = 250;
            //int start = System.Environment.TickCount & Int32.MaxValue;
            DateTime dtStart = DateTime.Now;
            for (int i = 0; i < test_count; i++)
            {
                var item = Upload506Item.Accessor.Instance(null).CreateNewForTest(manager, master, 71);
                item.Resolution = (int)Upload506Resolution.Created;
                master.Items.Add(item);
            }
            var durationCreate = DateTime.Now - dtStart;
            //int end = System.Environment.TickCount & Int32.MaxValue;
            //int durationTicks = end - start;

            dtStart = DateTime.Now;
            for (int i = 0; i < test_count; i++)
            {
                var duplicate = Upload506Duplicate.Accessor.Instance(null).SelectByItem(manager, master.Items[i]);
                if (duplicate != null)
                    master.Duplicates.Add(duplicate);
            }
            var durationDuplicateNoFound = DateTime.Now - dtStart;
            Assert.AreEqual(0, master.Duplicates.Count);

            var itemForDuplicate = Upload506Item.Accessor.Instance(null).CreateNewForTest(manager, master, 71);
            itemForDuplicate.Resolution = (int)Upload506Resolution.Created;
            itemForDuplicate.PostWithoutMaster = 1;
            Assert.IsTrue(Upload506Item.Accessor.Instance(null).Post(manager, itemForDuplicate));

            dtStart = DateTime.Now;
            for (int i = 0; i < test_count; i++)
            {
                var duplicate = Upload506Duplicate.Accessor.Instance(null).SelectByItem(manager, master.Items[i]);
                if (duplicate != null)
                    master.Duplicates.Add(duplicate);
            }
            var durationDuplicateFound = DateTime.Now - dtStart;
            Assert.AreEqual(test_count, master.Duplicates.Count);

            dtStart = DateTime.Now;
            Assert.IsTrue(accessor.Post(manager, master));
            var durationPost = DateTime.Now - dtStart;

            for (int i = 0; i < test_count; i++)
            {
                master.Items[i].Resolution = (int)Upload506Resolution.Updated;
            }

            dtStart = DateTime.Now;
            Assert.IsTrue(accessor.Post(manager, master));
            var durationPostUpdate = DateTime.Now - dtStart;

            dtStart = DateTime.Now;
        }
        //[TestMethod]
        //public void LoadMdbFileTest()
        //{
        //    string path = PathToTestFolder.Get(TestFolders.Db) + "Data\\";
        //    Assert.AreEqual(Upload506MasterState.ReadyForUpload, master.GetState());
        //    var result = master.GetItems(path + "506FileUpload_10.mdb");
        //    Assert.AreEqual(Upload506FileError.Success, result);
        //    Assert.AreEqual(10, master.Items.Count);
        //    Assert.AreEqual(Upload506MasterState.ReadyForValidation, master.GetState());
        //    bool validationResult = master.ValidateItems();
        //    Assert.AreEqual(true, validationResult);
        //    int i = 1;
        //    var rand = new Random();
        //    foreach (var item in master.Items)
        //    {
        //        item.strCaseID = string.Format("00000{0}", i++);
        //        item.Resolution = rand.Next(3);
        //    }
        //    master.WriteResultToFile(path + "506FileUpload_10_Result.xls");
        //    master.WriteErrorsToFile(path + "506FileUpload_10.xls");

        //    result = master.GetItems(path + "506FileUpload_10_Bad.mdb");
        //    Assert.AreEqual(Upload506FileError.Success, result);
        //    Assert.AreEqual(10, master.Items.Count);
        //    Assert.AreEqual(Upload506MasterState.ReadyForValidation, master.GetState());
        //    validationResult = master.ValidateItems();
        //    Assert.AreEqual(false, validationResult);
        //    master.WriteErrorsToFile(path + "506FileUpload_10_Bad.xls");
        //}
        [TestMethod]
        public void LoadDbfFileTest()
        {
            string path = PathToTestFolder.Get(TestFolders.Db) + "Data\\";
            Assert.AreEqual(Upload506MasterState.ReadyForUpload, master.GetState());
            var result = master.GetItems(path + "File506Upload17.dbf");
            Assert.AreEqual(Upload506FileError.Success, result);
            Assert.AreEqual(17, master.Items.Count);
            Assert.AreEqual(Upload506MasterState.ReadyForValidation, master.GetState());
            bool validationResult = master.ValidateItems();
            Assert.AreEqual(true, validationResult);
            int i = 1;
            var rand = new Random();
            foreach (var item in master.Items)
            {
                item.strCaseID = string.Format("00000{0}", i++);
                item.Resolution = rand.Next(3);
            }
            //master.WriteResultToFile(path + "File506Upload17Result.xls");
            if(BaseSettings.Uploading506ResultToExcel)
                master.WriteResultToFile(path + "File506Upload17Result.xls");
            else
                master.WriteResultToFile(path + "File506Upload17Result.dbf");
            result = master.GetItems(path + "File506UploadError17.dbf");
            Assert.AreEqual(Upload506FileError.Success, result);
            validationResult = master.ValidateItems();
            Assert.AreEqual(false, validationResult);
            master.WriteErrorsToFile(path + "File506UploadError17Errors.xls");

        }
        [TestMethod, Ignore]
        public void ImportFromMdbFileTest()
        {
            string path = PathToTestFolder.Get(TestFolders.Db) + "Data\\";
            long start = 1009508;
            long chunkSize = 10000;
            EidssUserContext.Init();
            DbManagerFactory.SetSqlFactory(bv.common.Configuration.Config.GetSetting("EidssConnectionString"));
            for (long i = start; i < 1009509; i += chunkSize)
            {
                var timer = new PerformanceTimer("mdb records loading", 0);
                using (var _manager = DbManagerFactory.Factory.Create(EidssUserContext.Instance))
                {   
                    var _accessor = Upload506Master.Accessor.Instance(null);
                    var _master = _accessor.CreateNewT(_manager, null);
                    var result = _master.GetItems(path + "Cddata.mdb", i, chunkSize);
                    timer.Stop();
                    Debug.WriteLine("records from {0} to {1} loading time:{2}", i, i + chunkSize, timer.Time());
                    timer = new PerformanceTimer("set item resolution", 0);
                    foreach (var item in _master.Items)
                        item.Resolution = (int)Upload506Resolution.Created;
                    timer.Stop();
                    Debug.WriteLine("set item resolution time:{0}", timer.Time());

                    Assert.AreEqual(Upload506FileError.Success, result);
                    Assert.AreEqual(chunkSize, _master.Items.Count);
                    Assert.AreEqual(Upload506MasterState.ReadyForValidation, _master.GetState());
                    timer = new PerformanceTimer("post", 0);
                    Assert.IsTrue(_accessor.Post(_manager, _master));
                    timer.Stop();
                    Debug.WriteLine("records from {0} to {1} posting time:{2}", i, i + chunkSize, timer.Time());
                }

            }
            EidssUserContext.Clear();

        }

        [TestMethod]
        public void DbfLibTest()
        {
            string path = PathToTestFolder.Get(TestFolders.Db) + "Data\\";
            var file = new FlatDatabase.DBase.File();
            var output = new FlatDatabase.DBase.File();
            if (file.Open(path + "File506Upload17.dbf", System.IO.FileMode.Open))
            {
                var out_columns = new List<FlatDatabase.ColumnInfo>(file.Columns);
                out_columns.Add(new FlatDatabase.ColumnInfo(){ Name="caseid", DataType=typeof(string), Length=20 });
                out_columns.Add(new FlatDatabase.ColumnInfo(){ Name="status", DataType=typeof(string), Length=20 });

                output.Create(path + "File506Upload17_out.dbf", out_columns);
                string str = string.Empty;

                int i = 0;
                foreach (FlatDatabase.ColumnInfo col in file.Columns)
                {
                    if (0 != i++) str += "\t";
                    str += col.Name;
                }
                Console.WriteLine(str);

                for (file.Position = 0; file.Position < file.RecordCount; file.Position++)
                {
                    str = string.Empty;
                    i = 0;
                    output.AppendRecord();
                    for (i=0; i<file.Columns.Count;i++)
                    {
                        var col = file.Columns[i];
                        if (0 != i) str += "\t";
                        var value = file.GetData(col);
                        output.WriteField(output.Columns[i], file.GetString(col));
                        str += file.GetString(col);
                        //break;
                    }
                    output.WriteField(output.Columns[i++], "Case" );
                    output.WriteField(output.Columns[i], "status");
                    output.SaveRecord();
                    Console.WriteLine("{0,5} {1}", file.Position, str);
                    //break;
                }

                file.Close();
                output.Close();
            }
        }

    }
}
