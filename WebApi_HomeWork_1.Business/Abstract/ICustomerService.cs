using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_HomeWork_1.Entitys.Model;

namespace WebApi_HomeWork_1.Business.Abstract
{
    public interface ICustomerService
    {

        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetByIdAsync(int id);
        Task AddAsync(Customer c);
        Task DeleteAsync(Customer c);
        Task UpdateAsync(Customer c);


    }
}
