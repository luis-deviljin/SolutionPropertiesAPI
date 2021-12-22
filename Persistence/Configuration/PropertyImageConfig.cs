using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{

    public class PropertyImageConfig : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.ToTable("PropertyImages");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.File)
                .IsRequired();
            builder.Property(p => p.Enable)
                .HasDefaultValue(true)
                .IsRequired();
            builder.Property(p => p.CreatedBy)
                .HasMaxLength(40);
            builder.Property(p => p.LastModifiesdBy)
                .HasMaxLength(40);
            builder.HasOne(p => p.Property)
                .WithMany(g => g.PropertyImage)
                .HasForeignKey(s => s.IdProperty);

        }
    }
}
