using System.Data.SqlClient;
using System.Linq;

namespace EIDSS.Reports.Parameterized.Human.GG.DataSet
{
    public partial class ComparativeSeveralYearsGGDataSet
    {
    }
}

namespace EIDSS.Reports.Parameterized.Human.GG.DataSet.ComparativeSeveralYearsGGDataSetTableAdapters
{
    public partial class ComparativeSeveralYearsTableAdapter
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