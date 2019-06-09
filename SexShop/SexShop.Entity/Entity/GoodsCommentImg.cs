using SexShop.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Entity
{
    /// <summary>
    /// 商品评论图片
    /// </summary>
    public class GoodsCommentImg: IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 商品评论Id
        /// </summary>
        public int GCId { get; set; }

        /// <summary>
        /// 缩略图地址
        /// </summary>
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// 原图地址
        /// </summary>
        public string OriginalImageUrl { get; set; }
    }
}
