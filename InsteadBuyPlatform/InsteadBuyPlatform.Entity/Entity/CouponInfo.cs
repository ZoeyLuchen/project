using InsteadBuyPlatform.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.Entity
{
    /// <summary>
    /// 优惠劵信息
    /// </summary>
    public class CouponInfo : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 优惠劵名称
        /// </summary>
        public string CouponName { get; set; }

        /// <summary>
        /// 优惠劵类型
        /// 000001 ：邀请用户返券
        /// </summary>
        public string CouponType { get; set; }

        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal DiscountedPrice { get; set; }

        /// <summary>
        /// 有效时长
        /// </summary>
        public int EffectiveLong { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDel { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>        
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}
