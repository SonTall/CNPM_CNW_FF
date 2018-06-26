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
    public class NhanViensController : Controller
    {
        private FastFoodManagementEntities1 db = new FastFoodManagementEntities1();

        // GET: NhanViens
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
                return View(db.NhanViens.ToList().OrderBy(n => n.HoTen).ToPagedList(pageNumber, pageSize));
            else
                return View(db.NhanViens.Where(n => n.HoTen.Contains(hoten)).ToList().OrderBy(n => n.HoTen).ToPagedList(pageNumber, pageSize));
            #endregion
        }

        // GET: NhanViens/Details/5
        public ActionResult Details()
        {
            TaiKhoan tk = Session["TaiKhoan"] as TaiKhoan;
            var taiKhoanNhanVien = db.TaiKhoans.Find(tk.MaTaiKhoan);
            ViewBag.TaiKhoan = taiKhoanNhanVien;
            NhanVien nhanVien = db.NhanViens.Find(tk.MaNhanVien);
            return View(nhanVien);
        }

        // GET: NhanViens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanViens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNhanVien,HoTen,GioiTinh,NgaySinh,SoDienThoai,DiaChi,Email")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhanVien);
        }

        // GET: NhanViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNhanVien,HoTen,GioiTinh,NgaySinh,SoDienThoai,DiaChi,Email")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    NhanVien nhanVien = db.NhanViens.Find(id);
        //    if (nhanVien == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(nhanVien);
        //}

        //// POST: NhanViens/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
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
