using InsteadBuyPlatform.Entity;
using InsteadBuyPlatform.Repository;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace InsteadBuyPlatform.IRepository
{
    public class ClientInfoRepository : EntityBaseRepository<ClientInfo>, IClientInfoRepository, IAutofacBase
    {
        public ClientInfoRepository(InsteadBuyPlatformDbContext context) : base(context)
        {
        }

        public PageModel<ClientInfo> SearchListByPage(ClientInfoParam param, PageInfo pageInfo)
        {
            var sqlParam = new List<DbParameter>();

            string sqlWhere = " where UserId = @UserId ";
            sqlParam.Add(new MySqlParameter("@UserId", param.UserId));

            if (param.IsDel != -1)
            {
                sqlWhere += " and IsDel = @IsDel ";
                sqlParam.Add(new MySqlParameter("@IsDel", param.IsDel));
            }

            if (!string.IsNullOrEmpty(param.ClientName))
            {
                sqlWhere += " and (ClientPhone like @ClientName or ClientName like @ClientName) ";
                sqlParam.Add(new MySqlParameter("@ClientName", "%" + param.ClientName + "%"));
            }

            string sql = @"select * from ClientInfo " + sqlWhere + " order by id desc ";

            string sqlCount = "select count(*) from ClientInfo " + sqlWhere;

            var list = _context.Database.SqlQuery<ClientInfo>(sql.ToPaginationSql(pageInfo), sqlParam.ToArray());
            var count = _context.Database.ExcuteSclare(sqlCount, sqlParam.ToArray());

            return new PageModel<ClientInfo>(list, pageInfo.PageIndex, pageInfo.PageSize, Convert.ToInt32(count));
        }
    }
}
