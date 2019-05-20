using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaiDongXi.Entity;
using Microsoft.AspNetCore.Mvc;
using MaiDongXi.IRepository;

namespace MaiDongXi.Controllers
{
    public class OrderInfoController : BaseController
    {
        IOrderInfoRepository _orderInfoRepository;
        ISendGoodsInfoRepository _sendGoodsInfoRepository;

        public OrderInfoController(IOrderInfoRepository orderInfoRepository, ISendGoodsInfoRepository sendGoodsInfoRepository)
        {
            _orderInfoRepository = orderInfoRepository;
            _sendGoodsInfoRepository = sendGoodsInfoRepository;
        }

        /// <summary>
        /// 后台列表页面
        /// </summary>
        /// <returns></returns>
        public IActionResult ManageIndex(int status = 0)
        {
            ViewBag.Status = status;
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
        /// 发货
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SendGoods([FromBody]SendGoodsInfo sendGoods)
        {
            try
            {
                var orderModel = _orderInfoRepository.GetSingle(sendGoods.OrderId);
                orderModel.Status = (int)OrderStatusEnum.已发货;
                _orderInfoRepository.Update(orderModel);

                sendGoods.CreateTime = DateTime.Now;
                _sendGoodsInfoRepository.Add(sendGoods);

                _orderInfoRepository.Commit();
                _sendGoodsInfoRepository.Commit();

                return JsonOk("", "发货成功");
            }
            catch (Exception)
            {
                return JsonError("发货失败");
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