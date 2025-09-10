using Microsoft.EntityFrameworkCore;
using StudentAutomationAPI.Data;
using StudentAutomationAPI.DI;

namespace StudentAutomationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // PostgreSQL DbContext
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AutomationDbContext>(options =>
                options.UseNpgsql(connectionString));

            // Add services to the container
            builder.Services.AddControllers();

            // Swagger UI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Dependency Injection
            RepositoryDI.Init(builder.Services);

            var app = builder.Build();

            // Her zaman Swagger aktif
            app.UseSwagger();
            app.UseSwaggerUI();

            
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
