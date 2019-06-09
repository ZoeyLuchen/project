using SexShop.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Entity
{
    /// <summary>
    /// 收货地址表
    /// </summary>
    public class ReceivingAddress : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 省 Code
        /// </summary>
        public string ProvinceCode { get; set; }

        /// <summary>
        /// 省名
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// 市Code
        /// </summary>
        public string CityCode { get; set; }

        /// <summary>
        /// 市名称
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 县Code
        /// </summary>
        public string CountyCode { get; set; }

        /// <summary>
        /// 县名
        /// </summary>
        public string CountyName { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string DetailedAddress { get; set; }

        /// <summary>
        /// 收货人
        /// </summary>
        public string Consignee { get; set; }

        /// <summary>
        /// 收货人电话
        /// </summary>
        public string Call { get; set; }

        /// <summary>
        /// 是否是默认地址
        /// </summary>
        public bool IsDefault { get; set; }

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
