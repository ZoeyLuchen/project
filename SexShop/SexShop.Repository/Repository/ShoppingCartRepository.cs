using SexShop.Entity;
using SexShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    public class ShoppingCartRepository : EntityBaseRepository<ShoppingCart>, IShoppingCartRepository, IAutofacBase
    {
        public ShoppingCartRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
