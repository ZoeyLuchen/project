using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.Entity
{
    public class PageInfo
    {
        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageIndex { get; set; } = 1;

        /// <summary>
        /// 每页大小
        /// </summary>
        public int PageSize { get; set; } = 10;

        /// <summary>
        /// 记录总数
        /// </summary>
        public int CountNum { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageNum { get; set; }
    }
}
