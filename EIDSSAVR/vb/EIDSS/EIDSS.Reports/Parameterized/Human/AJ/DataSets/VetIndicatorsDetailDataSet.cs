using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets
{
    public partial class VetIndicatorsDetailDataSet
    {
    }
}

namespace EIDSS.Reports.Parameterized.Human.AJ.DataSets.VetIndicatorsDetailDataSetTableAdapters
{
    public partial class VetIndicatorsDetailTableAdapter

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