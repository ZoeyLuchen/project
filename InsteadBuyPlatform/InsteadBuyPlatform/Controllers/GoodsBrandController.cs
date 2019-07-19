using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.IRepository;
using System.Linq.Expressions;
using InsteadBuyPlatform.Common;

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
        /// 查询数据列表
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public IActionResult SearchListByPage(GoodsBrandParam param, PageInfo pageInfo)
        {
            var result = _goodsBrandRepository.SearchListByPage(param, pageInfo);
            return Json(result);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult Add([FromBody]GoodsBrand model)
        {
            try
            {
                if (_goodsBrandRepository.Count(e => e.EnBrandName == model.EnBrandName) > 0)
                {
                    return JsonError("品牌英文名重复");
                }
                if (_goodsBrandRepository.Count(e => e.ChsBrandName == model.ChsBrandName) > 0)
                {
                    return JsonError("品牌中文名重复");
                }

                model.IsDel = 0;
                model.CreateTime = model.UpdateTime = DateTime.Now;
                model.CreateBy = model.UpdateBy = CurrentUser.Id;

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
        public IActionResult Modify([FromBody]GoodsBrand model)
        {
            try
            {
                if (model.IsDel != 1 && _goodsBrandRepository.Count(e => e.Id != model.Id && e.EnBrandName == model.EnBrandName)>0)
                {
                    return JsonError("品牌英文名重复");
                }
                if (model.IsDel != 1 && _goodsBrandRepository.Count(e => e.Id != model.Id && e.ChsBrandName == model.ChsBrandName)>0)
                {
                    return JsonError("品牌中文名重复");
                }

                var oldModel = _goodsBrandRepository.GetSingle(model.Id);
                oldModel.ChsBrandName = model.ChsBrandName;
                oldModel.EnBrandName = model.EnBrandName;
                oldModel.IsDel = model.IsDel;
                oldModel.UpdateBy = CurrentUser.Id;
                oldModel.UpdateTime = DateTime.Now;
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
                return JsonOk(_goodsBrandRepository.FindBy(e => e.IsDel == 0).Take(8).ToList());
            }
            else
            {
                return JsonOk(_goodsBrandRepository.FindBy(e => e.IsDel == 0 && (e.ChsBrandName.Contains(key) || e.EnBrandName.Contains(key))).Take(8).ToList());
            }
        }
    }
}