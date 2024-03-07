using Api.DataAccess;
using Api.Models;

namespace Api.Services
{
    public class DependentService : IDependentService
    {
        IDependentRepository dependentRepository;

        public DependentService(IDependentRepository dependentRepository)
        {
            this.dependentRepository = dependentRepository;
        }

        public async Task<bool> AddDependent(Dependent dependent)
        {
            // If dependent relationship is Spouse or Domestic Partner, need to make sure one doesn't already exist
            if (dependent.Relationship == Relationship.DomesticPartner || dependent.Relationship == Relationship.Spouse)
            {
                var dependents = await GetDependents(dependent.EmployeeId);

                var partners = dependents.Where(s => (s.Relationship == Relationship.Spouse) || (s.Relationship == Relationship.DomesticPartner));

                if (partners.Count() > 0)
                {
                    return false;
                }
            }

            return await dependentRepository.AddDependent(dependent);
        }

        public async Task<ICollection<Dependent>> GetAllDependents()
        {
            return await dependentRepository.GetAllDependents();
        }

        public async Task<Dependent?> GetDependentByDependentId(int dependentId)
        {
            return await dependentRepository.GetDependentByDependentId(dependentId);
        }

        public async Task<ICollection<Dependent>> GetDependents(int employeeId)
        {
            return await dependentRepository.GetDependents(employeeId);
        }
    }
}
