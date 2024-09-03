using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_HomeWork_1.Entitys.Model;

namespace WebApi_HomeWork_1.DataAccess.Data
{
    public class ProductDbContext : DbContext
    {
      

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProductDbContext;Integrated Security=True;");
            }
        }

        public virtual DbSet<Product> Products {  get; set; }        
        public virtual DbSet<Order> Orders {  get; set; }        
        public virtual DbSet<Customer> Customers {  get; set; }


    }
}
