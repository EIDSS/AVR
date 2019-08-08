

using System.Threading;
using bv.common.Configuration;
using bv.common.Core;
using bv.winclient.Core;

namespace EIDSS.FlexibleForms.Helpers.ReportHelper.Tree
{
    public abstract class FlexNodeVisitor
    {
        public abstract void Visit(FlexNode node);


        public static string CurrentFontName
        {
            get
            {
                if (Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == Localizer.lngGe || Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == Localizer.lngAr)
                    return BaseSettings.GGSystemFontName;
                else if (Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == Localizer.lngThai)
                    return BaseSettings.THSystemFontName;
                else
                 return BaseSettings.SystemFontName;
            }
        }
    }
}