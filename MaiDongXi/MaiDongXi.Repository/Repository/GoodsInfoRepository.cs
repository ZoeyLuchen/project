using MaiDongXi.Entity;
using MaiDongXi.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiDongXi.Repository.Repository
{
    class GoodsInfoRepository : EntityBaseRepository<GoodsInfo>, IGoodsInfoRepository, IAutofacBase
    {
        public GoodsInfoRepository(MDXDbContext context) : base(context)
        {
        }
    }
}
