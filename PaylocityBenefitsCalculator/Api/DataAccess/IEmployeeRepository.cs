using Api.Models;

namespace Api.DataAccess
{
    public interface IEmployeeRepository
    {
        Task<ICollection<Employee>> GetAllEmployees();
        Task<Employee?> GetEmployeeById(int employeeId);
    }
}
