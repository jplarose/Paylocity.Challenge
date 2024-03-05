using Api.Models;

namespace Api.Services
{
    public class PaycheckService : IPaycheckService
    {
        IEmployeeService employeeService;

        public PaycheckService(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task<Paycheck> GetEmployeePaycheck(int employeeId)
        {
            // First, get the employee
            Employee employee = await employeeService.GetEmployeeById(employeeId);

            // Pass the employee to a private method to calculate the total deductions

            // Populate the paycheck with the relevant information

            throw new NotImplementedException();
        }

        private decimal GetDeductions(Employee employee)
        {

            return 0m;
        }
    }
}
