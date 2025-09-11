using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAutomationAPI.DTO;
using StudentAutomationAPI.Services.Interfaces;

namespace StudentAutomationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // Teacher: add comment to student
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Add([FromBody] CommentCreateDto dto)
        {
            var created = await _commentService.AddCommentAsync(dto);
            return Ok(created);
        }

        // Teacher & Student: get comments by student
        [HttpGet("student/{studentId:guid}")]
        [Authorize(Roles = "Teacher,Student")]
        public async Task<IActionResult> GetByStudent(Guid studentId)
        {
            var list = await _commentService.GetByStudentIdAsync(studentId);
            return Ok(list);
        }
    }
}
