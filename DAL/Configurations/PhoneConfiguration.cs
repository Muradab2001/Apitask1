using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using p127Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p127Api.DAL.Configurations
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.Property(p => p.Brand).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Model).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Color).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(9,2)").IsRequired();
            builder.Property(p => p.Display).HasDefaultValue(true);
        }
    }
}
