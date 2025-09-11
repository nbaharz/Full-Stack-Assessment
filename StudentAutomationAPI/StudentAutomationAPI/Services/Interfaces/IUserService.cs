using StudentAutomationAPI.Entities;
namespace StudentAutomationAPI.Services.Interfaces
{
    public interface IUserService: IGenericService<User>
    {
        Task<User?> LoginAsync(string email, string password);
        Task<User> RegisterAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
    }
}
