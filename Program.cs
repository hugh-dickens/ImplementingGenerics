using System;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;
using WiredBrainCoffee.StorageApp.Data;

namespace WiredBrainCoffee.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            AddEmployees(employeeRepository);
            AddManagers(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);

            IWriteRepository<Manager> repo = new SqlRepository<Employee>(new StorageAppDbContext());
            
            var organisationRepository = new ListRepository<Organisation>();
            AddOrganisations(organisationRepository);
            WriteAllToConsole(organisationRepository);

            Console.ReadLine();
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetEmployeeById(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with Id 2: {employee.FirstName}");
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "Julia" });
            employeeRepository.Add(new Employee { FirstName = "Anna" });
            employeeRepository.Add(new Employee { FirstName = "Thomas" });
            employeeRepository.Save();
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            managerRepository.Add(new Manager { FirstName = "Sara" });
            managerRepository.Add(new Manager { FirstName = "Henry" });
            managerRepository.Save();

        }

        private static void AddOrganisations(IRepository<Organisation> organisationRepository)
        {
            organisationRepository.Add(new Organisation { Name = "Pluralsight" });
            organisationRepository.Add(new Organisation { Name = "Globomantics" });
            organisationRepository.Save();
        }
    }
}
