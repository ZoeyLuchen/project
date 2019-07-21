using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsteadBuyPlatform.IRepository;
using InsteadBuyPlatform.Entity;

namespace InsteadBuyPlatform.Controllers
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
        /// 查询数据列表
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public IActionResult SearchListByPage(GoodsTypeParam param, PageInfo pageInfo)
        {
            var result = _goodsTypeRepository.SearchListByPage(param, pageInfo);
            return Json(result);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult Add([FromBody]GoodsType model)
        {
            try
            {
                if (_goodsTypeRepository.Count(e => e.TypeName == model.TypeName && e.IsDel == 0) > 0)
                {
                    return JsonError("品类名重复");
                }

                model.IsDel = 0;               
                model.UpdateTime = model.CreateTime = DateTime.Now;
                model.UpdateBy = model.CreateBy = CurrentUser.Id;
                if (string.IsNullOrEmpty(model.PCode))
                {
                    model.Code = (_goodsTypeRepository.Count(e => e.PCode == "") + 1).ToString("00");
                }
                else
                {
                    model.Code = model.PCode + (_goodsTypeRepository.Count(e => e.PCode == model.PCode) + 1).ToString("00");
                }

                if (_goodsTypeRepository.Count(e => e.Code == model.Code) > 0)
                {
                    return JsonError("品类无法添加,请联系管理员");
                }

                _goodsTypeRepository.Add(model);
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
        public IActionResult Modify([FromBody]GoodsType model)
        {
            try
            {
                if (model.IsDel != 1 && _goodsTypeRepository.Count(e => e.Id != model.Id && e.TypeName == model.TypeName && e.IsDel == 0) > 0)
                {
                    return JsonError("品类名重复");
                }

                var oldModel = _goodsTypeRepository.GetSingle(model.Id);
                oldModel.TypeName = model.TypeName;
                oldModel.IsDel = model.IsDel;
                oldModel.UpdateBy = CurrentUser.Id;
                oldModel.UpdateTime = DateTime.Now;
                _goodsTypeRepository.Update(oldModel);
                return JsonOk("");
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        /// <summary>
        /// 返回整个类型列表
        /// </summary>
        /// <returns></returns>
        public IActionResult GetAllList()
        {
            var list = _goodsTypeRepository.FindBy(e=> e.IsDel == 0);

            return JsonOk(list);
        }
    }
}