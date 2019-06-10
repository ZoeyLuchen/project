using SexShop.Entity;
using SexShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    public class PurchaseDetailRepository : EntityBaseRepository<PurchaseDetail>, IPurchaseDetailRepository, IAutofacBase
    {
        public PurchaseDetailRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
