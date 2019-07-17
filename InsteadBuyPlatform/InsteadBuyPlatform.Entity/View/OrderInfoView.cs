using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.Entity
{
    public class OrderInfoView
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 收货客户
        /// </summary>
        public int? ClientId { get; set; }

        /// <summary>
        /// 客户名
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// 订单商品集合
        /// </summary>
       public List<OrderGoods> OrderGoodsList { get; set; }
    }
}
