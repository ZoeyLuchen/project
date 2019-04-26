using MaiDongXi.Entity;
using MaiDongXi.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiDongXi.Repository
{
    public class UserInfoRepository : EntityBaseRepository<UserInfo>, IUserInfoRepository, IAutofacBase
    {
        public UserInfoRepository(MDXDbContext context) : base(context)
        {
        }
    }
}
