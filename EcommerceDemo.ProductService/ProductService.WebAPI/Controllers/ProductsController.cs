using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Commands.CreateProduct;
using ProductService.Application.Commands.DeleteProduct;
using ProductService.Application.Commands.UpdateProduct;
using ProductService.Application.Common;
using ProductService.Application.DTOs;
using ProductService.Application.Queries.GetProductById;
using ProductService.Application.Queries.GetProducts;
using ProductService.Domain.Entities;

namespace ProductService.WebAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController(ISender mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<PagedResponse<ProductDTO>>> GetAll(string? filter, string? categoryName, int pageNumber = 1, int pageSize = 10)
        {
            // Implementation for getting all products
            var products = await mediator.Send(new GetProductsQuery(filter ?? "", categoryName, pageNumber, pageSize));
            return Ok(products);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Implementation for getting a product by id
            var product = await mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }
        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            // Implementation for creating a product
            var createdProduct = await mediator.Send(command);
            return Ok(createdProduct);
        }
        [HttpPut]
        [Authorize(Policy = "AdminOnly")]
        public async Task<ActionResult<Product>> Update([FromBody] UpdateProductCommand command)
        {
            // Implementation for updating a product
            var updatedProduct = await mediator.Send(command);
            return Ok(updatedProduct);
        }
        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            // Implementation for deleting a product
            var result = await mediator.Send(new DeleteProductCommand(id));
            return Ok(result);
        }
    }
}
