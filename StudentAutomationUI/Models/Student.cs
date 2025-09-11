namespace StudentAutomationUI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentNumber { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Class { get; set; } = string.Empty;
        public List<Course> Courses { get; set; } = new();
        public List<Grade> Grades { get; set; } = new();
        public List<Attendance> Attendances { get; set; } = new();
    }
}