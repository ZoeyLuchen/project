using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SexShop.IRepository;
using SexShop.Entity;
using System.IO;
using Microsoft.Extensions.Options;
using SexShop.Common;
using System.DrawingCore;

namespace SexShop.Controllers
{
    public class GoodsCommentController : BaseController
    {
        private IGoodsCommentRepository _goodsCommentRepository;
        private IGoodsCommentImgRepository _goodsCommentImgRepository;
        private AppSetting Config;

        public GoodsCommentController(IGoodsCommentRepository goodsCommentRepository,
            IGoodsCommentImgRepository goodsCommentImgRepository,
            IOptions<AppSetting> appSetting)
        {
            _goodsCommentRepository = goodsCommentRepository;
            _goodsCommentImgRepository = goodsCommentImgRepository;
            Config = appSetting.Value;
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

        /// <summary>
        /// 添加商品评论
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IActionResult AddComment(GoodsCommentView model)
        {
            var userId = CurrentUser.Id;

            GoodsComment goodsComment = new GoodsComment()
            {
                Comment = model.Comment,
                CreateBy = userId,
                CreateTime = model.CreateTime,
                DescScore = model.DescScore,
                GoodsId = model.GoodsId,
                UpdateBy = userId,
                UpdateTime = model.UpdateTime,
                WlScore = model.WlScore
            };

            var bo = _goodsCommentRepository.AddComment(goodsComment, model.ImgList);
            if (bo)
            {
                return JsonOk("");
            }
            else
            {
                return JsonError();
            }
        }

        /// <summary>
        /// 图片上传
        /// </summary>
        /// <returns></returns>
        public IActionResult UpLoadImg()
        {
            try
            {
                var date = Request;
                var files = Request.Form.Files;
                //long size = files.Sum(f => f.Length);
                string webRootPath = Config.HttpUrl;
                string imgUpLoadUrl = Config.ImgUpLoadUrl + "/" + DateTime.Now.ToString("yyyyMMdd") + "/";
                List<dynamic> list = new List<dynamic>();
                foreach (var formFile in files)
                {
                    if (formFile.Length > 0)
                    {
                        string fileExt = formFile.FileName.Substring(formFile.FileName.LastIndexOf(".") + 1, (formFile.FileName.Length - formFile.FileName.LastIndexOf(".") - 1)); //文件扩展名，不含“.”
                        long fileSize = formFile.Length; //获得文件大小，以字节为单位
                        string newFileName = System.Guid.NewGuid().ToString() + "." + fileExt; //随机生成新的文件名
                        string newFileNameSlt = "Min_" + newFileName; //随机生成新的文件名
                        var filePath = imgUpLoadUrl + newFileName;
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            formFile.CopyTo(stream);
                        }

                        ImageHelper.ResizeImage(new Bitmap(filePath), new Size(new Point(80, 80))).Save(newFileNameSlt);

                        list.Add(new { imgUrl = webRootPath + imgUpLoadUrl + newFileName, sltImgUrl = webRootPath + imgUpLoadUrl + newFileNameSlt });
                    }
                }

                return JsonOk(list);
            }
            catch (Exception e)
            {
                return JsonError(e.Message);
            }
           
        }
    }
}