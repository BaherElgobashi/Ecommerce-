using Application.Common.Interfaces;
using Application.DTOS;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Products.Queries.Get_ProductById
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto?>
    {

    }
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly IApplicationDbContext _context;

        public GetProductByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (product == null) return null;

            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
