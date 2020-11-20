using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using CLModels;

namespace CLDB
{
    public class AddressDataHandler
    {
        //Deklerere properties der skal anvendes. En connectionstring, en forbindelse der skal bruge connectionstring, samt en liste over returobjeker
        private string connectionString;
        private SqlConnection conn;
        public AddressDataHandler()
        {
            //Instanciere properties der skal anvendes
            connectionString = "Data Source=D0004;Initial Catalog=OpgaveDBAfsluttendeDB;User ID=sa;Password=Test142536";
            conn = new SqlConnection(connectionString);
        }
        public async Task<int> CreateAddress(Address inAddress)
        {
            //Sætter returvariabel der fortæller om metode er eksekveret uden problemer, til som udgangspunkt at være true
            SqlCommand cmd = new SqlCommand("CreateAddress", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //værdier associeres med parametre for den ovenstående query  
            cmd.Parameters.AddWithValue("@Street", inAddress.Street);
            cmd.Parameters.AddWithValue("@Zipcode", inAddress.ZipCode);
            try
            {
                //åbner forbindelse til databasen
                await conn.OpenAsync();
                int newAddressId = (int)await cmd.ExecuteScalarAsync();
                //Eksekvere SQL op imod databasen
                if (newAddressId > 0)
                {
                    //Lukker forbindelsen og returner at sql er eksekveret successfuldt
                    conn.Close();
                    return newAddressId;
                }
                else
                {
                    //Lukker forbindelsen og returner at sql ikke er eksekveret successfuldt
                    conn.Close();
                    return 0;
                }
            }
            catch(Exception e)
            {
                //Lukker forbindelsen og returner at sql ikke er eksekveret successfuldt
                return 0;
            }
        }
        public async Task<Address> getAddressFromId(int id)
        {
            //Laver en sqlcommand der modtager forbindelsen og som får query der vælger alt fra Opgave4View
            SqlCommand cmd = new SqlCommand("GetAddressFromId", conn);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                //Åbner forbindelse og sætter modelobjekter ind i listen mens der er data til modeller at læse. Til sidst lukkes der for forbindelsen.
                await conn.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                await reader.ReadAsync();
                Address newAddr = new Address();
                newAddr.Street = (string)reader["Street"];
                newAddr.ZipCode = (int)reader["Zipcode"];
                conn.Close();
                return newAddr;
            }
            catch (Exception e) //Er der gået noget galt laves en exception
            {
                return null;
            }
            //Returnere modellisten uanset hvordan læsning af data er gået
        }

    }
}
