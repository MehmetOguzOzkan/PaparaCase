using Microsoft.AspNetCore.Mvc;
using WebApiCase1.DTOs.Requests;
using WebApiCase1.DTOs.Responses;
using WebApiCase1.Models;
using WebApiCase1.Services;

namespace WebApiCase1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        // Constructor to inject the service dependency
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // Retrieve all products
        [HttpGet]
        public ActionResult<IEnumerable<ProductResponse>> GetAll()
        {
            // Get all products from the service
            var productDtos = _productService.GetAll();
            return Ok(productDtos);
        }

        // Retrieve a product by ID
        [HttpGet("{id}")]
        public ActionResult<ProductResponse> GetById(int id)
        {
            // Get the product by ID from the service
            var productDto = _productService.GetById(id);
            if (productDto == null)
                return NotFound();

            return Ok(productDto);
        }

        // Add a new product
        [HttpPost]
        public ActionResult Add([FromBody] ProductRequest productDto)
        {
            // FluentValidation will handle model validation automatically

            // Add the new product via the service
            var createdProductDto = _productService.Add(productDto);
            return CreatedAtAction(nameof(GetById), new { id = createdProductDto.Id }, createdProductDto);
        }

        // Update an existing product
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] ProductRequest productDto)
        {
            // FluentValidation will handle model validation automatically

            // Update the product via the service
            var result = _productService.Update(id, productDto);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // Delete a product
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // Delete the product via the service
            var result = _productService.Delete(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // List and sort products with optional filtering
        [HttpGet("list")]
        public ActionResult<IEnumerable<ProductResponse>> List([FromQuery] string name, [FromQuery] string sortField, [FromQuery] string sortOrder)
        {
            // List and sort products via the service
            var productDtos = _productService.List(name, sortField, sortOrder);
            return Ok(productDtos);
        }
    }
}
