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
            /// abc xyz
            /// </summary>
            public List<TuNguView> lstDoc { get; set; }
            public string Doc_Online { get; set; }
            public CLSHelper.Models.PagingInfo PagingInfo { get; set; }
        }
        public class TuNguView
        {
            public int ID { get; set; }
            public string NoiDungTu { get; set; }
            public string NghiaCuaTu { get; set; }
            public string ThanhNgu { get; set; }
            public string ViDu { get; set; }
            public string TuDongNghia { get; set; }
            public string TuTraiNghia { get; set; }
            public string CumDongTu { get; set; }
            public string TuLienQuan { get; set; }
            public DateTime? NgayTao { get; set; }
            public string TenTuDien { get; set; }
            public string TenNgonNgu { get; set; }
            public string TenNguoiTao { get; set; }
            public string TenNguoiSua { get; set; }
            public string PathVoice { get; set; }
        }
    }
}