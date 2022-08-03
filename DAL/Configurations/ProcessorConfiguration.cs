using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using p127Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p127Api.DAL.Configurations
{
    public class ProcessorConfiguration : IEntityTypeConfiguration<Processor>
    {
        public void Configure(EntityTypeBuilder<Processor> builder)
        {
            builder.Property(p => p.Model).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Cores).IsRequired();
            builder.Property(p => p.GHz).HasColumnType("decimal(4,2)").IsRequired();
        }
    }
}
