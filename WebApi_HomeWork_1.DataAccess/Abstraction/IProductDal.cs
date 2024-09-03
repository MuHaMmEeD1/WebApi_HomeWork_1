using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_HomeWork_1.Core.DataAccess;
using WebApi_HomeWork_1.Entitys.Model;

namespace WebApi_HomeWork_1.DataAccess.Abstraction
{
    public interface IProductDal:IEntityRepository<Product>
    {
    }
}
