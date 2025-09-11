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
```bash
git clone https://github.com/nbaharz/Full-Stack-Assessment.git
cd Full-Stack-Assessment
```

### 2. Create `.env` file
```env
CONNECTION_STRING=Host=student_postgres;Port=5432;Database=studentdb;Username=postgres;Password=postgres
```

> Update `Username` and `Password` according to your `docker-compose.yml` configuration.  

### 3. Run with Docker Compose
```bash
docker-compose up --build
```

- **Backend API** → `http://localhost:7117/swagger`  
- **Frontend (Blazor UI)** → `http://localhost:5001`  
- **PostgreSQL** → `localhost:5432`  

### 4. Apply Migrations
If the database is empty, apply EF Core migrations inside the backend container:
```bash
docker exec -it student_backend dotnet ef database update --project StudentAutomationAPI
```

(`student_backend` → replace with your backend container name if different.)  

---

## Test User Accounts

### Admin
- **Email**: `admin@test.com`  
- **Password**: `Admin123!`  

### Teacher
- **Email**: `teacher@test.com`  
- **Password**: `Teacher123!`  

### Student
- **Email**: `student@test.com`  
- **Password**: `Student123!`  

## Bonus Features

- **Docker Support**  
  The backend (ASP.NET Core API) and PostgreSQL database are containerized with **Docker Compose** for easy setup and deployment.  

- **Swagger / API Documentation**  
  The project includes **Swagger (OpenAPI)** for exploring and testing the backend API endpoints interactively.  

- **Clean Code Principles**  
  The codebase follows **clean code practices** such as separation of concerns, consistent naming, repository-service pattern, and layered architecture for better maintainability.  
