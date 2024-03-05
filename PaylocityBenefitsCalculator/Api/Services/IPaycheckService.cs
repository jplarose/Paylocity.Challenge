using Api.Models;

namespace Api.Services
{
    public interface IPaycheckService
    {
        Task<Paycheck> GetEmployeePaycheck(int employeeId);
    }
}
