using Microsoft.EntityFrameworkCore;
using PasswordManager_API.Entities;

namespace PasswordManager_API.Context
{

    public class PasswordManagerDbContext : DbContext
    {

        public DbSet<LookupType> LookupTypes { get; set; }
        public DbSet<LookupItem> LookupItems { get; set; }
        public PasswordManagerDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
