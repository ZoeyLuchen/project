using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.Entity
{
    public class GoodsInfoView : GoodsInfo
    {
        /// <summary>
        /// 中文品牌名
        /// </summary>
        public string ChsBrandName { get; set; }

        /// <summary>
        /// 英文品牌名
        /// </summary>
        public string EnBrandName { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 规格数量
        /// </summary>
        public Int64 GsNumber { get; set; }

    }
}
