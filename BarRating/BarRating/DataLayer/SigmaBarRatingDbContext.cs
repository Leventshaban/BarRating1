using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class SigmaBarRatingDbContext : DbContext
    {
        public SigmaBarRatingDbContext() : base()
        {
                
        }
        public SigmaBarRatingDbContext(DbContextOptions options) : base(options)
        {
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-CV7A96A\\SQLEXPRESS;Database=BarRatingDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Reviews).WithOne(b => b.User);
            modelBuilder.Entity<Bar>().HasMany(b => b.Reviews).WithOne(r => r.Bar);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
