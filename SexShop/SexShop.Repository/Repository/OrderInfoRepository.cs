﻿using SexShop.Entity;
using SexShop.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace SexShop.Repository.Repository
{
    class OrderInfoRepository : EntityBaseRepository<OrderInfo>, IOrderInfoRepository, IAutofacBase
    {
        public OrderInfoRepository(SexShopDbContext context) : base(context)
        {
        }

        public PageModel<OrderInfoView> GetListByPages(PageInfo pageInfo, OrderInfoParam param)
        {
            string sqlWhere = " where o.isDel = 0 ";
            var sqlParam = new List<DbParameter>();
            if (param.Status != 0)
            {
                sqlWhere += " and o.Status = @Status ";
                sqlParam.Add(new MySqlParameter("@Status", param.Status));
            }
            if (!string.IsNullOrEmpty(param.Phone))
            {
                sqlWhere += " and o.Phone like @Phone ";
                sqlParam.Add(new MySqlParameter("@Phone", "%"+param.Phone+"%"));
            }
            if (!string.IsNullOrEmpty(param.Consignee))
            {
                sqlWhere += " and o.Consignee like @Consignee ";
                sqlParam.Add(new MySqlParameter("@Consignee", "%" + param.Consignee+"%"));
            }
            if (param.BeginTime != null)
            {
                sqlWhere += " and o.CreateTime > @BeginTime ";
                sqlParam.Add(new MySqlParameter("@BeginTime", param.BeginTime));
            }
            if (param.EndTime != null)
            {
                sqlWhere += " and o.CreateTime < @EndTime ";
                sqlParam.Add(new MySqlParameter("@EndTime", param.EndTime));
            }

            string sql = @"select o.id as OrderId, o.OrderNo, CONCAT(o.ProvinceName,o.CityName,o.CountyName, ' ',o.DetailedAddress) Address,
                            o.Consignee,o.Phone,o.BuyQuantity,o.Message,o.OrderAmount,o.Status,o.CreateTime,g.SpecificationDesc,
                            sg.TrackingNo,sg.CourierCompany,sg.Remarks
                            from orderinfo o
                            LEFT JOIN goodsinfo g on o.GoodsId = g.Id
                            LEFT JOIN SendGoodsInfo sg on o.id = sg.OrderId " + sqlWhere + " order by o.createTime ";
            string sqlCount = "select count(*) from OrderInfo o "+ sqlWhere;

            var list = _context.Database.SqlQuery<OrderInfoView>(sql.ToPaginationSql(pageInfo), sqlParam.ToArray());
            var count = _context.Database.ExcuteSclare(sqlCount, sqlParam.ToArray());

            return new PageModel<OrderInfoView>(list, pageInfo.PageIndex, pageInfo.PageSize, Convert.ToInt32(count));
        }
    }
}
