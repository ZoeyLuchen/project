using System;
using System.Collections.Generic;
using System.Text;

namespace MaiDongXi.Entity
{
    /// <summary>
    /// 当前登录用户
    /// </summary>
    public class CurrentUserInfo
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户账号
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 权限菜单列表
        /// </summary>
        public List<dynamic> PermissionList { get; set; }
    }
}
