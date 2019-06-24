using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.IRepository
{
    public class GoodsBrandRepository : EntityBaseRepository<GoodsBrand>, IGoodsBrandRepository, IAutofacBase
    {
        public GoodsBrandRepository(InsteadBuyPlatformDbContext context) : base(context)
        {
        }
    }
}
