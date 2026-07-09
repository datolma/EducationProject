using EducationProject.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationProject.Infrastructure
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {
        public DbSet<Good> Goods => Set<Good>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=myDb;Username=postgres;Password=postgres");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GoodConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}