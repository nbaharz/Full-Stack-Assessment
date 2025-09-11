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
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        // Teacher: add attendance
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Add([FromBody] AttendanceCreateDto dto)
        {
            await _attendanceService.AddAttendanceAsync(dto.StudentId, dto.CourseId, dto.Date, dto.Status);
            return Ok();
        }

        // Teacher & Student: get attendance by student
        [HttpGet("student/{studentId:guid}")]
        [Authorize(Roles = "Teacher,Student")]
        public async Task<IActionResult> GetByStudent(Guid studentId)
        {
            var list = await _attendanceService.GetByStudentIdAsync(studentId);
            return Ok(list);
        }
    }
}
