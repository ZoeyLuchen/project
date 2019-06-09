using SexShop.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SexShop.Repository
{
    public class SexShopDbContext : DbContext
    {
        public SexShopDbContext(DbContextOptions<SexShopDbContext> options)
           : base(options)
        {
        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<GoodsInfo> GoodsInfo { get; set; }
        public DbSet<OrderInfo> OrderInfo { get; set; }
        public DbSet<CouponInfo> CouponInfo { get; set; }
        public DbSet<GoodsComment> GoodsComment { get; set; }
        public DbSet<GoodsCommentImg> GoodsCommentImg { get; set; }
        public DbSet<GoodsParameter> GoodsParameter { get; set; }
        public DbSet<GoodsSpecification> GoodsSpecification { get; set; }
        public DbSet<GoodsType> GoodsType { get; set; }
        public DbSet<InventoryInfo> InventoryInfo { get; set; }
        public DbSet<OrderGoods> OrderGoods { get; set; }
        public DbSet<OrderUseCoupon> OrderUseCoupon { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetail { get; set; }
        public DbSet<PurchaseInfo> PurchaseInfo { get; set; }
        public DbSet<ReceivingAddress> ReceivingAddress { get; set; }
        public DbSet<SendGoodsInfo> SendGoodsInfo { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<SysUserInfo> SysUserInfo { get; set; }
        public DbSet<UserCoupon> UserCoupon { get; set; }
        public DbSet<UserGoodsCollection> UserGoodsCollection { get; set; }      
    }
}
