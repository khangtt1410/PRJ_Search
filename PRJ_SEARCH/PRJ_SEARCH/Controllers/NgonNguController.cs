using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PRJ_SEARCH.Controllers
{
    public class NgonNguController : RouterConfigController
    {
        SearchDBDataContext db = new SearchDBDataContext();
        // GET: NgonNgu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetListData(string keyword = "", int page = 1, int pageSize = 6)
        {
            int totalRecord = 0;
            List<NgonNguEntities.NgonNguView> lstData = new List<NgonNguEntities.NgonNguView>();
            lstData = db.tb_NgonNgus.Where(k => k.TrangThai == true
            && (k.TenNgonNgu.Contains(keyword) || keyword == "")).OrderByDescending(k => k.ID)
            .Select(k => new NgonNguEntities.NgonNguView
            {
                TenNgonNgu = k.TenNgonNgu,
                TrangThai = k.TrangThai,
                ID = k.ID
            }).ToList();

            totalRecord = lstData.Count();
            lstData = lstData.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var pagingInfo = new CLSHelper.Models.PagingInfo();
            pagingInfo.CurrentPage = page;
            pagingInfo.ItemsPerPage = pageSize;
            pagingInfo.TotalItems = totalRecord;

            NgonNguEntities.lstData model = new NgonNguEntities.lstData()
            {
                lstDoc = lstData,
                PagingInfo = pagingInfo
            };
            return PartialView(model);
        }

        [HttpPost]
        public JsonResult GetData(int id)
        {
            tb_NgonNgu item = db.tb_NgonNgus.FirstOrDefault(x => x.ID == id);
            return Json(new
            {
                status = true,
                data = item
            }, JsonRequestBehavior.AllowGet);
        }

        [ValidateInput(false)]
        public JsonResult Save(FormCollection c)
        {
            int userId = 1;
            int ID = int.Parse(c["ID"].ToString());
            //int userId = int.Parse(Session["MaNguoiDung"].ToString());
            if (ID == 0)
            {
                //thêm mới
                tb_NgonNgu item = new tb_NgonNgu();
                item.TenNgonNgu = c["TenNgonNgu"] != null ? c["TenNgonNgu"].Trim() : "";
                item.NgayTao = DateTime.Now;
                item.NguoiTao = userId;
                item.TrangThai = true;
                db.tb_NgonNgus.InsertOnSubmit(item);
                db.SubmitChanges();
            }
            else
            {
                //sửa
                tb_NgonNgu data = db.tb_NgonNgus.FirstOrDefault(x => x.ID == ID);
                data.TenNgonNgu = c["TenNgonNgu"] != null ? c["TenNgonNgu"].Trim() : "";
                data.NgaySua = DateTime.Now;
                data.NguoiSua = userId;
                db.SubmitChanges();
            }
            return Json(new
            {
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int ID)
        {
            if (ID == null || ID == 0)
            {
                return Json(new
                {
                    status = false
                }, JsonRequestBehavior.AllowGet);
            }
            tb_NgonNgu objDel = db.tb_NgonNgus.FirstOrDefault(k => k.ID == ID);
            if (objDel != null)
            {
                objDel.TrangThai = false;
            }
            db.SubmitChanges();

            return Json(new
            {
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}