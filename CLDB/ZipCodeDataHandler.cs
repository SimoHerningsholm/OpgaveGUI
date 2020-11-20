using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using CLModels;
using System.Threading;
using System.Threading.Tasks;

namespace CLDB
{
    public class ZipCodeDataHandler
    {
        //Deklerere properties der skal anvendes. En connectionstring, en forbindelse der skal bruge connectionstring, samt en liste over returobjeker
        private string connectionString;
        private SqlConnection conn;
        private List<ZipCode> zipCodeList;
        public ZipCodeDataHandler()
        {
            //Instanciere properties der skal anvendes
            connectionString = "Data Source=D0004;Initial Catalog=OpgaveDBAfsluttendeDB;User ID=sa;Password=Test142536";
            conn = new SqlConnection(connectionString);
            zipCodeList = new List<ZipCode>();
        }
        public async Task<List<ZipCode>> getZipCodes()
        {
            //Laver en sqlcommand der modtager forbindelsen og som får query der vælger alt fra Opgave4View
            SqlCommand cmd = new SqlCommand("SELECT * FROM AllZipCodes", conn);
            try
            {
                //Åbner forbindelse og sætter modelobjekter ind i listen mens der er data til modeller at læse. Til sidst lukkes der for forbindelsen.
                await conn.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    ZipCode tempZip = new ZipCode();
                    tempZip.Zipcode = (int)reader["Zipcode"];
                    tempZip.City = (string)reader["City"];
                    zipCodeList.Add(tempZip);
                }
                conn.Close();
            }
            catch (Exception e) //Er der gået noget galt laves en exception
            {
                zipCodeList = null;
            }
            //Returnere modellisten uanset hvordan læsning af data er gået
            return zipCodeList;
        }
    }
}
