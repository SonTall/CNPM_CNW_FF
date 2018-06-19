using FastFoodManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FastFoodManagement.Controllers
{
    public class LoginController : Controller
    {
        private FastFoodManagementEntities1 db = new FastFoodManagementEntities1();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {

            return View();
        }
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult DangKy(KhachHang kh, FormCollection f)
        {
            if (ModelState.IsValid)
            {
                string sTaiKhoan = f["txtTaiKhoan"].ToString();
                string sMatKhau = f.Get("txtMatKhau").ToString();
                //TaiKhoan tk = new TaiKhoan();
                //{
                //    tk.MaTaiKhoan = 1;
                //    tk.MaKhachHang = kh.MaKhachHang;
                //    tk.MaNhanVien = null;
                //    tk.TenTaiKhoan = sTaiKhoan;
                //    tk.MatKhau = sMatKhau;
                //    //tk.ThoiGianTao = DateTime.Now;
                //    tk.LoaiTaiKhoan = 1;
                //    tk.HinhAnh = null;
                //}

                //Chèn dữ liệu vào bảng khách hàng
                db.KhachHangs.Add(kh);
                //Lưu vào csdl 
                db.SaveChanges();
                db.TaiKhoans.SqlQuery("insert into TaiKhoan values ( @makhachhang , NULL, @taikhoan, @matkhau, @ngaytao, 1, '')", new SqlParameter("@makhachhang", kh.MaKhachHang), new SqlParameter("@taikhoan", sTaiKhoan), new SqlParameter("@matkhau", sMatKhau), new SqlParameter("@ngaytao", DateTime.Now));
                //db.SaveChanges();

            }
            return View();
        }

        [HttpGet]
        public ActionResult TaiKhoan()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult TaiKhoan()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult DangNhap()
        {
            if (Session["TaiKhoan"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f.Get("txtMatKhau").ToString();
            var tk = db.TaiKhoans.SingleOrDefault(n => n.TenTaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if (tk != null)
            {
                //ViewBag.ThongBao = "Đăng nhập thành công!";
                Session["TaiKhoan"] = tk;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng!";
            return View();
        }
    }
}
