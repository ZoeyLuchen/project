using SexShop.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Entity
{
    /// <summary>
    /// 采购信息表
    /// </summary>
    public class PurchaseInfo : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 采购标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 采购内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }

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
        public int IsDel { get; set; }
    }
}
