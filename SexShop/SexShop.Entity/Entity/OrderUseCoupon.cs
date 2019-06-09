using SexShop.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Entity
{
    /// <summary>
    /// 订单使用优惠劵
    /// </summary>
    public class OrderUseCoupon : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 订单Id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 用户优惠劵
        /// </summary>
        public int UcId { get; set; }

        /// <summary>
        /// 实际扣除
        /// </summary>
        public decimal ActualDeduction { get; set; }
    }
}
