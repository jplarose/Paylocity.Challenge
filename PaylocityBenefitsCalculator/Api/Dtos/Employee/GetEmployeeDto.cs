using Api.Dtos.Dependent;

namespace Api.Dtos.Employee;

public class GetEmployeeDto
{
    /// <summary>
    /// Updated name, better to be more specific/verbose
    /// </summary>
    public int EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public decimal Salary { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ICollection<GetDependentDto> Dependents { get; set; } = new List<GetDependentDto>();

    /// <summary>
    /// Constructor to handle mapping from the repository model to the DTO
    /// </summary>
    /// <param name="employee"></param>
    public GetEmployeeDto(Models.Employee employee)
    {
        EmployeeId = employee.EmployeeId;
        FirstName = employee.FirstName;
        LastName = employee.LastName;
        Salary = employee.Salary;
        DateOfBirth = employee.DateOfBirth;
        Dependents = employee.Dependents
            .Select(s => new GetDependentDto(s))
            .ToList();
    }

    /// <summary>
    /// Base constructor
    /// </summary>
    public GetEmployeeDto()
    {

    }
}
