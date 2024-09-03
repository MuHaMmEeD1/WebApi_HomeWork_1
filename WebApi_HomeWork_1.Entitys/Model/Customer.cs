using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_HomeWork_1.Core.Abstraction;

namespace WebApi_HomeWork_1.Entitys.Model
{
    public class Customer : IEntity
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Surname { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }

    }
}
