namespace Api.Models
{
    public class Paycheck
    {
        public int EmployeeId { get; set; }
        public int NumberOfDependents { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetAmount { get; set; }
    }
}
