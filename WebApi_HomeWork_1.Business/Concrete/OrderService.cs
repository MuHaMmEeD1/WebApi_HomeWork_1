using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_HomeWork_1.Business.Abstract;
using WebApi_HomeWork_1.DataAccess.Abstraction;
using WebApi_HomeWork_1.Entitys.Model;

namespace WebApi_HomeWork_1.Business.Concrete
{
    public class OrderService : IOrderService
    {

        private readonly IOrderDal _orderDal;

        public OrderService(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public async Task AddAsync(Order o)
        {
            await _orderDal.AddAsync(o);
        }

        public async Task DeleteAsync(Order o)
        {
            await _orderDal.DeleteAsync(o);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _orderDal.GetListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _orderDal.GetAsync(o => o.Id == id);
        }

        public async Task UpdateAsync(Order o)
        {
            await _orderDal.UpdateAsync(o);
        }

    }
}
