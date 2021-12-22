using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Configuration
{
    public class OwnerConfig : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owners");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasMaxLength(70)
                .IsRequired();
            builder.Property(p => p.Address)
                .HasMaxLength(70)
                .IsRequired();
            builder.Property(p => p.Photo)
                .IsRequired();
            builder.Property(p => p.Birthday)
                .HasColumnType("Date")
                .IsRequired();
            builder.Property(p => p.Email)
                .HasMaxLength(70);
            builder.Property(p => p.NumberofContact)
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(p => p.CreatedBy)
                .HasMaxLength(40);
            builder.Property(p => p.LastModifiesdBy)
                .HasMaxLength(40);


        }
    }
}
