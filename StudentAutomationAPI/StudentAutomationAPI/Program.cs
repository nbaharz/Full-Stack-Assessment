using Microsoft.EntityFrameworkCore;
using StudentAutomationAPI.Data;

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

            // Swagger her zaman a��k
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Her zaman Swagger aktif
            app.UseSwagger();
            app.UseSwaggerUI();

            // Docker�da HTTPS kullanmad���m�z i�in kald�rd�k
            // app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
