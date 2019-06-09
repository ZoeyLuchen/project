using SexShop.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Entity
{
    /// <summary>
    /// 库存盘点表
    /// </summary>
    public class InventoryInfo : IEntityBase
    {
        public int Id { get; set; }

        

        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDel { get; set; }
    }
}
