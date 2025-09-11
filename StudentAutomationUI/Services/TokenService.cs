using Microsoft.JSInterop;

namespace StudentAutomationUI.Services
{
    public class TokenService
    {
        private const string StorageKey = "auth_token";
        private readonly IJSRuntime _js;
        private readonly IApiService _apiService;

        public string? Token { get; private set; }

        public TokenService(IJSRuntime js, IApiService apiService)
        {
            _js = js;
            _apiService = apiService;
        }

        public async Task InitializeAsync()
        {
            Token = await _js.InvokeAsync<string?>("localStorage.getItem", StorageKey);
            _apiServiceAsApi()?.SetBearer(Token);
        }

        public async Task SetTokenAsync(string? token)
        {
            Token = token;
            if (string.IsNullOrWhiteSpace(token))
            {
                await _js.InvokeVoidAsync("localStorage.removeItem", StorageKey);
            }
            else
            {
                await _js.InvokeVoidAsync("localStorage.setItem", StorageKey, token);
            }
            _apiServiceAsApi()?.SetBearer(Token);
        }

        private ApiService? _apiServiceAsApiCache;
        private ApiService? _apiServiceAsApi()
        {
            if (_apiServiceAsApiCache != null) return _apiServiceAsApiCache;
            _apiServiceAsApiCache = _apiService as ApiService;
            return _apiServiceAsApiCache;
        }
    }
}


