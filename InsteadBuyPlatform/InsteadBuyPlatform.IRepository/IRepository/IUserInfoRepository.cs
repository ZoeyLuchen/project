using InsteadBuyPlatform.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsteadBuyPlatform.IRepository
{
    public interface IUserInfoRepository:IEntityBaseRepository<UserInfo>
    {
        bool AddUserInfo(UserInfo model);
    }
}
