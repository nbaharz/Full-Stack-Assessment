using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Services.Interfaces
{
    public interface IAttendanceService: IGenericService<Attendance>
    {
        Task AddAttendanceAsync(Guid studentId, Guid courseId, DateTime date, string status);
        Task<IEnumerable<Attendance>> GetByStudentIdAsync(Guid studentId);
    }
}
