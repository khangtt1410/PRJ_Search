using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRJ_SEARCH
{
    public class TuDienEntities
    {
        public class lstData
        {
            public List<TuDienView> lstDoc { get; set; }
            public CLSHelper.Models.PagingInfo PagingInfo { get; set; }
        }
        public class TuDienView : tb_TuDien
        {
            public string NgonNguNguon { get; set; }
            public string NgonNguDich { get; set; }
            public string TenNguoiTao { get; set; }
            public string TenNguoiSua { get; set; }
        }
    }
}