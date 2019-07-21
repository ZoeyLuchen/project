using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace InsteadBuyPlatform.Repository.Repository
{
    class OrderInfoRepository : EntityBaseRepository<OrderInfo>, IOrderInfoRepository, IAutofacBase
    {
        public OrderInfoRepository(InsteadBuyPlatformDbContext context) : base(context)
        {
        }

        /// <summary>
        /// 后台订单列表查询
        /// </summary>
        /// <param name="param"></param>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public PageModel<OrderInfoView2> SearchListByPage(OrderInfoParam param, PageInfo pageInfo)
        {
            var sqlParam = new List<DbParameter>();
            string sqlWhere = " where oi.isDel=0 and oi.userId=@UserId ";
            sqlParam.Add(new MySqlParameter("@UserId", param.UserId));

            if (param.BeginDate != null)
            {
                sqlWhere += " and oi.CreateTime > @BeginDate ";
                sqlParam.Add(new MySqlParameter("@BeginDate", param.BeginDate));
            }

            if (param.EndDate != null)
            {
                sqlWhere += " and oi.CreateTime < @EndDate ";
                sqlParam.Add(new MySqlParameter("@EndDate", param.EndDate));
            }

            if (!string.IsNullOrEmpty(param.ClientName))
            {
                sqlWhere += " and (ci.ClientName like @ClientName or ci.ClientPhone like @ClientName) ";
                sqlParam.Add(new MySqlParameter("@ClientName", "%" + param.ClientName + "%"));
            }

            string sql = $@"SELECT oi.*,ci.ClientName,ci.ClientPhone 
                            from orderinfo oi
                            LEFT JOIN clientinfo ci on oi.clientId = ci.id {sqlWhere} order by oi.id desc ";

            string sqlCount = $@"SELECT count(*)  
                            from orderinfo oi
                            LEFT JOIN clientinfo ci on oi.clientId = ci.id {sqlWhere} ";

            var list = _context.Database.SqlQuery<OrderInfoView2>(sql.ToPaginationSql(pageInfo), sqlParam.ToArray());
            var count = _context.Database.ExcuteSclare(sqlCount, sqlParam.ToArray());

            return new PageModel<OrderInfoView2>(list, pageInfo.PageIndex, pageInfo.PageSize, Convert.ToInt32(count));
        }

        /// <summary>
        /// 根据订单Id查询订单商品
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<OrderGoodsView> GetOrderGoodsList(int orderId)
        {
            string sql = $@"select og.*,CONCAT(gi.goodsName,'(',gb.ChsBrandName,')') as goodsName,gs.SpecificationName as GsName 
                            from ordergoods og
                            LEFT JOIN goodsinfo gi on og.goodsId =gi.id
                            LEFT JOIN goodsbrand gb on gi.gbid = gb.id
                            LEFT JOIN goodsspecification gs on og.gsId = gs.id
                            where og.orderId = {orderId}";
            var list = _context.Database.SqlQuery<OrderGoodsView>(sql);
            return list;
        }

        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="orderInfoView"></param>
        /// <returns></returns>
        public bool AddOrder(OrderInfoView orderInfoView)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var orderInfo = new OrderInfo()
                    {
                        ClientId = orderInfoView.ClientId ?? 0,
                        CreateTime = DateTime.Now,
                        UserId = orderInfoView.UserId,
                        IsDel = 0,
                        IsPrint = 0
                    };

                    var entityEntry = _context.Set<OrderInfo>().Add(orderInfo);
                    _context.SaveChanges();

                    foreach (var item in orderInfoView.OrderGoodsList)
                    {
                        item.OrderId = entityEntry.Entity.Id;

                        _context.Set<OrderGoods>().Add(item);
                    }
                    _context.SaveChanges();

                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }


        /// <summary>
        /// 按品牌统计
        /// </summary>
        /// <returns></returns>
        public List<StatisticsView> GetDataByBrand(StatisticsParam param)
        {
            var sqlParam = new List<DbParameter>();
            string sqlWhere = " where oi.userId=@UserId ";
            sqlParam.Add(new MySqlParameter("@UserId", param.UserId));

            if (param.BeginDate != null)
            {
                sqlWhere += " and oi.CreateTime > @BeginDate ";
                sqlParam.Add(new MySqlParameter("@BeginDate", param.BeginDate));
            }

            if (param.EndDate != null)
            {
                sqlWhere += " and oi.CreateTime < @EndDate ";
                sqlParam.Add(new MySqlParameter("@EndDate", param.EndDate));
            }

            string sql = $@"select gb.ChsBrandName,gb.EnBrandName,gi.GoodsName,gs.SpecificationName,CONVERT(sum(og.GoodsNum),SIGNED) as num 
                            from orderinfo oi
                            LEFT JOIN ordergoods og on oi.id = og.orderId
                            LEFT JOIN goodsinfo gi on og.goodsId = gi.id
                            LEFT JOIN goodsspecification gs on og.gsId = gs.Id
                            LEFT JOIN goodsbrand gb on gi.gbId = gb.id
                            {sqlWhere}
                            group BY gb.id,gi.id,gs.id";
            var list = _context.Database.SqlQuery<StatisticsView>(sql, sqlParam.ToArray());
            return list;
        }

        /// <summary>
        /// 按客户名统计
        /// </summary>
        /// <returns></returns>
        public List<StatisticsView> GetDataByClient(StatisticsParam param)
        {
            var sqlParam = new List<DbParameter>();
            string sqlWhere = " where oi.userId=@UserId ";
            sqlParam.Add(new MySqlParameter("@UserId", param.UserId));

            if (param.BeginDate != null)
            {
                sqlWhere += " and oi.CreateTime > @BeginDate ";
                sqlParam.Add(new MySqlParameter("@BeginDate", param.BeginDate));
            }

            if (param.EndDate != null)
            {
                sqlWhere += " and oi.CreateTime < @EndDate ";
                sqlParam.Add(new MySqlParameter("@EndDate", param.EndDate));
            }

            string sql = $@"select ci.ClientName, gb.ChsBrandName,gb.EnBrandName,gi.GoodsName,gs.SpecificationName,CONVERT(sum(og.GoodsNum),SIGNED) as num 
                            from orderinfo oi
                            LEFT JOIN clientinfo ci on oi.ClientId = ci.id
                            LEFT JOIN ordergoods og on oi.id = og.orderId
                            LEFT JOIN goodsinfo gi on og.goodsId = gi.id
                            LEFT JOIN goodsspecification gs on og.gsId = gs.Id
                            LEFT JOIN goodsbrand gb on gi.gbId = gb.id
                            {sqlWhere}
                            group BY ci.id,gb.id,gi.id,gs.id";
            var list = _context.Database.SqlQuery<StatisticsView>(sql, sqlParam.ToArray());
            return list;
        }
    }
}
