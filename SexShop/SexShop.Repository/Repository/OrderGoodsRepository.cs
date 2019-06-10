using SexShop.Entity;
using SexShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    public class OrderGoodsRepository : EntityBaseRepository<OrderGoods>, IOrderGoodsRepository, IAutofacBase
    {
        public OrderGoodsRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
