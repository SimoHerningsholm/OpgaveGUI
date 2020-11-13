using System;
using System.Collections.Generic;
using System.Text;

namespace CLModels
{
    class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BossName { get; set; }
        public List<Department> Departments { get; set;}
    }
}
