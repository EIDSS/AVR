using System;
using System.Collections.Generic;
using System.Text;
using eidss.model.Enums;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.GG
{
    [Serializable]
    public class ComparativeGGSeveralYearsSurrogateModel : BaseModel
    {
        public ComparativeGGSeveralYearsSurrogateModel()
        {
            CounterIds = new string[0];
        }

        public ComparativeGGSeveralYearsSurrogateModel
            (string language, int year1, int year2,
                string[] counters, string[] diagnosesIds, string diagnosesName,
                long? regionId, long? rayonId, string regionName, string rayonName,
                long? organizationId, List<PersonalDataGroup> forbiddenGroups, bool useArchive)
            : base(language, useArchive)
        {
            CounterIds = counters ?? new string[0];
            DiagnosesIds = diagnosesIds;
            DiagnosesName = diagnosesName;

            Year1 = year1;
            Year2 = year2;
            RegionId = regionId;
            RayonId = rayonId;
            RegionName = regionName;
            RayonName = rayonName;

            OrganizationId = organizationId;
            ForbiddenGroups = forbiddenGroups;
        }

        public string[] CounterIds { get; set; }

        public int Year1 { get; set; }

        public int Year2 { get; set; }

        public string[] DiagnosesIds { get; set; }

        public string DiagnosesName { get; set; }

        public long? RegionId { get; set; }

        public long? RayonId { get; set; }

        public string RegionName { get; set; }

        public string RayonName { get; set; }

        public override string ToString()
        {
            var counter = new StringBuilder();
            if (CounterIds != null)
            {
                foreach (string item in CounterIds)
                {
                    counter.AppendFormat("{0},", item);
                }
            }
            string result = string.Format("{0}, Counters='{1}', Region='{2}', Rayon='{3}', Diagnoses={4}, Year1={5}, Year2={6}",
                base.ToString(), counter, RegionName, RayonName, DiagnosesName, Year1, Year2);
            return result;
        }
    }
}