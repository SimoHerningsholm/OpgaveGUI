using System;
using System.Collections.Generic;
using System.Text;
using CLDB;
using System.Threading;
using System.Threading.Tasks;
using CLModels;
using CLValidator;

namespace CLBL
{
    public class EmployeeRepository : Interfaces.IEmployeeRepository //Der sættes et interface på da nogle metoder er obligatorisk at impliementere 
    {
        //Denne her klasse er overordnet set bare en unødvendig mellemvej indtil der bliver implimenteret validering
        //eller anden funktionalitet data skal køres igennem før det lander i sine respektive endestationer.
        EmployeeDataHandler employeeBinder;
        EmployeeFieldChecker employeeChecker;
        List<string> employeeCheckerErrors;
        public EmployeeRepository()
        {
            //Instanciere datahandler
            employeeBinder = new EmployeeDataHandler();
            employeeChecker = new EmployeeFieldChecker();
            employeeCheckerErrors = new List<string>();
        }
        public async Task<List<Employee>> getEmployees()
        {
            //Indtil videre returneres bare liste der er genereret i datalaget
            return await employeeBinder.getEmployees();
        }
        public async Task<Employee> getEmployee()
        {
            //Indtil videre returneres bare en enkelt employee fra liste i datalaget
            return await employeeBinder.getEmployee();
        }
        public async Task<bool> createEmployee(Employee employee)
        {
            //Der sendes en ny employee ind i datalaget. Her skal der laves validering
            if(await employeeChecker.Check(employee))
            {
                return await employeeBinder.createEmployee(employee);
            }
            else
            {
                employeeCheckerErrors = await employeeChecker.getErrorMessages();
                return false;
            }
        }
        public async Task<bool> updateEmployee()
        {
            //Bliver først implementeret når der kommer SQL på.
            return true;
        }
        public async Task<bool> deleteEmployee()
        {
            //bliver først implementeret når der kommer SQL på.
            return true;
        }
        public List<string> getErrors()
        {
            return employeeCheckerErrors;
        }
    }
}
