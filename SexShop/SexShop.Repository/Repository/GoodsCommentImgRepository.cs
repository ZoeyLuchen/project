using SexShop.Entity;
using SexShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    public class GoodsInfoRepository : EntityBaseRepository<GoodsInfo>, IGoodsInfoRepository, IAutofacBase
    {
        public GoodsInfoRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
