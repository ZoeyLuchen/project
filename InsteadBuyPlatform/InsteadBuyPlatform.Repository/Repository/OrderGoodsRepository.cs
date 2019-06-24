using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.IRepository
{
    public class OrderGoodsRepository : EntityBaseRepository<OrderGoods>, IOrderGoodsRepository, IAutofacBase
    {
        public OrderGoodsRepository(InsteadBuyPlatformDbContext context) : base(context)
        {
        }
    }
}
