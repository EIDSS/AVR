using bv.model.BLToolkit;

namespace eidss.model.Schema
{

	public partial class Upload506Duplicate
	{
		public partial class Accessor
		{
			public Upload506Duplicate SelectByItem(DbManagerProxy manager, Upload506Item checkItem)
			{
				var ret = SelectByKey(manager
					, checkItem.idfsUpload506
					, checkItem.DISEASE
					, checkItem.HN
                    , checkItem.NAME
					, checkItem.SEX
					, checkItem.YEAR
					, checkItem.MONTH
					, checkItem.DAY
					, checkItem.RACE
					, checkItem.OCCUPAT
					, checkItem.ADDRESS
					, checkItem.ADDRCODE
					, checkItem.PROVINCE
					, checkItem.TYPE
					, checkItem.RESULT
					, checkItem.HSERV
					, checkItem.SCHOOL
					, checkItem.DATESICK
					, checkItem.DATEDEFINE
					, checkItem.DATEDEATH
					, checkItem.DATERECORD
					, checkItem.COMPLICA
					, checkItem.MARIETAL
					, checkItem.RACE1
					, checkItem.METROPOL
					, checkItem.HOSPITAL
					);
				if (ret != null)
				{
					ret.Item = checkItem;
				}
				return ret;
			}

		}

	}
}
