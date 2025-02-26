﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_HomeWork_1.Core.DataAccess.EntityFramework;
using WebApi_HomeWork_1.DataAccess.Abstraction;
using WebApi_HomeWork_1.DataAccess.Data;
using WebApi_HomeWork_1.Entitys.Model;

namespace WebApi_HomeWork_1.DataAccess.Concrete.EFEntityFramework
{
    public class EFProductDal : EFEntityRepositoryBase<Product, ProductDbContext>, IProductDal
    {
        public EFProductDal(ProductDbContext context) : base(context)
        {
        }
    }
}
