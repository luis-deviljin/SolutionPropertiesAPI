using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class PropertyConfig : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Properties");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(70)
                .IsRequired();
            builder.Property(p => p.Address)
                .HasMaxLength(70)
                .IsRequired();
            builder.Property(p => p.Price)
                .HasMaxLength(70);
            builder.Property(p => p.CodInternal)
                .HasMaxLength(70);
            builder.Property(p => p.Year)
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(p => p.IdOwner)
                .HasDefaultValue(true)
                .IsRequired();
            builder.Property(p => p.CreatedBy)
                .HasMaxLength(40);
            builder.Property(p => p.LastModifiesdBy)
                .HasMaxLength(40);
            builder.HasOne(p => p.Owner)
                .WithMany(g => g.Property)
                .HasForeignKey(s => s.IdOwner);

        }
    }
}
