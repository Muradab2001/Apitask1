using Microsoft.EntityFrameworkCore;
using p127Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p127Api.DAL
{
    public class APIDbContext:DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> opt):base(opt)
        {

        }
        public DbSet<Phone> Phones { get; set; }
    }
}
