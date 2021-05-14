using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Infrastructure.Context
{
    public class PostgreSQL_contextFactory : IDesignTimeDbContextFactory<PostgreSQL_context>
    {
        public PostgreSQL_context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PostgreSQL_context>();
            //change to
            optionsBuilder.UseNpgsql("Server =127.0.0.1;Port =5432;Database =chillidb;User Id =chilli;Password =secret123;");
            //for local
            //optionsBuilder.UseNpgsql("Server =127.0.0.1;Port =5432;Database =ChilliDb;User Id =chilli;Password =admin;");

            return new PostgreSQL_context(optionsBuilder.Options);
        }
    }
}
