using Api.Dtos.Dependent;
using Api.Dtos.Employee;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EmployeesController : ControllerBase
{
    IEmployeeService employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        this.employeeService = employeeService;
    }

    [SwaggerOperation(Summary = "Get employee by id")]
    [ProducesResponseType(typeof(ApiResponse<GetEmployeeDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GetEmployeeDto>>> Get(int id)
    {
        var employee = await employeeService.GetEmployeeById(id);

        if (employee == null)
        {
            var errorResult = new ApiResponse<ProblemDetails>
            {
                Success = false,
                Message = "No employee with that Id"
            };

            return NotFound(errorResult);
        }

        var result = new ApiResponse<GetEmployeeDto>
        {
            Data = new GetEmployeeDto(employee),
            Success = true
        };

        return Ok(result);
    }

    [SwaggerOperation(Summary = "Get all employees")]
    [ProducesResponseType(typeof(ApiResponse<List<GetEmployeeDto>>), StatusCodes.Status200OK)]
    [HttpGet("")]
    public async Task<ActionResult<ApiResponse<List<GetEmployeeDto>>>> GetAll()
    {
        ICollection<Employee> employees = await employeeService.GetAllEmployees();

        var result = new ApiResponse<List<GetEmployeeDto>>
        {
            // Map each of the employee models to the appropriate type
            Data = employees
            .Select(s => new GetEmployeeDto(s))
            .ToList(),
            Success = true
        };

        return result;
    }
}
