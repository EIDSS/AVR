using bv.common.Core;
using eidss.model.Core;
using eidss.model.Enums;
using eidss.model.Reports.Common;
using System;
using System.Collections.Generic;

namespace eidss.model.Reports.TH
{
	[Serializable]
	public class OnePageSituationTHModel : BaseModel
	{
		public OnePageSituationTHModel()
		{
			CanWorkWithArchive = false;
			DiagnosisModel = new DiagnosisModel();
			DiagnosisModel.SetDiagnoses(DiagnosisList);
		}

		public OnePageSituationTHModel(string language, long? diagnosis, string diagnosisName, long? zone)
			: base(language, false)
		{
			idfsDiagnosis = diagnosis;
			DiagnosisModel = new DiagnosisModel();
			DiagnosisModel.SetDiagnoses(DiagnosisList);
			DiagnosisModel.DiagnosisId = diagnosis;
			DiagnosisName = diagnosisName;
			idfsZone = zone;

		}

		public DiagnosisModel DiagnosisModel { get; set; }
		[LocalizedDisplayName("DiagnosisName")]
		public long? idfsDiagnosis { get; set; }
		public string DiagnosisName { get; set; }
		public List<SelectListItemSurrogate> DiagnosisList
		{
			get
			{
				return FilterHelper.GetDiagnosisList(Localizer.CurrentCultureLanguageID, (int)HACode.Human,
					DiagnosisUsingTypeEnum.StandardCase);
			}
		}
		public long? idfsZone { get; set; }
		public List<SelectListItemSurrogate> ZoneList
		{
			get
			{
				return FilterHelper.GetThaiZonesList(true);
			}
		}
	}
}
