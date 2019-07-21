using InsteadBuyPlatform.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.IRepository
{
    public interface IOrderInfoRepository : IEntityBaseRepository<OrderInfo>
    {
        /// <summary>
        /// 后台订单列表查询
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        PageModel<OrderInfoView2> SearchListByPage(OrderInfoParam param, PageInfo pageInfo);

        /// <summary>
        /// 根据订单Id查询订单商品
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        List<OrderGoodsView> GetOrderGoodsList(int orderId);

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="orderInfoView"></param>
        /// <returns></returns>
        bool AddOrder(OrderInfoView orderInfoView);

        /// <summary>
        /// 按品牌统计
        /// </summary>
        /// <returns></returns>
        List<StatisticsView> GetDataByBrand(StatisticsParam param);

        /// <summary>
        /// 按客户名统计
        /// </summary>
        /// <returns></returns>
        List<StatisticsView> GetDataByClient(StatisticsParam param);
        
    }
}
