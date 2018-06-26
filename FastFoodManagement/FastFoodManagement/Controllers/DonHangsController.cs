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
    public class DonHangsController : Controller
    {
        private FastFoodManagementEntities1 db = new FastFoodManagementEntities1();

        // GET: DonHangs
        public ActionResult Index(int? page, string ghichu, int? soluong)
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

            if ((ghichu == null || ghichu == "") && soluong == null)
                return View(db.DonHangs.ToList().OrderBy(n => n.MaHoaDon).ToPagedList(pageNumber, pageSize));
            else if ((ghichu != null || ghichu != "") && soluong == null)
            {
                var tmp = db.HoaDonThanhToans.SingleOrDefault(n => n.GhiChu == ghichu);
                if (tmp != null)
                    return View(db.DonHangs.Where(n => n.MaHoaDon == tmp.MaHoaDon).ToList().ToPagedList(pageNumber, pageSize));
                else
                    return View(db.DonHangs.Where(n => n.MaHoaDon == null).ToList().ToPagedList(pageNumber, pageSize));
            }
            else if ((ghichu == null || ghichu == "") && soluong != null)
                return View(db.DonHangs.Where(n => n.SoLuong == soluong).ToList().ToPagedList(pageNumber, pageSize));
            else
            {
                var tmp = db.HoaDonThanhToans.Single(n => n.GhiChu == ghichu);
                return View(db.DonHangs.Where(n => n.MaHoaDon == tmp.MaHoaDon && n.SoLuong == soluong).ToList().ToPagedList(pageNumber, pageSize));
            }
            #endregion
        }

        // GET: DonHangs/Create
        public ActionResult Create()
        {
            ViewBag.MaHoaDon = new SelectList(db.HoaDonThanhToans, "MaHoaDon", "GhiChu");
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn");
            return View();
        }

        // POST: DonHangs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoaDon,MaMonAn,SoLuong,ThoiGianDatHang")] DonHang donHang)
        {
            if (donHang.SoLuong <= 0)
            {
                ViewBag.ThongBao = "Số lượng món ăn phải > 0!";
                return View();
            }
            if (ModelState.IsValid)
            {
                db.DonHangs.Add(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHoaDon = new SelectList(db.HoaDonThanhToans, "MaHoaDon", "GhiChu", donHang.MaHoaDon);
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn", donHang.MaMonAn);
            return View(donHang);
        }

        // GET: DonHangs/Edit/5
        public ActionResult Edit(int? mahoadon, int? mamonan)
        {
            if (mahoadon == null || mamonan == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.SingleOrDefault(v => v.MaHoaDon == mahoadon.Value && v.MaMonAn == mamonan.Value);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHoaDon = new SelectList(db.HoaDonThanhToans, "MaHoaDon", "GhiChu", donHang.MaHoaDon);
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn", donHang.MaMonAn);
            return View(donHang);
        }

        // POST: DonHangs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoaDon,MaMonAn,SoLuong,ThoiGianDatHang")] DonHang donHang)
        {
            if (donHang.SoLuong <= 0)
            {
                ViewBag.ThongBao = "Số lượng món ăn phải > 0!";
                return View();
            }
            if (ModelState.IsValid)
            {
                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHoaDon = new SelectList(db.HoaDonThanhToans, "MaHoaDon", "GhiChu", donHang.MaHoaDon);
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn", donHang.MaMonAn);
            return View(donHang);
        }

        public ActionResult Delete(int? mahoadon, int? mamonan)
        {
            DonHang donHang = db.DonHangs.SingleOrDefault(v => v.MaHoaDon == mahoadon.Value && v.MaMonAn == mamonan.Value);
            db.DonHangs.Remove(donHang);
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
