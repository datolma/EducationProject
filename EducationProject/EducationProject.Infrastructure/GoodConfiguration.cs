using EducationProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationProject.Infrastructure
{
    public class GoodConfiguration : IEntityTypeConfiguration<Good>
    {
        public void Configure(EntityTypeBuilder<Good> builder)
        {
            builder.HasKey(g => g.Id);

            builder.HasIndex(x => x.Name);

            builder.Property(g => g.Price)
                   .IsRequired()
                   .HasPrecision(18, 2);

            builder.Ignore(x => x.FinalPrice);
        }
    }
}
