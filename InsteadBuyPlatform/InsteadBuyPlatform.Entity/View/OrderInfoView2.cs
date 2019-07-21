using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.Entity
{
    public class OrderInfoView2 : OrderInfo
    {
        /// <summary>
        /// 客户名
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// 客户电话
        /// </summary>
        public string ClientPhone { get; set; }
    }
}
