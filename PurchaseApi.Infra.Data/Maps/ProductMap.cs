using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseApi.Domain.Entities;

namespace PurchaseApi.Infra.Data.Maps;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("product");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("idproduct").UseIdentityColumn();
        builder.Property(c => c.Name).HasColumnName("name");
        builder.Property(c => c.Price).HasColumnName("price");
        builder.Property(c => c.CodeErp).HasColumnName("codeerp");

        builder.HasMany(c => c.Purchases).WithOne(p => p.Product)
            .HasForeignKey(c => c.ProductId);
    }
}