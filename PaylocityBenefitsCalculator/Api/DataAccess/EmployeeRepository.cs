using Api.Models;

namespace Api.DataAccess
{
    /// <summary>
    /// Concrete implementation of the Employee Repository. <br/> 
    /// Hard coding values in memory for the purpose of this excercise but could be replaced with an actual database implementation
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        IDependentRepository dependentRepository;

        public EmployeeRepository(IDependentRepository dependentRepository)
        {
            this.dependentRepository = dependentRepository;
        }

        public async Task<ICollection<Employee>> GetAllEmployees()
        {
            List<Employee> employees = Employees;

            employees.ForEach(async x => x.Dependents = await dependentRepository.GetDependents(x.EmployeeId));

            return employees;
        }

        public async Task<Employee?> GetEmployeeById(int employeeId)
        {
            var employee = Employees.FirstOrDefault(s => s.EmployeeId == employeeId);

            if (employee != null)
            {
                employee.Dependents = await dependentRepository.GetDependents(employeeId);
                return employee;
            }

            return null;
        }

        /// <summary>
        /// Keeping these employee values in memory for the purpose of this exercise
        /// </summary>
        private static List<Employee> Employees => new List<Employee>
            {
                new()
                {
                    EmployeeId = 1,
                    FirstName = "LeBron",
                    LastName = "James",
                    Salary = 75420.99m,
                    DateOfBirth = new DateTime(1984, 12, 30)
                },
                new()
                {
                    EmployeeId = 2,
                    FirstName = "Ja",
                    LastName = "Morant",
                    Salary = 92365.22m,
                    DateOfBirth = new DateTime(1999, 8, 10)
                },
                new()
                {
                    EmployeeId = 3,
                    FirstName = "Michael",
                    LastName = "Jordan",
                    Salary = 143211.12m,
                    DateOfBirth = new DateTime(1963, 2, 17)
                }
            };
    }
}
