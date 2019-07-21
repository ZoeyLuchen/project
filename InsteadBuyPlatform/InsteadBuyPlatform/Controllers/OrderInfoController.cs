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
        IOrderGoodsRepository _orderGoodsRepository;
        IClientInfoRepository _clientInfoRepository;

        public OrderInfoController(IOrderInfoRepository orderInfoRepository, 
            IOrderGoodsRepository orderGoodsRepository,
            IClientInfoRepository clientInfoRepository)
        {
            _orderInfoRepository = orderInfoRepository;
            _orderGoodsRepository = orderGoodsRepository;
            _clientInfoRepository = clientInfoRepository;
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
        /// 查询数据列表
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public IActionResult SearchListByPage(OrderInfoParam param, PageInfo pageInfo)
        {
            param.UserId = CurrentUser.Id;
            if(param.BeginDate != null)
                param.BeginDate = DateTime.Parse(string.Format("{0:yyyy-MM-dd}", param.BeginDate) + " 00:00:00");
            if (param.EndDate != null)
                param.EndDate = DateTime.Parse(string.Format("{0:yyyy-MM-dd}", param.EndDate) + " 23:59:59");

            var result = _orderInfoRepository.SearchListByPage(param, pageInfo);
            return Json(result);
        }

        /// <summary>
        /// 查询数据列表
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public IActionResult GetOrderGoodsList(int orderId)
        {
            var result = _orderInfoRepository.GetOrderGoodsList(orderId);
            return Json(result);
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult DelOrderInfo([FromBody] OrderInfo model)
        {
            try
            {
                var oldModel = _orderInfoRepository.GetSingle(e => e.Id == model.Id);
                oldModel.IsDel = 1;
                _orderInfoRepository.Update(oldModel);

                return JsonOk("");
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }


        #region 移动端接口
        [HttpGet]
        public IActionResult AddOrder()
        {
            return View();
        }

        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="orderInfoView"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddOrder([FromBody]OrderInfoView orderInfoView)
        {
            var userId = CurrentUser.Id;

            if (string.IsNullOrEmpty(orderInfoView.ClientName))
            {
                return JsonError("客户信息未填写");
            }
            orderInfoView.ClientName = orderInfoView.ClientName.Trim();
            if (orderInfoView.ClientId == null)
            {
                var clientModel = _clientInfoRepository.FindBy(e => e.UserId == userId && e.ClientName == orderInfoView.ClientName && e.IsDel == 0);

                if (clientModel.Any())
                {
                    return JsonError("该客户信息已存在,请直接选择");
                }
                else
                {
                    ClientInfo clientInfo = new ClientInfo()
                    {
                        ClientName = orderInfoView.ClientName,
                        UserId = userId,
                        IsDel = 0,
                        CreateTime = DateTime.Now,
                        UpdateTime = DateTime.Now
                    };

                    var clientId = _clientInfoRepository.Add(clientInfo);
                    orderInfoView.ClientId = clientId;
                }
            }

            try
            {
                orderInfoView.UserId = userId;
                _orderInfoRepository.AddOrder(orderInfoView);
                return JsonOk("");
            }
            catch (Exception e)
            {
                return JsonError(e.Message);
            }
        }
        #endregion
    }
}