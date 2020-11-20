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
        //Deklerere properties der skal anvendes. En connectionstring, en forbindelse der skal bruge connectionstring
        private string connectionString;
        private SqlConnection conn;
        public AddressDataHandler()
        {
            //Instanciere properties der skal anvendes
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Simon\\Source\\Repos\\OpgaveGUIAfsluttende\\OpgaveGUIAfsluttende\\AfsluttendeDB.mdf;Integrated Security=True";
            conn = new SqlConnection(connectionString);
        }
        public async Task<int> CreateAddress(Address inAddress)
        {
            //Laver en sqlcommand der modtager forbindelsen og som får storedprocedure
            SqlCommand cmd = new SqlCommand("CreateAddress", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //værdier associeres med parametre for den ovenstående query  
            cmd.Parameters.AddWithValue("@Street", inAddress.Street);
            cmd.Parameters.AddWithValue("@Zipcode", inAddress.ZipCode);
            try
            {
                //åbner forbindelse til databasen
                await conn.OpenAsync();
                //modtager id på ny adresse
                int newAddressId = (int)await cmd.ExecuteScalarAsync();
                //Eksekvere SQL op imod databasen, og hvis der er tale om et nyt id returneres det nye id
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
            //Laver en sqlcommand der modtager forbindelsen og som får storedprocedure
            SqlCommand cmd = new SqlCommand("GetAddressFromId", conn);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                //Åbner forbindelse og laver modelobjekt der returneres tilbage hvis process er successfuld
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
        public async Task<Address> getAddressFromZipCodeAndStreet(int zipCode, string street)
        {
            //Laver en sqlcommand der modtager forbindelsen og som får storedprocedure
            SqlCommand cmd = new SqlCommand("GetAddressFromZipCodeAndStreet", conn);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Zipcode", zipCode);
                cmd.Parameters.AddWithValue("@Street", street);
                //Åbner forbindelse og laver modelobjekt der returneres tilbage hvis process er successfuld
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
        public async Task<bool> updateAddress(Address inAddress)
        {
            //Laver en sqlcommand der modtager forbindelsen og som får storedprocedure
            SqlCommand cmd = new SqlCommand("UpdateAddress", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //værdier associeres med parametre for den ovenstående query
            cmd.Parameters.AddWithValue("@Id", inAddress.Id);
            cmd.Parameters.AddWithValue("@Street", inAddress.Street);
            cmd.Parameters.AddWithValue("@Zipcode", inAddress.ZipCode);
            try
            {
                //åbner forbindelse til databasen
                await conn.OpenAsync();
                //Eksekvere SQL op imod databasen
                if (await cmd.ExecuteNonQueryAsync() == 1)
                {
                    //Lukker forbindelsen og returner at sql er eksekveret successfuldt
                    conn.Close();
                    return true;
                }
                else
                {
                    //Lukker forbindelsen og returner at sql ikke er eksekveret successfuldt
                    conn.Close();
                    return false;
                }
            }
            catch (Exception e)
            {
                //Lukker forbindelsen og returner at sql ikke er eksekveret successfuldt
                return false;
            }
        }
    }
}
