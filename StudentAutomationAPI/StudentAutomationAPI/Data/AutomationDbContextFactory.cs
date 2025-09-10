using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace StudentAutomationAPI.Data
{
    public class AutomationDbContextFactory : IDesignTimeDbContextFactory<AutomationDbContext>
    {
        public AutomationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json") 
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AutomationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString);

            return new AutomationDbContext(optionsBuilder.Options);
        }
    }
}
