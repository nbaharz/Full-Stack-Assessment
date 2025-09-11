namespace StudentAutomationAPI.Entities
{
    public class Teacher: BaseEntity
    {
        public Guid UserId { get; set; }
        public string Department { get; set; } = null!;
        public string FullName { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
