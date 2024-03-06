using Api.Dtos.Dependent;

namespace Api.Models;

public class Dependent
{
    /// <summary>
    /// Updated name, better to be more specific/Verbose
    /// </summary>
    public int DependentId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Relationship Relationship { get; set; }
    public int EmployeeId { get; set; }

    public Dependent(AddDependentDto dependentDto)
    {
        FirstName = dependentDto.FirstName;
        LastName = dependentDto.LastName;
        DateOfBirth = dependentDto.DateOfBirth;
        Relationship = dependentDto.Relationship;
        EmployeeId = dependentDto.EmployeeId;
    }

    public Dependent()
    {

    }
}
