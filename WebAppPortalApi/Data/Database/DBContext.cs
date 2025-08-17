using Microsoft.EntityFrameworkCore;
using WebAppPortalApi.Common.Enums;
using WebAppPortalApi.Data.Database.Tables.dbo;
using WebAppPortalApi.Data.Database.Tables.log;

namespace WebAppPortalApi.Data.Database
{
    public class DBContext : DbContext
    {
        public DBContext()
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

        //log
        public DbSet<Request> Requests { get; set; }
        public DbSet<Event> Events { get; set; }

    }
}
