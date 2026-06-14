using LeaveManagementAPI.Models;
using LeaveManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        // GET api/employees
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _service.GetAllEmployees();
            return Ok(employees);
        }

        // GET api/employees/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _service.GetEmployeeById(id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");
            return Ok(employee);
        }

        // POST api/employees
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.AddEmployee(employee);
            return CreatedAtAction(nameof(GetById), new { id = created.EmployeeId }, created);
        }

        // PUT api/employees/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employee employee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateEmployee(id, employee);
            if (updated == null)
                return NotFound($"Employee with ID {id} not found.");
            return Ok(updated);
        }

        // DELETE api/employees/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteEmployee(id);
            if (!result)
                return NotFound($"Employee with ID {id} not found.");
            return Ok($"Employee {id} deleted successfully.");
        }
    }
}