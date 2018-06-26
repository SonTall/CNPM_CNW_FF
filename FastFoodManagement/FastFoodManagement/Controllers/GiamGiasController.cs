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
    public class GiamGiasController : Controller
    {
        private FastFoodManagementEntities1 db = new FastFoodManagementEntities1();

        // GET: GiamGias
        public ActionResult Index(int? page, string ghichu, string mota)
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
            if ((ghichu == null || ghichu == "") && (mota == null || mota == ""))
                return View(db.GiamGias.ToList().OrderBy(n => n.MaKhuyenMai).ToPagedList(pageNumber, pageSize));
            else if ((ghichu != null || ghichu != "") && (mota == null || mota == ""))
                return View(db.GiamGias.Where(n => n.HoaDonThanhToan.GhiChu.Equals(ghichu)).ToList().ToPagedList(pageNumber, pageSize));
            else if ((ghichu == null || ghichu == "") && (mota != null || mota != ""))
                return View(db.GiamGias.Where(n => n.KhuyenMai.MoTa.Contains(mota)).ToList().ToPagedList(pageNumber, pageSize));
            else
                return View(db.GiamGias.Where(n => n.KhuyenMai.MoTa.Contains(mota) && n.HoaDonThanhToan.GhiChu.Equals(ghichu)).ToList().OrderBy(n => n.MaKhuyenMai).ToPagedList(pageNumber, pageSize));
            #endregion
        }

        // GET: GiamGias/Create
        public ActionResult Create()
        {
            ViewBag.MaHoaDon = new SelectList(db.HoaDonThanhToans, "MaHoaDon", "GhiChu");
            ViewBag.MaKhuyenMai = new SelectList(db.KhuyenMais, "MaKhuyenMai", "MoTa");
            return View();
        }

        // POST: GiamGias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhuyenMai,MaHoaDon,ApDung")] GiamGia giamGia)
        {
            if (ModelState.IsValid)
            {
                db.GiamGias.Add(giamGia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHoaDon = new SelectList(db.HoaDonThanhToans, "MaHoaDon", "GhiChu", giamGia.MaHoaDon);
            ViewBag.MaKhuyenMai = new SelectList(db.KhuyenMais, "MaKhuyenMai", "MoTa", giamGia.MaKhuyenMai);
            return View(giamGia);
        }

        // GET: GiamGias/Edit/5
        public ActionResult Edit(int? mahoadon, int? makhuyenmai)
        {
            if (mahoadon == null && makhuyenmai == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GiamGia giamGia = db.GiamGias.SingleOrDefault(n => n.MaHoaDon == mahoadon && n.MaKhuyenMai == makhuyenmai);
            if (giamGia == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHoaDon = new SelectList(db.HoaDonThanhToans, "MaHoaDon", "GhiChu", giamGia.MaHoaDon);
            ViewBag.MaKhuyenMai = new SelectList(db.KhuyenMais, "MaKhuyenMai", "MoTa", giamGia.MaKhuyenMai);
            return View(giamGia);
        }

        // POST: GiamGias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhuyenMai,MaHoaDon,ApDung")] GiamGia giamGia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giamGia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHoaDon = new SelectList(db.HoaDonThanhToans, "MaHoaDon", "GhiChu", giamGia.MaHoaDon);
            ViewBag.MaKhuyenMai = new SelectList(db.KhuyenMais, "MaKhuyenMai", "MoTa", giamGia.MaKhuyenMai);
            return View(giamGia);
        }

        public ActionResult Delete(int mahoadon, int makhuyenmai)
        {
            GiamGia giamGia = db.GiamGias.SingleOrDefault(n => n.MaHoaDon == mahoadon && n.MaKhuyenMai == makhuyenmai);
            db.GiamGias.Remove(giamGia);
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
