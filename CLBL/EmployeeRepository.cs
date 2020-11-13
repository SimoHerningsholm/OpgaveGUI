using System;
using System.Collections.Generic;
using System.Text;
using CLDB;
using System.Threading;
using System.Threading.Tasks;
using CLModels;

namespace CLBL
{
    public class EmployeeRepository
    {
        EmployeeDataHandler employeeBinder;
        public EmployeeRepository()
        {
            employeeBinder = new EmployeeDataHandler();
        }
        public async Task<List<Employee>> getEmployees()
        {
            return await employeeBinder.getEmployees();
        }
        public async Task<Employee> getEmployee()
        {
            return await employeeBinder.getEmployee();
        }
        public async void createEmployee(Employee employee)
        {
            employeeBinder.createEmployee(employee);
        }
        public async void updateEmployee()
        {
            //Bliver først implementeret når der kommer SQL på.
        }
        public async void deleteEmployee()
        {
            //bliver først implementeret når der kommer SQL på.
        }
    }
}
