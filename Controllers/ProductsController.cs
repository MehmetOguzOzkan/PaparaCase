using Microsoft.AspNetCore.Mvc;
using WebApiCase1.Models;
using WebApiCase1.Services;

namespace WebApiCase1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public ActionResult Add([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _productService.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var existingProduct = _productService.GetById(id);
            if (existingProduct == null)
                return NotFound();
            product.Id = id;
            _productService.Update(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingProduct = _productService.GetById(id);
            if (existingProduct == null)
                return NotFound();
            _productService.Delete(id);
            return NoContent();
        }

        [HttpGet("list")]
        public ActionResult<IEnumerable<Product>> List([FromQuery] string name, [FromQuery] string sortField, [FromQuery] string sortOrder)
        {
            var products = _productService.List(name, sortField, sortOrder);
            return Ok(products);
        }
    }
}
