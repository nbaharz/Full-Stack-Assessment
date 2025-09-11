using StudentAutomationUI.Models;

namespace StudentAutomationUI.Services
{
    public class DataService
    {
        private List<Student> _students = new();
        private List<Teacher> _teachers = new();
        private List<Course> _courses = new();
        private List<Grade> _grades = new();
        private List<Attendance> _attendances = new();

        public DataService()
        {
            InitializeSampleData();
        }

        private void InitializeSampleData()
        {
            // Sample Teachers
            _teachers.AddRange(new[]
            {
                new Teacher { Id = 1, TeacherNumber = "T001", FirstName = "John", LastName = "Doe", Email = "john.doe@school.com", Phone = "555-0101", Department = "Mathematics" },
                new Teacher { Id = 2, TeacherNumber = "T002", FirstName = "Jane", LastName = "Smith", Email = "jane.smith@school.com", Phone = "555-0102", Department = "Physics" },
                new Teacher { Id = 3, TeacherNumber = "T003", FirstName = "Bob", LastName = "Johnson", Email = "bob.johnson@school.com", Phone = "555-0103", Department = "Chemistry" }
            });

            // Sample Courses
            _courses.AddRange(new[]
            {
                new Course { Id = 1, CourseCode = "MATH101", CourseName = "Calculus I", Description = "Introduction to Calculus", Credits = 4, TeacherId = 1 },
                new Course { Id = 2, CourseCode = "PHYS101", CourseName = "Physics I", Description = "Mechanics and Thermodynamics", Credits = 4, TeacherId = 2 },
                new Course { Id = 3, CourseCode = "CHEM101", CourseName = "Chemistry I", Description = "General Chemistry", Credits = 3, TeacherId = 3 }
            });

            // Sample Students
            _students.AddRange(new[]
            {
                new Student { Id = 1, StudentNumber = "S001", FirstName = "Alice", LastName = "Brown", Email = "alice.brown@school.com", Phone = "555-0201", BirthDate = new DateTime(2000, 5, 15), Class = "A1" },
                new Student { Id = 2, StudentNumber = "S002", FirstName = "Charlie", LastName = "Wilson", Email = "charlie.wilson@school.com", Phone = "555-0202", BirthDate = new DateTime(2000, 8, 22), Class = "A1" },
                new Student { Id = 3, StudentNumber = "S003", FirstName = "Diana", LastName = "Davis", Email = "diana.davis@school.com", Phone = "555-0203", BirthDate = new DateTime(1999, 12, 10), Class = "A2" }
            });

            // Sample Grades
            _grades.AddRange(new[]
            {
                new Grade { Id = 1, StudentId = 1, CourseId = 1, ExamType = "Midterm", Score = 85, ExamDate = new DateTime(2024, 3, 15) },
                new Grade { Id = 2, StudentId = 1, CourseId = 1, ExamType = "Final", Score = 90, ExamDate = new DateTime(2024, 5, 20) },
                new Grade { Id = 3, StudentId = 2, CourseId = 1, ExamType = "Midterm", Score = 78, ExamDate = new DateTime(2024, 3, 15) },
                new Grade { Id = 4, StudentId = 2, CourseId = 2, ExamType = "Quiz", Score = 92, ExamDate = new DateTime(2024, 4, 10) }
            });

            // Sample Attendance
            _attendances.AddRange(new[]
            {
                new Attendance { Id = 1, StudentId = 1, CourseId = 1, Date = new DateTime(2024, 3, 1), IsPresent = true },
                new Attendance { Id = 2, StudentId = 1, CourseId = 1, Date = new DateTime(2024, 3, 3), IsPresent = true },
                new Attendance { Id = 3, StudentId = 1, CourseId = 1, Date = new DateTime(2024, 3, 5), IsPresent = false },
                new Attendance { Id = 4, StudentId = 2, CourseId = 1, Date = new DateTime(2024, 3, 1), IsPresent = true },
                new Attendance { Id = 5, StudentId = 2, CourseId = 2, Date = new DateTime(2024, 3, 2), IsPresent = true }
            });
        }

        // Student methods
        public async Task<List<Student>> GetStudentsAsync()
        {
            return await Task.FromResult(_students);
        }

        public async Task<Student?> GetStudentAsync(int id)
        {
            return await Task.FromResult(_students.FirstOrDefault(s => s.Id == id));
        }

        // Teacher methods
        public async Task<List<Teacher>> GetTeachersAsync()
        {
            return await Task.FromResult(_teachers);
        }

        public async Task<Teacher?> GetTeacherAsync(int id)
        {
            return await Task.FromResult(_teachers.FirstOrDefault(t => t.Id == id));
        }

        // Course methods
        public async Task<List<Course>> GetCoursesAsync()
        {
            return await Task.FromResult(_courses);
        }

        public async Task<Course?> GetCourseAsync(int id)
        {
            return await Task.FromResult(_courses.FirstOrDefault(c => c.Id == id));
        }

        // Grade methods
        public async Task<List<Grade>> GetGradesAsync()
        {
            return await Task.FromResult(_grades);
        }

        public async Task<List<Grade>> GetGradesByStudentAsync(int studentId)
        {
            return await Task.FromResult(_grades.Where(g => g.StudentId == studentId).ToList());
        }

        // Attendance methods
        public async Task<List<Attendance>> GetAttendancesAsync()
        {
            return await Task.FromResult(_attendances);
        }

        public async Task<List<Attendance>> GetAttendancesByStudentAsync(int studentId)
        {
            return await Task.FromResult(_attendances.Where(a => a.StudentId == studentId).ToList());
        }
    }
}