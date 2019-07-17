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
                    ClientInfo clientInfo = new ClientInfo() {
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
    }
}