using InsteadBuyPlatform.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.Entity
{
    /// <summary>
    /// 客户表
    /// </summary>
    public class ClientInfo : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 客户名
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// 客户电话
        /// </summary>
        public string ClientPhone { get; set; }

        /// <summary>
        /// 所属用户Id
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
        /// 创建时间
        /// </summary>        
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDel { get; set; }
    }
}
