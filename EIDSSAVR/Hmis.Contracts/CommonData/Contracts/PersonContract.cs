using System;
using System.Runtime.Serialization;
using Hmis.Contracts.Common.Enums;
using Hmis.Contracts.CommonData.Enums;

namespace Hmis.Contracts.CommonData.Contracts
{
    [Serializable]
    [DataContract]
    public class PersonContract
    {
        public PersonContract()
        {
        }

        [DataMember]
        public Guid ID { get; set; }

        [DataMember]
        public String PersonalID { get; set; }

        [DataMember]
        public String PasportID { get; set; }

        [DataMember]
        public String FirstName { get; set; }

        [DataMember]
        public String LastName { get; set; }

        [DataMember]
        public DateTime? BirthDate { get; set; }

        [DataMember]
        public DateTime? RejectDate { get; set; }

        [DataMember]
        public PersonGendersEnum Gender { get; set; }

        [DataMember]
        public String GenderCode { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public int AppDataID { get; set; }

        [DataMember]
        public string AddressSourceID { get; set; }

        [DataMember]
        public String AddressID { get; set; }

        [DataMember]
        public String Address { get; set; }

        [DataMember]
        public long? RegionID { get; set; }

        [DataMember]
        public String Region { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsAlive { get; set; }

        [DataMember]
        public bool IsFound { get; set; }

        [DataMember]
        public bool CraError { get; set; }

        [DataMember]
        public bool InsError { get; set; }

        [DataMember]
        public byte[] Photo { get; set; }

        [DataMember]
        public String Tel { get; set; }

        [DataMember]
        public int? Status { get; set; }

        [DataMember]
        public int? Condition { get; set; }

        [DataMember]
        public String MiddleName { get; set; }

        [DataMember]
        public String BirthPlace { get; set; }

        [DataMember]
        public int BirthPlaceCountryID { get; set; }

        [DataMember]
        public String BirthPlaceCountry{ get; set; }

        [DataMember]
        public string BirthPlaceRaionID { get; set; }

        [DataMember]
        public String BirthPlaceRaion { get; set; }

        [DataMember]
        public String CitizenshipName { get; set; }

        [DataMember]
        public String CitizenshipCode { get; set; }

        [DataMember]
        public String DoubleCitizenshipName { get; set; }

        [DataMember]
        public String DoubleCitizenshipCode { get; set; }

        //[DataMember]
        //public List<PersonInsuranceContract> Insurances { get; set; }

        [DataMember]
        public bool HaveActiveCitizenship { get; set; }

        [DataMember]
        public bool? IsBeneficiary { get; set; }

        [DataMember]
        public PersonDataSourcesEnum PersonDataSource { get; set; }

     
    }
}