using StudentAutomationAPI.Entities;
using StudentAutomationAPI.Repositories.Implementations;
using StudentAutomationAPI.Services.Interfaces;

namespace StudentAutomationAPI.Services.Implementations
{

    public class AttendanceService : GenericService<Attendance>, IAttendanceService
    {
        private readonly Repositories.Implementations.IAttendanceRepository _attendanceRepository;
        public AttendanceService(Repositories.Implementations.IAttendanceRepository repository) : base(repository)
        {
            _attendanceRepository = repository;
        }

        public async Task AddAttendanceAsync(Guid studentId, Guid courseId, DateTime date, AttendanceStatus status) //bunu dto yap
        {
            var attendance = new Attendance
            {
                StudentId = studentId,
                CourseId = courseId, //idleri kullanicidan alamam
                Date = date,
                Status = status
            };
            await _attendanceRepository.AddAsync(attendance);
        }


        public async Task<IEnumerable<Attendance>> GetByStudentIdAsync(Guid studentId)
        {
            return await _attendanceRepository.FindAsync(a => a.StudentId == studentId); 
        }
    }
}
