using Api.Models;

namespace Api.Services
{
    public interface IEmployeeService
    {
        Task<ICollection<Employee>> GetAllEmployees();
        Task<Employee?> GetEmployeeById(int employeeId);
    }
}
