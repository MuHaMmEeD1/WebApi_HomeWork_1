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
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }





        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IEnumerable<OrderDto>> Get()
        {

            var orders = await _orderService.GetAllAsync();


            return orders.Select(or => new OrderDto
            {
                Id = or.Id,
                CustomerId = or.CustomerId,
                ProductId = or.ProductId,
                OrderDate = or.OrderDate,

            });
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _orderService.GetByIdAsync(id);


            if (order == null) { return BadRequest(); }

            return Ok(new OrderDto
            {

                Id = id,
                CustomerId = order.CustomerId,
                ProductId = order.ProductId,
                OrderDate = order.OrderDate,

            });
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderAddDto dto)
        {

            if (dto == null)
            {
                return BadRequest();

            }

            var order = new Order { CustomerId = dto.CustomerId, OrderDate=dto.OrderDate,
            ProductId=dto.ProductId, };
            await _orderService.AddAsync(order);
            return Ok(order);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrderAddDto dto)
        {
            if (id < 1 || dto == null)
            {
                return BadRequest();
            }
            var order = new Order {
                Id = id,
                CustomerId = dto.CustomerId,
                OrderDate = dto.OrderDate,
                ProductId = dto.ProductId,
            };
            await _orderService.UpdateAsync(order);
            return Ok(dto);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            if (id < 1)
            {
                return BadRequest();
            }

            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {

                return NotFound();
            }

            await _orderService.DeleteAsync(order);
            return Ok(order);
        }
    }
}
