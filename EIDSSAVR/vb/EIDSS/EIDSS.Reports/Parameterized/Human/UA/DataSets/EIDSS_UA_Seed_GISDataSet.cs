using EIDSS.Reports.BaseControls.BaseDataSetTableAdapters;
using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.UA.DataSets
{
    partial class UAReportForm1DataSet
    {
    }
}

namespace EIDSS.Reports.Parameterized.Human.UA.DataSets.EIDSS_UA_Seed_GISDataSetTableAdapters {
    
    
    public partial class USP_Rpt_Hum_Form1TableAdapter {

        internal int CommandTimeout
        {
            get { return CommandCollection.Select(c => c.CommandTimeout).FirstOrDefault(); }
            set
            {
                foreach (SqlCommand command in CommandCollection)
                {
                    command.CommandTimeout = value;
                }
            }
        }
    }
}
namespace EIDSS.Reports.Parameterized.Human.UA.DataSets
{


    partial class EIDSS_UA_Seed_GISDataSet
    {
    }
}
