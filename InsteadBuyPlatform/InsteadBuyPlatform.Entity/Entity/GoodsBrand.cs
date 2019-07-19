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
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int? CreateBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public int? UpdateBy { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDel { get; set; } 
    }
}
