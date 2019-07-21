using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.Entity
{
    public class OrderInfoParam
    {
        /// <summary>
        /// 所属用户
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string ClientName { get; set; }

        public DateTime? BeginDate { get; set; }


        public DateTime? EndDate { get; set; }
    }
}
