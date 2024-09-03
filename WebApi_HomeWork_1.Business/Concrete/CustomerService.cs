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
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerDal _customerDal;

        public CustomerService(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public async Task AddAsync(Customer c)
        {
            await _customerDal.AddAsync(c);
        }

        public async Task DeleteAsync(Customer c)
        {
            await _customerDal.DeleteAsync(c);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _customerDal.GetListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customerDal.GetAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(Customer c)
        {
            await _customerDal.UpdateAsync(c);
        }


    }
}
