using Microsoft.EntityFrameworkCore;

namespace EducationProject.Core
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Good> Goods => Set<Good>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=mydb;Username=postgres;Password=postgres");
        }
    }
}