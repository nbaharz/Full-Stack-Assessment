using StudentAutomationAPI.Services.Interfaces;
using StudentAutomationAPI.Entities;
using StudentAutomationAPI.Repositories.Implementations;

namespace StudentAutomationAPI.Services.Implementations
{
    public class GradeService : GenericService<Grade>, IGradeService
    {
        public GradeService(IGenericRepository<Grade> repository) : base(repository)
        {
        }

        public Task AddGradeAsync(Guid studentId, Guid courseId, double value)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Grade>> GetByStudentIdAsync(Guid studentId)
        {
            throw new NotImplementedException();
        }
    }
}
