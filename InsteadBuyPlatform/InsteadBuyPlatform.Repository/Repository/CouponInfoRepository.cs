using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.IRepository
{
    public class CouponInfoRepository : EntityBaseRepository<CouponInfo>, ICouponInfoRepository, IAutofacBase
    {
        public CouponInfoRepository(InsteadBuyPlatformDbContext context) : base(context)
        {
        }
    }
}
