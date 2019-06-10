using SexShop.Entity;
using SexShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    public class PurchaseInfoRepository : EntityBaseRepository<PurchaseInfo>, IPurchaseInfoRepository, IAutofacBase
    {
        public PurchaseInfoRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
