using InsteadBuyPlatform.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.IRepository
{
    /// <summary>
    /// 商品表
    /// </summary>
    public interface IGoodsInfoRepository : IEntityBaseRepository<GoodsInfo>
    {
        List<GoodsInfo> SearchGoodsList(GoodsSearchModel searchModel);
    }
}
