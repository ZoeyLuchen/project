using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.Entity
{
    /// <summary>
    /// 商品查询实体
    /// </summary>
    public class GoodsSearchModel
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 商品类型
        /// </summary>
        public string GoodsTypeCode { get; set; }

        /// <summary>
        /// 商品品牌
        /// </summary>
        public int? GbId { get; set; }
    }
}
