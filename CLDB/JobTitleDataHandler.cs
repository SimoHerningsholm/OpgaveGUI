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
    public class JobTitleDataHandler
    {
        //Deklerere liste af testemployees
        private string connectionString;
        private SqlConnection conn;
        private List<JobTitle> jobTitleList;
        public JobTitleDataHandler()
        {
            //Generere en liste af employee objekter der kan simulere database data i frontend
            connectionString = "Data Source=D0004;Initial Catalog=OpgaveDBAfsluttendeDB;User ID=sa;Password=Test142536";
            conn = new SqlConnection(connectionString);
            jobTitleList = new List<JobTitle>();
        }
        public async Task<List<JobTitle>> getJobTitles()
        {
            //Laver en sqlcommand der modtager forbindelsen og som får query der vælger alt fra Opgave4View
            SqlCommand cmd = new SqlCommand("SELECT * FROM AllJobTitleView", conn);
            try
            {
                //Åbner forbindelse og sætter modelobjekter ind i listen mens der er data til modeller at læse. Til sidst lukkes der for forbindelsen.
                await conn.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    JobTitle tempTitle = new JobTitle();
                    tempTitle.Id = (int)reader["Id"];
                    tempTitle.Name = (string)reader["Name"];
                    jobTitleList.Add(tempTitle);
                }
                conn.Close();
            }
            catch (Exception e) //Er der gået noget galt laves en exception
            {
                jobTitleList = null;
            }
            //Returnere modellisten uanset hvordan læsning af data er gået
            return jobTitleList;
        }
    }
}
