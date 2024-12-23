using cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cinema.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.id);

            builder.HasIndex(u => new { u.chat_id })
                .IsUnique();

            builder.HasIndex(u => u.phone_number).IsUnique();

            builder.Property(u => u.chat_id)
                .IsRequired();

            builder.Property(u => u.phone_number)
                .HasMaxLength(11)
                .IsRequired();
        }
    }
}
