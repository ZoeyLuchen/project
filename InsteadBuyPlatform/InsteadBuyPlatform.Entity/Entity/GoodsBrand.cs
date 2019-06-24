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
        /// 品牌名
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDel { get; set; } 
    }
}
