using SexShop.Entity;
using SexShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    public class GoodsSpecificationRepository : EntityBaseRepository<GoodsSpecification>, IGoodsSpecificationRepository, IAutofacBase
    {
        public GoodsSpecificationRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
