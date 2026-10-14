using Application.DTOS;
using Application.Products.Commands;
using Application.Products.Queries.Get_ProductById;
using Application.Products.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductsController(ISender sender)
        {
            _sender = sender;
        }

        // GET /api/products
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            var result = await _sender.Send(new GetProductsQuery());
            return Ok(result);
        }


        // GET /api/products/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var result = await _sender.Send(new GetProductByIdQuery(id));
            if (result == null)
                return NotFound(new { message = $"Product with ID {id} not found." });

            return Ok(result);
        }


        // POST /api/products
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateProductCommand command)
        {
            var id = await _sender.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }
    }
}
