# Student Automation System

## Project Description
This project is a simple student automation system designed as a full-stack application.  
The main goal is to implement **user management, CRUD operations for students/teachers/courses, grade and attendance tracking** within a fully functional application.  

Key Features:
- **User Roles**: Admin, Teacher, Student  
- **Student Management**: Add, update, delete, list students  
- **Teacher Management**: Add, update, delete, list teachers  
- **Course Management**: Create courses, update status, assign/remove students  
- **Grades & Attendance**: Teachers can assign grades, students can view them, attendance tracking included  
- **Frontend Pages**: Login, Register, Dashboard, Student/Teacher/Course/Grade screens  

---

## Technologies Used
- **Backend**: ASP.NET Core 9 (Web API)  
- **ORM**: Entity Framework Core  
- **Frontend**: Blazor WebAssembly  
- **Database**: PostgreSQL  
- **Containerization**: Docker & Docker Compose  
- **Version Control**: Git + GitHub  

---

## Installation & Run Instructions (with Docker)

### 1. Clone the repository
bash
git clone https://github.com/nbaharz/Full-Stack-Assessment.git
cd Full-Stack-Assessment

### 2. Create .env file
CONNECTION_STRING=Host=student_postgres;Port=5432;Database=studentdb;Username=postgres;Password=postgres

### 3. Run with docker compose
docker-compose up --build

### Apply Migrations
docker exec -it student_backend dotnet ef database update --project StudentAutomationAPI


