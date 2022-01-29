using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRJ_SEARCH
{
    public class NgonNguEntities
    {
        public class lstData
        {
            public List<NgonNguView> lstDoc { get; set; }
            public CLSHelper.Models.PagingInfo PagingInfo { get; set; }
        }
        public class NgonNguView : tb_NgonNgu
        {
            public string TenNguoiTao { get; set; }
            public string TenNguoiSua { get; set; }
        }
    }
}