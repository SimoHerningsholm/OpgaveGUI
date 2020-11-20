using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CLModels;
using System.Threading;
using System.Threading.Tasks;

namespace CLDB
{
    public class JoinedViewsDataHandler
    {
        //Deklerere liste af testemployees
        private string connectionString;
        private SqlConnection conn;
        public JoinedViewsDataHandler()
        {
            //Generere en liste af employee objekter der kan simulere database data i frontend
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Simon\\Source\\Repos\\OpgaveGUIAfsluttende\\OpgaveGUIAfsluttende\\AfsluttendeDB.mdf;Integrated Security=True";
            conn = new SqlConnection(connectionString);
        }
        public async Task<DataView> ViewEmployeesWithJoinedData()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM ViewAllEmployesWithJoinedData", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ViewAllEmployesWithJoinedData");
            sda.Fill(dt);
            return dt.DefaultView;
        }
    }
}
