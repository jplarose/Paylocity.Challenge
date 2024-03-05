using Api.Models;

namespace Api.DataAccess
{
    /// <summary>
    /// Concrete implementation of the Employee Repository. <br/> 
    /// Hard coding values in memory for the purpose of this excercise but could be replaced with an actual database implementation
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<ICollection<Employee>> GetAllEmployees()
        {
            List<Employee> employees = Employees;

            return employees;
        }

        public async Task<Employee> GetEmployeeById(int employeeId)
        {
            return Employees.FirstOrDefault(s => s.EmployeeId == employeeId);
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
                    DateOfBirth = new DateTime(1999, 8, 10),
                    Dependents = new List<Dependent>
                    {
                        new()
                        {
                            DependentId = 1,
                            FirstName = "Spouse",
                            LastName = "Morant",
                            Relationship = Relationship.Spouse,
                            DateOfBirth = new DateTime(1998, 3, 3)
                        },
                        new()
                        {
                            DependentId = 2,
                            FirstName = "Child1",
                            LastName = "Morant",
                            Relationship = Relationship.Child,
                            DateOfBirth = new DateTime(2020, 6, 23)
                        },
                        new()
                        {
                            DependentId = 3,
                            FirstName = "Child2",
                            LastName = "Morant",
                            Relationship = Relationship.Child,
                            DateOfBirth = new DateTime(2021, 5, 18)
                        }
                    }
                },
                new()
                {
                    EmployeeId = 3,
                    FirstName = "Michael",
                    LastName = "Jordan",
                    Salary = 143211.12m,
                    DateOfBirth = new DateTime(1963, 2, 17),
                    Dependents = new List<Dependent>
                    {
                        new()
                        {
                            DependentId = 4,
                            FirstName = "DP",
                            LastName = "Jordan",
                            Relationship = Relationship.DomesticPartner,
                            DateOfBirth = new DateTime(1974, 1, 2)
                        }
                    }
                }
            };
    }
}
