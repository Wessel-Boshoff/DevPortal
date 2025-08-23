using Microsoft.EntityFrameworkCore;
using WebAppPortalSite.Common.Enums;
using WebAppPortalSite.Database.Tables.dbo;
using WebAppPortalSite.Database.Tables.log;

namespace WebAppPortalSite.Database
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(e => e.Role).HasConversion(v => v.ToString(), v => (Role)Enum.Parse(typeof(Role), v));
            modelBuilder.Entity<User>().Property(e => e.RegistrationStatus).HasConversion(v => v.ToString(), v => (RegistrationStatus)Enum.Parse(typeof(RegistrationStatus), v));

        }

        //dbo
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        //log
        public DbSet<Request> Requests { get; set; }
        public DbSet<Event> Events { get; set; }

    }
}
