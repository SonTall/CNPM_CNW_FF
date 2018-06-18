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

        public ActionResult Menu(int? machude, string tenmon)
        {
            if (tenmon == null && machude == null)
            {
                ViewBag.TenChuDe = db.ChuDes.SingleOrDefault(n => n.MaChuDe == 1);
                return View(db.MonAns.OrderBy(n => n.MaMonAn).ToList());
            }
            else if (tenmon == null && machude != null)
            {
                ViewBag.TenChuDe = db.ChuDes.SingleOrDefault(n => n.MaChuDe == machude);
                return View(db.MonAns.Single(n => n.MaChuDe == machude));
            }
            else if (tenmon != null && machude == null)
            {
                ViewBag.TenChuDe = db.ChuDes.SingleOrDefault(n => n.MaChuDe == 1);
                return View(db.MonAns.SqlQuery("select * from MonAn where TenMonAn like '%'+@ten+'%'", new SqlParameter("@ten", tenmon)).ToList());
            }
            else
            {
                ViewBag.TenChuDe = db.ChuDes.SingleOrDefault(n => n.MaChuDe == machude);
                return View(db.MonAns.SqlQuery("select * from MonAn where TenMonAn like '%'+@ten+'%' and MaChuDe = @machude", new SqlParameter("@ten", tenmon), new SqlParameter("@machude", machude)));
            }
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