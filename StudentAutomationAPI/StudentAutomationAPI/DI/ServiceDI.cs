using StudentAutomationAPI.Repositories.Implementations;
using StudentAutomationAPI.Services.Interfaces;
using StudentAutomationAPI.Services.Implementations;

namespace StudentAutomationAPI.DI
{
    public static class ServiceDI
    {
        public static void Init(IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICourseStudentService, CourseStudentService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IGradeService, GradeService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IUserService, UserService>();

        }
    }
}
