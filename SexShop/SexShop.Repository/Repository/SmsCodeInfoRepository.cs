using SexShop.Entity;
using SexShop.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Repository
{
    public class SmsCodeInfoRepository : EntityBaseRepository<SmsCodeInfo>, ISmsCodeInfoRepository, IAutofacBase
    {
        public SmsCodeInfoRepository(SexShopDbContext context) : base(context)
        {
        }
    }
}
