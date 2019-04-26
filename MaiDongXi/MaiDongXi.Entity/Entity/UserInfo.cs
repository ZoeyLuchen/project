using MaiDongXi.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiDongXi.Entity
{
    public class UserInfo : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDel { get; set; }
    }
}
