using StudentAutomationAPI.Entities;
namespace StudentAutomationAPI.Data
{
    public class AutomationDbContextSeed
    {
        public static async Task SeedAsync(AutomationDbContext context)
        {
            if (!context.Users.Any())
            {
                var admin = new User
                {
                    Id = Guid.NewGuid(),
                    Email = "admin@test.com",
                    FullName = "Admin User",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                    Role = UserRole.Admin
                };

                var teacher = new User
                {
                    Id = Guid.NewGuid(),
                    Email = "teacher@test.com",
                    FullName = "Teacher User",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Teacher123!"),
                    Role = UserRole.Teacher
                };

                var student = new User
                {
                    Id = Guid.NewGuid(),
                    Email = "student@test.com",
                    FullName = "Student User",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Student123!"),
                    Role = UserRole.Student

                };

                context.Users.AddRange(admin, teacher, student);
                await context.SaveChangesAsync();
            }
        }
    }
}
