using Microsoft.EntityFrameworkCore;
using U3A.Model;
using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Components.Authorization;

namespace U3A.Database
{
    public class U3ADbContext : U3ADbContextBase {

        public ITenantInfo TenantInfo { get; set; }

        public U3ADbContext(TenantInfoEx tenantInfo, AuthenticationStateProvider AuthStateProvider) {
            // DI will pass in the tenant info for the current request.
            // ITenantInfo is also injectable.
            authenticationStateProvider= AuthStateProvider;
            TenantInfo = tenantInfo;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // Use the connection string to connect to the per-tenant database.
            optionsBuilder.UseSqlServer(TenantInfo.ConnectionString);
            optionsBuilder.LogTo(Console.WriteLine);
        }

    }
}