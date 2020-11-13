using System;
using System.Collections.Generic;
using System.Text;

namespace CLModels
{
    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }
        public List<Employee> Employees { get; set; }

    }
}
