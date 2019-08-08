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
    public abstract partial class Upload506Duplicate : 
        EditableObject<Upload506Duplicate>
        , IObject
        , IDisposable
        , ILookupUsage
        {
        
        [MapField(_str_idfCase), NonUpdatable, PrimaryKey]
        public abstract Int64 idfCase { get; set; }
                
        [LocalizedDisplayName(_str_strCaseID)]
        [MapField(_str_strCaseID)]
        public abstract String strCaseID { get; set; }
        protected String strCaseID_Original { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).OriginalValue; } }
        protected String strCaseID_Previous { get { return ((EditableValue<String>)((dynamic)this)._strCaseID).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DISEASE)]
        [MapField(_str_DISEASE)]
        public abstract String DISEASE { get; set; }
        protected String DISEASE_Original { get { return ((EditableValue<String>)((dynamic)this)._dISEASE).OriginalValue; } }
        protected String DISEASE_Previous { get { return ((EditableValue<String>)((dynamic)this)._dISEASE).PreviousValue; } }
                
        [LocalizedDisplayName("idfsTentativeDiagnosis")]
        [MapField(_str_strTentativeDiagnosisEIDSS)]
        public abstract String strTentativeDiagnosisEIDSS { get; set; }
        protected String strTentativeDiagnosisEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strTentativeDiagnosisEIDSS).OriginalValue; } }
        protected String strTentativeDiagnosisEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTentativeDiagnosisEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strTentativeDiagnosis506)]
        [MapField(_str_strTentativeDiagnosis506)]
        public abstract String strTentativeDiagnosis506 { get; set; }
        protected String strTentativeDiagnosis506_Original { get { return ((EditableValue<String>)((dynamic)this)._strTentativeDiagnosis506).OriginalValue; } }
        protected String strTentativeDiagnosis506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTentativeDiagnosis506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_HN)]
        [MapField(_str_HN)]
        public abstract String HN { get; set; }
        protected String HN_Original { get { return ((EditableValue<String>)((dynamic)this)._hN).OriginalValue; } }
        protected String HN_Previous { get { return ((EditableValue<String>)((dynamic)this)._hN).PreviousValue; } }
                
        [LocalizedDisplayName("strLocalIdentifier")]
        [MapField(_str_strLocalIdentifierEIDSS)]
        public abstract String strLocalIdentifierEIDSS { get; set; }
        protected String strLocalIdentifierEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strLocalIdentifierEIDSS).OriginalValue; } }
        protected String strLocalIdentifierEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strLocalIdentifierEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strLocalIdentifier506)]
        [MapField(_str_strLocalIdentifier506)]
        public abstract String strLocalIdentifier506 { get; set; }
        protected String strLocalIdentifier506_Original { get { return ((EditableValue<String>)((dynamic)this)._strLocalIdentifier506).OriginalValue; } }
        protected String strLocalIdentifier506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strLocalIdentifier506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_NAME)]
        [MapField(_str_NAME)]
        public abstract String NAME { get; set; }
        protected String NAME_Original { get { return ((EditableValue<String>)((dynamic)this)._nAME).OriginalValue; } }
        protected String NAME_Previous { get { return ((EditableValue<String>)((dynamic)this)._nAME).PreviousValue; } }
                
        [LocalizedDisplayName("PatientName")]
        [MapField(_str_strPatientNameEIDSS)]
        public abstract String strPatientNameEIDSS { get; set; }
        protected String strPatientNameEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strPatientNameEIDSS).OriginalValue; } }
        protected String strPatientNameEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPatientNameEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strPatientName506)]
        [MapField(_str_strPatientName506)]
        public abstract String strPatientName506 { get; set; }
        protected String strPatientName506_Original { get { return ((EditableValue<String>)((dynamic)this)._strPatientName506).OriginalValue; } }
        protected String strPatientName506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strPatientName506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_SEX)]
        [MapField(_str_SEX)]
        public abstract Int32? SEX { get; set; }
        protected Int32? SEX_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._sEX).OriginalValue; } }
        protected Int32? SEX_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._sEX).PreviousValue; } }
                
        [LocalizedDisplayName("idfsSex")]
        [MapField(_str_strHumanGenderEIDSS)]
        public abstract String strHumanGenderEIDSS { get; set; }
        protected String strHumanGenderEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strHumanGenderEIDSS).OriginalValue; } }
        protected String strHumanGenderEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHumanGenderEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strHumanGender506)]
        [MapField(_str_strHumanGender506)]
        public abstract String strHumanGender506 { get; set; }
        protected String strHumanGender506_Original { get { return ((EditableValue<String>)((dynamic)this)._strHumanGender506).OriginalValue; } }
        protected String strHumanGender506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHumanGender506).PreviousValue; } }
                
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
                
        [LocalizedDisplayName(_str_datDateofBirthEIDSS)]
        [MapField(_str_datDateofBirthEIDSS)]
        public abstract DateTime? datDateofBirthEIDSS { get; set; }
        protected DateTime? datDateofBirthEIDSS_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateofBirthEIDSS).OriginalValue; } }
        protected DateTime? datDateofBirthEIDSS_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateofBirthEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datDateofBirth506)]
        [MapField(_str_datDateofBirth506)]
        public abstract DateTime? datDateofBirth506 { get; set; }
        protected DateTime? datDateofBirth506_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateofBirth506).OriginalValue; } }
        protected DateTime? datDateofBirth506_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDateofBirth506).PreviousValue; } }
                
        [LocalizedDisplayName("Age")]
        [MapField(_str_intPatientAgeEIDSS)]
        public abstract Int32? intPatientAgeEIDSS { get; set; }
        protected Int32? intPatientAgeEIDSS_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intPatientAgeEIDSS).OriginalValue; } }
        protected Int32? intPatientAgeEIDSS_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intPatientAgeEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_intPatientAge506)]
        [MapField(_str_intPatientAge506)]
        public abstract Int32? intPatientAge506 { get; set; }
        protected Int32? intPatientAge506_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._intPatientAge506).OriginalValue; } }
        protected Int32? intPatientAge506_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._intPatientAge506).PreviousValue; } }
                
        [LocalizedDisplayName("idfsHumanAgeType")]
        [MapField(_str_strHumanAgeTypeEIDSS)]
        public abstract String strHumanAgeTypeEIDSS { get; set; }
        protected String strHumanAgeTypeEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strHumanAgeTypeEIDSS).OriginalValue; } }
        protected String strHumanAgeTypeEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHumanAgeTypeEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strHumanAgeType506)]
        [MapField(_str_strHumanAgeType506)]
        public abstract String strHumanAgeType506 { get; set; }
        protected String strHumanAgeType506_Original { get { return ((EditableValue<String>)((dynamic)this)._strHumanAgeType506).OriginalValue; } }
        protected String strHumanAgeType506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHumanAgeType506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_RACE)]
        [MapField(_str_RACE)]
        public abstract Int32? RACE { get; set; }
        protected Int32? RACE_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._rACE).OriginalValue; } }
        protected Int32? RACE_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._rACE).PreviousValue; } }
                
        [LocalizedDisplayName("idfsNationality")]
        [MapField(_str_strNationalityEIDSS)]
        public abstract String strNationalityEIDSS { get; set; }
        protected String strNationalityEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strNationalityEIDSS).OriginalValue; } }
        protected String strNationalityEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNationalityEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strNationality506)]
        [MapField(_str_strNationality506)]
        public abstract String strNationality506 { get; set; }
        protected String strNationality506_Original { get { return ((EditableValue<String>)((dynamic)this)._strNationality506).OriginalValue; } }
        protected String strNationality506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strNationality506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_OCCUPAT)]
        [MapField(_str_OCCUPAT)]
        public abstract Int32? OCCUPAT { get; set; }
        protected Int32? OCCUPAT_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._oCCUPAT).OriginalValue; } }
        protected Int32? OCCUPAT_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._oCCUPAT).PreviousValue; } }
                
        [LocalizedDisplayName("idfsOccupationType")]
        [MapField(_str_strOccupationTypeEIDSS)]
        public abstract String strOccupationTypeEIDSS { get; set; }
        protected String strOccupationTypeEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strOccupationTypeEIDSS).OriginalValue; } }
        protected String strOccupationTypeEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOccupationTypeEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strOccupationType506)]
        [MapField(_str_strOccupationType506)]
        public abstract String strOccupationType506 { get; set; }
        protected String strOccupationType506_Original { get { return ((EditableValue<String>)((dynamic)this)._strOccupationType506).OriginalValue; } }
        protected String strOccupationType506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOccupationType506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_ADDRESS)]
        [MapField(_str_ADDRESS)]
        public abstract String ADDRESS { get; set; }
        protected String ADDRESS_Original { get { return ((EditableValue<String>)((dynamic)this)._aDDRESS).OriginalValue; } }
        protected String ADDRESS_Previous { get { return ((EditableValue<String>)((dynamic)this)._aDDRESS).PreviousValue; } }
                
        [LocalizedDisplayName("strHouse")]
        [MapField(_str_strAddressEIDSS)]
        public abstract String strAddressEIDSS { get; set; }
        protected String strAddressEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strAddressEIDSS).OriginalValue; } }
        protected String strAddressEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAddressEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strAddress506)]
        [MapField(_str_strAddress506)]
        public abstract String strAddress506 { get; set; }
        protected String strAddress506_Original { get { return ((EditableValue<String>)((dynamic)this)._strAddress506).OriginalValue; } }
        protected String strAddress506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAddress506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_ADDRCODE)]
        [MapField(_str_ADDRCODE)]
        public abstract String ADDRCODE { get; set; }
        protected String ADDRCODE_Original { get { return ((EditableValue<String>)((dynamic)this)._aDDRCODE).OriginalValue; } }
        protected String ADDRCODE_Previous { get { return ((EditableValue<String>)((dynamic)this)._aDDRCODE).PreviousValue; } }
                
        [LocalizedDisplayName("strAddressCode")]
        [MapField(_str_strAddrCodeEIDSS)]
        public abstract String strAddrCodeEIDSS { get; set; }
        protected String strAddrCodeEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strAddrCodeEIDSS).OriginalValue; } }
        protected String strAddrCodeEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAddrCodeEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strAddrCode506)]
        [MapField(_str_strAddrCode506)]
        public abstract String strAddrCode506 { get; set; }
        protected String strAddrCode506_Original { get { return ((EditableValue<String>)((dynamic)this)._strAddrCode506).OriginalValue; } }
        protected String strAddrCode506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strAddrCode506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_PROVINCE)]
        [MapField(_str_PROVINCE)]
        public abstract String PROVINCE { get; set; }
        protected String PROVINCE_Original { get { return ((EditableValue<String>)((dynamic)this)._pROVINCE).OriginalValue; } }
        protected String PROVINCE_Previous { get { return ((EditableValue<String>)((dynamic)this)._pROVINCE).PreviousValue; } }
                
        [LocalizedDisplayName("strProvince")]
        [MapField(_str_strRegionEIDSS)]
        public abstract String strRegionEIDSS { get; set; }
        protected String strRegionEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strRegionEIDSS).OriginalValue; } }
        protected String strRegionEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRegionEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strRayonEIDSS)]
        [MapField(_str_strRayonEIDSS)]
        public abstract String strRayonEIDSS { get; set; }
        protected String strRayonEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strRayonEIDSS).OriginalValue; } }
        protected String strRayonEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRayonEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName("idfsSettlement")]
        [MapField(_str_strSettlementEIDSS)]
        public abstract String strSettlementEIDSS { get; set; }
        protected String strSettlementEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strSettlementEIDSS).OriginalValue; } }
        protected String strSettlementEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSettlementEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strRegion506)]
        [MapField(_str_strRegion506)]
        public abstract String strRegion506 { get; set; }
        protected String strRegion506_Original { get { return ((EditableValue<String>)((dynamic)this)._strRegion506).OriginalValue; } }
        protected String strRegion506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRegion506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strRayon506)]
        [MapField(_str_strRayon506)]
        public abstract String strRayon506 { get; set; }
        protected String strRayon506_Original { get { return ((EditableValue<String>)((dynamic)this)._strRayon506).OriginalValue; } }
        protected String strRayon506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strRayon506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSettlement506)]
        [MapField(_str_strSettlement506)]
        public abstract String strSettlement506 { get; set; }
        protected String strSettlement506_Original { get { return ((EditableValue<String>)((dynamic)this)._strSettlement506).OriginalValue; } }
        protected String strSettlement506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSettlement506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_TYPE)]
        [MapField(_str_TYPE)]
        public abstract Int32? TYPE { get; set; }
        protected Int32? TYPE_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._tYPE).OriginalValue; } }
        protected Int32? TYPE_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._tYPE).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strTypeEIDSS)]
        [MapField(_str_strTypeEIDSS)]
        public abstract String strTypeEIDSS { get; set; }
        protected String strTypeEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strTypeEIDSS).OriginalValue; } }
        protected String strTypeEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strTypeEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strType506)]
        [MapField(_str_strType506)]
        public abstract String strType506 { get; set; }
        protected String strType506_Original { get { return ((EditableValue<String>)((dynamic)this)._strType506).OriginalValue; } }
        protected String strType506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strType506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_RESULT)]
        [MapField(_str_RESULT)]
        public abstract Int32? RESULT { get; set; }
        protected Int32? RESULT_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._rESULT).OriginalValue; } }
        protected Int32? RESULT_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._rESULT).PreviousValue; } }
                
        [LocalizedDisplayName("idfsOutcome")]
        [MapField(_str_strOutcomeEIDSS)]
        public abstract String strOutcomeEIDSS { get; set; }
        protected String strOutcomeEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strOutcomeEIDSS).OriginalValue; } }
        protected String strOutcomeEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOutcomeEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strOutcome506)]
        [MapField(_str_strOutcome506)]
        public abstract String strOutcome506 { get; set; }
        protected String strOutcome506_Original { get { return ((EditableValue<String>)((dynamic)this)._strOutcome506).OriginalValue; } }
        protected String strOutcome506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strOutcome506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_HSERV)]
        [MapField(_str_HSERV)]
        public abstract String HSERV { get; set; }
        protected String HSERV_Original { get { return ((EditableValue<String>)((dynamic)this)._hSERV).OriginalValue; } }
        protected String HSERV_Previous { get { return ((EditableValue<String>)((dynamic)this)._hSERV).PreviousValue; } }
                
        [LocalizedDisplayName("idfSentByOffice2")]
        [MapField(_str_strSentByOfficeEIDSS)]
        public abstract String strSentByOfficeEIDSS { get; set; }
        protected String strSentByOfficeEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strSentByOfficeEIDSS).OriginalValue; } }
        protected String strSentByOfficeEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSentByOfficeEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strSentByOffice506)]
        [MapField(_str_strSentByOffice506)]
        public abstract String strSentByOffice506 { get; set; }
        protected String strSentByOffice506_Original { get { return ((EditableValue<String>)((dynamic)this)._strSentByOffice506).OriginalValue; } }
        protected String strSentByOffice506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strSentByOffice506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_SCHOOL)]
        [MapField(_str_SCHOOL)]
        public abstract String SCHOOL { get; set; }
        protected String SCHOOL_Original { get { return ((EditableValue<String>)((dynamic)this)._sCHOOL).OriginalValue; } }
        protected String SCHOOL_Previous { get { return ((EditableValue<String>)((dynamic)this)._sCHOOL).PreviousValue; } }
                
        [LocalizedDisplayName("strEmployerName")]
        [MapField(_str_strEmployerNameEIDSS)]
        public abstract String strEmployerNameEIDSS { get; set; }
        protected String strEmployerNameEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strEmployerNameEIDSS).OriginalValue; } }
        protected String strEmployerNameEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strEmployerNameEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strEmployerName506)]
        [MapField(_str_strEmployerName506)]
        public abstract String strEmployerName506 { get; set; }
        protected String strEmployerName506_Original { get { return ((EditableValue<String>)((dynamic)this)._strEmployerName506).OriginalValue; } }
        protected String strEmployerName506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strEmployerName506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DATESICK)]
        [MapField(_str_DATESICK)]
        public abstract DateTime? DATESICK { get; set; }
        protected DateTime? DATESICK_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._dATESICK).OriginalValue; } }
        protected DateTime? DATESICK_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._dATESICK).PreviousValue; } }
                
        [LocalizedDisplayName("datDateOfSymptomsOnset")]
        [MapField(_str_datSickEIDSS)]
        public abstract DateTime? datSickEIDSS { get; set; }
        protected DateTime? datSickEIDSS_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datSickEIDSS).OriginalValue; } }
        protected DateTime? datSickEIDSS_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datSickEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datSick506)]
        [MapField(_str_datSick506)]
        public abstract DateTime? datSick506 { get; set; }
        protected DateTime? datSick506_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datSick506).OriginalValue; } }
        protected DateTime? datSick506_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datSick506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DATEDEFINE)]
        [MapField(_str_DATEDEFINE)]
        public abstract DateTime? DATEDEFINE { get; set; }
        protected DateTime? DATEDEFINE_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._dATEDEFINE).OriginalValue; } }
        protected DateTime? DATEDEFINE_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._dATEDEFINE).PreviousValue; } }
                
        [LocalizedDisplayName("datDiagnosisDate")]
        [MapField(_str_datDefineEIDSS)]
        public abstract DateTime? datDefineEIDSS { get; set; }
        protected DateTime? datDefineEIDSS_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDefineEIDSS).OriginalValue; } }
        protected DateTime? datDefineEIDSS_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDefineEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datDefine506)]
        [MapField(_str_datDefine506)]
        public abstract DateTime? datDefine506 { get; set; }
        protected DateTime? datDefine506_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDefine506).OriginalValue; } }
        protected DateTime? datDefine506_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDefine506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DATEDEATH)]
        [MapField(_str_DATEDEATH)]
        public abstract DateTime? DATEDEATH { get; set; }
        protected DateTime? DATEDEATH_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._dATEDEATH).OriginalValue; } }
        protected DateTime? DATEDEATH_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._dATEDEATH).PreviousValue; } }
                
        [LocalizedDisplayName("datDateOfDeath")]
        [MapField(_str_datDeathEIDSS)]
        public abstract DateTime? datDeathEIDSS { get; set; }
        protected DateTime? datDeathEIDSS_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDeathEIDSS).OriginalValue; } }
        protected DateTime? datDeathEIDSS_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDeathEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datDeath506)]
        [MapField(_str_datDeath506)]
        public abstract DateTime? datDeath506 { get; set; }
        protected DateTime? datDeath506_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDeath506).OriginalValue; } }
        protected DateTime? datDeath506_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datDeath506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_DATERECORD)]
        [MapField(_str_DATERECORD)]
        public abstract DateTime? DATERECORD { get; set; }
        protected DateTime? DATERECORD_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._dATERECORD).OriginalValue; } }
        protected DateTime? DATERECORD_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._dATERECORD).PreviousValue; } }
                
        [LocalizedDisplayName("datNotificationDate")]
        [MapField(_str_datRecordEIDSS)]
        public abstract DateTime? datRecordEIDSS { get; set; }
        protected DateTime? datRecordEIDSS_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datRecordEIDSS).OriginalValue; } }
        protected DateTime? datRecordEIDSS_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datRecordEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datRecord506)]
        [MapField(_str_datRecord506)]
        public abstract DateTime? datRecord506 { get; set; }
        protected DateTime? datRecord506_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datRecord506).OriginalValue; } }
        protected DateTime? datRecord506_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datRecord506).PreviousValue; } }
                
        [LocalizedDisplayName("datEnteredDate")]
        [MapField(_str_datEnteredEIDSS)]
        public abstract DateTime? datEnteredEIDSS { get; set; }
        protected DateTime? datEnteredEIDSS_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredEIDSS).OriginalValue; } }
        protected DateTime? datEnteredEIDSS_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEnteredEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_datEntered506)]
        [MapField(_str_datEntered506)]
        public abstract DateTime? datEntered506 { get; set; }
        protected DateTime? datEntered506_Original { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEntered506).OriginalValue; } }
        protected DateTime? datEntered506_Previous { get { return ((EditableValue<DateTime?>)((dynamic)this)._datEntered506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_COMPLICA)]
        [MapField(_str_COMPLICA)]
        public abstract String COMPLICA { get; set; }
        protected String COMPLICA_Original { get { return ((EditableValue<String>)((dynamic)this)._cOMPLICA).OriginalValue; } }
        protected String COMPLICA_Previous { get { return ((EditableValue<String>)((dynamic)this)._cOMPLICA).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strComplicaEIDSS)]
        [MapField(_str_strComplicaEIDSS)]
        public abstract String strComplicaEIDSS { get; set; }
        protected String strComplicaEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strComplicaEIDSS).OriginalValue; } }
        protected String strComplicaEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strComplicaEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strComplica506)]
        [MapField(_str_strComplica506)]
        public abstract String strComplica506 { get; set; }
        protected String strComplica506_Original { get { return ((EditableValue<String>)((dynamic)this)._strComplica506).OriginalValue; } }
        protected String strComplica506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strComplica506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_MARIETAL)]
        [MapField(_str_MARIETAL)]
        public abstract Int32? MARIETAL { get; set; }
        protected Int32? MARIETAL_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._mARIETAL).OriginalValue; } }
        protected Int32? MARIETAL_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._mARIETAL).PreviousValue; } }
                
        [LocalizedDisplayName("strMaritalStatus")]
        [MapField(_str_strMarietalEIDSS)]
        public abstract String strMarietalEIDSS { get; set; }
        protected String strMarietalEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strMarietalEIDSS).OriginalValue; } }
        protected String strMarietalEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strMarietalEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strMarietal506)]
        [MapField(_str_strMarietal506)]
        public abstract String strMarietal506 { get; set; }
        protected String strMarietal506_Original { get { return ((EditableValue<String>)((dynamic)this)._strMarietal506).OriginalValue; } }
        protected String strMarietal506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strMarietal506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_RACE1)]
        [MapField(_str_RACE1)]
        public abstract Int32? RACE1 { get; set; }
        protected Int32? RACE1_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._rACE1).OriginalValue; } }
        protected Int32? RACE1_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._rACE1).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strForeignEIDSS)]
        [MapField(_str_strForeignEIDSS)]
        public abstract String strForeignEIDSS { get; set; }
        protected String strForeignEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strForeignEIDSS).OriginalValue; } }
        protected String strForeignEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strForeignEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strForeign506)]
        [MapField(_str_strForeign506)]
        public abstract String strForeign506 { get; set; }
        protected String strForeign506_Original { get { return ((EditableValue<String>)((dynamic)this)._strForeign506).OriginalValue; } }
        protected String strForeign506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strForeign506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_METROPOL)]
        [MapField(_str_METROPOL)]
        public abstract Int32? METROPOL { get; set; }
        protected Int32? METROPOL_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._mETROPOL).OriginalValue; } }
        protected Int32? METROPOL_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._mETROPOL).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strMunicipalityEIDSS)]
        [MapField(_str_strMunicipalityEIDSS)]
        public abstract String strMunicipalityEIDSS { get; set; }
        protected String strMunicipalityEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strMunicipalityEIDSS).OriginalValue; } }
        protected String strMunicipalityEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strMunicipalityEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strMunicipality506)]
        [MapField(_str_strMunicipality506)]
        public abstract String strMunicipality506 { get; set; }
        protected String strMunicipality506_Original { get { return ((EditableValue<String>)((dynamic)this)._strMunicipality506).OriginalValue; } }
        protected String strMunicipality506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strMunicipality506).PreviousValue; } }
                
        [LocalizedDisplayName(_str_HOSPITAL)]
        [MapField(_str_HOSPITAL)]
        public abstract Int32? HOSPITAL { get; set; }
        protected Int32? HOSPITAL_Original { get { return ((EditableValue<Int32?>)((dynamic)this)._hOSPITAL).OriginalValue; } }
        protected Int32? HOSPITAL_Previous { get { return ((EditableValue<Int32?>)((dynamic)this)._hOSPITAL).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strHospitalizationEIDSS)]
        [MapField(_str_strHospitalizationEIDSS)]
        public abstract String strHospitalizationEIDSS { get; set; }
        protected String strHospitalizationEIDSS_Original { get { return ((EditableValue<String>)((dynamic)this)._strHospitalizationEIDSS).OriginalValue; } }
        protected String strHospitalizationEIDSS_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHospitalizationEIDSS).PreviousValue; } }
                
        [LocalizedDisplayName(_str_strHospitalization506)]
        [MapField(_str_strHospitalization506)]
        public abstract String strHospitalization506 { get; set; }
        protected String strHospitalization506_Original { get { return ((EditableValue<String>)((dynamic)this)._strHospitalization506).OriginalValue; } }
        protected String strHospitalization506_Previous { get { return ((EditableValue<String>)((dynamic)this)._strHospitalization506).PreviousValue; } }
                
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
            internal Func<Upload506Duplicate, object> _get_func;
            internal Action<Upload506Duplicate, string> _set_func;
            internal Action<Upload506Duplicate, Upload506Duplicate, CompareModel, DbManagerProxy> _compare_func;
        }
        internal const string _str_Parent = "Parent";
        internal const string _str_IsNew = "IsNew";
        
        internal const string _str_idfCase = "idfCase";
        internal const string _str_strCaseID = "strCaseID";
        internal const string _str_DISEASE = "DISEASE";
        internal const string _str_strTentativeDiagnosisEIDSS = "strTentativeDiagnosisEIDSS";
        internal const string _str_strTentativeDiagnosis506 = "strTentativeDiagnosis506";
        internal const string _str_HN = "HN";
        internal const string _str_strLocalIdentifierEIDSS = "strLocalIdentifierEIDSS";
        internal const string _str_strLocalIdentifier506 = "strLocalIdentifier506";
        internal const string _str_NAME = "NAME";
        internal const string _str_strPatientNameEIDSS = "strPatientNameEIDSS";
        internal const string _str_strPatientName506 = "strPatientName506";
        internal const string _str_SEX = "SEX";
        internal const string _str_strHumanGenderEIDSS = "strHumanGenderEIDSS";
        internal const string _str_strHumanGender506 = "strHumanGender506";
        internal const string _str_YEAR = "YEAR";
        internal const string _str_MONTH = "MONTH";
        internal const string _str_DAY = "DAY";
        internal const string _str_datDateofBirthEIDSS = "datDateofBirthEIDSS";
        internal const string _str_datDateofBirth506 = "datDateofBirth506";
        internal const string _str_intPatientAgeEIDSS = "intPatientAgeEIDSS";
        internal const string _str_intPatientAge506 = "intPatientAge506";
        internal const string _str_strHumanAgeTypeEIDSS = "strHumanAgeTypeEIDSS";
        internal const string _str_strHumanAgeType506 = "strHumanAgeType506";
        internal const string _str_RACE = "RACE";
        internal const string _str_strNationalityEIDSS = "strNationalityEIDSS";
        internal const string _str_strNationality506 = "strNationality506";
        internal const string _str_OCCUPAT = "OCCUPAT";
        internal const string _str_strOccupationTypeEIDSS = "strOccupationTypeEIDSS";
        internal const string _str_strOccupationType506 = "strOccupationType506";
        internal const string _str_ADDRESS = "ADDRESS";
        internal const string _str_strAddressEIDSS = "strAddressEIDSS";
        internal const string _str_strAddress506 = "strAddress506";
        internal const string _str_ADDRCODE = "ADDRCODE";
        internal const string _str_strAddrCodeEIDSS = "strAddrCodeEIDSS";
        internal const string _str_strAddrCode506 = "strAddrCode506";
        internal const string _str_PROVINCE = "PROVINCE";
        internal const string _str_strRegionEIDSS = "strRegionEIDSS";
        internal const string _str_strRayonEIDSS = "strRayonEIDSS";
        internal const string _str_strSettlementEIDSS = "strSettlementEIDSS";
        internal const string _str_strRegion506 = "strRegion506";
        internal const string _str_strRayon506 = "strRayon506";
        internal const string _str_strSettlement506 = "strSettlement506";
        internal const string _str_TYPE = "TYPE";
        internal const string _str_strTypeEIDSS = "strTypeEIDSS";
        internal const string _str_strType506 = "strType506";
        internal const string _str_RESULT = "RESULT";
        internal const string _str_strOutcomeEIDSS = "strOutcomeEIDSS";
        internal const string _str_strOutcome506 = "strOutcome506";
        internal const string _str_HSERV = "HSERV";
        internal const string _str_strSentByOfficeEIDSS = "strSentByOfficeEIDSS";
        internal const string _str_strSentByOffice506 = "strSentByOffice506";
        internal const string _str_SCHOOL = "SCHOOL";
        internal const string _str_strEmployerNameEIDSS = "strEmployerNameEIDSS";
        internal const string _str_strEmployerName506 = "strEmployerName506";
        internal const string _str_DATESICK = "DATESICK";
        internal const string _str_datSickEIDSS = "datSickEIDSS";
        internal const string _str_datSick506 = "datSick506";
        internal const string _str_DATEDEFINE = "DATEDEFINE";
        internal const string _str_datDefineEIDSS = "datDefineEIDSS";
        internal const string _str_datDefine506 = "datDefine506";
        internal const string _str_DATEDEATH = "DATEDEATH";
        internal const string _str_datDeathEIDSS = "datDeathEIDSS";
        internal const string _str_datDeath506 = "datDeath506";
        internal const string _str_DATERECORD = "DATERECORD";
        internal const string _str_datRecordEIDSS = "datRecordEIDSS";
        internal const string _str_datRecord506 = "datRecord506";
        internal const string _str_datEnteredEIDSS = "datEnteredEIDSS";
        internal const string _str_datEntered506 = "datEntered506";
        internal const string _str_COMPLICA = "COMPLICA";
        internal const string _str_strComplicaEIDSS = "strComplicaEIDSS";
        internal const string _str_strComplica506 = "strComplica506";
        internal const string _str_MARIETAL = "MARIETAL";
        internal const string _str_strMarietalEIDSS = "strMarietalEIDSS";
        internal const string _str_strMarietal506 = "strMarietal506";
        internal const string _str_RACE1 = "RACE1";
        internal const string _str_strForeignEIDSS = "strForeignEIDSS";
        internal const string _str_strForeign506 = "strForeign506";
        internal const string _str_METROPOL = "METROPOL";
        internal const string _str_strMunicipalityEIDSS = "strMunicipalityEIDSS";
        internal const string _str_strMunicipality506 = "strMunicipality506";
        internal const string _str_HOSPITAL = "HOSPITAL";
        internal const string _str_strHospitalizationEIDSS = "strHospitalizationEIDSS";
        internal const string _str_strHospitalization506 = "strHospitalization506";
        internal const string _str_idfsUpload506 = "idfsUpload506";
        internal const string _str_Item = "Item";
        internal const string _str_Resolved = "Resolved";
        private static readonly field_info[] _field_infos =
        {
                  
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
              _name = _str_strTentativeDiagnosisEIDSS, _formname = _str_strTentativeDiagnosisEIDSS, _type = "String",
              _get_func = o => o.strTentativeDiagnosisEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTentativeDiagnosisEIDSS != newval) o.strTentativeDiagnosisEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strTentativeDiagnosisEIDSS != c.strTentativeDiagnosisEIDSS || o.IsRIRPropChanged(_str_strTentativeDiagnosisEIDSS, c)) 
                  m.Add(_str_strTentativeDiagnosisEIDSS, o.ObjectIdent + _str_strTentativeDiagnosisEIDSS, o.ObjectIdent2 + _str_strTentativeDiagnosisEIDSS, o.ObjectIdent3 + _str_strTentativeDiagnosisEIDSS, "String", 
                    o.strTentativeDiagnosisEIDSS == null ? "" : o.strTentativeDiagnosisEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strTentativeDiagnosisEIDSS), o.IsInvisible(_str_strTentativeDiagnosisEIDSS), o.IsRequired(_str_strTentativeDiagnosisEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strTentativeDiagnosis506, _formname = _str_strTentativeDiagnosis506, _type = "String",
              _get_func = o => o.strTentativeDiagnosis506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTentativeDiagnosis506 != newval) o.strTentativeDiagnosis506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strTentativeDiagnosis506 != c.strTentativeDiagnosis506 || o.IsRIRPropChanged(_str_strTentativeDiagnosis506, c)) 
                  m.Add(_str_strTentativeDiagnosis506, o.ObjectIdent + _str_strTentativeDiagnosis506, o.ObjectIdent2 + _str_strTentativeDiagnosis506, o.ObjectIdent3 + _str_strTentativeDiagnosis506, "String", 
                    o.strTentativeDiagnosis506 == null ? "" : o.strTentativeDiagnosis506.ToString(),                  
                  o.IsReadOnly(_str_strTentativeDiagnosis506), o.IsInvisible(_str_strTentativeDiagnosis506), o.IsRequired(_str_strTentativeDiagnosis506)); 
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
              _name = _str_strLocalIdentifierEIDSS, _formname = _str_strLocalIdentifierEIDSS, _type = "String",
              _get_func = o => o.strLocalIdentifierEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strLocalIdentifierEIDSS != newval) o.strLocalIdentifierEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strLocalIdentifierEIDSS != c.strLocalIdentifierEIDSS || o.IsRIRPropChanged(_str_strLocalIdentifierEIDSS, c)) 
                  m.Add(_str_strLocalIdentifierEIDSS, o.ObjectIdent + _str_strLocalIdentifierEIDSS, o.ObjectIdent2 + _str_strLocalIdentifierEIDSS, o.ObjectIdent3 + _str_strLocalIdentifierEIDSS, "String", 
                    o.strLocalIdentifierEIDSS == null ? "" : o.strLocalIdentifierEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strLocalIdentifierEIDSS), o.IsInvisible(_str_strLocalIdentifierEIDSS), o.IsRequired(_str_strLocalIdentifierEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strLocalIdentifier506, _formname = _str_strLocalIdentifier506, _type = "String",
              _get_func = o => o.strLocalIdentifier506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strLocalIdentifier506 != newval) o.strLocalIdentifier506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strLocalIdentifier506 != c.strLocalIdentifier506 || o.IsRIRPropChanged(_str_strLocalIdentifier506, c)) 
                  m.Add(_str_strLocalIdentifier506, o.ObjectIdent + _str_strLocalIdentifier506, o.ObjectIdent2 + _str_strLocalIdentifier506, o.ObjectIdent3 + _str_strLocalIdentifier506, "String", 
                    o.strLocalIdentifier506 == null ? "" : o.strLocalIdentifier506.ToString(),                  
                  o.IsReadOnly(_str_strLocalIdentifier506), o.IsInvisible(_str_strLocalIdentifier506), o.IsRequired(_str_strLocalIdentifier506)); 
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
              _name = _str_strPatientNameEIDSS, _formname = _str_strPatientNameEIDSS, _type = "String",
              _get_func = o => o.strPatientNameEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPatientNameEIDSS != newval) o.strPatientNameEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strPatientNameEIDSS != c.strPatientNameEIDSS || o.IsRIRPropChanged(_str_strPatientNameEIDSS, c)) 
                  m.Add(_str_strPatientNameEIDSS, o.ObjectIdent + _str_strPatientNameEIDSS, o.ObjectIdent2 + _str_strPatientNameEIDSS, o.ObjectIdent3 + _str_strPatientNameEIDSS, "String", 
                    o.strPatientNameEIDSS == null ? "" : o.strPatientNameEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strPatientNameEIDSS), o.IsInvisible(_str_strPatientNameEIDSS), o.IsRequired(_str_strPatientNameEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strPatientName506, _formname = _str_strPatientName506, _type = "String",
              _get_func = o => o.strPatientName506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strPatientName506 != newval) o.strPatientName506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strPatientName506 != c.strPatientName506 || o.IsRIRPropChanged(_str_strPatientName506, c)) 
                  m.Add(_str_strPatientName506, o.ObjectIdent + _str_strPatientName506, o.ObjectIdent2 + _str_strPatientName506, o.ObjectIdent3 + _str_strPatientName506, "String", 
                    o.strPatientName506 == null ? "" : o.strPatientName506.ToString(),                  
                  o.IsReadOnly(_str_strPatientName506), o.IsInvisible(_str_strPatientName506), o.IsRequired(_str_strPatientName506)); 
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
              _name = _str_strHumanGenderEIDSS, _formname = _str_strHumanGenderEIDSS, _type = "String",
              _get_func = o => o.strHumanGenderEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHumanGenderEIDSS != newval) o.strHumanGenderEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strHumanGenderEIDSS != c.strHumanGenderEIDSS || o.IsRIRPropChanged(_str_strHumanGenderEIDSS, c)) 
                  m.Add(_str_strHumanGenderEIDSS, o.ObjectIdent + _str_strHumanGenderEIDSS, o.ObjectIdent2 + _str_strHumanGenderEIDSS, o.ObjectIdent3 + _str_strHumanGenderEIDSS, "String", 
                    o.strHumanGenderEIDSS == null ? "" : o.strHumanGenderEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strHumanGenderEIDSS), o.IsInvisible(_str_strHumanGenderEIDSS), o.IsRequired(_str_strHumanGenderEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHumanGender506, _formname = _str_strHumanGender506, _type = "String",
              _get_func = o => o.strHumanGender506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHumanGender506 != newval) o.strHumanGender506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strHumanGender506 != c.strHumanGender506 || o.IsRIRPropChanged(_str_strHumanGender506, c)) 
                  m.Add(_str_strHumanGender506, o.ObjectIdent + _str_strHumanGender506, o.ObjectIdent2 + _str_strHumanGender506, o.ObjectIdent3 + _str_strHumanGender506, "String", 
                    o.strHumanGender506 == null ? "" : o.strHumanGender506.ToString(),                  
                  o.IsReadOnly(_str_strHumanGender506), o.IsInvisible(_str_strHumanGender506), o.IsRequired(_str_strHumanGender506)); 
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
              _name = _str_datDateofBirthEIDSS, _formname = _str_datDateofBirthEIDSS, _type = "DateTime?",
              _get_func = o => o.datDateofBirthEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDateofBirthEIDSS != newval) o.datDateofBirthEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datDateofBirthEIDSS != c.datDateofBirthEIDSS || o.IsRIRPropChanged(_str_datDateofBirthEIDSS, c)) 
                  m.Add(_str_datDateofBirthEIDSS, o.ObjectIdent + _str_datDateofBirthEIDSS, o.ObjectIdent2 + _str_datDateofBirthEIDSS, o.ObjectIdent3 + _str_datDateofBirthEIDSS, "DateTime?", 
                    o.datDateofBirthEIDSS == null ? "" : o.datDateofBirthEIDSS.ToString(),                  
                  o.IsReadOnly(_str_datDateofBirthEIDSS), o.IsInvisible(_str_datDateofBirthEIDSS), o.IsRequired(_str_datDateofBirthEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDateofBirth506, _formname = _str_datDateofBirth506, _type = "DateTime?",
              _get_func = o => o.datDateofBirth506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDateofBirth506 != newval) o.datDateofBirth506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datDateofBirth506 != c.datDateofBirth506 || o.IsRIRPropChanged(_str_datDateofBirth506, c)) 
                  m.Add(_str_datDateofBirth506, o.ObjectIdent + _str_datDateofBirth506, o.ObjectIdent2 + _str_datDateofBirth506, o.ObjectIdent3 + _str_datDateofBirth506, "DateTime?", 
                    o.datDateofBirth506 == null ? "" : o.datDateofBirth506.ToString(),                  
                  o.IsReadOnly(_str_datDateofBirth506), o.IsInvisible(_str_datDateofBirth506), o.IsRequired(_str_datDateofBirth506)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intPatientAgeEIDSS, _formname = _str_intPatientAgeEIDSS, _type = "Int32?",
              _get_func = o => o.intPatientAgeEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intPatientAgeEIDSS != newval) o.intPatientAgeEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intPatientAgeEIDSS != c.intPatientAgeEIDSS || o.IsRIRPropChanged(_str_intPatientAgeEIDSS, c)) 
                  m.Add(_str_intPatientAgeEIDSS, o.ObjectIdent + _str_intPatientAgeEIDSS, o.ObjectIdent2 + _str_intPatientAgeEIDSS, o.ObjectIdent3 + _str_intPatientAgeEIDSS, "Int32?", 
                    o.intPatientAgeEIDSS == null ? "" : o.intPatientAgeEIDSS.ToString(),                  
                  o.IsReadOnly(_str_intPatientAgeEIDSS), o.IsInvisible(_str_intPatientAgeEIDSS), o.IsRequired(_str_intPatientAgeEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_intPatientAge506, _formname = _str_intPatientAge506, _type = "Int32?",
              _get_func = o => o.intPatientAge506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseInt32Nullable(val); if (o.intPatientAge506 != newval) o.intPatientAge506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.intPatientAge506 != c.intPatientAge506 || o.IsRIRPropChanged(_str_intPatientAge506, c)) 
                  m.Add(_str_intPatientAge506, o.ObjectIdent + _str_intPatientAge506, o.ObjectIdent2 + _str_intPatientAge506, o.ObjectIdent3 + _str_intPatientAge506, "Int32?", 
                    o.intPatientAge506 == null ? "" : o.intPatientAge506.ToString(),                  
                  o.IsReadOnly(_str_intPatientAge506), o.IsInvisible(_str_intPatientAge506), o.IsRequired(_str_intPatientAge506)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHumanAgeTypeEIDSS, _formname = _str_strHumanAgeTypeEIDSS, _type = "String",
              _get_func = o => o.strHumanAgeTypeEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHumanAgeTypeEIDSS != newval) o.strHumanAgeTypeEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strHumanAgeTypeEIDSS != c.strHumanAgeTypeEIDSS || o.IsRIRPropChanged(_str_strHumanAgeTypeEIDSS, c)) 
                  m.Add(_str_strHumanAgeTypeEIDSS, o.ObjectIdent + _str_strHumanAgeTypeEIDSS, o.ObjectIdent2 + _str_strHumanAgeTypeEIDSS, o.ObjectIdent3 + _str_strHumanAgeTypeEIDSS, "String", 
                    o.strHumanAgeTypeEIDSS == null ? "" : o.strHumanAgeTypeEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strHumanAgeTypeEIDSS), o.IsInvisible(_str_strHumanAgeTypeEIDSS), o.IsRequired(_str_strHumanAgeTypeEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHumanAgeType506, _formname = _str_strHumanAgeType506, _type = "String",
              _get_func = o => o.strHumanAgeType506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHumanAgeType506 != newval) o.strHumanAgeType506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strHumanAgeType506 != c.strHumanAgeType506 || o.IsRIRPropChanged(_str_strHumanAgeType506, c)) 
                  m.Add(_str_strHumanAgeType506, o.ObjectIdent + _str_strHumanAgeType506, o.ObjectIdent2 + _str_strHumanAgeType506, o.ObjectIdent3 + _str_strHumanAgeType506, "String", 
                    o.strHumanAgeType506 == null ? "" : o.strHumanAgeType506.ToString(),                  
                  o.IsReadOnly(_str_strHumanAgeType506), o.IsInvisible(_str_strHumanAgeType506), o.IsRequired(_str_strHumanAgeType506)); 
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
              _name = _str_strNationalityEIDSS, _formname = _str_strNationalityEIDSS, _type = "String",
              _get_func = o => o.strNationalityEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strNationalityEIDSS != newval) o.strNationalityEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strNationalityEIDSS != c.strNationalityEIDSS || o.IsRIRPropChanged(_str_strNationalityEIDSS, c)) 
                  m.Add(_str_strNationalityEIDSS, o.ObjectIdent + _str_strNationalityEIDSS, o.ObjectIdent2 + _str_strNationalityEIDSS, o.ObjectIdent3 + _str_strNationalityEIDSS, "String", 
                    o.strNationalityEIDSS == null ? "" : o.strNationalityEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strNationalityEIDSS), o.IsInvisible(_str_strNationalityEIDSS), o.IsRequired(_str_strNationalityEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strNationality506, _formname = _str_strNationality506, _type = "String",
              _get_func = o => o.strNationality506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strNationality506 != newval) o.strNationality506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strNationality506 != c.strNationality506 || o.IsRIRPropChanged(_str_strNationality506, c)) 
                  m.Add(_str_strNationality506, o.ObjectIdent + _str_strNationality506, o.ObjectIdent2 + _str_strNationality506, o.ObjectIdent3 + _str_strNationality506, "String", 
                    o.strNationality506 == null ? "" : o.strNationality506.ToString(),                  
                  o.IsReadOnly(_str_strNationality506), o.IsInvisible(_str_strNationality506), o.IsRequired(_str_strNationality506)); 
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
              _name = _str_strOccupationTypeEIDSS, _formname = _str_strOccupationTypeEIDSS, _type = "String",
              _get_func = o => o.strOccupationTypeEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOccupationTypeEIDSS != newval) o.strOccupationTypeEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strOccupationTypeEIDSS != c.strOccupationTypeEIDSS || o.IsRIRPropChanged(_str_strOccupationTypeEIDSS, c)) 
                  m.Add(_str_strOccupationTypeEIDSS, o.ObjectIdent + _str_strOccupationTypeEIDSS, o.ObjectIdent2 + _str_strOccupationTypeEIDSS, o.ObjectIdent3 + _str_strOccupationTypeEIDSS, "String", 
                    o.strOccupationTypeEIDSS == null ? "" : o.strOccupationTypeEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strOccupationTypeEIDSS), o.IsInvisible(_str_strOccupationTypeEIDSS), o.IsRequired(_str_strOccupationTypeEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strOccupationType506, _formname = _str_strOccupationType506, _type = "String",
              _get_func = o => o.strOccupationType506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOccupationType506 != newval) o.strOccupationType506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strOccupationType506 != c.strOccupationType506 || o.IsRIRPropChanged(_str_strOccupationType506, c)) 
                  m.Add(_str_strOccupationType506, o.ObjectIdent + _str_strOccupationType506, o.ObjectIdent2 + _str_strOccupationType506, o.ObjectIdent3 + _str_strOccupationType506, "String", 
                    o.strOccupationType506 == null ? "" : o.strOccupationType506.ToString(),                  
                  o.IsReadOnly(_str_strOccupationType506), o.IsInvisible(_str_strOccupationType506), o.IsRequired(_str_strOccupationType506)); 
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
              _name = _str_strAddressEIDSS, _formname = _str_strAddressEIDSS, _type = "String",
              _get_func = o => o.strAddressEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strAddressEIDSS != newval) o.strAddressEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strAddressEIDSS != c.strAddressEIDSS || o.IsRIRPropChanged(_str_strAddressEIDSS, c)) 
                  m.Add(_str_strAddressEIDSS, o.ObjectIdent + _str_strAddressEIDSS, o.ObjectIdent2 + _str_strAddressEIDSS, o.ObjectIdent3 + _str_strAddressEIDSS, "String", 
                    o.strAddressEIDSS == null ? "" : o.strAddressEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strAddressEIDSS), o.IsInvisible(_str_strAddressEIDSS), o.IsRequired(_str_strAddressEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strAddress506, _formname = _str_strAddress506, _type = "String",
              _get_func = o => o.strAddress506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strAddress506 != newval) o.strAddress506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strAddress506 != c.strAddress506 || o.IsRIRPropChanged(_str_strAddress506, c)) 
                  m.Add(_str_strAddress506, o.ObjectIdent + _str_strAddress506, o.ObjectIdent2 + _str_strAddress506, o.ObjectIdent3 + _str_strAddress506, "String", 
                    o.strAddress506 == null ? "" : o.strAddress506.ToString(),                  
                  o.IsReadOnly(_str_strAddress506), o.IsInvisible(_str_strAddress506), o.IsRequired(_str_strAddress506)); 
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
              _name = _str_strAddrCodeEIDSS, _formname = _str_strAddrCodeEIDSS, _type = "String",
              _get_func = o => o.strAddrCodeEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strAddrCodeEIDSS != newval) o.strAddrCodeEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strAddrCodeEIDSS != c.strAddrCodeEIDSS || o.IsRIRPropChanged(_str_strAddrCodeEIDSS, c)) 
                  m.Add(_str_strAddrCodeEIDSS, o.ObjectIdent + _str_strAddrCodeEIDSS, o.ObjectIdent2 + _str_strAddrCodeEIDSS, o.ObjectIdent3 + _str_strAddrCodeEIDSS, "String", 
                    o.strAddrCodeEIDSS == null ? "" : o.strAddrCodeEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strAddrCodeEIDSS), o.IsInvisible(_str_strAddrCodeEIDSS), o.IsRequired(_str_strAddrCodeEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strAddrCode506, _formname = _str_strAddrCode506, _type = "String",
              _get_func = o => o.strAddrCode506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strAddrCode506 != newval) o.strAddrCode506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strAddrCode506 != c.strAddrCode506 || o.IsRIRPropChanged(_str_strAddrCode506, c)) 
                  m.Add(_str_strAddrCode506, o.ObjectIdent + _str_strAddrCode506, o.ObjectIdent2 + _str_strAddrCode506, o.ObjectIdent3 + _str_strAddrCode506, "String", 
                    o.strAddrCode506 == null ? "" : o.strAddrCode506.ToString(),                  
                  o.IsReadOnly(_str_strAddrCode506), o.IsInvisible(_str_strAddrCode506), o.IsRequired(_str_strAddrCode506)); 
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
              _name = _str_strRegionEIDSS, _formname = _str_strRegionEIDSS, _type = "String",
              _get_func = o => o.strRegionEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRegionEIDSS != newval) o.strRegionEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strRegionEIDSS != c.strRegionEIDSS || o.IsRIRPropChanged(_str_strRegionEIDSS, c)) 
                  m.Add(_str_strRegionEIDSS, o.ObjectIdent + _str_strRegionEIDSS, o.ObjectIdent2 + _str_strRegionEIDSS, o.ObjectIdent3 + _str_strRegionEIDSS, "String", 
                    o.strRegionEIDSS == null ? "" : o.strRegionEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strRegionEIDSS), o.IsInvisible(_str_strRegionEIDSS), o.IsRequired(_str_strRegionEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strRayonEIDSS, _formname = _str_strRayonEIDSS, _type = "String",
              _get_func = o => o.strRayonEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRayonEIDSS != newval) o.strRayonEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strRayonEIDSS != c.strRayonEIDSS || o.IsRIRPropChanged(_str_strRayonEIDSS, c)) 
                  m.Add(_str_strRayonEIDSS, o.ObjectIdent + _str_strRayonEIDSS, o.ObjectIdent2 + _str_strRayonEIDSS, o.ObjectIdent3 + _str_strRayonEIDSS, "String", 
                    o.strRayonEIDSS == null ? "" : o.strRayonEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strRayonEIDSS), o.IsInvisible(_str_strRayonEIDSS), o.IsRequired(_str_strRayonEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSettlementEIDSS, _formname = _str_strSettlementEIDSS, _type = "String",
              _get_func = o => o.strSettlementEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSettlementEIDSS != newval) o.strSettlementEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSettlementEIDSS != c.strSettlementEIDSS || o.IsRIRPropChanged(_str_strSettlementEIDSS, c)) 
                  m.Add(_str_strSettlementEIDSS, o.ObjectIdent + _str_strSettlementEIDSS, o.ObjectIdent2 + _str_strSettlementEIDSS, o.ObjectIdent3 + _str_strSettlementEIDSS, "String", 
                    o.strSettlementEIDSS == null ? "" : o.strSettlementEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strSettlementEIDSS), o.IsInvisible(_str_strSettlementEIDSS), o.IsRequired(_str_strSettlementEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strRegion506, _formname = _str_strRegion506, _type = "String",
              _get_func = o => o.strRegion506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRegion506 != newval) o.strRegion506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strRegion506 != c.strRegion506 || o.IsRIRPropChanged(_str_strRegion506, c)) 
                  m.Add(_str_strRegion506, o.ObjectIdent + _str_strRegion506, o.ObjectIdent2 + _str_strRegion506, o.ObjectIdent3 + _str_strRegion506, "String", 
                    o.strRegion506 == null ? "" : o.strRegion506.ToString(),                  
                  o.IsReadOnly(_str_strRegion506), o.IsInvisible(_str_strRegion506), o.IsRequired(_str_strRegion506)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strRayon506, _formname = _str_strRayon506, _type = "String",
              _get_func = o => o.strRayon506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strRayon506 != newval) o.strRayon506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strRayon506 != c.strRayon506 || o.IsRIRPropChanged(_str_strRayon506, c)) 
                  m.Add(_str_strRayon506, o.ObjectIdent + _str_strRayon506, o.ObjectIdent2 + _str_strRayon506, o.ObjectIdent3 + _str_strRayon506, "String", 
                    o.strRayon506 == null ? "" : o.strRayon506.ToString(),                  
                  o.IsReadOnly(_str_strRayon506), o.IsInvisible(_str_strRayon506), o.IsRequired(_str_strRayon506)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSettlement506, _formname = _str_strSettlement506, _type = "String",
              _get_func = o => o.strSettlement506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSettlement506 != newval) o.strSettlement506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSettlement506 != c.strSettlement506 || o.IsRIRPropChanged(_str_strSettlement506, c)) 
                  m.Add(_str_strSettlement506, o.ObjectIdent + _str_strSettlement506, o.ObjectIdent2 + _str_strSettlement506, o.ObjectIdent3 + _str_strSettlement506, "String", 
                    o.strSettlement506 == null ? "" : o.strSettlement506.ToString(),                  
                  o.IsReadOnly(_str_strSettlement506), o.IsInvisible(_str_strSettlement506), o.IsRequired(_str_strSettlement506)); 
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
              _name = _str_strTypeEIDSS, _formname = _str_strTypeEIDSS, _type = "String",
              _get_func = o => o.strTypeEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strTypeEIDSS != newval) o.strTypeEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strTypeEIDSS != c.strTypeEIDSS || o.IsRIRPropChanged(_str_strTypeEIDSS, c)) 
                  m.Add(_str_strTypeEIDSS, o.ObjectIdent + _str_strTypeEIDSS, o.ObjectIdent2 + _str_strTypeEIDSS, o.ObjectIdent3 + _str_strTypeEIDSS, "String", 
                    o.strTypeEIDSS == null ? "" : o.strTypeEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strTypeEIDSS), o.IsInvisible(_str_strTypeEIDSS), o.IsRequired(_str_strTypeEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strType506, _formname = _str_strType506, _type = "String",
              _get_func = o => o.strType506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strType506 != newval) o.strType506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strType506 != c.strType506 || o.IsRIRPropChanged(_str_strType506, c)) 
                  m.Add(_str_strType506, o.ObjectIdent + _str_strType506, o.ObjectIdent2 + _str_strType506, o.ObjectIdent3 + _str_strType506, "String", 
                    o.strType506 == null ? "" : o.strType506.ToString(),                  
                  o.IsReadOnly(_str_strType506), o.IsInvisible(_str_strType506), o.IsRequired(_str_strType506)); 
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
              _name = _str_strOutcomeEIDSS, _formname = _str_strOutcomeEIDSS, _type = "String",
              _get_func = o => o.strOutcomeEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOutcomeEIDSS != newval) o.strOutcomeEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strOutcomeEIDSS != c.strOutcomeEIDSS || o.IsRIRPropChanged(_str_strOutcomeEIDSS, c)) 
                  m.Add(_str_strOutcomeEIDSS, o.ObjectIdent + _str_strOutcomeEIDSS, o.ObjectIdent2 + _str_strOutcomeEIDSS, o.ObjectIdent3 + _str_strOutcomeEIDSS, "String", 
                    o.strOutcomeEIDSS == null ? "" : o.strOutcomeEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strOutcomeEIDSS), o.IsInvisible(_str_strOutcomeEIDSS), o.IsRequired(_str_strOutcomeEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strOutcome506, _formname = _str_strOutcome506, _type = "String",
              _get_func = o => o.strOutcome506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strOutcome506 != newval) o.strOutcome506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strOutcome506 != c.strOutcome506 || o.IsRIRPropChanged(_str_strOutcome506, c)) 
                  m.Add(_str_strOutcome506, o.ObjectIdent + _str_strOutcome506, o.ObjectIdent2 + _str_strOutcome506, o.ObjectIdent3 + _str_strOutcome506, "String", 
                    o.strOutcome506 == null ? "" : o.strOutcome506.ToString(),                  
                  o.IsReadOnly(_str_strOutcome506), o.IsInvisible(_str_strOutcome506), o.IsRequired(_str_strOutcome506)); 
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
              _name = _str_strSentByOfficeEIDSS, _formname = _str_strSentByOfficeEIDSS, _type = "String",
              _get_func = o => o.strSentByOfficeEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSentByOfficeEIDSS != newval) o.strSentByOfficeEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSentByOfficeEIDSS != c.strSentByOfficeEIDSS || o.IsRIRPropChanged(_str_strSentByOfficeEIDSS, c)) 
                  m.Add(_str_strSentByOfficeEIDSS, o.ObjectIdent + _str_strSentByOfficeEIDSS, o.ObjectIdent2 + _str_strSentByOfficeEIDSS, o.ObjectIdent3 + _str_strSentByOfficeEIDSS, "String", 
                    o.strSentByOfficeEIDSS == null ? "" : o.strSentByOfficeEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strSentByOfficeEIDSS), o.IsInvisible(_str_strSentByOfficeEIDSS), o.IsRequired(_str_strSentByOfficeEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strSentByOffice506, _formname = _str_strSentByOffice506, _type = "String",
              _get_func = o => o.strSentByOffice506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strSentByOffice506 != newval) o.strSentByOffice506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strSentByOffice506 != c.strSentByOffice506 || o.IsRIRPropChanged(_str_strSentByOffice506, c)) 
                  m.Add(_str_strSentByOffice506, o.ObjectIdent + _str_strSentByOffice506, o.ObjectIdent2 + _str_strSentByOffice506, o.ObjectIdent3 + _str_strSentByOffice506, "String", 
                    o.strSentByOffice506 == null ? "" : o.strSentByOffice506.ToString(),                  
                  o.IsReadOnly(_str_strSentByOffice506), o.IsInvisible(_str_strSentByOffice506), o.IsRequired(_str_strSentByOffice506)); 
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
              _name = _str_strEmployerNameEIDSS, _formname = _str_strEmployerNameEIDSS, _type = "String",
              _get_func = o => o.strEmployerNameEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strEmployerNameEIDSS != newval) o.strEmployerNameEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strEmployerNameEIDSS != c.strEmployerNameEIDSS || o.IsRIRPropChanged(_str_strEmployerNameEIDSS, c)) 
                  m.Add(_str_strEmployerNameEIDSS, o.ObjectIdent + _str_strEmployerNameEIDSS, o.ObjectIdent2 + _str_strEmployerNameEIDSS, o.ObjectIdent3 + _str_strEmployerNameEIDSS, "String", 
                    o.strEmployerNameEIDSS == null ? "" : o.strEmployerNameEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strEmployerNameEIDSS), o.IsInvisible(_str_strEmployerNameEIDSS), o.IsRequired(_str_strEmployerNameEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strEmployerName506, _formname = _str_strEmployerName506, _type = "String",
              _get_func = o => o.strEmployerName506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strEmployerName506 != newval) o.strEmployerName506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strEmployerName506 != c.strEmployerName506 || o.IsRIRPropChanged(_str_strEmployerName506, c)) 
                  m.Add(_str_strEmployerName506, o.ObjectIdent + _str_strEmployerName506, o.ObjectIdent2 + _str_strEmployerName506, o.ObjectIdent3 + _str_strEmployerName506, "String", 
                    o.strEmployerName506 == null ? "" : o.strEmployerName506.ToString(),                  
                  o.IsReadOnly(_str_strEmployerName506), o.IsInvisible(_str_strEmployerName506), o.IsRequired(_str_strEmployerName506)); 
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
              _name = _str_datSickEIDSS, _formname = _str_datSickEIDSS, _type = "DateTime?",
              _get_func = o => o.datSickEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datSickEIDSS != newval) o.datSickEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datSickEIDSS != c.datSickEIDSS || o.IsRIRPropChanged(_str_datSickEIDSS, c)) 
                  m.Add(_str_datSickEIDSS, o.ObjectIdent + _str_datSickEIDSS, o.ObjectIdent2 + _str_datSickEIDSS, o.ObjectIdent3 + _str_datSickEIDSS, "DateTime?", 
                    o.datSickEIDSS == null ? "" : o.datSickEIDSS.ToString(),                  
                  o.IsReadOnly(_str_datSickEIDSS), o.IsInvisible(_str_datSickEIDSS), o.IsRequired(_str_datSickEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datSick506, _formname = _str_datSick506, _type = "DateTime?",
              _get_func = o => o.datSick506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datSick506 != newval) o.datSick506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datSick506 != c.datSick506 || o.IsRIRPropChanged(_str_datSick506, c)) 
                  m.Add(_str_datSick506, o.ObjectIdent + _str_datSick506, o.ObjectIdent2 + _str_datSick506, o.ObjectIdent3 + _str_datSick506, "DateTime?", 
                    o.datSick506 == null ? "" : o.datSick506.ToString(),                  
                  o.IsReadOnly(_str_datSick506), o.IsInvisible(_str_datSick506), o.IsRequired(_str_datSick506)); 
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
              _name = _str_datDefineEIDSS, _formname = _str_datDefineEIDSS, _type = "DateTime?",
              _get_func = o => o.datDefineEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDefineEIDSS != newval) o.datDefineEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datDefineEIDSS != c.datDefineEIDSS || o.IsRIRPropChanged(_str_datDefineEIDSS, c)) 
                  m.Add(_str_datDefineEIDSS, o.ObjectIdent + _str_datDefineEIDSS, o.ObjectIdent2 + _str_datDefineEIDSS, o.ObjectIdent3 + _str_datDefineEIDSS, "DateTime?", 
                    o.datDefineEIDSS == null ? "" : o.datDefineEIDSS.ToString(),                  
                  o.IsReadOnly(_str_datDefineEIDSS), o.IsInvisible(_str_datDefineEIDSS), o.IsRequired(_str_datDefineEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDefine506, _formname = _str_datDefine506, _type = "DateTime?",
              _get_func = o => o.datDefine506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDefine506 != newval) o.datDefine506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datDefine506 != c.datDefine506 || o.IsRIRPropChanged(_str_datDefine506, c)) 
                  m.Add(_str_datDefine506, o.ObjectIdent + _str_datDefine506, o.ObjectIdent2 + _str_datDefine506, o.ObjectIdent3 + _str_datDefine506, "DateTime?", 
                    o.datDefine506 == null ? "" : o.datDefine506.ToString(),                  
                  o.IsReadOnly(_str_datDefine506), o.IsInvisible(_str_datDefine506), o.IsRequired(_str_datDefine506)); 
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
              _name = _str_datDeathEIDSS, _formname = _str_datDeathEIDSS, _type = "DateTime?",
              _get_func = o => o.datDeathEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDeathEIDSS != newval) o.datDeathEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datDeathEIDSS != c.datDeathEIDSS || o.IsRIRPropChanged(_str_datDeathEIDSS, c)) 
                  m.Add(_str_datDeathEIDSS, o.ObjectIdent + _str_datDeathEIDSS, o.ObjectIdent2 + _str_datDeathEIDSS, o.ObjectIdent3 + _str_datDeathEIDSS, "DateTime?", 
                    o.datDeathEIDSS == null ? "" : o.datDeathEIDSS.ToString(),                  
                  o.IsReadOnly(_str_datDeathEIDSS), o.IsInvisible(_str_datDeathEIDSS), o.IsRequired(_str_datDeathEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datDeath506, _formname = _str_datDeath506, _type = "DateTime?",
              _get_func = o => o.datDeath506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datDeath506 != newval) o.datDeath506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datDeath506 != c.datDeath506 || o.IsRIRPropChanged(_str_datDeath506, c)) 
                  m.Add(_str_datDeath506, o.ObjectIdent + _str_datDeath506, o.ObjectIdent2 + _str_datDeath506, o.ObjectIdent3 + _str_datDeath506, "DateTime?", 
                    o.datDeath506 == null ? "" : o.datDeath506.ToString(),                  
                  o.IsReadOnly(_str_datDeath506), o.IsInvisible(_str_datDeath506), o.IsRequired(_str_datDeath506)); 
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
              _name = _str_datRecordEIDSS, _formname = _str_datRecordEIDSS, _type = "DateTime?",
              _get_func = o => o.datRecordEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datRecordEIDSS != newval) o.datRecordEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datRecordEIDSS != c.datRecordEIDSS || o.IsRIRPropChanged(_str_datRecordEIDSS, c)) 
                  m.Add(_str_datRecordEIDSS, o.ObjectIdent + _str_datRecordEIDSS, o.ObjectIdent2 + _str_datRecordEIDSS, o.ObjectIdent3 + _str_datRecordEIDSS, "DateTime?", 
                    o.datRecordEIDSS == null ? "" : o.datRecordEIDSS.ToString(),                  
                  o.IsReadOnly(_str_datRecordEIDSS), o.IsInvisible(_str_datRecordEIDSS), o.IsRequired(_str_datRecordEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datRecord506, _formname = _str_datRecord506, _type = "DateTime?",
              _get_func = o => o.datRecord506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datRecord506 != newval) o.datRecord506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datRecord506 != c.datRecord506 || o.IsRIRPropChanged(_str_datRecord506, c)) 
                  m.Add(_str_datRecord506, o.ObjectIdent + _str_datRecord506, o.ObjectIdent2 + _str_datRecord506, o.ObjectIdent3 + _str_datRecord506, "DateTime?", 
                    o.datRecord506 == null ? "" : o.datRecord506.ToString(),                  
                  o.IsReadOnly(_str_datRecord506), o.IsInvisible(_str_datRecord506), o.IsRequired(_str_datRecord506)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datEnteredEIDSS, _formname = _str_datEnteredEIDSS, _type = "DateTime?",
              _get_func = o => o.datEnteredEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datEnteredEIDSS != newval) o.datEnteredEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datEnteredEIDSS != c.datEnteredEIDSS || o.IsRIRPropChanged(_str_datEnteredEIDSS, c)) 
                  m.Add(_str_datEnteredEIDSS, o.ObjectIdent + _str_datEnteredEIDSS, o.ObjectIdent2 + _str_datEnteredEIDSS, o.ObjectIdent3 + _str_datEnteredEIDSS, "DateTime?", 
                    o.datEnteredEIDSS == null ? "" : o.datEnteredEIDSS.ToString(),                  
                  o.IsReadOnly(_str_datEnteredEIDSS), o.IsInvisible(_str_datEnteredEIDSS), o.IsRequired(_str_datEnteredEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_datEntered506, _formname = _str_datEntered506, _type = "DateTime?",
              _get_func = o => o.datEntered506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseDateTimeNullable(val); if (o.datEntered506 != newval) o.datEntered506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.datEntered506 != c.datEntered506 || o.IsRIRPropChanged(_str_datEntered506, c)) 
                  m.Add(_str_datEntered506, o.ObjectIdent + _str_datEntered506, o.ObjectIdent2 + _str_datEntered506, o.ObjectIdent3 + _str_datEntered506, "DateTime?", 
                    o.datEntered506 == null ? "" : o.datEntered506.ToString(),                  
                  o.IsReadOnly(_str_datEntered506), o.IsInvisible(_str_datEntered506), o.IsRequired(_str_datEntered506)); 
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
              _name = _str_strComplicaEIDSS, _formname = _str_strComplicaEIDSS, _type = "String",
              _get_func = o => o.strComplicaEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strComplicaEIDSS != newval) o.strComplicaEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strComplicaEIDSS != c.strComplicaEIDSS || o.IsRIRPropChanged(_str_strComplicaEIDSS, c)) 
                  m.Add(_str_strComplicaEIDSS, o.ObjectIdent + _str_strComplicaEIDSS, o.ObjectIdent2 + _str_strComplicaEIDSS, o.ObjectIdent3 + _str_strComplicaEIDSS, "String", 
                    o.strComplicaEIDSS == null ? "" : o.strComplicaEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strComplicaEIDSS), o.IsInvisible(_str_strComplicaEIDSS), o.IsRequired(_str_strComplicaEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strComplica506, _formname = _str_strComplica506, _type = "String",
              _get_func = o => o.strComplica506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strComplica506 != newval) o.strComplica506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strComplica506 != c.strComplica506 || o.IsRIRPropChanged(_str_strComplica506, c)) 
                  m.Add(_str_strComplica506, o.ObjectIdent + _str_strComplica506, o.ObjectIdent2 + _str_strComplica506, o.ObjectIdent3 + _str_strComplica506, "String", 
                    o.strComplica506 == null ? "" : o.strComplica506.ToString(),                  
                  o.IsReadOnly(_str_strComplica506), o.IsInvisible(_str_strComplica506), o.IsRequired(_str_strComplica506)); 
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
              _name = _str_strMarietalEIDSS, _formname = _str_strMarietalEIDSS, _type = "String",
              _get_func = o => o.strMarietalEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strMarietalEIDSS != newval) o.strMarietalEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strMarietalEIDSS != c.strMarietalEIDSS || o.IsRIRPropChanged(_str_strMarietalEIDSS, c)) 
                  m.Add(_str_strMarietalEIDSS, o.ObjectIdent + _str_strMarietalEIDSS, o.ObjectIdent2 + _str_strMarietalEIDSS, o.ObjectIdent3 + _str_strMarietalEIDSS, "String", 
                    o.strMarietalEIDSS == null ? "" : o.strMarietalEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strMarietalEIDSS), o.IsInvisible(_str_strMarietalEIDSS), o.IsRequired(_str_strMarietalEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strMarietal506, _formname = _str_strMarietal506, _type = "String",
              _get_func = o => o.strMarietal506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strMarietal506 != newval) o.strMarietal506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strMarietal506 != c.strMarietal506 || o.IsRIRPropChanged(_str_strMarietal506, c)) 
                  m.Add(_str_strMarietal506, o.ObjectIdent + _str_strMarietal506, o.ObjectIdent2 + _str_strMarietal506, o.ObjectIdent3 + _str_strMarietal506, "String", 
                    o.strMarietal506 == null ? "" : o.strMarietal506.ToString(),                  
                  o.IsReadOnly(_str_strMarietal506), o.IsInvisible(_str_strMarietal506), o.IsRequired(_str_strMarietal506)); 
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
              _name = _str_strForeignEIDSS, _formname = _str_strForeignEIDSS, _type = "String",
              _get_func = o => o.strForeignEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strForeignEIDSS != newval) o.strForeignEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strForeignEIDSS != c.strForeignEIDSS || o.IsRIRPropChanged(_str_strForeignEIDSS, c)) 
                  m.Add(_str_strForeignEIDSS, o.ObjectIdent + _str_strForeignEIDSS, o.ObjectIdent2 + _str_strForeignEIDSS, o.ObjectIdent3 + _str_strForeignEIDSS, "String", 
                    o.strForeignEIDSS == null ? "" : o.strForeignEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strForeignEIDSS), o.IsInvisible(_str_strForeignEIDSS), o.IsRequired(_str_strForeignEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strForeign506, _formname = _str_strForeign506, _type = "String",
              _get_func = o => o.strForeign506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strForeign506 != newval) o.strForeign506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strForeign506 != c.strForeign506 || o.IsRIRPropChanged(_str_strForeign506, c)) 
                  m.Add(_str_strForeign506, o.ObjectIdent + _str_strForeign506, o.ObjectIdent2 + _str_strForeign506, o.ObjectIdent3 + _str_strForeign506, "String", 
                    o.strForeign506 == null ? "" : o.strForeign506.ToString(),                  
                  o.IsReadOnly(_str_strForeign506), o.IsInvisible(_str_strForeign506), o.IsRequired(_str_strForeign506)); 
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
              _name = _str_strMunicipalityEIDSS, _formname = _str_strMunicipalityEIDSS, _type = "String",
              _get_func = o => o.strMunicipalityEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strMunicipalityEIDSS != newval) o.strMunicipalityEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strMunicipalityEIDSS != c.strMunicipalityEIDSS || o.IsRIRPropChanged(_str_strMunicipalityEIDSS, c)) 
                  m.Add(_str_strMunicipalityEIDSS, o.ObjectIdent + _str_strMunicipalityEIDSS, o.ObjectIdent2 + _str_strMunicipalityEIDSS, o.ObjectIdent3 + _str_strMunicipalityEIDSS, "String", 
                    o.strMunicipalityEIDSS == null ? "" : o.strMunicipalityEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strMunicipalityEIDSS), o.IsInvisible(_str_strMunicipalityEIDSS), o.IsRequired(_str_strMunicipalityEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strMunicipality506, _formname = _str_strMunicipality506, _type = "String",
              _get_func = o => o.strMunicipality506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strMunicipality506 != newval) o.strMunicipality506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strMunicipality506 != c.strMunicipality506 || o.IsRIRPropChanged(_str_strMunicipality506, c)) 
                  m.Add(_str_strMunicipality506, o.ObjectIdent + _str_strMunicipality506, o.ObjectIdent2 + _str_strMunicipality506, o.ObjectIdent3 + _str_strMunicipality506, "String", 
                    o.strMunicipality506 == null ? "" : o.strMunicipality506.ToString(),                  
                  o.IsReadOnly(_str_strMunicipality506), o.IsInvisible(_str_strMunicipality506), o.IsRequired(_str_strMunicipality506)); 
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
              _name = _str_strHospitalizationEIDSS, _formname = _str_strHospitalizationEIDSS, _type = "String",
              _get_func = o => o.strHospitalizationEIDSS,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHospitalizationEIDSS != newval) o.strHospitalizationEIDSS = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strHospitalizationEIDSS != c.strHospitalizationEIDSS || o.IsRIRPropChanged(_str_strHospitalizationEIDSS, c)) 
                  m.Add(_str_strHospitalizationEIDSS, o.ObjectIdent + _str_strHospitalizationEIDSS, o.ObjectIdent2 + _str_strHospitalizationEIDSS, o.ObjectIdent3 + _str_strHospitalizationEIDSS, "String", 
                    o.strHospitalizationEIDSS == null ? "" : o.strHospitalizationEIDSS.ToString(),                  
                  o.IsReadOnly(_str_strHospitalizationEIDSS), o.IsInvisible(_str_strHospitalizationEIDSS), o.IsRequired(_str_strHospitalizationEIDSS)); 
                  }
              }, 
                  
            new field_info {
              _name = _str_strHospitalization506, _formname = _str_strHospitalization506, _type = "String",
              _get_func = o => o.strHospitalization506,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseString(val); if (o.strHospitalization506 != newval) o.strHospitalization506 = newval; },
              _compare_func = (o, c, m, g) => {
                if (o.strHospitalization506 != c.strHospitalization506 || o.IsRIRPropChanged(_str_strHospitalization506, c)) 
                  m.Add(_str_strHospitalization506, o.ObjectIdent + _str_strHospitalization506, o.ObjectIdent2 + _str_strHospitalization506, o.ObjectIdent3 + _str_strHospitalization506, "String", 
                    o.strHospitalization506 == null ? "" : o.strHospitalization506.ToString(),                  
                  o.IsReadOnly(_str_strHospitalization506), o.IsInvisible(_str_strHospitalization506), o.IsRequired(_str_strHospitalization506)); 
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
        
            new field_info {
              _name = _str_Item, _formname = _str_Item, _type = "Upload506Item",
              _get_func = o => o.Item,
              _set_func = (o, val) => { var newval = o.Item; if (o.Item != newval) o.Item = newval; },
              _compare_func = (o, c, m, g) => {
               }
              }, 
        
            new field_info {
              _name = _str_Resolved, _formname = _str_Resolved, _type = "bool",
              _get_func = o => o.Resolved,
              _set_func = (o, val) => { var newval = ParsingHelper.ParseBoolean(val); if (o.Resolved != newval) o.Resolved = newval; },
              _compare_func = (o, c, m, g) => {
              
                if (o.Resolved != c.Resolved || o.IsRIRPropChanged(_str_Resolved, c)) {
                  m.Add(_str_Resolved, o.ObjectIdent + _str_Resolved, o.ObjectIdent2 + _str_Resolved, o.ObjectIdent3 + _str_Resolved,  "bool", 
                    o.Resolved == null ? "" : o.Resolved.ToString(),                  
                    o.IsReadOnly(_str_Resolved), o.IsInvisible(_str_Resolved), o.IsRequired(_str_Resolved));
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
            Upload506Duplicate obj = (Upload506Duplicate)o;
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
    
          [LocalizedDisplayName(_str_Item)]
        public Upload506Item Item
        {
            get { return m_Item; }
            set { if (m_Item != value) { m_Item = value; OnPropertyChanged(_str_Item); } }
        }
        private Upload506Item m_Item;
        
          [LocalizedDisplayName(_str_Resolved)]
        public bool Resolved
        {
            get { return m_Resolved; }
            set { if (m_Resolved != value) { m_Resolved = value; OnPropertyChanged(_str_Resolved); } }
        }
        private bool m_Resolved;
        
        protected CacheScope m_CS;
        protected Accessor _getAccessor() { return Accessor.Instance(m_CS); }
        private IObjectPermissions m_permissions = null;
        internal IObjectPermissions _permissions { get { return m_permissions; } set { m_permissions = value; } }
        internal string m_ObjectName = "Upload506Duplicate";

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
            var ret = base.Clone() as Upload506Duplicate;
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
            var ret = base.Clone() as Upload506Duplicate;
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
        public Upload506Duplicate CloneWithSetup()
        {
            using (DbManagerProxy manager = DbManagerFactory.Factory.Create(ModelUserContext.Instance))
            {
                return CloneWithSetup(manager) as Upload506Duplicate;
            }
        }
        #endregion

        #region IObject implementation
        public object Key { get { return idfCase; } }
        public string KeyName { get { return "idfCase"; } }
        public object KeyLookup { get { return idfCase; } }
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

        private bool IsRIRPropChanged(string fld, Upload506Duplicate c)
        {
            return IsReadOnly(fld) != c.IsReadOnly(fld) || IsInvisible(fld) != c.IsInvisible(fld) || IsRequired(fld) != c._isRequired(m_isRequired, fld);
        }
        private bool IsLookupContentChanged(DbManagerProxy manager, string fld, Upload506Duplicate c)
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
        

      

        public Upload506Duplicate()
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
            PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Upload506Duplicate_PropertyChanged);
        }
        public void _RevokeMainHandler()
        {
            PropertyChanged -= new System.ComponentModel.PropertyChangedEventHandler(Upload506Duplicate_PropertyChanged);
        }
        private void Upload506Duplicate_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            (sender as Upload506Duplicate).Changed(e.PropertyName);
            
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
            Upload506Duplicate obj = this;
            
        }
        private void _DeletedExtenders()
        {
            Upload506Duplicate obj = this;
            
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
            
            return ReadOnly || new Func<Upload506Duplicate, bool>(c => true)(this);
                
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


        internal Dictionary<string, Func<Upload506Duplicate, bool>> m_isRequired;
        private bool _isRequired(Dictionary<string, Func<Upload506Duplicate, bool>> isRequiredDict, string name)
        {
            if (isRequiredDict != null && isRequiredDict.ContainsKey(name))
                return isRequiredDict[name](this);
            return false;
        }
        
        public void AddRequired(string name, Func<Upload506Duplicate, bool> func)
        {
            if (m_isRequired == null) 
                m_isRequired = new Dictionary<string, Func<Upload506Duplicate, bool>>();
            if (!m_isRequired.ContainsKey(name))
                m_isRequired.Add(name, func);
        }
    
    internal Dictionary<string, Func<Upload506Duplicate, bool>> m_isHiddenPersonalData;
    private bool _isHiddenPersonalData(string name)
    {
      if (m_isHiddenPersonalData != null && m_isHiddenPersonalData.ContainsKey(name))
        return m_isHiddenPersonalData[name](this);
      return false;
    }

    public void AddHiddenPersonalData(string name, Func<Upload506Duplicate, bool> func)
    {
      if (m_isHiddenPersonalData == null)
        m_isHiddenPersonalData = new Dictionary<string, Func<Upload506Duplicate, bool>>();
      if (!m_isHiddenPersonalData.ContainsKey(name))
        m_isHiddenPersonalData.Add(name, func);
    }
  
        #region IDisposable Members
        partial void Disposed();
        private bool bIsDisposed;
        protected bool bNeedLookupRemove;
        ~Upload506Duplicate()
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
        : DataAccessor<Upload506Duplicate>
            , IObjectAccessor
            , IObjectMeta
            , IObjectValidator
            
            , IObjectCreator
            , IObjectCreator<Upload506Duplicate>
            
            , IObjectSelectDetailList
            , IObjectPost
                
        {
            #region IObjectAccessor
            public string KeyName { get { return "idfCase"; } }
            #endregion
        
            public delegate void on_action(Upload506Duplicate obj);
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
                    , (Int64?)ident
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                        
                    , null
                    , null
                    ).Cast<IObject>().ToList();
            }
            
        
            public virtual List<Upload506Duplicate> SelectList(DbManagerProxy manager
                , Int64? idfsUpload506
                , String DISEASE
                , String HN
                , String NAME
                , Int32? SEX
                , Int32? YEAR
                , Int32? MONTH
                , Int32? DAY
                , Int32? RACE
                , Int32? OCCUPAT
                , String ADDRESS
                , String ADDRCODE
                , String PROVINCE
                , Int32? TYPE
                , Int32? RESULT
                , String HSERV
                , String SCHOOL
                , DateTime? DATESICK
                , DateTime? DATEDEFINE
                , DateTime? DATEDEATH
                , DateTime? DATERECORD
                , String COMPLICA
                , Int32? MARIETAL
                , Int32? RACE1
                , Int32? METROPOL
                , Int32? HOSPITAL
                )
            {
                return _SelectList(manager
                    , idfsUpload506
                    , DISEASE
                    , HN
                    , NAME
                    , SEX
                    , YEAR
                    , MONTH
                    , DAY
                    , RACE
                    , OCCUPAT
                    , ADDRESS
                    , ADDRCODE
                    , PROVINCE
                    , TYPE
                    , RESULT
                    , HSERV
                    , SCHOOL
                    , DATESICK
                    , DATEDEFINE
                    , DATEDEATH
                    , DATERECORD
                    , COMPLICA
                    , MARIETAL
                    , RACE1
                    , METROPOL
                    , HOSPITAL
                    , delegate(Upload506Duplicate obj)
                        {
                        }
                    , delegate(Upload506Duplicate obj)
                        {
                        }
                    );
            }

            

            public List<Upload506Duplicate> _SelectList(DbManagerProxy manager
                , Int64? idfsUpload506
                , String DISEASE
                , String HN
                , String NAME
                , Int32? SEX
                , Int32? YEAR
                , Int32? MONTH
                , Int32? DAY
                , Int32? RACE
                , Int32? OCCUPAT
                , String ADDRESS
                , String ADDRCODE
                , String PROVINCE
                , Int32? TYPE
                , Int32? RESULT
                , String HSERV
                , String SCHOOL
                , DateTime? DATESICK
                , DateTime? DATEDEFINE
                , DateTime? DATEDEATH
                , DateTime? DATERECORD
                , String COMPLICA
                , Int32? MARIETAL
                , Int32? RACE1
                , Int32? METROPOL
                , Int32? HOSPITAL
                , on_action loading, on_action loaded
                )
            {
                var ret = _SelectListInternal(manager
                    , idfsUpload506
                    , DISEASE
                    , HN
                    , NAME
                    , SEX
                    , YEAR
                    , MONTH
                    , DAY
                    , RACE
                    , OCCUPAT
                    , ADDRESS
                    , ADDRCODE
                    , PROVINCE
                    , TYPE
                    , RESULT
                    , HSERV
                    , SCHOOL
                    , DATESICK
                    , DATEDEFINE
                    , DATEDEATH
                    , DATERECORD
                    , COMPLICA
                    , MARIETAL
                    , RACE1
                    , METROPOL
                    , HOSPITAL
                    , loading
                    , loaded
                    );
                  
                  return ret;
            }
      
            
            public virtual List<Upload506Duplicate> _SelectListInternal(DbManagerProxy manager
                , Int64? idfsUpload506
                , String DISEASE
                , String HN
                , String NAME
                , Int32? SEX
                , Int32? YEAR
                , Int32? MONTH
                , Int32? DAY
                , Int32? RACE
                , Int32? OCCUPAT
                , String ADDRESS
                , String ADDRCODE
                , String PROVINCE
                , Int32? TYPE
                , Int32? RESULT
                , String HSERV
                , String SCHOOL
                , DateTime? DATESICK
                , DateTime? DATEDEFINE
                , DateTime? DATEDEATH
                , DateTime? DATERECORD
                , String COMPLICA
                , Int32? MARIETAL
                , Int32? RACE1
                , Int32? METROPOL
                , Int32? HOSPITAL
                , on_action loading, on_action loaded
                )
            {
                Upload506Duplicate _obj = null;
                try
                {
                    MapResultSet[] sets = new MapResultSet[1];
                    List<Upload506Duplicate> objs = new List<Upload506Duplicate>();
                    sets[0] = new MapResultSet(typeof(Upload506Duplicate), objs);
                    
                    manager
                        .SetSpCommand("spUpload506Duplicate_SelectDetail"
                            , manager.Parameter("@idfsUpload506", idfsUpload506)
                            , manager.Parameter("@DISEASE", DISEASE)
                            , manager.Parameter("@HN", HN)
                            , manager.Parameter("@NAME", NAME)
                            , manager.Parameter("@SEX", SEX)
                            , manager.Parameter("@YEAR", YEAR)
                            , manager.Parameter("@MONTH", MONTH)
                            , manager.Parameter("@DAY", DAY)
                            , manager.Parameter("@RACE", RACE)
                            , manager.Parameter("@OCCUPAT", OCCUPAT)
                            , manager.Parameter("@ADDRESS", ADDRESS)
                            , manager.Parameter("@ADDRCODE", ADDRCODE)
                            , manager.Parameter("@PROVINCE", PROVINCE)
                            , manager.Parameter("@TYPE", TYPE)
                            , manager.Parameter("@RESULT", RESULT)
                            , manager.Parameter("@HSERV", HSERV)
                            , manager.Parameter("@SCHOOL", SCHOOL)
                            , manager.Parameter("@DATESICK", DATESICK)
                            , manager.Parameter("@DATEDEFINE", DATEDEFINE)
                            , manager.Parameter("@DATEDEATH", DATEDEATH)
                            , manager.Parameter("@DATERECORD", DATERECORD)
                            , manager.Parameter("@COMPLICA", COMPLICA)
                            , manager.Parameter("@MARIETAL", MARIETAL)
                            , manager.Parameter("@RACE1", RACE1)
                            , manager.Parameter("@METROPOL", METROPOL)
                            , manager.Parameter("@HOSPITAL", HOSPITAL)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
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
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null, null
                        );
                }
            }
            public virtual Upload506Duplicate SelectDetailT(DbManagerProxy manager, object ident, int? HACode = null)
            {
                if (ident == null)
                {
                    return CreateNewT(manager, null, HACode);
                }
                else
                {
                    return _SelectByKey(manager
                        , (Int64?)ident
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null
                            
                        , null, null
                        );
                }
            }

            
            public virtual Upload506Duplicate SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                , String DISEASE
                , String HN
                , String NAME
                , Int32? SEX
                , Int32? YEAR
                , Int32? MONTH
                , Int32? DAY
                , Int32? RACE
                , Int32? OCCUPAT
                , String ADDRESS
                , String ADDRCODE
                , String PROVINCE
                , Int32? TYPE
                , Int32? RESULT
                , String HSERV
                , String SCHOOL
                , DateTime? DATESICK
                , DateTime? DATEDEFINE
                , DateTime? DATEDEATH
                , DateTime? DATERECORD
                , String COMPLICA
                , Int32? MARIETAL
                , Int32? RACE1
                , Int32? METROPOL
                , Int32? HOSPITAL
                )
            {
                return _SelectByKey(manager
                    , idfsUpload506
                    , DISEASE
                    , HN
                    , NAME
                    , SEX
                    , YEAR
                    , MONTH
                    , DAY
                    , RACE
                    , OCCUPAT
                    , ADDRESS
                    , ADDRCODE
                    , PROVINCE
                    , TYPE
                    , RESULT
                    , HSERV
                    , SCHOOL
                    , DATESICK
                    , DATEDEFINE
                    , DATEDEATH
                    , DATERECORD
                    , COMPLICA
                    , MARIETAL
                    , RACE1
                    , METROPOL
                    , HOSPITAL
                    , null, null
                    );
            }
            

            private Upload506Duplicate _SelectByKey(DbManagerProxy manager
                , Int64? idfsUpload506
                , String DISEASE
                , String HN
                , String NAME
                , Int32? SEX
                , Int32? YEAR
                , Int32? MONTH
                , Int32? DAY
                , Int32? RACE
                , Int32? OCCUPAT
                , String ADDRESS
                , String ADDRCODE
                , String PROVINCE
                , Int32? TYPE
                , Int32? RESULT
                , String HSERV
                , String SCHOOL
                , DateTime? DATESICK
                , DateTime? DATEDEFINE
                , DateTime? DATEDEATH
                , DateTime? DATERECORD
                , String COMPLICA
                , Int32? MARIETAL
                , Int32? RACE1
                , Int32? METROPOL
                , Int32? HOSPITAL
                , on_action loading, on_action loaded
                )
            {
                return _SelectByKeyInternal(manager
                    , idfsUpload506
                    , DISEASE
                    , HN
                    , NAME
                    , SEX
                    , YEAR
                    , MONTH
                    , DAY
                    , RACE
                    , OCCUPAT
                    , ADDRESS
                    , ADDRCODE
                    , PROVINCE
                    , TYPE
                    , RESULT
                    , HSERV
                    , SCHOOL
                    , DATESICK
                    , DATEDEFINE
                    , DATEDEATH
                    , DATERECORD
                    , COMPLICA
                    , MARIETAL
                    , RACE1
                    , METROPOL
                    , HOSPITAL
                    , loading, loaded
                    )
                    
                    ;
            }
      
            
            protected virtual Upload506Duplicate _SelectByKeyInternal(DbManagerProxy manager
                , Int64? idfsUpload506
                , String DISEASE
                , String HN
                , String NAME
                , Int32? SEX
                , Int32? YEAR
                , Int32? MONTH
                , Int32? DAY
                , Int32? RACE
                , Int32? OCCUPAT
                , String ADDRESS
                , String ADDRCODE
                , String PROVINCE
                , Int32? TYPE
                , Int32? RESULT
                , String HSERV
                , String SCHOOL
                , DateTime? DATESICK
                , DateTime? DATEDEFINE
                , DateTime? DATEDEATH
                , DateTime? DATERECORD
                , String COMPLICA
                , Int32? MARIETAL
                , Int32? RACE1
                , Int32? METROPOL
                , Int32? HOSPITAL
                , on_action loading, on_action loaded
                )
            {
            
                MapResultSet[] sets = new MapResultSet[1];
                List<Upload506Duplicate> objs = new List<Upload506Duplicate>();
                sets[0] = new MapResultSet(typeof(Upload506Duplicate), objs);
                Upload506Duplicate obj = null;
                try
                {
                    manager
                        .SetSpCommand("spUpload506Duplicate_SelectDetail"
                            , manager.Parameter("@idfsUpload506", idfsUpload506)
                            , manager.Parameter("@DISEASE", DISEASE)
                            , manager.Parameter("@HN", HN)
                            , manager.Parameter("@NAME", NAME)
                            , manager.Parameter("@SEX", SEX)
                            , manager.Parameter("@YEAR", YEAR)
                            , manager.Parameter("@MONTH", MONTH)
                            , manager.Parameter("@DAY", DAY)
                            , manager.Parameter("@RACE", RACE)
                            , manager.Parameter("@OCCUPAT", OCCUPAT)
                            , manager.Parameter("@ADDRESS", ADDRESS)
                            , manager.Parameter("@ADDRCODE", ADDRCODE)
                            , manager.Parameter("@PROVINCE", PROVINCE)
                            , manager.Parameter("@TYPE", TYPE)
                            , manager.Parameter("@RESULT", RESULT)
                            , manager.Parameter("@HSERV", HSERV)
                            , manager.Parameter("@SCHOOL", SCHOOL)
                            , manager.Parameter("@DATESICK", DATESICK)
                            , manager.Parameter("@DATEDEFINE", DATEDEFINE)
                            , manager.Parameter("@DATEDEATH", DATEDEATH)
                            , manager.Parameter("@DATERECORD", DATERECORD)
                            , manager.Parameter("@COMPLICA", COMPLICA)
                            , manager.Parameter("@MARIETAL", MARIETAL)
                            , manager.Parameter("@RACE1", RACE1)
                            , manager.Parameter("@METROPOL", METROPOL)
                            , manager.Parameter("@HOSPITAL", HOSPITAL)
                            , manager.Parameter("@LangID", ModelUserContext.CurrentLanguage)
                            
                            )
                        .ExecuteResultSet(sets);

                    if (objs.Count == 0)
                        return null;

                    obj = objs[0];
                    obj.m_CS = m_CS;
                    
                  
                    if (loading != null)
                        loading(obj);
                    _SetupLoad(manager, obj);
                    

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
    
        
        
            internal void _SetupLoad(DbManagerProxy manager, Upload506Duplicate obj, bool bCloning = false)
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
            
            internal void _SetPermitions(IObjectPermissions permissions, Upload506Duplicate obj)
            {
                if (obj != null)
                {
                    obj._permissions = permissions;
                    if (obj._permissions != null)
                    {
                    
                    }
                }
            }

    

            private Upload506Duplicate _CreateNew(DbManagerProxy manager, IObject Parent, int? HACode, on_action creating, on_action created, bool isFake = false)
            {
                Upload506Duplicate obj = null;
                try
                {
                    obj = Upload506Duplicate.CreateInstance();
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

            
            public Upload506Duplicate CreateNewT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public IObject CreateNew(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null);
            }
            public Upload506Duplicate CreateFakeT(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            public IObject CreateFake(DbManagerProxy manager, IObject Parent, int? HACode = null)
            {
                return _CreateNew(manager, Parent, HACode, null, null, true);
            }
            
            public Upload506Duplicate CreateWithParamsT(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            public IObject CreateWithParams(DbManagerProxy manager, IObject Parent, List<object> pars)
            {
                return _CreateNew(manager, Parent, null, null, null);
            }
            
            private void _SetupChildHandlers(Upload506Duplicate obj, object newobj)
            {
                
            }
            
            private void _SetupHandlers(Upload506Duplicate obj)
            {
                
            }
    

            internal void _LoadLookups(DbManagerProxy manager, Upload506Duplicate obj)
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
            
      
            protected ValidationModelException ChainsValidate(Upload506Duplicate obj)
            {
                
                return null;
            }
            protected bool ChainsValidate(Upload506Duplicate obj, bool bRethrowException)
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
                return Validate(manager, obj as Upload506Duplicate, bPostValidation, bChangeValidation, bDeepValidation, bRethrowException);
            }
            public bool Validate(DbManagerProxy manager, Upload506Duplicate obj, bool bPostValidation, bool bChangeValidation, bool bDeepValidation, bool bRethrowException = false)
            {
                if (!ChainsValidate(obj, bRethrowException))
                    return false;
                    
                
                return true;
            }
           
    
            private void _SetupRequired(Upload506Duplicate obj)
            {
            
            }
    
    private void _SetupPersonalDataRestrictions(Upload506Duplicate obj)
    {
    
    
    }
  
            #region IObjectMeta
            public int? MaxSize(string name) { return Meta.Sizes.ContainsKey(name) ? (int?)Meta.Sizes[name] : null; }
            public bool RequiredByField(string name, IObject obj) { return Meta.RequiredByField.ContainsKey(name) ? Meta.RequiredByField[name](obj as Upload506Duplicate) : false; }
            public bool RequiredByProperty(string name, IObject obj) { return Meta.RequiredByProperty.ContainsKey(name) ? Meta.RequiredByProperty[name](obj as Upload506Duplicate) : false; }
            public List<SearchPanelMetaItem> SearchPanelMeta { get { return Meta.SearchPanelMeta; } }
            public List<GridMetaItem> GridMeta { get { return Meta.GridMeta; } }
            public List<ActionMetaItem> Actions { get { return Meta.Actions; } }
            public string DetailPanel { get { return "Upload506DuplicateDetail"; } }
            public string HelpIdWin { get { return ""; } }
            public string HelpIdWeb { get { return ""; } }
            public string HelpIdHh { get { return ""; } }
            public string SqlSortOrder { get { return Meta.sqlSortOrder; } }
            #endregion
    
        }

        
        #region Meta
        public static class Meta
        {
            public static string spSelect = "spUpload506Duplicate_SelectDetail";
            public static string spCount = "";
            public static string spPost = "";
            public static string spInsert = "";
            public static string spUpdate = "";
            public static string spDelete = "";
            public static string spCanDelete = "";
            public static string sqlSortOrder = "";
            public static Dictionary<string, int> Sizes = new Dictionary<string, int>();
            public static Dictionary<string, Func<Upload506Duplicate, bool>> RequiredByField = new Dictionary<string, Func<Upload506Duplicate, bool>>();
            public static Dictionary<string, Func<Upload506Duplicate, bool>> RequiredByProperty = new Dictionary<string, Func<Upload506Duplicate, bool>>();
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
                
                Sizes.Add(_str_strCaseID, 255);
                Sizes.Add(_str_DISEASE, 255);
                Sizes.Add(_str_strTentativeDiagnosisEIDSS, 255);
                Sizes.Add(_str_strTentativeDiagnosis506, 255);
                Sizes.Add(_str_HN, 255);
                Sizes.Add(_str_strLocalIdentifierEIDSS, 255);
                Sizes.Add(_str_strLocalIdentifier506, 255);
                Sizes.Add(_str_NAME, 255);
                Sizes.Add(_str_strPatientNameEIDSS, 255);
                Sizes.Add(_str_strPatientName506, 255);
                Sizes.Add(_str_strHumanGenderEIDSS, 255);
                Sizes.Add(_str_strHumanGender506, 255);
                Sizes.Add(_str_strHumanAgeTypeEIDSS, 255);
                Sizes.Add(_str_strHumanAgeType506, 255);
                Sizes.Add(_str_strNationalityEIDSS, 255);
                Sizes.Add(_str_strNationality506, 255);
                Sizes.Add(_str_strOccupationTypeEIDSS, 255);
                Sizes.Add(_str_strOccupationType506, 255);
                Sizes.Add(_str_ADDRESS, 255);
                Sizes.Add(_str_strAddressEIDSS, 255);
                Sizes.Add(_str_strAddress506, 255);
                Sizes.Add(_str_ADDRCODE, 255);
                Sizes.Add(_str_strAddrCodeEIDSS, 255);
                Sizes.Add(_str_strAddrCode506, 255);
                Sizes.Add(_str_PROVINCE, 255);
                Sizes.Add(_str_strRegionEIDSS, 255);
                Sizes.Add(_str_strRayonEIDSS, 255);
                Sizes.Add(_str_strSettlementEIDSS, 255);
                Sizes.Add(_str_strRegion506, 255);
                Sizes.Add(_str_strRayon506, 255);
                Sizes.Add(_str_strSettlement506, 255);
                Sizes.Add(_str_strTypeEIDSS, 255);
                Sizes.Add(_str_strType506, 255);
                Sizes.Add(_str_strOutcomeEIDSS, 255);
                Sizes.Add(_str_strOutcome506, 255);
                Sizes.Add(_str_HSERV, 255);
                Sizes.Add(_str_strSentByOfficeEIDSS, 255);
                Sizes.Add(_str_strSentByOffice506, 255);
                Sizes.Add(_str_SCHOOL, 255);
                Sizes.Add(_str_strEmployerNameEIDSS, 255);
                Sizes.Add(_str_strEmployerName506, 255);
                Sizes.Add(_str_COMPLICA, 255);
                Sizes.Add(_str_strComplicaEIDSS, 255);
                Sizes.Add(_str_strComplica506, 255);
                Sizes.Add(_str_strMarietalEIDSS, 255);
                Sizes.Add(_str_strMarietal506, 255);
                Sizes.Add(_str_strForeignEIDSS, 255);
                Sizes.Add(_str_strForeign506, 255);
                Sizes.Add(_str_strMunicipalityEIDSS, 255);
                Sizes.Add(_str_strMunicipality506, 255);
                Sizes.Add(_str_strHospitalizationEIDSS, 255);
                Sizes.Add(_str_strHospitalization506, 255);
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
	