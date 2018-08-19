using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace HealthMonitor.DataUploader.Entity
{
    public class EntityContext: DbContext
    {
        public EntityContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity=> 
            {
                entity.ToTable("User");
                entity.Property(e => e.Id).HasColumnName("Id");
            });
            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.ToTable("UserHealthTracker");
            });
        }
    }
}
