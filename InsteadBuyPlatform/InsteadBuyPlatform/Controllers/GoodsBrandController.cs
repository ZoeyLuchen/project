using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.IRepository;

namespace InsteadBuyPlatform.Controllers
{
    /// <summary>
    /// 商品品牌
    /// </summary>
    public class GoodsBrandController : BaseController
    {
        IGoodsBrandRepository _goodsBrandRepository;

        public GoodsBrandController(IGoodsBrandRepository goodsBrandRepository)
        {
            _goodsBrandRepository = goodsBrandRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult Add(GoodsBrand model)
        {
            model.IsDel = false;

            try
            {
                _goodsBrandRepository.Add(model);
                return JsonOk("");
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        /// <summary>
        /// 修改(删除)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult Modify(GoodsBrand model)
        {
            try
            {
                var oldModel = _goodsBrandRepository.GetSingle(model.Id);
                oldModel.BrandName = model.BrandName;
                oldModel.IsDel = model.IsDel;
                _goodsBrandRepository.Update(oldModel);
                return JsonOk("");
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        /// <summary>
        /// 获取前8个品牌
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public IActionResult GetTop8(string key = "")
        {
            if (string.IsNullOrEmpty(key))
            {
                return JsonOk(_goodsBrandRepository.FindBy(e => e.IsDel == false).Take(8).ToList());
            }
            else
            {
                return JsonOk(_goodsBrandRepository.FindBy(e => e.IsDel == false && e.BrandName.Contains(key)).Take(8).ToList());
            }            
        }
    }
}