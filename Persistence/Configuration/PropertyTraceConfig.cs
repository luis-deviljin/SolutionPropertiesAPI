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

    public class PropertyTraceConfig : IEntityTypeConfiguration<PropertyTrace>
    {
        public void Configure(EntityTypeBuilder<PropertyTrace> builder)
        {
            builder.ToTable("PropertyTraces");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.DateSale)
                .HasColumnType("Date")
                .IsRequired();
            builder.Property(p => p.Name)
                .IsRequired();
            builder.Property(p => p.Value)
                .IsRequired();
            builder.Property(p => p.Tax)
                .HasMaxLength(70)
                .IsRequired();
            builder.Property(p => p.CreatedBy)
                .HasMaxLength(40);
            builder.Property(p => p.LastModifiesdBy)
                .HasMaxLength(40);
            builder.HasOne(p => p.Property)
                .WithMany(g => g.PropertyTrace)
                .HasForeignKey(s => s.IdProperty);

        }
    }
}
