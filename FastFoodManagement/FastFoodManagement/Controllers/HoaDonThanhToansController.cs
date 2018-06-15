using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FastFoodManagement.Models;

namespace FastFoodManagement.Controllers
{
    public class HoaDonThanhToansController : Controller
    {
        private FastFoodManagementEntities1 db = new FastFoodManagementEntities1();

        public PartialViewResult AvaliableKhuyenMai()
        {
            var khuyenmai = db.KhuyenMais.ToList();
            return PartialView( khuyenmai);
        }

        // GET: HoaDonThanhToans
        public ActionResult Index()
        {
            var hoaDonThanhToans = db.HoaDonThanhToans.Include(h => h.KhachHang).Include(h => h.KhachVangLai).Include(h => h.NhanVien);
            return View(hoaDonThanhToans.ToList());
        }

        // GET: HoaDonThanhToans/Details/5
        public ActionResult Details(int? id)
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
            return View(hoaDonThanhToan);
        }

        // GET: HoaDonThanhToans/Create
        public ActionResult Create()
        {
            var khuyenmai = db.KhuyenMais.ToList();

            ViewBag.KhuyenMais = new SelectList(khuyenmai, "MaKhuyenMai", "MoTa");
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang");
            ViewBag.MaKhachVangLai = new SelectList(db.KhachVangLais, "MaKhachVangLai", "HoTen");
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen");
            return View();
        }

        // POST: HoaDonThanhToans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoaDon,MaNhanVien,MaKhachHang,MaKhachVangLai,GhiChu,ThoiGian")] HoaDonThanhToan hoaDonThanhToan, int KhuyenMais)
        {
            if (ModelState.IsValid)
            {
                //var km = ViewBag.KhuyenMai;
                //hoaDonThanhToan.KhuyenMais = km;
                hoaDonThanhToan.KhuyenMais = db.KhuyenMais.Where(v => v.MaKhuyenMai == KhuyenMais).ToList();

                db.HoaDonThanhToans.Add(hoaDonThanhToan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", hoaDonThanhToan.MaKhachHang);
            ViewBag.MaKhachVangLai = new SelectList(db.KhachVangLais, "MaKhachVangLai", "HoTen", hoaDonThanhToan.MaKhachVangLai);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", hoaDonThanhToan.MaNhanVien);
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
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", hoaDonThanhToan.MaNhanVien);
            return View(hoaDonThanhToan);
        }

        // POST: HoaDonThanhToans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoaDon,MaNhanVien,MaKhachHang,MaKhachVangLai,GhiChu,ThoiGian")] HoaDonThanhToan hoaDonThanhToan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDonThanhToan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhachHang = new SelectList(db.KhachHangs, "MaKhachHang", "TenKhachHang", hoaDonThanhToan.MaKhachHang);
            ViewBag.MaKhachVangLai = new SelectList(db.KhachVangLais, "MaKhachVangLai", "HoTen", hoaDonThanhToan.MaKhachVangLai);
            ViewBag.MaNhanVien = new SelectList(db.NhanViens, "MaNhanVien", "HoTen", hoaDonThanhToan.MaNhanVien);
            return View(hoaDonThanhToan);
        }

        // GET: HoaDonThanhToans/Delete/5
        public ActionResult Delete(int? id)
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
            return View(hoaDonThanhToan);
        }

        // POST: HoaDonThanhToans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
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
