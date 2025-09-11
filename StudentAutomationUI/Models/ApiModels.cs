namespace StudentAutomationUI.Models
{
    public class ApiStudent
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string StudentNumber { get; set; } = string.Empty;
    }

    public class ApiTeacher
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? Department { get; set; }
    }

    public class ApiCourse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid TeacherId { get; set; }
        public string? Status { get; set; }
    }

    public class ApiGrade
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public string ExamType { get; set; } = string.Empty;
        public double Score { get; set; }
        public DateTime ExamDate { get; set; }
    }

    public class ApiAttendance
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
    }
}


