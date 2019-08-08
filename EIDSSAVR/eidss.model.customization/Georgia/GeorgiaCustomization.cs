using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using bv.common.Configuration;
using eidss.model.customization.Core;
using eidss.model.Core;
using System.ServiceModel;
using System.Net;
using eidss.model.Enums;
using bv.model.BLToolkit;
using bv.model.Model.Core;
using bv.common.Core;
using eidss.model.Model;
using System.Configuration;
using eidss.model.customization.Proxies;
using Hmis.Contracts.Common.Enums;
using System.Globalization;

namespace eidss.model.customization.Georgia
{
    class GeorgiaCustomization : BaseCustomization
    {
        public override PersonIdentityServiceFeatures PersonIdentityServiceFeatures
        {
            get
            {
                return new PersonIdentityServiceFeatures()
                {
                    IsAvailable = true,
                    IsOnHumanCase = false,
                    IsOnPatient = false,
                    IsOnHumanCasePatient = true,
                    IsOnContactedPerson = true,
                    ButtonResId = "btTitleFindInPersonIdentityServiceGG",
                };
            }
        }

        public override VisibilityFeatures VisibilityFeatures
        {
            get
            {
                return new VisibilityFeatures()
                {
                    IsPersonIDBeforeName = true,
                    IsHumanCaseSampleMainTestVisible = true,
                    IsHerdEpiControlMeasuresVisible = true,
                    IsLastNameBeforeFirstName = true,
                    IsOnlyHouseUseInAddress = false,
                };
            }
        }

        public override Tuple<Schema.Patient, string> GetFromPersonIdentityService(Schema.Patient p)
        {
            //for (int i = 0; i < 3; i++)
            //{
            try
            {
                if (p.strPersonID.Length != 11 || p.strPersonID.Any(c => !Char.IsDigit(c)))
                    return new Tuple<Schema.Patient, string>(null, "strPinWrongFormat");

                if (!p.datDateofBirth.HasValue)
                    return new Tuple<Schema.Patient, string>(null, "strPinDOB");

                var ret = _getFromPersonIdentityServiceInternal(p);
                return ret;
                /*if (ret == null)
                    return new Tuple<Schema.Patient, string>(null, "strPinNoRecordsFound");

                return new Tuple<Schema.Patient, string>(ret, null);*/
            }
            catch (Exception ex)
            {
                string e = ex.Message;
            }
            //}

            //using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            //{
            //}

            return new Tuple<Schema.Patient, string>(null, "strPinNotResponding");

        }

        //private Tuple<Schema.Patient, string> _getFromPersonIdentityServiceInternal(Schema.Patient p)
        //{
        //    string pin = p.strPersonID;
        //    string form = p.Parent is Schema.HumanCase ? "H02" : "H04";
        //    string caseID = p.Parent is Schema.HumanCase ? 
        //        (p.Parent as Schema.HumanCase).strCaseID : 
        //        (p.Parent is Schema.ContactedCasePerson ? 
        //            ((p.Parent as Schema.ContactedCasePerson).Parent as Schema.HumanCase).strCaseID : 
        //            "");
        //    DateTime? dtResponse = null;
        //    string resultCode = "";

        //    var userName = ConfigurationManager.AppSettings["UserName"];
        //    var password = ConfigurationManager.AppSettings["Password"];
        //    var moduleID = Guid.Parse(ConfigurationManager.AppSettings["ModuleID"]);

        //    var token = HmisProxy.Login(userName, password, false);

        //    try
        //    {
        //        if(token != null)
        //        {
        //            var person = HmisProxy.GetPersonInfo(token.Value, moduleID, p.strPersonID);

        //            if (person != null)
        //            {
        //                resultCode = "OK";
        //                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
        //                {
        //                    FilterParams filters = new FilterParams();
        //                    filters.Add("strPersonID", "=", p.strPersonID);
        //                    var items = Schema.PatientListItem.Accessor.Instance(null).SelectListT(manager, filters);
        //                    if (items != null && items.Count == 1)
        //                    {
        //                        var proot = Schema.Patient.Accessor.Instance(null).SelectByKey(manager, items[0].idfHumanActual);
        //                        p = proot;
        //                    }
        //                }

        //                p.PersonIDType = p.PersonIDTypeLookup.FirstOrDefault(i => i.idfsBaseReference == (long)PersonalIDType.PIN_GG);
        //                p.strPersonID = person.PersonalID;
        //                p.strFirstName = person.FirstName;
        //                p.strLastName = person.LastName;
        //                p.datDateofBirth = person.BirthDate;
        //                p.Gender = p.GenderLookup.FirstOrDefault(c => c.idfsBaseReference == (person.Gender.Equals(PersonGendersEnum.Male) ? (long)GenderType.Male : (person.Gender.Equals(PersonGendersEnum.Female) ? (long)GenderType.Female : 0)));
        //                p.bPINMode = true;
        //                dtResponse = DateTime.Now;
        //                return new Tuple<Schema.Patient, string>(p, null);
        //            }
        //            else
        //            {
        //                resultCode = "NO_RECORDS_FOUND";
        //                return new Tuple<Schema.Patient, string>(p, "strPinNoRecordsFound");
        //            }                    
        //        }
        //        else
        //        {
        //            resultCode = "INVALID_TOKEN";
        //            return new Tuple<Schema.Patient, string>(null, "User name or password is wrong!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError.Log("ErrorLog_PinService_", ex, stream =>
        //        {
        //            stream.WriteLine(String.Format("PIN = {0}, Form = {1}, CaseID = {2}, UserID = {3}, UserName = {4}, UserOrganization = {5}, EIDSSDateTime = {6}, PINServiceDateTime = {7}, Result = {8}",
        //                pin, form, caseID, 
        //                EidssUserContext.Instance.CurrentUser.LoginName, 
        //                EidssUserContext.Instance.CurrentUser.FullName, 
        //                EidssUserContext.Instance.CurrentUser.OrganizationEng, 
        //                DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
        //                dtResponse.HasValue ? dtResponse.Value.ToString("yyyy-MM-ddTHH:mm:ss") : "",
        //                resultCode
        //                ));
        //        });
        //        throw;
        //    }
        //    finally
        //    {
        //        LogError.Log("Log_PinService_", null, stream =>
        //        {
        //            stream.WriteLine(String.Format("PIN = {0}, form = {1}, CaseID = {2}, UserID = {3}, UserName = {4}, UserOrganization = {5}, EIDSSDateTime = {6}, PINServiceDateTime = {7}, Result = {8}",
        //                pin, form, caseID,
        //                EidssUserContext.Instance.CurrentUser.LoginName,
        //                EidssUserContext.Instance.CurrentUser.FullName,
        //                EidssUserContext.Instance.CurrentUser.OrganizationEng,
        //                DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
        //                dtResponse.HasValue ? dtResponse.Value.ToString("yyyy-MM-ddTHH:mm:ss") : "",
        //                resultCode
        //                ));
        //        }, "{0}{3}.txt");
        //    }

        //}

        private Tuple<Schema.Patient, string> _getFromPersonIdentityServiceInternal(Schema.Patient p)
        {
            string pin = p.strPersonID;
            var username = ConfigurationManager.AppSettings["UserName"];
            var password = ConfigurationManager.AppSettings["Password"];
            string form = p.Parent is Schema.HumanCase ? "H02" : "H04";
            string caseID = p.Parent is Schema.HumanCase ?
                (p.Parent as Schema.HumanCase).strCaseID :
                (p.Parent is Schema.ContactedCasePerson ?
                    ((p.Parent as Schema.ContactedCasePerson).Parent as Schema.HumanCase).strCaseID :
                    "");
            DateTime? dtResponse = null;
            string resultCode = "";

            try
            {
                Georgia.CommonDataWebSoapClient client = new CommonDataWebSoapClient();
                var token = client.Login(username, password);
                if (token == null)
                    throw new Exception("User name or Password is incorrect");

                var person = client.GetPersonInfoEx(token.Value, Guid.Empty, p.strPersonID, p.datDateofBirth.Value.Year);

                if (person != null)
                {
                    resultCode = "OK";
                    using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                    {
                        FilterParams filters = new FilterParams();
                        filters.Add("strPersonID", "=", p.strPersonID);
                        var items = Schema.PatientListItem.Accessor.Instance(null).SelectListT(manager, filters);
                        if (items != null && items.Count == 1)
                        {
                            var proot = Schema.Patient.Accessor.Instance(null).SelectByKey(manager, items[0].idfHumanActual);
                            p = proot;
                        }
                    }

                    DateTime xx;

                    if (DateTime.TryParseExact(person.BirthDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out xx))
                    {
                        p.PersonIDType = p.PersonIDTypeLookup.FirstOrDefault(i => i.idfsBaseReference == (long)PersonalIDType.PIN_GG);
                        p.strPersonID = person.PrivateNumber; //person.PersonalID;
                        p.strFirstName = person.FirstName;
                        p.strLastName = person.LastName;
                        p.datDateofBirth = xx; //person.BirthDate;
                        p.Gender = p.GenderLookup.FirstOrDefault(c => c.idfsBaseReference == (person.GenderID.Equals("1") ? (long)GenderType.Male : (person.GenderID.Equals("2") ? (long)GenderType.Female : 0)));
                        p.bPINMode = true;
                        dtResponse = DateTime.Now;
                        return new Tuple<Schema.Patient, string>(p, null);
                    }
                    else
                    {
                        p.PersonIDType = p.PersonIDTypeLookup.FirstOrDefault(i => i.idfsBaseReference == (long)PersonalIDType.PIN_GG);
                        p.strPersonID = person.PrivateNumber; //person.PersonalID;
                        p.strFirstName = person.FirstName;
                        p.strLastName = person.LastName;
                        p.Gender = p.GenderLookup.FirstOrDefault(c => c.idfsBaseReference == (person.GenderID.Equals(PersonGendersEnum.Male) ? (long)GenderType.Male : (person.GenderID.Equals(PersonGendersEnum.Female) ? (long)GenderType.Female : 0)));
                        p.bPINMode = true;
                        dtResponse = DateTime.Now;
                        return new Tuple<Schema.Patient, string>(p, null);
                    }
                    
                }
                else
                {
                    resultCode = "NO_RECORDS_FOUND";
                    return new Tuple<Schema.Patient, string>(null, "strPinNoRecordsFound");
                }
            }
            catch (Exception ex)
            {
                LogError.Log("ErrorLog_PinService_", ex, stream =>
                {
                    stream.WriteLine(String.Format("PIN = {0}, Form = {1}, CaseID = {2}, UserID = {3}, UserName = {4}, UserOrganization = {5}, EIDSSDateTime = {6}, PINServiceDateTime = {7}, Result = {8}",
                        pin, form, caseID,
                        EidssUserContext.Instance.CurrentUser.LoginName,
                        EidssUserContext.Instance.CurrentUser.FullName,
                        EidssUserContext.Instance.CurrentUser.OrganizationEng,
                        DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                        dtResponse.HasValue ? dtResponse.Value.ToString("yyyy-MM-ddTHH:mm:ss") : "",
                        resultCode
                        ));
                });
                throw;
            }
            finally
            {
                if (client != null && client.State != System.ServiceModel.CommunicationState.Closed)
                    client.Close();

                LogError.Log("Log_PinService_", null, stream =>
                {
                    stream.WriteLine(String.Format("PIN = {0}, form = {1}, CaseID = {2}, UserID = {3}, UserName = {4}, UserOrganization = {5}, EIDSSDateTime = {6}, PINServiceDateTime = {7}, Result = {8}",
                        pin, form, caseID,
                        EidssUserContext.Instance.CurrentUser.LoginName,
                        EidssUserContext.Instance.CurrentUser.FullName,
                        EidssUserContext.Instance.CurrentUser.OrganizationEng,
                        DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                        dtResponse.HasValue ? dtResponse.Value.ToString("yyyy-MM-ddTHH:mm:ss") : "",
                        resultCode
                        ));
                }, "{0}{3}.txt");
            }

        }
    }
}
