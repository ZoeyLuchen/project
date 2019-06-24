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

            string sql = @"select top(8) * from GoodsInfo " + sqlWhere ;

            var list = _context.Database.SqlQuery<GoodsInfo>(sql, sqlParam.ToArray());
            return list;
        }
    }
}
