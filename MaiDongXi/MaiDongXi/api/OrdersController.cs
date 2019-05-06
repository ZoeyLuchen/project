using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MaiDongXi.IRepository;
using MaiDongXi.Entity;


namespace MaiDongXi.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderInfoRepository _orderInfoRepository;
        public OrdersController(IOrderInfoRepository orderInfoRepository)
        {
            _orderInfoRepository = orderInfoRepository;
        }

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public IActionResult Add([FromBody]OrderInfo model)
        {
            try
            {
                model.Status = (int)OrderStatusEnum.已下单;
                model.CreateTime = DateTime.Now;
                model.OrderNo = "";

                _orderInfoRepository.Add(model);
                _orderInfoRepository.Commit();

                return Ok();
            }
            catch (Exception )
            {
                Response.StatusCode = 500;
                return null;
            }
        }
    }
}