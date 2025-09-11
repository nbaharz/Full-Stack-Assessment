namespace StudentAutomationUI.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string ExamType { get; set; } = string.Empty; // Midterm, Final, Quiz, etc.
        public double Score { get; set; }
        public DateTime ExamDate { get; set; }
        public string? Notes { get; set; }
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}