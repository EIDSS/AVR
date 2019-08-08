using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets
{
    public partial class VetIndicatorsSummaryDataSet
    {
    }
}

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets.VetIndicatorsSummaryDataSetTableAdapters
{
    public partial class VetIndicatorsSummaryTableAdapter
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