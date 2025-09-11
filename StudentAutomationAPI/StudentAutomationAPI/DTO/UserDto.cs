using StudentAutomationAPI.Entities;
namespace StudentAutomationAPI.DTO
{
    public class UserDto
    {
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public UserRole Role { get; set; }
    }
}
