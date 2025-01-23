using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Plumberz.Core.Entities.Account;
using Plumberz.Core.Entities.Departments;
using Plumberz.Core.Entities.Technicals;

namespace Plumberz.DAL.Contexts
{
    public class PlumberzDbContext : IdentityDbContext<AppUser>
    {
        public PlumberzDbContext(DbContextOptions<PlumberzDbContext> opt) : base(opt) { }
        public DbSet<Technical> Technicals { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PlumberzDbContext).Assembly);
        }
    }
}
