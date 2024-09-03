using Microsoft.AspNetCore.Mvc;
using WebApi_HomeWork_1.Business.Abstract;
using WebApi_HomeWork_1.Dtos;
using WebApi_HomeWork_1.Entitys.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_HomeWork_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> Get()
        {

            var products = await _productService.GetAllAsync();

           
            return products.Select(pr=> new ProductDto { 
                Id = pr.Id,
                Name = pr.Name,
                Discount = pr.Discount,
                Price = pr.Price,
           
            });
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null) { return BadRequest(); }


            return Ok(new ProductDto { Id = product.Id, Name = product.Name, Discount = product.Discount, Price = product.Price });
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductAddDto dto)
        {

            if(dto == null)
            {
            return BadRequest();
               
            }

            var product = new Product { Name = dto.Name, Price = dto.Price, Discount = dto.Discount };
            await _productService.AddAsync(product);
            return Ok(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductAddDto dto)
        {
            if (id < 1 || dto == null)
            {
                return BadRequest();
            }
            var product = new Product { Id = id, Name = dto.Name, Price = dto.Price, Discount = dto.Discount };
           await _productService.UpdateAsync(product);
            return Ok(dto);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            if(id < 1)
            {
                return BadRequest();
            }

            var product = await _productService.GetByIdAsync(id);
            if (product == null) {

                return NotFound(); 
            }

            await _productService.DeleteAsync(product);
            return Ok(product);
        }
    }
}
