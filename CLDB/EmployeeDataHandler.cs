﻿using System;
using CLModels;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CLDB
{
    public class EmployeeDataHandler
    {
        //Properties der skal anvendes
        private string connectionString;
        private SqlConnection conn;
        private List<Employee> employeeList;
        public EmployeeDataHandler()
        {
            //sætter connectionstring og laver en connection med connectionstring
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Simon\\Source\\Repos\\OpgaveGUIAfsluttende\\OpgaveGUIAfsluttende\\AfsluttendeDB.mdf;Integrated Security=True";
            conn = new SqlConnection(connectionString);
            employeeList = new List<Employee>();
        }
        public async Task<List<Employee>> GetEmployees()
        {
            //Laver en sqlcommand der modtager forbindelsen og som får query
            SqlCommand cmd = new SqlCommand("SELECT * FROM AllEmployeesView", conn);
            try
            {
                //Åbner forbindelse og sætter modelobjekter ind i listen mens der er data til modeller at læse. Til sidst lukkes der for forbindelsen.
                await conn.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    Employee tempEmp= new Employee();
                    tempEmp.Id = (int)reader["Id"];
                    tempEmp.FirstName = (string)reader["FirstName"];
                    tempEmp.LastName = (string)reader["LastName"];
                    tempEmp.Address = (int)reader["Address"];
                    tempEmp.BirthDay = (DateTime)reader["BirthDay"];
                    tempEmp.Email = (string)reader["Email"];
                    tempEmp.Phone = (int)reader["Phone"];
                    tempEmp.Department = (int)reader["Department"];
                    tempEmp.JobTitle = (int)reader["JobTitle"];
                    employeeList.Add(tempEmp);
                }
                conn.Close();
            }
            catch (Exception e) //Er der gået noget galt laves en exception
            {
                employeeList = null;
            }
            //Returnere modellisten uanset hvordan læsning af data er gået
            return employeeList;
        }
        public async Task<Employee> GetEmployee(int id)
        {
            //Laver en sqlcommand der modtager forbindelsen og som får storedprocedure
            SqlCommand cmd = new SqlCommand("GetEmployeeView", conn);
            try
            {
                //Åbner forbindelse og sætter modelobjekter ind i listen mens der er data til modeller at læse. Til sidst lukkes der for forbindelsen.
                await conn.OpenAsync();
                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                await reader.ReadAsync();
                Employee tempEmp = new Employee();
                tempEmp.Id = (int)reader["Id"];
                tempEmp.FirstName = (string)reader["FirstName"];
                tempEmp.LastName = (string)reader["LastName"];
                tempEmp.Address = (int)reader["Address"];
                tempEmp.BirthDay = (DateTime)reader["BirthDay"];
                tempEmp.Email = (string)reader["Email"];
                tempEmp.Phone = (int)reader["Phone"];
                tempEmp.Department = (int)reader["Department"];
                tempEmp.JobTitle = (int)reader["JobTitle"];
                employeeList.Add(tempEmp);
                conn.Close();
                return tempEmp;
            }
            catch (Exception e) //Er der gået noget galt laves en exception
            {
                return null;
            }
        }
        public async Task<bool> CreateEmployee(Employee inEmp)
        {
            //Laver en sqlcommand der modtager forbindelsen og som får storedprocedure
            SqlCommand cmd = new SqlCommand("CreateEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //værdier associeres med parametre for den ovenstående query  
            cmd.Parameters.AddWithValue("@FirstName", inEmp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", inEmp.LastName);
            cmd.Parameters.AddWithValue("@Address", inEmp.Address);
            cmd.Parameters.AddWithValue("@Birthday", inEmp.BirthDay);
            cmd.Parameters.AddWithValue("@Email", inEmp.Email);
            cmd.Parameters.AddWithValue("@Phone", inEmp.Phone);
            cmd.Parameters.AddWithValue("@Department", inEmp.Department);
            cmd.Parameters.AddWithValue("@JobTitle", inEmp.JobTitle);
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
        public async Task<bool> UpdateEmployee(Employee inEmp)
        {
            //Laver en sqlcommand der modtager forbindelsen og som får storedprocedure
            SqlCommand cmd = new SqlCommand("UpdateEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //værdier associeres med parametre for den ovenstående query  
            cmd.Parameters.AddWithValue("@Id", inEmp.Id);
            cmd.Parameters.AddWithValue("@FirstName", inEmp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", inEmp.LastName);
            cmd.Parameters.AddWithValue("@Address", inEmp.Address);
            cmd.Parameters.AddWithValue("@Birthday", inEmp.BirthDay);
            cmd.Parameters.AddWithValue("@Email", inEmp.Email);
            cmd.Parameters.AddWithValue("@Phone", inEmp.Phone);
            cmd.Parameters.AddWithValue("@Department", inEmp.Department);
            cmd.Parameters.AddWithValue("@JobTitle", inEmp.JobTitle);
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
            catch(Exception e)
            {
                //Lukker forbindelsen og returner at sql ikke er eksekveret successfuldt
                return false;
            }
        }
        public async Task<bool> DeleteEmployee(int empId)
        {
            //Laver en sqlcommand der modtager forbindelsen og som får storedprocedure
            SqlCommand cmd = new SqlCommand("DeleteEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //værdier associeres med parametre for den ovenstående query  
            cmd.Parameters.AddWithValue("@Id", empId);
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
