using cinema.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cinema.Data.Configuration
{
    public class RowConfiguration : IEntityTypeConfiguration<Row>
    {
        public void Configure(EntityTypeBuilder<Row> builder) 
        {
            builder.HasKey(r => r.id);

            builder.HasOne(r => r.hall)
                .WithMany(h => h.rows)
                .HasForeignKey(r => r.hall_id);
        }
    }
}
