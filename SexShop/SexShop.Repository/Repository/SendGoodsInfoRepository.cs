using SexShop.Entity;
using SexShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    public class SendGoodsInfoRepository : EntityBaseRepository<SendGoodsInfo>, ISendGoodsInfoRepository, IAutofacBase
    {
        public SendGoodsInfoRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
