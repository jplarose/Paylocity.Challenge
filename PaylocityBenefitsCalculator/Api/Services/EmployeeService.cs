using Api.DataAccess;
using Api.Models;

namespace Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<ICollection<Employee>> GetAllEmployees()
        {
            return await employeeRepository.GetAllEmployees();
        }

        public async Task<Employee?> GetEmployeeById(int employeeId)
        {
            return await employeeRepository.GetEmployeeById(employeeId);
        }
    }
}
