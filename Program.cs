using System;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

namespace WiredBrainCoffee.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new GenericRepository<Employee>();
            
            AddEmployees(employeeRepository);
            GetEmployeeById(employeeRepository);

            var organisationRepository = new GenericRepository<Organisation>();
            AddOrganisations(organisationRepository);

            Console.ReadLine();

        }

        private static void GetEmployeeById(GenericRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            System.Console.WriteLine($"Employee with Id 2: {employee.FirstName}");
        }

        private static void AddEmployees(GenericRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "Julia" });
            employeeRepository.Add(new Employee { FirstName = "Anna" });
            employeeRepository.Add(new Employee { FirstName = "Thomas" });
            employeeRepository.Save();
        }

        private static void AddOrganisations(GenericRepository<Organisation> organisationRepository)
        {
            organisationRepository.Add(new Organisation { Name = "Pluralsight" });
            organisationRepository.Add(new Organisation { Name = "Globomantics" });
            organisationRepository.Save();
        }
    }
}
