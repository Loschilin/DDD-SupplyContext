using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupplyContext.Domain;
using SupplyContext.Domain.Entities;
using SupplyContext.Domain.ValueObjects;

namespace SupplyContext.Infrastructure.Ef.ContextConfig
{
    internal class SupplyListEntityConfiguration : IEntityTypeConfiguration<SupplyList>
    {
        public void Configure(EntityTypeBuilder<SupplyList> builder)
        {
            builder.ToTable("SupplyLists", SupplyContextSchemes.Deault);

            builder.Property(e => e.BarCode)
                .HasConversion(e => e.ToString(), e => SupplyBarCode.Parse(e));

            builder.Property(e => e.FileKey)
                .HasConversion(e => e.ToString(), e => FileKey.Parse(e));

            builder.Property(e => e.FileKey);
            builder.Property(e => e.BarCode);

            builder.Property<int>("Id").ValueGeneratedOnAdd();
            builder.HasKey("Id");
            
        }
    }
}