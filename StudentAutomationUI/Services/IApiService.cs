using System.Net.Http.Json;

namespace StudentAutomationUI.Services
{
    public interface IApiService
    {
        // Users
        Task<HttpResponseMessage> RegisterAsync(object dto);
        Task<HttpResponseMessage> LoginAsync(object dto);

        // Students
        Task<HttpResponseMessage> GetStudentsAsync();
        Task<HttpResponseMessage> GetStudentByIdAsync(Guid id);
        Task<HttpResponseMessage> CreateStudentAsync(object student);
        Task<HttpResponseMessage> UpdateStudentAsync(Guid id, object student);
        Task<HttpResponseMessage> DeleteStudentAsync(Guid id);

        // Teachers
        Task<HttpResponseMessage> GetTeachersAsync();
        Task<HttpResponseMessage> GetTeacherByIdAsync(Guid id);
        Task<HttpResponseMessage> CreateTeacherAsync(object teacher);
        Task<HttpResponseMessage> UpdateTeacherAsync(Guid id, object teacher);
        Task<HttpResponseMessage> DeleteTeacherAsync(Guid id);
        Task<HttpResponseMessage> GetTeacherCoursesAsync(Guid teacherId);

        // Courses
        Task<HttpResponseMessage> GetCoursesAsync();
        Task<HttpResponseMessage> GetCourseByIdAsync(Guid id);
        Task<HttpResponseMessage> CreateCourseAsync(object courseCreateDto);
        Task<HttpResponseMessage> UpdateCourseAsync(Guid id, object course);
        Task<HttpResponseMessage> DeleteCourseAsync(Guid id);
        Task<HttpResponseMessage> UpdateCourseStatusAsync(Guid id, string status);

        // Grades
        Task<HttpResponseMessage> AddGradeAsync(object gradeCreateDto);
        Task<HttpResponseMessage> GetGradesByStudentAsync(Guid studentId);

        // Attendance
        Task<HttpResponseMessage> AddAttendanceAsync(object attendanceCreateDto);
        Task<HttpResponseMessage> GetAttendanceByStudentAsync(Guid studentId);

        // Comments
        Task<HttpResponseMessage> AddCommentAsync(object commentCreateDto);
        Task<HttpResponseMessage> GetCommentsByStudentAsync(Guid studentId);
    }
}


