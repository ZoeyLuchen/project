using MaiDongXi.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaiDongXi.Entity
{
    public class User : IEntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
