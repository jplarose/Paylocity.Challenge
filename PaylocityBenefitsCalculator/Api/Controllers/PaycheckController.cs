using Api.Dtos.Paycheck;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaycheckController : ControllerBase
    {
        [SwaggerOperation(Summary = "Get paycheck by Employee Id")]
        [ProducesResponseType(typeof(ApiResponse<GetEmployeePaycheckDto>), StatusCodes.Status200OK)]
        [HttpGet("{employeeId}")]
        public async Task<ActionResult<ApiResponse<GetEmployeePaycheckDto>>> GetEmployeePaycheck(int employeeId)
        {
            throw new NotImplementedException();
        }

        [SwaggerOperation(Summary = "Get specific paycheck for an Employee")]
        [ProducesResponseType(typeof(ApiResponse<GetEmployeePaycheckDto>), StatusCodes.Status200OK)]
        [HttpGet("{employeeId}/{paycheckId}")]
        public async Task<ActionResult<ApiResponse<GetEmployeePaycheckDto>>> GetEmployeePaycheckByPaycheckId(int employeeId, string paycheckId)
        {
            throw new NotImplementedException();
        }

    }
}
