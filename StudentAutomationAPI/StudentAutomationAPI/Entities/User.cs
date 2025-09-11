namespace StudentAutomationAPI.Entities
{
   
    public class User : BaseEntity
    {
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public UserRole Role { get; set; }

        public Student? Student { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
