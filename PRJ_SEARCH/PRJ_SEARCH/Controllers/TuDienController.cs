using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PRJ_SEARCH.Controllers
{
    public class TuDienController : RouterConfigController
    {
        SearchDBDataContext db = new SearchDBDataContext();
        // GET: TuDien
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Lấy danh sách từ điển
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult GetListData(string keyword = "", int page = 1, int pageSize = 6)
        {
            int totalRecord = 0;
            List<TuDienEntities.TuDienView> lstData = new List<TuDienEntities.TuDienView>();
            string sqlQuery = "Select tudien.ID, tudien.MaTuDien, tudien.TenTuDien, tudien.TacGia, " +
                "ngonngunguon.TenNgonNgu as NgonNguNguon, ngonngudich.TenNgonNgu as NgonNguDich " +
                "from tb_TuDien tudien " +
                "left join tb_NgonNgu ngonngunguon on ngonngunguon.ID = tudien.IDNgonNguNguon and ngonngunguon.TrangThai <> 10 " +
                "left join tb_NgonNgu ngonngudich on ngonngudich.ID = tudien.IDNgonNguDich and ngonngudich.TrangThai <> 10 " +
                "where tudien.TrangThai = 1 " +
                $"and ((tudien.MaTuDien collate Latin1_General_CI_AI like N'%{keyword}%' or '{keyword}' = '') " +
                $"or (tudien.TenTuDien collate Latin1_General_CI_AI like N'%{keyword}%' or '{keyword}' = '') " +
                $"or (ngonngunguon.TenNgonNgu collate Latin1_General_CI_AI like N'%{keyword}%' or '{keyword}' = '') " +
                $"or (ngonngudich.TenNgonNgu collate Latin1_General_CI_AI like N'%{keyword}%' or '{keyword}' = '')) ";

            lstData = db.ExecuteQuery<TuDienEntities.TuDienView>(sqlQuery).OrderByDescending(k => k.ID).ThenBy(k => k.TenTuDien).ToList();

            totalRecord = lstData.Count();
            lstData = lstData.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var pagingInfo = new CLSHelper.Models.PagingInfo();
            pagingInfo.CurrentPage = page;
            pagingInfo.ItemsPerPage = pageSize;
            pagingInfo.TotalItems = totalRecord;

            TuDienEntities.lstData model = new TuDienEntities.lstData()
            {
                lstDoc = lstData,
                PagingInfo = pagingInfo
            };
            return PartialView(model);
        }
        /// <summary>
        /// Hàm lấy thông tin từ điển theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetData(int id = 0)
        {
            //Lấy danh mục ngôn ngữ
            List<tb_NgonNgu> lstNgonNgu = db.tb_NgonNgus.Where(k => k.TrangThai == true).OrderByDescending(k => k.TenNgonNgu).ToList();
            //Lấy thông tin từ điển
            tb_TuDien item = db.tb_TuDiens.FirstOrDefault(x => x.ID == id && x.TrangThai == true);
            //Lấy thông tin các từ ngữ trong từ điển
            List<tb_TuNgu> lstTuNgu = db.tb_TuNgus.Where(k => k.IDTuDien == id && k.TrangThai == true).ToList();
            return Json(new
            {
                status = true,
                data = item,
                lstNgonNgu = lstNgonNgu,
                lstTuNgu = lstTuNgu
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Xóa từ điển theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult Delete(int id = 0)
        {
            tb_TuDien item = db.tb_TuDiens.FirstOrDefault(x => x.ID == id && x.TrangThai == true);
            if (item != null)
            {
                item.TrangThai = false;
                db.SubmitChanges();
            }
            return Json(new
            {
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Thêm mới từ điển
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [ValidateInput(false)]
        public JsonResult Save(FormCollection c)
        {
            bool status = true;
            string mess = "Thêm mới từ điển thành công";

            int ID = int.Parse(c["ID"] == "" ? "0" : c["ID"]);
            int userId = int.Parse(Session["IDNguoiDung"].ToString());

            //Kiểm tra mã trùng
            tb_TuDien checkCode = db.tb_TuDiens.FirstOrDefault(k => k.ID != ID && k.TrangThai == true && k.MaTuDien == c["MaTuDien"]);
            if (checkCode != null)
            {
                status = false;
                mess = "Mã từ điển đã tồn tại. Vui lòng kiểm tra lại";

            }
            else if (ID == 0)
            {
                //thêm mới thông tin từ điển
                tb_TuDien tudien = new tb_TuDien();
                tudien.TrangThai = true;
                tudien.TenTuDien = c["TenTuDien"];
                tudien.MaTuDien = c["MaTuDien"];
                tudien.TacGia = c["TacGia"];
                tudien.NguoiTao = userId;
                tudien.NgayTao = DateTime.Now;
                tudien.IDNgonNguDich = int.Parse(c["IDNgonNguDich"] == null ? "0" : c["IDNgonNguDich"]);
                tudien.IDNgonNguNguon = int.Parse(c["IDNgonNguNguon"] == null ? "0" : c["IDNgonNguNguon"]);
                db.tb_TuDiens.InsertOnSubmit(tudien);
                db.SubmitChanges();

                //Thêm mới danh sách từ ngữ vào từ điển
                List<tb_TuNgu> lstTuNgu = JsonConvert.DeserializeObject<List<tb_TuNgu>>(c["lstTuNgu"]);
                foreach (var item in lstTuNgu)
                {
                    var task = Task.Run(async () => await CreateVoice(item.NoiDungTu));
                    string pathVoice = task.Result;

                    tb_TuNgu objNew = new tb_TuNgu
                    {
                        CumDongTu = item.CumDongTu,
                        IDNgonNgu = item.IDNgonNgu,
                        IDTuDien = tudien.ID,
                        NgayTao = DateTime.Now,
                        NghiaCuaTu = item.NghiaCuaTu,
                        NguoiTao = userId,
                        NoiDungTu = item.NoiDungTu,
                        ThanhNgu = item.ThanhNgu,
                        TrangThai = true,
                        TuDongNghia = item.TuDongNghia,
                        TuLienQuan = item.TuLienQuan,
                        TuTraiNghia = item.TuTraiNghia,
                        ViDu = item.ViDu,
                        PathVoice = pathVoice,
                    };
                    db.tb_TuNgus.InsertOnSubmit(objNew);

                }
                db.SubmitChanges();

            }
            else
            {
                //sửa thông tin từ điển
                tb_TuDien tudien = db.tb_TuDiens.FirstOrDefault(x => x.ID == ID);
                tudien.TenTuDien = c["TenTuDien"];
                tudien.MaTuDien = c["MaTuDien"];
                tudien.TacGia = c["TacGia"];
                tudien.NguoiSua = userId;
                tudien.NgaySua = DateTime.Now;
                tudien.IDNgonNguDich = int.Parse(c["IDNgonNguDich"]);
                tudien.IDNgonNguNguon = int.Parse(c["IDNgonNguNguon"]);
                db.SubmitChanges();
                //sửa đổi danh sách các từ ngữ trong từ điển
                List<tb_TuNgu> lstNew = JsonConvert.DeserializeObject<List<tb_TuNgu>>(c["lstTuNgu"]);
                //Lấy danh sách từ ngữ trong từ điển ban đầu
                List<tb_TuNgu> lstOld = db.tb_TuNgus.Where(k => k.IDTuDien == ID && k.TrangThai == true).ToList();
                //Lấy danh sách các từ ngữ đã bị xóa sau lần cập nhật
                List<tb_TuNgu> lstDel = lstOld.Where(k => !lstNew.Select(x => x.NoiDungTu.Trim().ToUpper()).Contains(k.NoiDungTu.Trim().ToUpper())).ToList();
                foreach (var itemDel in lstDel)
                {
                    itemDel.TrangThai = false;

                    System.IO.File.Delete(Server.MapPath(itemDel.PathVoice));
                }
                db.SubmitChanges();
                //Duyệt danh sách từ ngữ mới
                foreach (var item in lstNew)
                {
                    var task = Task.Run(async () => await CreateVoice(item.NoiDungTu));
                    string pathVoice = task.Result;

                    var existObj = lstOld.FirstOrDefault(k => k.ID == item.ID);
                    if (existObj != null)
                    {
                        existObj.CumDongTu = item.CumDongTu;
                        existObj.IDNgonNgu = item.IDNgonNgu;
                        existObj.IDTuDien = tudien.ID;
                        existObj.NgayTao = DateTime.Now;
                        existObj.NghiaCuaTu = item.NghiaCuaTu;
                        existObj.NguoiTao = userId;
                        existObj.NoiDungTu = item.NoiDungTu;
                        existObj.ThanhNgu = item.ThanhNgu;
                        existObj.TrangThai = true;
                        existObj.TuDongNghia = item.TuDongNghia;
                        existObj.TuLienQuan = item.TuLienQuan;
                        existObj.TuTraiNghia = item.TuTraiNghia;
                        existObj.ViDu = item.ViDu;
                        existObj.PathVoice = pathVoice;
                    }
                    else
                    {
                        tb_TuNgu objNew = new tb_TuNgu
                        {
                            CumDongTu = item.CumDongTu,
                            IDNgonNgu = item.IDNgonNgu,
                            IDTuDien = tudien.ID,
                            NgayTao = DateTime.Now,
                            NghiaCuaTu = item.NghiaCuaTu,
                            NguoiTao = userId,
                            NoiDungTu = item.NoiDungTu,
                            ThanhNgu = item.ThanhNgu,
                            TrangThai = true,
                            TuDongNghia = item.TuDongNghia,
                            TuLienQuan = item.TuLienQuan,
                            TuTraiNghia = item.TuTraiNghia,
                            ViDu = item.ViDu,
                            PathVoice = pathVoice
                        };
                        db.tb_TuNgus.InsertOnSubmit(objNew);
                    }
                }
                db.SubmitChanges();
            }
            return Json(new
            {
                status = status,
                mess = mess
            }, JsonRequestBehavior.AllowGet);
        }

        public async Task<string> CreateVoice(string word)
        {
            Task<string> task = Task.Run(() =>
            {
                using (SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer())
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        string pathSave = "~/Content/sound/";
                        speechSynthesizer.SetOutputToWaveStream(stream);
                        speechSynthesizer.Speak(word);
                        var bytes = stream.GetBuffer();
                        string speechFile = Server.MapPath(Path.Combine(pathSave, word + ".mp3"));

                        System.IO.File.WriteAllBytes(speechFile, bytes);
                        return Path.Combine(pathSave, word + ".mp3");
                    }
                }
            });
            return await task;
        }
    }
}