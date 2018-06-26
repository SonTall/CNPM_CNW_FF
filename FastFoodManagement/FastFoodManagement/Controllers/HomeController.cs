using FastFoodManagement.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FastFoodManagement.Controllers
{
    public class HomeController : Controller
    {
        private FastFoodManagementEntities1 db = new FastFoodManagementEntities1();

        //[AuthorizeAttribute]
        public ActionResult Index(int? page)
        {
            int pageSize = 7;
            int pageNumber = (page ?? 1);
            return View(db.MonAns.OrderBy(n => n.MaMonAn).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(int? mamonan)
        {
            if (mamonan == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.MonAns.Find(mamonan);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            return View(monAn);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Menu(string tenmon)
        {
            if (tenmon == null)
                return View(db.MonAns.OrderBy(n => n.MaMonAn).ToList());
            else
                return View(db.MonAns.SqlQuery("select * from MonAn where TenMonAn like '%'+@ten+'%'", new SqlParameter("@ten", tenmon)).ToList());
        }


        public ActionResult ListKhuyenMai()
        {
            //var khuyenMai = db.KhuyenMais.Where(n => DateTime.Compare(Convert.ToDateTime(n.ThoiGianBatDau), DateTime.Now) > 0 && DateTime.Compare(Convert.ToDateTime(n.ThoiGianKetThuc), DateTime.Now) < 0).ToList();
            var khuyenMai = db.KhuyenMais.Where(n => n.ThoiGianBatDau < DateTime.Now && n.ThoiGianKetThuc > DateTime.Now).ToList();
            return View(khuyenMai);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}