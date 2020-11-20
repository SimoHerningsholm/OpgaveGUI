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
            //sætter connectionstring og laver en connection med connectionstring
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Simon\\Source\\Repos\\OpgaveGUIAfsluttende\\OpgaveGUIAfsluttende\\AfsluttendeDB.mdf;Integrated Security=True";
            conn = new SqlConnection(connectionString);
        }
        public async Task<DataView> ViewEmployeesWithJoinedData()
        {
            //Instanciere en sqlcommand som modtager en query og en forbindelse den skal anvende
            SqlCommand cmd = new SqlCommand("SELECT * FROM ViewAllEmployesWithJoinedData", conn);
            //Instanciere en sqldatadapter der modtager en command, og som skal anvende en datatable
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ViewAllEmployesWithJoinedData");
            sda.Fill(dt);
            //returnere dataview der er lavet med datatable
            return dt.DefaultView;
        }
        public async Task<DataView> ViewEmployeeWithJoinedData(int employeeId)
        {
            //Instanciere en sqlcommand som modtager en query og en forbindelse den skal anvende
            SqlCommand cmd = new SqlCommand("ViewEmployeeWithJoinedData", conn);
            //Sætter at det skal være en storedprocedure og associere med et id der skal indgå i eksekveringen
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", employeeId);
            //Instanciere en sqldatadapter der modtager en command, og som skal anvende en datatable
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ViewEmployeeWithJoinedData");
            sda.Fill(dt);
            //returnere dataview der er lavet med datatable
            return dt.DefaultView;
        }
    }
}
