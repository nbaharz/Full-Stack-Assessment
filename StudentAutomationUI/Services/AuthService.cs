using StudentAutomationUI.Models;
using System.Net.Http.Json;

namespace StudentAutomationUI.Services
{
    public class AuthService
    {
        private readonly IApiService _apiService;
        private readonly TokenService _tokenService;
        private User? _currentUser;

        public User? CurrentUser => _currentUser;
        public bool IsAuthenticated => _currentUser != null;

        public AuthService(IApiService apiService, TokenService tokenService)
        {
            _apiService = apiService;
            _tokenService = tokenService;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            // Backend expects email/password for login
            var response = await _apiService.LoginAsync(new { email = username, password });
            if (!response.IsSuccessStatusCode) return false;

            var payload = await response.Content.ReadFromJsonAsync<TokenResponse>();
            if (payload == null || string.IsNullOrWhiteSpace(payload.token)) return false;

            await _tokenService.SetTokenAsync(payload.token);

            // Minimal current user placeholder; in real app, decode JWT or fetch profile
            _currentUser = new User { Username = username, Email = username };
            return true;
        }

        public async Task<bool> RegisterAsync(string username, string email, string password, string firstName, string lastName, UserRole role)
        {
            var fullName = string.Join(' ', new[] { firstName, lastName }.Where(s => !string.IsNullOrWhiteSpace(s)));
            var response = await _apiService.RegisterAsync(new { email, fullName, password, role });
            if (!response.IsSuccessStatusCode) return false;

            var payload = await response.Content.ReadFromJsonAsync<TokenResponse>();
            if (payload == null || string.IsNullOrWhiteSpace(payload.token)) return false;

            await _tokenService.SetTokenAsync(payload.token);
            _currentUser = new User { Username = username, Email = email, FirstName = firstName, LastName = lastName, Role = role };
            return true;
        }

        public void Logout()
        {
            _currentUser = null;
            _ = _tokenService.SetTokenAsync(null);
        }

        private class TokenResponse
        {
            public string token { get; set; } = string.Empty;
        }
    }
}