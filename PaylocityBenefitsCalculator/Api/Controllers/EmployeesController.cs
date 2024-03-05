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
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<GetEmployeeDto>>> Get(int id)
    {
        Employee employee = await employeeService.GetEmployeeById(id);

        var result = new ApiResponse<GetEmployeeDto>
        {
            Data = new GetEmployeeDto(employee),
            Success = true
        };

        return result;
    }

    [SwaggerOperation(Summary = "Get all employees")]
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
