using EFCore.BulkExtensions;
using SexShop.Entity;
using SexShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    /// <summary>
    /// 商品评价表
    /// </summary>
    public class GoodsCommentRepository : EntityBaseRepository<GoodsComment>, IGoodsCommentRepository, IAutofacBase
    {
        public GoodsCommentRepository(SexShopDbContext context) : base(context)
        {
        }

        /// <summary>
        /// 添加用户商品评论
        /// </summary>
        /// <param name="goodsComment"></param>
        /// <param name="imgList"></param>
        /// <returns></returns>
        public bool AddComment(GoodsComment goodsComment, List<GoodsCommentImg> imgList)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var entityEntry = _context.Add<GoodsComment>(goodsComment);

                    _context.SaveChanges();

                    if (imgList.Count != 0)
                    {
                        imgList.ForEach(e => { e.GCId = entityEntry.Entity.Id; });
                        _context.BulkInsert(imgList);
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
               
            }
        }
    }
}
