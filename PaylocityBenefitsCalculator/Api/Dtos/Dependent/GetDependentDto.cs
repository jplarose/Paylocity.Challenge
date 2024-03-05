using Api.Models;

namespace Api.Dtos.Dependent;

public class GetDependentDto
{
    /// <summary>
    /// Updated name, better to be more specific/verbose
    /// </summary>
    public int DependentId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Relationship Relationship { get; set; }

    /// <summary>
    /// Constructor to handle mapping
    /// </summary>
    /// <param name="dependent"></param>
    public GetDependentDto(Models.Dependent dependent)
    {
        DependentId = dependent.DependentId;
        FirstName = dependent.FirstName;
        LastName = dependent.LastName;
        DateOfBirth = dependent.DateOfBirth;
        Relationship = dependent.Relationship;
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public GetDependentDto()
    {

    }
}
