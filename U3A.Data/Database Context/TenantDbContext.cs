// Copyright Finbuckle LLC, Andrew White, and Contributors.
// Refer to the solution LICENSE file for more inforation.

using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.Stores;
using Microsoft.EntityFrameworkCore;
using U3A.Model;

namespace U3A.Database
{

    public class TenantStoreDbContext : EFCoreStoreDbContext<TenantInfoEx>
    {
        public TenantStoreDbContext(DbContextOptions<TenantStoreDbContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TenantInfoEx>().HasData(
                        new TenantInfoEx {
                            Id = "9D36C579-9D45-4ACE-8260-7673DBF53572",
                            State = "NSW",
                            Identifier = "demo",
                            Name = "U3A Demonstration Only",
                            Website = "https://eastlakes.u3anet.org.au/",
                            ConnectionString= "Data Source=tcp:u3admin-server.database.windows.net,1433;Initial Catalog=U3A;User Id=u3admin-server-admin@u3admin-server.database.windows.net;Password=1JYL735FP13D1T1R$"
                        }
                       );
        }
    }
}