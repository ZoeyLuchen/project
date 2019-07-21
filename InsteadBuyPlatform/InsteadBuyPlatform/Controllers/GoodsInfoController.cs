using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsteadBuyPlatform.IRepository;
using InsteadBuyPlatform.Entity;

namespace InsteadBuyPlatform.Controllers
{
    public class GoodsInfoController : BaseController
    {
        IGoodsInfoRepository _goodsInfoRepository;
        IGoodsSpecificationRepository _goodsSpecificationRepository;
        public GoodsInfoController(IGoodsInfoRepository goodsInfoRepository,
            IGoodsSpecificationRepository goodsSpecificationRepository)
        {
            _goodsInfoRepository = goodsInfoRepository;
            _goodsSpecificationRepository = goodsSpecificationRepository;
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
        public IActionResult SearchListByPage(GoodsInfoParam param, PageInfo pageInfo)
        {
            var result = _goodsInfoRepository.SearchListByPage(param, pageInfo);
            return Json(result);
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult AddGoods([FromBody]GoodsInfo model)
        {
            try
            {
               

                model.CreateBy = CurrentUser.Id;
                model.CreateTime = DateTime.Now;
                model.IsDel = 0;
                model.UpdateBy = CurrentUser.Id;
                model.UpdateTime = DateTime.Now;

                _goodsInfoRepository.Add(model);

                return JsonOk("");
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        /// <summary>
        /// 修改商品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult ModifyGoods([FromBody]GoodsInfo model)
        {
            try
            {
                var oldModel = _goodsInfoRepository.GetSingle(e => e.Id == model.Id);

                oldModel.GoodsDesc = model.GoodsDesc;
                oldModel.GoodsName = model.GoodsName;
                oldModel.UpdateBy = CurrentUser.Id;
                oldModel.UpdateTime = DateTime.Now;

                _goodsInfoRepository.Update(oldModel);

                return JsonOk("");
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult DelGoodsInfo([FromBody]GoodsInfo model)
        {
            try
            {
                var oldModel = _goodsInfoRepository.GetSingle(e => e.Id == model.Id);
                oldModel.IsDel = 1;
                _goodsInfoRepository.Update(oldModel);

                return JsonOk("");
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        /// <summary>
        /// 根据商品Id获取所有商品规格
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        public IActionResult getGsList(int goodsId)
        {
            return Json(_goodsSpecificationRepository.FindBy(e => e.IsDel == 0 && e.GoodsId == goodsId).ToList());
        }

        /// <summary>
        /// 批量新增、修改、删除商品规格
        /// </summary>
        public IActionResult AddOrModifyGs([FromBody]List<GoodsSpecification> list)
        {
            try
            {
                var newList = list.Where(e => e.Id == 0 && e.IsDel ==0).ToList();
                newList.ForEach(e =>
                {
                    e.CreateBy = e.UpdateBy = CurrentUser.Id;
                    e.CreateTime = e.UpdateTime = DateTime.Now;
                });
                _goodsSpecificationRepository.BatchAdd(newList);

                var modifyList = list.Where(e => e.Id != 0).ToList();
                modifyList.ForEach(e =>
                {
                    e.UpdateBy = CurrentUser.Id;
                    e.UpdateTime = DateTime.Now;
                });
                _goodsSpecificationRepository.BatchUpdate(modifyList);

                return JsonOk("");
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
           
        }

        #region 移动端调用
        /// <summary>
        /// 根据查询条件 查询商品列表
        /// </summary>
        /// <param name="searchModel"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public IActionResult SearchGoodsList(GoodsSearchModel searchModel)
        {
            var list = _goodsInfoRepository.SearchGoodsList(searchModel);
            return JsonOk(list);
        }

        /// <summary>
        /// 获取商品所有规格
        /// </summary>
        /// <param name="goodsId"></param>
        /// <returns></returns>
        public IActionResult GetSpecificationList(int goodsId)
        {
            return JsonOk(_goodsSpecificationRepository.FindBy(e => e.GoodsId == goodsId && e.IsDel == 0));
        }
        #endregion

    }
}