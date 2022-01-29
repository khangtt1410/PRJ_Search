using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRJ_SEARCH
{
    public class NguoiDungEntities
    {
        public class lstData
        {
            public List<NguoiDungView> lstDoc { get; set; }
            public CLSHelper.Models.PagingInfo PagingInfo { get; set; }
        }
        public class NguoiDungView : tb_NguoiDung
        {
            public string TenNguoiTao { get; set; }
            public string TenNguoiSua { get; set; }
        }
    }
}