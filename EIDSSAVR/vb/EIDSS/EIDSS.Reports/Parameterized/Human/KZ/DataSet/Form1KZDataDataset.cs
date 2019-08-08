using EIDSS.Reports.BaseControls.BaseDataSetTableAdapters;
using System.Linq;
using System.Data.SqlClient;
namespace EIDSS.Reports.Parameterized.Human.KZ.DataSet
{

    public partial class Form1KZDataDataset
    {
    }
}
namespace EIDSS.Reports.Parameterized.Human.KZ.DataSet.Form1KZDataDatasetTableAdapters
{
    public partial class spRepHumForm1KZDataTableAdapter
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
