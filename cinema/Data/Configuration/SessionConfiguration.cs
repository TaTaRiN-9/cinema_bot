using cinema.Data.Entities;
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
                .WithMany(m => m.sessions)
                .HasForeignKey(s => s.movie_id);

            builder.HasOne(s => s.hall)
                .WithMany(h => h.sessions)
                .HasForeignKey(s => s.hall_id);
        }
    }
}
