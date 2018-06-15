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
    public class DonHangsController : Controller
    {
        private FastFoodManagementEntities1 db = new FastFoodManagementEntities1();

        // GET: DonHangs
        public ActionResult Index()
        {
            var donHangs = db.DonHangs.Include(d => d.HoaDonThanhToan).Include(d => d.MonAn);
            return View(donHangs.ToList());
        }

        // GET: DonHangs/Details/5
        public ActionResult Details(int? mahoadon, int? mamonan)
        {
            if (mahoadon == null || mamonan == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.FirstOrDefault(v => v.MaHoaDon == mahoadon.Value && v.MaMonAn == mamonan.Value);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
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
        public ActionResult Create([Bind(Include = "MaHoaDon,MaMonAn,SoLuong")] DonHang donHang)
        {
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
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
        public ActionResult Edit([Bind(Include = "MaHoaDon,MaMonAn,SoLuong")] DonHang donHang)
        {
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

        // GET: DonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonHang donHang = db.DonHangs.Find(id);
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
