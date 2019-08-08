using System;
using eidss.model.Core;
using eidss.model.Resources;

namespace eidss.model.Reports.Common
{
    [Serializable]
    public class FromYearToYearModel : BaseModel
    {
        public int MinYearFrom { get; private set; }
        public int MaxYearFrom { get; private set; }
        public int MinYearTo { get; private set; }
        public int MaxYearTo { get; private set; }

        public void SetYearsIntervalFrom(int minYear = 0, int maxYear = 0, int defaultYear = 0)
        {
            if (minYear > 0) MinYearFrom = minYear;
            if (maxYear > 0) MaxYearFrom = maxYear;
            if (defaultYear > 0) Year1 = defaultYear;
        }

        public void SetYearsIntervalTo(int minYear = 0, int maxYear = 0, int defaultYear = 0)
        {
            if (minYear > 0) MinYearTo = minYear;
            if (maxYear > 0) MaxYearTo = maxYear;
            if (defaultYear > 0) Year2 = defaultYear;
        }

        public bool YearsCaptionsSpecial { get; set; }
        private bool m_IsYear1GreaterYear2;
        public bool IsYear1GreaterYear2
        {
            get{return m_IsYear1GreaterYear2;}
            set
            {
                m_IsYear1GreaterYear2 = value;
                if (m_IsYear1GreaterYear2)
                {
                    Year1 = DateTime.Now.Year;
                    Year2 = Year1 - 1;                   
                }
            }
        }

        public FromYearToYearModel()
        {
            Year2 = DateTime.Now.Year;
            Year1 = Year2 - 1;
            MinYearFrom = MinYearTo = 2000;
            MaxYearFrom = MaxYearTo = DateTime.Today.Year;
            ValidationScript = "paperForm.ValidateYears";
        }

        public string GetYearFromCaption()
        {
            if (!string.IsNullOrEmpty(Year1Caption))
                return EidssFields.Get(Year1Caption);
            return YearsCaptionsSpecial ? EidssFields.Get("strFromYear") : EidssFields.Get("Year1", "Year1");
        }

        public string GetYearToCaption()
        {
            if (!string.IsNullOrEmpty(Year2Caption))
                return EidssFields.Get(Year2Caption);
            return YearsCaptionsSpecial ? EidssFields.Get("strToYear") : EidssFields.Get("Year2", "Year2");
        }

        [LocalizedDisplayName("Year1")]
        public int Year1 { get; set; }

        [LocalizedDisplayName("Year2")]
        public int Year2 { get; set; }

        public string ValidationMessage { get; set; }
        public string ValidationScript { get; set; }
        public string Year1Caption { get; set; }
        public string Year2Caption { get; set; }

        public override string ToString()
        {
            return base.ToString() + string.Format(" Year1={0}, Year2={1}", Year1, Year2);
        }
    }
}