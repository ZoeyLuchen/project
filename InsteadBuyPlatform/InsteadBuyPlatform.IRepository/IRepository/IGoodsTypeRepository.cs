using InsteadBuyPlatform.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.IRepository
{
    public interface IGoodsTypeRepository : IEntityBaseRepository<GoodsType>
    {
        PageModel<GoodsType> SearchListByPage(GoodsTypeParam param, PageInfo pageInfo);
    }
}
