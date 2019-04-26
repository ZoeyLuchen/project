using System;
using System.Collections.Generic;
using System.Text;

namespace MaiDongXi.Entity
{
    public class PageModel<T>
    {
        /// <summary>
        /// 分页视图要显示的数据项
        /// </summary>
        /// <value></value>
        public List<T> Items { get; set; }
        /// <summary>
        /// 当前页码索引
        /// </summary>
        /// <value></value>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页显示记录数
        /// </summary>
        /// <value></value>
        public int PageSize { get; set; }
        /// <summary>
        /// 数据总记录数
        /// </summary>
        /// <value></value>
        public int TotalCount { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        /// <value></value>
        public int PageCount
        {
            get
            {
                return (int)Math.Ceiling((double)this.TotalCount / (double)this.PageSize);
            }
        }    

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="items">显示项</param>
        /// <param name="pageIndex">页码索引项</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalCount">总记录数</param>
        /// <value></value>
        public PageModel(List<T> items, int pageIndex, int pageSize, int totalCount)
        {
            this.Items = items;
            this.TotalCount = totalCount;
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
        }
    }
}
