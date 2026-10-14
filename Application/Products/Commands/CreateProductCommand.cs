using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Products.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
