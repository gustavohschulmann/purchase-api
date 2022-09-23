using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PurchaseApi.Domain.Entities;

namespace PurchaseApi.Infra.Data.Maps;

public class PersonMap : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        //Maybe pass the table name/columns as lowcase
        builder.ToTable("person");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("idperson").UseIdentityColumn();
        builder.Property(c => c.Name).HasColumnName("name");
        builder.Property(c => c.Document).HasColumnName("documento");
        builder.Property(c => c.Phone).HasColumnName("celular");

        builder.HasMany(c => c.Purchases).WithOne(p => p.Person)
            .HasForeignKey(c => c.PersonId);
    }
}