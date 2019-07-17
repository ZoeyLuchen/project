using InsteadBuyPlatform.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.Entity
{
    /// <summary>
    /// 用户订单表
    /// </summary>
    public class OrderInfo : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 收货客户
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// 是否打单
        /// </summary>
        public int IsPrint { get; set; }       

        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDel { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
