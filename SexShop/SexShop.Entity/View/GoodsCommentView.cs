using System;
using System.Collections.Generic;
using System.Text;

namespace SexShop.Entity
{
    public class GoodsCommentView : GoodsComment
    {
        public List<GoodsCommentImg> ImgList { get; set; }
    }
}
