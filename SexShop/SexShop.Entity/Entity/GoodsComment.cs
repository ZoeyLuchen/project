using SexShop.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Entity
{
    /// <summary>
    /// 商品评价表
    /// </summary>
    public class GoodsComment : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 被评价商品Id
        /// </summary>
        public int GoodsId { get; set; }

        /// <summary>
        /// 描述评分
        /// </summary>
        public int DescScore { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 物流得分
        /// </summary>
        public int WlScore { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>        
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public int UpdateBy { get; set; }

    }
}
