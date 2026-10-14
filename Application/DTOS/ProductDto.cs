using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOS
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
