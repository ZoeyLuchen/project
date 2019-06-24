using InsteadBuyPlatform.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace InsteadBuyPlatform.Repository
{
    public class InsteadBuyPlatformDbContext : DbContext
    {
        public InsteadBuyPlatformDbContext(DbContextOptions<InsteadBuyPlatformDbContext> options)
           : base(options)
        {
        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<GoodsInfo> GoodsInfo { get; set; }
        public DbSet<OrderInfo> OrderInfo { get; set; }
        public DbSet<CouponInfo> CouponInfo { get; set; }       
        public DbSet<GoodsSpecification> GoodsSpecification { get; set; }
        public DbSet<GoodsType> GoodsType { get; set; }       
        public DbSet<UserCoupon> UserCoupon { get; set; }
        public DbSet<ClientInfo> ClientInfo { get; set; }
        public DbSet<GoodsBrand> GoodsBrand { get; set; }
        public DbSet<SmsCodeInfo> SmsCodeInfo { get; set; }
        public DbSet<OrderGoods> OrderGoods { get; set; }
    }
}
