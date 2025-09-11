using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAutomationAPI.DTO;
using StudentAutomationAPI.Entities;
using StudentAutomationAPI.Services.Interfaces;

namespace StudentAutomationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // Admin: create course
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CourseCreateDto dto)
        {
            await _courseService.AddCourseAsync(dto);
            return Ok();
        }

        // Anyone authenticated: list courses (optionally filter by teacher via query)
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAllAsync();
            return Ok(courses);
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            var course = await _courseService.GetByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        // Teacher: update own course status (started, finished, etc.)
        [HttpPut("{id:guid}/status")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromQuery] string status)
        {
            await _courseService.UpdateCourseStatusAsync(id, status);
            return NoContent();
        }

        // Admin: update course
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Course course)
        {
            if (id != course.Id) return BadRequest("Id eşleşmiyor");
            var updated = await _courseService.UpdateAsync(course);
            return Ok(updated);
        }

        // Admin: delete course
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _courseService.DeleteAsync(id);
            return NoContent();
        }
    }
}
