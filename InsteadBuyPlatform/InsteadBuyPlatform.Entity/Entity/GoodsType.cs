﻿using InsteadBuyPlatform.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.Entity
{
    /// <summary>
    /// 商品类型
    /// </summary>
    public class GoodsType : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 类型Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 父类型Code
        /// </summary>
        public string PCode { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDel { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>        
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int? CreateBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public int? UpdateBy { get; set; }
    }
}
