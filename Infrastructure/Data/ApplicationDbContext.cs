using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    internal class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Product> Products => Set<Product>();

       

        public Task<int> SaveChangesasync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
