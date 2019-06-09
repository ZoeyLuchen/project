using SexShop.Entity;
using SexShop.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Repository.Repository
{
    class GoodsInfoRepository : EntityBaseRepository<GoodsInfo>, IGoodsInfoRepository, IAutofacBase
    {
        public GoodsInfoRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
