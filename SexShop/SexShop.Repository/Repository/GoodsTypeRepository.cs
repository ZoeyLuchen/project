using SexShop.Entity;
using SexShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    public class GoodsTypeRepository : EntityBaseRepository<GoodsType>, IGoodsTypeRepository, IAutofacBase
    {
        public GoodsTypeRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
