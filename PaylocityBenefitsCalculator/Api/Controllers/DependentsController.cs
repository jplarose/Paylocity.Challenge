using Api.Dtos.Dependent;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DependentsController : ControllerBase
{
    IDependentService dependentService;

    public DependentsController(IDependentService dependentService)
    {
        this.dependentService = dependentService;
    }

    [SwaggerOperation(Summary = "Get dependent by id")]
    [ProducesResponseType(typeof(ApiResponse<GetDependentDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
    [HttpGet("{dependentId}")]
    public async Task<ActionResult<ApiResponse<GetDependentDto>>> Get(int dependentId)
    {
        var dependent = await dependentService.GetDependentByDependentId(dependentId);

        if (dependent == null)
        {
            var errorResult = new ApiResponse<ProblemDetails>
            {
                Success = false,
                Message = "No dependent with that Id"
            };

            return NotFound(errorResult);
        }

        var result = new ApiResponse<GetDependentDto>
        {
            Data = new GetDependentDto(dependent),
            Success = true
        };

        return Ok(result);
    }

    [SwaggerOperation(Summary = "Get all dependents")]
    [ProducesResponseType(typeof(ApiResponse<List<GetDependentDto>>), StatusCodes.Status200OK)]
    [HttpGet("")]
    public async Task<ActionResult<ApiResponse<List<GetDependentDto>>>> GetAll()
    {
        var dependents = await dependentService.GetAllDependents();

        var result = new ApiResponse<List<GetDependentDto>>
        {
            Data = dependents
            .Select(s => new GetDependentDto(s))
            .ToList(),
            Success = true
        };

        return Ok(result);
    }

    [SwaggerOperation(Summary = "Add a new dependent for an employee")]
    [ProducesResponseType(typeof(ActionResult), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ActionResult<ProblemDetails>), StatusCodes.Status400BadRequest)]
    [HttpPost("")]
    public async Task<ActionResult> AddDependent([FromBody]AddDependentDto dependent)
    {
        bool success = await dependentService.AddDependent(new Dependent(dependent));

        if (!success)
        {
            return BadRequest(new ProblemDetails
            {
                Detail = "This dependent could not be added"
            });
        }

        return CreatedAtAction("AddDependent", dependent);
    }
}
