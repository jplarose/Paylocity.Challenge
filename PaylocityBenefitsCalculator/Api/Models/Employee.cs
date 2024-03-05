namespace Api.Models;

public class Employee
{
    /// <summary>
    /// Updated name, better to be more specific/verbose 
    /// </summary>
    public int EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public decimal Salary { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();
}
