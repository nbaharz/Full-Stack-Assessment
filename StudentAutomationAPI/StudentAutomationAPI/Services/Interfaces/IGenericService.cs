using StudentAutomationAPI.Entities;
using System.Linq.Expressions;

namespace StudentAutomationAPI.Services.Interfaces
{
    public interface IGenericService<T> where T:BaseEntity
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
