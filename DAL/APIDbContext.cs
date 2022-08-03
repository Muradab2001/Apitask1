using Microsoft.EntityFrameworkCore;
using p127Api.DAL.Configurations;
using p127Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p127Api.DAL
{
    public class APIDbContext: DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PhoneConfiguration());
        }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Processor> Processors { get; set; }
    }
}
