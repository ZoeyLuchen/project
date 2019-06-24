using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.IRepository
{
    public class UserCouponRepository : EntityBaseRepository<UserCoupon>, IUserCouponRepository, IAutofacBase
    {
        public UserCouponRepository(InsteadBuyPlatformDbContext context) : base(context)
        {
        }
    }
}
