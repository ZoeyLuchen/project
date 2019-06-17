using SexShop.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    /// <summary>
    /// 商品评价表
    /// </summary>
    public interface IGoodsCommentRepository : IEntityBaseRepository<GoodsComment>
    {
        /// <summary>
        /// 添加用户商品评论
        /// </summary>
        /// <param name="goodsComment"></param>
        /// <param name="imgList"></param>
        /// <returns></returns>
        bool AddComment(GoodsComment goodsComment, List<GoodsCommentImg> imgList);
    }
}
