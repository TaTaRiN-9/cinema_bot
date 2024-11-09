using cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cinema.Data.Configuration
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasKey(s => s.id);

            // внешний ключ к билету
            builder.HasOne(s => s.ticket)
                .WithOne(s => s.seat)
                .HasForeignKey<Ticket>(s => s.seat_id);

            builder.HasOne(s => s.row)
                .WithMany(r => r.seats)
                .HasForeignKey(s => s.row_id);
        }
    }
}
