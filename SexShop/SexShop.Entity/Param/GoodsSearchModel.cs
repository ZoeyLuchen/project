using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Entity
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
        /// 最低价
        /// </summary>
        public decimal? BeginPrice { get; set; }

        /// <summary>
        /// 最高价
        /// </summary>
        public decimal? EndPrice { get; set; }

        /// <summary>
        /// 按那个维度排序
        /// </summary>
        public GoodsOrderByEnum OrderBy { get; set; }

        /// <summary>
        /// 是否倒序
        /// </summary>
        public bool IsDesc { get; set; }
    }

    public enum GoodsOrderByEnum
    {
        综合排序 = 1,
        价格排序 = 2,
        销量排序 = 3
    }
}
