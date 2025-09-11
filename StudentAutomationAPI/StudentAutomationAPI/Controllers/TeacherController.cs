using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using StudentAutomationAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using StudentAutomationAPI.Services.Interfaces;

namespace StudentAutomationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _teacherService.GetAllAsync();
            return Ok(teachers);
        }

      
        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var teacher = await _teacherService.GetByIdAsync(id);
            if (teacher == null) return NotFound();
            return Ok(teacher);
        }

      
        [HttpPost] // yalnizca admin yapabilir
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddTeacher([FromBody] Teacher teacher)
        {
            var created = await _teacherService.AddAsync(teacher);
            return Ok(created);
        }

        
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Teacher teacher)
        {
            if (id != teacher.Id) return BadRequest("Id eşleşmiyor");

            var updated = await _teacherService.UpdateAsync(teacher);
            return Ok(updated);
        }

        // Öğretmen sil
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _teacherService.DeleteAsync(id);
            return NoContent();
        }

        // Öğretmenin derslerini getir
        [HttpGet("{id:guid}/courses")]
        [Authorize(Roles = "Admin,Teacher")]
        public async Task<IActionResult> GetCourses(Guid id)
        {
            var courses = await _teacherService.GetCoursesAsync(id);
            return Ok(courses);
        }
    }
}
