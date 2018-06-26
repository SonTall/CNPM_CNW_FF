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
    public class HoaDonThanhToansController : Controller
    {
        private FastFoodManagementEntities1 db = new FastFoodManagementEntities1();

        // GET: HoaDonThanhToans
        public ActionResult Index(int? page, string khachhang, string khachvanglai, string ghichu)
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

            #region tim kiem hoa don thanh toan, phan trang
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if ((khachhang == "" || khachhang == null) && (khachvanglai == "" || khachvanglai == null) && (ghichu == null || ghichu == ""))
                return View(db.HoaDonThanhToans.ToList().OrderBy(n => n.MaHoaDon).ToPagedList(pageNumber, pageSize));
            // khach hang 
            else if ((khachhang != "" || khachhang != null) && (khachvanglai == "" || khachvanglai == null) && (ghichu == null || ghichu == ""))
                return View(db.HoaDonThanhToans.Where(n => n.KhachHang.TenKhachHang.Contains(khachhang)).ToList().OrderBy(n => n.MaHoaDon).ToPagedList(pageNumber, pageSize));
            // khach vang lai
            else if ((khachhang == "" || khachhang == null) && (khachvanglai != "" || khachvanglai != null) && (ghichu == null || ghichu == ""))
                return View(db.HoaDonThanhToans.Where(n => n.KhachVangLai.HoTen.Contains(khachvanglai)).ToList().OrderBy(n => n.MaHoaDon).ToPagedList(pageNumber, pageSize));
            //ghi chu
            else if ((khachhang == "" || khachhang == null) && (khachvanglai == "" || khachvanglai == null) && (ghichu != null || ghichu != ""))
                return View(db.HoaDonThanhToans.Where(n => n.GhiChu.Contains(ghichu)).ToList().OrderBy(n => n.MaHoaDon).ToPagedList(pageNumber, pageSize));
            // khach hang va ghi chu
            else if ((khachhang != "" || khachhang != null) && (khachvanglai == "" || khachvanglai == null) && (ghichu != null || ghichu != ""))
                return View(db.HoaDonThanhToans.Where(n => n.GhiChu.Contains(ghichu) && n.KhachHang.TenKhachHang.Contains(khachhang)).ToList().OrderBy(n => n.MaHoaDon).ToPagedList(pageNumber, pageSize));
            // khach vang lai va ghi chu
            else if ((khachhang == "" || khachhang == null) && (khachvanglai != "" || khachvanglai != null) && (ghichu != null || ghichu != ""))
                return View(db.HoaDonThanhToans.Where(n => n.GhiChu.Contains(ghichu) && n.KhachVangLai.HoTen.Contains(khachvanglai)).ToList().OrderBy(n => n.MaHoaDon).ToPagedList(pageNumber, pageSize));
            else
                return View(db.HoaDonThanhToans.Where(n => n.MaHoaDon == null).ToList().OrderBy(n => n.MaHoaDon).ToPagedList(pageNumber, pageSize));
            #endregion
        }

        // GET: HoaDonThanhToans/Create
        public ActionResult Create()
        {
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang");
            ViewBag.MaKhachVangLai = new SelectList(db.KhachVangLais, "MaKhachVangLai", "HoTen");
            ViewBag.MaMonAn = new SelectList(db.MonAns, "MaMonAn", "TenMonAn");
            return View();
        }

        // POST: HoaDonThanhToans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoaDon,MaKhachHang,MaKhachVangLai,ThanhToan,GhiChu,ThoiGianDatHang,ThoiGianThanhToan,GiaoHang")] HoaDonThanhToan hoaDonThanhToan, [Bind(Include = "MaMonAn")] DonHang donHang, FormCollection f)
        {
            if (ModelState.IsValid)
            {
                //db.MonAns.SingleOrDefault(n => n.TenMonAn == f["txtMonAn"].ToString());
                donHang.SoLuong = Convert.ToInt32(f["txtSoLuong"].ToString());
                db.HoaDonThanhToans.Add(hoaDonThanhToan);
                db.SaveChanges();
                donHang.MaHoaDon = hoaDonThanhToan.MaHoaDon;
                db.DonHangs.Add(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", hoaDonThanhToan.MaKhachHang);
            ViewBag.MaKhachVangLai = new SelectList(db.KhachVangLais, "MaKhachVangLai", "HoTen", hoaDonThanhToan.MaKhachVangLai);
            return View(hoaDonThanhToan);
        }

        // GET: HoaDonThanhToans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDonThanhToan hoaDonThanhToan = db.HoaDonThanhToans.Find(id);
            if (hoaDonThanhToan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", hoaDonThanhToan.MaKhachHang);
            ViewBag.MaKhachVangLai = new SelectList(db.KhachVangLais, "MaKhachVangLai", "HoTen", hoaDonThanhToan.MaKhachVangLai);
            return View(hoaDonThanhToan);
        }

        // POST: HoaDonThanhToans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoaDon,MaKhachHang,MaKhachVangLai,ThanhToan,GhiChu,ThoiGianDatHang,ThoiGianThanhToan,GiaoHang")] HoaDonThanhToan hoaDonThanhToan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDonThanhToan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", hoaDonThanhToan.MaKhachHang);
            ViewBag.MaKhachVangLai = new SelectList(db.KhachVangLais, "MaKhachVangLai", "HoTen", hoaDonThanhToan.MaKhachVangLai);
            return View(hoaDonThanhToan);
        }

        public ActionResult Delete(int id)
        {
            var donHang = db.DonHangs.SqlQuery("Select * from DonHang where MaHoaDon = @id", new SqlParameter("@id", id)).ToList();
            if (donHang != null)
            {
                db.DonHangs.RemoveRange(donHang);
                db.SaveChanges();
            }
            var giamGia = db.GiamGias.SqlQuery("Select * from GiamGia where MaHoaDon = @id", new SqlParameter("@id", id)).ToList();
            if (giamGia != null)
            {
                db.GiamGias.RemoveRange(giamGia);
                db.SaveChanges();
            }
            HoaDonThanhToan hoaDonThanhToan = db.HoaDonThanhToans.Find(id);
            db.HoaDonThanhToans.Remove(hoaDonThanhToan);
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
