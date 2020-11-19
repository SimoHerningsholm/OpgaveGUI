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
    public class DepartmentDataHandler
    {
        //Deklerere properties der skal anvendes. En connectionstring, en forbindelse der skal bruge connectionstring, samt en liste over returobjeker
        private string connectionString;
        private SqlConnection conn;
        private List<Department> departmentList;
        public DepartmentDataHandler()
        {
            //Instanciere properties der skal anvendes
            connectionString = "Data Source=localhost;Initial Catalog=AdventureWorks2016CTP3;User ID=SA;Password=Test142536";
            conn = new SqlConnection(connectionString);
            departmentList = new List<Department>();
        }
        public async Task<List<Department>> GetDepartments()
        {
            //Laver en sqlcommand der modtager forbindelsen og som får query der vælger alt fra Opgave4View
            SqlCommand cmd = new SqlCommand("AllDepartmentsView", conn);
            try
            {
                //Åbner forbindelse og sætter modelobjekter ind i listen mens der er data til modeller at læse. Til sidst lukkes der for forbindelsen.
                await conn.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Department tempDep = new Department();
                    tempDep.Id = (int)reader["Id"];
                    tempDep.Name = (string)reader["Name"];
                    tempDep.CompanyId = (int)reader["Company"];
                    departmentList.Add(tempDep);
                }
                conn.Close();
            }
            catch (Exception e) //Er der gået noget galt laves en exception
            {
                departmentList = null;
            }
            //Returnere modellisten uanset hvordan læsning af data er gået
            return departmentList;
        }
        public async Task<Department> GetDepartment(int departmentId)
        {
            //Laver en sqlcommand der modtager forbindelsen og som får query der vælger alt fra Opgave4View
            SqlCommand cmd = new SqlCommand("GetDepartmentView", conn);
            cmd.Parameters.AddWithValue("@departmentId", departmentId);
            try
            {
                //Åbner forbindelse og sætter modelobjekter ind i listen mens der er data til modeller at læse. Til sidst lukkes der for forbindelsen.
                await conn.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                await reader.ReadAsync();
                Department dep = new Department();
                dep.Id = (int)reader["Id"];
                dep.Name = (string)reader["Name"];
                dep.CompanyId = (int)reader["Company"];
                conn.Close();
                return dep;
            }    
            catch (Exception e) //Er der gået noget galt laves en exception
            {
                departmentList = null;
            }
            //Returnere modellisten uanset hvordan læsning af data er gået
            return null;
        }
        public async Task<bool> CreateDepartment(Department inDep)
        {
            //Sætter returvariabel der fortæller om metode er eksekveret uden problemer, til som udgangspunkt at være true
            SqlCommand cmd = new SqlCommand("CreateDepartment", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //værdier associeres med parametre for den ovenstående query  
            cmd.Parameters.AddWithValue("@Name", inDep.Name);
            cmd.Parameters.AddWithValue("@Company", inDep.CompanyId);
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
            catch
            {
                //Lukker forbindelsen og returner at sql ikke er eksekveret successfuldt
                return false;
            }
        }
    }
}
