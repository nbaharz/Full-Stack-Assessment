using StudentAutomationAPI.Entities;
using StudentAutomationAPI.DTO;
namespace StudentAutomationAPI.Services.Interfaces
{
    public interface IUserService: IGenericService<User>
    {
        Task<User?> LoginAsync(string email, string password);
        Task<User> RegisterAsync(RegisterDto user);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
    }
}
