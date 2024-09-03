using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi_HomeWork_1.Core.Abstraction;

namespace WebApi_HomeWork_1.Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        //Get(x=>x.price>10)
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> filter = null);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
