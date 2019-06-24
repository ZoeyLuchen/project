using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.IRepository
{
    public class GoodsSpecificationRepository : EntityBaseRepository<GoodsSpecification>, IGoodsSpecificationRepository, IAutofacBase
    {
        public GoodsSpecificationRepository(InsteadBuyPlatformDbContext context) : base(context)
        {
        }
    }
}
