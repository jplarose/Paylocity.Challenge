using Api.Dtos.Paycheck;
using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaycheckController : ControllerBase
    {
        IPaycheckService paycheckService;

        public PaycheckController(IPaycheckService paycheckService)
        {
            this.paycheckService = paycheckService;
        }

        [SwaggerOperation(Summary = "Get paycheck by Employee Id")]
        [ProducesResponseType(typeof(ApiResponse<GetEmployeePaycheckDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<ProblemDetails>), StatusCodes.Status400BadRequest)]
        [HttpGet("{employeeId}")]
        public async Task<ActionResult<ApiResponse<GetEmployeePaycheckDto>>> GetEmployeePaycheck(int employeeId)
        {
            var paycheck = await paycheckService.GetEmployeePaycheck(employeeId);

            if (paycheck == null)
            {
                var errorResult = new ApiResponse<ProblemDetails>
                {
                    Data = new ProblemDetails
                    {
                        Detail = "Employee provided doesn't exist"
                    },
                    Message = "Employee provided doesn't exist",
                    Success = false
                };

                return BadRequest(errorResult);
            }

            var result = new ApiResponse<GetEmployeePaycheckDto>
            {
                Data = new GetEmployeePaycheckDto(paycheck),
                Success = true
            };

            return Ok(result);
        }
    }
}
