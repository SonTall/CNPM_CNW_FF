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
    public class TaiKhoansController : Controller
    {
        private FastFoodManagementEntities1 db = new FastFoodManagementEntities1();
        private Encrypt md5 = new Encrypt();

        // GET: TaiKhoans
        public ActionResult Index(int? page, string hoten, int? loaitaikhoan)
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
            if ((hoten == null || hoten == "") && loaitaikhoan == null)
                return View(db.TaiKhoans.ToList().OrderBy(n => n.LoaiTaiKhoan).ToPagedList(pageNumber, pageSize));
            else if ((hoten != null || hoten != "") && loaitaikhoan == null)
                return View(db.TaiKhoans.Where(n => n.KhachHang.TenKhachHang.Contains(hoten) || n.NhanVien.HoTen.Contains(hoten)).ToList().OrderBy(n => n.LoaiTaiKhoan).ToPagedList(pageNumber, pageSize));
            else if ((hoten == null || hoten == "") && loaitaikhoan != null)
                return View(db.TaiKhoans.Where(n => n.LoaiTaiKhoan == loaitaikhoan).ToList().OrderBy(n => n.LoaiTaiKhoan).ToPagedList(pageNumber, pageSize));
            else
                return View(db.TaiKhoans.Where(n => n.LoaiTaiKhoan == loaitaikhoan && (n.KhachHang.TenKhachHang.Contains(hoten) || n.NhanVien.HoTen.Contains(hoten))).ToList().OrderBy(n => n.LoaiTaiKhoan).ToPagedList(pageNumber, pageSize));
            #endregion
        }

        // GET: TaiKhoans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // GET: TaiKhoans/Create
        public ActionResult Create()
        {
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang");
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen");
            return View();
        }

        // POST: TaiKhoans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTaiKhoan,MaKhachHang,MaNhanVien,TenTaiKhoan,MatKhau,ThoiGianTao,LoaiTaiKhoan,HinhAnh")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                taiKhoan.MatKhau = md5.Hash(taiKhoan.MatKhau);
                db.TaiKhoans.Add(taiKhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", taiKhoan.MaKhachHang);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", taiKhoan.MaNhanVien);
            return View(taiKhoan);
        }

        // GET: TaiKhoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", taiKhoan.MaKhachHang);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", taiKhoan.MaNhanVien);
            return View(taiKhoan);
        }

        // POST: TaiKhoans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTaiKhoan,MaKhachHang,MaNhanVien,TenTaiKhoan,MatKhau,ThoiGianTao,LoaiTaiKhoan,HinhAnh")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", taiKhoan.MaKhachHang);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", taiKhoan.MaNhanVien);
            return View(taiKhoan);
        }

        // GET: TaiKhoans/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
        //    if (taiKhoan == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(taiKhoan);
        //}

        //// POST: TaiKhoans/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            db.TaiKhoans.Remove(taiKhoan);
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
