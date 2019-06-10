using SexShop.Entity;
using SexShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    public class CouponInfoRepository : EntityBaseRepository<CouponInfo>, ICouponInfoRepository, IAutofacBase
    {
        public CouponInfoRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
