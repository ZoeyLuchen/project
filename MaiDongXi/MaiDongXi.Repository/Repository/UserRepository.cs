using MaiDongXi.Entity;
using MaiDongXi.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiDongXi.Repository
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository, IAutofacBase
    {
        public UserRepository(MDXDbContext context) : base(context)
        {
        }
    }
}
