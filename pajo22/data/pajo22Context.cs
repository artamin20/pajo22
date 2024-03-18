using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pajo22.Models;

namespace pajo22.Data
{
    public class pajo22Context : DbContext
    {
        public pajo22Context (DbContextOptions<pajo22Context> options)
            : base(options)
        {
        }

        public DbSet<pajo22.Models.ProductModels> ProductModels { get; set; } = default!;
        public DbSet<pajo22.Models.GroupModels> GroupModels { get; set; } = default!;
        public DbSet<pajo22.Models.SubgroupModels> SubgroupModels { get; set; } = default!;


    }
}
