using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.DTO
{
    public class AttendanceCreateDto
    {
        public Guid StudentId {  get; set; }
        public Guid CourseId { get; set; }
        public DateTime Date { get; set; }
        public AttendanceStatus Status { get; set; } //enum olmali
    }
   
}
