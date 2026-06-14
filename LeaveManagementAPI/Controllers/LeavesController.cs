using LeaveManagementAPI.Models;
using LeaveManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeavesController : ControllerBase
    {
        private readonly ILeaveService _service;

        public LeavesController(ILeaveService service)
        {
            _service = service;
        }

        // GET api/leaves
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var leaves = await _service.GetAllLeaves();
            return Ok(leaves);
        }

        // GET api/leaves/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var leave = await _service.GetLeaveById(id);
            if (leave == null)
                return NotFound($"Leave request {id} not found.");
            return Ok(leave);
        }

        // POST api/leaves
        [HttpPost]
        public async Task<IActionResult> Apply(LeaveRequest leave)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.ApplyLeave(leave);
            return CreatedAtAction(nameof(GetById), new { id = created.LeaveRequestId }, created);
        }

        // PUT api/leaves/approve/1
        [HttpPut("approve/{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            var result = await _service.ApproveLeave(id);
            if (result == null)
                return NotFound($"Leave request {id} not found.");
            return Ok(result);
        }

        // PUT api/leaves/reject/1
        [HttpPut("reject/{id}")]
        public async Task<IActionResult> Reject(int id)
        {
            var result = await _service.RejectLeave(id);
            if (result == null)
                return NotFound($"Leave request {id} not found.");
            return Ok(result);
        }

        // DELETE api/leaves/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteLeave(id);
            if (!result)
                return NotFound($"Leave request {id} not found.");
            return Ok($"Leave request {id} deleted successfully.");
        }
    }
}
