using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsteadBuyPlatform.Entity;
using Microsoft.AspNetCore.Mvc;
using InsteadBuyPlatform.IRepository;

namespace InsteadBuyPlatform.Controllers
{
    public class OrderInfoController : BaseController
    {
        IOrderInfoRepository _orderInfoRepository;

        public OrderInfoController(IOrderInfoRepository orderInfoRepository)
        {
            _orderInfoRepository = orderInfoRepository;
        }

        /// <summary>
        /// 前台下单页面
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 根据查询条件获取分页数据
        /// </summary>
        /// <param name="pageInfo"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public IActionResult GetListByPages(PageInfo pageInfo, OrderInfoParam param)
        {
            var result = _orderInfoRepository.GetListByPages(pageInfo,param);
            return JsonOk(result);
        }

        /// <summary>
        /// 获取订单明细数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult GetDetailData(int id)
        {
            return Json("");
        }
    }
}