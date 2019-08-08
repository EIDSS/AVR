using System;
using System.Linq;
using bv.common.Core;
using bv.common.Configuration;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.model.Helpers;
using eidss.model.Enums;
using eidss.model.Resources;
using System.Collections.Generic;
using System.Text;

namespace eidss.model.Schema
{

    public enum Upload506Resolution
    {
        Updated = 0,
        Created = 1,
        Dismissed = 2
    }
    public partial class Upload506Item
    {
        public int ItemHash { get; set; }
        private Dictionary<string, object> m_RawValues = new Dictionary<string,object>();
        public Dictionary<string, object> RawValues { get { return m_RawValues; } }
        public void AddError(string colCaption, string error)
        {
            var err = validationErrors.FirstOrDefault(i => i.Item1 == colCaption);
            if(err !=null)
            {
                error = err.Item2 + "\r\n" + error;
                validationErrors.Remove(err);
            }
            validationErrors.Add(new Tuple<string, string>(colCaption, error));

        }
        public bool ValidateItem(string HSERVmaster)
        {
            try
            {
                var master = this.Parent as Upload506Master;
                validationErrors.Clear();

                if (iCOMPLICA.HasValue && iCOMPLICA.Value == 0)
                    COMPLICA = null;

                // step 3
                validateMandatory(DISEASE, "DISEASE");
                validateMandatory(NAME, "NAME");
                validateMandatory(SEX, "SEX");
                //validateMandatory(MARIETAL, "MARIETAL");
                validateMandatory(RACE, "RACE");
                //validateMandatory(RACE1, "RACE1");
                //validateMandatory(OCCUPAT, "OCCUPAT");
                validateMandatory(ADDRCODE, "ADDRCODE");
                validateMandatory(PROVINCE, "PROVINCE");
                //validateMandatory(METROPOL, "METROPOL");
                //validateMandatory(HOSPITAL, "HOSPITAL");
                //validateMandatory(TYPE, "TYPE");
                //validateMandatory(RESULT, "RESULT");
                validateMandatory(HSERV, "HSERV");
                //validateMandatory(CLASS, "CLASS");
                //validateMandatory(ORGANISM, "ORGANISM");
                //validateMandatory(COMPLICA, "COMPLICA", () => DISEASE.HasValue && (DISEASE.Value == 71 || DISEASE.Value == 22));
                validateMandatory(DATESICK, "DATESICK");
                validateMandatory(DATERECORD, "DATERECORD");
                validateMandatory(DATEDEFINE, "DATEDEFINE");

                // step 4
                validateRef(SEX, "SEX", () => master.HumanGenderRefs.Any(i => i.SEX == SEX));
                validateRef(RACE, "RACE", () => master.NationalityRefs.Any(i => i.RACE == RACE));
                validateRef(OCCUPAT, "OCCUPAT", () => master.OccupationTypeRefs.Any(i => i.OCCUPAT == OCCUPAT));
                validateRef(RESULT, "RESULT", () => master.OutcomeRefs.Any(i => i.RESULT == RESULT));
                validateRef(DISEASE, "DISEASE", () => master.DiagnosisRefs.Any(i => i.DISEASE == iDISEASE));
                validateRef(MARIETAL, "MARIETAL", () => master.MaritalStatusRefs.Any(i => i.MARIETAL == MARIETAL));
                validateRef(RACE1, "RACE1", () => master.ForeignerTypeRefs.Any(i => i.RACE1 == RACE1));
                validateRef(METROPOL, "METROPOL", () => master.MunicipalityRefs.Any(i => i.METROPOL == METROPOL));
                validateRef(HOSPITAL, "HOSPITAL", () => master.HospitalizationRefs.Any(i => i.HOSPITAL == HOSPITAL));
                validateRef(TYPE, "TYPE", () => master.PatientTypeRefs.Any(i => i.TYPE == TYPE));
                validateRef(COMPLICA, "COMPLICA", () => master.ComplicationRefs.Any(i => i.COMPLICA == iCOMPLICA && i.DISEASE == iDISEASE));

                // step 5
                DateTime dateOfBirth = DATERECORD.HasValue ? (DATERECORD.Value
                    .AddYears(YEAR.HasValue ? -YEAR.Value : 0)
                    .AddMonths(MONTH.HasValue ? -MONTH.Value : 0)
                    .AddDays(DAY.HasValue ? -DAY.Value : 0))
                        : DateTime.Today;
                if (DATESICK.HasValue && dateOfBirth > DATESICK)
                    AddError("DATESICK", String.Format(EidssMessages.Get("msg506DateBusinessRuleFailed"), "DATESICK"));
                if (DATESICK.HasValue && (DATESICK > DateTime.Today))
                    AddError("DATESICK", String.Format(EidssMessages.Get("msg506DateBusinessRuleFailed"), "DATESICK"));
                if (DATESICK.HasValue && DATEDEFINE.HasValue && (DATESICK > DATEDEFINE || dateOfBirth > DATEDEFINE))
                    AddError("DATEDEFINE", String.Format(EidssMessages.Get("msg506DateBusinessRuleFailed"), "DATEDEFINE"));
                if (DATEDEFINE.HasValue && DATERECORD.HasValue && (DATEDEFINE > DATERECORD || dateOfBirth > DATERECORD))
                    AddError("DATERECORD", String.Format(EidssMessages.Get("msg506DateBusinessRuleFailed"), "DATERECORD"));
                if (DATEDEFINE.HasValue && (DATEDEFINE > DateTime.Today))
                    AddError("DATEDEFINE", String.Format(EidssMessages.Get("msg506DateBusinessRuleFailed"), "DATEDEFINE"));
                /*if (DATERECORD.HasValue && DATEREACH.HasValue && (DATERECORD > DATEREACH || dateOfBirth > DATEREACH))
                   AddError(("DATEREACH", String.Format(EidssMessages.Get("msg506DateBusinessRuleFailed"), "DATEREACH")));
                if (DATEREACH.HasValue && (DATEREACH > DateTime.Today))
                   AddError(("DATEREACH", String.Format(EidssMessages.Get("msg506DateBusinessRuleFailed"), "DATEREACH")));*/
                if (DATERECORD.HasValue && (DATERECORD > DateTime.Today))
                    AddError("DATERECORD", String.Format(EidssMessages.Get("msg506DateBusinessRuleFailed"), "DATERECORD"));

                if (DATEDEATH.HasValue && dateOfBirth > DATEDEATH)
                    AddError("DATEDEATH", String.Format(EidssMessages.Get("msg506DateBusinessRuleFailed"), "DATEDEATH"));
                if (DATEDEATH.HasValue && (DATEDEATH > DateTime.Today))
                    AddError("DATEDEATH", String.Format(EidssMessages.Get("msg506DateBusinessRuleFailed"), "DATEDEATH"));

                // step 6
                if (DATEDEATH.HasValue && (!RESULT.HasValue || (RESULT.HasValue && RESULT.Value != 2)))
                    AddError("DATEDEATH", EidssMessages.Get("msg506DATEDEATH"));

                //if (!DATEDEATH.HasValue && (!RESULT.HasValue || (RESULT.HasValue && RESULT.Value == 2)))
                //    AddError("DATEDEATH", EidssMessages.Get("msg506DATEDEATH"));
                // step 7
                if (iDISEASE != 71 && iDISEASE != 22 && iCOMPLICA.HasValue)
                    AddError("COMPLICA", EidssMessages.Get("msg506COMPLICA"));

                // step 8
                //for (int i = 0; i < master.Items.Count; i++)
                //{
                //    var checkItem = master.Items[i];
                //    if (!checkItem.Equals(this))
                //    {
                //        if (String.Compare(NAME, checkItem.NAME) == 0
                //            && DISEASE == checkItem.DISEASE
                //            && String.Compare(HSERV, checkItem.HSERV) == 0
                //            && DATEDEFINE.HasValue && checkItem.DATEDEFINE.HasValue 
                //                && Math.Abs((DATEDEFINE - checkItem.DATEDEFINE).ValueOrDefault().Days) <= 30
                //            )
                //        {
                //           AddError("Duplicate", String.Format(EidssMessages.Get("msg506RecordIsDuplicate"), i+1));
                //        }
                //    }
                //}

                // step 9
                if (BaseSettings.Uploading506HSERVUnique && String.Compare(HSERV, HSERVmaster) != 0)
                    AddError("HSERV", EidssMessages.Get("msg506HSERV"));

                return validationErrors.Count == 0;
            }
            catch(Exception ex)
            {
                string e = ex.Message;
                throw;
            }
        }

        private void validateMandatory(DateTime? val, string name)
        {
            if (!val.HasValue)
                AddError(name, String.Format(EidssMessages.Get("msg506MandatoryField"), name));
        }
        private void validateMandatory(int? val, string name)
        {
            if (!val.HasValue || val.Value == 0)
               AddError(name, String.Format(EidssMessages.Get("msg506MandatoryField"), name));
        }
        private void validateMandatory(int? val, string name, Func<bool> predicate)
        {
            if ((!val.HasValue || val.Value == 0) && predicate())
                AddError(name, String.Format(EidssMessages.Get("msg506MandatoryField"), name));
        }
        private void validateMandatory(string val, string name)
        {
            if (String.IsNullOrEmpty(val))
               AddError(name, String.Format(EidssMessages.Get("msg506MandatoryField"), name));
        }

        private void validateRef(int? val, string name, Func<bool> predicate)
        {
            try
            {
                if (val.HasValue && val.Value != 0 && !predicate())
                    AddError(name, String.Format(EidssMessages.Get("msg506UnknownReferenceValue"), name));
            }
            catch(Exception ex)
            {
                string e = ex.Message;
                throw;
            }
        }
        private void validateRef(string val, string name, Func<bool> predicate)
        {
            if (!String.IsNullOrEmpty(val) && !predicate())
               AddError(name, String.Format(EidssMessages.Get("msg506UnknownReferenceValue"), name));
        }

        public partial class Accessor
        {
            public Upload506Item CreateNewForTest(DbManagerProxy manager, IObject Parent, int disease)
            {
                var item = CreateNewT(manager, Parent);
                item.E0 = 3;
                item.E1 = 2;
                item.PE0 = 2159;
                item.PE1 = 1494;
                item.DISEASE = disease.ToString();
                item.HN = "5822879";
                item.NAME = "A CHUIH";
                item.SEX = 1;
                item.YEAR = 57;
                item.MONTH = 0;
                item.DAY = 0;
                item.MARIETAL = 1;
                item.RACE = 7;
                item.RACE1 = 1;
                item.OCCUPAT = 3;
                item.ADDRESS = "64/99";
                item.ADDRCODE = "010801";
                item.PROVINCE = "12";
                item.METROPOL = 1;
                item.HOSPITAL = 2;
                item.TYPE = 1;
                item.RESULT = 4;
                item.HSERV = "010420";
                item.DATESICK = new DateTime(2015, 6, 12);
                item.DATEDEFINE = new DateTime(2015, 6, 14);
                item.DATERECORD = new DateTime(2015, 6, 18);
                //item.DATEREACH = new DateTime(2015, 6, 18);
                //item.ORGANISM = 0;
                item.COMPLICA = "1";
                return item;
            }

            public Upload506Item CreateNewForTest2(DbManagerProxy manager, IObject Parent)
            {
                var item = CreateNewT(manager, Parent);
                item.E0 = 1;
                item.E1 = 1;
                item.PE0 = null;
                item.PE1 = null;
                item.DISEASE = "22";
                item.HN = "1194421";
                item.NAME = "ไพลิน รักษพันธ์";
                item.SEX = 2;
                item.YEAR = 17;
                item.MONTH = 2;
                item.DAY = 2;
                item.MARIETAL = 1;
                item.RACE = 1;
                item.RACE1 = 1;
                item.OCCUPAT = 3;
                item.ADDRESS = "30/15";
                item.ADDRCODE = "010309";
                item.PROVINCE = "12";
                item.METROPOL = 1;
                item.HOSPITAL = 2;
                item.TYPE = 1;
                item.RESULT = 1;
                item.HSERV = "010420";
                item.DATESICK = new DateTime(2015, 4, 24);
                item.DATEDEFINE = new DateTime(2015, 4, 27);
                item.DATERECORD = new DateTime(2015, 5, 4);
                //item.DATEREACH = new DateTime(2015, 6, 18);
                //item.ORGANISM = 0;
                item.COMPLICA = "1";
                return item;
            }

        }

    }
}
