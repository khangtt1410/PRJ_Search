using CLSHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PRJ_SEARCH.Controllers
{
    public class CheckValidAccountController : Controller
    {
        SearchDBDataContext db = new SearchDBDataContext();
        // GET: DangNhap
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Hàm xử lý đăng nhập
        /// </summary>
        /// <param name="taikhoan"></param>
        /// <param name="matkhau"></param>
        /// <returns></returns>
        public JsonResult DangNhap(string taikhoan, string matkhau)
        {
            bool status = true;
            string mess = "";

            //Lấy tài khoản của người dùng có thông tin tài khoản, mật khẩu tương ứng
            tb_NguoiDung nguoiDung = db.tb_NguoiDungs.FirstOrDefault(k => k.TenDangNhap == taikhoan && k.TrangThai == true);
            if(nguoiDung != null)
            {
                matkhau = LMSUtilities.GetMD5(string.Concat(nguoiDung.DoPhucTap, matkhau));
                if(matkhau == nguoiDung.MatKhau)
                {
                    status = true;
                    //Lưu mã người dùng vào session - bộ nhớ tạm
                    Session["IDNguoiDung"] = nguoiDung.ID;
                }
                else
                {
                    status = false;
                    mess = "Mật khẩu không chính xác";
                }
            }
            else
            {
                status = false;
                mess = "Tài khoản không chính xác";
            }
            return Json(new
            {
                status = status,
                mess = mess
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Hàm xử lý đăng xuất
        /// </summary>
        /// <returns></returns>
        public JsonResult DangXuat()
        {
            //Xóa dữ liệu session đã lưu
            Session.Clear();
            return Json(new
            {
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}