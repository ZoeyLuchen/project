using SexShop.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.IRepository
{
    public interface IOrderInfoRepository : IEntityBaseRepository<OrderInfo>
    {
        PageModel<OrderInfoView> GetListByPages(PageInfo pageInfo, OrderInfoParam param);
    }
}
