using SexShop.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Entity
{
    /// <summary>
    /// 用户订单表
    /// </summary>
    public class OrderInfo : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNo { get; set; }

        /// <summary>
        /// 交易编号(支付宝\微信编号)
        /// </summary>
        public string TransactionNo { get; set; }

        /// <summary>
        /// 运费
        /// </summary>
        public decimal Freight { get; set; }

        /// <summary>
        /// 收货地址Id
        /// </summary>
        public int RaId { get; set; }

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
        public int IsDel { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 付款时间
        /// </summary>
        public DateTime PaymentTime { get; set; }

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
