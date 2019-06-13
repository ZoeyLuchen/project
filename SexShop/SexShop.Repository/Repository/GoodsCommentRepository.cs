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
    }
}
