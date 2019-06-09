using SexShop.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Entity
{
    /// <summary>
    /// 用户商品收藏
    /// </summary>
    public class UserGoodsCollection : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public int GoodsId { get; set; }
    }
}
