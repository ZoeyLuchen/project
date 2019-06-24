using InsteadBuyPlatform.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.Entity
{
    /// <summary>
    /// 用户优惠劵表
    /// </summary>
    public class UserCoupon : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 优惠劵Id
        /// </summary>
        public int CouponId { get; set; }

        /// <summary>
        /// 最高扣除
        /// </summary>
        public decimal HighestDeduction { get; set; }

        /// <summary>
        /// 有效期
        /// </summary>
        public DateTime ValidityPeriod { get; set; }

    }
}
