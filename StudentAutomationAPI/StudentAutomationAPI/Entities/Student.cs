namespace StudentAutomationAPI.Entities
{
    public class Student: BaseEntity
    {
        public Guid UserId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string StudentNumber { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
