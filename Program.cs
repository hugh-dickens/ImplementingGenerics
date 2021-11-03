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
            var itemAdded = new ItemAdded(EmployeeAdded);
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext(),
              itemAdded);
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

        private static void EmployeeAdded(object item)
        {
            var employee = (Employee)item;
            Console.WriteLine($"Employee added => {employee.FirstName}");
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
            var employees = new[]
            {
                new Employee { FirstName = "Julia" },
                new Employee { FirstName = "Anna" },
                new Employee { FirstName = "Thomas" }
            };

            employeeRepository.AddBatch(employees);
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            managerRepository.Add(new Manager { FirstName = "Sara" });
            managerRepository.Add(new Manager { FirstName = "Henry" });
            managerRepository.Save();

        }

        private static void AddOrganisations(IRepository<Organisation> organisationRepository)
        {
            var organisations = new[]
            {
                new Organisation { Name = "Pluralsight" },
                new Organisation { Name = "Globomantics" }
            };
            organisationRepository.AddBatch(organisations);
        }
    }
}
