using SexShop.Entity;
using SexShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    public class GoodsCommentImgRepository : EntityBaseRepository<GoodsCommentImg>, IGoodsCommentImgRepository, IAutofacBase
    {
        public GoodsCommentImgRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
