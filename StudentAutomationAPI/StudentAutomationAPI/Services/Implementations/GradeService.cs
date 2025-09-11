using StudentAutomationAPI.Services.Interfaces;
using StudentAutomationAPI.Entities;
using StudentAutomationAPI.Repositories.Implementations;
using StudentAutomationAPI.DTO;

namespace StudentAutomationAPI.Services.Implementations
{
    public class GradeService : GenericService<Grade>, IGradeService
    {
        private readonly IGenericRepository<Grade> _gradeRepository;

        public GradeService(IGenericRepository<Grade> repository) : base(repository)
        {
            _gradeRepository = repository;
        }

        public async Task AddGradeAsync(GradeCreateDto dto )
        {
            var grade = new Grade
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId,
                GradeValue = dto.Value,
            };

            await _gradeRepository.AddAsync(grade);
        }

        public async Task<IEnumerable<Grade>> GetByStudentIdAsync(Guid studentId)
        {
            return await _gradeRepository.FindAsync(g => g.StudentId == studentId);
        }
    }
}
