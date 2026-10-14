using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Product> Products { get;  }
        Task<int> SaveChangesasync(CancellationToken cancellationToken);
    }
}
