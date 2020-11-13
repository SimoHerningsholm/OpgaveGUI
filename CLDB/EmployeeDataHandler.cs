using System;
using CLModels;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CLDB
{
    public class EmployeeDataHandler
    {
        //Deklerere liste af testemployees
        List<Employee> testEmployees;
        public EmployeeDataHandler()
        {
            //Generere en liste af employee objekter der kan simulere database data i frontend
            testEmployees = new List<Employee>()
            {
                new Employee() {Id=1, Name = "Kurt", Address = "Kurtstreet 3", BirthDay = new DateTime(1980, 12, 24), Company = "FunnyINC", Department = "Comedy", ZipCode = 8000 },
                new Employee() {Id=2, Name = "Benny", Address = "Bennystreet 3", BirthDay = new DateTime(1980, 11, 24), Company = "CircusArena", Department = "Acrobatics", ZipCode = 8700 },
                new Employee() {Id=3, Name = "Sigurd", Address = "Sigurdstreet 3", BirthDay = new DateTime(1985, 10, 24), Company = "ToysRUs", Department = "ToyProduction", ZipCode = 7400 },
                new Employee() {Id=4, Name = "Lene", Address = "Lenestreet 3", BirthDay = new DateTime(1991, 9, 24), Company = "FunnyINC", Department = "Management", ZipCode = 7100 },
                new Employee() {Id=5, Name = "Claudia", Address = "Claudiatreet 3", BirthDay = new DateTime(1980, 12, 24), Company = "CircusArena", Department = "Acrobatics", ZipCode = 8000 },
                new Employee() {Id=6, Name = "Peter", Address = "Peterstreet 3", BirthDay = new DateTime(1972, 12, 24), Company = "SantaInc", Department = "ToyProduction", ZipCode = 7210 },
                new Employee() {Id=7, Name = "Anders", Address = "Andersstreet 3", BirthDay = new DateTime(1980, 12, 24), Company = "FunnyINC", Department = "Comedy", ZipCode = 1500 },
                new Employee() {Id=8, Name = "Line", Address = "Linestreet 3", BirthDay = new DateTime(1993, 12, 24), Company = "CircusArena", Department = "Linedancers", ZipCode = 8400 },
                new Employee() {Id=9, Name = "Lone", Address = "Lonesstreet 3", BirthDay = new DateTime(1977, 12, 24), Company = "ToysRUs", Department = "Management", ZipCode = 1500 },
                new Employee() {Id=10, Name = "Magnus", Address = "Magnusstreet 3", BirthDay = new DateTime(1988, 12, 24), Company = "FunnyINC", Department = "Management", ZipCode = 8400 }
            };
        }
        public async Task<List<Employee>> getEmployees()
        {
            //Indtil der kommer databasefunktionalitet returneres listen bare til den der kalder metoden
            return testEmployees;
        }
        public async Task<Employee> getEmployee()
        {
            //Indtil der kommer databasefunktionalitet returneres den første employee fra listen
            return testEmployees[0];
        }
        public async Task<bool> createEmployee(Employee employee)
        {
            //Man kan indsætte en ny employee i listen. Dette vises dog ikke i viewgrid i program da listen med ny
            //employee overskrives med listen i constructoren når der sker et kald hen til denne metode.
            testEmployees.Add(employee);
            return true;
        }
    }
}
