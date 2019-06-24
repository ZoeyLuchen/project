using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.IRepository
{
    public class GoodsTypeRepository : EntityBaseRepository<GoodsType>, IGoodsTypeRepository, IAutofacBase
    {
        public GoodsTypeRepository(InsteadBuyPlatformDbContext context) : base(context)
        {
        }
    }
}
