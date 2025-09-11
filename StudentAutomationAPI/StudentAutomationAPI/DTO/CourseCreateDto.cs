namespace StudentAutomationAPI.DTO
{
    public class CourseCreateDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid TeacherId { get; set; }
    }
}
