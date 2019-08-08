using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.TH.DataSets {
    
    
    public partial class OnePageSituationTHDataset {
        partial class OnePageSituationDataTable{
        }
    }
}

namespace EIDSS.Reports.Parameterized.Human.TH.DataSets.OnePageSituationTHDatasetTableAdapters
{

    public partial class OnePageSituationTableAdapter
    {
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