using System;
using CLDB;
using CLModels;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using CLValidator;

namespace CLBL
{
    public class DepartmentRepository
    {
        private DepartmentDataHandler departmentDH;
        public DepartmentRepository()
        {
            departmentDH = new DepartmentDataHandler();
        }
        public async Task<List<Department>> GetDepartments()
        {
            return await departmentDH.GetDepartments();
        }
        public async Task<Department> GetDepartment(int departmentId)
        {
            return await departmentDH.GetDepartment(departmentId);
        }
        public async Task<bool> CreateDepartment(Department inDepartment, Employee inBoss)
        {
            return await departmentDH.CreateDepartment(inDepartment, inBoss);
        }
    }
}
