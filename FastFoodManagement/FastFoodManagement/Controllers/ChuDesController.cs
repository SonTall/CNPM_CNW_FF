using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FastFoodManagement.Models;
using PagedList;

namespace FastFoodManagement.Controllers
{
    public class ChuDesController : Controller
    {
        private FastFoodManagementEntities1 db = new FastFoodManagementEntities1();

        // GET: ChuDes
        public ActionResult Index(int? page, string tenchude)
        {
            #region phan quyen
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "Login");
            }
            TaiKhoan check = Session["TaiKhoan"] as TaiKhoan;
            if (check.LoaiTaiKhoan != 0 && check.LoaiTaiKhoan != 1)
            {
                //ViewBag.ThongBao = "Tài khoản của bạn không được phép truy cập!";
                TempData["msg"] = "<script>alert('Tài khoản của bạn không được phép truy cập!');</script>";
                return RedirectToAction("Index", "Home");
            }
            #endregion

            #region tim kiem, phan trang
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if (tenchude == "" || tenchude == null)
            {
                return View(db.ChuDes.ToList().OrderBy(n => n.TenChuDe).ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return View(db.ChuDes.SqlQuery("select * from ChuDe where TenChuDe like '%'+@ten+'%'", new SqlParameter("@ten", tenchude)).ToList().OrderBy(n => n.TenChuDe).ToPagedList(pageNumber, pageSize));
            }
            #endregion
        }

        public PartialViewResult MonAnTheoChuDePartial()
        {
            return PartialView(db.ChuDes.OrderBy(n => n.TenChuDe).ToList());
        }

        public ViewResult MonAnTheoChuDe(int machude = 0)
        {
            //Kiểm tra chủ đề tồn tại hay không
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaChuDe == machude);
            if (cd == null)
            {
                //Response.StatusCode = 404;
                //return null;
                List<MonAn> monAns = db.MonAns.OrderBy(n => n.MaMonAn).ToList();
                ViewBag.TenChuDe = db.ChuDes.ToList();
                return View(monAns);
            }
            //Truy xuất danh sách các quyển sách theo chủ đề
            List<MonAn> lstMonAn = db.MonAns.Where(n => n.MaChuDe == machude).OrderBy(n => n.MaMonAn).ToList();
            if (lstMonAn.Count == 0)
            {
                ViewBag.Sach = "Không có món ăn nào thuộc chủ đề này!";
            }
            //Gán danh sách chủ để
            ViewBag.TenChuDe = db.ChuDes.ToList();
            return View(lstMonAn);
        }



        // GET: ChuDes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChuDes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChuDe,TenChuDe,MoTa")] ChuDe chuDe)
        {
            if (ModelState.IsValid)
            {
                db.ChuDes.Add(chuDe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chuDe);
        }

        // GET: ChuDes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuDe chuDe = db.ChuDes.Find(id);
            if (chuDe == null)
            {
                return HttpNotFound();
            }
            return View(chuDe);
        }

        // POST: ChuDes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChuDe,TenChuDe,MoTa")] ChuDe chuDe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chuDe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chuDe);
        }

        public ActionResult Delete(int id)
        {
            ChuDe chuDe = db.ChuDes.Find(id);
            db.ChuDes.Remove(chuDe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
