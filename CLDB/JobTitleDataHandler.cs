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
            //sætter connectionstring og laver en connection med connectionstring
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Simon\\Source\\Repos\\OpgaveGUIAfsluttende\\OpgaveGUIAfsluttende\\AfsluttendeDB.mdf;Integrated Security=True";
            conn = new SqlConnection(connectionString);
            //Instanciere en liste af jobtitle modeller der kan sendes tilbage
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
        public async Task<JobTitle> GetJobTitle(int jobTitleId)
        {
            //Laver en sqlcommand der modtager forbindelsen og som får storedprocedure
            SqlCommand cmd = new SqlCommand("GetJobTitleFromId", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", jobTitleId);
            try
            {
                //Åbner forbindelse og sætter modelobjekter ind i listen mens der er data til modeller at læse. Til sidst lukkes der for forbindelsen.
                await conn.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                await reader.ReadAsync();
                JobTitle job = new JobTitle();
                job.Id = (int)reader["Id"];
                job.Name = (string)reader["Name"];
                conn.Close();
                return job;
            }
            catch (Exception e) //Er der gået noget galt laves en exception
            {
                return null;
            }
        }
    }
}
