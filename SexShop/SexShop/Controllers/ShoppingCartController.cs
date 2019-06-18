using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SexShop.IRepository;
using SexShop.Entity;

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

        public IActionResult GetMyCartList(PageInfo page)
        {
            int userId = CurrentUser.Id;

            _shoppingCartRepository.FindBy(e=>e.)
        }
    }
}