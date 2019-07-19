using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace InsteadBuyPlatform.IRepository
{
    public class GoodsBrandRepository : EntityBaseRepository<GoodsBrand>, IGoodsBrandRepository, IAutofacBase
    {
        public GoodsBrandRepository(InsteadBuyPlatformDbContext context) : base(context)
        {
            
        }
        public PageModel<GoodsBrand> SearchListByPage(GoodsBrandParam param, PageInfo pageInfo)
        {
            string sqlWhere = " where 1=1 ";
            var sqlParam = new List<DbParameter>();
            if (param.isDel != -1)
            {
                sqlWhere += " and IsDel = @IsDel ";
                sqlParam.Add(new MySqlParameter("@IsDel", param.isDel));
            }

            if (!string.IsNullOrEmpty(param.GoodsBrandName))
            {
                sqlWhere += " and (ChsBrandName like @GoodsBrandName or EnBrandName like @GoodsBrandName) ";
                sqlParam.Add(new MySqlParameter("@GoodsBrandName", "%"+param.GoodsBrandName+"%"));
            }

            string sql = @"select * from GoodsBrand " + sqlWhere +" order by id desc ";

            string sqlCount = "select count(*) from GoodsBrand " + sqlWhere;

            var list = _context.Database.SqlQuery<GoodsBrand>(sql.ToPaginationSql(pageInfo), sqlParam.ToArray());
            var count = _context.Database.ExcuteSclare(sqlCount, sqlParam.ToArray());

            return new PageModel<GoodsBrand>(list, pageInfo.PageIndex, pageInfo.PageSize, Convert.ToInt32(count));
        }
    }
}
