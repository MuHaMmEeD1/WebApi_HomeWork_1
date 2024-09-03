using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_HomeWork_1.Entitys.Model;

namespace WebApi_HomeWork_1.Business.Abstract
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order> GetByIdAsync(int id);
        Task AddAsync(Order o);
        Task DeleteAsync(Order o);
        Task UpdateAsync(Order o);
    }
}
