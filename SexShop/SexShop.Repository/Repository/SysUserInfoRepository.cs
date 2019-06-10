using SexShop.Entity;
using SexShop.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    public class SysUserInfoRepository : EntityBaseRepository<SysUserInfo>, ISysUserInfoRepository, IAutofacBase
    {
        public SysUserInfoRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
