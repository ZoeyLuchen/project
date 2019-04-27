using MaiDongXi.Entity;
using MaiDongXi.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiDongXi.Repository.Repository
{
    public class SendGoodsInfoRepository : EntityBaseRepository<SendGoodsInfo>, ISendGoodsInfoRepository, IAutofacBase
    {
        public SendGoodsInfoRepository(MDXDbContext context) : base(context)
        {
        }
    }
}
