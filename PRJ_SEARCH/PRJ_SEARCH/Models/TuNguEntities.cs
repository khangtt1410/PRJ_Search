using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRJ_SEARCH
{
    public class TuNguEntities
    {
        public class lstData
        {
            /// <summary>
            /// abc
            /// </summary>
            public List<TuNguView> lstDoc { get; set; }
            public CLSHelper.Models.PagingInfo PagingInfo { get; set; }
        }
        public class TuNguView : tb_TuNgu
        {
            public string TenTuDien { get; set; }
            public string TenNgonNgu { get; set; }
            public string TenNguoiTao { get; set; }
            public string TenNguoiSua { get; set; }
        }
    }
}