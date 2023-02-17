using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using U3A.Model;
using Microsoft.AspNetCore.Identity;

namespace U3A.Database
{
    public class U3ADbContextSeed : U3ADbContextBase
    {

        static IConfigurationRoot _configuration;

        public U3ADbContextSeed() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
                _configuration = builder.Build();
                var cnstr = _configuration.GetConnectionString("SeedConnectionString");
                optionsBuilder.UseSqlServer(cnstr);
            }
        }
    }
}