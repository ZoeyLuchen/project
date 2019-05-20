using MaiDongXi.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiDongXi.IRepository
{
    public interface IOrderInfoRepository : IEntityBaseRepository<OrderInfo>
    {
        PageModel<OrderInfoView> GetListByPages(PageInfo pageInfo, OrderInfoParam param);

        List<ChatView> GetLineChatData();
    }
}
