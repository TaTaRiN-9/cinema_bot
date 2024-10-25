using cinema.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cinema.Data.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => t.id);

            builder.HasIndex(
                t => new
                {
                    t.row_number,
                    t.seat_number
                })
                .IsUnique();

            // устанавливаем связь один ко многим между пользователем и билетами
            builder.HasOne(t => t.user)
                .WithMany(u => u.tickets)
                .HasForeignKey(t => t.user_id);

            builder.HasOne(t => t.session)
                .WithMany(s => s.tickets)
                .HasForeignKey(t => t.session_id);
        }
    }
}
