using SexShop.Entity;
using SexShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    public class InventoryInfoRepository : EntityBaseRepository<InventoryInfo>, IInventoryInfoRepository, IAutofacBase
    {
        public InventoryInfoRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
