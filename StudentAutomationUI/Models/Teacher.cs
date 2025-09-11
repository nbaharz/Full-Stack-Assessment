namespace StudentAutomationUI.Models
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string TeacherNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public List<Course> Courses { get; set; } = new();
    }
}