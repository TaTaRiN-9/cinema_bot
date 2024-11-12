using cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cinema.Data.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.id);

            builder.HasIndex(m => m.title).IsUnique();

            builder.Property(m => m.title).HasMaxLength(50).IsRequired();

            builder.Property(m => m.description).HasMaxLength(250).IsRequired();

            builder.Property(m => m.duration).IsRequired();
        }
    }
}
