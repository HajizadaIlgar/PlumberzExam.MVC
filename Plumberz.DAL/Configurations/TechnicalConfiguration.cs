using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plumberz.Core.Entities.Technicals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plumberz.DAL.Configurations
{
    public class TechnicalConfiguration : IEntityTypeConfiguration<Technical>
    {
        public void Configure(EntityTypeBuilder<Technical> builder)
        {
            builder
                .HasKey(e => e.Id);
            builder
                .Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(64);
            builder
                .Property(e => e.ImageUrl)
                .IsRequired()
                .HasMaxLength(255);
            builder
                .HasOne(e => e.Department)
                .WithMany(e => e.Technicals)
                .HasForeignKey(e => e.DepartmentId);
        }
    }
}
