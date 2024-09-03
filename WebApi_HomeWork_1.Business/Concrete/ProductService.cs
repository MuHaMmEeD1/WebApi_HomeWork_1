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
    public class ProductService : IProductService
    {

        private readonly IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task AddAsync(Product p)
        {
            await _productDal.AddAsync(p);
        }

        public async Task DeleteAsync(Product p)
        {
            await _productDal.DeleteAsync(p);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
              return await _productDal.GetListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productDal.GetAsync(p=>p.Id == id);
        }

        public async Task UpdateAsync(Product p)
        {
            await _productDal.UpdateAsync(p);
        }
    }
}
