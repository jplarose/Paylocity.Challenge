using Api.Models;

namespace Api.Services
{
    /// <summary>
    /// Concrete implementation of a Paycheck service following the business rules defined in the requirements
    /// </summary>
    public class PaycheckService : IPaycheckService
    {
        readonly IEmployeeService employeeService;

        public PaycheckService(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public async Task<Paycheck?> GetEmployeePaycheck(int employeeId)
        {
            // First, get the employee
            var employee = await employeeService.GetEmployeeById(employeeId);

            if (employee == null)
            {
                return null;
            }

            // Calculate the total deductions
            decimal deductions = GetDeductions(employee);

            // Calculate the gross amount per paycheck
            decimal grossAmount = Decimal.Round(Decimal.Divide(employee.Salary, 26), 2);

            // Populate the paycheck with the relevant information
            Paycheck paycheck = new Paycheck
            {
                Deductions = deductions,
                GrossAmount = grossAmount,
                NetAmount = grossAmount - deductions,
                EmployeeId = employee.EmployeeId,
                NumberOfDependents = employee.Dependents.Count()
            };

            return paycheck;
        }

        /// <summary>
        /// Calculate the deductions per paycheck based on certain employee demographics
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        private decimal GetDeductions(Employee employee)
        {
            // Base cost is $1000/month
            decimal baseCost = 12000m;

            // $600/month for each dependent
            decimal dependentCost = (employee.Dependents.Count() * 600m) * 12;

            // Additional 2% charge for employees with a salary over $80000
            decimal salaryOver80kCost = employee.Salary > 80000m ? (employee.Salary * 0.02m) : 0m;

            // Additional $200/month for each dependent over 50
            int dependentsOver50Count = employee.Dependents.Count(s => GetAge(s.DateOfBirth) > 50);

            decimal ageOver50Cost = (dependentsOver50Count > 0 ? 200m * dependentsOver50Count : 0m) * 12;

            // Employee's total yearly cost for benefits
            decimal totalYearlyCost = baseCost + dependentCost + salaryOver80kCost + ageOver50Cost;

            // Divide into individual Paycheck deductions
            decimal perPaycheckCost = Decimal.Divide(totalYearlyCost, 26);

            // Return that amount rounded to two decimal places
            return Decimal.Round(perPaycheckCost, 2);
        }

        /// <summary>
        /// Get a persons age given a DateTime birthdate
        /// </summary>
        /// <param name="birthDate"></param>
        /// <returns></returns>
        private static int GetAge(DateTime birthDate)
        {
            DateTime now = DateTime.Now;

            int age = now.Year - birthDate.Year;

            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day))
            {
                age--;
            }

            return age;
        }
    }
}
