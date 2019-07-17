using InsteadBuyPlatform.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.IRepository
{
    public interface IOrderInfoRepository : IEntityBaseRepository<OrderInfo>
    {
        PageModel<OrderInfoView> GetListByPages(PageInfo pageInfo, OrderInfoParam param);

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="orderInfoView"></param>
        /// <returns></returns>
        bool AddOrder(OrderInfoView orderInfoView);
    }
}
