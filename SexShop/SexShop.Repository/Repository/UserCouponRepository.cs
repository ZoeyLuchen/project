using SexShop.Entity;
using SexShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    public class UserCouponRepository : EntityBaseRepository<UserCoupon>, IUserCouponRepository, IAutofacBase
    {
        public UserCouponRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
