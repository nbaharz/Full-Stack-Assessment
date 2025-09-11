namespace StudentAutomationAPI.DTO
{
    public class GradeCreateDto
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public decimal Value { get; set; }
    }
}
