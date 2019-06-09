using SexShop.Entity;
using SexShop.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Repository
{
    public class UserInfoRepository : EntityBaseRepository<UserInfo>, IUserInfoRepository, IAutofacBase
    {
        public UserInfoRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
