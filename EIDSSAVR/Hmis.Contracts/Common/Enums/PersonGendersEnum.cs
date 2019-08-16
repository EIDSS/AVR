using System;
using System.Runtime.Serialization;

namespace Hmis.Contracts.Common.Enums
{
    [Flags]
    [Serializable]
    [DataContract]
    public enum PersonGendersEnum
    {
        [EnumMember]
        Unknown,

        [EnumMember]
        Male,

        [EnumMember]
        Female,
    }
}