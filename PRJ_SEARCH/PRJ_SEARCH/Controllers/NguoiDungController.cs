using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRJ_SEARCH
{
    public class NguoiDungController : Controller
    {
        SearchDBDataContext db = new SearchDBDataContext();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetListData(string keyword = "", int page = 1, int pageSize = 6)
        {
            int totalRecord = 0;
            List<NguoiDungEntities.NguoiDungView> lstData = new List<NguoiDungEntities.NguoiDungView>();
            lstData = db.tb_NguoiDungs.Where(k => k.TrangThai == true
            && (k.TenDangNhap.Contains(keyword)
            || k.HoTen.Contains(keyword) || k.DiaChi.Contains(keyword) || keyword == "")).OrderByDescending(k => k.ID)
            .Select(k => new NguoiDungEntities.NguoiDungView {
                DiaChi = k.DiaChi,
                Email = k.Email,
                HoTen = k.HoTen,
                TenDangNhap = k.TenDangNhap,
                SoDienThoai = k.SoDienThoai
            }).ToList();

            totalRecord = lstData.Count();
            lstData = lstData.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var pagingInfo = new CLSHelper.Models.PagingInfo();
            pagingInfo.CurrentPage = page;
            pagingInfo.ItemsPerPage = pageSize;
            pagingInfo.TotalItems = totalRecord;

            NguoiDungEntities.lstData model = new NguoiDungEntities.lstData()
            {
                lstDoc = lstData,
                PagingInfo = pagingInfo
            };
            return PartialView(model);
        }
    }
}