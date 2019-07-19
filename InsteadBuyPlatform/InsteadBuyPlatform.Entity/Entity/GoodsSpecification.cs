using InsteadBuyPlatform.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.Entity
{
    /// <summary>
    /// 商品规格表
    /// </summary>
    public class GoodsSpecification : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public int GoodsId { get; set; }

        /// <summary>
        /// 规格名称
        /// </summary>
        public string SpecificationName { get; set; }

        /// <summary>
        /// 规格描述
        /// </summary>
        public string SpecificationDesc { get; set; }

        /// <summary>
        /// 专柜价格
        /// </summary>
        public decimal Price { get; set; }

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
