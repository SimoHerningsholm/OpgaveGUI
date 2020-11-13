using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CLModels;

namespace CLBL.Interfaces
{
    interface IEmployeeRepository
    {
        Task<List<Employee>> getEmployees();
        Task<Employee> getEmployee();
        Task<bool> createEmployee(Employee employee);
        Task<bool> updateEmployee();
        Task<bool> deleteEmployee();

    }
}
