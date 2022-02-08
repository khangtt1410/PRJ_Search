using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PRJ_SEARCH.Controllers
{
    public class TrangChuController : Controller
    {
        SearchDBDataContext db = new SearchDBDataContext();
        // GET: TrangChu
        public ActionResult Index()
        { 
            //lấy danh mục ngôn ngữ
            List<tb_NgonNgu> lstNgonNgu = new List<tb_NgonNgu>();
            lstNgonNgu = db.tb_NgonNgus.Where(k => k.TrangThai == true).ToList();
            ViewBag.lstNgonNgu = lstNgonNgu;
            return View();
        }
        public ActionResult TraCuu(string keyWord = "", int tuNgonNgu = 0, int denNgonNgu = 0)
        {
            //Lấy tất cả các từ có trong bảng từ ngữ phù hợp điều kiện
            string sqlQuyery = "Select tn.ID, tn.NgayTao, tn.NoiDungTu, tn.NghiaCuaTu, tn.TuDongNghia, tn.TuTraiNghia, tn.ThanhNgu, tn.ViDu, " +
                "tn.TuLienQuan, tn.CumDongTu, td.TenTuDien, nd.HoTen as TenNguoiTao, " +
                "CONCAT(nnn.TenNgonNgu, ' - ', nnd.TenNgonNgu) as TenNgonNgu " +
                "from tb_TuNgu tn " +
                "join tb_TuDien td on td.ID = tn.IDTuDien and td.TrangThai = 1 " +
                "join tb_NguoiDung nd on nd.ID = tn.NguoiTao and nd.TrangThai = 1 " +
                "left join tb_NgonNgu nnn on nnn.ID = td.IDNgonNguNguon and nnn.TrangThai = 1 " +
                "left join tb_NgonNgu nnd on nnd.ID = td.IDNgonNguDich and nnd.TrangThai = 1 " +
                "where tn.TrangThai = 1 " +
                $"and (nnn.ID = {tuNgonNgu} or {tuNgonNgu} = 0) " +
                $"and (nnd.ID = {denNgonNgu} or {denNgonNgu} = 0) " +
                $"and ((tn.NoiDungTu collate Latin1_General_CI_AI like N'%{keyWord.Trim()}%' or '{keyWord.Trim()}' = '')) ";
            List<TuNguEntities.TuNguView> lstTuNgu = db.ExecuteQuery<TuNguEntities.TuNguView>(sqlQuyery).ToList();
            //lấy danh mục ngôn ngữ
            List<tb_NgonNgu> lstNgonNgu = new List<tb_NgonNgu>();
            lstNgonNgu = db.tb_NgonNgus.Where(k => k.TrangThai == true).ToList();
            ViewBag.lstNgonNgu = lstNgonNgu;
            return PartialView(lstTuNgu);
        }
        [HttpPost]
        public async Task<JsonResult> SpeakWord(string word)
        {
            string pathSave = "~/Content/sound/" + word + ".wav";
            Task<JsonResult> task = Task.Run(() =>
            {
                using (SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer())
                {
                    speechSynthesizer.SetOutputToWaveFile(Server.MapPath(pathSave));
                    speechSynthesizer.Speak(word);
                    return Json(new
                    {
                        pathSave = pathSave
                    }, JsonRequestBehavior.AllowGet);
                }
            });
            return await task;
        }
    }
}