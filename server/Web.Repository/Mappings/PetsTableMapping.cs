using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Models.Tables;

namespace Web.Repository.Mappings
{
    public class PetsTableMapping : IEntityTypeConfiguration<PetsTable>
    {
        public void Configure(EntityTypeBuilder<PetsTable> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Type).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(200);

        }
    }
}
