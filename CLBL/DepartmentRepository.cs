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
        //deklerere department datahandler variabel
        private DepartmentDataHandler departmentDH;
        public DepartmentRepository()
        {
            //instanciere departmentdatahandler objekt
            departmentDH = new DepartmentDataHandler();
        }
        public async Task<List<Department>> GetDepartments()
        {
            //kalder metode på departmentdatahandler objekt som returnere liste over departments
            return await departmentDH.GetDepartments();
        }
        public async Task<List<Department>> GetDepartmentsFromCompany(int companyId)
        {
            //kalder metode som returnere liste over departments på basis af companyid
            return await departmentDH.GetDepartmentsFromCompanyId(companyId);
        }
        public async Task<Department> GetDepartment(int departmentId)
        {
            //kalder metode der returnere department på basis af departmentid
            return await departmentDH.GetDepartment(departmentId);
        }
        public async Task<bool> CreateDepartment(Department inDepartment, Employee inBoss)
        {
            //kalder metode der opretter ny department med en boss tilhørende den pågældende department
            return await departmentDH.CreateDepartment(inDepartment, inBoss);
        }
    }
}
