using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}


