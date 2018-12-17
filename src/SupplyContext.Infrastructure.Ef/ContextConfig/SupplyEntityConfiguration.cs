using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplyContext.Domain;

namespace SupplyContext.Infrastructure.Ef.ContextConfig
{
    internal class SupplyEntityConfiguration : IEntityTypeConfiguration<Supply>
    {
        public void Configure(EntityTypeBuilder<Supply> builder)
        {
            builder.ToTable("Supplies", SupplyContextSchemes.Deault);

            builder.Property<int>("Id").ValueGeneratedOnAdd();
            builder.HasKey("Id");
            
            builder.Property<bool>("Deleted")
                .HasDefaultValue(false);

            builder.Property(e => e.Number);
            builder.HasIndex(e => e.Number);

            builder.Property(e => e.Date);
            builder.Property(e => e.ContractorCode);

            //builder.HasOne(e=>e.TitleList)
            //    .WithOne()
            //    .HasForeignKey(nameof(Supply), "ListId")
            //    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.TitleList);
        }

        
    }
}
