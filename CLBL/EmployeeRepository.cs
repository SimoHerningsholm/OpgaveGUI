using System;
using System.Collections.Generic;
using System.Text;
using CLDB;
using System.Threading;
using System.Threading.Tasks;
using CLModels;
using CLValidator;
using System.Data;

namespace CLBL
{
    public class EmployeeRepository : Interfaces.IEmployeeRepository //Der sættes et interface på da nogle metoder er obligatorisk at impliementere 
    {
        //Denne her klasse er overordnet set bare en unødvendig mellemvej indtil der bliver implimenteret validering
        //eller anden funktionalitet data skal køres igennem før det lander i sine respektive endestationer.
        EmployeeDataHandler employeeBinder;
        public EmployeeRepository()
        {
            //Instanciere datahandler
            employeeBinder = new EmployeeDataHandler();
        }
        public async Task<List<Employee>> GetEmployees()
        {
            //Kalder metode på employeedatahadlerobjekt der returnere en liste af employees
            return await employeeBinder.GetEmployees();
        }
        public async Task<Employee> GetEmployee(int empId)
        {
            //Kalder metode på employeedatahandlerobjekt der returnere en employee på basis af id givet som argument
            return await employeeBinder.GetEmployee(empId);
        }
        public async Task<bool> CreateEmployee(Employee employee)
        {
            //Der sendes en ny employee ind i datalaget til oprettelse
            return await employeeBinder.CreateEmployee(employee);
        }
        public async Task<bool> UpdateEmployee(Employee employee)
        {
            //Der sendes en ny employee ind i datalaget til opdatering
            return await employeeBinder.UpdateEmployee(employee);
        }
        public async Task<bool> DeleteEmployee(int empId)
        {
            //Der kaldes deleteemployee metoden på employeedatahandler som modtager id på employee der skal slettes
            return await employeeBinder.DeleteEmployee(empId);
        }
    }
}
