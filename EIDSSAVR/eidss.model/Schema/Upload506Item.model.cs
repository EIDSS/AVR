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
    public abstract partial class Upload506Item : 
        EditableObject<Upload506Item>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfsUpload506), NonUpdatable, PrimaryKey]
        public abstract Int64 idfsUpload506 { get; set; }
                
        [LocalizedDisplayName(_str_idfsUpload506Item)]
        [MapField(_str_idfsUpload506Item)]
        public abstract Int64 idfsUpload506Item { get; set; }
        protected Int64 idfsUpload506Item_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506Item).OriginalValue; } }
        protected Int64 idfsUpload506Item_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfsUpload506Item).PreviousValue; } }
                
        [LocalizedDisplayName(_str_E0)]
        [MapField(_str_E0)]
        public abstract Int32? E0 { get; set; }
        protected Int32? E0_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._e0).OriginalValue; } }
        protected Int32? E0_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._e0).PreviousValue; } }
                
        [LocalizedDisplayName(_str_E1)]
        [MapField(_str_E1)]
        public abstract Int32? E1 { get; set; }
        protected Int32? E1_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._e1).OriginalValue; } }
        protected Int32? E1_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._e1).PreviousValue; } }
                
        [LocalizedDisplayName(_str_PE0)]
        [MapField(_str_PE0)]
        public abstract Int32? PE0 { get; set; }
        protected Int32? PE0_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._pE0).OriginalValue; } }
        protected Int32? PE0_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._pE0).PreviousValue; } }
                
        [LocalizedDisplayName(_str_PE1)]
        [MapField(_str_PE1)]
        public abstract Int32? PE1 { get; set; }
        protected Int32? PE1_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._pE1).OriginalValue; } }
        protected Int32? PE1_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._pE1).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DISEASE)]
        [MapField(_str_DISEASE)]
        public abstract String DISEASE { get; set; }
        protected String DISEASE_Original { get { return ((EditableValue<String>)((dynamic)this)._dISEASE).OriginalValue; } }
        protected String DISEASE_Previous { get { return ((EditableValue<String>)((dynamic)this)._dISEASE).PreviousValue; } }
                
        [LocalizedDisplayName("str506HN")]
        [MapField(_str_HN)]
        public abstract String HN { get; set; }
        protected String HN_Original { get { return ((EditableValue<String>)((dynamic)this)._hN).OriginalValue; } }
        protected String HN_Previous { get { return ((EditableValue<String>)((dynamic)this)._hN).PreviousValue; } }
                
        [LocalizedDisplayName("PatientName")]
        [MapField(_str_NAME)]
        public abstract String NAME { get; set; }
        protected String NAME_Original { get { return ((EditableValue<String>)((dynamic)this)._nAME).OriginalValue; } }
        protected String NAME_Previous { get { return ((EditableValue<String>)((dynamic)this)._nAME).PreviousValue; } }
                
        [LocalizedDisplayName(_str_SEX)]
        [MapField(_str_SEX)]
        public abstract Int32? SEX { get; set; }
        protected Int32? SEX_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._sEX).OriginalValue; } }
        protected Int32? SEX_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._sEX).PreviousValue; } }
                
        [LocalizedDisplayName(_str_YEAR)]
        [MapField(_str_YEAR)]
        public abstract Int32? YEAR { get; set; }
        protected Int32? YEAR_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._yEAR).OriginalValue; } }
        protected Int32? YEAR_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._yEAR).PreviousValue; } }
                
        [LocalizedDisplayName(_str_MONTH)]
        [MapField(_str_MONTH)]
        public abstract Int32? MONTH { get; set; }
        protected Int32? MONTH_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._mONTH).OriginalValue; } }
        protected Int32? MONTH_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._mONTH).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DAY)]
        [MapField(_str_DAY)]
        public abstract Int32? DAY { get; set; }
        protected Int32? DAY_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._dAY).OriginalValue; } }
        protected Int32? DAY_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._dAY).PreviousValue; } }
                
        [LocalizedDisplayName(_str_MARIETAL)]
        [MapField(_str_MARIETAL)]
        public abstract Int32? MARIETAL { get; set; }
        protected Int32? MARIETAL_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._mARIETAL).OriginalValue; } }
        protected Int32? MARIETAL_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._mARIETAL).PreviousValue; } }
                
        [LocalizedDisplayName(_str_RACE)]
        [MapField(_str_RACE)]
        public abstract Int32? RACE { get; set; }
        protected Int32? RACE_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._rACE).OriginalValue; } }
        protected Int32? RACE_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._rACE).PreviousValue; } }
                
        [LocalizedDisplayName(_str_RACE1)]
        [MapField(_str_RACE1)]
        public abstract Int32? RACE1 { get; set; }
        protected Int32? RACE1_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._rACE1).OriginalValue; } }
        protected Int32? RACE1_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._rACE1).PreviousValue; } }
                
        [LocalizedDisplayName(_str_OCCUPAT)]
        [MapField(_str_OCCUPAT)]
        public abstract Int32? OCCUPAT { get; set; }
        protected Int32? OCCUPAT_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._oCCUPAT).OriginalValue; } }
        protected Int32? OCCUPAT_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._oCCUPAT).PreviousValue; } }
                
        [LocalizedDisplayName(_str_ADDRESS)]
        [MapField(_str_ADDRESS)]
        public abstract String ADDRESS { get; set; }
        protected String ADDRESS_Original { get { return ((EditableValue<String>)((dynamic)this)._aDDRESS).OriginalValue; } }
        protected String ADDRESS_Previous { get { return ((EditableValue<String>)((dynamic)this)._aDDRESS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_ADDRCODE)]
        [MapField(_str_ADDRCODE)]
        public abstract String ADDRCODE { get; set; }
        protected String ADDRCODE_Original { get { return ((EditableValue<String>)((dynamic)this)._aDDRCODE).OriginalValue; } }
        protected String ADDRCODE_Previous { get { return ((EditableValue<String>)((dynamic)this)._aDDRCODE).PreviousValue; } }
                
        [LocalizedDisplayName(_str_PROVINCE)]
        [MapField(_str_PROVINCE)]
        public abstract String PROVINCE { get; set; }
        protected String PROVINCE_Original { get { return ((EditableValue<String>)((dynamic)this)._pROVINCE).OriginalValue; } }
        protected String PROVINCE_Previous { get { return ((EditableValue<String>)((dynamic)this)._pROVINCE).PreviousValue; } }
                
        [LocalizedDisplayName(_str_METROPOL)]
        [MapField(_str_METROPOL)]
        public abstract Int32? METROPOL { get; set; }
        protected Int32? METROPOL_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._mETROPOL).OriginalValue; } }
        protected Int32? METROPOL_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._mETROPOL).PreviousValue; } }
                
        [LocalizedDisplayName(_str_HOSPITAL)]
        [MapField(_str_HOSPITAL)]
        public abstract Int32? HOSPITAL { get; set; }
        protected Int32? HOSPITAL_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._hOSPITAL).OriginalValue; } }
        protected Int32? HOSPITAL_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._hOSPITAL).PreviousValue; } }
                
        [LocalizedDisplayName(_str_TYPE)]
        [MapField(_str_TYPE)]
        public abstract Int32? TYPE { get; set; }
        protected Int32? TYPE_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._tYPE).OriginalValue; } }
        protected Int32? TYPE_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._tYPE).PreviousValue; } }
                
        [LocalizedDisplayName(_str_RESULT)]
        [MapField(_str_RESULT)]
        public abstract Int32? RESULT { get; set; }
        protected Int32? RESULT_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._rESULT).OriginalValue; } }
        protected Int32? RESULT_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._rESULT).PreviousValue; } }
                
        [LocalizedDisplayName(_str_HSERV)]
        [MapField(_str_HSERV)]
        public abstract String HSERV { get; set; }
        protected String HSERV_Original { get { return ((EditableValue<String>)((dynamic)this)._hSERV).OriginalValue; } }
        protected String HSERV_Previous { get { return ((EditableValue<String>)((dynamic)this)._hSERV).PreviousValue; } }
                
        [LocalizedDisplayName(_str_SCHOOL)]
        [MapField(_str_SCHOOL)]
        public abstract String SCHOOL { get; set; }
        protected String SCHOOL_Original { get { return ((EditableValue<String>)((dynamic)this)._sCHOOL).OriginalValue; } }
        protected String SCHOOL_Previous { get { return ((EditableValue<String>)((dynamic)this)._sCHOOL).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DATESICK)]
        [MapField(_str_DATESICK)]
        public abstract DateTime? DATESICK { get; set; }
        protected DateTime? DATESICK_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._dATESICK).OriginalValue; } }
        protected DateTime? DATESICK_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._dATESICK).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DATEDEFINE)]
        [MapField(_str_DATEDEFINE)]
        public abstract DateTime? DATEDEFINE { get; set; }
        protected DateTime? DATEDEFINE_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._dATEDEFINE).OriginalValue; } }
        protected DateTime? DATEDEFINE_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._dATEDEFINE).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DATEDEATH)]
        [MapField(_str_DATEDEATH)]
        public abstract DateTime? DATEDEATH { get; set; }
        protected DateTime? DATEDEATH_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._dATEDEATH).OriginalValue; } }
        protected DateTime? DATEDEATH_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._dATEDEATH).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DATERECORD)]
        [MapField(_str_DATERECORD)]
        public abstract DateTime? DATERECORD { get; set; }
        protected DateTime? DATERECORD_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._dATERECORD).OriginalValue; } }
        protected DateTime? DATERECORD_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._dATERECORD).PreviousValue; } }
                
        [LocalizedDisplayName(_str_COMPLICA)]
        [MapField(_str_COMPLICA)]
        public abstract String COMPLICA { get; set; }
        protected String COMPLICA_Original { get { return ((EditableValue<String>)((dynamic)this)._cOMPLICA).OriginalValue; } }
        protected String COMPLICA_Previous { get { return ((EditableValue<String>)((dynamic)this)._cOMPLICA).PreviousValue; } }
                
        [LocalizedDisplayName(_str_idfCase)]
        [MapField(_str_idfCase)]
        public abstract Int64 idfCase { get; set; }
        protected Int64 idfCase_Original { get { return ((EditableValue<Int64>)((dynamic)this)._idfCase).OriginalValue; } }
        protected Int64 idfCase_Previous { get { return ((EditableValue<Int64>)((dynamic)this)._idfCase).PreviousValue; } }
                
        [LocalizedDisplayName("str506EIDSSCaseID")]
        [MapField(_str_strCaseID)]
        public abstract String strCaseID { get; set; }
        protected String strCaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).OriginalValue; } }
        protected String strCaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_Resolution)]
        [MapField(_str_Resolution)]
        public abstract Int32? Resolution { get; set; }
        protected Int32? Resolution_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._resolution).OriginalValue; } }
        protected Int32? Resolution_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._resolution).PreviousValue; } }
                
        [LocalizedDisplayName(_str_PostWithoutMaster)]
        [MapField(_str_PostWithoutMaster)]
        public abstract Int32 PostWithoutMaster { get; set; }
        protected Int32 PostWithoutMaster_Original { get { return ((EditableValue<Int32>)((dynamic)this)._postWithoutMaster).OriginalValue; } }
        protected Int32 PostWithoutMaster_Previous { get { return ((EditableValue<Int32>)((dynamic)this)._postWithoutMaster).PreviousValue; } }
                
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
            internal Func<Upload506Item, object> _get_func;
            internal Action<Upload506Item, string> _set_func;
            internal Action<Upload506Item, Upload506Item, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfsUpload506 = "idfsUpload506";
        internal const string _str_idfsUpload506Item = "idfsUpload506Item";
        internal const string _str_E0 = "E0";
        internal const string _str_E1 = "E1";
        internal const string _str_PE0 = "PE0";
        internal const string _str_PE1 = "PE1";
        internal const string _str_DISEASE = "DISEASE";
        internal const string _str_HN = "HN";
        internal const string _str_NAME = "NAME";
        internal const string _str_SEX = "SEX";
        internal const string _str_YEAR = "YEAR";
        internal const string _str_MONTH = "MONTH";
        internal const string _str_DAY = "DAY";
        internal const string _str_MARIETAL = "MARIETAL";
        internal const string _str_RACE = "RACE";
        internal const string _str_RACE1 = "RACE1";
        internal const string _str_OCCUPAT = "OCCUPAT";
        internal const string _str_ADDRESS = "ADDRESS";
        internal const string _str_ADDRCODE = "ADDRCODE";
        internal const string _str_PROVINCE = "PROVINCE";
        internal const string _str_METROPOL = "METROPOL";
        internal const string _str_HOSPITAL = "HOSPITAL";
        internal const string _str_TYPE = "TYPE";
        internal const string _str_RESULT = "RESULT";
        internal const string _str_HSERV = "HSERV";
        internal const string _str_SCHOOL = "SCHOOL";
        internal const string _str_DATESICK = "DATESICK";
        internal const string _str_DATEDEFINE = "DATEDEFINE";
        internal const string _str_DATEDEATH = "DATEDEATH";
        internal const string _str_DATERECORD = "DATERECORD";
        internal const string _str_COMPLICA = "COMPLICA";
        internal const string _str_idfCase = "idfCase";
        internal const string _str_strCaseID = "strCaseID";
        internal const string _str_Resolution = "Resolution";
        internal const string _str_PostWithoutMaster = "PostWithoutMaster";
        internal const string _str_idfPersonEnteredBy = "idfPersonEnteredBy";
        internal const string _str_idfUserID = "idfUserID";
        internal const string _str_validationErrors = "validationErrors";
        internal const string _str_master = "master";
        internal const string _str_isValid = "isValid";
        internal const string _str_iDISEASE = "iDISEASE";
        internal const string _str_iCOMPLICA = "iCOMPLICA";
        internal const string _str_idfsDiagnosis = "idfsDiagnosis";
        internal const string _str_strDiagnosis = "strDiagnosis";
        internal const string _str_datDiagnosisDate = "datDiagnosisDate";
        internal const string _str_strHospital = "strHospital";
        internal const string _str_strStatus = "strStatus";
        internal const string _str_strStatusPresent = "strStatusPresent";
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
              _name = _str_idfsUpload506Item, _formname = _str_idfsUpload506Item, _type = "Int64",
              _get_func = o => o.idfsUpload506Item,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfsUpload506Item != newval) o.idfsUpload506Item = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfsUpload506Item != c.idfsUpload506Item || o.IsRIRPropChanged(_str_idfsUpload506Item, c)) 
                  m.Add(_str_idfsUpload506Item, o.ObjectIdent + _str_idfsUpload506Item, o.ObjectIdent2 + _str_idfsUpload506Item, o.ObjectIdent3 + _str_idfsUpload506Item, "Int64", 
                    o.idfsUpload506Item == null ? "" : o.idfsUpload506Item.ToString(),                  
                  o.IsReadOnly(_str_idfsUpload506Item), o.IsInvisible(_str_idfsUpload506Item), o.IsRequired(_str_idfsUpload506Item)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_E0, _formname = _str_E0, _type = "Int32?",
              _get_func = o => o.E0,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.E0 != newval) o.E0 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.E0 != c.E0 || o.IsRIRPropChanged(_str_E0, c)) 
                  m.Add(_str_E0, o.ObjectIdent + _str_E0, o.ObjectIdent2 + _str_E0, o.ObjectIdent3 + _str_E0, "Int32?", 
                    o.E0 == null ? "" : o.E0.ToString(),                  
                  o.IsReadOnly(_str_E0), o.IsInvisible(_str_E0), o.IsRequired(_str_E0)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_E1, _formname = _str_E1, _type = "Int32?",
              _get_func = o => o.E1,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.E1 != newval) o.E1 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.E1 != c.E1 || o.IsRIRPropChanged(_str_E1, c)) 
                  m.Add(_str_E1, o.ObjectIdent + _str_E1, o.ObjectIdent2 + _str_E1, o.ObjectIdent3 + _str_E1, "Int32?", 
                    o.E1 == null ? "" : o.E1.ToString(),                  
                  o.IsReadOnly(_str_E1), o.IsInvisible(_str_E1), o.IsRequired(_str_E1)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_PE0, _formname = _str_PE0, _type = "Int32?",
              _get_func = o => o.PE0,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.PE0 != newval) o.PE0 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.PE0 != c.PE0 || o.IsRIRPropChanged(_str_PE0, c)) 
                  m.Add(_str_PE0, o.ObjectIdent + _str_PE0, o.ObjectIdent2 + _str_PE0, o.ObjectIdent3 + _str_PE0, "Int32?", 
                    o.PE0 == null ? "" : o.PE0.ToString(),                  
                  o.IsReadOnly(_str_PE0), o.IsInvisible(_str_PE0), o.IsRequired(_str_PE0)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_PE1, _formname = _str_PE1, _type = "Int32?",
              _get_func = o => o.PE1,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.PE1 != newval) o.PE1 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.PE1 != c.PE1 || o.IsRIRPropChanged(_str_PE1, c)) 
                  m.Add(_str_PE1, o.ObjectIdent + _str_PE1, o.ObjectIdent2 + _str_PE1, o.ObjectIdent3 + _str_PE1, "Int32?", 
                    o.PE1 == null ? "" : o.PE1.ToString(),                  
                  o.IsReadOnly(_str_PE1), o.IsInvisible(_str_PE1), o.IsRequired(_str_PE1)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DISEASE, _formname = _str_DISEASE, _type = "String",
              _get_func = o => o.DISEASE,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.DISEASE != newval) o.DISEASE = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.DISEASE != c.DISEASE || o.IsRIRPropChanged(_str_DISEASE, c)) 
                  m.Add(_str_DISEASE, o.ObjectIdent + _str_DISEASE, o.ObjectIdent2 + _str_DISEASE, o.ObjectIdent3 + _str_DISEASE, "String", 
                    o.DISEASE == null ? "" : o.DISEASE.ToString(),                  
                  o.IsReadOnly(_str_DISEASE), o.IsInvisible(_str_DISEASE), o.IsRequired(_str_DISEASE)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_HN, _formname = _str_HN, _type = "String",
              _get_func = o => o.HN,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.HN != newval) o.HN = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.HN != c.HN || o.IsRIRPropChanged(_str_HN, c)) 
                  m.Add(_str_HN, o.ObjectIdent + _str_HN, o.ObjectIdent2 + _str_HN, o.ObjectIdent3 + _str_HN, "String", 
                    o.HN == null ? "" : o.HN.ToString(),                  
                  o.IsReadOnly(_str_HN), o.IsInvisible(_str_HN), o.IsRequired(_str_HN)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_NAME, _formname = _str_NAME, _type = "String",
              _get_func = o => o.NAME,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.NAME != newval) o.NAME = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.NAME != c.NAME || o.IsRIRPropChanged(_str_NAME, c)) 
                  m.Add(_str_NAME, o.ObjectIdent + _str_NAME, o.ObjectIdent2 + _str_NAME, o.ObjectIdent3 + _str_NAME, "String", 
                    o.NAME == null ? "" : o.NAME.ToString(),                  
                  o.IsReadOnly(_str_NAME), o.IsInvisible(_str_NAME), o.IsRequired(_str_NAME)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_SEX, _formname = _str_SEX, _type = "Int32?",
              _get_func = o => o.SEX,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.SEX != newval) o.SEX = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.SEX != c.SEX || o.IsRIRPropChanged(_str_SEX, c)) 
                  m.Add(_str_SEX, o.ObjectIdent + _str_SEX, o.ObjectIdent2 + _str_SEX, o.ObjectIdent3 + _str_SEX, "Int32?", 
                    o.SEX == null ? "" : o.SEX.ToString(),                  
                  o.IsReadOnly(_str_SEX), o.IsInvisible(_str_SEX), o.IsRequired(_str_SEX)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_YEAR, _formname = _str_YEAR, _type = "Int32?",
              _get_func = o => o.YEAR,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.YEAR != newval) o.YEAR = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.YEAR != c.YEAR || o.IsRIRPropChanged(_str_YEAR, c)) 
                  m.Add(_str_YEAR, o.ObjectIdent + _str_YEAR, o.ObjectIdent2 + _str_YEAR, o.ObjectIdent3 + _str_YEAR, "Int32?", 
                    o.YEAR == null ? "" : o.YEAR.ToString(),                  
                  o.IsReadOnly(_str_YEAR), o.IsInvisible(_str_YEAR), o.IsRequired(_str_YEAR)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_MONTH, _formname = _str_MONTH, _type = "Int32?",
              _get_func = o => o.MONTH,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.MONTH != newval) o.MONTH = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.MONTH != c.MONTH || o.IsRIRPropChanged(_str_MONTH, c)) 
                  m.Add(_str_MONTH, o.ObjectIdent + _str_MONTH, o.ObjectIdent2 + _str_MONTH, o.ObjectIdent3 + _str_MONTH, "Int32?", 
                    o.MONTH == null ? "" : o.MONTH.ToString(),                  
                  o.IsReadOnly(_str_MONTH), o.IsInvisible(_str_MONTH), o.IsRequired(_str_MONTH)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DAY, _formname = _str_DAY, _type = "Int32?",
              _get_func = o => o.DAY,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.DAY != newval) o.DAY = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.DAY != c.DAY || o.IsRIRPropChanged(_str_DAY, c)) 
                  m.Add(_str_DAY, o.ObjectIdent + _str_DAY, o.ObjectIdent2 + _str_DAY, o.ObjectIdent3 + _str_DAY, "Int32?", 
                    o.DAY == null ? "" : o.DAY.ToString(),                  
                  o.IsReadOnly(_str_DAY), o.IsInvisible(_str_DAY), o.IsRequired(_str_DAY)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_MARIETAL, _formname = _str_MARIETAL, _type = "Int32?",
              _get_func = o => o.MARIETAL,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.MARIETAL != newval) o.MARIETAL = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.MARIETAL != c.MARIETAL || o.IsRIRPropChanged(_str_MARIETAL, c)) 
                  m.Add(_str_MARIETAL, o.ObjectIdent + _str_MARIETAL, o.ObjectIdent2 + _str_MARIETAL, o.ObjectIdent3 + _str_MARIETAL, "Int32?", 
                    o.MARIETAL == null ? "" : o.MARIETAL.ToString(),                  
                  o.IsReadOnly(_str_MARIETAL), o.IsInvisible(_str_MARIETAL), o.IsRequired(_str_MARIETAL)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_RACE, _formname = _str_RACE, _type = "Int32?",
              _get_func = o => o.RACE,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.RACE != newval) o.RACE = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.RACE != c.RACE || o.IsRIRPropChanged(_str_RACE, c)) 
                  m.Add(_str_RACE, o.ObjectIdent + _str_RACE, o.ObjectIdent2 + _str_RACE, o.ObjectIdent3 + _str_RACE, "Int32?", 
                    o.RACE == null ? "" : o.RACE.ToString(),                  
                  o.IsReadOnly(_str_RACE), o.IsInvisible(_str_RACE), o.IsRequired(_str_RACE)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_RACE1, _formname = _str_RACE1, _type = "Int32?",
              _get_func = o => o.RACE1,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.RACE1 != newval) o.RACE1 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.RACE1 != c.RACE1 || o.IsRIRPropChanged(_str_RACE1, c)) 
                  m.Add(_str_RACE1, o.ObjectIdent + _str_RACE1, o.ObjectIdent2 + _str_RACE1, o.ObjectIdent3 + _str_RACE1, "Int32?", 
                    o.RACE1 == null ? "" : o.RACE1.ToString(),                  
                  o.IsReadOnly(_str_RACE1), o.IsInvisible(_str_RACE1), o.IsRequired(_str_RACE1)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_OCCUPAT, _formname = _str_OCCUPAT, _type = "Int32?",
              _get_func = o => o.OCCUPAT,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.OCCUPAT != newval) o.OCCUPAT = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.OCCUPAT != c.OCCUPAT || o.IsRIRPropChanged(_str_OCCUPAT, c)) 
                  m.Add(_str_OCCUPAT, o.ObjectIdent + _str_OCCUPAT, o.ObjectIdent2 + _str_OCCUPAT, o.ObjectIdent3 + _str_OCCUPAT, "Int32?", 
                    o.OCCUPAT == null ? "" : o.OCCUPAT.ToString(),                  
                  o.IsReadOnly(_str_OCCUPAT), o.IsInvisible(_str_OCCUPAT), o.IsRequired(_str_OCCUPAT)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_ADDRESS, _formname = _str_ADDRESS, _type = "String",
              _get_func = o => o.ADDRESS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.ADDRESS != newval) o.ADDRESS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.ADDRESS != c.ADDRESS || o.IsRIRPropChanged(_str_ADDRESS, c)) 
                  m.Add(_str_ADDRESS, o.ObjectIdent + _str_ADDRESS, o.ObjectIdent2 + _str_ADDRESS, o.ObjectIdent3 + _str_ADDRESS, "String", 
                    o.ADDRESS == null ? "" : o.ADDRESS.ToString(),                  
                  o.IsReadOnly(_str_ADDRESS), o.IsInvisible(_str_ADDRESS), o.IsRequired(_str_ADDRESS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_ADDRCODE, _formname = _str_ADDRCODE, _type = "String",
              _get_func = o => o.ADDRCODE,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.ADDRCODE != newval) o.ADDRCODE = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.ADDRCODE != c.ADDRCODE || o.IsRIRPropChanged(_str_ADDRCODE, c)) 
                  m.Add(_str_ADDRCODE, o.ObjectIdent + _str_ADDRCODE, o.ObjectIdent2 + _str_ADDRCODE, o.ObjectIdent3 + _str_ADDRCODE, "String", 
                    o.ADDRCODE == null ? "" : o.ADDRCODE.ToString(),                  
                  o.IsReadOnly(_str_ADDRCODE), o.IsInvisible(_str_ADDRCODE), o.IsRequired(_str_ADDRCODE)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_PROVINCE, _formname = _str_PROVINCE, _type = "String",
              _get_func = o => o.PROVINCE,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.PROVINCE != newval) o.PROVINCE = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.PROVINCE != c.PROVINCE || o.IsRIRPropChanged(_str_PROVINCE, c)) 
                  m.Add(_str_PROVINCE, o.ObjectIdent + _str_PROVINCE, o.ObjectIdent2 + _str_PROVINCE, o.ObjectIdent3 + _str_PROVINCE, "String", 
                    o.PROVINCE == null ? "" : o.PROVINCE.ToString(),                  
                  o.IsReadOnly(_str_PROVINCE), o.IsInvisible(_str_PROVINCE), o.IsRequired(_str_PROVINCE)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_METROPOL, _formname = _str_METROPOL, _type = "Int32?",
              _get_func = o => o.METROPOL,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.METROPOL != newval) o.METROPOL = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.METROPOL != c.METROPOL || o.IsRIRPropChanged(_str_METROPOL, c)) 
                  m.Add(_str_METROPOL, o.ObjectIdent + _str_METROPOL, o.ObjectIdent2 + _str_METROPOL, o.ObjectIdent3 + _str_METROPOL, "Int32?", 
                    o.METROPOL == null ? "" : o.METROPOL.ToString(),                  
                  o.IsReadOnly(_str_METROPOL), o.IsInvisible(_str_METROPOL), o.IsRequired(_str_METROPOL)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_HOSPITAL, _formname = _str_HOSPITAL, _type = "Int32?",
              _get_func = o => o.HOSPITAL,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.HOSPITAL != newval) o.HOSPITAL = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.HOSPITAL != c.HOSPITAL || o.IsRIRPropChanged(_str_HOSPITAL, c)) 
                  m.Add(_str_HOSPITAL, o.ObjectIdent + _str_HOSPITAL, o.ObjectIdent2 + _str_HOSPITAL, o.ObjectIdent3 + _str_HOSPITAL, "Int32?", 
                    o.HOSPITAL == null ? "" : o.HOSPITAL.ToString(),                  
                  o.IsReadOnly(_str_HOSPITAL), o.IsInvisible(_str_HOSPITAL), o.IsRequired(_str_HOSPITAL)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_TYPE, _formname = _str_TYPE, _type = "Int32?",
              _get_func = o => o.TYPE,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.TYPE != newval) o.TYPE = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.TYPE != c.TYPE || o.IsRIRPropChanged(_str_TYPE, c)) 
                  m.Add(_str_TYPE, o.ObjectIdent + _str_TYPE, o.ObjectIdent2 + _str_TYPE, o.ObjectIdent3 + _str_TYPE, "Int32?", 
                    o.TYPE == null ? "" : o.TYPE.ToString(),                  
                  o.IsReadOnly(_str_TYPE), o.IsInvisible(_str_TYPE), o.IsRequired(_str_TYPE)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_RESULT, _formname = _str_RESULT, _type = "Int32?",
              _get_func = o => o.RESULT,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.RESULT != newval) o.RESULT = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.RESULT != c.RESULT || o.IsRIRPropChanged(_str_RESULT, c)) 
                  m.Add(_str_RESULT, o.ObjectIdent + _str_RESULT, o.ObjectIdent2 + _str_RESULT, o.ObjectIdent3 + _str_RESULT, "Int32?", 
                    o.RESULT == null ? "" : o.RESULT.ToString(),                  
                  o.IsReadOnly(_str_RESULT), o.IsInvisible(_str_RESULT), o.IsRequired(_str_RESULT)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_HSERV, _formname = _str_HSERV, _type = "String",
              _get_func = o => o.HSERV,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.HSERV != newval) o.HSERV = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.HSERV != c.HSERV || o.IsRIRPropChanged(_str_HSERV, c)) 
                  m.Add(_str_HSERV, o.ObjectIdent + _str_HSERV, o.ObjectIdent2 + _str_HSERV, o.ObjectIdent3 + _str_HSERV, "String", 
                    o.HSERV == null ? "" : o.HSERV.ToString(),                  
                  o.IsReadOnly(_str_HSERV), o.IsInvisible(_str_HSERV), o.IsRequired(_str_HSERV)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_SCHOOL, _formname = _str_SCHOOL, _type = "String",
              _get_func = o => o.SCHOOL,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.SCHOOL != newval) o.SCHOOL = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.SCHOOL != c.SCHOOL || o.IsRIRPropChanged(_str_SCHOOL, c)) 
                  m.Add(_str_SCHOOL, o.ObjectIdent + _str_SCHOOL, o.ObjectIdent2 + _str_SCHOOL, o.ObjectIdent3 + _str_SCHOOL, "String", 
                    o.SCHOOL == null ? "" : o.SCHOOL.ToString(),                  
                  o.IsReadOnly(_str_SCHOOL), o.IsInvisible(_str_SCHOOL), o.IsRequired(_str_SCHOOL)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DATESICK, _formname = _str_DATESICK, _type = "DateTime?",
              _get_func = o => o.DATESICK,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.DATESICK != newval) o.DATESICK = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.DATESICK != c.DATESICK || o.IsRIRPropChanged(_str_DATESICK, c)) 
                  m.Add(_str_DATESICK, o.ObjectIdent + _str_DATESICK, o.ObjectIdent2 + _str_DATESICK, o.ObjectIdent3 + _str_DATESICK, "DateTime?", 
                    o.DATESICK == null ? "" : o.DATESICK.ToString(),                  
                  o.IsReadOnly(_str_DATESICK), o.IsInvisible(_str_DATESICK), o.IsRequired(_str_DATESICK)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DATEDEFINE, _formname = _str_DATEDEFINE, _type = "DateTime?",
              _get_func = o => o.DATEDEFINE,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.DATEDEFINE != newval) o.DATEDEFINE = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.DATEDEFINE != c.DATEDEFINE || o.IsRIRPropChanged(_str_DATEDEFINE, c)) 
                  m.Add(_str_DATEDEFINE, o.ObjectIdent + _str_DATEDEFINE, o.ObjectIdent2 + _str_DATEDEFINE, o.ObjectIdent3 + _str_DATEDEFINE, "DateTime?", 
                    o.DATEDEFINE == null ? "" : o.DATEDEFINE.ToString(),                  
                  o.IsReadOnly(_str_DATEDEFINE), o.IsInvisible(_str_DATEDEFINE), o.IsRequired(_str_DATEDEFINE)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DATEDEATH, _formname = _str_DATEDEATH, _type = "DateTime?",
              _get_func = o => o.DATEDEATH,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.DATEDEATH != newval) o.DATEDEATH = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.DATEDEATH != c.DATEDEATH || o.IsRIRPropChanged(_str_DATEDEATH, c)) 
                  m.Add(_str_DATEDEATH, o.ObjectIdent + _str_DATEDEATH, o.ObjectIdent2 + _str_DATEDEATH, o.ObjectIdent3 + _str_DATEDEATH, "DateTime?", 
                    o.DATEDEATH == null ? "" : o.DATEDEATH.ToString(),                  
                  o.IsReadOnly(_str_DATEDEATH), o.IsInvisible(_str_DATEDEATH), o.IsRequired(_str_DATEDEATH)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_DATERECORD, _formname = _str_DATERECORD, _type = "DateTime?",
              _get_func = o => o.DATERECORD,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.DATERECORD != newval) o.DATERECORD = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.DATERECORD != c.DATERECORD || o.IsRIRPropChanged(_str_DATERECORD, c)) 
                  m.Add(_str_DATERECORD, o.ObjectIdent + _str_DATERECORD, o.ObjectIdent2 + _str_DATERECORD, o.ObjectIdent3 + _str_DATERECORD, "DateTime?", 
                    o.DATERECORD == null ? "" : o.DATERECORD.ToString(),                  
                  o.IsReadOnly(_str_DATERECORD), o.IsInvisible(_str_DATERECORD), o.IsRequired(_str_DATERECORD)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_COMPLICA, _formname = _str_COMPLICA, _type = "String",
              _get_func = o => o.COMPLICA,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.COMPLICA != newval) o.COMPLICA = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.COMPLICA != c.COMPLICA || o.IsRIRPropChanged(_str_COMPLICA, c)) 
                  m.Add(_str_COMPLICA, o.ObjectIdent + _str_COMPLICA, o.ObjectIdent2 + _str_COMPLICA, o.ObjectIdent3 + _str_COMPLICA, "String", 
                    o.COMPLICA == null ? "" : o.COMPLICA.ToString(),                  
                  o.IsReadOnly(_str_COMPLICA), o.IsInvisible(_str_COMPLICA), o.IsRequired(_str_COMPLICA)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_idfCase, _formname = _str_idfCase, _type = "Int64",
              _get_func = o => o.idfCase,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt64(val); if (o.idfCase != newval) o.idfCase = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.idfCase != c.idfCase || o.IsRIRPropChanged(_str_idfCase, c)) 
                  m.Add(_str_idfCase, o.ObjectIdent + _str_idfCase, o.ObjectIdent2 + _str_idfCase, o.ObjectIdent3 + _str_idfCase, "Int64", 
                    o.idfCase == null ? "" : o.idfCase.ToString(),                  
                  o.IsReadOnly(_str_idfCase), o.IsInvisible(_str_idfCase), o.IsRequired(_str_idfCase)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strCaseID, _formname = _str_strCaseID, _type = "String",
              _get_func = o => o.strCaseID,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strCaseID != newval) o.strCaseID = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strCaseID != c.strCaseID || o.IsRIRPropChanged(_str_strCaseID, c)) 
                  m.Add(_str_strCaseID, o.ObjectIdent + _str_strCaseID, o.ObjectIdent2 + _str_strCaseID, o.ObjectIdent3 + _str_strCaseID, "String", 
                    o.strCaseID == null ? "" : o.strCaseID.ToString(),                  
                  o.IsReadOnly(_str_strCaseID), o.IsInvisible(_str_strCaseID), o.IsRequired(_str_strCaseID)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_Resolution, _formname = _str_Resolution, _type = "Int32?",
              _get_func = o => o.Resolution,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.Resolution != newval) o.Resolution = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.Resolution != c.Resolution || o.IsRIRPropChanged(_str_Resolution, c)) 
                  m.Add(_str_Resolution, o.ObjectIdent + _str_Resolution, o.ObjectIdent2 + _str_Resolution, o.ObjectIdent3 + _str_Resolution, "Int32?", 
                    o.Resolution == null ? "" : o.Resolution.ToString(),                  
                  o.IsReadOnly(_str_Resolution), o.IsInvisible(_str_Resolution), o.IsRequired(_str_Resolution)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_PostWithoutMaster, _formname = _str_PostWithoutMaster, _type = "Int32",
              _get_func = o => o.PostWithoutMaster,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32(val); if (o.PostWithoutMaster != newval) o.PostWithoutMaster = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.PostWithoutMaster != c.PostWithoutMaster || o.IsRIRPropChanged(_str_PostWithoutMaster, c)) 
                  m.Add(_str_PostWithoutMaster, o.ObjectIdent + _str_PostWithoutMaster, o.ObjectIdent2 + _str_PostWithoutMaster, o.ObjectIdent3 + _str_PostWithoutMaster, "Int32", 
                    o.PostWithoutMaster == null ? "" : o.PostWithoutMaster.ToString(),                  
                  o.IsReadOnly(_str_PostWithoutMaster), o.IsInvisible(_str_PostWithoutMaster), o.IsRequired(_str_PostWithoutMaster)); 
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
              _name = _str_validationErrors, _formname = _str_validationErrors, _type = "List<Tuple<string,string>>",
              _get_func = o => o.validationErrors,
              _set_func = (o, val) => { var newval = o.validationErrors; if (o.validationErrors != newval) o.validationErrors = newval; },
              _compare_func = (o, c, m, g) => {
               }
              }, 
        
            new field_info {
              _name = _str_master, _formname = _str_master, _type = "Upload506Master",
              _get_func = o => o.master,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                }
              }, 
        
            new field_info {
              _name = _str_isValid, _formname = _str_isValid, _type = "bool",
              _get_func = o => o.isValid,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.isValid != c.isValid || o.IsRIRPropChanged(_str_isValid, c)) {
                  m.Add(_str_isValid, o.ObjectIdent + _str_isValid, o.ObjectIdent2 + _str_isValid, o.ObjectIdent3 + _str_isValid, "bool", o.isValid == null ? "" : o.isValid.ToString(), o.IsReadOnly(_str_isValid), o.IsInvisible(_str_isValid), o.IsRequired(_str_isValid));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_iDISEASE, _formname = _str_iDISEASE, _type = "int",
              _get_func = o => o.iDISEASE,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.iDISEASE != c.iDISEASE || o.IsRIRPropChanged(_str_iDISEASE, c)) {
                  m.Add(_str_iDISEASE, o.ObjectIdent + _str_iDISEASE, o.ObjectIdent2 + _str_iDISEASE, o.ObjectIdent3 + _str_iDISEASE, "int", o.iDISEASE == null ? "" : o.iDISEASE.ToString(), o.IsReadOnly(_str_iDISEASE), o.IsInvisible(_str_iDISEASE), o.IsRequired(_str_iDISEASE));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_iCOMPLICA, _formname = _str_iCOMPLICA, _type = "int?",
              _get_func = o => o.iCOMPLICA,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.iCOMPLICA != c.iCOMPLICA || o.IsRIRPropChanged(_str_iCOMPLICA, c)) {
                  m.Add(_str_iCOMPLICA, o.ObjectIdent + _str_iCOMPLICA, o.ObjectIdent2 + _str_iCOMPLICA, o.ObjectIdent3 + _str_iCOMPLICA, "int?", o.iCOMPLICA == null ? "" : o.iCOMPLICA.ToString(), o.IsReadOnly(_str_iCOMPLICA), o.IsInvisible(_str_iCOMPLICA), o.IsRequired(_str_iCOMPLICA));
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
              _name = _str_strDiagnosis, _formname = _str_strDiagnosis, _type = "string",
              _get_func = o => o.strDiagnosis,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strDiagnosis != c.strDiagnosis || o.IsRIRPropChanged(_str_strDiagnosis, c)) {
                  m.Add(_str_strDiagnosis, o.ObjectIdent + _str_strDiagnosis, o.ObjectIdent2 + _str_strDiagnosis, o.ObjectIdent3 + _str_strDiagnosis, "string", o.strDiagnosis == null ? "" : o.strDiagnosis.ToString(), o.IsReadOnly(_str_strDiagnosis), o.IsInvisible(_str_strDiagnosis), o.IsRequired(_str_strDiagnosis));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_datDiagnosisDate, _formname = _str_datDiagnosisDate, _type = "DateTime?",
              _get_func = o => o.datDiagnosisDate,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.datDiagnosisDate != c.datDiagnosisDate || o.IsRIRPropChanged(_str_datDiagnosisDate, c)) {
                  m.Add(_str_datDiagnosisDate, o.ObjectIdent + _str_datDiagnosisDate, o.ObjectIdent2 + _str_datDiagnosisDate, o.ObjectIdent3 + _str_datDiagnosisDate, "DateTime?", o.datDiagnosisDate == null ? "" : o.datDiagnosisDate.ToString(), o.IsReadOnly(_str_datDiagnosisDate), o.IsInvisible(_str_datDiagnosisDate), o.IsRequired(_str_datDiagnosisDate));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strHospital, _formname = _str_strHospital, _type = "string",
              _get_func = o => o.strHospital,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strHospital != c.strHospital || o.IsRIRPropChanged(_str_strHospital, c)) {
                  m.Add(_str_strHospital, o.ObjectIdent + _str_strHospital, o.ObjectIdent2 + _str_strHospital, o.ObjectIdent3 + _str_strHospital, "string", o.strHospital == null ? "" : o.strHospital.ToString(), o.IsReadOnly(_str_strHospital), o.IsInvisible(_str_strHospital), o.IsRequired(_str_strHospital));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strStatus, _formname = _str_strStatus, _type = "string",
              _get_func = o => o.strStatus,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strStatus != c.strStatus || o.IsRIRPropChanged(_str_strStatus, c)) {
                  m.Add(_str_strStatus, o.ObjectIdent + _str_strStatus, o.ObjectIdent2 + _str_strStatus, o.ObjectIdent3 + _str_strStatus, "string", o.strStatus == null ? "" : o.strStatus.ToString(), o.IsReadOnly(_str_strStatus), o.IsInvisible(_str_strStatus), o.IsRequired(_str_strStatus));
                  }
                
                }
              }, 
        
            new field_info {
              _name = _str_strStatusPresent, _formname = _str_strStatusPresent, _type = "string",
              _get_func = o => o.strStatusPresent,
              _set_func = (o, val) => {  },
              _compare_func = (o, c, m, g) => { 
              
                if (o.strStatusPresent != c.strStatusPresent || o.IsRIRPropChanged(_str_strStatusPresent, c)) {
                  m.Add(_str_strStatusPresent, o.ObjectIdent + _str_strStatusPresent, o.ObjectIdent2 + _str_strStatusPresent, o.ObjectIdent3 + _str_strStatusPresent, "string", o.strStatusPresent == null ? "" : o.strStatusPresent.ToString(), o.IsReadOnly(_str_strStatusPresent), o.IsInvisible(_str_strStatusPresent), o.IsRequired(_str_strStatusPresent));
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
            Upload506Item obj = (Upload506Item)o;
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
    
          [XmlIgnore]
          [LocalizedDisplayName(_str_master)]
        public Upload506Master master
        {
            get { return new Func<Upload506Item, Upload506Master>(c => c.Parent as Upload506Master)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_isValid)]
        public bool isValid
        {
            get { return new Func<Upload506Item, bool>(c => c.validationErrors == null || c.validationErrors.Count == 0)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_iDISEASE)]
        public int iDISEASE
        {
            get { return new Func<Upload506Item, int>(c => Int32.Parse(c.DISEASE))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_iCOMPLICA)]
        public int? iCOMPLICA
        {
            get { return new Func<Upload506Item, int?>(c => String.IsNullOrEmpty(c.COMPLICA) ? new Int32?() : Int32.Parse(c.COMPLICA))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_idfsDiagnosis)]
        public long? idfsDiagnosis
        {
            get { return new Func<Upload506Item, long?>(c => c.master == null ? new long?() : c.master.DiagnosisRefs.FirstOrDefault(i => i.DISEASE == c.iDISEASE, i => i.idfsTentativeDiagnosis))(this); }
            
            set { idfsDiagnosis = value; OnPropertyChanged(_str_idfsDiagnosis); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("DiagnosisName")]
        public string strDiagnosis
        {
            get { return new Func<Upload506Item, string>(c => c.master == null ? "" : c.master.DiagnosisLookup.FirstOrDefault(i => i.idfsDiagnosis == c.idfsDiagnosis, i => i.name))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_datDiagnosisDate)]
        public DateTime? datDiagnosisDate
        {
            get { return new Func<Upload506Item, DateTime?>(c => c.DATEDEFINE)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("strHospital506Item")]
        public string strHospital
        {
            get { return new Func<Upload506Item, string>(c => c.PROVINCE + c.HSERV)(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName("strStatus506Item")]
        public string strStatus
        {
            get { return new Func<Upload506Item, string>(c => eidss.model.Resources.EidssMessages.Get(c.Resolution.HasValue ? (c.Resolution.Value == (int)Upload506Resolution.Updated ? "rsUpdated" : (c.Resolution.Value == (int)Upload506Resolution.Created ? "rsCreated" : "rsDismissed")) : "rsUnspecified"))(this); }
            
        }
        
          [XmlIgnore]
          [LocalizedDisplayName(_str_strStatusPresent)]
        public string strStatusPresent
        {
            get { return new Func<Upload506Item, string>(c => eidss.model.Resources.EidssMessages.Get(c.Resolution.HasValue ? (c.Resolution.Value == (int)Upload506Resolution.Updated ? "rsUpdate" : (c.Resolution.Value == (int)Upload506Resolution.Created ? "rsCreate" : "rsDismiss")) : "rsUnspecified"))(this); }
            
        }
        
          [LocalizedDisplayName(_str_validationErrors)]
        public List<Tuple<string,string>> validationErrors
        {
            get { return m_validationErrors; }
            set { if (m_validationErrors != value) { m_validationErrors = value; OnPropertyChanged(_str_validationErrors); } }
        }
        private List<Tuple<string,string>> m_validationErrors;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "Upload506Item";

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
            var ret = base.Clone() as Upload506Item;
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
            var ret = base.Clone() as Upload506Item;
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
        public Upload506Item CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as Upload506Item;
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

        private bool IsRIRPropChanged(string fld, Upload506Item c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, Upload506Item c)
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
        

      

        public Upload506Item()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Upload506Item_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(Upload506Item_PropertyChanged);
        }
        private void Upload506Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as Upload506Item).Changed(e.PropertyName);
            
            if (e.PropertyName == _str_Parent)
                OnPropertyChanged(_str_master);
                  
            if (e.PropertyName == _str_validationErrors)
                OnPropertyChanged(_str_isValid);
                  
            if (e.PropertyName == _str_DISEASE)
                OnPropertyChanged(_str_iDISEASE);
                  
            if (e.PropertyName == _str_COMPLICA)
                OnPropertyChanged(_str_iCOMPLICA);
                  
            if (e.PropertyName == _str_DISEASE)
                OnPropertyChanged(_str_idfsDiagnosis);
                  
            if (e.PropertyName == _str_idfsDiagnosis)
                OnPropertyChanged(_str_strDiagnosis);
                  
            if (e.PropertyName == _str_DATEDEFINE)
                OnPropertyChanged(_str_datDiagnosisDate);
                  
            if (e.PropertyName == _str_PROVINCE)
                OnPropertyChanged(_str_strHospital);
                  
            if (e.PropertyName == _str_HSERV)
                OnPropertyChanged(_str_strHospital);
                  
            if (e.PropertyName == _str_Resolution)
                OnPropertyChanged(_str_strStatus);
                  
            if (e.PropertyName == _str_Resolution)
                OnPropertyChanged(_str_strStatusPresent);
                  
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
            Upload506Item obj = this;
            
        }
        private void _DeletedExtenders()
        {
            Upload506Item obj = this;
            
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

    
        private static string[] readonly_names1 = "strStatus".Split(new char[] { ',' });
        
        private bool _isReadOnly(string name)
        {
            
            if (readonly_names1.Where(c => c == name).Count() > 0)
                return ReadOnly || new Func<Upload506Item, bool>(c => true)(this);
            
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


        internal Dictionary<string, Func<Upload506Item, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<Upload506Item, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Upload506Item, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Upload506Item, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<Upload506Item, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<Upload506Item, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<Upload506Item, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        partial void Disposed();
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~Upload506Item()
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
    
        #region Class for web grid
        public class Upload506ItemGridModel : IGridModelItem
        {
            public string ErrorMessage { get; set; }
            public long ItemKey { get; set; }
        
            public Int64 idfCase { get; set; }
        
            public String HN { get; set; }
        
            public String strCaseID { get; set; }
        
            public string strDiagnosis { get; set; }
        
            public DateTimeWrap datDiagnosisDate { get; set; }
        
            public String NAME { get; set; }
        
            public string strHospital { get; set; }
        
            public string strStatus { get; set; }
        
        }
        public partial class Upload506ItemGridModelList : List<Upload506ItemGridModel>, IGridModelList, IGridModelListLoad
        {
            public long ListKey { get; protected set; }
            public List<string> Columns { get; protected set; }
            public List<string> Hiddens { get; protected set; }
            public Dictionary<string, string> Labels { get; protected set; }
            public Dictionary<string, ActionMetaItem> Actions { get; protected set; }
            public List<string> Keys { get; protected set; }
            public bool IsHiddenPersonalData(string name) { return Meta._isHiddenPersonalData(name); }
            public IObjectMeta ObjectMeta { get { return Accessor.Instance(null); } }
            public Upload506ItemGridModelList()
            {
            }
            public void Load(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<Upload506Item>, errMes);
            }
            public Upload506ItemGridModelList(long key, IEnumerable items, string errMes)
            {
                LoadGridModelList(key, items as IEnumerable<Upload506Item>, errMes);
            }
            public Upload506ItemGridModelList(long key, IEnumerable<Upload506Item> items)
            {
                LoadGridModelList(key, items, null);
            }
            public Upload506ItemGridModelList(long key)
            {
                LoadGridModelList(key, new List<Upload506Item>(), null);
            }
            partial void filter(List<Upload506Item> items);
            private void LoadGridModelList(long key, IEnumerable<Upload506Item> items, string errMes)
            {
                ListKey = key;
                
                Columns = new List<string> {_str_HN,_str_strCaseID,_str_strDiagnosis,_str_datDiagnosisDate,_str_NAME,_str_strHospital,_str_strStatus};
                    
                Hiddens = new List<string> {_str_idfCase};
                Keys = new List<string> {_str_idfCase};
                Labels = new Dictionary<string, string> {{_str_HN, "str506HN"},{_str_strCaseID, "str506EIDSSCaseID"},{_str_strDiagnosis, "DiagnosisName"},{_str_datDiagnosisDate, _str_datDiagnosisDate},{_str_NAME, "PatientName"},{_str_strHospital, "strHospital506Item"},{_str_strStatus, "strStatus506Item"}};
                Actions = new Dictionary<string, ActionMetaItem> {{_str_strCaseID, Accessor.Instance(null).Actions.SingleOrDefault(c => c.Name == "ActionEditHumanCase")}};
                Upload506Item.Meta.Actions.ForEach(a => Actions.Add("@" + a.Name, a));
                var list = new List<Upload506Item>(items);
                filter(list);
                AddRange(list.Where(c => !c.IsMarkedToDelete).Select(c => new Upload506ItemGridModel()
                {
                    ItemKey=c.idfCase,HN=c.HN,strCaseID=c.strCaseID,strDiagnosis=c.strDiagnosis,datDiagnosisDate=c.datDiagnosisDate,NAME=c.NAME,strHospital=c.strHospital,strStatus=c.strStatus
                }));
                if (Count > 0)
                {
                    this.Last().ErrorMessage = errMes;
                }
            }
        }
        #endregion
        

        #region Accessor
        public abstract partial class Accessor
        : DataAccessor<Upload506Item>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<Upload506Item>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfsUpload506"; } }
            #endregion
        
            public delegate void on_action(Upload506Item obj);
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
            
            public virtual List<IObject> SelectDetailList(DbManagerProxy manager, object ident, int? HACode = null)
            {
                return _SelectList(manager
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<Upload506Item> SelectList(DbManagerProxy manager
                )
            {
                return _SelectList(manager
                    , delegate(Upload506Item obj)
                        {
                        }
                    , delegate(Upload506Item obj)
                        {
                        }
                    );
            }

            

            public List<Upload506Item> _SelectList(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<Upload506Item> _SelectListInternal(DbManagerProxy manager
                , on_action loading, on_action loaded
                )
            {
                Upload506Item _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<Upload506Item> objs = new List<Upload506Item>();
                    sets[0] = new MapResultSet(typeof(Upload506Item), objs);
                    
                    manager
                        .SetSpCommand("spUpload506Item_SelectDetail"
                            )
                        .ExecuteResultSet(sets);
                    foreach(var obj in objs) 
                    {
                        _obj = obj;
                        obj.m_CS = m_CS;
                        
                        if (loading != null)
                            loading(obj);
                        _SetupLoad(manager, obj);
                        
                        if (loaded != null)
                            loaded(obj);
                    }
                    
                    return objs;
                }
                catch(DataException e)
                {
                    throw DbModelException.Create(_obj, e);
                }
            }
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, Upload506Item obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, Upload506Item obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private Upload506Item _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                Upload506Item obj = null;
                try
                {
                    obj = Upload506Item.CreateInstance();
                    obj.m_CS = m_CS;
                    obj.m_IsNew = true;
                    obj.Parent = Parent;
                    
                    if (creating != null)
                        creating(obj);
                
                    // creating extenters - begin
                obj.validationErrors = new List<Tuple<string,string>>();
                obj.idfsUpload506 = new Func<Upload506Item, long>(c => c.master == null ? 0 : c.master.idfsUpload506)(obj);
                obj.idfsUpload506Item = (new PositiveAutoIncrementExtender<Upload506Item>()).GetScalar(manager, obj, isFake);
                    // creating extenters - end
                
                    _LoadLookups(manager, obj);
                    _SetupHandlers(obj);
                    _SetupChildHandlers(obj, null);
                    
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

            
            public Upload506Item CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public Upload506Item CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public Upload506Item CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            public ActResult ActionEditHumanCase(DbManagerProxy manager, Upload506Item obj, List<object> pars)
            {
                
                return ActionEditHumanCase(manager, obj
                    );
            }
            public ActResult ActionEditHumanCase(DbManagerProxy manager, Upload506Item obj
                )
            {
                
                return true;
                
            }
            
      
            private void _SetupChildHandlers(Upload506Item obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(Upload506Item obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, Upload506Item obj)
            {
                
            }
    
            [SprocName("spUpload506Item_Post")]
            protected abstract void _post(DbManagerProxy manager, 
                [Direction.InputOutput("idfCase")] Upload506Item obj);
            protected void _postPredicate(DbManagerProxy manager, 
                [Direction.InputOutput("idfCase")] Upload506Item obj)
            {
                
                if (new Func<Upload506Item, bool>(c => c.isValid)(obj))
                {
                
                _post(manager, obj);
                
                }
                
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
                        Upload506Item bo = obj as Upload506Item;
                        
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
                        bSuccess = _PostNonTransaction(manager, obj as Upload506Item, bChildObject);
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
            private bool _PostNonTransaction(DbManagerProxy manager, Upload506Item obj, bool bChildObject) 
            { 
                bool bHasChanges = obj.HasChanges;
                if (!obj.IsNew && obj.IsMarkedToDelete) // delete
                {
            
                    if (!ValidateCanDelete(manager, obj)) return false;
                            
                }
                else if (!obj.IsMarkedToDelete) // insert/update
                {
                    if (!bChildObject)
                        if (!Validate(manager, obj, true, true, true)) 
                            return false;
                    
            
                    // posting extenters - begin
                obj.strCaseID = new Func<Upload506Item, DbManagerProxy, string>((c,m) => 
                      c.Resolution.HasValue && c.Resolution.Value == (int)Upload506Resolution.Created && c.PostWithoutMaster == 1
                      ? m.SetSpCommand("dbo.spGetNextNumber", (long)NumberingObjectEnum.HumanCase, DBNull.Value, DBNull.Value)
                        .ExecuteScalar<string>(ScalarSourceType.OutputParameter, "NextNumberValue")
                      : c.strCaseID 
                      )(obj, manager);
                    // posting extenters - end
            
                    if (!obj.IsMarkedToDelete && bHasChanges)
                        _postPredicate(manager, obj);
                        
                    // posted extenters - begin
                    // posted extenters - end
            
                }
                //obj.AcceptChanges();
                
                return true;
            }
            
            public bool ValidateCanDelete(Upload506Item obj)
            {
                using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
                {
                    return ValidateCanDelete(manager, obj);
                }
            }
            public bool ValidateCanDelete(DbManagerProxy manager, Upload506Item obj)
            {
            
                return true;
            }
        
      
            protected ValidationModelException ChainsValidate(Upload506Item obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(Upload506Item obj, bool bRethrowException)
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
                return Validate(manager, obj as Upload506Item, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Upload506Item obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(Upload506Item obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(Upload506Item obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as Upload506Item) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as Upload506Item) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "Upload506ItemDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spUpload506Item_SelectDetail";
            public static string spCount = "";
            public static string spPost = "spUpload506Item_Post";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<Upload506Item, bool>> RequiredByField = new Dictionary<string, Func<Upload506Item, bool>>();
            public static Dictionary<string, Func<Upload506Item, bool>> RequiredByProperty = new Dictionary<string, Func<Upload506Item, bool>>();
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
                
                Sizes.Add(_str_DISEASE, 255);
                Sizes.Add(_str_HN, 255);
                Sizes.Add(_str_NAME, 255);
                Sizes.Add(_str_ADDRESS, 255);
                Sizes.Add(_str_ADDRCODE, 255);
                Sizes.Add(_str_PROVINCE, 255);
                Sizes.Add(_str_HSERV, 255);
                Sizes.Add(_str_SCHOOL, 255);
                Sizes.Add(_str_COMPLICA, 255);
                Sizes.Add(_str_strCaseID, 32);
                GridMeta.Add(new GridMetaItem(
                    _str_idfCase,
                    _str_idfCase, null, false, false, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_HN,
                    "str506HN", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strCaseID,
                    "str506EIDSSCaseID", null, true, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strDiagnosis,
                    "DiagnosisName", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_datDiagnosisDate,
                    _str_datDiagnosisDate, null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_NAME,
                    "PatientName", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strHospital,
                    "strHospital506Item", null, false, true, true, true, true, null
                    ));
                GridMeta.Add(new GridMetaItem(
                    _str_strStatus,
                    "strStatus506Item", null, false, true, true, true, true, null
                    ));
                Actions.Add(new ActionMetaItem(
                    "ActionEditHumanCase",
                    ActionTypes.Action,
                    true,
                    "",
                    "",
                    
                    (manager, c, pars) => Accessor.Instance(null).ActionEditHumanCase(manager, (Upload506Item)c, pars),
                        
                    null,
                    
                    null,
                      true,
                    null,
                    null,
                    null,
                    null,
                    null,
                    false,
                    false,
                    null,
                    false,
                    new ActionMetaItem[] {
                      
                      }
                    
                    ));
                  
                Actions.Add(new ActionMetaItem(
                    "Edit",
                    ActionTypes.Edit,
                    false,
                    String.Empty,
                    String.Empty,
                    (manager, c, pars) => new ActResult(true, c),
                    null,
                    new ActionMetaItem.VisualItem(
                        /*from BvMessages*/"strEdit_Id",
                        "edit",
                        /*from BvMessages*/"tooltipEdit_Id",
                        /*from BvMessages*/"strView_Id",
                        "View1",
                        /*from BvMessages*/"tooltipEdit_Id",
                        ActionsAlignment.Right,
                        ActionsPanelType.Group,
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
	