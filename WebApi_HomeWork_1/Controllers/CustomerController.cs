using Microsoft.AspNetCore.Mvc;
using WebApi_HomeWork_1.Business.Abstract;
using WebApi_HomeWork_1.Business.Concrete;
using WebApi_HomeWork_1.Dtos;
using WebApi_HomeWork_1.Entitys.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi_HomeWork_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }



        // GET: api/<CustomercController>
        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> Get()
        {

            var customers = await _customerService.GetAllAsync();


            return customers.Select(cu => new CustomerDto
            {
                Id = cu.Id,
                Name = cu.Name,
                Surname = cu.Surname,
             
            });
        }

        // GET api/<CustomercController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);

            if (customer == null) { return BadRequest(); }

            return Ok( new CustomerDto { Id = customer.Id, Name = customer.Name, Surname = customer.Surname });
        }

        // POST api/<CustomercController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerAddDto dto)
        {

            if (dto == null)
            {
                return BadRequest();

            }

            var customer = new Customer { Name = dto.Name, Surname = dto.Surname };
            await _customerService.AddAsync(customer);
            return Ok(customer);
        }

        // PUT api/<CustomercController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerAddDto dto)
        {
            if (id < 1 || dto == null)
            {
                return BadRequest();
            }
            var customer = new Customer { Id = id, Name = dto.Name, Surname = dto.Surname };
            await _customerService.UpdateAsync(customer);
            return Ok(dto);
        }

        // DELETE api/<CustomercController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            if (id < 1)
            {
                return BadRequest();
            }

            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null)
            {

                return NotFound();
            }

            await _customerService.DeleteAsync(customer);
            return Ok(customer);
        }
    }
}
