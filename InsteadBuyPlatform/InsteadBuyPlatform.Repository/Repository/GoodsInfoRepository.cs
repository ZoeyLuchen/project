using MySql.Data.MySqlClient;
using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace InsteadBuyPlatform.Repository.Repository
{
    public class GoodsInfoRepository : EntityBaseRepository<GoodsInfo>, IGoodsInfoRepository, IAutofacBase
    {
        public GoodsInfoRepository(InsteadBuyPlatformDbContext context) : base(context)
        {

        }

        /// <summary>
        /// 根据查询条件，搜索商品
        /// </summary>
        /// <param name="searchModel"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public List<GoodsInfo> SearchGoodsList(GoodsSearchModel searchModel)
        {
            string sqlWhere = " where isDel = 0 ";
            var sqlParam = new List<DbParameter>();
            if (searchModel.GbId != null)
            {
                sqlWhere += " and GbId = @GbId ";
                sqlParam.Add(new MySqlParameter("@GbId", searchModel.GbId));
            }

            if (!string.IsNullOrEmpty(searchModel.GoodsTypeCode))
            {
                sqlWhere += " and GoodsTypeCode = @GoodsTypeCode ";
                sqlParam.Add(new MySqlParameter("@GoodsTypeCode", searchModel.GoodsTypeCode));
            }
            if (!string.IsNullOrEmpty(searchModel.Key))
            {
                sqlWhere += " and (GoodsName like @Key or GoodsDesc like @Key)  ";
                sqlParam.Add(new MySqlParameter("@Key", "%" + searchModel.Key + "%"));
            }

            string sql = @"select * from GoodsInfo " + sqlWhere +" limit 8 ";

            var list = _context.Database.SqlQuery<GoodsInfo>(sql, sqlParam.ToArray());
            return list;
        }

        public PageModel<GoodsInfoView> SearchListByPage(GoodsInfoParam param, PageInfo pageInfo)
        {
            string sqlWhere = " where gi.IsDel = 0 ";
            var sqlParam = new List<DbParameter>();

            if (!string.IsNullOrEmpty(param.GoodsName))
            {
                sqlWhere += " and (gi.GoodsName like @GoodsName) ";
                sqlParam.Add(new MySqlParameter("@GoodsName", "%" + param.GoodsName + "%"));
            }

            if (!string.IsNullOrEmpty(param.GoodsTypeCode))
            {
                sqlWhere += " and (gi.GoodsTypeCode = @GoodsTypeCode) ";
                sqlParam.Add(new MySqlParameter("@GoodsTypeCode", param.GoodsTypeCode));
            }

            if (param.GbId != null)
            {
                sqlWhere += " and (gi.GbId = @GbId) ";
                sqlParam.Add(new MySqlParameter("@GbId", param.GbId));
            }

            string sql = $@"select gi.*,gb.ChsBrandName,gb.EnBrandName,gt.TypeName,count(gs.Id) as GsNumber
                                from goodsinfo gi
                                LEFT JOIN goodsbrand gb on gi.GbId = gb.Id
                                LEFT JOIN goodstype gt on gt.`Code` = gi.GoodsTypeCode
                                LEFT JOIN goodsspecification gs on gs.GoodsId = gi.Id 
                            {sqlWhere} 
                            GROUP BY gi.Id order by gi.id desc";

            string sqlCount = $"select count(*) from GoodsInfo gi {sqlWhere}";

            var list = _context.Database.SqlQuery<GoodsInfoView>(sql.ToPaginationSql(pageInfo), sqlParam.ToArray());
            var count = _context.Database.ExcuteSclare(sqlCount, sqlParam.ToArray());

            return new PageModel<GoodsInfoView>(list, pageInfo.PageIndex, pageInfo.PageSize, Convert.ToInt32(count));
        }
    }
}
