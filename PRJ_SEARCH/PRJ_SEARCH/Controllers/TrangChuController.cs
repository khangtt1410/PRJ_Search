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
using Google.API.Search;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.TextToSpeech.V1;

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
            //string uriString = "http://www.google.com/search";

            //WebClient webClient = new WebClient();

            //NameValueCollection nameValueCollection = new NameValueCollection();
            //nameValueCollection.Add("q", keyWord);

            //webClient.QueryString.Add(nameValueCollection);
            //var res = webClient.DownloadString(uriString);
            //WebClient Web = new WebClient();
            //string Source = Web.DownloadString("https://www.google.com/search?client=" + keyWord);
            //Regex regex = new Regex(@"^http(s) ?://([\w-]+.)+[\w-]+(/[\w%&=])?$");
            //MatchCollection Collection = regex.Matches(res);
            List<string> Urls = new List<string>();
            //foreach (Match match in Collection)
            //{
            //    Urls.Add(match.ToString());
            //}

            //string raw = "http://www.google.com/search?num=39&q={0}&btnG=Search";
            //string search = string.Format(raw, HttpUtility.UrlEncode(keyWord));

           //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(search);
            //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //{
            //    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
            //    {
            //        string html = reader.ReadToEnd();
            //        string lookup = "(<a href=\")(\\w+[a-zA-Z0-9.-?=/]*)\" class=l";
            //        MatchCollection matches = Regex.Matches(html, lookup);

            //        for (int i = 0; i < matches.Count; i++)
            //        {
            //            string match = matches[i].Groups[2].Value;
            //            Urls.Add(match.ToString());
            //        }
            //    }
            //}
           // GwebSearchClient gweb = new GwebSearchClient("http://ubound.hipchat.com");
           // GwebSearchClient client = new GwebSearchClient("www.google.com");
           // IList<IWebResult> results = client.Search(keyWord, 10); //max is 64
           //// var results = gweb.Search(keyWord, 32);

           // try
           // {
           //     if (results.Count > 0)
           //     {
           //         foreach (var result in results)
           //         {
           //             var ew = result.Url;
           //         }
           //     }
           // }
           // catch
           // {
           //     string mes = "Error in search!";
           // }


           // var gclient = new GwebSearchClient("www.google.com");
           // var searchResult = gclient.Search(keyWord, 1000);

           // if (searchResult != null)
           // {
           //     var ress =  searchResult.Select(result => result.Url).ToList();
           // }

            //List<string> res = new List<string>();
            //var client = new GwebSearchClient("http://www.google.com");
            //var results = client.Search("google api for .NET", 100);
            //foreach (var webResult in results)
            //{
            //    //Console.WriteLine("{0}, {1}, {2}", webResult.Title, webResult.Url, webResult.Content);
            //    res.Add(webResult.ToString());
            //}

            TuNguEntities.lstData data = new TuNguEntities.lstData()
            {
                lstDoc = lstTuNgu,
                //Doc_Online = res
            };
            return PartialView(data);
        }
    }
}