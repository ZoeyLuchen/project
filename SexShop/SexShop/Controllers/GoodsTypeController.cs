using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SexShop.IRepository;
using SexShop.Entity;

namespace SexShop.Controllers
{
    public class GoodsTypeController : BaseController
    {
        private IGoodsTypeRepository _goodsTypeRepository;
        public GoodsTypeController(IGoodsTypeRepository goodsTypeRepository) {
            _goodsTypeRepository = goodsTypeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 返回所有一级类型
        /// </summary>
        /// <returns></returns>
        public IActionResult GetOneLvTypeList()
        {
            var list = _goodsTypeRepository.FindBy(e => e.PCode == "" && e.IsDel == false).OrderBy(e => e.OrderNum);

            return JsonOk(list);
        }

        /// <summary>
        /// 返回整个类型列表
        /// </summary>
        /// <returns></returns>
        public IActionResult GetAllList()
        {
            var list = _goodsTypeRepository.FindBy(e.IsDel == false).OrderBy(e => e.OrderNum);

            return JsonOk(list);
        }
    }
}