﻿using System;
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
    public class CompanyDataHandler
    {
        //Deklerere properties der skal anvendes. En connectionstring, en forbindelse der skal bruge connectionstring, samt en liste over returobjeker
        private string connectionString;
        private SqlConnection conn;
        private List<Company> companyList;
        public CompanyDataHandler()
        {
            //Instanciere properties der skal anvendes
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Simon\\Source\\Repos\\OpgaveGUIAfsluttende\\OpgaveGUIAfsluttende\\AfsluttendeDB.mdf;Integrated Security=True";
            conn = new SqlConnection(connectionString);
            companyList = new List<Company>();
        }
        public async Task<List<Company>> getCompanies()
        {
            //Laver en sqlcommand der modtager forbindelsen og som får query
            SqlCommand cmd = new SqlCommand("SELECT * FROM AllCompaniesView", conn);
            try
            {
                //Åbner forbindelse og sætter modelobjekter ind i listen mens der er data til modeller at læse. Til sidst lukkes der for forbindelsen.
                await conn.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Company tempComp = new Company();
                    tempComp.Id = (int)reader["Id"];
                    tempComp.Name = (string)reader["Name"];
                    tempComp.Address = (int)reader["Address"];
                    companyList.Add(tempComp);
                }
                conn.Close();
            }
            catch (Exception e) //Er der gået noget galt laves en exception
            {
                companyList = null;
            }
            //Returnere modellisten uanset hvordan læsning af data er gået
            return companyList;
        }
        public async Task<Company> GetCompany(int companyId)
        {
            //Laver en sqlcommand der modtager forbindelsen og som får storedprocedure
            SqlCommand cmd = new SqlCommand("GetCompanyView", conn);
            cmd.Parameters.AddWithValue("@companyId", companyId);
            try
            {
                //Åbner forbindelse og laver modelobjekt der returneres tilbage hvis process er successfuld
                await conn.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                await reader.ReadAsync();
                Company comp = new Company();
                comp.Id = (int)reader["Id"];
                comp.Name = (string)reader["Name"];
                comp.Address = (int)reader["Address"];
                conn.Close();
                return comp;
            }
            catch (Exception e) //Er der gået noget galt laves en exception
            {
                companyList = null;
            }
            //Returnere modellisten uanset hvordan læsning af data er gået
            return null;
        }
        public async Task<Company> GetCompanyFromDepartmentId(int departmentId)
        {
            //Laver en sqlcommand der modtager forbindelsen og som får storedprocedure
            SqlCommand cmd = new SqlCommand("GetCompanyFromDepartmentId", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", departmentId);
            try
            {
                //Åbner forbindelse og laver modelobjekt der returneres tilbage hvis process er successfuld
                await conn.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                await reader.ReadAsync();
                Company comp = new Company();
                comp.Id = (int)reader["Id"];
                comp.Name = (string)reader["Name"];
                comp.Address = (int)reader["Address"];
                conn.Close();
                return comp;
            }
            catch (Exception e) //Er der gået noget galt laves en exception
            {
                companyList = null;
            }
            //Returnere modellisten uanset hvordan læsning af data er gået
            return null;
        }
        public async Task<bool> CreateCompany(Company inComp)
        {
            //Laver en sqlcommand der modtager forbindelsen og som får storedprocedure
            SqlCommand cmd = new SqlCommand("CreateCompany", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //værdier associeres med parametre for den ovenstående query  
            cmd.Parameters.AddWithValue("@Name", inComp.Name);
            cmd.Parameters.AddWithValue("@Address", inComp.Address);
            try
            {
                //åbner forbindelse til databasen
                await conn.OpenAsync();
                //Eksekvere SQL op imod databasen, hvis det er successfuldt returneres at process er eksekveret successfuldt eller at det er eksekveret med error
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
