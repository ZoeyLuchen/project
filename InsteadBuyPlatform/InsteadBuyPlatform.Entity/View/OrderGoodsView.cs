using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.Entity
{
    public class OrderGoodsView :  OrderGoods
    {
        /// <summary>
        /// 商品Name
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 商品规格Name
        /// </summary>
        public string GsName { get; set; }
    }
}
