using Api.Models;

namespace Api.Services
{
    public interface IDependentService
    {
        Task<Dependent?> GetDependentByDependentId(int dependentId);
        Task<ICollection<Dependent>> GetAllDependents();
        Task<ICollection<Dependent>> GetDependents(int employeeId);
        Task<bool> AddDependent(Dependent dependent);
    }
}
