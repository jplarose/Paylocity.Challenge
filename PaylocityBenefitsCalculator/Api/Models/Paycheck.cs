namespace Api.Models
{
    public class Paycheck
    {
        public int EmployeeId { get; set; }
        public string? PaycheckId { get; set; }
        public int NumberOfDependents { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetAmount { get; set; }
        public DateTime PayPeriodStart { get; set; }
        public DateTime PayPeriodEnd { get; set; }
    }
}
