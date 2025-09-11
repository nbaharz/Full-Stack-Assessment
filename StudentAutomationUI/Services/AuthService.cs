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
            _currentUser = CreateUserFromToken(payload.token, username);
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
            _currentUser = CreateUserFromToken(payload.token, email, firstName, lastName);
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

        private static User CreateUserFromToken(string jwt, string emailFallback, string? firstName = null, string? lastName = null)
        {
            try
            {
                var parts = jwt.Split('.');
                if (parts.Length < 2) return new User { Email = emailFallback, FirstName = firstName ?? string.Empty, LastName = lastName ?? string.Empty };
                string payloadJson = System.Text.Encoding.UTF8.GetString(Base64UrlDecode(parts[1]));
                var dict = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(payloadJson);
                var roleStr = dict != null && dict.TryGetValue("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", out var r)
                    ? r?.ToString() ?? string.Empty : string.Empty;
                var name = dict != null && dict.TryGetValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name", out var n)
                    ? n?.ToString() ?? string.Empty : string.Empty;
                var email = dict != null && dict.TryGetValue("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", out var e)
                    ? e?.ToString() ?? emailFallback : emailFallback;

                var userRole = roleStr switch
                {
                    "Admin" => UserRole.Admin,
                    "Teacher" => UserRole.Teacher,
                    "Student" => UserRole.Student,
                    _ => UserRole.Student
                };

                var splitName = (name ?? string.Empty).Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var first = firstName ?? splitName.FirstOrDefault() ?? string.Empty;
                var last = lastName ?? (splitName.Length > 1 ? string.Join(' ', splitName.Skip(1)) : string.Empty);

                return new User { Email = email, FirstName = first, LastName = last, Role = userRole, Username = email };
            }
            catch
            {
                return new User { Email = emailFallback, FirstName = firstName ?? string.Empty, LastName = lastName ?? string.Empty };
            }
        }

        private static byte[] Base64UrlDecode(string input)
        {
            string padded = input.Replace('-', '+').Replace('_', '/');
            switch (padded.Length % 4)
            {
                case 2: padded += "=="; break;
                case 3: padded += "="; break;
            }
            return Convert.FromBase64String(padded);
        }
    }
}