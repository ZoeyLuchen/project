using MaiDongXi.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiDongXi.Entity
{
    public class OrderInfo : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 产品Id
        /// </summary>
        public int GoodsId { get; set; }

        /// <summary>
        /// 省 Code
        /// </summary>
        public int ProvinceCode { get; set; }

        /// <summary>
        /// 省名
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// 市Code
        /// </summary>
        public int CityCode { get; set; }

        /// <summary>
        /// 市名称
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 县Code
        /// </summary>
        public int CountyCode { get; set; }

        /// <summary>
        /// 县名
        /// </summary>
        public string CountyName { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string DetailedAddress { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        public string Consignee { get; set; }

        /// <summary>
        /// 收货人电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int BuyQuantity { get; set; }

        /// <summary>
        /// 留言
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public int PayType { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal OrderAmount { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDel { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

    }

    public enum OrderStatusEnum
    {
        已下单 = 1,
        已发货 = 2,
        已签收 = 3,
        拒绝签收 = 4,
        快件丢失 = 5
    }

    public enum PayTypeEnum
    {
        支付宝 = 1,
        微信 = 2,
        货到付款 = 3
    }
}
