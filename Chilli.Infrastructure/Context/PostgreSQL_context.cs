using Chilli.Core.Infrastructure.Entities.Order;
using Chilli.Core.Infrastructure.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Infrastructure.Context
{
    public class PostgreSQL_context : DbContext
    {
        public PostgreSQL_context(DbContextOptions<PostgreSQL_context> options)
: base(options)
        {}

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    => modelBuilder.UseTablespace("chillidb");
    }
}
