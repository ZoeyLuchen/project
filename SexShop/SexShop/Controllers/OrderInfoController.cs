using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SexShop.Entity;
using Microsoft.AspNetCore.Mvc;
using SexShop.IRepository;

namespace SexShop.Controllers
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
        /// 后台列表页面
        /// </summary>
        /// <returns></returns>
        public IActionResult ManageIndex()
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
        /// 修改订单状态
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public IActionResult ChangeStatus([FromBody]OrderInfo oldModel)
        {
            try
            {
                var orderModel = _orderInfoRepository.GetSingle(oldModel.Id);
                orderModel.Status = oldModel.Status;
                _orderInfoRepository.Update(orderModel);
                _orderInfoRepository.Commit();
                return JsonOk("", "操作成功");
            }
            catch (Exception)
            {
                return JsonOk("", "操作失败");
            }           
        }

        /// <summary>
        /// 订单明细页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Detial(int id)
        {
            ViewBag.Id = id;
            return View();
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