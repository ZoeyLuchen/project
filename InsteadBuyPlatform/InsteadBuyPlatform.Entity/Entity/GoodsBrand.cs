using InsteadBuyPlatform.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.Entity
{
    /// <summary>
    /// 商品品牌
    /// </summary>
    public class GoodsBrand : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 中文品牌名
        /// </summary>
        public string ChsBrandName { get; set; }

        /// <summary>
        /// 英文品牌名
        /// </summary>
        public string EnBrandName { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDel { get; set; } 
    }
}
