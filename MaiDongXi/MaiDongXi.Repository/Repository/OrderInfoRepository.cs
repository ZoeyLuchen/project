using MaiDongXi.Entity;
using MaiDongXi.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MaiDongXi.Repository.Repository
{
    class OrderInfoRepository : EntityBaseRepository<OrderInfo>, IOrderInfoRepository, IAutofacBase
    {
        public OrderInfoRepository(MDXDbContext context) : base(context)
        {
        }

        public PageModel<OrderInfoView> GetListByPages(PageInfo pageInfo, OrderInfoParam param)
        {
            string sql = "";
            string sqlCount = "";

            var list = _context.Database.SqlQuery<OrderInfoView>(sql);
            var count = _context.Database.ExecuteSqlCommand(sqlCount);

            return new PageModel<OrderInfoView>(list, pageInfo.PageIndex, pageInfo.PageSize, count);
        }
    }
}
