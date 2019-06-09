using SexShop.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Entity
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class ShoppingCart : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public int GoodsId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime{ get; set; }

        /// <summary>
        /// 加入时的价格
        /// </summary>
        public decimal AddTimePice { get; set; }
    }
}
