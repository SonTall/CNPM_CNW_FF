using FastFoodManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FastFoodManagement.Controllers
{
    public class AdminController : Controller
    {
        private FastFoodManagementEntities1 db = new FastFoodManagementEntities1();
        // GET: Admin
        public ActionResult Index()
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

            #region thong ke
            //so luong ban? ghi
            ViewBag.CountNhanVien = db.NhanViens.Count();
            ViewBag.CountTaiKhoan = db.TaiKhoans.Count();
            ViewBag.CountKhachHang = db.KhachHangs.Count();
            ViewBag.CountKhachVangLai = db.KhachVangLais.Count();
            ViewBag.CountChuDe = db.ChuDes.Count();
            ViewBag.CountMonAn = db.MonAns.Count();
            ViewBag.CountDonHang = db.DonHangs.Count();
            ViewBag.CountHoaDonThanhToan = db.HoaDonThanhToans.Count();
            ViewBag.CountKhuyenMai = db.KhuyenMais.Count();
            ViewBag.CountGiamGia = db.GiamGias.Count();

            // tong so hoa don da thanh toan
            ViewBag.HoaDonThanhToan = db.HoaDonThanhToans.Where(n => n.ThanhToan == true).Count();
            // tong so luong mon an da ban
            ViewBag.SoLuongMonAn = db.DonHangs.Where(n => n.HoaDonThanhToan.ThanhToan == true).Sum(n => n.SoLuong);
            // tai khoan 
            ViewBag.QuanTri = db.TaiKhoans.Where(n => n.LoaiTaiKhoan == 0).Count();
            ViewBag.NhanVien = db.TaiKhoans.Where(n => n.LoaiTaiKhoan == 1).Count();
            ViewBag.KhachHang = db.TaiKhoans.Where(n => n.LoaiTaiKhoan == 2).Count();

            // so luong don dat hang theo thang
            //ViewBag.DonHangTheoThang = db.HoaDonThanhToans.Where(n => n.ThanhToan == true).GroupBy(n => n.ThoiGianThanhToan.Value.Month).ToList();
            #endregion
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
