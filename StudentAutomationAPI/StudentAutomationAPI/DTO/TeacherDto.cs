namespace StudentAutomationAPI.DTO
{
    public class TeacherDto
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string? Department { get; set; }
    }
}
