using SexShop.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Entity
{
    /// <summary>
    /// 系统用户表
    /// </summary>
    public class SysUserInfo : IEntityBase
    {
        public int Id { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }       

        /// <summary>
        /// 创建时间
        /// </summary>        
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int CreateBy { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public int UpdateBy { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDel { get; set; }
    }
}
