using Api.Models;

namespace Api.DataAccess
{
    public interface IDependentRepository
    {
        Task<ICollection<Dependent>> GetDependents(int employeeId);
        Task<bool> AddDependent(Dependent dependent);
        Task<ICollection<Dependent>> GetAllDependents();
        Task<Dependent?> GetDependentByDependentId(int dependentId);
    }
}
