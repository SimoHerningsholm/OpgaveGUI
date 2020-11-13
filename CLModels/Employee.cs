using System;

namespace CLModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address{ get; set; }
        public int ZipCode { get; set; }
        public DateTime BirthDay { get; set; }
        public string Company { get; set; }
        public string Department { get; set; }
    }
}
