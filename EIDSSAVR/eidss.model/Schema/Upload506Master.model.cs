#pragma warning disable 0472,0414
using System;
using System.Text;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Xml.Serialization;
using BLToolkit.Aspects;
using BLToolkit.DataAccess;
using BLToolkit.EditableObjects;
using BLToolkit.Data;
using BLToolkit.Data.DataProvider;
using BLToolkit.Mapping;
using BLToolkit.Reflection;
using bv.common.Configuration;
using bv.common.Enums;
using bv.common.Core;
using bv.model.BLToolkit;
using bv.model.Model;
using bv.model.Helpers;
using bv.model.Model.Extenders;
using bv.model.Model.Core;
using bv.model.Model.Handlers;
using bv.model.Model.Validators;
using eidss.model.Core;
using eidss.model.Enums;
		

namespace eidss.model.Schema
{
        
        
    [XmlType(AnonymousType = true)]
    public abstract partial class Upload506Master : 
        EditableObject<Upload506Master>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsUpload506), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsUpload506 { get; set; }
                
        [LocalizedDisplayName(_str_idfPersonEnteredBy)]
        [MapField(_str_idfPersonEnteredBy)]
        public abstract Int64? idfPersonEnteredBy { get; set; }
        protected Int64? idfPersonEnteredBy_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPersonEnteredBy).OriginalValue; } }
        protected Int64? idfPersonEnteredBy_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfPersonEnteredBy).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfUserID)]
        [MapField(_str_idfUserID)]
        public abstract Int64? idfUserID { get; set; }
        protected Int64? idfUserID_Original { get { return ((EditableValue<Int64?>)((dynamic)this)._idfUserID).OriginalValue; } }
        protected Int64? idfUserID_Previous { get { return ((EditableValue<Int64?>)((dynamic)this)._idfUserID).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<Upload506Master, object> _get_func;
            internal Action<Upload506Master, string> _set_func;
            internal Action<Upload506Master, Upload506Master, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsUpload506 = "idfsUpload506";
        internal const string _str_idfPersonEnteredBy = "idfPersonEnteredBy";
        internal const string _str_idfUserID = "idfUserID";
        internal const string _str_FileName = "FileName";
        internal const string _str_FileContent = "FileContent";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_intDummy = "intDummy";
        internal const string _str_Diagnosis = "Diagnosis";
        internal const string _str_Items = "Items";
        internal const string _str_Duplicates = "Duplicates";
        internal const string _str_HumanGenderRefs = "HumanGenderRefs";
        internal const string _str_NationalityRefs = "NationalityRefs";
        internal const string _str_OccupationTypeRefs = "OccupationTypeRefs";
        internal const string _str_OutcomeRefs = "OutcomeRefs";
        internal const string _str_DiagnosisRefs = "DiagnosisRefs";
        internal const string _str_MaritalStatusRefs = "MaritalStatusRefs";
        internal const string _str_ForeignerTypeRefs = "ForeignerTypeRefs";
        internal const string _str_MunicipalityRefs = "MunicipalityRefs";
        internal const string _str_HospitalizationRefs = "HospitalizationRefs";
        internal const string _str_PatientTypeRefs = "PatientTypeRefs";
        internal const string _str_ComplicationRefs = "ComplicationRefs";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsUpload506, _formname = _str_idfsUpload506, _type = "Int64",
              _get_func = o => o.idfsUpload506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsUpload506 != newval) o.idfsUpload506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsUpload506 != c.idfsUpload506 || o.IsRIRPropChanged(_str_idfsUpload506, c)) 
                  m.Add(_str_idfsUpload506, o.ObjectIdent + _str_idfsUpload506, o.ObjectIdent2 + _str_idfsUpload506, o.ObjectIdent3 + _str_idfsUpload506, "Int64", 
                    o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(),                  
                  o.IsReadOnly(_str_idfsUpload506), o.IsInvisible(_str_idfsUpload506), o.IsRequired(_str_idfsUpload506)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfPersonEnteredBy, _formname = _str_idfPersonEnteredBy, _type = "Int64?",
              _get_func = o => o.idfPersonEnteredBy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfPersonEnteredBy != newval) o.idfPersonEnteredBy = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfPersonEnteredBy != c.idfPersonEnteredBy || o.IsRIRPropChanged(_str_idfPersonEnteredBy, c)) 
                  m.Add(_str_idfPersonEnteredBy, o.ObjectIdent + _str_idfPersonEnteredBy, o.ObjectIdent2 + _str_idfPersonEnteredBy, o.ObjectIdent3 + _str_idfPersonEnteredBy, "Int64?", 
                    o.idfPersonEnteredBy == null ? "" : o.idfPersonEnteredBy.ToString(),                  
                  o.IsReadOnly(_str_idfPersonEnteredBy), o.IsInvisible(_str_idfPersonEnteredBy), o.IsRequired(_str_idfPersonEnteredBy)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfUserID, _formname = _str_idfUserID, _type = "Int64?",
              _get_func = o => o.idfUserID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfUserID != newval) o.idfUserID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfUserID != c.idfUserID || o.IsRIRPropChanged(_str_idfUserID, c)) 
                  m.Add(_str_idfUserID, o.ObjectIdent + _str_idfUserID, o.ObjectIdent2 + _str_idfUserID, o.ObjectIdent3 + _str_idfUserID, "Int64?", 
                    o.idfUserID == null ? "" : o.idfUserID.ToString(),                  
                  o.IsReadOnly(_str_idfUserID), o.IsInvisible(_str_idfUserID), o.IsRequired(_str_idfUserID)); 
                  }
              }, 
        
            new field_info {
              _name = _str_FileName, _formname = _str_FileName, _type = "string",
              _get_func = o => o.FileName,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.FileName != newval) o.FileName = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.FileName != c.FileName || o.IsRIRPropChanged(_str_FileName, c)) {
                  m.Add(_str_FileName, o.ObjectIdent + _str_FileName, o.ObjectIdent2 + _str_FileName, o.ObjectIdent3 + _str_FileName,  "string", 
                    o.FileName == null ? "" : o.FileName.ToString(),                  
                    o.IsReadOnly(_str_FileName), o.IsInvisible(_str_FileName), o.IsRequired(_str_FileName));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_FileContent, _formname = _str_FileContent, _type = "byte[]",
              _get_func = o => o.FileContent,
              _set_func = (o, val) => { var newval = o.FileContent; if (o.FileContent != newval) o.FileContent = newval; },
              _compare_func = (o, c, m, g) => {
               }
              }, 
        
            new field_info {
              _name = _str_intDummy, _formname = _str_intDummy, _type = "int",
              _get_func = o => o.intDummy,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.intDummy != newval) o.intDummy = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.intDummy != c.intDummy || o.IsRIRPropChanged(_str_intDummy, c)) {
                  m.Add(_str_intDummy, o.ObjectIdent + _str_intDummy, o.ObjectIdent2 + _str_intDummy, o.ObjectIdent3 + _str_intDummy,  "int", 
                    o.intDummy == null ? "" : o.intDummy.ToString(),                  
                    o.IsReadOnly(_str_intDummy), o.IsInvisible(_str_intDummy), o.IsRequired(_str_intDummy));
                  }
                 }
              }, 
        
            new field_info {
              _name = _str_idfsDiagnosis, _formname = _str_idfsDiagnosis, _type = "long?",
              _get_func = o => o.idfsDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64Nullable(val); if (o.idfsDiagnosis != newval) o.idfsDiagnosis = newval;  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_idfsDiagnosis, c)) {
                  m.Add(_str_idfsDiagnosis, o.ObjectIdent + _str_idfsDiagnosis, o.ObjectIdent2 + _str_idfsDiagnosis, o.ObjectIdent3 + _str_idfsDiagnosis, "long?", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_idfsDiagnosis), o.IsInvisible(_str_idfsDiagnosis), o.IsRequired(_str_idfsDiagnosis));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_Diagnosis, _formname = _str_Diagnosis, _type = "Lookup",
              _get_func = o => { if (o.Diagnosis == null) return null; return o.Diagnosis.idfsDiagnosis; },
              _set_func = (o, val) => { o.Diagnosis = o.DiagnosisLookup.Where(c => c.idfsDiagnosis.ToString() == val).SingleOrDefault(); },
              _compare_func = (o, c, m, g) => {
                bool bChangeLookupContent = o.IsLookupContentChanged(g, _str_Diagnosis, c);
                if (o.idfsDiagnosis != c.idfsDiagnosis || o.IsRIRPropChanged(_str_Diagnosis, c) || bChangeLookupContent) {
                  m.Add(_str_Diagnosis, o.ObjectIdent + _str_Diagnosis, o.ObjectIdent2 + _str_Diagnosis, o.ObjectIdent3 + _str_Diagnosis, "Lookup", o.idfsDiagnosis == null ? "" : o.idfsDiagnosis.ToString(), o.IsReadOnly(_str_Diagnosis), o.IsInvisible(_str_Diagnosis), o.IsRequired(_str_Diagnosis),
                  bChangeLookupContent ? o.DiagnosisLookup.Select(i => new CompareModel.ComboBoxItem() { id = i.KeyLookup, name = i.ToStringProp }).ToList() : null);
                  }
                }
              }, 
            new field_info {
              _name = _str_Diagnosis + "Lookup", _formname = _str_Diagnosis + "Lookup", _type = "LookupContent",
              _get_func = o => o.DiagnosisLookup,
              _set_func = (o, val) => { },
              _compare_func = (o, c, m, g) => { }, 
              }, 
        
            new field_info {
              _name = _str_Items, _formname = _str_Items, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Items.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Items.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.Items.Count != c.Items.Count || o.IsReadOnly(_str_Items) != c.IsReadOnly(_str_Items) || o.IsInvisible(_str_Items) != c.IsInvisible(_str_Items) || o.IsRequired(_str_Items) != c._isRequired(o.m_isRequired, _str_Items)) {
                  m.Add(_str_Items, o.ObjectIdent + _str_Items, o.ObjectIdent2 + _str_Items, o.ObjectIdent3 + _str_Items, "Child", o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(), o.IsReadOnly(_str_Items), o.IsInvisible(_str_Items), o.IsRequired(_str_Items)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_Duplicates, _formname = _str_Duplicates, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.Duplicates.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.Duplicates.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.Duplicates.Count != c.Duplicates.Count || o.IsReadOnly(_str_Duplicates) != c.IsReadOnly(_str_Duplicates) || o.IsInvisible(_str_Duplicates) != c.IsInvisible(_str_Duplicates) || o.IsRequired(_str_Duplicates) != c._isRequired(o.m_isRequired, _str_Duplicates)) {
                  m.Add(_str_Duplicates, o.ObjectIdent + _str_Duplicates, o.ObjectIdent2 + _str_Duplicates, o.ObjectIdent3 + _str_Duplicates, "Child", o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(), o.IsReadOnly(_str_Duplicates), o.IsInvisible(_str_Duplicates), o.IsRequired(_str_Duplicates)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_HumanGenderRefs, _formname = _str_HumanGenderRefs, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.HumanGenderRefs.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.HumanGenderRefs.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.HumanGenderRefs.Count != c.HumanGenderRefs.Count || o.IsReadOnly(_str_HumanGenderRefs) != c.IsReadOnly(_str_HumanGenderRefs) || o.IsInvisible(_str_HumanGenderRefs) != c.IsInvisible(_str_HumanGenderRefs) || o.IsRequired(_str_HumanGenderRefs) != c._isRequired(o.m_isRequired, _str_HumanGenderRefs)) {
                  m.Add(_str_HumanGenderRefs, o.ObjectIdent + _str_HumanGenderRefs, o.ObjectIdent2 + _str_HumanGenderRefs, o.ObjectIdent3 + _str_HumanGenderRefs, "Child", o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(), o.IsReadOnly(_str_HumanGenderRefs), o.IsInvisible(_str_HumanGenderRefs), o.IsRequired(_str_HumanGenderRefs)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_NationalityRefs, _formname = _str_NationalityRefs, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.NationalityRefs.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.NationalityRefs.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.NationalityRefs.Count != c.NationalityRefs.Count || o.IsReadOnly(_str_NationalityRefs) != c.IsReadOnly(_str_NationalityRefs) || o.IsInvisible(_str_NationalityRefs) != c.IsInvisible(_str_NationalityRefs) || o.IsRequired(_str_NationalityRefs) != c._isRequired(o.m_isRequired, _str_NationalityRefs)) {
                  m.Add(_str_NationalityRefs, o.ObjectIdent + _str_NationalityRefs, o.ObjectIdent2 + _str_NationalityRefs, o.ObjectIdent3 + _str_NationalityRefs, "Child", o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(), o.IsReadOnly(_str_NationalityRefs), o.IsInvisible(_str_NationalityRefs), o.IsRequired(_str_NationalityRefs)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_OccupationTypeRefs, _formname = _str_OccupationTypeRefs, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.OccupationTypeRefs.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.OccupationTypeRefs.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.OccupationTypeRefs.Count != c.OccupationTypeRefs.Count || o.IsReadOnly(_str_OccupationTypeRefs) != c.IsReadOnly(_str_OccupationTypeRefs) || o.IsInvisible(_str_OccupationTypeRefs) != c.IsInvisible(_str_OccupationTypeRefs) || o.IsRequired(_str_OccupationTypeRefs) != c._isRequired(o.m_isRequired, _str_OccupationTypeRefs)) {
                  m.Add(_str_OccupationTypeRefs, o.ObjectIdent + _str_OccupationTypeRefs, o.ObjectIdent2 + _str_OccupationTypeRefs, o.ObjectIdent3 + _str_OccupationTypeRefs, "Child", o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(), o.IsReadOnly(_str_OccupationTypeRefs), o.IsInvisible(_str_OccupationTypeRefs), o.IsRequired(_str_OccupationTypeRefs)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_OutcomeRefs, _formname = _str_OutcomeRefs, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.OutcomeRefs.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.OutcomeRefs.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.OutcomeRefs.Count != c.OutcomeRefs.Count || o.IsReadOnly(_str_OutcomeRefs) != c.IsReadOnly(_str_OutcomeRefs) || o.IsInvisible(_str_OutcomeRefs) != c.IsInvisible(_str_OutcomeRefs) || o.IsRequired(_str_OutcomeRefs) != c._isRequired(o.m_isRequired, _str_OutcomeRefs)) {
                  m.Add(_str_OutcomeRefs, o.ObjectIdent + _str_OutcomeRefs, o.ObjectIdent2 + _str_OutcomeRefs, o.ObjectIdent3 + _str_OutcomeRefs, "Child", o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(), o.IsReadOnly(_str_OutcomeRefs), o.IsInvisible(_str_OutcomeRefs), o.IsRequired(_str_OutcomeRefs)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_DiagnosisRefs, _formname = _str_DiagnosisRefs, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.DiagnosisRefs.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.DiagnosisRefs.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.DiagnosisRefs.Count != c.DiagnosisRefs.Count || o.IsReadOnly(_str_DiagnosisRefs) != c.IsReadOnly(_str_DiagnosisRefs) || o.IsInvisible(_str_DiagnosisRefs) != c.IsInvisible(_str_DiagnosisRefs) || o.IsRequired(_str_DiagnosisRefs) != c._isRequired(o.m_isRequired, _str_DiagnosisRefs)) {
                  m.Add(_str_DiagnosisRefs, o.ObjectIdent + _str_DiagnosisRefs, o.ObjectIdent2 + _str_DiagnosisRefs, o.ObjectIdent3 + _str_DiagnosisRefs, "Child", o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(), o.IsReadOnly(_str_DiagnosisRefs), o.IsInvisible(_str_DiagnosisRefs), o.IsRequired(_str_DiagnosisRefs)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_MaritalStatusRefs, _formname = _str_MaritalStatusRefs, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.MaritalStatusRefs.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.MaritalStatusRefs.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.MaritalStatusRefs.Count != c.MaritalStatusRefs.Count || o.IsReadOnly(_str_MaritalStatusRefs) != c.IsReadOnly(_str_MaritalStatusRefs) || o.IsInvisible(_str_MaritalStatusRefs) != c.IsInvisible(_str_MaritalStatusRefs) || o.IsRequired(_str_MaritalStatusRefs) != c._isRequired(o.m_isRequired, _str_MaritalStatusRefs)) {
                  m.Add(_str_MaritalStatusRefs, o.ObjectIdent + _str_MaritalStatusRefs, o.ObjectIdent2 + _str_MaritalStatusRefs, o.ObjectIdent3 + _str_MaritalStatusRefs, "Child", o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(), o.IsReadOnly(_str_MaritalStatusRefs), o.IsInvisible(_str_MaritalStatusRefs), o.IsRequired(_str_MaritalStatusRefs)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_ForeignerTypeRefs, _formname = _str_ForeignerTypeRefs, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.ForeignerTypeRefs.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.ForeignerTypeRefs.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.ForeignerTypeRefs.Count != c.ForeignerTypeRefs.Count || o.IsReadOnly(_str_ForeignerTypeRefs) != c.IsReadOnly(_str_ForeignerTypeRefs) || o.IsInvisible(_str_ForeignerTypeRefs) != c.IsInvisible(_str_ForeignerTypeRefs) || o.IsRequired(_str_ForeignerTypeRefs) != c._isRequired(o.m_isRequired, _str_ForeignerTypeRefs)) {
                  m.Add(_str_ForeignerTypeRefs, o.ObjectIdent + _str_ForeignerTypeRefs, o.ObjectIdent2 + _str_ForeignerTypeRefs, o.ObjectIdent3 + _str_ForeignerTypeRefs, "Child", o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(), o.IsReadOnly(_str_ForeignerTypeRefs), o.IsInvisible(_str_ForeignerTypeRefs), o.IsRequired(_str_ForeignerTypeRefs)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_MunicipalityRefs, _formname = _str_MunicipalityRefs, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.MunicipalityRefs.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.MunicipalityRefs.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.MunicipalityRefs.Count != c.MunicipalityRefs.Count || o.IsReadOnly(_str_MunicipalityRefs) != c.IsReadOnly(_str_MunicipalityRefs) || o.IsInvisible(_str_MunicipalityRefs) != c.IsInvisible(_str_MunicipalityRefs) || o.IsRequired(_str_MunicipalityRefs) != c._isRequired(o.m_isRequired, _str_MunicipalityRefs)) {
                  m.Add(_str_MunicipalityRefs, o.ObjectIdent + _str_MunicipalityRefs, o.ObjectIdent2 + _str_MunicipalityRefs, o.ObjectIdent3 + _str_MunicipalityRefs, "Child", o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(), o.IsReadOnly(_str_MunicipalityRefs), o.IsInvisible(_str_MunicipalityRefs), o.IsRequired(_str_MunicipalityRefs)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_HospitalizationRefs, _formname = _str_HospitalizationRefs, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.HospitalizationRefs.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.HospitalizationRefs.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.HospitalizationRefs.Count != c.HospitalizationRefs.Count || o.IsReadOnly(_str_HospitalizationRefs) != c.IsReadOnly(_str_HospitalizationRefs) || o.IsInvisible(_str_HospitalizationRefs) != c.IsInvisible(_str_HospitalizationRefs) || o.IsRequired(_str_HospitalizationRefs) != c._isRequired(o.m_isRequired, _str_HospitalizationRefs)) {
                  m.Add(_str_HospitalizationRefs, o.ObjectIdent + _str_HospitalizationRefs, o.ObjectIdent2 + _str_HospitalizationRefs, o.ObjectIdent3 + _str_HospitalizationRefs, "Child", o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(), o.IsReadOnly(_str_HospitalizationRefs), o.IsInvisible(_str_HospitalizationRefs), o.IsRequired(_str_HospitalizationRefs)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_PatientTypeRefs, _formname = _str_PatientTypeRefs, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.PatientTypeRefs.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.PatientTypeRefs.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.PatientTypeRefs.Count != c.PatientTypeRefs.Count || o.IsReadOnly(_str_PatientTypeRefs) != c.IsReadOnly(_str_PatientTypeRefs) || o.IsInvisible(_str_PatientTypeRefs) != c.IsInvisible(_str_PatientTypeRefs) || o.IsRequired(_str_PatientTypeRefs) != c._isRequired(o.m_isRequired, _str_PatientTypeRefs)) {
                  m.Add(_str_PatientTypeRefs, o.ObjectIdent + _str_PatientTypeRefs, o.ObjectIdent2 + _str_PatientTypeRefs, o.ObjectIdent3 + _str_PatientTypeRefs, "Child", o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(), o.IsReadOnly(_str_PatientTypeRefs), o.IsInvisible(_str_PatientTypeRefs), o.IsRequired(_str_PatientTypeRefs)); 
                  }
                }
              }, 
        
            new field_info {
              _name = _str_ComplicationRefs, _formname = _str_ComplicationRefs, _type = "Child",
              _get_func = o => null,
              _set_func = (o, val) => {
                  o.ComplicationRefs.ForEach(c => c.SetValue("blnChecked", "false")); 
                  if (!string.IsNullOrEmpty(val)) 
                      val.Split(',').ToList().ForEach(i => o.ComplicationRefs.First(c => (long)c.Key == Int64.Parse(i)).SetValue("blnChecked", "true"));
                  },
              _compare_func = (o, c, m, g) => {
                if (o.ComplicationRefs.Count != c.ComplicationRefs.Count || o.IsReadOnly(_str_ComplicationRefs) != c.IsReadOnly(_str_ComplicationRefs) || o.IsInvisible(_str_ComplicationRefs) != c.IsInvisible(_str_ComplicationRefs) || o.IsRequired(_str_ComplicationRefs) != c._isRequired(o.m_isRequired, _str_ComplicationRefs)) {
                  m.Add(_str_ComplicationRefs, o.ObjectIdent + _str_ComplicationRefs, o.ObjectIdent2 + _str_ComplicationRefs, o.ObjectIdent3 + _str_ComplicationRefs, "Child", o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(), o.IsReadOnly(_str_ComplicationRefs), o.IsInvisible(_str_ComplicationRefs), o.IsRequired(_str_ComplicationRefs)); 
                  }
                }
              }, 
        
            new field_info()
        };
        #endregion
        
        private string _getType(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? "" : i._type;
        }
        private object _getValue(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? null : i._get_func(this);
        }
        private void _setValue(string name, string val)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            if (i != null) i._set_func(this, val);
        }
        internal CompareModel _compare(IObject o, CompareModel ret)
        {
            if (ret == null) ret = new CompareModel();
            if (o == null) return ret;
            Upload506Master obj = (Upload506Master)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        [LocalizedDisplayName(_str_Items)]
        [Relation(typeof(Upload506Item), eidss.model.Schema.Upload506Item._str_idfsUpload506, _str_idfsUpload506)]
        public EditableList<Upload506Item> Items
        {
            get 
            {   
                return _Items; 
            }
            set 
            {
                _Items = value;
            }
        }
        protected EditableList<Upload506Item> _Items = new EditableList<Upload506Item>();
                    
        [LocalizedDisplayName(_str_Duplicates)]
        [Relation(typeof(Upload506Duplicate), eidss.model.Schema.Upload506Duplicate._str_idfsUpload506, _str_idfsUpload506)]
        public EditableList<Upload506Duplicate> Duplicates
        {
            get 
            {   
                return _Duplicates; 
            }
            set 
            {
                _Duplicates = value;
            }
        }
        protected EditableList<Upload506Duplicate> _Duplicates = new EditableList<Upload506Duplicate>();
                    
        [LocalizedDisplayName(_str_HumanGenderRefs)]
        [Relation(typeof(cc_506_HumanGender), eidss.model.Schema.cc_506_HumanGender._str_idfsUpload506, _str_idfsUpload506)]
        public EditableList<cc_506_HumanGender> HumanGenderRefs
        {
            get 
            {   
                return _HumanGenderRefs; 
            }
            set 
            {
                _HumanGenderRefs = value;
            }
        }
        protected EditableList<cc_506_HumanGender> _HumanGenderRefs = new EditableList<cc_506_HumanGender>();
                    
        [LocalizedDisplayName(_str_NationalityRefs)]
        [Relation(typeof(cc_506_Nationality), eidss.model.Schema.cc_506_Nationality._str_idfsUpload506, _str_idfsUpload506)]
        public EditableList<cc_506_Nationality> NationalityRefs
        {
            get 
            {   
                return _NationalityRefs; 
            }
            set 
            {
                _NationalityRefs = value;
            }
        }
        protected EditableList<cc_506_Nationality> _NationalityRefs = new EditableList<cc_506_Nationality>();
                    
        [LocalizedDisplayName(_str_OccupationTypeRefs)]
        [Relation(typeof(cc_506_OccupationType), eidss.model.Schema.cc_506_OccupationType._str_idfsUpload506, _str_idfsUpload506)]
        public EditableList<cc_506_OccupationType> OccupationTypeRefs
        {
            get 
            {   
                return _OccupationTypeRefs; 
            }
            set 
            {
                _OccupationTypeRefs = value;
            }
        }
        protected EditableList<cc_506_OccupationType> _OccupationTypeRefs = new EditableList<cc_506_OccupationType>();
                    
        [LocalizedDisplayName(_str_OutcomeRefs)]
        [Relation(typeof(cc_506_Outcome), eidss.model.Schema.cc_506_Outcome._str_idfsUpload506, _str_idfsUpload506)]
        public EditableList<cc_506_Outcome> OutcomeRefs
        {
            get 
            {   
                return _OutcomeRefs; 
            }
            set 
            {
                _OutcomeRefs = value;
            }
        }
        protected EditableList<cc_506_Outcome> _OutcomeRefs = new EditableList<cc_506_Outcome>();
                    
        [LocalizedDisplayName(_str_DiagnosisRefs)]
        [Relation(typeof(cc_506_Diagnosis), eidss.model.Schema.cc_506_Diagnosis._str_idfsUpload506, _str_idfsUpload506)]
        public EditableList<cc_506_Diagnosis> DiagnosisRefs
        {
            get 
            {   
                return _DiagnosisRefs; 
            }
            set 
            {
                _DiagnosisRefs = value;
            }
        }
        protected EditableList<cc_506_Diagnosis> _DiagnosisRefs = new EditableList<cc_506_Diagnosis>();
                    
        [LocalizedDisplayName(_str_MaritalStatusRefs)]
        [Relation(typeof(cc_506_MaritalStatus), eidss.model.Schema.cc_506_MaritalStatus._str_idfsUpload506, _str_idfsUpload506)]
        public EditableList<cc_506_MaritalStatus> MaritalStatusRefs
        {
            get 
            {   
                return _MaritalStatusRefs; 
            }
            set 
            {
                _MaritalStatusRefs = value;
            }
        }
        protected EditableList<cc_506_MaritalStatus> _MaritalStatusRefs = new EditableList<cc_506_MaritalStatus>();
                    
        [LocalizedDisplayName(_str_ForeignerTypeRefs)]
        [Relation(typeof(cc_506_ForeignerType), eidss.model.Schema.cc_506_ForeignerType._str_idfsUpload506, _str_idfsUpload506)]
        public EditableList<cc_506_ForeignerType> ForeignerTypeRefs
        {
            get 
            {   
                return _ForeignerTypeRefs; 
            }
            set 
            {
                _ForeignerTypeRefs = value;
            }
        }
        protected EditableList<cc_506_ForeignerType> _ForeignerTypeRefs = new EditableList<cc_506_ForeignerType>();
                    
        [LocalizedDisplayName(_str_MunicipalityRefs)]
        [Relation(typeof(cc_506_Municipality), eidss.model.Schema.cc_506_Municipality._str_idfsUpload506, _str_idfsUpload506)]
        public EditableList<cc_506_Municipality> MunicipalityRefs
        {
            get 
            {   
                return _MunicipalityRefs; 
            }
            set 
            {
                _MunicipalityRefs = value;
            }
        }
        protected EditableList<cc_506_Municipality> _MunicipalityRefs = new EditableList<cc_506_Municipality>();
                    
        [LocalizedDisplayName(_str_HospitalizationRefs)]
        [Relation(typeof(cc_506_Hospitalization), eidss.model.Schema.cc_506_Hospitalization._str_idfsUpload506, _str_idfsUpload506)]
        public EditableList<cc_506_Hospitalization> HospitalizationRefs
        {
            get 
            {   
                return _HospitalizationRefs; 
            }
            set 
            {
                _HospitalizationRefs = value;
            }
        }
        protected EditableList<cc_506_Hospitalization> _HospitalizationRefs = new EditableList<cc_506_Hospitalization>();
                    
        [LocalizedDisplayName(_str_PatientTypeRefs)]
        [Relation(typeof(cc_506_PatientType), eidss.model.Schema.cc_506_PatientType._str_idfsUpload506, _str_idfsUpload506)]
        public EditableList<cc_506_PatientType> PatientTypeRefs
        {
            get 
            {   
                return _PatientTypeRefs; 
            }
            set 
            {
                _PatientTypeRefs = value;
            }
        }
        protected EditableList<cc_506_PatientType> _PatientTypeRefs = new EditableList<cc_506_PatientType>();
                    
        [LocalizedDisplayName(_str_ComplicationRefs)]
        [Relation(typeof(cc_506_Complication), eidss.model.Schema.cc_506_Complication._str_idfsUpload506, _str_idfsUpload506)]
        public EditableList<cc_506_Complication> ComplicationRefs
        {
            get 
            {   
                return _ComplicationRefs; 
            }
            set 
            {
                _ComplicationRefs = value;
            }
        }
        protected EditableList<cc_506_Complication> _ComplicationRefs = new EditableList<cc_506_Complication>();
                    
        [LocalizedDisplayName(_str_Diagnosis)]
        [Relation(typeof(DiagnosisLookup), eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, _str_idfsDiagnosis)]
        public DiagnosisLookup Diagnosis
        {
            get { return _Diagnosis == null ? null : ((long)_Diagnosis.Key == 0 ? null : _Diagnosis); }
            set 
            { 
                var oldVal = _Diagnosis;
                _Diagnosis = value == null ? null : ((long) value.Key == 0 ? null : value);
                if (_Diagnosis != oldVal)
                {
                    if (idfsDiagnosis != (_Diagnosis == null
                            ? new long?()
                            : _Diagnosis.idfsDiagnosis))
                        idfsDiagnosis = _Diagnosis == null 
                            ? new long?()
                            : _Diagnosis.idfsDiagnosis; 
                    OnPropertyChanged(_str_Diagnosis); 
                }
            }
        }
        private DiagnosisLookup _Diagnosis;

        
        public List<DiagnosisLookup> DiagnosisLookup
        {
            get { return _DiagnosisLookup; }
        }
        private List<DiagnosisLookup> _DiagnosisLookup = new List<DiagnosisLookup>();
            
        private BvSelectList _getList(string name)
        {
        
            switch(name)
            {
            
                case _str_Diagnosis:
                    return new BvSelectList(DiagnosisLookup, eidss.model.Schema.DiagnosisLookup._str_idfsDiagnosis, null, Diagnosis, _str_idfsDiagnosis);
            
                case _str_Items:
                    return new BvSelectList(Items, "", "", null, "");
            
                case _str_Duplicates:
                    return new BvSelectList(Duplicates, "", "", null, "");
            
                case _str_HumanGenderRefs:
                    return new BvSelectList(HumanGenderRefs, "", "", null, "");
            
                case _str_NationalityRefs:
                    return new BvSelectList(NationalityRefs, "", "", null, "");
            
                case _str_OccupationTypeRefs:
                    return new BvSelectList(OccupationTypeRefs, "", "", null, "");
            
                case _str_OutcomeRefs:
                    return new BvSelectList(OutcomeRefs, "", "", null, "");
            
                case _str_DiagnosisRefs:
                    return new BvSelectList(DiagnosisRefs, "", "", null, "");
            
                case _str_MaritalStatusRefs:
                    return new BvSelectList(MaritalStatusRefs, "", "", null, "");
            
                case _str_ForeignerTypeRefs:
                    return new BvSelectList(ForeignerTypeRefs, "", "", null, "");
            
                case _str_MunicipalityRefs:
                    return new BvSelectList(MunicipalityRefs, "", "", null, "");
            
                case _str_HospitalizationRefs:
                    return new BvSelectList(HospitalizationRefs, "", "", null, "");
            
                case _str_PatientTypeRefs:
                    return new BvSelectList(PatientTypeRefs, "", "", null, "");
            
                case _str_ComplicationRefs:
                    return new BvSelectList(ComplicationRefs, "", "", null, "");
            
            }
        
            return null;
        }
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsDiagnosis)]
        public long? idfsDiagnosis
        {
            get { return new Func<Upload506Master, long?>(c => 0)(this); }
            
            set { ; OnPropertyChanged(_str_idfsDiagnosis); }
            
        }
        
          [LocalizedDisplayName(_str_FileName)]
        public string FileName
        {
            get { return m_FileName; }
            set { if (m_FileName != value) { m_FileName = value; OnPropertyChanged(_str_FileName); } }
        }
        private string m_FileName;
        
          [LocalizedDisplayName(_str_FileContent)]
        public byte[] FileContent
        {
            get { return m_FileContent; }
            set { if (m_FileContent != value) { m_FileContent = value; OnPropertyChanged(_str_FileContent); } }
        }
        private byte[] m_FileContent;
        
          [LocalizedDisplayName(_str_intDummy)]
        public int intDummy
        {
            get { return m_intDummy; }
            set { if (m_intDummy != value) { m_intDummy = value; OnPropertyChanged(_str_intDummy); } }
        }
        private int m_intDummy;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "Upload506Master";

        #region Parent and Clone supporting
        [XmlIgnore]
        public IObject Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; /*OnPropertyChanged(_str_Parent);*/ }
        }
        private IObject m_Parent;
        internal void _setParent()
        {
        Items.ForEach(c => { c.Parent = this; });
                Duplicates.ForEach(c => { c.Parent = this; });
                HumanGenderRefs.ForEach(c => { c.Parent = this; });
                NationalityRefs.ForEach(c => { c.Parent = this; });
                OccupationTypeRefs.ForEach(c => { c.Parent = this; });
                OutcomeRefs.ForEach(c => { c.Parent = this; });
                DiagnosisRefs.ForEach(c => { c.Parent = this; });
                MaritalStatusRefs.ForEach(c => { c.Parent = this; });
                ForeignerTypeRefs.ForEach(c => { c.Parent = this; });
                MunicipalityRefs.ForEach(c => { c.Parent = this; });
                HospitalizationRefs.ForEach(c => { c.Parent = this; });
                PatientTypeRefs.ForEach(c => { c.Parent = this; });
                ComplicationRefs.ForEach(c => { c.Parent = this; });
                
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as Upload506Master;
            ret.bIsClone = true;
            ret.Cloned();
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager, bool bRestricted = false)
        {
            var ret = base.Clone() as Upload506Master;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            if (_Items != null && _Items.Count > 0)
            {
              ret.Items.Clear();
              _Items.ForEach(c => ret.Items.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_Duplicates != null && _Duplicates.Count > 0)
            {
              ret.Duplicates.Clear();
              _Duplicates.ForEach(c => ret.Duplicates.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_HumanGenderRefs != null && _HumanGenderRefs.Count > 0)
            {
              ret.HumanGenderRefs.Clear();
              _HumanGenderRefs.ForEach(c => ret.HumanGenderRefs.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_NationalityRefs != null && _NationalityRefs.Count > 0)
            {
              ret.NationalityRefs.Clear();
              _NationalityRefs.ForEach(c => ret.NationalityRefs.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_OccupationTypeRefs != null && _OccupationTypeRefs.Count > 0)
            {
              ret.OccupationTypeRefs.Clear();
              _OccupationTypeRefs.ForEach(c => ret.OccupationTypeRefs.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_OutcomeRefs != null && _OutcomeRefs.Count > 0)
            {
              ret.OutcomeRefs.Clear();
              _OutcomeRefs.ForEach(c => ret.OutcomeRefs.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_DiagnosisRefs != null && _DiagnosisRefs.Count > 0)
            {
              ret.DiagnosisRefs.Clear();
              _DiagnosisRefs.ForEach(c => ret.DiagnosisRefs.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_MaritalStatusRefs != null && _MaritalStatusRefs.Count > 0)
            {
              ret.MaritalStatusRefs.Clear();
              _MaritalStatusRefs.ForEach(c => ret.MaritalStatusRefs.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_ForeignerTypeRefs != null && _ForeignerTypeRefs.Count > 0)
            {
              ret.ForeignerTypeRefs.Clear();
              _ForeignerTypeRefs.ForEach(c => ret.ForeignerTypeRefs.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_MunicipalityRefs != null && _MunicipalityRefs.Count > 0)
            {
              ret.MunicipalityRefs.Clear();
              _MunicipalityRefs.ForEach(c => ret.MunicipalityRefs.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_HospitalizationRefs != null && _HospitalizationRefs.Count > 0)
            {
              ret.HospitalizationRefs.Clear();
              _HospitalizationRefs.ForEach(c => ret.HospitalizationRefs.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_PatientTypeRefs != null && _PatientTypeRefs.Count > 0)
            {
              ret.PatientTypeRefs.Clear();
              _PatientTypeRefs.ForEach(c => ret.PatientTypeRefs.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            if (_ComplicationRefs != null && _ComplicationRefs.Count > 0)
            {
              ret.ComplicationRefs.Clear();
              _ComplicationRefs.ForEach(c => ret.ComplicationRefs.Add(c.CloneWithSetup(manager, bRestricted)));
            }
                
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public Upload506Master CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as Upload506Master;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsUpload506; } }
        public string KeyName { get { return "idfsUpload506"; } }
        public object KeyLookup { get { return idfsUpload506; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        [XmlIgnore]
        [LocalizedDisplayName("HasChanges")]
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                    || Items.IsDirty
                    || Items.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || Duplicates.IsDirty
                    || Duplicates.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || HumanGenderRefs.IsDirty
                    || HumanGenderRefs.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || NationalityRefs.IsDirty
                    || NationalityRefs.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || OccupationTypeRefs.IsDirty
                    || OccupationTypeRefs.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || OutcomeRefs.IsDirty
                    || OutcomeRefs.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || DiagnosisRefs.IsDirty
                    || DiagnosisRefs.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || MaritalStatusRefs.IsDirty
                    || MaritalStatusRefs.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || ForeignerTypeRefs.IsDirty
                    || ForeignerTypeRefs.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || MunicipalityRefs.IsDirty
                    || MunicipalityRefs.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || HospitalizationRefs.IsDirty
                    || HospitalizationRefs.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || PatientTypeRefs.IsDirty
                    || PatientTypeRefs.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                    || ComplicationRefs.IsDirty
                    || ComplicationRefs.Count(c => c.IsMarkedToDelete || c.HasChanges) > 0
                
                ;
            }
        }
        public new void RejectChanges()
        {
        
            var _prev_idfsDiagnosis_Diagnosis = idfsDiagnosis;
            base.RejectChanges();
        
            if (_prev_idfsDiagnosis_Diagnosis != idfsDiagnosis)
            {
                _Diagnosis = _DiagnosisLookup.FirstOrDefault(c => c.idfsDiagnosis == idfsDiagnosis);
            }
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        Items.DeepRejectChanges();
                Duplicates.DeepRejectChanges();
                HumanGenderRefs.DeepRejectChanges();
                NationalityRefs.DeepRejectChanges();
                OccupationTypeRefs.DeepRejectChanges();
                OutcomeRefs.DeepRejectChanges();
                DiagnosisRefs.DeepRejectChanges();
                MaritalStatusRefs.DeepRejectChanges();
                ForeignerTypeRefs.DeepRejectChanges();
                MunicipalityRefs.DeepRejectChanges();
                HospitalizationRefs.DeepRejectChanges();
                PatientTypeRefs.DeepRejectChanges();
                ComplicationRefs.DeepRejectChanges();
                
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        Items.DeepAcceptChanges();
                Duplicates.DeepAcceptChanges();
                HumanGenderRefs.DeepAcceptChanges();
                NationalityRefs.DeepAcceptChanges();
                OccupationTypeRefs.DeepAcceptChanges();
                OutcomeRefs.DeepAcceptChanges();
                DiagnosisRefs.DeepAcceptChanges();
                MaritalStatusRefs.DeepAcceptChanges();
                ForeignerTypeRefs.DeepAcceptChanges();
                MunicipalityRefs.DeepAcceptChanges();
                HospitalizationRefs.DeepAcceptChanges();
                PatientTypeRefs.DeepAcceptChanges();
                ComplicationRefs.DeepAcceptChanges();
                
        }
        private bool m_bForceDirty;
        public override void AcceptChanges()
        {
            m_bForceDirty = false;
            base.AcceptChanges();
        }
        [XmlIgnore]
        [LocalizedDisplayName("IsDirty")]
        public override bool IsDirty
        {
            get { return m_bForceDirty || base.IsDirty; }
        }
        public void SetChange()
        { 
            m_bForceDirty = true;
        }
        public void DeepSetChange()
        { 
            SetChange();
        Items.ForEach(c => c.SetChange());
                Duplicates.ForEach(c => c.SetChange());
                HumanGenderRefs.ForEach(c => c.SetChange());
                NationalityRefs.ForEach(c => c.SetChange());
                OccupationTypeRefs.ForEach(c => c.SetChange());
                OutcomeRefs.ForEach(c => c.SetChange());
                DiagnosisRefs.ForEach(c => c.SetChange());
                MaritalStatusRefs.ForEach(c => c.SetChange());
                ForeignerTypeRefs.ForEach(c => c.SetChange());
                MunicipalityRefs.ForEach(c => c.SetChange());
                HospitalizationRefs.ForEach(c => c.SetChange());
                PatientTypeRefs.ForEach(c => c.SetChange());
                ComplicationRefs.ForEach(c => c.SetChange());
                
        }
        public bool MarkToDelete() { return _Delete(false); }
        public string ObjectName { get { return m_ObjectName; } }
        public string ObjectIdent { get { return ObjectName + "_" + Key.ToString() + "_"; } }
        
        public string ObjectIdent2 { get { return ObjectIdent; } }
          
        public string ObjectIdent3 { get { return ObjectIdent; } }
          
        public IObjectAccessor GetAccessor() { return _getAccessor(); }
        public IObjectPermissions GetPermissions() { return _permissions; }
        private IObjectEnvironment _environment;
        public IObjectEnvironment Environment { get { return _environment; } set { _environment = value; } }
        public bool IsValidObject { get { return _isValid; } }
        public bool ReadOnly { get { return _readOnly || !_isValid; } set { _readOnly = value; } }
        public bool IsReadOnly(string name) { return _isReadOnly(name); }
        public bool IsInvisible(string name) { return _isInvisible(name); }
        public bool IsRequired(string name) { return _isRequired(m_isRequired, name); }
        public bool IsHiddenPersonalData(string name) { return _isHiddenPersonalData(name); }
        public string GetType(string name) { return _getType(name); }
        public object GetValue(string name) { return _getValue(name); }
        public void SetValue(string name, string val) { _setValue(name, val); }
        public CompareModel Compare(IObject o) { return _compare(o, null); }
        public BvSelectList GetList(string name) { return _getList(name); }
        public event ValidationEvent Validation;
        public event ValidationEvent ValidationEnd;
        public event AfterPostEvent AfterPost;
      
        public Dictionary<string, string> GetFieldTags(string name)
        {
          return null;
        }
      #endregion

        private bool IsRIRPropChanged(string fld, Upload506Master c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, Upload506Master c)
        {
            var thisLookup = GetValue(fld + "Lookup") as IList;
            var thatLookup = c.GetValue(fld + "Lookup") as IList;
            bool bChangeLookupContent = thisLookup.Count != thatLookup.Count;
            if (!bChangeLookupContent)
            {
                for (int i = 0; i < thisLookup.Count; i++)
                {
                    if (((thisLookup[i] as IObject).Key as IComparable).CompareTo((thatLookup[i] as IObject).Key) != 0 &&
                        (thisLookup[i] as IObject).ToStringProp != null && ((thisLookup[i] as IObject).ToStringProp as IComparable).CompareTo((thatLookup[i] as IObject).ToStringProp) != 0)
                    {
                        bChangeLookupContent = true;
                        break;
                    }
                }
            }
            return bChangeLookupContent;
        }
        

      

        public Upload506Master()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Upload506Master_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(Upload506Master_PropertyChanged);
        }
        private void Upload506Master_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as Upload506Master).Changed(e.PropertyName);
            
        }
        
        public bool ForceToDelete() { return _Delete(true); }
        internal bool _Delete(bool isForceDelete)
        {
            if (!_ValidateOnDelete()) return false;
            _DeletingExtenders();
            m_IsMarkedToDelete = true;
            m_IsForcedToDelete = m_IsForcedToDelete ? m_IsForcedToDelete : isForceDelete;
            OnPropertyChanged("IsMarkedToDelete");
            _DeletedExtenders();
            Deleted();
            return true;
        }
        private bool _ValidateOnDelete(bool bReport = true)
        {
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            Upload506Master obj = this;
            
        }
        private void _DeletedExtenders()
        {
            Upload506Master obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                ValidationEnd(this, args);
                return args.Continue;
            }
            return false;
        }

        public void OnAfterPost()
        {
            if (AfterPost != null)
            {
                AfterPost(this, EventArgs.Empty);
            }
        }

        public FormSize FormSize
        {
            get { return FormSize.Undefined; }
        }
    
        private bool _isInvisible(string name)
        {
            
            return false;
                
        }

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
                foreach(var o in _Items)
                    o._isValid &= value;
                
                foreach(var o in _Duplicates)
                    o._isValid &= value;
                
                foreach(var o in _HumanGenderRefs)
                    o._isValid &= value;
                
                foreach(var o in _NationalityRefs)
                    o._isValid &= value;
                
                foreach(var o in _OccupationTypeRefs)
                    o._isValid &= value;
                
                foreach(var o in _OutcomeRefs)
                    o._isValid &= value;
                
                foreach(var o in _DiagnosisRefs)
                    o._isValid &= value;
                
                foreach(var o in _MaritalStatusRefs)
                    o._isValid &= value;
                
                foreach(var o in _ForeignerTypeRefs)
                    o._isValid &= value;
                
                foreach(var o in _MunicipalityRefs)
                    o._isValid &= value;
                
                foreach(var o in _HospitalizationRefs)
                    o._isValid &= value;
                
                foreach(var o in _PatientTypeRefs)
                    o._isValid &= value;
                
                foreach(var o in _ComplicationRefs)
                    o._isValid &= value;
                
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
                foreach(var o in _Items)
                    o.ReadOnly |= value;
                
                foreach(var o in _Duplicates)
                    o.ReadOnly |= value;
                
                foreach(var o in _HumanGenderRefs)
                    o.ReadOnly |= value;
                
                foreach(var o in _NationalityRefs)
                    o.ReadOnly |= value;
                
                foreach(var o in _OccupationTypeRefs)
                    o.ReadOnly |= value;
                
                foreach(var o in _OutcomeRefs)
                    o.ReadOnly |= value;
                
                foreach(var o in _DiagnosisRefs)
                    o.ReadOnly |= value;
                
                foreach(var o in _MaritalStatusRefs)
                    o.ReadOnly |= value;
                
                foreach(var o in _ForeignerTypeRefs)
                    o.ReadOnly |= value;
                
                foreach(var o in _MunicipalityRefs)
                    o.ReadOnly |= value;
                
                foreach(var o in _HospitalizationRefs)
                    o.ReadOnly |= value;
                
                foreach(var o in _PatientTypeRefs)
                    o.ReadOnly |= value;
                
                foreach(var o in _ComplicationRefs)
                    o.ReadOnly |= value;
                
            }
        }


        internal Dictionary<string, Func<Upload506Master, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<Upload506Master, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Upload506Master, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Upload506Master, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<Upload506Master, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<Upload506Master, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<Upload506Master, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        partial void Disposed();
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~Upload506Master()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                m_Parent = null;
                m_permissions = null;
                
                this.ClearModelObjEventInvocations();
                
                if (!bIsClone)
                {
                    Items.ForEach(c => c.Dispose());
                }
                Items.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    Duplicates.ForEach(c => c.Dispose());
                }
                Duplicates.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    HumanGenderRefs.ForEach(c => c.Dispose());
                }
                HumanGenderRefs.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    NationalityRefs.ForEach(c => c.Dispose());
                }
                NationalityRefs.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    OccupationTypeRefs.ForEach(c => c.Dispose());
                }
                OccupationTypeRefs.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    OutcomeRefs.ForEach(c => c.Dispose());
                }
                OutcomeRefs.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    DiagnosisRefs.ForEach(c => c.Dispose());
                }
                DiagnosisRefs.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    MaritalStatusRefs.ForEach(c => c.Dispose());
                }
                MaritalStatusRefs.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    ForeignerTypeRefs.ForEach(c => c.Dispose());
                }
                ForeignerTypeRefs.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    MunicipalityRefs.ForEach(c => c.Dispose());
                }
                MunicipalityRefs.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    HospitalizationRefs.ForEach(c => c.Dispose());
                }
                HospitalizationRefs.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    PatientTypeRefs.ForEach(c => c.Dispose());
                }
                PatientTypeRefs.ClearModelListEventInvocations();
                
                if (!bIsClone)
                {
                    ComplicationRefs.ForEach(c => c.Dispose());
                }
                ComplicationRefs.ClearModelListEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                LookupManager.RemoveObject("DiagnosisLookup", this);
                
                }
                Disposed();
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
            if (lookup_object == "DiagnosisLookup")
                _getAccessor().LoadLookup_Diagnosis(manager, this);
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            ParsingFormCollection(form);
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            if (_Items != null) _Items.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_Duplicates != null) _Duplicates.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_HumanGenderRefs != null) _HumanGenderRefs.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_NationalityRefs != null) _NationalityRefs.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_OccupationTypeRefs != null) _OccupationTypeRefs.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_OutcomeRefs != null) _OutcomeRefs.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_DiagnosisRefs != null) _DiagnosisRefs.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_MaritalStatusRefs != null) _MaritalStatusRefs.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_ForeignerTypeRefs != null) _ForeignerTypeRefs.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_MunicipalityRefs != null) _MunicipalityRefs.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_HospitalizationRefs != null) _HospitalizationRefs.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_PatientTypeRefs != null) _PatientTypeRefs.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            if (_ComplicationRefs != null) _ComplicationRefs.ForEach(c => c.ParseFormCollection(form, bParseLookups, bParseRelations));
                
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<Upload506Master>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<Upload506Master>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<Upload506Master>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsUpload506"; } }
            #endregion
        
            public delegate void on_action(Upload506Master obj);
            private static Accessor g_Instance = CreateInstance<Accessor>();
            private CacheScope m_CS;
            public static Accessor Instance(CacheScope cs) 
            { 
                if (cs == null)
                    return g_Instance;
                lock(cs)
                {
                    object acc = cs.Get(typeof (Accessor));
                    if (acc != null)
                    {
                        return acc as Accessor;
                    }
                    Accessor ret = CreateInstance<Accessor>();
                    ret.m_CS = cs;
                    cs.Add(typeof(Accessor), ret);
                    return ret;
                }
            }
            private Upload506Item.Accessor ItemsAccessor { get { return eidss.model.Schema.Upload506Item.Accessor.Instance(m_CS); } }
            private Upload506Duplicate.Accessor DuplicatesAccessor { get { return eidss.model.Schema.Upload506Duplicate.Accessor.Instance(m_CS); } }
            private cc_506_HumanGender.Accessor HumanGenderRefsAccessor { get { return eidss.model.Schema.cc_506_HumanGender.Accessor.Instance(m_CS); } }
            private cc_506_Nationality.Accessor NationalityRefsAccessor { get { return eidss.model.Schema.cc_506_Nationality.Accessor.Instance(m_CS); } }
            private cc_506_OccupationType.Accessor OccupationTypeRefsAccessor { get { return eidss.model.Schema.cc_506_OccupationType.Accessor.Instance(m_CS); } }
            private cc_506_Outcome.Accessor OutcomeRefsAccessor { get { return eidss.model.Schema.cc_506_Outcome.Accessor.Instance(m_CS); } }
            private cc_506_Diagnosis.Accessor DiagnosisRefsAccessor { get { return eidss.model.Schema.cc_506_Diagnosis.Accessor.Instance(m_CS); } }
            private cc_506_MaritalStatus.Accessor MaritalStatusRefsAccessor { get { return eidss.model.Schema.cc_506_MaritalStatus.Accessor.Instance(m_CS); } }
            private cc_506_ForeignerType.Accessor ForeignerTypeRefsAccessor { get { return eidss.model.Schema.cc_506_ForeignerType.Accessor.Instance(m_CS); } }
            private cc_506_Municipality.Accessor MunicipalityRefsAccessor { get { return eidss.model.Schema.cc_506_Municipality.Accessor.Instance(m_CS); } }
            private cc_506_Hospitalization.Accessor HospitalizationRefsAccessor { get { return eidss.model.Schema.cc_506_Hospitalization.Accessor.Instance(m_CS); } }
            private cc_506_PatientType.Accessor PatientTypeRefsAccessor { get { return eidss.model.Schema.cc_506_PatientType.Accessor.Instance(m_CS); } }
            private cc_506_Complication.Accessor ComplicationRefsAccessor { get { return eidss.model.Schema.cc_506_Complication.Accessor.Instance(m_CS); } }
            private DiagnosisLookup.Accessor DiagnosisAccessor { get { return eidss.model.Schema.DiagnosisLookup.Accessor.Instance(m_CS); } }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }
            public virtual Upload506Master SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual Upload506Master SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                )
            {
                return _SelectByKey(manager
                    , idfsUpload506
                    , null, null
                    );
            }
            

            private Upload506Master _SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfsUpload506
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual Upload506Master _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[12];
                List<Upload506Master> objs = new List<Upload506Master>();
                sets[0] = new MapResultSet(typeof(Upload506Master), objs);
                
                List<cc_506_HumanGender> objs_cc_506_HumanGender = new List<cc_506_HumanGender>();
                sets[1] = new MapResultSet(typeof(cc_506_HumanGender), objs_cc_506_HumanGender);
                
                List<cc_506_Nationality> objs_cc_506_Nationality = new List<cc_506_Nationality>();
                sets[2] = new MapResultSet(typeof(cc_506_Nationality), objs_cc_506_Nationality);
                
                List<cc_506_OccupationType> objs_cc_506_OccupationType = new List<cc_506_OccupationType>();
                sets[3] = new MapResultSet(typeof(cc_506_OccupationType), objs_cc_506_OccupationType);
                
                List<cc_506_Outcome> objs_cc_506_Outcome = new List<cc_506_Outcome>();
                sets[4] = new MapResultSet(typeof(cc_506_Outcome), objs_cc_506_Outcome);
                
                List<cc_506_Diagnosis> objs_cc_506_Diagnosis = new List<cc_506_Diagnosis>();
                sets[5] = new MapResultSet(typeof(cc_506_Diagnosis), objs_cc_506_Diagnosis);
                
                List<cc_506_MaritalStatus> objs_cc_506_MaritalStatus = new List<cc_506_MaritalStatus>();
                sets[6] = new MapResultSet(typeof(cc_506_MaritalStatus), objs_cc_506_MaritalStatus);
                
                List<cc_506_ForeignerType> objs_cc_506_ForeignerType = new List<cc_506_ForeignerType>();
                sets[7] = new MapResultSet(typeof(cc_506_ForeignerType), objs_cc_506_ForeignerType);
                
                List<cc_506_Municipality> objs_cc_506_Municipality = new List<cc_506_Municipality>();
                sets[8] = new MapResultSet(typeof(cc_506_Municipality), objs_cc_506_Municipality);
                
                List<cc_506_Hospitalization> objs_cc_506_Hospitalization = new List<cc_506_Hospitalization>();
                sets[9] = new MapResultSet(typeof(cc_506_Hospitalization), objs_cc_506_Hospitalization);
                
                List<cc_506_PatientType> objs_cc_506_PatientType = new List<cc_506_PatientType>();
                sets[10] = new MapResultSet(typeof(cc_506_PatientType), objs_cc_506_PatientType);
                
                List<cc_506_Complication> objs_cc_506_Complication = new List<cc_506_Complication>();
                sets[11] = new MapResultSet(typeof(cc_506_Complication), objs_cc_506_Complication);
                Upload506Master obj = null;
                try
                {
                    manager
                        .SetSpCommand("spUpload506Master_SelectDetail"
                            , manager.Parameter("@idfsUpload506", idfsUpload506)
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    obj = objs[0];
                    obj.m_CS = m_CS;
                    
                  
                    if (loading != null)
                        loading(obj);

                    //_SetupRefs(sets, obj);

                    _SetupLoad(manager, obj);
                    
                    obj.HumanGenderRefs.ForEach(c => HumanGenderRefsAccessor._SetupLoad(manager, c));
                            
                    obj.NationalityRefs.ForEach(c => NationalityRefsAccessor._SetupLoad(manager, c));
                            
                    obj.OccupationTypeRefs.ForEach(c => OccupationTypeRefsAccessor._SetupLoad(manager, c));
                            
                    obj.OutcomeRefs.ForEach(c => OutcomeRefsAccessor._SetupLoad(manager, c));
                            
                    obj.DiagnosisRefs.ForEach(c => DiagnosisRefsAccessor._SetupLoad(manager, c));
                            
                    obj.MaritalStatusRefs.ForEach(c => MaritalStatusRefsAccessor._SetupLoad(manager, c));
                            
                    obj.ForeignerTypeRefs.ForEach(c => ForeignerTypeRefsAccessor._SetupLoad(manager, c));
                            
                    obj.MunicipalityRefs.ForEach(c => MunicipalityRefsAccessor._SetupLoad(manager, c));
                            
                    obj.HospitalizationRefs.ForEach(c => HospitalizationRefsAccessor._SetupLoad(manager, c));
                            
                    obj.PatientTypeRefs.ForEach(c => PatientTypeRefsAccessor._SetupLoad(manager, c));
                            
                    obj.ComplicationRefs.ForEach(c => ComplicationRefsAccessor._SetupLoad(manager, c));
                            

                    //obj._setParent();
                    if (loaded != null)
                    loaded(obj);
                    obj.Loaded(manager);
                    return obj;
                  }
                  catch(DataException e)
                  {
                    throw DbModelException.Create(obj, e);
                  }
                
            }

            private void _SetupRefs(MapResultSet[] sets, Upload506Master obj)
            {
                obj.HumanGenderRefs.AddRange((IList)sets[1].List);
                obj.NationalityRefs.AddRange((IList)sets[2].List);
                obj.OccupationTypeRefs.AddRange((IList)sets[3].List);
                obj.OutcomeRefs.AddRange((IList)sets[4].List);
                obj.DiagnosisRefs.AddRange((IList)sets[5].List);
                obj.MaritalStatusRefs.AddRange((IList)sets[6].List);
                obj.ForeignerTypeRefs.AddRange((IList)sets[7].List);
                obj.MunicipalityRefs.AddRange((IList)sets[8].List);
                obj.HospitalizationRefs.AddRange((IList)sets[9].List);
                obj.PatientTypeRefs.AddRange((IList)sets[10].List);
                obj.ComplicationRefs.AddRange((IList)sets[11].List);
            }
    
            private void _SetupAddChildHandlerItems(Upload506Master obj)
            {
                obj.Items.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            private void _SetupAddChildHandlerDuplicates(Upload506Master obj)
            {
                obj.Duplicates.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            private void _SetupAddChildHandlerHumanGenderRefs(Upload506Master obj)
            {
                obj.HumanGenderRefs.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            private void _SetupAddChildHandlerNationalityRefs(Upload506Master obj)
            {
                obj.NationalityRefs.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            private void _SetupAddChildHandlerOccupationTypeRefs(Upload506Master obj)
            {
                obj.OccupationTypeRefs.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            private void _SetupAddChildHandlerOutcomeRefs(Upload506Master obj)
            {
                obj.OutcomeRefs.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            private void _SetupAddChildHandlerDiagnosisRefs(Upload506Master obj)
            {
                obj.DiagnosisRefs.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            private void _SetupAddChildHandlerMaritalStatusRefs(Upload506Master obj)
            {
                obj.MaritalStatusRefs.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            private void _SetupAddChildHandlerForeignerTypeRefs(Upload506Master obj)
            {
                obj.ForeignerTypeRefs.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            private void _SetupAddChildHandlerMunicipalityRefs(Upload506Master obj)
            {
                obj.MunicipalityRefs.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            private void _SetupAddChildHandlerHospitalizationRefs(Upload506Master obj)
            {
                obj.HospitalizationRefs.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            private void _SetupAddChildHandlerPatientTypeRefs(Upload506Master obj)
            {
                obj.PatientTypeRefs.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            private void _SetupAddChildHandlerComplicationRefs(Upload506Master obj)
            {
                obj.ComplicationRefs.CollectionChanged += delegate(object sender, NotifyCollectionChangedEventArgs e)
                {
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach(var o in e.NewItems)
                        {
                            _SetupChildHandlers(obj, o);
                        }
                    }
                };
            }
            
            internal void _LoadItems(Upload506Master obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadItems(manager, obj);
                }
            }
            internal void _LoadItems(DbManagerProxy manager, Upload506Master obj)
            {
              
                obj.Items.Clear();
                obj.Items.AddRange(ItemsAccessor.SelectDetailList(manager
                    
                    , obj.idfsUpload506
                    ));
                obj.Items.ForEach(c => c.m_ObjectName = _str_Items);
                obj.Items.AcceptChanges();
                    
              }
            
            internal void _LoadDuplicates(Upload506Master obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    _LoadDuplicates(manager, obj);
                }
            }
            internal void _LoadDuplicates(DbManagerProxy manager, Upload506Master obj)
            {
              
                obj.Duplicates.Clear();
                obj.Duplicates.AddRange(DuplicatesAccessor.SelectDetailList(manager
                    
                    , obj.idfsUpload506
                    ));
                obj.Duplicates.ForEach(c => c.m_ObjectName = _str_Duplicates);
                obj.Duplicates.AcceptChanges();
                    
              }
            
        
        
            internal void _SetupLoad(DbManagerProxy manager, Upload506Master obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                _LoadItems(manager, obj);
                _LoadDuplicates(manager, obj);
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetupAddChildHandlerItems(obj);
                
                _SetupAddChildHandlerDuplicates(obj);
                
                _SetupAddChildHandlerHumanGenderRefs(obj);
                
                _SetupAddChildHandlerNationalityRefs(obj);
                
                _SetupAddChildHandlerOccupationTypeRefs(obj);
                
                _SetupAddChildHandlerOutcomeRefs(obj);
                
                _SetupAddChildHandlerDiagnosisRefs(obj);
                
                _SetupAddChildHandlerMaritalStatusRefs(obj);
                
                _SetupAddChildHandlerForeignerTypeRefs(obj);
                
                _SetupAddChildHandlerMunicipalityRefs(obj);
                
                _SetupAddChildHandlerHospitalizationRefs(obj);
                
                _SetupAddChildHandlerPatientTypeRefs(obj);
                
                _SetupAddChildHandlerComplicationRefs(obj);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, Upload506Master obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                        obj.Items.ForEach(c => ItemsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.Duplicates.ForEach(c => DuplicatesAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.HumanGenderRefs.ForEach(c => HumanGenderRefsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.NationalityRefs.ForEach(c => NationalityRefsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.OccupationTypeRefs.ForEach(c => OccupationTypeRefsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.OutcomeRefs.ForEach(c => OutcomeRefsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.DiagnosisRefs.ForEach(c => DiagnosisRefsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.MaritalStatusRefs.ForEach(c => MaritalStatusRefsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.ForeignerTypeRefs.ForEach(c => ForeignerTypeRefsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.MunicipalityRefs.ForEach(c => MunicipalityRefsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.HospitalizationRefs.ForEach(c => HospitalizationRefsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.PatientTypeRefs.ForEach(c => PatientTypeRefsAccessor._SetPermitions(obj._permissions, c));
                    
                        obj.ComplicationRefs.ForEach(c => ComplicationRefsAccessor._SetPermitions(obj._permissions, c));
                    
                    }
                }
            }

    

            private Upload506Master _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                Upload506Master obj = null;
                try
                {
                    obj = Upload506Master.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
              obj = SelectByKey(manager, GetNewIDExtender<Upload506Master>.getNewId(manager));
              obj.Items.Clear();
            
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    _SetupAddChildHandlerItems(obj);
                    
                    _SetupAddChildHandlerDuplicates(obj);
                    
                    _SetupAddChildHandlerHumanGenderRefs(obj);
                    
                    _SetupAddChildHandlerNationalityRefs(obj);
                    
                    _SetupAddChildHandlerOccupationTypeRefs(obj);
                    
                    _SetupAddChildHandlerOutcomeRefs(obj);
                    
                    _SetupAddChildHandlerDiagnosisRefs(obj);
                    
                    _SetupAddChildHandlerMaritalStatusRefs(obj);
                    
                    _SetupAddChildHandlerForeignerTypeRefs(obj);
                    
                    _SetupAddChildHandlerMunicipalityRefs(obj);
                    
                    _SetupAddChildHandlerHospitalizationRefs(obj);
                    
                    _SetupAddChildHandlerPatientTypeRefs(obj);
                    
                    _SetupAddChildHandlerComplicationRefs(obj);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
              if (EidssUserContext.Instance != null)
                if (EidssUserContext.User != null)
                {                             
                  if (EidssUserContext.User.EmployeeID != null)
                  {
                    long em;
                    if (long.TryParse(EidssUserContext.User.EmployeeID.ToString(), out em))
                      obj.idfPersonEnteredBy = em;
                  }
                  if (EidssUserContext.User.ID != null)
                  {
                    long em;
                    if (long.TryParse(EidssUserContext.User.ID.ToString(), out em))
                      obj.idfUserID = em;
                  }
                }                        
            
                    // created extenters - end
        
                    if (created != null)
                        created(obj);
                    obj.Created(manager);
                    _SetPermitions(obj._permissions, obj);
                    _SetupRequired(obj);
                    _SetupPersonalDataRestrictions(obj);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public Upload506Master CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public Upload506Master CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public Upload506Master CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(Upload506Master obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(Upload506Master obj)
            {
                
            }
    
            public void LoadLookup_Diagnosis(DbManagerProxy manager, Upload506Master obj)
            {
                
                obj.DiagnosisLookup.Clear();
                
                obj.DiagnosisLookup.Add(DiagnosisAccessor.CreateNewT(manager, null));
                
                obj.DiagnosisLookup.AddRange(DiagnosisAccessor.SelectLookupList(manager
                    
                    )
                    .Where(c => (c.intHACode & (int)HACode.Human) != 0)
                        
                    .Where(c => c.idfsUsingType == (long)DiagnosisUsingTypeEnum.StandardCase)
                        
                    .Where(c => (c.intRowStatus == 0) || (c.idfsDiagnosis == obj.idfsDiagnosis))
                    
                    .ToList());
                
                if (obj.idfsDiagnosis != null && obj.idfsDiagnosis != 0)
                {
                    obj.Diagnosis = obj.DiagnosisLookup
                        .SingleOrDefault(c => c.idfsDiagnosis == obj.idfsDiagnosis);
                    
                }
              
                LookupManager.AddObject("DiagnosisLookup", obj, DiagnosisAccessor.GetType(), "_SelectListInternal");
                obj.bNeedLookupRemove = true;
              
            }
            

            internal void _LoadLookups(DbManagerProxy manager, Upload506Master obj)
            {
                
                LoadLookup_Diagnosis(manager, obj);
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            [SprocName("spUpload506Master_Post")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput()] Upload506Master obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput()] Upload506Master obj)
            {
                
                _post(manager, obj);
                
            }
            
            
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false)
            {
                bool bSuccess = false;
                int iDeadlockAttemptsCount = BaseSettings.DeadlockAttemptsCount;
                for (int iAttemptNumber = 0; iAttemptNumber < iDeadlockAttemptsCount; iAttemptNumber++)
                {
                    bool bTransactionStarted = false;
                    try
                    {
                        Upload506Master bo = obj as Upload506Master;
                        
                        if (!bo.IsNew && bo.IsMarkedToDelete) // delete
                        {
                        }
                        else if (bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            
                        }
                        else if (!bo.IsMarkedToDelete) // update
                        {
                            
                        }

                        if (!manager.IsTransactionStarted)
                        {
                            
                            bTransactionStarted = true;
                            manager.BeginTransaction();
                        }
                        bSuccess = _PostNonTransaction(manager, obj as Upload506Master, bChildObject);
                        if (bTransactionStarted)
                        {
                            if (bSuccess)
                            {
                                obj.DeepAcceptChanges();
                                manager.CommitTransaction();
                                
                            }
                            else
                            {
                                manager.RollbackTransaction();
                            }
                            
                        }
                        if (bSuccess && bo.IsNew && !bo.IsMarkedToDelete) // insert
                        {
                            bo.m_IsNew = false;
                        }
                        if (bSuccess && bTransactionStarted)
                        {
                            bo.OnAfterPost();
                        }
                        
                        break;
                    }
                    catch(Exception e)
                    {
                        if (bTransactionStarted)
                        {
                            manager.RollbackTransaction();
                            
                            if (DbModelException.IsDeadlockException(e))
                            {
                                System.Threading.Thread.Sleep(BaseSettings.DeadlockDelay);
                                continue;
                            }
                        }
                    
                        if (e is DataException)
                        {
                            throw DbModelException.Create(obj, e as DataException);
                        }
                        if (e is System.Data.SqlClient.SqlException)
                        {
                            throw DbModelException.Create(obj, e as System.Data.SqlClient.SqlException);
                        }
                        else 
                            throw;
                    }
                }
                return bSuccess;
            }
            private bool _PostNonTransaction(DbManagerProxy manager, Upload506Master obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (obj.Items != null)
                    {
                        foreach (var i in obj.Items)
                        {
                            i.MarkToDelete();
                            if (!ItemsAccessor.Post(manager, i, true))
                                return false;
                        }
                    }
                                            
                    if (!ValidateCanDelete(manager, obj)) return false;
                                        
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                obj.intDummy = new Func<Upload506Master, DbManagerProxy, int>((c,m) => m.SetCommand(@"
DECLARE @drop_cmd NVARCHAR(4000)
IF OBJECT_ID('tempdb..#R506') is not null
BEGIN
	SET @drop_cmd = N'drop table #R506'
	EXECUTE sp_executesql @drop_cmd
END
CREATE TABLE #R506(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[E0] [int] NULL,
	[E1] [int] NULL,
	[PE0] [int] NULL,
	[PE1] [int] NULL,
	[DISEASE] [nvarchar](255) NULL,
	[iDISEASE] [bigint] NULL,
	[HN] [nvarchar](255) NULL,
	[NAME] [nvarchar](255) NULL,
	[SEX] [int] NULL,
	[YEAR] [int] NULL,
	[MONTH] [int] NULL,
	[DAY] [int] NULL,
	[RACE] [int] NULL,
	[OCCUPAT] [int] NULL,
	[ADDRESS] [nvarchar](255) NULL,
	[ADDRCODE] [nvarchar](255) COLLATE Cyrillic_General_CI_AS NULL,
	[PROVINCE] [nvarchar](255) COLLATE Cyrillic_General_CI_AS NULL,
	[TYPE] [int] NULL,
	[RESULT] [int] NULL,
	[HSERV] [nvarchar](255) COLLATE Cyrillic_General_CI_AS NULL,
	[SCHOOL] [nvarchar](255) NULL,
	[DATESICK] [datetime] NULL,
	[DATEDEFINE] [datetime] NULL,
	[DATEDEATH] [datetime] NULL,
	[DATERECORD] [datetime] NULL,
	--[DATEREACH] [datetime] NULL,
	--[ORGANISM] [nvarchar](255) NULL,
	[COMPLICA] [nvarchar](255) NULL,
	[iCOMPLICA] [bigint] NULL,
	[MARIETAL] [int] NULL,
	[RACE1] [int] NULL,
	[METROPOL] [int] NULL,
	[HOSPITAL] [int] NULL,
	idfsUpload506Item BIGINT NULL,
	idfHumanCase BIGINT NULL,
	strCaseID NVARCHAR(255) NULL,
	Resolution int
) 
").ExecuteNonQuery())(obj, manager);
                    // posting extenters - end
            
                    if (obj.IsNew)
                    {
                        if (obj.Items != null) // forced load potential lazy subobject for new object
                        {
                            foreach (var i in obj.Items)
                                if (!ItemsAccessor.Post(manager, i, true))
                                    return false;
                            obj.Items.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj.Items.Remove(c));
                            obj.Items.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (obj._Items != null) // do not load lazy subobject for existing object
                        {
                            foreach (var i in obj._Items)
                                if (!ItemsAccessor.Post(manager, i, true))
                                    return false;
                            obj._Items.Where(c => c.IsMarkedToDelete).ToList().ForEach(c => obj._Items.Remove(c));
                            obj._Items.AcceptChanges();
                        }
                    }
                                    
                    if (!obj.IsMarkedToDelete && bHasChanges)
                        _postPredicate(manager, obj);
                                    
                    // posted extenters - begin
              var items = new Dictionary<long, Upload506Item>();
              obj.Items.ForEach(c => items.Add(c.idfsUpload506Item, c));
              var result = manager.SetCommand("select idfHumanCase, idfsUpload506Item, strCaseID from #R506").ExecuteList<Upload506AfterPostItem>();
              result.ForEach(c => { var i = items[c.idfsUpload506Item]; i.idfCase = c.idfHumanCase; i.strCaseID = c.strCaseID; } );
              
              obj.SetState(Upload506MasterState.Saved);
              
              obj.m_resultFile = new MemoryStream();
			        obj.WriteResultToStream(obj.m_resultFile);
            
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(Upload506Master obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, Upload506Master obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(Upload506Master obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(Upload506Master obj, bool bRethrowException)
            {
                ValidationModelException ex = ChainsValidate(obj);
                if (ex != null)
                {
                    if (bRethrowException)
                        throw ex;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                return true;
            }
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as Upload506Master, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Upload506Master obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(Upload506Master obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(Upload506Master obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as Upload506Master) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as Upload506Master) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "Upload506MasterDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spUpload506Master_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spUpload506Master_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<Upload506Master, bool>> RequiredByField = new Dictionary<string, Func<Upload506Master, bool>>();
            public static Dictionary<string, Func<Upload506Master, bool>> RequiredByProperty = new Dictionary<string, Func<Upload506Master, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            
            
    private static Dictionary<string, List<Func<bool>>> m_isHiddenPersonalData = new Dictionary<string, List<Func<bool>>>();
    internal static bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData.ContainsKey(name))
          return m_isHiddenPersonalData[name].Aggregate(false, (s,c) => s | c());
      return false;
    }

    private static void AddHiddenPersonalData(string name, Func<bool> func)
    {
      if (!m_isHiddenPersonalData.ContainsKey(name))
          m_isHiddenPersonalData.Add(name, new List<Func<bool>>());
      m_isHiddenPersonalData[name].Add(func);
    }
  
            
            static Meta()
            {
                
        
                _SetupPersonalDataRestrictions();
            }
            
            
    private static void _SetupPersonalDataRestrictions()
    {
    

    }
  
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class cc_506_HumanGender : 
        EditableObject<cc_506_HumanGender>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsHumanGender), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsHumanGender { get; set; }
                
        [LocalizedDisplayName(_str_SEX)]
        [MapField(_str_SEX)]
        public abstract Int64 SEX { get; set; }
        protected Int64 SEX_Original { get { return ((EditableValue<Int64>)((dynamic)this)._sEX).OriginalValue; } }
        protected Int64 SEX_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._sEX).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsUpload506)]
        [MapField(_str_idfsUpload506)]
        public abstract Int64 idfsUpload506 { get; set; }
        protected Int64 idfsUpload506_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).OriginalValue; } }
        protected Int64 idfsUpload506_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<cc_506_HumanGender, object> _get_func;
            internal Action<cc_506_HumanGender, string> _set_func;
            internal Action<cc_506_HumanGender, cc_506_HumanGender, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsHumanGender = "idfsHumanGender";
        internal const string _str_SEX = "SEX";
        internal const string _str_idfsUpload506 = "idfsUpload506";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsHumanGender, _formname = _str_idfsHumanGender, _type = "Int64",
              _get_func = o => o.idfsHumanGender,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsHumanGender != newval) o.idfsHumanGender = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsHumanGender != c.idfsHumanGender || o.IsRIRPropChanged(_str_idfsHumanGender, c)) 
                  m.Add(_str_idfsHumanGender, o.ObjectIdent + _str_idfsHumanGender, o.ObjectIdent2 + _str_idfsHumanGender, o.ObjectIdent3 + _str_idfsHumanGender, "Int64", 
                    o.idfsHumanGender == null ? "" : o.idfsHumanGender.ToString(),                  
                  o.IsReadOnly(_str_idfsHumanGender), o.IsInvisible(_str_idfsHumanGender), o.IsRequired(_str_idfsHumanGender)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_SEX, _formname = _str_SEX, _type = "Int64",
              _get_func = o => o.SEX,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.SEX != newval) o.SEX = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.SEX != c.SEX || o.IsRIRPropChanged(_str_SEX, c)) 
                  m.Add(_str_SEX, o.ObjectIdent + _str_SEX, o.ObjectIdent2 + _str_SEX, o.ObjectIdent3 + _str_SEX, "Int64", 
                    o.SEX == null ? "" : o.SEX.ToString(),                  
                  o.IsReadOnly(_str_SEX), o.IsInvisible(_str_SEX), o.IsRequired(_str_SEX)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsUpload506, _formname = _str_idfsUpload506, _type = "Int64",
              _get_func = o => o.idfsUpload506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsUpload506 != newval) o.idfsUpload506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsUpload506 != c.idfsUpload506 || o.IsRIRPropChanged(_str_idfsUpload506, c)) 
                  m.Add(_str_idfsUpload506, o.ObjectIdent + _str_idfsUpload506, o.ObjectIdent2 + _str_idfsUpload506, o.ObjectIdent3 + _str_idfsUpload506, "Int64", 
                    o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(),                  
                  o.IsReadOnly(_str_idfsUpload506), o.IsInvisible(_str_idfsUpload506), o.IsRequired(_str_idfsUpload506)); 
                  }
              }, 
        
            new field_info()
        };
        #endregion
        
        private string _getType(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? "" : i._type;
        }
        private object _getValue(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? null : i._get_func(this);
        }
        private void _setValue(string name, string val)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            if (i != null) i._set_func(this, val);
        }
        internal CompareModel _compare(IObject o, CompareModel ret)
        {
            if (ret == null) ret = new CompareModel();
            if (o == null) return ret;
            cc_506_HumanGender obj = (cc_506_HumanGender)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "cc_506_HumanGender";

        #region Parent and Clone supporting
        [XmlIgnore]
        public IObject Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; /*OnPropertyChanged(_str_Parent);*/ }
        }
        private IObject m_Parent;
        internal void _setParent()
        {
        
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as cc_506_HumanGender;
            ret.bIsClone = true;
            ret.Cloned();
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager, bool bRestricted = false)
        {
            var ret = base.Clone() as cc_506_HumanGender;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public cc_506_HumanGender CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as cc_506_HumanGender;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsHumanGender; } }
        public string KeyName { get { return "idfsHumanGender"; } }
        public object KeyLookup { get { return idfsHumanGender; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        [XmlIgnore]
        [LocalizedDisplayName("HasChanges")]
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                ;
            }
        }
        public new void RejectChanges()
        {
        
            base.RejectChanges();
        
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
        }
        private bool m_bForceDirty;
        public override void AcceptChanges()
        {
            m_bForceDirty = false;
            base.AcceptChanges();
        }
        [XmlIgnore]
        [LocalizedDisplayName("IsDirty")]
        public override bool IsDirty
        {
            get { return m_bForceDirty || base.IsDirty; }
        }
        public void SetChange()
        { 
            m_bForceDirty = true;
        }
        public void DeepSetChange()
        { 
            SetChange();
        
        }
        public bool MarkToDelete() { return _Delete(false); }
        public string ObjectName { get { return m_ObjectName; } }
        public string ObjectIdent { get { return ObjectName + "_" + Key.ToString() + "_"; } }
        
        public string ObjectIdent2 { get { return ObjectIdent; } }
          
        public string ObjectIdent3 { get { return ObjectIdent; } }
          
        public IObjectAccessor GetAccessor() { return _getAccessor(); }
        public IObjectPermissions GetPermissions() { return _permissions; }
        private IObjectEnvironment _environment;
        public IObjectEnvironment Environment { get { return _environment; } set { _environment = value; } }
        public bool IsValidObject { get { return _isValid; } }
        public bool ReadOnly { get { return _readOnly || !_isValid; } set { _readOnly = value; } }
        public bool IsReadOnly(string name) { return _isReadOnly(name); }
        public bool IsInvisible(string name) { return _isInvisible(name); }
        public bool IsRequired(string name) { return _isRequired(m_isRequired, name); }
        public bool IsHiddenPersonalData(string name) { return _isHiddenPersonalData(name); }
        public string GetType(string name) { return _getType(name); }
        public object GetValue(string name) { return _getValue(name); }
        public void SetValue(string name, string val) { _setValue(name, val); }
        public CompareModel Compare(IObject o) { return _compare(o, null); }
        public BvSelectList GetList(string name) { return _getList(name); }
        public event ValidationEvent Validation;
        public event ValidationEvent ValidationEnd;
        public event AfterPostEvent AfterPost;
      
        public Dictionary<string, string> GetFieldTags(string name)
        {
          return null;
        }
      #endregion

        private bool IsRIRPropChanged(string fld, cc_506_HumanGender c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, cc_506_HumanGender c)
        {
            var thisLookup = GetValue(fld + "Lookup") as IList;
            var thatLookup = c.GetValue(fld + "Lookup") as IList;
            bool bChangeLookupContent = thisLookup.Count != thatLookup.Count;
            if (!bChangeLookupContent)
            {
                for (int i = 0; i < thisLookup.Count; i++)
                {
                    if (((thisLookup[i] as IObject).Key as IComparable).CompareTo((thatLookup[i] as IObject).Key) != 0 &&
                        (thisLookup[i] as IObject).ToStringProp != null && ((thisLookup[i] as IObject).ToStringProp as IComparable).CompareTo((thatLookup[i] as IObject).ToStringProp) != 0)
                    {
                        bChangeLookupContent = true;
                        break;
                    }
                }
            }
            return bChangeLookupContent;
        }
        

      

        public cc_506_HumanGender()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(cc_506_HumanGender_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(cc_506_HumanGender_PropertyChanged);
        }
        private void cc_506_HumanGender_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as cc_506_HumanGender).Changed(e.PropertyName);
            
        }
        
        public bool ForceToDelete() { return _Delete(true); }
        internal bool _Delete(bool isForceDelete)
        {
            if (!_ValidateOnDelete()) return false;
            _DeletingExtenders();
            m_IsMarkedToDelete = true;
            m_IsForcedToDelete = m_IsForcedToDelete ? m_IsForcedToDelete : isForceDelete;
            OnPropertyChanged("IsMarkedToDelete");
            _DeletedExtenders();
            Deleted();
            return true;
        }
        private bool _ValidateOnDelete(bool bReport = true)
        {
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            cc_506_HumanGender obj = this;
            
        }
        private void _DeletedExtenders()
        {
            cc_506_HumanGender obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                ValidationEnd(this, args);
                return args.Continue;
            }
            return false;
        }

        public void OnAfterPost()
        {
            if (AfterPost != null)
            {
                AfterPost(this, EventArgs.Empty);
            }
        }

        public FormSize FormSize
        {
            get { return FormSize.Undefined; }
        }
    
        private bool _isInvisible(string name)
        {
            
            return false;
                
        }

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
            }
        }


        internal Dictionary<string, Func<cc_506_HumanGender, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<cc_506_HumanGender, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<cc_506_HumanGender, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<cc_506_HumanGender, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<cc_506_HumanGender, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<cc_506_HumanGender, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<cc_506_HumanGender, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        partial void Disposed();
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~cc_506_HumanGender()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                m_Parent = null;
                m_permissions = null;
                
                this.ClearModelObjEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                }
                Disposed();
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            ParsingFormCollection(form);
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<cc_506_HumanGender>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<cc_506_HumanGender>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<cc_506_HumanGender>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsHumanGender"; } }
            #endregion
        
            public delegate void on_action(cc_506_HumanGender obj);
            private static Accessor g_Instance = CreateInstance<Accessor>();
            private CacheScope m_CS;
            public static Accessor Instance(CacheScope cs) 
            { 
                if (cs == null)
                    return g_Instance;
                lock(cs)
                {
                    object acc = cs.Get(typeof (Accessor));
                    if (acc != null)
                    {
                        return acc as Accessor;
                    }
                    Accessor ret = CreateInstance<Accessor>();
                    ret.m_CS = cs;
                    cs.Add(typeof(Accessor), ret);
                    return ret;
                }
            }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }
            public virtual cc_506_HumanGender SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual cc_506_HumanGender SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                )
            {
                return _SelectByKey(manager
                    , idfsUpload506
                    , null, null
                    );
            }
            

            private cc_506_HumanGender _SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfsUpload506
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual cc_506_HumanGender _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, cc_506_HumanGender obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, cc_506_HumanGender obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private cc_506_HumanGender _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                cc_506_HumanGender obj = null;
                try
                {
                    obj = cc_506_HumanGender.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                    // created extenters - end
        
                    if (created != null)
                        created(obj);
                    obj.Created(manager);
                    _SetPermitions(obj._permissions, obj);
                    _SetupRequired(obj);
                    _SetupPersonalDataRestrictions(obj);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public cc_506_HumanGender CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public cc_506_HumanGender CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public cc_506_HumanGender CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(cc_506_HumanGender obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(cc_506_HumanGender obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, cc_506_HumanGender obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(cc_506_HumanGender obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(cc_506_HumanGender obj, bool bRethrowException)
            {
                ValidationModelException ex = ChainsValidate(obj);
                if (ex != null)
                {
                    if (bRethrowException)
                        throw ex;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                return true;
            }
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as cc_506_HumanGender, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, cc_506_HumanGender obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(cc_506_HumanGender obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(cc_506_HumanGender obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as cc_506_HumanGender) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as cc_506_HumanGender) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "cc_506_HumanGenderDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spUpload506Master_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<cc_506_HumanGender, bool>> RequiredByField = new Dictionary<string, Func<cc_506_HumanGender, bool>>();
            public static Dictionary<string, Func<cc_506_HumanGender, bool>> RequiredByProperty = new Dictionary<string, Func<cc_506_HumanGender, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            
            
    private static Dictionary<string, List<Func<bool>>> m_isHiddenPersonalData = new Dictionary<string, List<Func<bool>>>();
    internal static bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData.ContainsKey(name))
          return m_isHiddenPersonalData[name].Aggregate(false, (s,c) => s | c());
      return false;
    }

    private static void AddHiddenPersonalData(string name, Func<bool> func)
    {
      if (!m_isHiddenPersonalData.ContainsKey(name))
          m_isHiddenPersonalData.Add(name, new List<Func<bool>>());
      m_isHiddenPersonalData[name].Add(func);
    }
  
            
            static Meta()
            {
                
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, c, pars)),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_HumanGender>().Post(manager, (cc_506_HumanGender)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_HumanGender>().Post(manager, (cc_506_HumanGender)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Cancel",
                    ActionTypes.Cancel,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((cc_506_HumanGender)c).MarkToDelete() && ObjectAccessor.PostInterface<cc_506_HumanGender>().Post(manager, (cc_506_HumanGender)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
                      null,
                      null,
                      false
                      ));
                    
        
                _SetupPersonalDataRestrictions();
            }
            
            
    private static void _SetupPersonalDataRestrictions()
    {
    

    }
  
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class cc_506_Nationality : 
        EditableObject<cc_506_Nationality>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsNationality), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsNationality { get; set; }
                
        [LocalizedDisplayName(_str_RACE)]
        [MapField(_str_RACE)]
        public abstract Int64 RACE { get; set; }
        protected Int64 RACE_Original { get { return ((EditableValue<Int64>)((dynamic)this)._rACE).OriginalValue; } }
        protected Int64 RACE_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._rACE).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsUpload506)]
        [MapField(_str_idfsUpload506)]
        public abstract Int64 idfsUpload506 { get; set; }
        protected Int64 idfsUpload506_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).OriginalValue; } }
        protected Int64 idfsUpload506_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<cc_506_Nationality, object> _get_func;
            internal Action<cc_506_Nationality, string> _set_func;
            internal Action<cc_506_Nationality, cc_506_Nationality, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsNationality = "idfsNationality";
        internal const string _str_RACE = "RACE";
        internal const string _str_idfsUpload506 = "idfsUpload506";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsNationality, _formname = _str_idfsNationality, _type = "Int64",
              _get_func = o => o.idfsNationality,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsNationality != newval) o.idfsNationality = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsNationality != c.idfsNationality || o.IsRIRPropChanged(_str_idfsNationality, c)) 
                  m.Add(_str_idfsNationality, o.ObjectIdent + _str_idfsNationality, o.ObjectIdent2 + _str_idfsNationality, o.ObjectIdent3 + _str_idfsNationality, "Int64", 
                    o.idfsNationality == null ? "" : o.idfsNationality.ToString(),                  
                  o.IsReadOnly(_str_idfsNationality), o.IsInvisible(_str_idfsNationality), o.IsRequired(_str_idfsNationality)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_RACE, _formname = _str_RACE, _type = "Int64",
              _get_func = o => o.RACE,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.RACE != newval) o.RACE = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.RACE != c.RACE || o.IsRIRPropChanged(_str_RACE, c)) 
                  m.Add(_str_RACE, o.ObjectIdent + _str_RACE, o.ObjectIdent2 + _str_RACE, o.ObjectIdent3 + _str_RACE, "Int64", 
                    o.RACE == null ? "" : o.RACE.ToString(),                  
                  o.IsReadOnly(_str_RACE), o.IsInvisible(_str_RACE), o.IsRequired(_str_RACE)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsUpload506, _formname = _str_idfsUpload506, _type = "Int64",
              _get_func = o => o.idfsUpload506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsUpload506 != newval) o.idfsUpload506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsUpload506 != c.idfsUpload506 || o.IsRIRPropChanged(_str_idfsUpload506, c)) 
                  m.Add(_str_idfsUpload506, o.ObjectIdent + _str_idfsUpload506, o.ObjectIdent2 + _str_idfsUpload506, o.ObjectIdent3 + _str_idfsUpload506, "Int64", 
                    o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(),                  
                  o.IsReadOnly(_str_idfsUpload506), o.IsInvisible(_str_idfsUpload506), o.IsRequired(_str_idfsUpload506)); 
                  }
              }, 
        
            new field_info()
        };
        #endregion
        
        private string _getType(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? "" : i._type;
        }
        private object _getValue(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? null : i._get_func(this);
        }
        private void _setValue(string name, string val)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            if (i != null) i._set_func(this, val);
        }
        internal CompareModel _compare(IObject o, CompareModel ret)
        {
            if (ret == null) ret = new CompareModel();
            if (o == null) return ret;
            cc_506_Nationality obj = (cc_506_Nationality)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "cc_506_Nationality";

        #region Parent and Clone supporting
        [XmlIgnore]
        public IObject Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; /*OnPropertyChanged(_str_Parent);*/ }
        }
        private IObject m_Parent;
        internal void _setParent()
        {
        
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as cc_506_Nationality;
            ret.bIsClone = true;
            ret.Cloned();
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager, bool bRestricted = false)
        {
            var ret = base.Clone() as cc_506_Nationality;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public cc_506_Nationality CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as cc_506_Nationality;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsNationality; } }
        public string KeyName { get { return "idfsNationality"; } }
        public object KeyLookup { get { return idfsNationality; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        [XmlIgnore]
        [LocalizedDisplayName("HasChanges")]
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                ;
            }
        }
        public new void RejectChanges()
        {
        
            base.RejectChanges();
        
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
        }
        private bool m_bForceDirty;
        public override void AcceptChanges()
        {
            m_bForceDirty = false;
            base.AcceptChanges();
        }
        [XmlIgnore]
        [LocalizedDisplayName("IsDirty")]
        public override bool IsDirty
        {
            get { return m_bForceDirty || base.IsDirty; }
        }
        public void SetChange()
        { 
            m_bForceDirty = true;
        }
        public void DeepSetChange()
        { 
            SetChange();
        
        }
        public bool MarkToDelete() { return _Delete(false); }
        public string ObjectName { get { return m_ObjectName; } }
        public string ObjectIdent { get { return ObjectName + "_" + Key.ToString() + "_"; } }
        
        public string ObjectIdent2 { get { return ObjectIdent; } }
          
        public string ObjectIdent3 { get { return ObjectIdent; } }
          
        public IObjectAccessor GetAccessor() { return _getAccessor(); }
        public IObjectPermissions GetPermissions() { return _permissions; }
        private IObjectEnvironment _environment;
        public IObjectEnvironment Environment { get { return _environment; } set { _environment = value; } }
        public bool IsValidObject { get { return _isValid; } }
        public bool ReadOnly { get { return _readOnly || !_isValid; } set { _readOnly = value; } }
        public bool IsReadOnly(string name) { return _isReadOnly(name); }
        public bool IsInvisible(string name) { return _isInvisible(name); }
        public bool IsRequired(string name) { return _isRequired(m_isRequired, name); }
        public bool IsHiddenPersonalData(string name) { return _isHiddenPersonalData(name); }
        public string GetType(string name) { return _getType(name); }
        public object GetValue(string name) { return _getValue(name); }
        public void SetValue(string name, string val) { _setValue(name, val); }
        public CompareModel Compare(IObject o) { return _compare(o, null); }
        public BvSelectList GetList(string name) { return _getList(name); }
        public event ValidationEvent Validation;
        public event ValidationEvent ValidationEnd;
        public event AfterPostEvent AfterPost;
      
        public Dictionary<string, string> GetFieldTags(string name)
        {
          return null;
        }
      #endregion

        private bool IsRIRPropChanged(string fld, cc_506_Nationality c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, cc_506_Nationality c)
        {
            var thisLookup = GetValue(fld + "Lookup") as IList;
            var thatLookup = c.GetValue(fld + "Lookup") as IList;
            bool bChangeLookupContent = thisLookup.Count != thatLookup.Count;
            if (!bChangeLookupContent)
            {
                for (int i = 0; i < thisLookup.Count; i++)
                {
                    if (((thisLookup[i] as IObject).Key as IComparable).CompareTo((thatLookup[i] as IObject).Key) != 0 &&
                        (thisLookup[i] as IObject).ToStringProp != null && ((thisLookup[i] as IObject).ToStringProp as IComparable).CompareTo((thatLookup[i] as IObject).ToStringProp) != 0)
                    {
                        bChangeLookupContent = true;
                        break;
                    }
                }
            }
            return bChangeLookupContent;
        }
        

      

        public cc_506_Nationality()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(cc_506_Nationality_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(cc_506_Nationality_PropertyChanged);
        }
        private void cc_506_Nationality_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as cc_506_Nationality).Changed(e.PropertyName);
            
        }
        
        public bool ForceToDelete() { return _Delete(true); }
        internal bool _Delete(bool isForceDelete)
        {
            if (!_ValidateOnDelete()) return false;
            _DeletingExtenders();
            m_IsMarkedToDelete = true;
            m_IsForcedToDelete = m_IsForcedToDelete ? m_IsForcedToDelete : isForceDelete;
            OnPropertyChanged("IsMarkedToDelete");
            _DeletedExtenders();
            Deleted();
            return true;
        }
        private bool _ValidateOnDelete(bool bReport = true)
        {
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            cc_506_Nationality obj = this;
            
        }
        private void _DeletedExtenders()
        {
            cc_506_Nationality obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                ValidationEnd(this, args);
                return args.Continue;
            }
            return false;
        }

        public void OnAfterPost()
        {
            if (AfterPost != null)
            {
                AfterPost(this, EventArgs.Empty);
            }
        }

        public FormSize FormSize
        {
            get { return FormSize.Undefined; }
        }
    
        private bool _isInvisible(string name)
        {
            
            return false;
                
        }

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
            }
        }


        internal Dictionary<string, Func<cc_506_Nationality, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<cc_506_Nationality, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<cc_506_Nationality, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<cc_506_Nationality, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<cc_506_Nationality, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<cc_506_Nationality, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<cc_506_Nationality, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        partial void Disposed();
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~cc_506_Nationality()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                m_Parent = null;
                m_permissions = null;
                
                this.ClearModelObjEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                }
                Disposed();
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            ParsingFormCollection(form);
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<cc_506_Nationality>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<cc_506_Nationality>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<cc_506_Nationality>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsNationality"; } }
            #endregion
        
            public delegate void on_action(cc_506_Nationality obj);
            private static Accessor g_Instance = CreateInstance<Accessor>();
            private CacheScope m_CS;
            public static Accessor Instance(CacheScope cs) 
            { 
                if (cs == null)
                    return g_Instance;
                lock(cs)
                {
                    object acc = cs.Get(typeof (Accessor));
                    if (acc != null)
                    {
                        return acc as Accessor;
                    }
                    Accessor ret = CreateInstance<Accessor>();
                    ret.m_CS = cs;
                    cs.Add(typeof(Accessor), ret);
                    return ret;
                }
            }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }
            public virtual cc_506_Nationality SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual cc_506_Nationality SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                )
            {
                return _SelectByKey(manager
                    , idfsUpload506
                    , null, null
                    );
            }
            

            private cc_506_Nationality _SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfsUpload506
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual cc_506_Nationality _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, cc_506_Nationality obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, cc_506_Nationality obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private cc_506_Nationality _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                cc_506_Nationality obj = null;
                try
                {
                    obj = cc_506_Nationality.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                    // created extenters - end
        
                    if (created != null)
                        created(obj);
                    obj.Created(manager);
                    _SetPermitions(obj._permissions, obj);
                    _SetupRequired(obj);
                    _SetupPersonalDataRestrictions(obj);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public cc_506_Nationality CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public cc_506_Nationality CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public cc_506_Nationality CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(cc_506_Nationality obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(cc_506_Nationality obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, cc_506_Nationality obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(cc_506_Nationality obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(cc_506_Nationality obj, bool bRethrowException)
            {
                ValidationModelException ex = ChainsValidate(obj);
                if (ex != null)
                {
                    if (bRethrowException)
                        throw ex;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                return true;
            }
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as cc_506_Nationality, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, cc_506_Nationality obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(cc_506_Nationality obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(cc_506_Nationality obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as cc_506_Nationality) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as cc_506_Nationality) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "cc_506_NationalityDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spUpload506Master_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<cc_506_Nationality, bool>> RequiredByField = new Dictionary<string, Func<cc_506_Nationality, bool>>();
            public static Dictionary<string, Func<cc_506_Nationality, bool>> RequiredByProperty = new Dictionary<string, Func<cc_506_Nationality, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            
            
    private static Dictionary<string, List<Func<bool>>> m_isHiddenPersonalData = new Dictionary<string, List<Func<bool>>>();
    internal static bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData.ContainsKey(name))
          return m_isHiddenPersonalData[name].Aggregate(false, (s,c) => s | c());
      return false;
    }

    private static void AddHiddenPersonalData(string name, Func<bool> func)
    {
      if (!m_isHiddenPersonalData.ContainsKey(name))
          m_isHiddenPersonalData.Add(name, new List<Func<bool>>());
      m_isHiddenPersonalData[name].Add(func);
    }
  
            
            static Meta()
            {
                
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, c, pars)),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_Nationality>().Post(manager, (cc_506_Nationality)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_Nationality>().Post(manager, (cc_506_Nationality)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Cancel",
                    ActionTypes.Cancel,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((cc_506_Nationality)c).MarkToDelete() && ObjectAccessor.PostInterface<cc_506_Nationality>().Post(manager, (cc_506_Nationality)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
                      null,
                      null,
                      false
                      ));
                    
        
                _SetupPersonalDataRestrictions();
            }
            
            
    private static void _SetupPersonalDataRestrictions()
    {
    

    }
  
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class cc_506_OccupationType : 
        EditableObject<cc_506_OccupationType>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsOccupationType), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsOccupationType { get; set; }
                
        [LocalizedDisplayName(_str_OCCUPAT)]
        [MapField(_str_OCCUPAT)]
        public abstract Int64 OCCUPAT { get; set; }
        protected Int64 OCCUPAT_Original { get { return ((EditableValue<Int64>)((dynamic)this)._oCCUPAT).OriginalValue; } }
        protected Int64 OCCUPAT_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._oCCUPAT).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsUpload506)]
        [MapField(_str_idfsUpload506)]
        public abstract Int64 idfsUpload506 { get; set; }
        protected Int64 idfsUpload506_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).OriginalValue; } }
        protected Int64 idfsUpload506_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<cc_506_OccupationType, object> _get_func;
            internal Action<cc_506_OccupationType, string> _set_func;
            internal Action<cc_506_OccupationType, cc_506_OccupationType, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsOccupationType = "idfsOccupationType";
        internal const string _str_OCCUPAT = "OCCUPAT";
        internal const string _str_idfsUpload506 = "idfsUpload506";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsOccupationType, _formname = _str_idfsOccupationType, _type = "Int64",
              _get_func = o => o.idfsOccupationType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsOccupationType != newval) o.idfsOccupationType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsOccupationType != c.idfsOccupationType || o.IsRIRPropChanged(_str_idfsOccupationType, c)) 
                  m.Add(_str_idfsOccupationType, o.ObjectIdent + _str_idfsOccupationType, o.ObjectIdent2 + _str_idfsOccupationType, o.ObjectIdent3 + _str_idfsOccupationType, "Int64", 
                    o.idfsOccupationType == null ? "" : o.idfsOccupationType.ToString(),                  
                  o.IsReadOnly(_str_idfsOccupationType), o.IsInvisible(_str_idfsOccupationType), o.IsRequired(_str_idfsOccupationType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_OCCUPAT, _formname = _str_OCCUPAT, _type = "Int64",
              _get_func = o => o.OCCUPAT,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.OCCUPAT != newval) o.OCCUPAT = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.OCCUPAT != c.OCCUPAT || o.IsRIRPropChanged(_str_OCCUPAT, c)) 
                  m.Add(_str_OCCUPAT, o.ObjectIdent + _str_OCCUPAT, o.ObjectIdent2 + _str_OCCUPAT, o.ObjectIdent3 + _str_OCCUPAT, "Int64", 
                    o.OCCUPAT == null ? "" : o.OCCUPAT.ToString(),                  
                  o.IsReadOnly(_str_OCCUPAT), o.IsInvisible(_str_OCCUPAT), o.IsRequired(_str_OCCUPAT)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsUpload506, _formname = _str_idfsUpload506, _type = "Int64",
              _get_func = o => o.idfsUpload506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsUpload506 != newval) o.idfsUpload506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsUpload506 != c.idfsUpload506 || o.IsRIRPropChanged(_str_idfsUpload506, c)) 
                  m.Add(_str_idfsUpload506, o.ObjectIdent + _str_idfsUpload506, o.ObjectIdent2 + _str_idfsUpload506, o.ObjectIdent3 + _str_idfsUpload506, "Int64", 
                    o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(),                  
                  o.IsReadOnly(_str_idfsUpload506), o.IsInvisible(_str_idfsUpload506), o.IsRequired(_str_idfsUpload506)); 
                  }
              }, 
        
            new field_info()
        };
        #endregion
        
        private string _getType(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? "" : i._type;
        }
        private object _getValue(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? null : i._get_func(this);
        }
        private void _setValue(string name, string val)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            if (i != null) i._set_func(this, val);
        }
        internal CompareModel _compare(IObject o, CompareModel ret)
        {
            if (ret == null) ret = new CompareModel();
            if (o == null) return ret;
            cc_506_OccupationType obj = (cc_506_OccupationType)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "cc_506_OccupationType";

        #region Parent and Clone supporting
        [XmlIgnore]
        public IObject Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; /*OnPropertyChanged(_str_Parent);*/ }
        }
        private IObject m_Parent;
        internal void _setParent()
        {
        
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as cc_506_OccupationType;
            ret.bIsClone = true;
            ret.Cloned();
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager, bool bRestricted = false)
        {
            var ret = base.Clone() as cc_506_OccupationType;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public cc_506_OccupationType CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as cc_506_OccupationType;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsOccupationType; } }
        public string KeyName { get { return "idfsOccupationType"; } }
        public object KeyLookup { get { return idfsOccupationType; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        [XmlIgnore]
        [LocalizedDisplayName("HasChanges")]
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                ;
            }
        }
        public new void RejectChanges()
        {
        
            base.RejectChanges();
        
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
        }
        private bool m_bForceDirty;
        public override void AcceptChanges()
        {
            m_bForceDirty = false;
            base.AcceptChanges();
        }
        [XmlIgnore]
        [LocalizedDisplayName("IsDirty")]
        public override bool IsDirty
        {
            get { return m_bForceDirty || base.IsDirty; }
        }
        public void SetChange()
        { 
            m_bForceDirty = true;
        }
        public void DeepSetChange()
        { 
            SetChange();
        
        }
        public bool MarkToDelete() { return _Delete(false); }
        public string ObjectName { get { return m_ObjectName; } }
        public string ObjectIdent { get { return ObjectName + "_" + Key.ToString() + "_"; } }
        
        public string ObjectIdent2 { get { return ObjectIdent; } }
          
        public string ObjectIdent3 { get { return ObjectIdent; } }
          
        public IObjectAccessor GetAccessor() { return _getAccessor(); }
        public IObjectPermissions GetPermissions() { return _permissions; }
        private IObjectEnvironment _environment;
        public IObjectEnvironment Environment { get { return _environment; } set { _environment = value; } }
        public bool IsValidObject { get { return _isValid; } }
        public bool ReadOnly { get { return _readOnly || !_isValid; } set { _readOnly = value; } }
        public bool IsReadOnly(string name) { return _isReadOnly(name); }
        public bool IsInvisible(string name) { return _isInvisible(name); }
        public bool IsRequired(string name) { return _isRequired(m_isRequired, name); }
        public bool IsHiddenPersonalData(string name) { return _isHiddenPersonalData(name); }
        public string GetType(string name) { return _getType(name); }
        public object GetValue(string name) { return _getValue(name); }
        public void SetValue(string name, string val) { _setValue(name, val); }
        public CompareModel Compare(IObject o) { return _compare(o, null); }
        public BvSelectList GetList(string name) { return _getList(name); }
        public event ValidationEvent Validation;
        public event ValidationEvent ValidationEnd;
        public event AfterPostEvent AfterPost;
      
        public Dictionary<string, string> GetFieldTags(string name)
        {
          return null;
        }
      #endregion

        private bool IsRIRPropChanged(string fld, cc_506_OccupationType c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, cc_506_OccupationType c)
        {
            var thisLookup = GetValue(fld + "Lookup") as IList;
            var thatLookup = c.GetValue(fld + "Lookup") as IList;
            bool bChangeLookupContent = thisLookup.Count != thatLookup.Count;
            if (!bChangeLookupContent)
            {
                for (int i = 0; i < thisLookup.Count; i++)
                {
                    if (((thisLookup[i] as IObject).Key as IComparable).CompareTo((thatLookup[i] as IObject).Key) != 0 &&
                        (thisLookup[i] as IObject).ToStringProp != null && ((thisLookup[i] as IObject).ToStringProp as IComparable).CompareTo((thatLookup[i] as IObject).ToStringProp) != 0)
                    {
                        bChangeLookupContent = true;
                        break;
                    }
                }
            }
            return bChangeLookupContent;
        }
        

      

        public cc_506_OccupationType()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(cc_506_OccupationType_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(cc_506_OccupationType_PropertyChanged);
        }
        private void cc_506_OccupationType_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as cc_506_OccupationType).Changed(e.PropertyName);
            
        }
        
        public bool ForceToDelete() { return _Delete(true); }
        internal bool _Delete(bool isForceDelete)
        {
            if (!_ValidateOnDelete()) return false;
            _DeletingExtenders();
            m_IsMarkedToDelete = true;
            m_IsForcedToDelete = m_IsForcedToDelete ? m_IsForcedToDelete : isForceDelete;
            OnPropertyChanged("IsMarkedToDelete");
            _DeletedExtenders();
            Deleted();
            return true;
        }
        private bool _ValidateOnDelete(bool bReport = true)
        {
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            cc_506_OccupationType obj = this;
            
        }
        private void _DeletedExtenders()
        {
            cc_506_OccupationType obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                ValidationEnd(this, args);
                return args.Continue;
            }
            return false;
        }

        public void OnAfterPost()
        {
            if (AfterPost != null)
            {
                AfterPost(this, EventArgs.Empty);
            }
        }

        public FormSize FormSize
        {
            get { return FormSize.Undefined; }
        }
    
        private bool _isInvisible(string name)
        {
            
            return false;
                
        }

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
            }
        }


        internal Dictionary<string, Func<cc_506_OccupationType, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<cc_506_OccupationType, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<cc_506_OccupationType, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<cc_506_OccupationType, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<cc_506_OccupationType, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<cc_506_OccupationType, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<cc_506_OccupationType, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        partial void Disposed();
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~cc_506_OccupationType()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                m_Parent = null;
                m_permissions = null;
                
                this.ClearModelObjEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                }
                Disposed();
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            ParsingFormCollection(form);
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<cc_506_OccupationType>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<cc_506_OccupationType>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<cc_506_OccupationType>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsOccupationType"; } }
            #endregion
        
            public delegate void on_action(cc_506_OccupationType obj);
            private static Accessor g_Instance = CreateInstance<Accessor>();
            private CacheScope m_CS;
            public static Accessor Instance(CacheScope cs) 
            { 
                if (cs == null)
                    return g_Instance;
                lock(cs)
                {
                    object acc = cs.Get(typeof (Accessor));
                    if (acc != null)
                    {
                        return acc as Accessor;
                    }
                    Accessor ret = CreateInstance<Accessor>();
                    ret.m_CS = cs;
                    cs.Add(typeof(Accessor), ret);
                    return ret;
                }
            }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }
            public virtual cc_506_OccupationType SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual cc_506_OccupationType SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                )
            {
                return _SelectByKey(manager
                    , idfsUpload506
                    , null, null
                    );
            }
            

            private cc_506_OccupationType _SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfsUpload506
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual cc_506_OccupationType _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, cc_506_OccupationType obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, cc_506_OccupationType obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private cc_506_OccupationType _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                cc_506_OccupationType obj = null;
                try
                {
                    obj = cc_506_OccupationType.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                    // created extenters - end
        
                    if (created != null)
                        created(obj);
                    obj.Created(manager);
                    _SetPermitions(obj._permissions, obj);
                    _SetupRequired(obj);
                    _SetupPersonalDataRestrictions(obj);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public cc_506_OccupationType CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public cc_506_OccupationType CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public cc_506_OccupationType CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(cc_506_OccupationType obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(cc_506_OccupationType obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, cc_506_OccupationType obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(cc_506_OccupationType obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(cc_506_OccupationType obj, bool bRethrowException)
            {
                ValidationModelException ex = ChainsValidate(obj);
                if (ex != null)
                {
                    if (bRethrowException)
                        throw ex;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                return true;
            }
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as cc_506_OccupationType, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, cc_506_OccupationType obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(cc_506_OccupationType obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(cc_506_OccupationType obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as cc_506_OccupationType) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as cc_506_OccupationType) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "cc_506_OccupationTypeDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spUpload506Master_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<cc_506_OccupationType, bool>> RequiredByField = new Dictionary<string, Func<cc_506_OccupationType, bool>>();
            public static Dictionary<string, Func<cc_506_OccupationType, bool>> RequiredByProperty = new Dictionary<string, Func<cc_506_OccupationType, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            
            
    private static Dictionary<string, List<Func<bool>>> m_isHiddenPersonalData = new Dictionary<string, List<Func<bool>>>();
    internal static bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData.ContainsKey(name))
          return m_isHiddenPersonalData[name].Aggregate(false, (s,c) => s | c());
      return false;
    }

    private static void AddHiddenPersonalData(string name, Func<bool> func)
    {
      if (!m_isHiddenPersonalData.ContainsKey(name))
          m_isHiddenPersonalData.Add(name, new List<Func<bool>>());
      m_isHiddenPersonalData[name].Add(func);
    }
  
            
            static Meta()
            {
                
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, c, pars)),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_OccupationType>().Post(manager, (cc_506_OccupationType)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_OccupationType>().Post(manager, (cc_506_OccupationType)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Cancel",
                    ActionTypes.Cancel,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((cc_506_OccupationType)c).MarkToDelete() && ObjectAccessor.PostInterface<cc_506_OccupationType>().Post(manager, (cc_506_OccupationType)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
                      null,
                      null,
                      false
                      ));
                    
        
                _SetupPersonalDataRestrictions();
            }
            
            
    private static void _SetupPersonalDataRestrictions()
    {
    

    }
  
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class cc_506_Outcome : 
        EditableObject<cc_506_Outcome>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsOutcome), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsOutcome { get; set; }
                
        [LocalizedDisplayName(_str_RESULT)]
        [MapField(_str_RESULT)]
        public abstract Int64 RESULT { get; set; }
        protected Int64 RESULT_Original { get { return ((EditableValue<Int64>)((dynamic)this)._rESULT).OriginalValue; } }
        protected Int64 RESULT_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._rESULT).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsUpload506)]
        [MapField(_str_idfsUpload506)]
        public abstract Int64 idfsUpload506 { get; set; }
        protected Int64 idfsUpload506_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).OriginalValue; } }
        protected Int64 idfsUpload506_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<cc_506_Outcome, object> _get_func;
            internal Action<cc_506_Outcome, string> _set_func;
            internal Action<cc_506_Outcome, cc_506_Outcome, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsOutcome = "idfsOutcome";
        internal const string _str_RESULT = "RESULT";
        internal const string _str_idfsUpload506 = "idfsUpload506";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsOutcome, _formname = _str_idfsOutcome, _type = "Int64",
              _get_func = o => o.idfsOutcome,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsOutcome != newval) o.idfsOutcome = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsOutcome != c.idfsOutcome || o.IsRIRPropChanged(_str_idfsOutcome, c)) 
                  m.Add(_str_idfsOutcome, o.ObjectIdent + _str_idfsOutcome, o.ObjectIdent2 + _str_idfsOutcome, o.ObjectIdent3 + _str_idfsOutcome, "Int64", 
                    o.idfsOutcome == null ? "" : o.idfsOutcome.ToString(),                  
                  o.IsReadOnly(_str_idfsOutcome), o.IsInvisible(_str_idfsOutcome), o.IsRequired(_str_idfsOutcome)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_RESULT, _formname = _str_RESULT, _type = "Int64",
              _get_func = o => o.RESULT,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.RESULT != newval) o.RESULT = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.RESULT != c.RESULT || o.IsRIRPropChanged(_str_RESULT, c)) 
                  m.Add(_str_RESULT, o.ObjectIdent + _str_RESULT, o.ObjectIdent2 + _str_RESULT, o.ObjectIdent3 + _str_RESULT, "Int64", 
                    o.RESULT == null ? "" : o.RESULT.ToString(),                  
                  o.IsReadOnly(_str_RESULT), o.IsInvisible(_str_RESULT), o.IsRequired(_str_RESULT)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsUpload506, _formname = _str_idfsUpload506, _type = "Int64",
              _get_func = o => o.idfsUpload506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsUpload506 != newval) o.idfsUpload506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsUpload506 != c.idfsUpload506 || o.IsRIRPropChanged(_str_idfsUpload506, c)) 
                  m.Add(_str_idfsUpload506, o.ObjectIdent + _str_idfsUpload506, o.ObjectIdent2 + _str_idfsUpload506, o.ObjectIdent3 + _str_idfsUpload506, "Int64", 
                    o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(),                  
                  o.IsReadOnly(_str_idfsUpload506), o.IsInvisible(_str_idfsUpload506), o.IsRequired(_str_idfsUpload506)); 
                  }
              }, 
        
            new field_info()
        };
        #endregion
        
        private string _getType(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? "" : i._type;
        }
        private object _getValue(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? null : i._get_func(this);
        }
        private void _setValue(string name, string val)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            if (i != null) i._set_func(this, val);
        }
        internal CompareModel _compare(IObject o, CompareModel ret)
        {
            if (ret == null) ret = new CompareModel();
            if (o == null) return ret;
            cc_506_Outcome obj = (cc_506_Outcome)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "cc_506_Outcome";

        #region Parent and Clone supporting
        [XmlIgnore]
        public IObject Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; /*OnPropertyChanged(_str_Parent);*/ }
        }
        private IObject m_Parent;
        internal void _setParent()
        {
        
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as cc_506_Outcome;
            ret.bIsClone = true;
            ret.Cloned();
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager, bool bRestricted = false)
        {
            var ret = base.Clone() as cc_506_Outcome;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public cc_506_Outcome CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as cc_506_Outcome;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsOutcome; } }
        public string KeyName { get { return "idfsOutcome"; } }
        public object KeyLookup { get { return idfsOutcome; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        [XmlIgnore]
        [LocalizedDisplayName("HasChanges")]
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                ;
            }
        }
        public new void RejectChanges()
        {
        
            base.RejectChanges();
        
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
        }
        private bool m_bForceDirty;
        public override void AcceptChanges()
        {
            m_bForceDirty = false;
            base.AcceptChanges();
        }
        [XmlIgnore]
        [LocalizedDisplayName("IsDirty")]
        public override bool IsDirty
        {
            get { return m_bForceDirty || base.IsDirty; }
        }
        public void SetChange()
        { 
            m_bForceDirty = true;
        }
        public void DeepSetChange()
        { 
            SetChange();
        
        }
        public bool MarkToDelete() { return _Delete(false); }
        public string ObjectName { get { return m_ObjectName; } }
        public string ObjectIdent { get { return ObjectName + "_" + Key.ToString() + "_"; } }
        
        public string ObjectIdent2 { get { return ObjectIdent; } }
          
        public string ObjectIdent3 { get { return ObjectIdent; } }
          
        public IObjectAccessor GetAccessor() { return _getAccessor(); }
        public IObjectPermissions GetPermissions() { return _permissions; }
        private IObjectEnvironment _environment;
        public IObjectEnvironment Environment { get { return _environment; } set { _environment = value; } }
        public bool IsValidObject { get { return _isValid; } }
        public bool ReadOnly { get { return _readOnly || !_isValid; } set { _readOnly = value; } }
        public bool IsReadOnly(string name) { return _isReadOnly(name); }
        public bool IsInvisible(string name) { return _isInvisible(name); }
        public bool IsRequired(string name) { return _isRequired(m_isRequired, name); }
        public bool IsHiddenPersonalData(string name) { return _isHiddenPersonalData(name); }
        public string GetType(string name) { return _getType(name); }
        public object GetValue(string name) { return _getValue(name); }
        public void SetValue(string name, string val) { _setValue(name, val); }
        public CompareModel Compare(IObject o) { return _compare(o, null); }
        public BvSelectList GetList(string name) { return _getList(name); }
        public event ValidationEvent Validation;
        public event ValidationEvent ValidationEnd;
        public event AfterPostEvent AfterPost;
      
        public Dictionary<string, string> GetFieldTags(string name)
        {
          return null;
        }
      #endregion

        private bool IsRIRPropChanged(string fld, cc_506_Outcome c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, cc_506_Outcome c)
        {
            var thisLookup = GetValue(fld + "Lookup") as IList;
            var thatLookup = c.GetValue(fld + "Lookup") as IList;
            bool bChangeLookupContent = thisLookup.Count != thatLookup.Count;
            if (!bChangeLookupContent)
            {
                for (int i = 0; i < thisLookup.Count; i++)
                {
                    if (((thisLookup[i] as IObject).Key as IComparable).CompareTo((thatLookup[i] as IObject).Key) != 0 &&
                        (thisLookup[i] as IObject).ToStringProp != null && ((thisLookup[i] as IObject).ToStringProp as IComparable).CompareTo((thatLookup[i] as IObject).ToStringProp) != 0)
                    {
                        bChangeLookupContent = true;
                        break;
                    }
                }
            }
            return bChangeLookupContent;
        }
        

      

        public cc_506_Outcome()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(cc_506_Outcome_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(cc_506_Outcome_PropertyChanged);
        }
        private void cc_506_Outcome_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as cc_506_Outcome).Changed(e.PropertyName);
            
        }
        
        public bool ForceToDelete() { return _Delete(true); }
        internal bool _Delete(bool isForceDelete)
        {
            if (!_ValidateOnDelete()) return false;
            _DeletingExtenders();
            m_IsMarkedToDelete = true;
            m_IsForcedToDelete = m_IsForcedToDelete ? m_IsForcedToDelete : isForceDelete;
            OnPropertyChanged("IsMarkedToDelete");
            _DeletedExtenders();
            Deleted();
            return true;
        }
        private bool _ValidateOnDelete(bool bReport = true)
        {
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            cc_506_Outcome obj = this;
            
        }
        private void _DeletedExtenders()
        {
            cc_506_Outcome obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                ValidationEnd(this, args);
                return args.Continue;
            }
            return false;
        }

        public void OnAfterPost()
        {
            if (AfterPost != null)
            {
                AfterPost(this, EventArgs.Empty);
            }
        }

        public FormSize FormSize
        {
            get { return FormSize.Undefined; }
        }
    
        private bool _isInvisible(string name)
        {
            
            return false;
                
        }

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
            }
        }


        internal Dictionary<string, Func<cc_506_Outcome, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<cc_506_Outcome, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<cc_506_Outcome, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<cc_506_Outcome, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<cc_506_Outcome, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<cc_506_Outcome, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<cc_506_Outcome, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        partial void Disposed();
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~cc_506_Outcome()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                m_Parent = null;
                m_permissions = null;
                
                this.ClearModelObjEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                }
                Disposed();
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            ParsingFormCollection(form);
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<cc_506_Outcome>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<cc_506_Outcome>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<cc_506_Outcome>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsOutcome"; } }
            #endregion
        
            public delegate void on_action(cc_506_Outcome obj);
            private static Accessor g_Instance = CreateInstance<Accessor>();
            private CacheScope m_CS;
            public static Accessor Instance(CacheScope cs) 
            { 
                if (cs == null)
                    return g_Instance;
                lock(cs)
                {
                    object acc = cs.Get(typeof (Accessor));
                    if (acc != null)
                    {
                        return acc as Accessor;
                    }
                    Accessor ret = CreateInstance<Accessor>();
                    ret.m_CS = cs;
                    cs.Add(typeof(Accessor), ret);
                    return ret;
                }
            }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }
            public virtual cc_506_Outcome SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual cc_506_Outcome SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                )
            {
                return _SelectByKey(manager
                    , idfsUpload506
                    , null, null
                    );
            }
            

            private cc_506_Outcome _SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfsUpload506
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual cc_506_Outcome _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, cc_506_Outcome obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, cc_506_Outcome obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private cc_506_Outcome _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                cc_506_Outcome obj = null;
                try
                {
                    obj = cc_506_Outcome.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                    // created extenters - end
        
                    if (created != null)
                        created(obj);
                    obj.Created(manager);
                    _SetPermitions(obj._permissions, obj);
                    _SetupRequired(obj);
                    _SetupPersonalDataRestrictions(obj);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public cc_506_Outcome CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public cc_506_Outcome CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public cc_506_Outcome CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(cc_506_Outcome obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(cc_506_Outcome obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, cc_506_Outcome obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(cc_506_Outcome obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(cc_506_Outcome obj, bool bRethrowException)
            {
                ValidationModelException ex = ChainsValidate(obj);
                if (ex != null)
                {
                    if (bRethrowException)
                        throw ex;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                return true;
            }
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as cc_506_Outcome, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, cc_506_Outcome obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(cc_506_Outcome obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(cc_506_Outcome obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as cc_506_Outcome) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as cc_506_Outcome) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "cc_506_OutcomeDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spUpload506Master_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<cc_506_Outcome, bool>> RequiredByField = new Dictionary<string, Func<cc_506_Outcome, bool>>();
            public static Dictionary<string, Func<cc_506_Outcome, bool>> RequiredByProperty = new Dictionary<string, Func<cc_506_Outcome, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            
            
    private static Dictionary<string, List<Func<bool>>> m_isHiddenPersonalData = new Dictionary<string, List<Func<bool>>>();
    internal static bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData.ContainsKey(name))
          return m_isHiddenPersonalData[name].Aggregate(false, (s,c) => s | c());
      return false;
    }

    private static void AddHiddenPersonalData(string name, Func<bool> func)
    {
      if (!m_isHiddenPersonalData.ContainsKey(name))
          m_isHiddenPersonalData.Add(name, new List<Func<bool>>());
      m_isHiddenPersonalData[name].Add(func);
    }
  
            
            static Meta()
            {
                
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, c, pars)),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_Outcome>().Post(manager, (cc_506_Outcome)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_Outcome>().Post(manager, (cc_506_Outcome)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Cancel",
                    ActionTypes.Cancel,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((cc_506_Outcome)c).MarkToDelete() && ObjectAccessor.PostInterface<cc_506_Outcome>().Post(manager, (cc_506_Outcome)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
                      null,
                      null,
                      false
                      ));
                    
        
                _SetupPersonalDataRestrictions();
            }
            
            
    private static void _SetupPersonalDataRestrictions()
    {
    

    }
  
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class cc_506_Diagnosis : 
        EditableObject<cc_506_Diagnosis>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsTentativeDiagnosis), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsTentativeDiagnosis { get; set; }
                
        [LocalizedDisplayName(_str_DISEASE)]
        [MapField(_str_DISEASE)]
        public abstract Int64 DISEASE { get; set; }
        protected Int64 DISEASE_Original { get { return ((EditableValue<Int64>)((dynamic)this)._dISEASE).OriginalValue; } }
        protected Int64 DISEASE_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._dISEASE).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsUpload506)]
        [MapField(_str_idfsUpload506)]
        public abstract Int64 idfsUpload506 { get; set; }
        protected Int64 idfsUpload506_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).OriginalValue; } }
        protected Int64 idfsUpload506_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<cc_506_Diagnosis, object> _get_func;
            internal Action<cc_506_Diagnosis, string> _set_func;
            internal Action<cc_506_Diagnosis, cc_506_Diagnosis, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsTentativeDiagnosis = "idfsTentativeDiagnosis";
        internal const string _str_DISEASE = "DISEASE";
        internal const string _str_idfsUpload506 = "idfsUpload506";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsTentativeDiagnosis, _formname = _str_idfsTentativeDiagnosis, _type = "Int64",
              _get_func = o => o.idfsTentativeDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsTentativeDiagnosis != newval) o.idfsTentativeDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsTentativeDiagnosis != c.idfsTentativeDiagnosis || o.IsRIRPropChanged(_str_idfsTentativeDiagnosis, c)) 
                  m.Add(_str_idfsTentativeDiagnosis, o.ObjectIdent + _str_idfsTentativeDiagnosis, o.ObjectIdent2 + _str_idfsTentativeDiagnosis, o.ObjectIdent3 + _str_idfsTentativeDiagnosis, "Int64", 
                    o.idfsTentativeDiagnosis == null ? "" : o.idfsTentativeDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsTentativeDiagnosis), o.IsInvisible(_str_idfsTentativeDiagnosis), o.IsRequired(_str_idfsTentativeDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DISEASE, _formname = _str_DISEASE, _type = "Int64",
              _get_func = o => o.DISEASE,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.DISEASE != newval) o.DISEASE = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.DISEASE != c.DISEASE || o.IsRIRPropChanged(_str_DISEASE, c)) 
                  m.Add(_str_DISEASE, o.ObjectIdent + _str_DISEASE, o.ObjectIdent2 + _str_DISEASE, o.ObjectIdent3 + _str_DISEASE, "Int64", 
                    o.DISEASE == null ? "" : o.DISEASE.ToString(),                  
                  o.IsReadOnly(_str_DISEASE), o.IsInvisible(_str_DISEASE), o.IsRequired(_str_DISEASE)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsUpload506, _formname = _str_idfsUpload506, _type = "Int64",
              _get_func = o => o.idfsUpload506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsUpload506 != newval) o.idfsUpload506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsUpload506 != c.idfsUpload506 || o.IsRIRPropChanged(_str_idfsUpload506, c)) 
                  m.Add(_str_idfsUpload506, o.ObjectIdent + _str_idfsUpload506, o.ObjectIdent2 + _str_idfsUpload506, o.ObjectIdent3 + _str_idfsUpload506, "Int64", 
                    o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(),                  
                  o.IsReadOnly(_str_idfsUpload506), o.IsInvisible(_str_idfsUpload506), o.IsRequired(_str_idfsUpload506)); 
                  }
              }, 
        
            new field_info()
        };
        #endregion
        
        private string _getType(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? "" : i._type;
        }
        private object _getValue(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? null : i._get_func(this);
        }
        private void _setValue(string name, string val)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            if (i != null) i._set_func(this, val);
        }
        internal CompareModel _compare(IObject o, CompareModel ret)
        {
            if (ret == null) ret = new CompareModel();
            if (o == null) return ret;
            cc_506_Diagnosis obj = (cc_506_Diagnosis)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "cc_506_Diagnosis";

        #region Parent and Clone supporting
        [XmlIgnore]
        public IObject Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; /*OnPropertyChanged(_str_Parent);*/ }
        }
        private IObject m_Parent;
        internal void _setParent()
        {
        
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as cc_506_Diagnosis;
            ret.bIsClone = true;
            ret.Cloned();
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager, bool bRestricted = false)
        {
            var ret = base.Clone() as cc_506_Diagnosis;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public cc_506_Diagnosis CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as cc_506_Diagnosis;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsTentativeDiagnosis; } }
        public string KeyName { get { return "idfsTentativeDiagnosis"; } }
        public object KeyLookup { get { return idfsTentativeDiagnosis; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        [XmlIgnore]
        [LocalizedDisplayName("HasChanges")]
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                ;
            }
        }
        public new void RejectChanges()
        {
        
            base.RejectChanges();
        
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
        }
        private bool m_bForceDirty;
        public override void AcceptChanges()
        {
            m_bForceDirty = false;
            base.AcceptChanges();
        }
        [XmlIgnore]
        [LocalizedDisplayName("IsDirty")]
        public override bool IsDirty
        {
            get { return m_bForceDirty || base.IsDirty; }
        }
        public void SetChange()
        { 
            m_bForceDirty = true;
        }
        public void DeepSetChange()
        { 
            SetChange();
        
        }
        public bool MarkToDelete() { return _Delete(false); }
        public string ObjectName { get { return m_ObjectName; } }
        public string ObjectIdent { get { return ObjectName + "_" + Key.ToString() + "_"; } }
        
        public string ObjectIdent2 { get { return ObjectIdent; } }
          
        public string ObjectIdent3 { get { return ObjectIdent; } }
          
        public IObjectAccessor GetAccessor() { return _getAccessor(); }
        public IObjectPermissions GetPermissions() { return _permissions; }
        private IObjectEnvironment _environment;
        public IObjectEnvironment Environment { get { return _environment; } set { _environment = value; } }
        public bool IsValidObject { get { return _isValid; } }
        public bool ReadOnly { get { return _readOnly || !_isValid; } set { _readOnly = value; } }
        public bool IsReadOnly(string name) { return _isReadOnly(name); }
        public bool IsInvisible(string name) { return _isInvisible(name); }
        public bool IsRequired(string name) { return _isRequired(m_isRequired, name); }
        public bool IsHiddenPersonalData(string name) { return _isHiddenPersonalData(name); }
        public string GetType(string name) { return _getType(name); }
        public object GetValue(string name) { return _getValue(name); }
        public void SetValue(string name, string val) { _setValue(name, val); }
        public CompareModel Compare(IObject o) { return _compare(o, null); }
        public BvSelectList GetList(string name) { return _getList(name); }
        public event ValidationEvent Validation;
        public event ValidationEvent ValidationEnd;
        public event AfterPostEvent AfterPost;
      
        public Dictionary<string, string> GetFieldTags(string name)
        {
          return null;
        }
      #endregion

        private bool IsRIRPropChanged(string fld, cc_506_Diagnosis c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, cc_506_Diagnosis c)
        {
            var thisLookup = GetValue(fld + "Lookup") as IList;
            var thatLookup = c.GetValue(fld + "Lookup") as IList;
            bool bChangeLookupContent = thisLookup.Count != thatLookup.Count;
            if (!bChangeLookupContent)
            {
                for (int i = 0; i < thisLookup.Count; i++)
                {
                    if (((thisLookup[i] as IObject).Key as IComparable).CompareTo((thatLookup[i] as IObject).Key) != 0 &&
                        (thisLookup[i] as IObject).ToStringProp != null && ((thisLookup[i] as IObject).ToStringProp as IComparable).CompareTo((thatLookup[i] as IObject).ToStringProp) != 0)
                    {
                        bChangeLookupContent = true;
                        break;
                    }
                }
            }
            return bChangeLookupContent;
        }
        

      

        public cc_506_Diagnosis()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(cc_506_Diagnosis_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(cc_506_Diagnosis_PropertyChanged);
        }
        private void cc_506_Diagnosis_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as cc_506_Diagnosis).Changed(e.PropertyName);
            
        }
        
        public bool ForceToDelete() { return _Delete(true); }
        internal bool _Delete(bool isForceDelete)
        {
            if (!_ValidateOnDelete()) return false;
            _DeletingExtenders();
            m_IsMarkedToDelete = true;
            m_IsForcedToDelete = m_IsForcedToDelete ? m_IsForcedToDelete : isForceDelete;
            OnPropertyChanged("IsMarkedToDelete");
            _DeletedExtenders();
            Deleted();
            return true;
        }
        private bool _ValidateOnDelete(bool bReport = true)
        {
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            cc_506_Diagnosis obj = this;
            
        }
        private void _DeletedExtenders()
        {
            cc_506_Diagnosis obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                ValidationEnd(this, args);
                return args.Continue;
            }
            return false;
        }

        public void OnAfterPost()
        {
            if (AfterPost != null)
            {
                AfterPost(this, EventArgs.Empty);
            }
        }

        public FormSize FormSize
        {
            get { return FormSize.Undefined; }
        }
    
        private bool _isInvisible(string name)
        {
            
            return false;
                
        }

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
            }
        }


        internal Dictionary<string, Func<cc_506_Diagnosis, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<cc_506_Diagnosis, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<cc_506_Diagnosis, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<cc_506_Diagnosis, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<cc_506_Diagnosis, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<cc_506_Diagnosis, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<cc_506_Diagnosis, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        partial void Disposed();
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~cc_506_Diagnosis()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                m_Parent = null;
                m_permissions = null;
                
                this.ClearModelObjEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                }
                Disposed();
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            ParsingFormCollection(form);
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<cc_506_Diagnosis>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<cc_506_Diagnosis>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<cc_506_Diagnosis>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsTentativeDiagnosis"; } }
            #endregion
        
            public delegate void on_action(cc_506_Diagnosis obj);
            private static Accessor g_Instance = CreateInstance<Accessor>();
            private CacheScope m_CS;
            public static Accessor Instance(CacheScope cs) 
            { 
                if (cs == null)
                    return g_Instance;
                lock(cs)
                {
                    object acc = cs.Get(typeof (Accessor));
                    if (acc != null)
                    {
                        return acc as Accessor;
                    }
                    Accessor ret = CreateInstance<Accessor>();
                    ret.m_CS = cs;
                    cs.Add(typeof(Accessor), ret);
                    return ret;
                }
            }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }
            public virtual cc_506_Diagnosis SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual cc_506_Diagnosis SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                )
            {
                return _SelectByKey(manager
                    , idfsUpload506
                    , null, null
                    );
            }
            

            private cc_506_Diagnosis _SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfsUpload506
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual cc_506_Diagnosis _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, cc_506_Diagnosis obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, cc_506_Diagnosis obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private cc_506_Diagnosis _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                cc_506_Diagnosis obj = null;
                try
                {
                    obj = cc_506_Diagnosis.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                    // created extenters - end
        
                    if (created != null)
                        created(obj);
                    obj.Created(manager);
                    _SetPermitions(obj._permissions, obj);
                    _SetupRequired(obj);
                    _SetupPersonalDataRestrictions(obj);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public cc_506_Diagnosis CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public cc_506_Diagnosis CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public cc_506_Diagnosis CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(cc_506_Diagnosis obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(cc_506_Diagnosis obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, cc_506_Diagnosis obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(cc_506_Diagnosis obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(cc_506_Diagnosis obj, bool bRethrowException)
            {
                ValidationModelException ex = ChainsValidate(obj);
                if (ex != null)
                {
                    if (bRethrowException)
                        throw ex;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                return true;
            }
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as cc_506_Diagnosis, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, cc_506_Diagnosis obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(cc_506_Diagnosis obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(cc_506_Diagnosis obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as cc_506_Diagnosis) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as cc_506_Diagnosis) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "cc_506_DiagnosisDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spUpload506Master_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<cc_506_Diagnosis, bool>> RequiredByField = new Dictionary<string, Func<cc_506_Diagnosis, bool>>();
            public static Dictionary<string, Func<cc_506_Diagnosis, bool>> RequiredByProperty = new Dictionary<string, Func<cc_506_Diagnosis, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            
            
    private static Dictionary<string, List<Func<bool>>> m_isHiddenPersonalData = new Dictionary<string, List<Func<bool>>>();
    internal static bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData.ContainsKey(name))
          return m_isHiddenPersonalData[name].Aggregate(false, (s,c) => s | c());
      return false;
    }

    private static void AddHiddenPersonalData(string name, Func<bool> func)
    {
      if (!m_isHiddenPersonalData.ContainsKey(name))
          m_isHiddenPersonalData.Add(name, new List<Func<bool>>());
      m_isHiddenPersonalData[name].Add(func);
    }
  
            
            static Meta()
            {
                
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, c, pars)),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_Diagnosis>().Post(manager, (cc_506_Diagnosis)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_Diagnosis>().Post(manager, (cc_506_Diagnosis)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Cancel",
                    ActionTypes.Cancel,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((cc_506_Diagnosis)c).MarkToDelete() && ObjectAccessor.PostInterface<cc_506_Diagnosis>().Post(manager, (cc_506_Diagnosis)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
                      null,
                      null,
                      false
                      ));
                    
        
                _SetupPersonalDataRestrictions();
            }
            
            
    private static void _SetupPersonalDataRestrictions()
    {
    

    }
  
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class cc_506_MaritalStatus : 
        EditableObject<cc_506_MaritalStatus>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsMaritalStatus), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsMaritalStatus { get; set; }
                
        [LocalizedDisplayName(_str_MARIETAL)]
        [MapField(_str_MARIETAL)]
        public abstract Int64 MARIETAL { get; set; }
        protected Int64 MARIETAL_Original { get { return ((EditableValue<Int64>)((dynamic)this)._mARIETAL).OriginalValue; } }
        protected Int64 MARIETAL_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._mARIETAL).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsUpload506)]
        [MapField(_str_idfsUpload506)]
        public abstract Int64 idfsUpload506 { get; set; }
        protected Int64 idfsUpload506_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).OriginalValue; } }
        protected Int64 idfsUpload506_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<cc_506_MaritalStatus, object> _get_func;
            internal Action<cc_506_MaritalStatus, string> _set_func;
            internal Action<cc_506_MaritalStatus, cc_506_MaritalStatus, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsMaritalStatus = "idfsMaritalStatus";
        internal const string _str_MARIETAL = "MARIETAL";
        internal const string _str_idfsUpload506 = "idfsUpload506";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsMaritalStatus, _formname = _str_idfsMaritalStatus, _type = "Int64",
              _get_func = o => o.idfsMaritalStatus,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsMaritalStatus != newval) o.idfsMaritalStatus = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsMaritalStatus != c.idfsMaritalStatus || o.IsRIRPropChanged(_str_idfsMaritalStatus, c)) 
                  m.Add(_str_idfsMaritalStatus, o.ObjectIdent + _str_idfsMaritalStatus, o.ObjectIdent2 + _str_idfsMaritalStatus, o.ObjectIdent3 + _str_idfsMaritalStatus, "Int64", 
                    o.idfsMaritalStatus == null ? "" : o.idfsMaritalStatus.ToString(),                  
                  o.IsReadOnly(_str_idfsMaritalStatus), o.IsInvisible(_str_idfsMaritalStatus), o.IsRequired(_str_idfsMaritalStatus)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_MARIETAL, _formname = _str_MARIETAL, _type = "Int64",
              _get_func = o => o.MARIETAL,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.MARIETAL != newval) o.MARIETAL = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.MARIETAL != c.MARIETAL || o.IsRIRPropChanged(_str_MARIETAL, c)) 
                  m.Add(_str_MARIETAL, o.ObjectIdent + _str_MARIETAL, o.ObjectIdent2 + _str_MARIETAL, o.ObjectIdent3 + _str_MARIETAL, "Int64", 
                    o.MARIETAL == null ? "" : o.MARIETAL.ToString(),                  
                  o.IsReadOnly(_str_MARIETAL), o.IsInvisible(_str_MARIETAL), o.IsRequired(_str_MARIETAL)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsUpload506, _formname = _str_idfsUpload506, _type = "Int64",
              _get_func = o => o.idfsUpload506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsUpload506 != newval) o.idfsUpload506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsUpload506 != c.idfsUpload506 || o.IsRIRPropChanged(_str_idfsUpload506, c)) 
                  m.Add(_str_idfsUpload506, o.ObjectIdent + _str_idfsUpload506, o.ObjectIdent2 + _str_idfsUpload506, o.ObjectIdent3 + _str_idfsUpload506, "Int64", 
                    o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(),                  
                  o.IsReadOnly(_str_idfsUpload506), o.IsInvisible(_str_idfsUpload506), o.IsRequired(_str_idfsUpload506)); 
                  }
              }, 
        
            new field_info()
        };
        #endregion
        
        private string _getType(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? "" : i._type;
        }
        private object _getValue(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? null : i._get_func(this);
        }
        private void _setValue(string name, string val)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            if (i != null) i._set_func(this, val);
        }
        internal CompareModel _compare(IObject o, CompareModel ret)
        {
            if (ret == null) ret = new CompareModel();
            if (o == null) return ret;
            cc_506_MaritalStatus obj = (cc_506_MaritalStatus)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "cc_506_MaritalStatus";

        #region Parent and Clone supporting
        [XmlIgnore]
        public IObject Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; /*OnPropertyChanged(_str_Parent);*/ }
        }
        private IObject m_Parent;
        internal void _setParent()
        {
        
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as cc_506_MaritalStatus;
            ret.bIsClone = true;
            ret.Cloned();
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager, bool bRestricted = false)
        {
            var ret = base.Clone() as cc_506_MaritalStatus;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public cc_506_MaritalStatus CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as cc_506_MaritalStatus;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsMaritalStatus; } }
        public string KeyName { get { return "idfsMaritalStatus"; } }
        public object KeyLookup { get { return idfsMaritalStatus; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        [XmlIgnore]
        [LocalizedDisplayName("HasChanges")]
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                ;
            }
        }
        public new void RejectChanges()
        {
        
            base.RejectChanges();
        
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
        }
        private bool m_bForceDirty;
        public override void AcceptChanges()
        {
            m_bForceDirty = false;
            base.AcceptChanges();
        }
        [XmlIgnore]
        [LocalizedDisplayName("IsDirty")]
        public override bool IsDirty
        {
            get { return m_bForceDirty || base.IsDirty; }
        }
        public void SetChange()
        { 
            m_bForceDirty = true;
        }
        public void DeepSetChange()
        { 
            SetChange();
        
        }
        public bool MarkToDelete() { return _Delete(false); }
        public string ObjectName { get { return m_ObjectName; } }
        public string ObjectIdent { get { return ObjectName + "_" + Key.ToString() + "_"; } }
        
        public string ObjectIdent2 { get { return ObjectIdent; } }
          
        public string ObjectIdent3 { get { return ObjectIdent; } }
          
        public IObjectAccessor GetAccessor() { return _getAccessor(); }
        public IObjectPermissions GetPermissions() { return _permissions; }
        private IObjectEnvironment _environment;
        public IObjectEnvironment Environment { get { return _environment; } set { _environment = value; } }
        public bool IsValidObject { get { return _isValid; } }
        public bool ReadOnly { get { return _readOnly || !_isValid; } set { _readOnly = value; } }
        public bool IsReadOnly(string name) { return _isReadOnly(name); }
        public bool IsInvisible(string name) { return _isInvisible(name); }
        public bool IsRequired(string name) { return _isRequired(m_isRequired, name); }
        public bool IsHiddenPersonalData(string name) { return _isHiddenPersonalData(name); }
        public string GetType(string name) { return _getType(name); }
        public object GetValue(string name) { return _getValue(name); }
        public void SetValue(string name, string val) { _setValue(name, val); }
        public CompareModel Compare(IObject o) { return _compare(o, null); }
        public BvSelectList GetList(string name) { return _getList(name); }
        public event ValidationEvent Validation;
        public event ValidationEvent ValidationEnd;
        public event AfterPostEvent AfterPost;
      
        public Dictionary<string, string> GetFieldTags(string name)
        {
          return null;
        }
      #endregion

        private bool IsRIRPropChanged(string fld, cc_506_MaritalStatus c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, cc_506_MaritalStatus c)
        {
            var thisLookup = GetValue(fld + "Lookup") as IList;
            var thatLookup = c.GetValue(fld + "Lookup") as IList;
            bool bChangeLookupContent = thisLookup.Count != thatLookup.Count;
            if (!bChangeLookupContent)
            {
                for (int i = 0; i < thisLookup.Count; i++)
                {
                    if (((thisLookup[i] as IObject).Key as IComparable).CompareTo((thatLookup[i] as IObject).Key) != 0 &&
                        (thisLookup[i] as IObject).ToStringProp != null && ((thisLookup[i] as IObject).ToStringProp as IComparable).CompareTo((thatLookup[i] as IObject).ToStringProp) != 0)
                    {
                        bChangeLookupContent = true;
                        break;
                    }
                }
            }
            return bChangeLookupContent;
        }
        

      

        public cc_506_MaritalStatus()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(cc_506_MaritalStatus_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(cc_506_MaritalStatus_PropertyChanged);
        }
        private void cc_506_MaritalStatus_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as cc_506_MaritalStatus).Changed(e.PropertyName);
            
        }
        
        public bool ForceToDelete() { return _Delete(true); }
        internal bool _Delete(bool isForceDelete)
        {
            if (!_ValidateOnDelete()) return false;
            _DeletingExtenders();
            m_IsMarkedToDelete = true;
            m_IsForcedToDelete = m_IsForcedToDelete ? m_IsForcedToDelete : isForceDelete;
            OnPropertyChanged("IsMarkedToDelete");
            _DeletedExtenders();
            Deleted();
            return true;
        }
        private bool _ValidateOnDelete(bool bReport = true)
        {
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            cc_506_MaritalStatus obj = this;
            
        }
        private void _DeletedExtenders()
        {
            cc_506_MaritalStatus obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                ValidationEnd(this, args);
                return args.Continue;
            }
            return false;
        }

        public void OnAfterPost()
        {
            if (AfterPost != null)
            {
                AfterPost(this, EventArgs.Empty);
            }
        }

        public FormSize FormSize
        {
            get { return FormSize.Undefined; }
        }
    
        private bool _isInvisible(string name)
        {
            
            return false;
                
        }

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
            }
        }


        internal Dictionary<string, Func<cc_506_MaritalStatus, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<cc_506_MaritalStatus, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<cc_506_MaritalStatus, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<cc_506_MaritalStatus, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<cc_506_MaritalStatus, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<cc_506_MaritalStatus, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<cc_506_MaritalStatus, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        partial void Disposed();
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~cc_506_MaritalStatus()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                m_Parent = null;
                m_permissions = null;
                
                this.ClearModelObjEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                }
                Disposed();
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            ParsingFormCollection(form);
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<cc_506_MaritalStatus>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<cc_506_MaritalStatus>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<cc_506_MaritalStatus>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsMaritalStatus"; } }
            #endregion
        
            public delegate void on_action(cc_506_MaritalStatus obj);
            private static Accessor g_Instance = CreateInstance<Accessor>();
            private CacheScope m_CS;
            public static Accessor Instance(CacheScope cs) 
            { 
                if (cs == null)
                    return g_Instance;
                lock(cs)
                {
                    object acc = cs.Get(typeof (Accessor));
                    if (acc != null)
                    {
                        return acc as Accessor;
                    }
                    Accessor ret = CreateInstance<Accessor>();
                    ret.m_CS = cs;
                    cs.Add(typeof(Accessor), ret);
                    return ret;
                }
            }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }
            public virtual cc_506_MaritalStatus SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual cc_506_MaritalStatus SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                )
            {
                return _SelectByKey(manager
                    , idfsUpload506
                    , null, null
                    );
            }
            

            private cc_506_MaritalStatus _SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfsUpload506
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual cc_506_MaritalStatus _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, cc_506_MaritalStatus obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, cc_506_MaritalStatus obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private cc_506_MaritalStatus _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                cc_506_MaritalStatus obj = null;
                try
                {
                    obj = cc_506_MaritalStatus.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                    // created extenters - end
        
                    if (created != null)
                        created(obj);
                    obj.Created(manager);
                    _SetPermitions(obj._permissions, obj);
                    _SetupRequired(obj);
                    _SetupPersonalDataRestrictions(obj);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public cc_506_MaritalStatus CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public cc_506_MaritalStatus CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public cc_506_MaritalStatus CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(cc_506_MaritalStatus obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(cc_506_MaritalStatus obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, cc_506_MaritalStatus obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(cc_506_MaritalStatus obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(cc_506_MaritalStatus obj, bool bRethrowException)
            {
                ValidationModelException ex = ChainsValidate(obj);
                if (ex != null)
                {
                    if (bRethrowException)
                        throw ex;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                return true;
            }
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as cc_506_MaritalStatus, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, cc_506_MaritalStatus obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(cc_506_MaritalStatus obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(cc_506_MaritalStatus obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as cc_506_MaritalStatus) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as cc_506_MaritalStatus) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "cc_506_MaritalStatusDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spUpload506Master_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<cc_506_MaritalStatus, bool>> RequiredByField = new Dictionary<string, Func<cc_506_MaritalStatus, bool>>();
            public static Dictionary<string, Func<cc_506_MaritalStatus, bool>> RequiredByProperty = new Dictionary<string, Func<cc_506_MaritalStatus, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            
            
    private static Dictionary<string, List<Func<bool>>> m_isHiddenPersonalData = new Dictionary<string, List<Func<bool>>>();
    internal static bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData.ContainsKey(name))
          return m_isHiddenPersonalData[name].Aggregate(false, (s,c) => s | c());
      return false;
    }

    private static void AddHiddenPersonalData(string name, Func<bool> func)
    {
      if (!m_isHiddenPersonalData.ContainsKey(name))
          m_isHiddenPersonalData.Add(name, new List<Func<bool>>());
      m_isHiddenPersonalData[name].Add(func);
    }
  
            
            static Meta()
            {
                
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, c, pars)),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_MaritalStatus>().Post(manager, (cc_506_MaritalStatus)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_MaritalStatus>().Post(manager, (cc_506_MaritalStatus)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Cancel",
                    ActionTypes.Cancel,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((cc_506_MaritalStatus)c).MarkToDelete() && ObjectAccessor.PostInterface<cc_506_MaritalStatus>().Post(manager, (cc_506_MaritalStatus)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
                      null,
                      null,
                      false
                      ));
                    
        
                _SetupPersonalDataRestrictions();
            }
            
            
    private static void _SetupPersonalDataRestrictions()
    {
    

    }
  
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class cc_506_ForeignerType : 
        EditableObject<cc_506_ForeignerType>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsForeignerType), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsForeignerType { get; set; }
                
        [LocalizedDisplayName(_str_RACE1)]
        [MapField(_str_RACE1)]
        public abstract Int64 RACE1 { get; set; }
        protected Int64 RACE1_Original { get { return ((EditableValue<Int64>)((dynamic)this)._rACE1).OriginalValue; } }
        protected Int64 RACE1_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._rACE1).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsUpload506)]
        [MapField(_str_idfsUpload506)]
        public abstract Int64 idfsUpload506 { get; set; }
        protected Int64 idfsUpload506_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).OriginalValue; } }
        protected Int64 idfsUpload506_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<cc_506_ForeignerType, object> _get_func;
            internal Action<cc_506_ForeignerType, string> _set_func;
            internal Action<cc_506_ForeignerType, cc_506_ForeignerType, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsForeignerType = "idfsForeignerType";
        internal const string _str_RACE1 = "RACE1";
        internal const string _str_idfsUpload506 = "idfsUpload506";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsForeignerType, _formname = _str_idfsForeignerType, _type = "Int64",
              _get_func = o => o.idfsForeignerType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsForeignerType != newval) o.idfsForeignerType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsForeignerType != c.idfsForeignerType || o.IsRIRPropChanged(_str_idfsForeignerType, c)) 
                  m.Add(_str_idfsForeignerType, o.ObjectIdent + _str_idfsForeignerType, o.ObjectIdent2 + _str_idfsForeignerType, o.ObjectIdent3 + _str_idfsForeignerType, "Int64", 
                    o.idfsForeignerType == null ? "" : o.idfsForeignerType.ToString(),                  
                  o.IsReadOnly(_str_idfsForeignerType), o.IsInvisible(_str_idfsForeignerType), o.IsRequired(_str_idfsForeignerType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_RACE1, _formname = _str_RACE1, _type = "Int64",
              _get_func = o => o.RACE1,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.RACE1 != newval) o.RACE1 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.RACE1 != c.RACE1 || o.IsRIRPropChanged(_str_RACE1, c)) 
                  m.Add(_str_RACE1, o.ObjectIdent + _str_RACE1, o.ObjectIdent2 + _str_RACE1, o.ObjectIdent3 + _str_RACE1, "Int64", 
                    o.RACE1 == null ? "" : o.RACE1.ToString(),                  
                  o.IsReadOnly(_str_RACE1), o.IsInvisible(_str_RACE1), o.IsRequired(_str_RACE1)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsUpload506, _formname = _str_idfsUpload506, _type = "Int64",
              _get_func = o => o.idfsUpload506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsUpload506 != newval) o.idfsUpload506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsUpload506 != c.idfsUpload506 || o.IsRIRPropChanged(_str_idfsUpload506, c)) 
                  m.Add(_str_idfsUpload506, o.ObjectIdent + _str_idfsUpload506, o.ObjectIdent2 + _str_idfsUpload506, o.ObjectIdent3 + _str_idfsUpload506, "Int64", 
                    o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(),                  
                  o.IsReadOnly(_str_idfsUpload506), o.IsInvisible(_str_idfsUpload506), o.IsRequired(_str_idfsUpload506)); 
                  }
              }, 
        
            new field_info()
        };
        #endregion
        
        private string _getType(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? "" : i._type;
        }
        private object _getValue(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? null : i._get_func(this);
        }
        private void _setValue(string name, string val)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            if (i != null) i._set_func(this, val);
        }
        internal CompareModel _compare(IObject o, CompareModel ret)
        {
            if (ret == null) ret = new CompareModel();
            if (o == null) return ret;
            cc_506_ForeignerType obj = (cc_506_ForeignerType)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "cc_506_ForeignerType";

        #region Parent and Clone supporting
        [XmlIgnore]
        public IObject Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; /*OnPropertyChanged(_str_Parent);*/ }
        }
        private IObject m_Parent;
        internal void _setParent()
        {
        
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as cc_506_ForeignerType;
            ret.bIsClone = true;
            ret.Cloned();
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager, bool bRestricted = false)
        {
            var ret = base.Clone() as cc_506_ForeignerType;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public cc_506_ForeignerType CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as cc_506_ForeignerType;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsForeignerType; } }
        public string KeyName { get { return "idfsForeignerType"; } }
        public object KeyLookup { get { return idfsForeignerType; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        [XmlIgnore]
        [LocalizedDisplayName("HasChanges")]
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                ;
            }
        }
        public new void RejectChanges()
        {
        
            base.RejectChanges();
        
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
        }
        private bool m_bForceDirty;
        public override void AcceptChanges()
        {
            m_bForceDirty = false;
            base.AcceptChanges();
        }
        [XmlIgnore]
        [LocalizedDisplayName("IsDirty")]
        public override bool IsDirty
        {
            get { return m_bForceDirty || base.IsDirty; }
        }
        public void SetChange()
        { 
            m_bForceDirty = true;
        }
        public void DeepSetChange()
        { 
            SetChange();
        
        }
        public bool MarkToDelete() { return _Delete(false); }
        public string ObjectName { get { return m_ObjectName; } }
        public string ObjectIdent { get { return ObjectName + "_" + Key.ToString() + "_"; } }
        
        public string ObjectIdent2 { get { return ObjectIdent; } }
          
        public string ObjectIdent3 { get { return ObjectIdent; } }
          
        public IObjectAccessor GetAccessor() { return _getAccessor(); }
        public IObjectPermissions GetPermissions() { return _permissions; }
        private IObjectEnvironment _environment;
        public IObjectEnvironment Environment { get { return _environment; } set { _environment = value; } }
        public bool IsValidObject { get { return _isValid; } }
        public bool ReadOnly { get { return _readOnly || !_isValid; } set { _readOnly = value; } }
        public bool IsReadOnly(string name) { return _isReadOnly(name); }
        public bool IsInvisible(string name) { return _isInvisible(name); }
        public bool IsRequired(string name) { return _isRequired(m_isRequired, name); }
        public bool IsHiddenPersonalData(string name) { return _isHiddenPersonalData(name); }
        public string GetType(string name) { return _getType(name); }
        public object GetValue(string name) { return _getValue(name); }
        public void SetValue(string name, string val) { _setValue(name, val); }
        public CompareModel Compare(IObject o) { return _compare(o, null); }
        public BvSelectList GetList(string name) { return _getList(name); }
        public event ValidationEvent Validation;
        public event ValidationEvent ValidationEnd;
        public event AfterPostEvent AfterPost;
      
        public Dictionary<string, string> GetFieldTags(string name)
        {
          return null;
        }
      #endregion

        private bool IsRIRPropChanged(string fld, cc_506_ForeignerType c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, cc_506_ForeignerType c)
        {
            var thisLookup = GetValue(fld + "Lookup") as IList;
            var thatLookup = c.GetValue(fld + "Lookup") as IList;
            bool bChangeLookupContent = thisLookup.Count != thatLookup.Count;
            if (!bChangeLookupContent)
            {
                for (int i = 0; i < thisLookup.Count; i++)
                {
                    if (((thisLookup[i] as IObject).Key as IComparable).CompareTo((thatLookup[i] as IObject).Key) != 0 &&
                        (thisLookup[i] as IObject).ToStringProp != null && ((thisLookup[i] as IObject).ToStringProp as IComparable).CompareTo((thatLookup[i] as IObject).ToStringProp) != 0)
                    {
                        bChangeLookupContent = true;
                        break;
                    }
                }
            }
            return bChangeLookupContent;
        }
        

      

        public cc_506_ForeignerType()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(cc_506_ForeignerType_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(cc_506_ForeignerType_PropertyChanged);
        }
        private void cc_506_ForeignerType_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as cc_506_ForeignerType).Changed(e.PropertyName);
            
        }
        
        public bool ForceToDelete() { return _Delete(true); }
        internal bool _Delete(bool isForceDelete)
        {
            if (!_ValidateOnDelete()) return false;
            _DeletingExtenders();
            m_IsMarkedToDelete = true;
            m_IsForcedToDelete = m_IsForcedToDelete ? m_IsForcedToDelete : isForceDelete;
            OnPropertyChanged("IsMarkedToDelete");
            _DeletedExtenders();
            Deleted();
            return true;
        }
        private bool _ValidateOnDelete(bool bReport = true)
        {
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            cc_506_ForeignerType obj = this;
            
        }
        private void _DeletedExtenders()
        {
            cc_506_ForeignerType obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                ValidationEnd(this, args);
                return args.Continue;
            }
            return false;
        }

        public void OnAfterPost()
        {
            if (AfterPost != null)
            {
                AfterPost(this, EventArgs.Empty);
            }
        }

        public FormSize FormSize
        {
            get { return FormSize.Undefined; }
        }
    
        private bool _isInvisible(string name)
        {
            
            return false;
                
        }

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
            }
        }


        internal Dictionary<string, Func<cc_506_ForeignerType, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<cc_506_ForeignerType, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<cc_506_ForeignerType, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<cc_506_ForeignerType, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<cc_506_ForeignerType, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<cc_506_ForeignerType, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<cc_506_ForeignerType, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        partial void Disposed();
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~cc_506_ForeignerType()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                m_Parent = null;
                m_permissions = null;
                
                this.ClearModelObjEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                }
                Disposed();
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            ParsingFormCollection(form);
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<cc_506_ForeignerType>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<cc_506_ForeignerType>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<cc_506_ForeignerType>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsForeignerType"; } }
            #endregion
        
            public delegate void on_action(cc_506_ForeignerType obj);
            private static Accessor g_Instance = CreateInstance<Accessor>();
            private CacheScope m_CS;
            public static Accessor Instance(CacheScope cs) 
            { 
                if (cs == null)
                    return g_Instance;
                lock(cs)
                {
                    object acc = cs.Get(typeof (Accessor));
                    if (acc != null)
                    {
                        return acc as Accessor;
                    }
                    Accessor ret = CreateInstance<Accessor>();
                    ret.m_CS = cs;
                    cs.Add(typeof(Accessor), ret);
                    return ret;
                }
            }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }
            public virtual cc_506_ForeignerType SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual cc_506_ForeignerType SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                )
            {
                return _SelectByKey(manager
                    , idfsUpload506
                    , null, null
                    );
            }
            

            private cc_506_ForeignerType _SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfsUpload506
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual cc_506_ForeignerType _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, cc_506_ForeignerType obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, cc_506_ForeignerType obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private cc_506_ForeignerType _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                cc_506_ForeignerType obj = null;
                try
                {
                    obj = cc_506_ForeignerType.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                    // created extenters - end
        
                    if (created != null)
                        created(obj);
                    obj.Created(manager);
                    _SetPermitions(obj._permissions, obj);
                    _SetupRequired(obj);
                    _SetupPersonalDataRestrictions(obj);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public cc_506_ForeignerType CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public cc_506_ForeignerType CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public cc_506_ForeignerType CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(cc_506_ForeignerType obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(cc_506_ForeignerType obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, cc_506_ForeignerType obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(cc_506_ForeignerType obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(cc_506_ForeignerType obj, bool bRethrowException)
            {
                ValidationModelException ex = ChainsValidate(obj);
                if (ex != null)
                {
                    if (bRethrowException)
                        throw ex;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                return true;
            }
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as cc_506_ForeignerType, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, cc_506_ForeignerType obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(cc_506_ForeignerType obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(cc_506_ForeignerType obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as cc_506_ForeignerType) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as cc_506_ForeignerType) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "cc_506_ForeignerTypeDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spUpload506Master_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<cc_506_ForeignerType, bool>> RequiredByField = new Dictionary<string, Func<cc_506_ForeignerType, bool>>();
            public static Dictionary<string, Func<cc_506_ForeignerType, bool>> RequiredByProperty = new Dictionary<string, Func<cc_506_ForeignerType, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            
            
    private static Dictionary<string, List<Func<bool>>> m_isHiddenPersonalData = new Dictionary<string, List<Func<bool>>>();
    internal static bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData.ContainsKey(name))
          return m_isHiddenPersonalData[name].Aggregate(false, (s,c) => s | c());
      return false;
    }

    private static void AddHiddenPersonalData(string name, Func<bool> func)
    {
      if (!m_isHiddenPersonalData.ContainsKey(name))
          m_isHiddenPersonalData.Add(name, new List<Func<bool>>());
      m_isHiddenPersonalData[name].Add(func);
    }
  
            
            static Meta()
            {
                
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, c, pars)),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_ForeignerType>().Post(manager, (cc_506_ForeignerType)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_ForeignerType>().Post(manager, (cc_506_ForeignerType)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Cancel",
                    ActionTypes.Cancel,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((cc_506_ForeignerType)c).MarkToDelete() && ObjectAccessor.PostInterface<cc_506_ForeignerType>().Post(manager, (cc_506_ForeignerType)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
                      null,
                      null,
                      false
                      ));
                    
        
                _SetupPersonalDataRestrictions();
            }
            
            
    private static void _SetupPersonalDataRestrictions()
    {
    

    }
  
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class cc_506_Municipality : 
        EditableObject<cc_506_Municipality>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsMunicipality), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsMunicipality { get; set; }
                
        [LocalizedDisplayName(_str_METROPOL)]
        [MapField(_str_METROPOL)]
        public abstract Int64 METROPOL { get; set; }
        protected Int64 METROPOL_Original { get { return ((EditableValue<Int64>)((dynamic)this)._mETROPOL).OriginalValue; } }
        protected Int64 METROPOL_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._mETROPOL).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsUpload506)]
        [MapField(_str_idfsUpload506)]
        public abstract Int64 idfsUpload506 { get; set; }
        protected Int64 idfsUpload506_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).OriginalValue; } }
        protected Int64 idfsUpload506_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<cc_506_Municipality, object> _get_func;
            internal Action<cc_506_Municipality, string> _set_func;
            internal Action<cc_506_Municipality, cc_506_Municipality, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsMunicipality = "idfsMunicipality";
        internal const string _str_METROPOL = "METROPOL";
        internal const string _str_idfsUpload506 = "idfsUpload506";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsMunicipality, _formname = _str_idfsMunicipality, _type = "Int64",
              _get_func = o => o.idfsMunicipality,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsMunicipality != newval) o.idfsMunicipality = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsMunicipality != c.idfsMunicipality || o.IsRIRPropChanged(_str_idfsMunicipality, c)) 
                  m.Add(_str_idfsMunicipality, o.ObjectIdent + _str_idfsMunicipality, o.ObjectIdent2 + _str_idfsMunicipality, o.ObjectIdent3 + _str_idfsMunicipality, "Int64", 
                    o.idfsMunicipality == null ? "" : o.idfsMunicipality.ToString(),                  
                  o.IsReadOnly(_str_idfsMunicipality), o.IsInvisible(_str_idfsMunicipality), o.IsRequired(_str_idfsMunicipality)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_METROPOL, _formname = _str_METROPOL, _type = "Int64",
              _get_func = o => o.METROPOL,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.METROPOL != newval) o.METROPOL = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.METROPOL != c.METROPOL || o.IsRIRPropChanged(_str_METROPOL, c)) 
                  m.Add(_str_METROPOL, o.ObjectIdent + _str_METROPOL, o.ObjectIdent2 + _str_METROPOL, o.ObjectIdent3 + _str_METROPOL, "Int64", 
                    o.METROPOL == null ? "" : o.METROPOL.ToString(),                  
                  o.IsReadOnly(_str_METROPOL), o.IsInvisible(_str_METROPOL), o.IsRequired(_str_METROPOL)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsUpload506, _formname = _str_idfsUpload506, _type = "Int64",
              _get_func = o => o.idfsUpload506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsUpload506 != newval) o.idfsUpload506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsUpload506 != c.idfsUpload506 || o.IsRIRPropChanged(_str_idfsUpload506, c)) 
                  m.Add(_str_idfsUpload506, o.ObjectIdent + _str_idfsUpload506, o.ObjectIdent2 + _str_idfsUpload506, o.ObjectIdent3 + _str_idfsUpload506, "Int64", 
                    o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(),                  
                  o.IsReadOnly(_str_idfsUpload506), o.IsInvisible(_str_idfsUpload506), o.IsRequired(_str_idfsUpload506)); 
                  }
              }, 
        
            new field_info()
        };
        #endregion
        
        private string _getType(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? "" : i._type;
        }
        private object _getValue(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? null : i._get_func(this);
        }
        private void _setValue(string name, string val)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            if (i != null) i._set_func(this, val);
        }
        internal CompareModel _compare(IObject o, CompareModel ret)
        {
            if (ret == null) ret = new CompareModel();
            if (o == null) return ret;
            cc_506_Municipality obj = (cc_506_Municipality)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "cc_506_Municipality";

        #region Parent and Clone supporting
        [XmlIgnore]
        public IObject Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; /*OnPropertyChanged(_str_Parent);*/ }
        }
        private IObject m_Parent;
        internal void _setParent()
        {
        
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as cc_506_Municipality;
            ret.bIsClone = true;
            ret.Cloned();
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager, bool bRestricted = false)
        {
            var ret = base.Clone() as cc_506_Municipality;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public cc_506_Municipality CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as cc_506_Municipality;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsMunicipality; } }
        public string KeyName { get { return "idfsMunicipality"; } }
        public object KeyLookup { get { return idfsMunicipality; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        [XmlIgnore]
        [LocalizedDisplayName("HasChanges")]
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                ;
            }
        }
        public new void RejectChanges()
        {
        
            base.RejectChanges();
        
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
        }
        private bool m_bForceDirty;
        public override void AcceptChanges()
        {
            m_bForceDirty = false;
            base.AcceptChanges();
        }
        [XmlIgnore]
        [LocalizedDisplayName("IsDirty")]
        public override bool IsDirty
        {
            get { return m_bForceDirty || base.IsDirty; }
        }
        public void SetChange()
        { 
            m_bForceDirty = true;
        }
        public void DeepSetChange()
        { 
            SetChange();
        
        }
        public bool MarkToDelete() { return _Delete(false); }
        public string ObjectName { get { return m_ObjectName; } }
        public string ObjectIdent { get { return ObjectName + "_" + Key.ToString() + "_"; } }
        
        public string ObjectIdent2 { get { return ObjectIdent; } }
          
        public string ObjectIdent3 { get { return ObjectIdent; } }
          
        public IObjectAccessor GetAccessor() { return _getAccessor(); }
        public IObjectPermissions GetPermissions() { return _permissions; }
        private IObjectEnvironment _environment;
        public IObjectEnvironment Environment { get { return _environment; } set { _environment = value; } }
        public bool IsValidObject { get { return _isValid; } }
        public bool ReadOnly { get { return _readOnly || !_isValid; } set { _readOnly = value; } }
        public bool IsReadOnly(string name) { return _isReadOnly(name); }
        public bool IsInvisible(string name) { return _isInvisible(name); }
        public bool IsRequired(string name) { return _isRequired(m_isRequired, name); }
        public bool IsHiddenPersonalData(string name) { return _isHiddenPersonalData(name); }
        public string GetType(string name) { return _getType(name); }
        public object GetValue(string name) { return _getValue(name); }
        public void SetValue(string name, string val) { _setValue(name, val); }
        public CompareModel Compare(IObject o) { return _compare(o, null); }
        public BvSelectList GetList(string name) { return _getList(name); }
        public event ValidationEvent Validation;
        public event ValidationEvent ValidationEnd;
        public event AfterPostEvent AfterPost;
      
        public Dictionary<string, string> GetFieldTags(string name)
        {
          return null;
        }
      #endregion

        private bool IsRIRPropChanged(string fld, cc_506_Municipality c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, cc_506_Municipality c)
        {
            var thisLookup = GetValue(fld + "Lookup") as IList;
            var thatLookup = c.GetValue(fld + "Lookup") as IList;
            bool bChangeLookupContent = thisLookup.Count != thatLookup.Count;
            if (!bChangeLookupContent)
            {
                for (int i = 0; i < thisLookup.Count; i++)
                {
                    if (((thisLookup[i] as IObject).Key as IComparable).CompareTo((thatLookup[i] as IObject).Key) != 0 &&
                        (thisLookup[i] as IObject).ToStringProp != null && ((thisLookup[i] as IObject).ToStringProp as IComparable).CompareTo((thatLookup[i] as IObject).ToStringProp) != 0)
                    {
                        bChangeLookupContent = true;
                        break;
                    }
                }
            }
            return bChangeLookupContent;
        }
        

      

        public cc_506_Municipality()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(cc_506_Municipality_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(cc_506_Municipality_PropertyChanged);
        }
        private void cc_506_Municipality_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as cc_506_Municipality).Changed(e.PropertyName);
            
        }
        
        public bool ForceToDelete() { return _Delete(true); }
        internal bool _Delete(bool isForceDelete)
        {
            if (!_ValidateOnDelete()) return false;
            _DeletingExtenders();
            m_IsMarkedToDelete = true;
            m_IsForcedToDelete = m_IsForcedToDelete ? m_IsForcedToDelete : isForceDelete;
            OnPropertyChanged("IsMarkedToDelete");
            _DeletedExtenders();
            Deleted();
            return true;
        }
        private bool _ValidateOnDelete(bool bReport = true)
        {
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            cc_506_Municipality obj = this;
            
        }
        private void _DeletedExtenders()
        {
            cc_506_Municipality obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                ValidationEnd(this, args);
                return args.Continue;
            }
            return false;
        }

        public void OnAfterPost()
        {
            if (AfterPost != null)
            {
                AfterPost(this, EventArgs.Empty);
            }
        }

        public FormSize FormSize
        {
            get { return FormSize.Undefined; }
        }
    
        private bool _isInvisible(string name)
        {
            
            return false;
                
        }

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
            }
        }


        internal Dictionary<string, Func<cc_506_Municipality, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<cc_506_Municipality, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<cc_506_Municipality, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<cc_506_Municipality, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<cc_506_Municipality, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<cc_506_Municipality, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<cc_506_Municipality, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        partial void Disposed();
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~cc_506_Municipality()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                m_Parent = null;
                m_permissions = null;
                
                this.ClearModelObjEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                }
                Disposed();
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            ParsingFormCollection(form);
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<cc_506_Municipality>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<cc_506_Municipality>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<cc_506_Municipality>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsMunicipality"; } }
            #endregion
        
            public delegate void on_action(cc_506_Municipality obj);
            private static Accessor g_Instance = CreateInstance<Accessor>();
            private CacheScope m_CS;
            public static Accessor Instance(CacheScope cs) 
            { 
                if (cs == null)
                    return g_Instance;
                lock(cs)
                {
                    object acc = cs.Get(typeof (Accessor));
                    if (acc != null)
                    {
                        return acc as Accessor;
                    }
                    Accessor ret = CreateInstance<Accessor>();
                    ret.m_CS = cs;
                    cs.Add(typeof(Accessor), ret);
                    return ret;
                }
            }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }
            public virtual cc_506_Municipality SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual cc_506_Municipality SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                )
            {
                return _SelectByKey(manager
                    , idfsUpload506
                    , null, null
                    );
            }
            

            private cc_506_Municipality _SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfsUpload506
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual cc_506_Municipality _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, cc_506_Municipality obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, cc_506_Municipality obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private cc_506_Municipality _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                cc_506_Municipality obj = null;
                try
                {
                    obj = cc_506_Municipality.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                    // created extenters - end
        
                    if (created != null)
                        created(obj);
                    obj.Created(manager);
                    _SetPermitions(obj._permissions, obj);
                    _SetupRequired(obj);
                    _SetupPersonalDataRestrictions(obj);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public cc_506_Municipality CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public cc_506_Municipality CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public cc_506_Municipality CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(cc_506_Municipality obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(cc_506_Municipality obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, cc_506_Municipality obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(cc_506_Municipality obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(cc_506_Municipality obj, bool bRethrowException)
            {
                ValidationModelException ex = ChainsValidate(obj);
                if (ex != null)
                {
                    if (bRethrowException)
                        throw ex;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                return true;
            }
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as cc_506_Municipality, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, cc_506_Municipality obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(cc_506_Municipality obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(cc_506_Municipality obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as cc_506_Municipality) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as cc_506_Municipality) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "cc_506_MunicipalityDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spUpload506Master_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<cc_506_Municipality, bool>> RequiredByField = new Dictionary<string, Func<cc_506_Municipality, bool>>();
            public static Dictionary<string, Func<cc_506_Municipality, bool>> RequiredByProperty = new Dictionary<string, Func<cc_506_Municipality, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            
            
    private static Dictionary<string, List<Func<bool>>> m_isHiddenPersonalData = new Dictionary<string, List<Func<bool>>>();
    internal static bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData.ContainsKey(name))
          return m_isHiddenPersonalData[name].Aggregate(false, (s,c) => s | c());
      return false;
    }

    private static void AddHiddenPersonalData(string name, Func<bool> func)
    {
      if (!m_isHiddenPersonalData.ContainsKey(name))
          m_isHiddenPersonalData.Add(name, new List<Func<bool>>());
      m_isHiddenPersonalData[name].Add(func);
    }
  
            
            static Meta()
            {
                
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, c, pars)),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_Municipality>().Post(manager, (cc_506_Municipality)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_Municipality>().Post(manager, (cc_506_Municipality)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Cancel",
                    ActionTypes.Cancel,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((cc_506_Municipality)c).MarkToDelete() && ObjectAccessor.PostInterface<cc_506_Municipality>().Post(manager, (cc_506_Municipality)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
                      null,
                      null,
                      false
                      ));
                    
        
                _SetupPersonalDataRestrictions();
            }
            
            
    private static void _SetupPersonalDataRestrictions()
    {
    

    }
  
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class cc_506_Hospitalization : 
        EditableObject<cc_506_Hospitalization>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsHospitalization), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsHospitalization { get; set; }
                
        [LocalizedDisplayName(_str_HOSPITAL)]
        [MapField(_str_HOSPITAL)]
        public abstract Int64 HOSPITAL { get; set; }
        protected Int64 HOSPITAL_Original { get { return ((EditableValue<Int64>)((dynamic)this)._hOSPITAL).OriginalValue; } }
        protected Int64 HOSPITAL_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._hOSPITAL).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsUpload506)]
        [MapField(_str_idfsUpload506)]
        public abstract Int64 idfsUpload506 { get; set; }
        protected Int64 idfsUpload506_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).OriginalValue; } }
        protected Int64 idfsUpload506_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<cc_506_Hospitalization, object> _get_func;
            internal Action<cc_506_Hospitalization, string> _set_func;
            internal Action<cc_506_Hospitalization, cc_506_Hospitalization, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsHospitalization = "idfsHospitalization";
        internal const string _str_HOSPITAL = "HOSPITAL";
        internal const string _str_idfsUpload506 = "idfsUpload506";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsHospitalization, _formname = _str_idfsHospitalization, _type = "Int64",
              _get_func = o => o.idfsHospitalization,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsHospitalization != newval) o.idfsHospitalization = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsHospitalization != c.idfsHospitalization || o.IsRIRPropChanged(_str_idfsHospitalization, c)) 
                  m.Add(_str_idfsHospitalization, o.ObjectIdent + _str_idfsHospitalization, o.ObjectIdent2 + _str_idfsHospitalization, o.ObjectIdent3 + _str_idfsHospitalization, "Int64", 
                    o.idfsHospitalization == null ? "" : o.idfsHospitalization.ToString(),                  
                  o.IsReadOnly(_str_idfsHospitalization), o.IsInvisible(_str_idfsHospitalization), o.IsRequired(_str_idfsHospitalization)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_HOSPITAL, _formname = _str_HOSPITAL, _type = "Int64",
              _get_func = o => o.HOSPITAL,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.HOSPITAL != newval) o.HOSPITAL = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.HOSPITAL != c.HOSPITAL || o.IsRIRPropChanged(_str_HOSPITAL, c)) 
                  m.Add(_str_HOSPITAL, o.ObjectIdent + _str_HOSPITAL, o.ObjectIdent2 + _str_HOSPITAL, o.ObjectIdent3 + _str_HOSPITAL, "Int64", 
                    o.HOSPITAL == null ? "" : o.HOSPITAL.ToString(),                  
                  o.IsReadOnly(_str_HOSPITAL), o.IsInvisible(_str_HOSPITAL), o.IsRequired(_str_HOSPITAL)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsUpload506, _formname = _str_idfsUpload506, _type = "Int64",
              _get_func = o => o.idfsUpload506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsUpload506 != newval) o.idfsUpload506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsUpload506 != c.idfsUpload506 || o.IsRIRPropChanged(_str_idfsUpload506, c)) 
                  m.Add(_str_idfsUpload506, o.ObjectIdent + _str_idfsUpload506, o.ObjectIdent2 + _str_idfsUpload506, o.ObjectIdent3 + _str_idfsUpload506, "Int64", 
                    o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(),                  
                  o.IsReadOnly(_str_idfsUpload506), o.IsInvisible(_str_idfsUpload506), o.IsRequired(_str_idfsUpload506)); 
                  }
              }, 
        
            new field_info()
        };
        #endregion
        
        private string _getType(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? "" : i._type;
        }
        private object _getValue(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? null : i._get_func(this);
        }
        private void _setValue(string name, string val)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            if (i != null) i._set_func(this, val);
        }
        internal CompareModel _compare(IObject o, CompareModel ret)
        {
            if (ret == null) ret = new CompareModel();
            if (o == null) return ret;
            cc_506_Hospitalization obj = (cc_506_Hospitalization)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "cc_506_Hospitalization";

        #region Parent and Clone supporting
        [XmlIgnore]
        public IObject Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; /*OnPropertyChanged(_str_Parent);*/ }
        }
        private IObject m_Parent;
        internal void _setParent()
        {
        
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as cc_506_Hospitalization;
            ret.bIsClone = true;
            ret.Cloned();
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager, bool bRestricted = false)
        {
            var ret = base.Clone() as cc_506_Hospitalization;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public cc_506_Hospitalization CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as cc_506_Hospitalization;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsHospitalization; } }
        public string KeyName { get { return "idfsHospitalization"; } }
        public object KeyLookup { get { return idfsHospitalization; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        [XmlIgnore]
        [LocalizedDisplayName("HasChanges")]
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                ;
            }
        }
        public new void RejectChanges()
        {
        
            base.RejectChanges();
        
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
        }
        private bool m_bForceDirty;
        public override void AcceptChanges()
        {
            m_bForceDirty = false;
            base.AcceptChanges();
        }
        [XmlIgnore]
        [LocalizedDisplayName("IsDirty")]
        public override bool IsDirty
        {
            get { return m_bForceDirty || base.IsDirty; }
        }
        public void SetChange()
        { 
            m_bForceDirty = true;
        }
        public void DeepSetChange()
        { 
            SetChange();
        
        }
        public bool MarkToDelete() { return _Delete(false); }
        public string ObjectName { get { return m_ObjectName; } }
        public string ObjectIdent { get { return ObjectName + "_" + Key.ToString() + "_"; } }
        
        public string ObjectIdent2 { get { return ObjectIdent; } }
          
        public string ObjectIdent3 { get { return ObjectIdent; } }
          
        public IObjectAccessor GetAccessor() { return _getAccessor(); }
        public IObjectPermissions GetPermissions() { return _permissions; }
        private IObjectEnvironment _environment;
        public IObjectEnvironment Environment { get { return _environment; } set { _environment = value; } }
        public bool IsValidObject { get { return _isValid; } }
        public bool ReadOnly { get { return _readOnly || !_isValid; } set { _readOnly = value; } }
        public bool IsReadOnly(string name) { return _isReadOnly(name); }
        public bool IsInvisible(string name) { return _isInvisible(name); }
        public bool IsRequired(string name) { return _isRequired(m_isRequired, name); }
        public bool IsHiddenPersonalData(string name) { return _isHiddenPersonalData(name); }
        public string GetType(string name) { return _getType(name); }
        public object GetValue(string name) { return _getValue(name); }
        public void SetValue(string name, string val) { _setValue(name, val); }
        public CompareModel Compare(IObject o) { return _compare(o, null); }
        public BvSelectList GetList(string name) { return _getList(name); }
        public event ValidationEvent Validation;
        public event ValidationEvent ValidationEnd;
        public event AfterPostEvent AfterPost;
      
        public Dictionary<string, string> GetFieldTags(string name)
        {
          return null;
        }
      #endregion

        private bool IsRIRPropChanged(string fld, cc_506_Hospitalization c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, cc_506_Hospitalization c)
        {
            var thisLookup = GetValue(fld + "Lookup") as IList;
            var thatLookup = c.GetValue(fld + "Lookup") as IList;
            bool bChangeLookupContent = thisLookup.Count != thatLookup.Count;
            if (!bChangeLookupContent)
            {
                for (int i = 0; i < thisLookup.Count; i++)
                {
                    if (((thisLookup[i] as IObject).Key as IComparable).CompareTo((thatLookup[i] as IObject).Key) != 0 &&
                        (thisLookup[i] as IObject).ToStringProp != null && ((thisLookup[i] as IObject).ToStringProp as IComparable).CompareTo((thatLookup[i] as IObject).ToStringProp) != 0)
                    {
                        bChangeLookupContent = true;
                        break;
                    }
                }
            }
            return bChangeLookupContent;
        }
        

      

        public cc_506_Hospitalization()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(cc_506_Hospitalization_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(cc_506_Hospitalization_PropertyChanged);
        }
        private void cc_506_Hospitalization_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as cc_506_Hospitalization).Changed(e.PropertyName);
            
        }
        
        public bool ForceToDelete() { return _Delete(true); }
        internal bool _Delete(bool isForceDelete)
        {
            if (!_ValidateOnDelete()) return false;
            _DeletingExtenders();
            m_IsMarkedToDelete = true;
            m_IsForcedToDelete = m_IsForcedToDelete ? m_IsForcedToDelete : isForceDelete;
            OnPropertyChanged("IsMarkedToDelete");
            _DeletedExtenders();
            Deleted();
            return true;
        }
        private bool _ValidateOnDelete(bool bReport = true)
        {
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            cc_506_Hospitalization obj = this;
            
        }
        private void _DeletedExtenders()
        {
            cc_506_Hospitalization obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                ValidationEnd(this, args);
                return args.Continue;
            }
            return false;
        }

        public void OnAfterPost()
        {
            if (AfterPost != null)
            {
                AfterPost(this, EventArgs.Empty);
            }
        }

        public FormSize FormSize
        {
            get { return FormSize.Undefined; }
        }
    
        private bool _isInvisible(string name)
        {
            
            return false;
                
        }

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
            }
        }


        internal Dictionary<string, Func<cc_506_Hospitalization, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<cc_506_Hospitalization, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<cc_506_Hospitalization, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<cc_506_Hospitalization, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<cc_506_Hospitalization, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<cc_506_Hospitalization, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<cc_506_Hospitalization, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        partial void Disposed();
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~cc_506_Hospitalization()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                m_Parent = null;
                m_permissions = null;
                
                this.ClearModelObjEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                }
                Disposed();
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            ParsingFormCollection(form);
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<cc_506_Hospitalization>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<cc_506_Hospitalization>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<cc_506_Hospitalization>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsHospitalization"; } }
            #endregion
        
            public delegate void on_action(cc_506_Hospitalization obj);
            private static Accessor g_Instance = CreateInstance<Accessor>();
            private CacheScope m_CS;
            public static Accessor Instance(CacheScope cs) 
            { 
                if (cs == null)
                    return g_Instance;
                lock(cs)
                {
                    object acc = cs.Get(typeof (Accessor));
                    if (acc != null)
                    {
                        return acc as Accessor;
                    }
                    Accessor ret = CreateInstance<Accessor>();
                    ret.m_CS = cs;
                    cs.Add(typeof(Accessor), ret);
                    return ret;
                }
            }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }
            public virtual cc_506_Hospitalization SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual cc_506_Hospitalization SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                )
            {
                return _SelectByKey(manager
                    , idfsUpload506
                    , null, null
                    );
            }
            

            private cc_506_Hospitalization _SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfsUpload506
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual cc_506_Hospitalization _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, cc_506_Hospitalization obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, cc_506_Hospitalization obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private cc_506_Hospitalization _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                cc_506_Hospitalization obj = null;
                try
                {
                    obj = cc_506_Hospitalization.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                    // created extenters - end
        
                    if (created != null)
                        created(obj);
                    obj.Created(manager);
                    _SetPermitions(obj._permissions, obj);
                    _SetupRequired(obj);
                    _SetupPersonalDataRestrictions(obj);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public cc_506_Hospitalization CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public cc_506_Hospitalization CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public cc_506_Hospitalization CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(cc_506_Hospitalization obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(cc_506_Hospitalization obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, cc_506_Hospitalization obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(cc_506_Hospitalization obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(cc_506_Hospitalization obj, bool bRethrowException)
            {
                ValidationModelException ex = ChainsValidate(obj);
                if (ex != null)
                {
                    if (bRethrowException)
                        throw ex;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                return true;
            }
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as cc_506_Hospitalization, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, cc_506_Hospitalization obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(cc_506_Hospitalization obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(cc_506_Hospitalization obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as cc_506_Hospitalization) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as cc_506_Hospitalization) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "cc_506_HospitalizationDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spUpload506Master_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<cc_506_Hospitalization, bool>> RequiredByField = new Dictionary<string, Func<cc_506_Hospitalization, bool>>();
            public static Dictionary<string, Func<cc_506_Hospitalization, bool>> RequiredByProperty = new Dictionary<string, Func<cc_506_Hospitalization, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            
            
    private static Dictionary<string, List<Func<bool>>> m_isHiddenPersonalData = new Dictionary<string, List<Func<bool>>>();
    internal static bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData.ContainsKey(name))
          return m_isHiddenPersonalData[name].Aggregate(false, (s,c) => s | c());
      return false;
    }

    private static void AddHiddenPersonalData(string name, Func<bool> func)
    {
      if (!m_isHiddenPersonalData.ContainsKey(name))
          m_isHiddenPersonalData.Add(name, new List<Func<bool>>());
      m_isHiddenPersonalData[name].Add(func);
    }
  
            
            static Meta()
            {
                
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, c, pars)),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_Hospitalization>().Post(manager, (cc_506_Hospitalization)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_Hospitalization>().Post(manager, (cc_506_Hospitalization)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Cancel",
                    ActionTypes.Cancel,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((cc_506_Hospitalization)c).MarkToDelete() && ObjectAccessor.PostInterface<cc_506_Hospitalization>().Post(manager, (cc_506_Hospitalization)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
                      null,
                      null,
                      false
                      ));
                    
        
                _SetupPersonalDataRestrictions();
            }
            
            
    private static void _SetupPersonalDataRestrictions()
    {
    

    }
  
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class cc_506_PatientType : 
        EditableObject<cc_506_PatientType>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsPatientType), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsPatientType { get; set; }
                
        [LocalizedDisplayName(_str_TYPE)]
        [MapField(_str_TYPE)]
        public abstract Int64 TYPE { get; set; }
        protected Int64 TYPE_Original { get { return ((EditableValue<Int64>)((dynamic)this)._tYPE).OriginalValue; } }
        protected Int64 TYPE_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._tYPE).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsUpload506)]
        [MapField(_str_idfsUpload506)]
        public abstract Int64 idfsUpload506 { get; set; }
        protected Int64 idfsUpload506_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).OriginalValue; } }
        protected Int64 idfsUpload506_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<cc_506_PatientType, object> _get_func;
            internal Action<cc_506_PatientType, string> _set_func;
            internal Action<cc_506_PatientType, cc_506_PatientType, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsPatientType = "idfsPatientType";
        internal const string _str_TYPE = "TYPE";
        internal const string _str_idfsUpload506 = "idfsUpload506";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_idfsPatientType, _formname = _str_idfsPatientType, _type = "Int64",
              _get_func = o => o.idfsPatientType,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsPatientType != newval) o.idfsPatientType = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsPatientType != c.idfsPatientType || o.IsRIRPropChanged(_str_idfsPatientType, c)) 
                  m.Add(_str_idfsPatientType, o.ObjectIdent + _str_idfsPatientType, o.ObjectIdent2 + _str_idfsPatientType, o.ObjectIdent3 + _str_idfsPatientType, "Int64", 
                    o.idfsPatientType == null ? "" : o.idfsPatientType.ToString(),                  
                  o.IsReadOnly(_str_idfsPatientType), o.IsInvisible(_str_idfsPatientType), o.IsRequired(_str_idfsPatientType)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_TYPE, _formname = _str_TYPE, _type = "Int64",
              _get_func = o => o.TYPE,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.TYPE != newval) o.TYPE = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.TYPE != c.TYPE || o.IsRIRPropChanged(_str_TYPE, c)) 
                  m.Add(_str_TYPE, o.ObjectIdent + _str_TYPE, o.ObjectIdent2 + _str_TYPE, o.ObjectIdent3 + _str_TYPE, "Int64", 
                    o.TYPE == null ? "" : o.TYPE.ToString(),                  
                  o.IsReadOnly(_str_TYPE), o.IsInvisible(_str_TYPE), o.IsRequired(_str_TYPE)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsUpload506, _formname = _str_idfsUpload506, _type = "Int64",
              _get_func = o => o.idfsUpload506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsUpload506 != newval) o.idfsUpload506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsUpload506 != c.idfsUpload506 || o.IsRIRPropChanged(_str_idfsUpload506, c)) 
                  m.Add(_str_idfsUpload506, o.ObjectIdent + _str_idfsUpload506, o.ObjectIdent2 + _str_idfsUpload506, o.ObjectIdent3 + _str_idfsUpload506, "Int64", 
                    o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(),                  
                  o.IsReadOnly(_str_idfsUpload506), o.IsInvisible(_str_idfsUpload506), o.IsRequired(_str_idfsUpload506)); 
                  }
              }, 
        
            new field_info()
        };
        #endregion
        
        private string _getType(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? "" : i._type;
        }
        private object _getValue(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? null : i._get_func(this);
        }
        private void _setValue(string name, string val)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            if (i != null) i._set_func(this, val);
        }
        internal CompareModel _compare(IObject o, CompareModel ret)
        {
            if (ret == null) ret = new CompareModel();
            if (o == null) return ret;
            cc_506_PatientType obj = (cc_506_PatientType)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "cc_506_PatientType";

        #region Parent and Clone supporting
        [XmlIgnore]
        public IObject Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; /*OnPropertyChanged(_str_Parent);*/ }
        }
        private IObject m_Parent;
        internal void _setParent()
        {
        
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as cc_506_PatientType;
            ret.bIsClone = true;
            ret.Cloned();
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager, bool bRestricted = false)
        {
            var ret = base.Clone() as cc_506_PatientType;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public cc_506_PatientType CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as cc_506_PatientType;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfsPatientType; } }
        public string KeyName { get { return "idfsPatientType"; } }
        public object KeyLookup { get { return idfsPatientType; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        [XmlIgnore]
        [LocalizedDisplayName("HasChanges")]
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                ;
            }
        }
        public new void RejectChanges()
        {
        
            base.RejectChanges();
        
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
        }
        private bool m_bForceDirty;
        public override void AcceptChanges()
        {
            m_bForceDirty = false;
            base.AcceptChanges();
        }
        [XmlIgnore]
        [LocalizedDisplayName("IsDirty")]
        public override bool IsDirty
        {
            get { return m_bForceDirty || base.IsDirty; }
        }
        public void SetChange()
        { 
            m_bForceDirty = true;
        }
        public void DeepSetChange()
        { 
            SetChange();
        
        }
        public bool MarkToDelete() { return _Delete(false); }
        public string ObjectName { get { return m_ObjectName; } }
        public string ObjectIdent { get { return ObjectName + "_" + Key.ToString() + "_"; } }
        
        public string ObjectIdent2 { get { return ObjectIdent; } }
          
        public string ObjectIdent3 { get { return ObjectIdent; } }
          
        public IObjectAccessor GetAccessor() { return _getAccessor(); }
        public IObjectPermissions GetPermissions() { return _permissions; }
        private IObjectEnvironment _environment;
        public IObjectEnvironment Environment { get { return _environment; } set { _environment = value; } }
        public bool IsValidObject { get { return _isValid; } }
        public bool ReadOnly { get { return _readOnly || !_isValid; } set { _readOnly = value; } }
        public bool IsReadOnly(string name) { return _isReadOnly(name); }
        public bool IsInvisible(string name) { return _isInvisible(name); }
        public bool IsRequired(string name) { return _isRequired(m_isRequired, name); }
        public bool IsHiddenPersonalData(string name) { return _isHiddenPersonalData(name); }
        public string GetType(string name) { return _getType(name); }
        public object GetValue(string name) { return _getValue(name); }
        public void SetValue(string name, string val) { _setValue(name, val); }
        public CompareModel Compare(IObject o) { return _compare(o, null); }
        public BvSelectList GetList(string name) { return _getList(name); }
        public event ValidationEvent Validation;
        public event ValidationEvent ValidationEnd;
        public event AfterPostEvent AfterPost;
      
        public Dictionary<string, string> GetFieldTags(string name)
        {
          return null;
        }
      #endregion

        private bool IsRIRPropChanged(string fld, cc_506_PatientType c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, cc_506_PatientType c)
        {
            var thisLookup = GetValue(fld + "Lookup") as IList;
            var thatLookup = c.GetValue(fld + "Lookup") as IList;
            bool bChangeLookupContent = thisLookup.Count != thatLookup.Count;
            if (!bChangeLookupContent)
            {
                for (int i = 0; i < thisLookup.Count; i++)
                {
                    if (((thisLookup[i] as IObject).Key as IComparable).CompareTo((thatLookup[i] as IObject).Key) != 0 &&
                        (thisLookup[i] as IObject).ToStringProp != null && ((thisLookup[i] as IObject).ToStringProp as IComparable).CompareTo((thatLookup[i] as IObject).ToStringProp) != 0)
                    {
                        bChangeLookupContent = true;
                        break;
                    }
                }
            }
            return bChangeLookupContent;
        }
        

      

        public cc_506_PatientType()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(cc_506_PatientType_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(cc_506_PatientType_PropertyChanged);
        }
        private void cc_506_PatientType_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as cc_506_PatientType).Changed(e.PropertyName);
            
        }
        
        public bool ForceToDelete() { return _Delete(true); }
        internal bool _Delete(bool isForceDelete)
        {
            if (!_ValidateOnDelete()) return false;
            _DeletingExtenders();
            m_IsMarkedToDelete = true;
            m_IsForcedToDelete = m_IsForcedToDelete ? m_IsForcedToDelete : isForceDelete;
            OnPropertyChanged("IsMarkedToDelete");
            _DeletedExtenders();
            Deleted();
            return true;
        }
        private bool _ValidateOnDelete(bool bReport = true)
        {
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            cc_506_PatientType obj = this;
            
        }
        private void _DeletedExtenders()
        {
            cc_506_PatientType obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                ValidationEnd(this, args);
                return args.Continue;
            }
            return false;
        }

        public void OnAfterPost()
        {
            if (AfterPost != null)
            {
                AfterPost(this, EventArgs.Empty);
            }
        }

        public FormSize FormSize
        {
            get { return FormSize.Undefined; }
        }
    
        private bool _isInvisible(string name)
        {
            
            return false;
                
        }

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
            }
        }


        internal Dictionary<string, Func<cc_506_PatientType, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<cc_506_PatientType, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<cc_506_PatientType, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<cc_506_PatientType, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<cc_506_PatientType, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<cc_506_PatientType, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<cc_506_PatientType, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        partial void Disposed();
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~cc_506_PatientType()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                m_Parent = null;
                m_permissions = null;
                
                this.ClearModelObjEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                }
                Disposed();
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            ParsingFormCollection(form);
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<cc_506_PatientType>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<cc_506_PatientType>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<cc_506_PatientType>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsPatientType"; } }
            #endregion
        
            public delegate void on_action(cc_506_PatientType obj);
            private static Accessor g_Instance = CreateInstance<Accessor>();
            private CacheScope m_CS;
            public static Accessor Instance(CacheScope cs) 
            { 
                if (cs == null)
                    return g_Instance;
                lock(cs)
                {
                    object acc = cs.Get(typeof (Accessor));
                    if (acc != null)
                    {
                        return acc as Accessor;
                    }
                    Accessor ret = CreateInstance<Accessor>();
                    ret.m_CS = cs;
                    cs.Add(typeof(Accessor), ret);
                    return ret;
                }
            }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }
            public virtual cc_506_PatientType SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual cc_506_PatientType SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                )
            {
                return _SelectByKey(manager
                    , idfsUpload506
                    , null, null
                    );
            }
            

            private cc_506_PatientType _SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfsUpload506
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual cc_506_PatientType _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, cc_506_PatientType obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, cc_506_PatientType obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private cc_506_PatientType _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                cc_506_PatientType obj = null;
                try
                {
                    obj = cc_506_PatientType.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                    // created extenters - end
        
                    if (created != null)
                        created(obj);
                    obj.Created(manager);
                    _SetPermitions(obj._permissions, obj);
                    _SetupRequired(obj);
                    _SetupPersonalDataRestrictions(obj);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public cc_506_PatientType CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public cc_506_PatientType CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public cc_506_PatientType CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(cc_506_PatientType obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(cc_506_PatientType obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, cc_506_PatientType obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(cc_506_PatientType obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(cc_506_PatientType obj, bool bRethrowException)
            {
                ValidationModelException ex = ChainsValidate(obj);
                if (ex != null)
                {
                    if (bRethrowException)
                        throw ex;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                return true;
            }
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as cc_506_PatientType, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, cc_506_PatientType obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(cc_506_PatientType obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(cc_506_PatientType obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as cc_506_PatientType) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as cc_506_PatientType) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "cc_506_PatientTypeDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spUpload506Master_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<cc_506_PatientType, bool>> RequiredByField = new Dictionary<string, Func<cc_506_PatientType, bool>>();
            public static Dictionary<string, Func<cc_506_PatientType, bool>> RequiredByProperty = new Dictionary<string, Func<cc_506_PatientType, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            
            
    private static Dictionary<string, List<Func<bool>>> m_isHiddenPersonalData = new Dictionary<string, List<Func<bool>>>();
    internal static bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData.ContainsKey(name))
          return m_isHiddenPersonalData[name].Aggregate(false, (s,c) => s | c());
      return false;
    }

    private static void AddHiddenPersonalData(string name, Func<bool> func)
    {
      if (!m_isHiddenPersonalData.ContainsKey(name))
          m_isHiddenPersonalData.Add(name, new List<Func<bool>>());
      m_isHiddenPersonalData[name].Add(func);
    }
  
            
            static Meta()
            {
                
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, c, pars)),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_PatientType>().Post(manager, (cc_506_PatientType)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_PatientType>().Post(manager, (cc_506_PatientType)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Cancel",
                    ActionTypes.Cancel,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((cc_506_PatientType)c).MarkToDelete() && ObjectAccessor.PostInterface<cc_506_PatientType>().Post(manager, (cc_506_PatientType)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
                      null,
                      null,
                      false
                      ));
                    
        
                _SetupPersonalDataRestrictions();
            }
            
            
    private static void _SetupPersonalDataRestrictions()
    {
    

    }
  
        }
        #endregion
    

        #endregion
        }
    
        
    [XmlType(AnonymousType = true)]
    public abstract partial class cc_506_Complication : 
        EditableObject<cc_506_Complication>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_DISEASE), NonUpdatable, PrimaryKey]
        public abstract Int64 DISEASE { get; set; }
                
        [LocalizedDisplayName(_str_idfsTentativeDiagnosis)]
        [MapField(_str_idfsTentativeDiagnosis)]
        public abstract Int64 idfsTentativeDiagnosis { get; set; }
        protected Int64 idfsTentativeDiagnosis_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsTentativeDiagnosis).OriginalValue; } }
        protected Int64 idfsTentativeDiagnosis_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsTentativeDiagnosis).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsFormTemplate)]
        [MapField(_str_idfsFormTemplate)]
        public abstract Int64 idfsFormTemplate { get; set; }
        protected Int64 idfsFormTemplate_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsFormTemplate).OriginalValue; } }
        protected Int64 idfsFormTemplate_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsFormTemplate).PreviousValue; } }
                
        [LocalizedDisplayName(_str_COMPLICA)]
        [MapField(_str_COMPLICA)]
        public abstract Int64 COMPLICA { get; set; }
        protected Int64 COMPLICA_Original { get { return ((EditableValue<Int64>)((dynamic)this)._cOMPLICA).OriginalValue; } }
        protected Int64 COMPLICA_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._cOMPLICA).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsComplication)]
        [MapField(_str_idfsComplication)]
        public abstract Int64 idfsComplication { get; set; }
        protected Int64 idfsComplication_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsComplication).OriginalValue; } }
        protected Int64 idfsComplication_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsComplication).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfsUpload506)]
        [MapField(_str_idfsUpload506)]
        public abstract Int64 idfsUpload506 { get; set; }
        protected Int64 idfsUpload506_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).OriginalValue; } }
        protected Int64 idfsUpload506_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506).PreviousValue; } }
                
        #region Set/Get values
        #region filed_info definifion
        protected class field_info
        {
            internal string _name;
            internal string _formname;
            internal string _type;
            internal Func<cc_506_Complication, object> _get_func;
            internal Action<cc_506_Complication, string> _set_func;
            internal Action<cc_506_Complication, cc_506_Complication, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_DISEASE = "DISEASE";
        internal const string _str_idfsTentativeDiagnosis = "idfsTentativeDiagnosis";
        internal const string _str_idfsFormTemplate = "idfsFormTemplate";
        internal const string _str_COMPLICA = "COMPLICA";
        internal const string _str_idfsComplication = "idfsComplication";
        internal const string _str_idfsUpload506 = "idfsUpload506";
        private static readonly field_info[] _field_infos =
        {
                  
            new field_info {
              _name = _str_DISEASE, _formname = _str_DISEASE, _type = "Int64",
              _get_func = o => o.DISEASE,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.DISEASE != newval) o.DISEASE = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.DISEASE != c.DISEASE || o.IsRIRPropChanged(_str_DISEASE, c)) 
                  m.Add(_str_DISEASE, o.ObjectIdent + _str_DISEASE, o.ObjectIdent2 + _str_DISEASE, o.ObjectIdent3 + _str_DISEASE, "Int64", 
                    o.DISEASE == null ? "" : o.DISEASE.ToString(),                  
                  o.IsReadOnly(_str_DISEASE), o.IsInvisible(_str_DISEASE), o.IsRequired(_str_DISEASE)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsTentativeDiagnosis, _formname = _str_idfsTentativeDiagnosis, _type = "Int64",
              _get_func = o => o.idfsTentativeDiagnosis,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsTentativeDiagnosis != newval) o.idfsTentativeDiagnosis = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsTentativeDiagnosis != c.idfsTentativeDiagnosis || o.IsRIRPropChanged(_str_idfsTentativeDiagnosis, c)) 
                  m.Add(_str_idfsTentativeDiagnosis, o.ObjectIdent + _str_idfsTentativeDiagnosis, o.ObjectIdent2 + _str_idfsTentativeDiagnosis, o.ObjectIdent3 + _str_idfsTentativeDiagnosis, "Int64", 
                    o.idfsTentativeDiagnosis == null ? "" : o.idfsTentativeDiagnosis.ToString(),                  
                  o.IsReadOnly(_str_idfsTentativeDiagnosis), o.IsInvisible(_str_idfsTentativeDiagnosis), o.IsRequired(_str_idfsTentativeDiagnosis)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsFormTemplate, _formname = _str_idfsFormTemplate, _type = "Int64",
              _get_func = o => o.idfsFormTemplate,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsFormTemplate != newval) o.idfsFormTemplate = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsFormTemplate != c.idfsFormTemplate || o.IsRIRPropChanged(_str_idfsFormTemplate, c)) 
                  m.Add(_str_idfsFormTemplate, o.ObjectIdent + _str_idfsFormTemplate, o.ObjectIdent2 + _str_idfsFormTemplate, o.ObjectIdent3 + _str_idfsFormTemplate, "Int64", 
                    o.idfsFormTemplate == null ? "" : o.idfsFormTemplate.ToString(),                  
                  o.IsReadOnly(_str_idfsFormTemplate), o.IsInvisible(_str_idfsFormTemplate), o.IsRequired(_str_idfsFormTemplate)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_COMPLICA, _formname = _str_COMPLICA, _type = "Int64",
              _get_func = o => o.COMPLICA,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.COMPLICA != newval) o.COMPLICA = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.COMPLICA != c.COMPLICA || o.IsRIRPropChanged(_str_COMPLICA, c)) 
                  m.Add(_str_COMPLICA, o.ObjectIdent + _str_COMPLICA, o.ObjectIdent2 + _str_COMPLICA, o.ObjectIdent3 + _str_COMPLICA, "Int64", 
                    o.COMPLICA == null ? "" : o.COMPLICA.ToString(),                  
                  o.IsReadOnly(_str_COMPLICA), o.IsInvisible(_str_COMPLICA), o.IsRequired(_str_COMPLICA)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsComplication, _formname = _str_idfsComplication, _type = "Int64",
              _get_func = o => o.idfsComplication,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsComplication != newval) o.idfsComplication = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsComplication != c.idfsComplication || o.IsRIRPropChanged(_str_idfsComplication, c)) 
                  m.Add(_str_idfsComplication, o.ObjectIdent + _str_idfsComplication, o.ObjectIdent2 + _str_idfsComplication, o.ObjectIdent3 + _str_idfsComplication, "Int64", 
                    o.idfsComplication == null ? "" : o.idfsComplication.ToString(),                  
                  o.IsReadOnly(_str_idfsComplication), o.IsInvisible(_str_idfsComplication), o.IsRequired(_str_idfsComplication)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfsUpload506, _formname = _str_idfsUpload506, _type = "Int64",
              _get_func = o => o.idfsUpload506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsUpload506 != newval) o.idfsUpload506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsUpload506 != c.idfsUpload506 || o.IsRIRPropChanged(_str_idfsUpload506, c)) 
                  m.Add(_str_idfsUpload506, o.ObjectIdent + _str_idfsUpload506, o.ObjectIdent2 + _str_idfsUpload506, o.ObjectIdent3 + _str_idfsUpload506, "Int64", 
                    o.idfsUpload506 == null ? "" : o.idfsUpload506.ToString(),                  
                  o.IsReadOnly(_str_idfsUpload506), o.IsInvisible(_str_idfsUpload506), o.IsRequired(_str_idfsUpload506)); 
                  }
              }, 
        
            new field_info()
        };
        #endregion
        
        private string _getType(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? "" : i._type;
        }
        private object _getValue(string name)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            return i == null ? null : i._get_func(this);
        }
        private void _setValue(string name, string val)
        {
            var i = _field_infos.FirstOrDefault(n => n._name == name);
            if (i != null) i._set_func(this, val);
        }
        internal CompareModel _compare(IObject o, CompareModel ret)
        {
            if (ret == null) ret = new CompareModel();
            if (o == null) return ret;
            cc_506_Complication obj = (cc_506_Complication)o;
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                Accessor.Instance(null)._LoadLookups(manager, obj);
                foreach (var i in _field_infos)
                    if (i != null && i._compare_func != null) i._compare_func(this, obj, ret, manager);
            }
            return ret;
        }
        #endregion
    
        private BvSelectList _getList(string name)
        {
        
            return null;
        }
    
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "cc_506_Complication";

        #region Parent and Clone supporting
        [XmlIgnore]
        public IObject Parent
        {
            get { return m_Parent; }
            set { m_Parent = value; /*OnPropertyChanged(_str_Parent);*/ }
        }
        private IObject m_Parent;
        internal void _setParent()
        {
        
        }
        partial void Cloned();
        partial void ClonedWithSetup();
        private bool bIsClone;
        public override object Clone()
        {
            var ret = base.Clone() as cc_506_Complication;
            ret.bIsClone = true;
            ret.Cloned();
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret._setParent();
            if (this.IsDirty && !ret.IsDirty)
                ret.SetChange();
            else if (!this.IsDirty && ret.IsDirty)
                ret.RejectChanges();
            return ret;
        }
        public IObject CloneWithSetup(DbManagerProxy manager, bool bRestricted = false)
        {
            var ret = base.Clone() as cc_506_Complication;
            ret.m_Parent = this.Parent;
            ret.m_IsMarkedToDelete = this.m_IsMarkedToDelete;
            ret.m_IsForcedToDelete = this.m_IsForcedToDelete;
            ret.m_IsNew = this.IsNew;
            ret.m_ObjectName = this.m_ObjectName;
        
            Accessor.Instance(null)._SetupLoad(manager, ret, true);
            ret.ClonedWithSetup();
            ret.DeepAcceptChanges();
            ret._setParent();
            ret._permissions = _permissions;
            return ret;
        }
        public cc_506_Complication CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as cc_506_Complication;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return DISEASE; } }
        public string KeyName { get { return "DISEASE"; } }
        public object KeyLookup { get { return DISEASE; } }
        public string ToStringProp { get { return ToString(); } }
        private bool m_IsNew;
        public bool IsNew { get { return m_IsNew; } }
        [XmlIgnore]
        [LocalizedDisplayName("HasChanges")]
        public bool HasChanges 
        { 
            get 
            { 
                return IsDirty
        
                ;
            }
        }
        public new void RejectChanges()
        {
        
            base.RejectChanges();
        
        }
        public void DeepRejectChanges()
        {
            RejectChanges();
        
        }
        public void DeepAcceptChanges()
        { 
            AcceptChanges();
        
        }
        private bool m_bForceDirty;
        public override void AcceptChanges()
        {
            m_bForceDirty = false;
            base.AcceptChanges();
        }
        [XmlIgnore]
        [LocalizedDisplayName("IsDirty")]
        public override bool IsDirty
        {
            get { return m_bForceDirty || base.IsDirty; }
        }
        public void SetChange()
        { 
            m_bForceDirty = true;
        }
        public void DeepSetChange()
        { 
            SetChange();
        
        }
        public bool MarkToDelete() { return _Delete(false); }
        public string ObjectName { get { return m_ObjectName; } }
        public string ObjectIdent { get { return ObjectName + "_" + Key.ToString() + "_"; } }
        
        public string ObjectIdent2 { get { return ObjectIdent; } }
          
        public string ObjectIdent3 { get { return ObjectIdent; } }
          
        public IObjectAccessor GetAccessor() { return _getAccessor(); }
        public IObjectPermissions GetPermissions() { return _permissions; }
        private IObjectEnvironment _environment;
        public IObjectEnvironment Environment { get { return _environment; } set { _environment = value; } }
        public bool IsValidObject { get { return _isValid; } }
        public bool ReadOnly { get { return _readOnly || !_isValid; } set { _readOnly = value; } }
        public bool IsReadOnly(string name) { return _isReadOnly(name); }
        public bool IsInvisible(string name) { return _isInvisible(name); }
        public bool IsRequired(string name) { return _isRequired(m_isRequired, name); }
        public bool IsHiddenPersonalData(string name) { return _isHiddenPersonalData(name); }
        public string GetType(string name) { return _getType(name); }
        public object GetValue(string name) { return _getValue(name); }
        public void SetValue(string name, string val) { _setValue(name, val); }
        public CompareModel Compare(IObject o) { return _compare(o, null); }
        public BvSelectList GetList(string name) { return _getList(name); }
        public event ValidationEvent Validation;
        public event ValidationEvent ValidationEnd;
        public event AfterPostEvent AfterPost;
      
        public Dictionary<string, string> GetFieldTags(string name)
        {
          return null;
        }
      #endregion

        private bool IsRIRPropChanged(string fld, cc_506_Complication c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, cc_506_Complication c)
        {
            var thisLookup = GetValue(fld + "Lookup") as IList;
            var thatLookup = c.GetValue(fld + "Lookup") as IList;
            bool bChangeLookupContent = thisLookup.Count != thatLookup.Count;
            if (!bChangeLookupContent)
            {
                for (int i = 0; i < thisLookup.Count; i++)
                {
                    if (((thisLookup[i] as IObject).Key as IComparable).CompareTo((thatLookup[i] as IObject).Key) != 0 &&
                        (thisLookup[i] as IObject).ToStringProp != null && ((thisLookup[i] as IObject).ToStringProp as IComparable).CompareTo((thatLookup[i] as IObject).ToStringProp) != 0)
                    {
                        bChangeLookupContent = true;
                        break;
                    }
                }
            }
            return bChangeLookupContent;
        }
        

      

        public cc_506_Complication()
        {
            
        }

        partial void Changed(string fieldName);
        partial void Created(DbManagerProxy manager);
        partial void Loaded(DbManagerProxy manager);
        partial void Deleted();
        partial void ParsedFormCollection(NameValueCollection form);
        partial void ParsingFormCollection(NameValueCollection form);

        

        private bool m_IsForcedToDelete;
        [LocalizedDisplayName("IsForcedToDelete")]
        public bool IsForcedToDelete { get { return m_IsForcedToDelete; } }

        private bool m_IsMarkedToDelete;
        [LocalizedDisplayName("IsMarkedToDelete")]
        public bool IsMarkedToDelete { get { return m_IsMarkedToDelete; } }

        public void _SetupMainHandler()
        {
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(cc_506_Complication_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(cc_506_Complication_PropertyChanged);
        }
        private void cc_506_Complication_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as cc_506_Complication).Changed(e.PropertyName);
            
        }
        
        public bool ForceToDelete() { return _Delete(true); }
        internal bool _Delete(bool isForceDelete)
        {
            if (!_ValidateOnDelete()) return false;
            _DeletingExtenders();
            m_IsMarkedToDelete = true;
            m_IsForcedToDelete = m_IsForcedToDelete ? m_IsForcedToDelete : isForceDelete;
            OnPropertyChanged("IsMarkedToDelete");
            _DeletedExtenders();
            Deleted();
            return true;
        }
        private bool _ValidateOnDelete(bool bReport = true)
        {
            
            return true;                
              
        }
        private void _DeletingExtenders()
        {
            cc_506_Complication obj = this;
            
        }
        private void _DeletedExtenders()
        {
            cc_506_Complication obj = this;
            
        }
        
        public bool OnValidation(ValidationModelException ex)
        {
            if (Validation != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                Validation(this, args);
                return args.Continue;
            }
            return false;
        }
        public bool OnValidationEnd(ValidationModelException ex)
        {
            if (ValidationEnd != null)
            {
                var args = new ValidationEventArgs(ex.MessageId, ex.FieldName, ex.PropertyName, ex.Pars, ex.ValidatorType, ex.Obj, ex.ValidationType);
                ValidationEnd(this, args);
                return args.Continue;
            }
            return false;
        }

        public void OnAfterPost()
        {
            if (AfterPost != null)
            {
                AfterPost(this, EventArgs.Empty);
            }
        }

        public FormSize FormSize
        {
            get { return FormSize.Undefined; }
        }
    
        private bool _isInvisible(string name)
        {
            
            return false;
                
        }

    
        private bool _isReadOnly(string name)
        {
            
            return ReadOnly;
                
        }

        private bool m_isValid = true;
        internal bool _isValid
        {
            get { return m_isValid; }
            set
            {
                m_isValid = value;
        
            }
        }

        private bool m_readOnly;
        private bool _readOnly
        {
            get { return m_readOnly; }
            set
            {
                m_readOnly = value;
        
            }
        }


        internal Dictionary<string, Func<cc_506_Complication, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<cc_506_Complication, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<cc_506_Complication, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<cc_506_Complication, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<cc_506_Complication, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<cc_506_Complication, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<cc_506_Complication, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        partial void Disposed();
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~cc_506_Complication()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!bIsDisposed) 
            {
                bIsDisposed = true;
                m_Parent = null;
                m_permissions = null;
                
                this.ClearModelObjEventInvocations();
                
                
                if (bNeedLookupRemove)
                {
                
                }
                Disposed();
            }
            GC.SuppressFinalize(this);
        }
        #endregion
    
        #region ILookupUsage Members
        public void ReloadLookupItem(DbManagerProxy manager, string lookup_object)
        {
            
        }
        #endregion
    
        public void ParseFormCollection(NameValueCollection form, bool bParseLookups = true, bool bParseRelations = true)
        {
            ParsingFormCollection(form);
            if (bParseLookups)
            {
                _field_infos.Where(i => i._type == "Lookup").ToList().ForEach(a => { if (form[ObjectIdent + a._formname] != null) a._set_func(this, form[ObjectIdent + a._formname]);} );
            }
            
            _field_infos.Where(i => i._type != "Lookup" && i._type != "Child" && i._type != "Relation" && i._type != null)
                .ToList().ForEach(a => { if (form.AllKeys.Contains(ObjectIdent + a._formname)) a._set_func(this, form[ObjectIdent + a._formname]);} );
      
            if (bParseRelations)
            {
        
            }
            ParsedFormCollection(form);
        }
    

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<cc_506_Complication>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<cc_506_Complication>
            
            , IObjectSelectDetail
            , IObjectSelectDetail<cc_506_Complication>
            , IObjectPost
            , IObjectDelete
                    
        {
            #region IObjectAccessor
            public string KeyName { get { return "DISEASE"; } }
            #endregion
        
            public delegate void on_action(cc_506_Complication obj);
            private static Accessor g_Instance = CreateInstance<Accessor>();
            private CacheScope m_CS;
            public static Accessor Instance(CacheScope cs) 
            { 
                if (cs == null)
                    return g_Instance;
                lock(cs)
                {
                    object acc = cs.Get(typeof (Accessor));
                    if (acc != null)
                    {
                        return acc as Accessor;
                    }
                    Accessor ret = CreateInstance<Accessor>();
                    ret.m_CS = cs;
                    cs.Add(typeof(Accessor), ret);
                    return ret;
                }
            }
            

            public virtual IObject SelectDetail(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNew(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }
            public virtual cc_506_Complication SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null, null
                        );
                }
            }

            
            public virtual cc_506_Complication SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                )
            {
                return _SelectByKey(manager
                    , idfsUpload506
                    , null, null
                    );
            }
            

            private cc_506_Complication _SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfsUpload506
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual cc_506_Complication _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfsUpload506
                , on_action loading, on_action loaded
                )
            {
            
                throw new NotImplementedException();
                
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, cc_506_Complication obj, bool bCloning = false)
            {
                if (obj == null) return;
                
                // loading extenters - begin
                // loading extenters - end
                if (!bCloning)
                {
                
                }
                _LoadLookups(manager, obj);
                obj._setParent();
                
                // loaded extenters - begin
                // loaded extenters - end
                
                _SetupHandlers(obj);
                _SetupChildHandlers(obj, null);
                
                _SetPermitions(obj._permissions, obj);
                _SetupRequired(obj);
                _SetupPersonalDataRestrictions(obj);
                obj._SetupMainHandler();
                obj.AcceptChanges();
            }
            
            internal void _SetPermitions(IObjectPermissions permissions, cc_506_Complication obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private cc_506_Complication _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                cc_506_Complication obj = null;
                try
                {
                    obj = cc_506_Complication.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
                    obj._SetupMainHandler();
                    obj._setParent();
                
                    // created extenters - begin
                    // created extenters - end
        
                    if (created != null)
                        created(obj);
                    obj.Created(manager);
                    _SetPermitions(obj._permissions, obj);
                    _SetupRequired(obj);
                    _SetupPersonalDataRestrictions(obj);
                    return obj;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(obj, e);
                }
            }

            
            public cc_506_Complication CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public cc_506_Complication CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public cc_506_Complication CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(cc_506_Complication obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(cc_506_Complication obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, cc_506_Complication obj)
            {
                
            }
    
            public bool DeleteObject(DbManagerProxy manager, object ident)
            {
                IObject obj = SelectDetail(manager, ident);
                if (!obj.MarkToDelete()) return false;
                return Post(manager, obj);
            }
        
            public bool Post(DbManagerProxy manager, IObject obj, bool bChildObject = false) 
            {
                throw new NotImplementedException();
            }
            
      
            protected ValidationModelException ChainsValidate(cc_506_Complication obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(cc_506_Complication obj, bool bRethrowException)
            {
                ValidationModelException ex = ChainsValidate(obj);
                if (ex != null)
                {
                    if (bRethrowException)
                        throw ex;
                    if (!obj.OnValidation(ex))
                    {
                        obj.OnValidationEnd(ex);
                        return false;
                    }
                }
                return true;
            }
        
            public bool Validate(DbManagerProxy manager, IObject obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                return Validate(manager, obj as cc_506_Complication, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, cc_506_Complication obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(cc_506_Complication obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(cc_506_Complication obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as cc_506_Complication) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as cc_506_Complication) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "cc_506_ComplicationDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spUpload506Master_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<cc_506_Complication, bool>> RequiredByField = new Dictionary<string, Func<cc_506_Complication, bool>>();
            public static Dictionary<string, Func<cc_506_Complication, bool>> RequiredByProperty = new Dictionary<string, Func<cc_506_Complication, bool>>();
            public static List<SearchPanelMetaItem> SearchPanelMeta = new List<SearchPanelMetaItem>();
            public static List<GridMetaItem> GridMeta = new List<GridMetaItem>();
            public static List<ActionMetaItem> Actions = new List<ActionMetaItem>();
            
            
    private static Dictionary<string, List<Func<bool>>> m_isHiddenPersonalData = new Dictionary<string, List<Func<bool>>>();
    internal static bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData.ContainsKey(name))
          return m_isHiddenPersonalData[name].Aggregate(false, (s,c) => s | c());
      return false;
    }

    private static void AddHiddenPersonalData(string name, Func<bool> func)
    {
      if (!m_isHiddenPersonalData.ContainsKey(name))
          m_isHiddenPersonalData.Add(name, new List<Func<bool>>());
      m_isHiddenPersonalData[name].Add(func);
    }
  
            
            static Meta()
            {
                
                Actions.Add(new ActionMetaItem(
                    "Create",
                    ActionTypes.Create,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, Accessor.Instance(null).CreateWithParams(manager, c, pars)),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCreate_Id",
                        "add",
                        /*from BvMessages*/"tooltipCreate_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipCreate_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Save",
                    ActionTypes.Save,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_Complication>().Post(manager, (cc_506_Complication)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strSave_Id",
                        "Save",
                        /*from BvMessages*/"tooltipSave_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipSave_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Ok",
                    ActionTypes.Ok,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(ObjectAccessor.PostInterface<cc_506_Complication>().Post(manager, (cc_506_Complication)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipOK_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Cancel",
                    ActionTypes.Cancel,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strCancel_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        /*from BvMessages*/"strOK_Id",
                        "",
                        /*from BvMessages*/"tooltipCancel_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      null,
                      null,
                      null,
                      false
                      ));
                    
                Actions.Add(new ActionMetaItem(
                    "Delete",
                    ActionTypes.Delete,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(((cc_506_Complication)c).MarkToDelete() && ObjectAccessor.PostInterface<cc_506_Complication>().Post(manager, (cc_506_Complication)c), c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strDelete_Id",
                        "Delete_Remove",
                        /*from BvMessages*/"tooltipDelete_Id",
                        /*from BvMessages*/"",
                        "",
                        /*from BvMessages*/"tooltipDelete_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Main,
                        ActionsAppType.All
                      ),
                      false,
                      null,
                      null,
                      (o, p, r) => r && !o.IsNew && !o.HasChanges,
                      null,
                      null,
                      false
                      ));
                    
        
                _SetupPersonalDataRestrictions();
            }
            
            
    private static void _SetupPersonalDataRestrictions()
    {
    

    }
  
        }
        #endregion
    

        #endregion
        }
    
}
	