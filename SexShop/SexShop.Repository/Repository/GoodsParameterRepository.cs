using SexShop.Entity;
using SexShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    public class GoodsParameterRepository : EntityBaseRepository<GoodsParameter>, IGoodsParameterRepository, IAutofacBase
    {
        public GoodsParameterRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
