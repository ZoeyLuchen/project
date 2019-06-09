using SexShop.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Entity
{
    /// <summary>
    /// 采购明细表
    /// </summary>
    public class PurchaseDetail : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 采购Id
        /// </summary>
        public int PurchaseId { get; set; }

        /// <summary>
        /// 商品Id
        /// </summary>
        public int GoodsId { get; set; }

        /// <summary>
        /// 商品规格Id
        /// </summary>
        public int GsId { get; set; }

        /// <summary>
        /// 采购数量
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 采购单号
        /// </summary>
        public string PurchaseNo { get;set;}

        /// <summary>
        /// 采购单价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 供应商名
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// 是否入库
        /// </summary>
        public bool IsStorage { get; set; }

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
