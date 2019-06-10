using SexShop.Entity;
using SexShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    public class UserGoodsCollectionRepository : EntityBaseRepository<UserGoodsCollection>, IUserGoodsCollectionRepository, IAutofacBase
    {
        public UserGoodsCollectionRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
