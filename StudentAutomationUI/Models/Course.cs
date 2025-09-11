namespace StudentAutomationUI.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseCode { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Credits { get; set; }
        public int TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public List<Student> Students { get; set; } = new();
    }
}