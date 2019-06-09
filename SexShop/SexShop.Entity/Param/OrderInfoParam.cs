using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Entity
{
    public class OrderInfoParam
    {
        /// <summary>
        /// 订单状态状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        public string Consignee { get; set; }

        /// <summary>
        /// 收货人电话
        /// </summary>
        public string Phone { get; set; }

        public DateTime? BeginTime { get; set; }


        public DateTime? EndTime { get; set; }
    }
}
