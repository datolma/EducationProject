using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EducationProject.Infrastructure
{
    // Класс должен реализовывать интерфейс IDesignTimeDbContextFactory<ApplicationContext>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            // Настраиваем параметры подключения
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=myDb;Username=postgres;Password=postgres");

            // Возвращаем новый экземпляр контекста
            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}