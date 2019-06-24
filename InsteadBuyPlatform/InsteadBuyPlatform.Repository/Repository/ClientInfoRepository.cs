using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.IRepository
{
    public class ClientInfoRepository : EntityBaseRepository<ClientInfo>, IClientInfoRepository, IAutofacBase
    {
        public ClientInfoRepository(InsteadBuyPlatformDbContext context) : base(context)
        {
        }
    }
}
