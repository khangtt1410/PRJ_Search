using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                SoDienThoai = k.SoDienThoai,
                ID= k.ID
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

        [HttpPost]
        public JsonResult GetData(int id)
        {
            tb_NguoiDung item = db.tb_NguoiDungs.FirstOrDefault(x => x.ID == id);
            return Json(new
            {
                status = true,
                data = item
            }, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public JsonResult Save(FormCollection c)
        {
            int ID = int.Parse(c["ID"].ToString());
            //int userId = int.Parse(Session["MaNguoiDung"].ToString());
            if (ID == 0)
            {
                //thêm mới
                tb_NguoiDung item = new tb_NguoiDung();
                item.HoTen = c["HoTen"] != null ? c["HoTen"].Trim() : "";
                item.TenDangNhap = c["TenDangNhap"] != null ? c["TenDangNhap"].Trim() : "";
                item.MatKhau = c["MatKhau"];
                item.SoDienThoai = c["Phone"] != null ? c["Phone"].Trim() : "";
                item.DiaChi = c["DiaChi"] != null ? c["DiaChi"].Trim() : "";
                item.Email = c["Email"] != null ? c["Email"].Trim() : "";
                item.DoPhucTap = c["DoPhucTap"] != null ? c["DoPhucTap"].Trim() : "";
                item.NgayTao = DateTime.Now;
                //tam thoi chua lam nut dang nhap nguoi dung nen de tam nguoi tao la 1
                item.NguoiTao = 1;
                item.TrangThai = true;
                db.tb_NguoiDungs.InsertOnSubmit(item);
                db.SubmitChanges();
            }
            else
            {
                //sửa
                tb_NguoiDung data = db.tb_NguoiDungs.FirstOrDefault(x => x.ID == ID);
                data.HoTen = c["HoTen"] != null ? c["HoTen"].Trim() : "";
                data.TenDangNhap = c["TenDangNhap"] != null ? c["TenDangNhap"].Trim() : "";
                data.MatKhau = c["MatKhau"];
                data.SoDienThoai = c["Phone"] != null ? c["Phone"].Trim() : "";
                data.DiaChi = c["DiaChi"] != null ? c["DiaChi"].Trim() : "";
                data.Email = c["Email"] != null ? c["Email"].Trim() : "";
                data.DoPhucTap = c["DoPhucTap"] != null ? c["DoPhucTap"].Trim() : "";
                data.NgaySua = DateTime.Now;
                data.NguoiSua = 1;
                db.SubmitChanges();
            }
            return Json(new
            {
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public int Delete(string ListID)
        {
            //int userId = int.Parse(Session["MaNguoiDung"].ToString());
            var convertArray = ListID.Replace("[", "").Replace("]", "");
            var lstLoai = convertArray.Split(',').ToList();
            foreach (var item in lstLoai)
            {
                int id = int.Parse(item);
                tb_NguoiDung objDel = db.tb_NguoiDungs.FirstOrDefault(k => k.ID == id);
                if (objDel != null)
                {
                    objDel.TrangThai = false;
                }
                db.SubmitChanges();
            }
            return 1;

        }

        [HttpPost]
        public async Task<JsonResult> DeleteAll(string lstIdString)
        {
            if (lstIdString == null || lstIdString.Length < 0)
                return Json(new
                {
                    status = false
                }, JsonRequestBehavior.AllowGet);

            int CountCreateDDAP = Delete(lstIdString);
            if (CountCreateDDAP <= 0)
            {
                return Json(new
                {
                    status = false
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                status = true,
                data = lstIdString,
            }, JsonRequestBehavior.AllowGet);
        }
    }
}