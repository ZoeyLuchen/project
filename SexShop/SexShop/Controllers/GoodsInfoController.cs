using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SexShop.IRepository;
using SexShop.Entity;

namespace SexShop.Controllers
{
    public class GoodsInfoController : BaseController
    {
        IGoodsInfoRepository _goodsInfoRepository;
        public GoodsInfoController(IGoodsInfoRepository goodsInfoRepository)
        {
            _goodsInfoRepository = goodsInfoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 根据商品类型获取每种类型的前5条商品
        /// </summary>
        public IActionResult GetGoodsListTop5(string goodsTypeCode)
        {
           var list = _goodsInfoRepository.FindBy(e => e.GoodsTypeCode == goodsTypeCode && e.Status == (int)GoodsStatusEnum.已上架 && e.IsDel == false)
                .OrderByDescending(e => e.IsTop).OrderByDescending(e => e.CreateTime).Take(5);

            return JsonOk(list);
        }


    }
}