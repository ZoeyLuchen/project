using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace InsteadBuyPlatform.Controllers
{
    /// <summary>
    /// 统计
    /// </summary>
    public class StatisticsController : BaseController
    {
        IOrderInfoRepository _orderInfoRepository;

        public StatisticsController(IOrderInfoRepository orderInfoRepository)
        {
            _orderInfoRepository = orderInfoRepository;
        }

        /// <summary>
        /// 按品牌统计
        /// </summary>
        /// <returns></returns>
        public IActionResult StatisticsByBrand()
        {
            ViewBag.BeginDate = DateTime.Now.AddDays(-7);
            ViewBag.EndDate = DateTime.Now;

            return View();
        }

        /// <summary>
        /// 按客户名统计
        /// </summary>
        /// <returns></returns>
        public IActionResult StatisticsByClient()
        {
            ViewBag.BeginDate = DateTime.Now.AddDays(-7);
            ViewBag.EndDate = DateTime.Now;

            return View();
        }

        /// <summary>
        /// 按品牌统计
        /// </summary>
        /// <returns></returns>
        public IActionResult GetDataByBrand(StatisticsParam param)
        {
            param.UserId = CurrentUser.Id;

            if (param.BeginDate == null || param.EndDate == null)
                return JsonError("请输入查询时间段");

            if (param.BeginDate != null)
                param.BeginDate = DateTime.Parse(string.Format("{0:yyyy-MM-dd}", param.BeginDate) + " 00:00:00");
            if (param.EndDate != null)
                param.EndDate = DateTime.Parse(string.Format("{0:yyyy-MM-dd}", param.EndDate) + " 23:59:59");

            var list = _orderInfoRepository.GetDataByBrand(param);

            return Json(list);
        }

        /// <summary>
        /// 按客户名统计
        /// </summary>
        /// <returns></returns>
        public IActionResult GetDataByClient(StatisticsParam param)
        {
            if (param.BeginDate == null || param.EndDate == null)
                return JsonError("请输入查询时间段");

            param.UserId = CurrentUser.Id;
            if (param.BeginDate != null)
                param.BeginDate = DateTime.Parse(string.Format("{0:yyyy-MM-dd}", param.BeginDate) + " 00:00:00");
            if (param.EndDate != null)
                param.EndDate = DateTime.Parse(string.Format("{0:yyyy-MM-dd}", param.EndDate) + " 23:59:59");

            var list = _orderInfoRepository.GetDataByClient(param);

            return Json(list);
        }
    }
}