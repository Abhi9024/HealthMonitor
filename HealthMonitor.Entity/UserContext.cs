using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthMonitor.Entity
{
    public class UserContext : IdentityDbContext<UserCredential>
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserHealthTracker> UserHealthTracker { get; set; }
        public DbSet<EventLog> EventLog { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Name).HasColumnType("varchar(200)");
                entity.Property(e => e.Age).HasColumnType("int");
                entity.Property(e => e.Gender).HasColumnType("int");
            });
            modelBuilder.Entity<EventLog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.EventId).HasColumnName("EventID");
                entity.Property(e => e.LogLevel).HasMaxLength(50);
                entity.Property(e => e.Message).HasMaxLength(4000);
            });
            modelBuilder.Entity<UserCredential>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnType("varchar(200)");
                entity.Property(e => e.Password).HasColumnType("nvarchar(max)");
            });
        }
    }
}
