using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FastFoodManagement.Models;
using PagedList;

namespace FastFoodManagement.Controllers
{
    public class KhachHangsController : Controller
    {
        private FastFoodManagementEntities1 db = new FastFoodManagementEntities1();

        // GET: KhachHangs
        public ActionResult Index(int? page, string hoten)
        {
            #region phan quyen
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "Login");
            }
            TaiKhoan check = Session["TaiKhoan"] as TaiKhoan;
            if (check.LoaiTaiKhoan != 0)
            {
                //ViewBag.ThongBao = "Tài khoản của bạn không được phép truy cập!";
                if (check.LoaiTaiKhoan == 2)
                {
                    TempData["msg"] = "<script>alert('Tài khoản của bạn không được phép truy cập!');</script>";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["msg"] = "<script>alert('Chỉ admin mới được phép truy cập các bảng này!');</script>";
                    return RedirectToAction("Index", "Admin");
                }
            }
            #endregion

            #region tim kiem, phan trang
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if (hoten == null || hoten == "")
                return View(db.KhachHangs.ToList().OrderBy(n => n.TenKhachHang).ToPagedList(pageNumber, pageSize));
            else
                return View(db.KhachHangs.Where(n => n.TenKhachHang.Contains(hoten)).ToList().OrderBy(n => n.TenKhachHang).ToPagedList(pageNumber, pageSize));
            #endregion
        }

        // GET: KhachHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // GET: KhachHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhachHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhachHang,TenKhachHang,DiaChi,SoDienThoai,Email")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachHang);
        }

        // GET: KhachHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhachHang,TenKhachHang,DiaChi,SoDienThoai,Email")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        // GET: KhachHangs/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    KhachHang khachHang = db.KhachHangs.Find(id);
        //    if (khachHang == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(khachHang);
        //}

        //// POST: KhachHangs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(khachHang);
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
