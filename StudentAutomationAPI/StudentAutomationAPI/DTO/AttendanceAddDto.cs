namespace StudentAutomationAPI.DTO
{
    public class AttendanceAddDto
    {
        public Guid StudentId {  get; set; }
        public Guid CourseId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } //enum olmali
    }
   
}
