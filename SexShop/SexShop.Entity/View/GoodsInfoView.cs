using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Entity.View
{
    public class GoodsInfoView : GoodsInfo
    {
        /// <summary>
        /// 商品Id
        /// </summary>
        public int GoodsId { get; set; }

        /// <summary>
        /// 商品规格Id
        /// </summary>
        public int GsId { get; set; }

        /// <summary>
        /// 规格名称
        /// </summary>
        public string SpecificationName { get; set; }

        /// <summary>
        /// 规格描述
        /// </summary>
        public string SpecificationDesc { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }
    }
}
