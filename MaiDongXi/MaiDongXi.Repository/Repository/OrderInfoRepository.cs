using MaiDongXi.Entity;
using MaiDongXi.IRepository;
using MaiDongXi.IRepository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiDongXi.Repository.Repository
{
    class OrderInfoRepository : EntityBaseRepository<OrderInfo>, IOrderInfoRepository, IAutofacBase
    {
        public OrderInfoRepository(MDXDbContext context) : base(context)
        {
        }
    }
}
