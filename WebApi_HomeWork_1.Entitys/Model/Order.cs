using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_HomeWork_1.Core.Abstraction;

namespace WebApi_HomeWork_1.Entitys.Model
{
    public class Order : IEntity
    {


        public int Id { get; set; }
        public string? OrderDate { get; set; }
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
