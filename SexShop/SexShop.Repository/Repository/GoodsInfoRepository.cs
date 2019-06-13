using MySql.Data.MySqlClient;
using SexShop.Entity;
using SexShop.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace SexShop.Repository.Repository
{
    public class GoodsInfoRepository : EntityBaseRepository<GoodsInfo>, IGoodsInfoRepository, IAutofacBase
    {
        public GoodsInfoRepository(SexShopDbContext context) : base(context)
        {

        }

        /// <summary>
        /// 根据查询条件，搜索商品
        /// </summary>
        /// <param name="searchModel"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public PageModel<GoodsInfo> SearchGoodsList(GoodsSearchModel searchModel, PageInfo page)
        {
            string sqlWhere = " where isDel = 0 ";
            string orderStr = "";
            var sqlParam = new List<DbParameter>();
            if (!string.IsNullOrEmpty(searchModel.GoodsTypeCode))
            {
                sqlWhere += " and GoodsTypeCode like @GoodsTypeCode ";
                sqlParam.Add(new MySqlParameter("@GoodsTypeCode", searchModel.GoodsTypeCode+"%"));
            }
            if (!string.IsNullOrEmpty(searchModel.Key))
            {
                sqlWhere += " and (GoodsName like @Key or GoodsDesc like @Key)  ";
                sqlParam.Add(new MySqlParameter("@Key", "%" + searchModel.Key + "%"));
            }
            if (searchModel.BeginPrice != null)
            {
                sqlWhere += " and (BeginDisplayPrice >= @BeginPrice or EndDisplayPrice >=@BeginPrice )";
                sqlParam.Add(new MySqlParameter("@Consignee", searchModel.BeginPrice ));
            }
            if (searchModel.EndPrice != null)
            {
                sqlWhere += " and (BeginDisplayPrice <= @EndPrice or EndDisplayPrice <= @EndPrice )";
                sqlParam.Add(new MySqlParameter("@EndPrice", searchModel.EndPrice));
            }

            if (searchModel.OrderBy == GoodsOrderByEnum.价格排序)
            {
                orderStr += " order by  BeginDisplayPrice ";
            }
            if (searchModel.OrderBy == GoodsOrderByEnum.综合排序)
            {
                /*
                 商品综合排序跟10项因素相关（会变化），具体如下 影响宝贝排名的重要因素的权重占比（会变化）：
                    成交量：15%
                    好评率：10%
                    收藏量：8%
                    上下架：12%
                    转化率：14%
                    橱窗推荐：10%
                    回购率：10%
                    DSR：8% 卖家服务评级系统(Detail Seller Rating）
                 */

                orderStr += " order by  SalesVolume desc ,BeginDisplayPrice desc  ";
            }
            if (searchModel.OrderBy == GoodsOrderByEnum.销量排序)
            {
                orderStr += " order by  SalesVolume ";
            }

            if (searchModel.OrderBy == GoodsOrderByEnum.综合排序 && searchModel.IsDesc )
            {
                orderStr += " Desc ";
            }

            string sql = @"select * from GoodsInfo " + sqlWhere + orderStr;
            //string sqlCount = "select count(*) from GoodsInfo o " + sqlWhere;

            var list = _context.Database.SqlQuery<GoodsInfo>(sql.ToPaginationSql(page), sqlParam.ToArray());
            //var count = _context.Database.ExcuteSclare(sqlCount, sqlParam.ToArray());

            return new PageModel<GoodsInfo>(list, page.PageIndex, page.PageSize,null);
        }
    }
}
