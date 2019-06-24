using InsteadBuyPlatform.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.IRepository
{
    public interface IOrderInfoRepository : IEntityBaseRepository<OrderInfo>
    {
        PageModel<OrderInfoView> GetListByPages(PageInfo pageInfo, OrderInfoParam param);
    }
}
