using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SexShop.IRepository;
using SexShop.Entity;

namespace SexShop.Controllers
{
    public class GoodsCommentController : BaseController
    {
        private IGoodsCommentRepository _goodsCommentRepository;
        private IGoodsCommentImgRepository _goodsCommentImgRepository;

        public GoodsCommentController(IGoodsCommentRepository goodsCommentRepository,
            IGoodsCommentImgRepository goodsCommentImgRepository)
        {
            _goodsCommentRepository = goodsCommentRepository;
            _goodsCommentImgRepository = goodsCommentImgRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 根据商品Id获取商品评论列表
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public IActionResult GetAllCommentByGoodsId(int goodsId, PageInfo pageInfo)
        {
            var goodsCommentList = _goodsCommentRepository.FindBy(e => e.GoodsId == goodsId && e.IsDel == false)
                 .OrderByDescending(e => e.CreateTime)
                 .Skip((pageInfo.PageIndex - 1) * pageInfo.PageSize)
                 .Take(pageInfo.PageSize).ToList();

            var list = GetViewList(goodsCommentList);

            var result = new PageModel<GoodsCommentView>(list, pageInfo.PageIndex, pageInfo.PageSize);
            return Json(result);
        }

        /// <summary>
        /// 根据商品Id获取我的商品评论列表
        /// </summary>
        /// <param name="goodsId"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public IActionResult GetMyCommentByGoodsId(int goodsId, PageInfo pageInfo)
        {
            var userId = CurrentUser.Id;

            var goodsCommentList = _goodsCommentRepository.FindBy(e => e.GoodsId == goodsId && e.IsDel == false && e.CreateBy == userId)
                 .OrderByDescending(e => e.CreateTime)
                 .Skip((pageInfo.PageIndex - 1) * pageInfo.PageSize)
                 .Take(pageInfo.PageSize).ToList();

            var list = GetViewList(goodsCommentList);

            var result = new PageModel<GoodsCommentView>(list, pageInfo.PageIndex, pageInfo.PageSize);
            return Json(result);
        }

        private List<GoodsCommentView> GetViewList(List<GoodsComment> list)
        {
            var newList = new List<GoodsCommentView>();

            if (list.Any())
            {
                list.ForEach(e =>
                {
                    GoodsCommentView view = new GoodsCommentView()
                    {
                        Comment = e.Comment,
                        CreateBy = e.CreateBy,
                        CreateTime = e.CreateTime,
                        DescScore = e.DescScore,
                        GoodsId = e.GoodsId,
                        Id = e.Id,
                        UpdateBy = e.UpdateBy,
                        UpdateTime = e.UpdateTime,
                        WlScore = e.WlScore,
                        ImgList = _goodsCommentImgRepository.FindBy(g => g.GCId == e.Id).ToList()
                    };

                    newList.Add(view);
                });
            }

            return newList;
        }

        public IActionResult AddComment(GoodsCommentView model)
        {
            try
            {
                GoodsComment goodsComment = new GoodsComment()
                {
                    Comment = model.Comment,
                    CreateBy = model.CreateBy,
                    CreateTime = model.CreateTime,
                    DescScore = model.DescScore,
                    GoodsId = model.GoodsId,
                    Id = model.Id,
                    UpdateBy = model.UpdateBy,
                    UpdateTime = model.UpdateTime,
                    WlScore = model.WlScore
                };

                var id = _goodsCommentRepository.AddComment(goodsComment, model.ImgList);
                
                if (model.ImgList.Any())
                {
                    _goodsCommentImgRepository.BatchAdd(model.ImgList);
                }
                _goodsCommentRepository.Commit();
            }
            catch (Exception)
            {
                _goodsCommentRepository.
            }
            
        }
    }
}