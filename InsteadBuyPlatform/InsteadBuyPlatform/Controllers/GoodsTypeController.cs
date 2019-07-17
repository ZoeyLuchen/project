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
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult Add(GoodsType model)
        {
            model.IsDel = 0;

            try
            {
                _goodsTypeRepository.Add(model);
                model.CreateTime = DateTime.Now;
                if (string.IsNullOrEmpty(model.PCode))
                {
                    model.Code = (_goodsTypeRepository.Count(e => e.PCode == "") + 1).ToString("000");
                }
                else
                {
                    model.Code = model.PCode + (_goodsTypeRepository.Count(e => e.PCode == model.PCode) + 1).ToString("000");
                }
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
        public IActionResult Modify(GoodsType model)
        {
            try
            {
                var oldModel = _goodsTypeRepository.GetSingle(model.Id);
                oldModel.TypeName = model.TypeName;
                oldModel.IsDel = model.IsDel;
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