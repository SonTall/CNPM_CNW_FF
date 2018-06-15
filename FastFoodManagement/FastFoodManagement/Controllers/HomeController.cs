using FastFoodManagement.Models;
using PagedList;
using System;
using System.Collections.Generic;
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
            ViewBag.Message = "Your application description page.";

            return View();
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