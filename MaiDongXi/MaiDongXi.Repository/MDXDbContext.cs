using MaiDongXi.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MaiDongXi.Repository
{
    public class MDXDbContext : DbContext
    {
        public MDXDbContext(DbContextOptions<MDXDbContext> options)
           : base(options)
        {
        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<GoodsInfo> GoodsInfo { get; set; }
        public DbSet<OrderInfo> OrderInfo { get; set; }
        public DbSet<SendGoodsInfo> SendGoodsInfo { get; set; }
    }
}
