using Api.Models;

namespace Api.DataAccess
{
    /// <summary>
    /// Concrete implementation of the Dependent Repository. <br/> 
    /// Hard coding values in memory for the purpose of this excercise but could be replaced with an actual database implementation
    /// </summary>
    public class DependentRepository : IDependentRepository
    {
        public async Task<ICollection<Dependent>> GetDependents(int employeeId)
        {
            return Dependents.Where(s => s.EmployeeId == employeeId).ToList();
        }

        public async Task<bool> AddDependent(Dependent dependent)
        {
            Dependents.Add(dependent);

            // Hard coding for this exercise, here you would have a try/catch to account for DB errors
            // to alert the service if there was a problem
            return true;
        }

        public async Task<ICollection<Dependent>> GetAllDependents()
        {
            return Dependents;
        }

        public async Task<Dependent?> GetDependentByDependentId(int dependentId)
        {
            return Dependents.FirstOrDefault(s => s.DependentId == dependentId);
        }

        /// <summary>
        /// In memory dependent values for the purpose of this exercise
        /// </summary>
        private List<Dependent> Dependents = new List<Dependent>
            {
                new()
                {
                    DependentId = 1,
                    FirstName = "Spouse",
                    LastName = "Morant",
                    Relationship = Relationship.Spouse,
                    DateOfBirth = new DateTime(1998, 3, 3),
                    EmployeeId = 2
                },
                new()
                {
                    DependentId = 2,
                    FirstName = "Child1",
                    LastName = "Morant",
                    Relationship = Relationship.Child,
                    DateOfBirth = new DateTime(2020, 6, 23),
                    EmployeeId = 2
                },
                new()
                {
                    DependentId = 3,
                    FirstName = "Child2",
                    LastName = "Morant",
                    Relationship = Relationship.Child,
                    DateOfBirth = new DateTime(2021, 5, 18),
                    EmployeeId = 2
                },
                new()
                {
                    DependentId = 4,
                    FirstName = "DP",
                    LastName = "Jordan",
                    Relationship = Relationship.DomesticPartner,
                    DateOfBirth = new DateTime(1974, 1, 2),
                    EmployeeId = 3
                }
            };
    }
}
