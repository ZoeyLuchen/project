using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SexShop.IRepository;
using SexShop.Entity;
using System.Linq.Expressions;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace SexShop.Controllers
{
    public class ShoppingCartController : BaseController
    {
        IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取购物车中的商品
        /// </summary>
        /// <returns></returns>
        public IActionResult GetMyCartList()
        {
            int userId = CurrentUser.Id;
            var list = _shoppingCartRepository.GetMyCartList(userId);
            return JsonOk(list);
        }

        /// <summary>
        /// 添加商品到购物车
        /// </summary>
        /// <param name="goodsId">商品Id</param>
        /// <param name="gsId">商品规格Id</param>
        /// <returns></returns>
        public IActionResult AddToCart(int goodsId, int gsId, decimal price)
        {
            try
            {
                int userId = CurrentUser.Id;
                var model = _shoppingCartRepository.FindBy(e => e.GsId == gsId && e.GoodsId == goodsId).FirstOrDefault();

                if (model != null)
                {
                    model.Num = model.Num + 1;
                    _shoppingCartRepository.Update(model);
                }
                else
                {
                    model = new ShoppingCart()
                    {
                        AddTimePice = price,
                        CreateTime = DateTime.Now,
                        GoodsId = goodsId,
                        GsId = gsId,
                        Num = 1,
                        UserId = userId
                    };

                    _shoppingCartRepository.Add(model);
                }
                return JsonOk("");
            }
            catch (Exception e)
            {
                return JsonError(e.Message);
            }            
        }

        /// <summary>
        /// 修改购物车商品数量
        /// </summary>
        /// <param name="goodsId">商品Id</param>
        /// <param name="gsId">商品规格Id</param>
        /// <param name="num">商品数量</param>
        /// <returns></returns>
        public IActionResult ChangeGoodsNum(int goodsId, int gsId, int num)
        {
            try
            {
                int userId = CurrentUser.Id;
                var model = _shoppingCartRepository.FindBy(e => e.GsId == gsId && e.GoodsId == goodsId).FirstOrDefault();
                model.Num = num;
                _shoppingCartRepository.Update(model);

                return JsonOk("");
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        /// <summary>
        /// 批量删除购物车商品
        /// </summary>
        /// <param name="goodsList"></param>
        /// <returns></returns>
        public IActionResult DeleteGoods(List<ShoppingCart> goodsList)
        {
            string whereStr = "";
            var sqlParam = new List<DbParameter>();
            MySqlParameter
            goodsList.ForEach(g => { });

            _shoppingCartRepository.GetListBySql(sql,)
        }
    }
}