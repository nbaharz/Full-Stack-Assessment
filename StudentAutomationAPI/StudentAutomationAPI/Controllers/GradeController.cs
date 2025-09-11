using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAutomationAPI.DTO;
using StudentAutomationAPI.Services.Interfaces;

namespace StudentAutomationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        // Teacher: add grade per course
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Add([FromBody] GradeCreateDto dto)
        {
            await _gradeService.AddGradeAsync(dto);
            return Ok();
        }

        // Student & Teacher: get grades by student
        [HttpGet("student/{studentId:guid}")]
        [Authorize(Roles = "Teacher,Student")]
        public async Task<IActionResult> GetByStudent(Guid studentId)
        {
            var list = await _gradeService.GetByStudentIdAsync(studentId);
            return Ok(list);
        }
    }
}
