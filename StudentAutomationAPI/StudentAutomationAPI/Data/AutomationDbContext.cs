using Microsoft.EntityFrameworkCore;
using StudentAutomationAPI.Entities;
namespace StudentAutomationAPI.Data
{
    public class AutomationDbContext: DbContext
    {
        public AutomationDbContext(DbContextOptions<AutomationDbContext> options)
            : base(options)
        {
        }

        // Ana varlıklar
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;

        // İlişki tablolari
        public DbSet<Enrollment> Enrollments { get; set; } = null!;
        public DbSet<Grade> Grades { get; set; } = null!;
        public DbSet<Attendance> Attendances { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
