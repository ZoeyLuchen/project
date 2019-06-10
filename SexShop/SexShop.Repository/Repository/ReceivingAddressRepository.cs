using SexShop.Entity;
using SexShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    public class ReceivingAddressRepository : EntityBaseRepository<ReceivingAddress>, IReceivingAddressRepository, IAutofacBase
    {
        public ReceivingAddressRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
