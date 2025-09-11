using System.Net.Http.Headers;
using System.Web;
using System.Net.Http.Json;


namespace StudentAutomationUI.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private string? _bearerToken;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void SetBearerToken(string? token)
        {
            _bearerToken = token;
            if (!string.IsNullOrWhiteSpace(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            else
            {
                _httpClient.DefaultRequestHeaders.Authorization = null;
            }
        }

        // helper for TokenService
        public void SetBearer(string? token) => SetBearerToken(token);

        // Users
        public Task<HttpResponseMessage> RegisterAsync(object dto)
            => _httpClient.PostAsJsonAsync("api/Users/register", dto);

        public Task<HttpResponseMessage> LoginAsync(object dto)
            => _httpClient.PostAsJsonAsync("api/Users/login", dto);

        // Students
        public Task<HttpResponseMessage> GetStudentsAsync()
            => _httpClient.GetAsync("api/Student");

        public Task<HttpResponseMessage> GetStudentByIdAsync(Guid id)
            => _httpClient.GetAsync($"api/Student/{id}");

        public Task<HttpResponseMessage> GetStudentMeAsync()
            => _httpClient.GetAsync("api/Student/me");

        public Task<HttpResponseMessage> CreateStudentAsync(object student)
            => _httpClient.PostAsJsonAsync("api/Student", student);

        public Task<HttpResponseMessage> UpdateStudentAsync(Guid id, object student)
            => _httpClient.PutAsJsonAsync($"api/Student/{id}", student);

        public Task<HttpResponseMessage> DeleteStudentAsync(Guid id)
            => _httpClient.DeleteAsync($"api/Student/{id}");

        // Teachers
        public Task<HttpResponseMessage> GetTeachersAsync()
            => _httpClient.GetAsync("api/Teacher");

        public Task<HttpResponseMessage> GetTeacherByIdAsync(Guid id)
            => _httpClient.GetAsync($"api/Teacher/{id}");

        public Task<HttpResponseMessage> CreateTeacherAsync(object teacher)
            => _httpClient.PostAsJsonAsync("api/Teacher", teacher);

        public Task<HttpResponseMessage> UpdateTeacherAsync(Guid id, object teacher)
            => _httpClient.PutAsJsonAsync($"api/Teacher/{id}", teacher);

        public Task<HttpResponseMessage> DeleteTeacherAsync(Guid id)
            => _httpClient.DeleteAsync($"api/Teacher/{id}");

        public Task<HttpResponseMessage> GetTeacherCoursesAsync(Guid teacherId)
            => _httpClient.GetAsync($"api/Teacher/{teacherId}/courses");

        // Courses
        public Task<HttpResponseMessage> GetCoursesAsync()
            => _httpClient.GetAsync("api/Course");

        public Task<HttpResponseMessage> GetCourseByIdAsync(Guid id)
            => _httpClient.GetAsync($"api/Course/{id}");

        public Task<HttpResponseMessage> CreateCourseAsync(object courseCreateDto)
            => _httpClient.PostAsJsonAsync("api/Course", courseCreateDto);

        public Task<HttpResponseMessage> UpdateCourseAsync(Guid id, object course)
            => _httpClient.PutAsJsonAsync($"api/Course/{id}", course);

        public Task<HttpResponseMessage> DeleteCourseAsync(Guid id)
            => _httpClient.DeleteAsync($"api/Course/{id}");

        public Task<HttpResponseMessage> UpdateCourseStatusAsync(Guid id, string status)
        {
            var uri = $"api/Course/{id}/status?status={HttpUtility.UrlEncode(status)}";
            return _httpClient.PutAsync(uri, null);
        }

        // Grades
        public Task<HttpResponseMessage> AddGradeAsync(object gradeCreateDto)
            => _httpClient.PostAsJsonAsync("api/Grade", gradeCreateDto);

        public Task<HttpResponseMessage> GetGradesByStudentAsync(Guid studentId)
            => _httpClient.GetAsync($"api/Grade/student/{studentId}");

        // Attendance
        public Task<HttpResponseMessage> AddAttendanceAsync(object attendanceCreateDto)
            => _httpClient.PostAsJsonAsync("api/Attendance", attendanceCreateDto);

        public Task<HttpResponseMessage> GetAttendanceByStudentAsync(Guid studentId)
            => _httpClient.GetAsync($"api/Attendance/student/{studentId}");

        // Comments
        public Task<HttpResponseMessage> AddCommentAsync(object commentCreateDto)
            => _httpClient.PostAsJsonAsync("api/Comment", commentCreateDto);

        public Task<HttpResponseMessage> GetCommentsByStudentAsync(Guid studentId)
            => _httpClient.GetAsync($"api/Comment/student/{studentId}");
    }
}


