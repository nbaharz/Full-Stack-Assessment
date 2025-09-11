using System.Linq.Expressions;
using StudentAutomationAPI.DTO;
using StudentAutomationAPI.Entities;
using StudentAutomationAPI.Repositories.Implementations;
using StudentAutomationAPI.Services.Interfaces;

namespace StudentAutomationAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;

        public UserService(IUserRepository userRepository, ITeacherService teacherService, IStudentService studentService)
        {
            _userRepository = userRepository;
            _teacherService = teacherService;
            _studentService = studentService;
        }

        public async Task<User> AddAsync(User entity)
        {
            await _userRepository.AddAsync(entity);
            await _userRepository.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                _userRepository.Delete(user);
                await _userRepository.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate)
        {
            return await _userRepository.FindAsync(predicate);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = (await _userRepository.FindAsync(u => u.Email == email)).FirstOrDefault();
            if (user == null) return null;

            // hash dogrulama
            bool isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            return isValid ? user : null;
        }

        public async Task<User> RegisterAsync(RegisterDto dto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User
            {
                Email = dto.Email,
                FullName = dto.FullName,
                PasswordHash = hashedPassword,
                Role = dto.Role
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            // Create role-specific entity for admin-created accounts as well
            if (user.Role == UserRole.Teacher)
            {
                var teacher = new Teacher { UserId = user.Id, Department = string.Empty };
                await _teacherService.AddAsync(teacher);
            }
            else if (user.Role == UserRole.Student)
            {
                var student = new Student { UserId = user.Id, StudentNumber = $"S-{DateTime.UtcNow:yyyyMMddHHmmss}" };
                await _studentService.AddAsync(student);
            }

            return user;
        }

        public async Task<User> UpdateAsync(User entity)
        {
            _userRepository.Update(entity);
            await _userRepository.SaveChangesAsync();
            return entity;
        }
    }
}
