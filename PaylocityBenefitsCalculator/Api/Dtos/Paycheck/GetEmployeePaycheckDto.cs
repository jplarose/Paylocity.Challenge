
namespace Api.Dtos.Paycheck
{
    public class GetEmployeePaycheckDto
    {
        public int EmployeeId { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetAmount { get; set; }
        public DateTime PayPeriodStart { get; set; }
        public DateTime PayPeriodEnd { get; set; }

        /// <summary>
        /// Constructor for mapping the data model to the DTO
        /// </summary>
        /// <param name="paycheck"></param>
        public GetEmployeePaycheckDto(Models.Paycheck paycheck)
        {
            EmployeeId = paycheck.EmployeeId;
            GrossAmount = paycheck.GrossAmount;
            Deductions = paycheck.Deductions;
            NetAmount = paycheck.NetAmount;
            PayPeriodStart = paycheck.PayPeriodStart;
            PayPeriodEnd = paycheck.PayPeriodEnd;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GetEmployeePaycheckDto()
        {
        }
    }
}
