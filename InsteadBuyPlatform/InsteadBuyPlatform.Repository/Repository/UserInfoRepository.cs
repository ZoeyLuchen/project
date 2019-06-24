using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace InsteadBuyPlatform.Repository
{
    public class UserInfoRepository : EntityBaseRepository<UserInfo>, IUserInfoRepository, IAutofacBase
    {
        public UserInfoRepository(InsteadBuyPlatformDbContext context) : base(context)
        {
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddUserInfo(UserInfo model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var entityEntry = _context.Set<UserInfo>().Add(model);
                    _context.SaveChanges();

                    var couponModel = _context.Set<CouponInfo>().FirstOrDefault(e => e.CouponType == "000001" && e.IsDel == false);
                    if (couponModel != null)
                    {
                        UserCoupon userCoupon = new UserCoupon()
                        {
                            CouponId = couponModel.Id,
                            UserId = entityEntry.Entity.Id,
                            HighestDeduction = couponModel.DiscountedPrice,
                            ValidityPeriod = DateTime.Now.AddDays(couponModel.EffectiveLong)
                        };

                        _context.Set<UserCoupon>().Add(userCoupon);
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
