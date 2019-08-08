using System;
using System.Collections.Generic;
using eidss.model.Reports.Common;

namespace eidss.model.Reports.GG
{
    [Serializable]
    public class MultipleGGCounterModel : MultipleCounterModel
    {
        public MultipleGGCounterModel()
        {
        }
        public MultipleGGCounterModel(string[] checkedItems)
            : base(checkedItems)
        {
        }

        public override List<SelectListItemSurrogate> LoadItemList()
        {
            return FilterHelper.GetWebCounterGGList(1);
        }
    }
}
