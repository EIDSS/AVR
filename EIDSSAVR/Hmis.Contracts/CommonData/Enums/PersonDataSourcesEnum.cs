using System.Runtime.Serialization;

namespace Hmis.Contracts.CommonData.Enums
{
    [DataContract]
    public enum PersonDataSourcesEnum
    {
        [EnumMember]
        CRA,

        [EnumMember]
        LocalDB
    }
}
