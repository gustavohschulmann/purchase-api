using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseApi.Domain.Entities;

namespace PurchaseApi.Infra.Data.Maps;

public class PurchaseMap : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable("purchase");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("idpurchase").UseIdentityColumn();
        builder.Property(c => c.PersonId).HasColumnName("idperson");
        builder.Property(c => c.ProductId).HasColumnName("idproduto");
        builder.Property(c => c.Date).HasColumnName("datepurchase");

        builder.HasOne(c => c.Person).WithMany(p => p.Purchases);
        builder.HasOne(c => c.Product).WithMany(p => p.Purchases);
    }
}