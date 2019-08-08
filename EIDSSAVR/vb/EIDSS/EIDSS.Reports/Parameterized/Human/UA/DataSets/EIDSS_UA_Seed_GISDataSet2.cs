using EIDSS.Reports.BaseControls.BaseDataSetTableAdapters;
using System.Data.SqlClient;
using System.Linq;
using System;

namespace EIDSS.Reports.Parameterized.Human.UA.DataSets
{
    partial class UAReportForm2DataSet
    {
    }
}

namespace EIDSS.Reports.Parameterized.Human.UA.DataSets.EIDSS_UA_Seed_GISDataSet2TableAdapters
{


    public partial class USP_Rpt_Hum_Form2_Table1TableAdapter
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

    public partial class USP_Rpt_Hum_Form2_Table2TableAdapter
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

    public partial class USP_Rpt_Hum_Form2_Table3TableAdapter
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