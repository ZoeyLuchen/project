using SexShop.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Entity
{
    /// <summary>
    /// 商品表
    /// </summary>
    public class GoodsInfo : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 商品类型Code
        /// </summary>
        public string GoodsTypeCode { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 商品描述
        /// </summary>
        public string GoodsDesc { get; set; }

        /// <summary>
        /// 商品图片  用;分割
        /// </summary>
        public string GoodsImgs { get; set; }

        /// <summary>
        /// 显示价格最低价
        /// </summary>
        public decimal? BeginDisplayPrice { get; set; }

        /// <summary>
        /// 显示价格最高价
        /// </summary>
        public decimal? EndDisplayPrice { get; set; }

        /// <summary>
        /// 商品地址  填 广东 深圳
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 商品明细图片地址集合 
        /// </summary>
        public string GoodsDeatilImgs { get; set; }

        /// <summary>
        /// 商品状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool IsTop { get; set; }

        /// <summary>
        /// 销量
        /// </summary>
        public int SalesVolume { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>        
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public int UpdateBy { get; set; }

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
