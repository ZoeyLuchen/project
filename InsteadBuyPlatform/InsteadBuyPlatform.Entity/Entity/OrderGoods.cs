using InsteadBuyPlatform.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.Entity
{
    public class OrderGoods : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 订单Id
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 订单Id
        /// </summary>
        public int GoodsId { get; set; }

        /// <summary>
        /// 商品规格Id
        /// </summary>
        public int GsId { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int GoodsNum { get; set; }
    }
}
