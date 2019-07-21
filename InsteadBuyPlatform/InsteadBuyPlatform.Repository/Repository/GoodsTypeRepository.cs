using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace InsteadBuyPlatform.IRepository
{
    public class GoodsTypeRepository : EntityBaseRepository<GoodsType>, IGoodsTypeRepository, IAutofacBase
    {
        public GoodsTypeRepository(InsteadBuyPlatformDbContext context) : base(context)
        {
        }

        public PageModel<GoodsType> SearchListByPage(GoodsTypeParam param, PageInfo pageInfo)
        {
            string sqlWhere = " where 1=1 ";
            var sqlParam = new List<DbParameter>();
            if (param.IsDel != -1)
            {
                sqlWhere += " and IsDel = @IsDel ";
                sqlParam.Add(new MySqlParameter("@IsDel", param.IsDel));
            }

            if (!string.IsNullOrEmpty(param.TypeName))
            {
                sqlWhere += " and TypeName like @GoodsBrandName  ";
                sqlParam.Add(new MySqlParameter("@GoodsBrandName", "%" + param.TypeName + "%"));
            }

            string sql = @"select * from GoodsType " + sqlWhere + " order by id desc ";

            string sqlCount = "select count(*) from GoodsType " + sqlWhere;

            var list = _context.Database.SqlQuery<GoodsType>(sql.ToPaginationSql(pageInfo), sqlParam.ToArray());
            var count = _context.Database.ExcuteSclare(sqlCount, sqlParam.ToArray());

            return new PageModel<GoodsType>(list, pageInfo.PageIndex, pageInfo.PageSize, Convert.ToInt32(count));
        }
    }
}
