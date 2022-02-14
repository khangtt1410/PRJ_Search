using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Speech.Synthesis;
using System.Text;
using System.Text.RegularExpressions;
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
        public ActionResult KetQuaTraCuu(string keyWord = "", int tuNgonNgu = 0, int denNgonNgu = 0)
        {
            //Lấy tất cả các từ có trong bảng từ ngữ phù hợp điều kiện
            string sqlQuyery = "Select tn.ID, tn.NgayTao, tn.NoiDungTu, tn.NghiaCuaTu, tn.TuDongNghia, tn.TuTraiNghia, tn.ThanhNgu, tn.ViDu, " +
                "tn.TuLienQuan, tn.CumDongTu, td.TenTuDien, nd.HoTen as TenNguoiTao, tn.PathVoice, " +
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

            //Tìm kiếm trên website
            // lấy api key từ link này https://developers.google.com/custom-search/v1/overview
            string apiKey = "AIzaSyCuU5tGTEMc6YJIT8owSgsmDiiOFIF_sHI";
            //string cx = "017576662512468239146";
            string cx = "b60a96b351223441f";

            string query = keyWord;
            string url = "https://www.googleapis.com/customsearch/v1?key=" + apiKey + "&cx=" + cx + "&q=" + keyWord;
            var request = WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string resString = reader.ReadToEnd();
            dynamic jsonData = JsonConvert.DeserializeObject(resString);

            List<ResponseGoogleAPI> lstData = new List<ResponseGoogleAPI>();
            foreach (var item in jsonData.items)
            {
                lstData.Add(new ResponseGoogleAPI()
                {
                    Title = item.title,
                    Link = item.link,
                    Snippet = item.snippet
                });
            }

            TuNguEntities.lstData data = new TuNguEntities.lstData()
            {
                lstDoc = lstTuNgu,
                lstResponse = lstData,
                data = resString
            };
            return PartialView(data);
        }

        public JsonResult Translate(string inputData, string toLanguage = "en", string fromLanguage = "vi")
        {
            var url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(inputData)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return Json(new
                {
                    data = result
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    data = ex.Message
                });
            }
        }
    }
}