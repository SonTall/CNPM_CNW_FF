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
    public class MonAnsController : Controller
    {
        private FastFoodManagementEntities1 db = new FastFoodManagementEntities1();

        // GET: MonAns
        public ActionResult Index(int? page, string tenmon, string gia)
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
            if ((tenmon == null || tenmon == "") && (gia == null || gia == ""))
                return View(db.MonAns.ToList().OrderBy(n => n.TenMonAn).ToPagedList(pageNumber, pageSize));
            else if ((tenmon != null || tenmon != "") && (gia == null || gia == ""))
                return View(db.MonAns.SqlQuery("select * from MonAn where TenMonAn like '%'+@ten+'%'", new SqlParameter("@ten", tenmon)).ToList().OrderBy(n => n.TenMonAn).ToPagedList(pageNumber, pageSize));
            else if ((tenmon == null || tenmon == "") && (gia != null || gia != ""))
                return View(db.MonAns.SqlQuery("select * from MonAn where DonGia = @gia", new SqlParameter("@gia", gia)).ToList().OrderBy(n => n.TenMonAn).ToPagedList(pageNumber, pageSize));
            else
                return View(db.MonAns.SqlQuery("select * from MonAn where TenMonAn like '%'+@ten+'%' and DonGia = @gia", new SqlParameter("@ten", tenmon), new SqlParameter("@gia", gia)).ToList().OrderBy(n => n.TenMonAn).ToPagedList(pageNumber, pageSize));
            #endregion
        }

        // GET: MonAns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.MonAns.Find(id);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            List<MonAn> lstMonAn = db.MonAns.Where(n => n.MaChuDe == monAn.MaChuDe).OrderBy(n => n.TenMonAn).ToList();
            ViewBag.ListSame = lstMonAn;
            return View(monAn);
        }

        // GET: MonAns/Create
        public ActionResult Create()
        {
            ViewBag.MaChuDe = new SelectList(db.ChuDes, "MaChuDe", "TenChuDe");
            return View();
        }

        // POST: MonAns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMonAn,MaChuDe,TenMonAn,DonGia,HinhAnh,GhiChu")] MonAn monAn)
        {
            if (ModelState.IsValid)
            {
                db.MonAns.Add(monAn);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChuDe = new SelectList(db.ChuDes, "MaChuDe", "TenChuDe", monAn.MaChuDe);
            return View(monAn);
        }

        // GET: MonAns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MonAn monAn = db.MonAns.Find(id);
            if (monAn == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChuDe = new SelectList(db.ChuDes, "MaChuDe", "TenChuDe", monAn.MaChuDe);
            return View(monAn);
        }

        // POST: MonAns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMonAn,MaChuDe,TenMonAn,DonGia,HinhAnh,GhiChu")] MonAn monAn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monAn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChuDe = new SelectList(db.ChuDes, "MaChuDe", "TenChuDe", monAn.MaChuDe);
            return View(monAn);
        }

        //// GET: MonAns/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    MonAn monAn = db.MonAns.Find(id);
        //    if (monAn == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(monAn);
        //}

        // POST: MonAns/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            MonAn monAn = db.MonAns.Find(id);
            db.MonAns.Remove(monAn);
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
