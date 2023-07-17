using DotnetWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotnetWebAPI.ContextMappers
{
    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Purchase");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Value)
                .HasColumnName("Value")
                .HasColumnType("decimal")
                .HasPrecision(15, 2)
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .IsRequired();

            builder.Property(x => x.DeletedAt)
                .HasColumnName("DeletedAt");
        }
    }
}
