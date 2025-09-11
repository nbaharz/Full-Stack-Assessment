using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAutomationAPI.Entities;
using StudentAutomationAPI.Services.Interfaces;

namespace StudentAutomationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // Admin & Teacher: list students
        [HttpGet]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(students);
        }

        // Admin & Teacher: get by id
        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        // Student: view own profile
        [HttpGet("me")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetMe()
        {
            // In a real app, studentId would come from the authenticated user claims
            if (!Guid.TryParse(User.FindFirst("sub")?.Value, out var studentId))
                return Unauthorized();

            var me = await _studentService.GetOwnProfileAsync(studentId);
            if (me == null) return NotFound();
            return Ok(me);
        }

        // Admin & Teacher: create student
        [HttpPost]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            var created = await _studentService.AddAsync(student);
            return Ok(created);
        }

        // Admin & Teacher: update student
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Student student)
        {
            if (id != student.Id) return BadRequest("Id eşleşmiyor");
            var updated = await _studentService.UpdateAsync(student);
            return Ok(updated);
        }

        // Admin & Teacher: delete student
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _studentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
