using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.Repository
{
    public class SmsCodeInfoRepository : EntityBaseRepository<SmsCodeInfo>, ISmsCodeInfoRepository, IAutofacBase
    {
        public SmsCodeInfoRepository(InsteadBuyPlatformDbContext context) : base(context)
        {
        }
    }
}
