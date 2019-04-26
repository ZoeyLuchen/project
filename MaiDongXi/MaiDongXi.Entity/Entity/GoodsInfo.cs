using MaiDongXi.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiDongXi.Entity
{
    public class GoodsInfo : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 规格描述
        /// </summary>
        public string SpecificationDesc { get; set; }

        /// <summary>
        /// 赠送信息描述
        /// </summary>
        public string GiftDesc { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 商品状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDel { get; set; }
    }

    public enum GoodsStatusEnum
    {
        已上架 = 1,
        已下架 = 2
    }
}
