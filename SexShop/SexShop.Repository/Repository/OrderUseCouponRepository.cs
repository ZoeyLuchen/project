using SexShop.Entity;
using SexShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    public class OrderUseCouponRepository : EntityBaseRepository<OrderUseCoupon>, IOrderUseCouponRepository, IAutofacBase
    {
        public OrderUseCouponRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
