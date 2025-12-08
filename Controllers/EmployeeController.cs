using EmployeeListApp.Enums;
using EmployeeListApp.Helpers;
using EmployeeListApp.Models.EmployeeModels;
using EmployeeListApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeListApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<ReadEmployeeModel>>> GetEmployeeList()
        {
            var result = await _employeeService.GetAllEmployeesAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ReadEmployeeModel?>> GetEmployeeById([FromRoute] Guid id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);

            if (employee == null)
            {
                return NotFound(ApiResponse.FailMessage("Employee does not exist."));
            }

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeModel model)
        {
            Result result = await _employeeService.AddEmployeeAsync(model);

            return result switch
            {
                Result.Success => Ok(ApiResponse.SuccessMessage("Added employee successfully.")),
                Result.Failed => BadRequest(ApiResponse.FailMessage("Adding employee failed.")),
                _ => StatusCode(500, ApiResponse.FailMessage("Unexpected server error."))
            };
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeModel model)
        {
            Result result = await _employeeService.UpdateEmployeeAsync(model);

            return result switch
            {
                Result.Success => Ok(ApiResponse.SuccessMessage("Employee updated successfully.")),
                Result.DoesNotExist => NotFound(ApiResponse.FailMessage("Employee does not exist.")),
                Result.Failed => BadRequest(ApiResponse.FailMessage("Updating employee failed.")),
                _ => StatusCode(500, ApiResponse.FailMessage("Unexpected server error."))
            };
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            Result result = await _employeeService.DeleteEmployeeAsync(id);

            return result switch
            {
                Result.Success => Ok(ApiResponse.SuccessMessage("Employee deleted successfully.")),
                Result.DoesNotExist => NotFound(ApiResponse.FailMessage("Employee does not exist.")),
                Result.Failed => BadRequest(ApiResponse.FailMessage("Deleting employee failed.")),
                _ => StatusCode(500, ApiResponse.FailMessage("Unexpected server error."))
            };
        }
    }
}
