using InsteadBuyPlatform.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.IRepository
{
    public interface IClientInfoRepository : IEntityBaseRepository<ClientInfo>
    {
        PageModel<ClientInfo> SearchListByPage(ClientInfoParam param, PageInfo pageInfo);
    }
}
