using cinema.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cinema.Data.Configuration
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(s => s.id);

            builder.HasOne(s => s.movie)
                .WithOne(m => m.session)
                .HasForeignKey<Session>(s => s.movie_id);

            builder.HasOne(s => s.hall)
                .WithOne(h => h.session)
                .HasForeignKey<Session>(s => s.hall_id);
        }
    }
}
