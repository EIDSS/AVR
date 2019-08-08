using eidss.model.Enums;
using eidss.model.Reports.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eidss.model.Reports.KZ
{
    [Serializable]
    public class Form1KZSurrogateModel : BaseYearModel
    {
        public Form1KZSurrogateModel()
        {
        }

         public Form1KZSurrogateModel
            (string language, int? formType, int year, long? employeeId, int? startMonth, int? endMonth, 
            long? regionId, long? rayonId, string regionName, string rayonName,
            List<PersonalDataGroup> forbiddenGroups, bool useArchive)
            : base(language, year, useArchive)
        {
            FormType = formType;
            StartMonth = startMonth;
            EndMonth = endMonth;
            EmployeeId = employeeId;
            RegionId = regionId;
            RayonId = rayonId;
            RegionName = regionName;
            RayonName = rayonName;
            ForbiddenGroups = forbiddenGroups;
        }

        public long? EmployeeId { get; set; }

        public int? StartMonth { get; set; }

        public int? EndMonth { get; set; }

        public long? RegionId { get; set; }

        public long? RayonId { get; set; }

        public string RegionName { get; set; }

        public string RayonName { get; set; }

        public int? FormType { get; set; }

        public static explicit operator BaseDateModel(Form1KZSurrogateModel model)
        {
            var result = new BaseDateModel(model.Language, model.Year, model.StartMonth, model.EndMonth, model.UseArchive)
                {
                    ExportFormat = model.ExportFormat,
                    IsOpenInNewWindow = model.IsOpenInNewWindow,
                    OrganizationId = model.OrganizationId,
                    ForbiddenGroups = model.ForbiddenGroups,
                    UserId = model.UserId,
                    IsArchiveMode = model.IsArchiveMode,
                };

            return result;
        }
   }
}
