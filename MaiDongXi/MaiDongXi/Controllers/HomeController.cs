using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MaiDongXi.Models;
using MaiDongXi.IRepository;
using MaiDongXi.Entity;

namespace MaiDongXi.Controllers
{
    public class HomeController : BaseController
    {
        IOrderInfoRepository _orderInfoRepository;

        public HomeController(IOrderInfoRepository orderInfoRepository)
        {
            _orderInfoRepository = orderInfoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取折线图数据
        /// </summary>
        /// <returns></returns>
        public IActionResult GetLineChatData()
        {
            List<ChatView> list = _orderInfoRepository.GetLineChatData();
            List<string> xList = new List<string>();
            List<Int64> yList = new List<Int64>();

            var nowDate = DateTime.Now;

            for (var i = 30; i > 0; i--)
            {
                var dateStr = nowDate.AddDays(i * -1).ToString("yyyy-MM-dd");
                xList.Add(dateStr);

                if (list.Any(e => e.X == dateStr))
                {                    
                    yList.Add(list.FirstOrDefault(e => e.X == dateStr).Y);
                }
                else
                {
                    yList.Add(0);
                }
            }

            return Json(new { x = xList, y = yList });
        }

        /// <summary>
        /// 获取订单数据
        /// </summary>
        /// <returns></returns>
        public IActionResult GetOrderData()
        {
            var waitSendGoodsList = _orderInfoRepository.FindBy(e => e.Status == (int)OrderStatusEnum.已下单).OrderByDescending(e => e.CreateTime).Take(5).ToList();
            var waitSendGoodsNum = _orderInfoRepository.Count(e => e.Status == (int)OrderStatusEnum.已下单);

            return Json(new { waitSendGoodsList, waitSendGoodsNum });
            //var waitDealWithList = _orderInfoRepository.
            //var waitDealWithNum = _orderInfoRepository.Count(e => e.Status == (int)OrderStatusEnum.已发货);
        }
    }
}
