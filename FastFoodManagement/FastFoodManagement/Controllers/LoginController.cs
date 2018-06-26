using FastFoodManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FastFoodManagement.Controllers
{
    public class LoginController : Controller
    {
        private FastFoodManagementEntities1 db = new FastFoodManagementEntities1();
        private Encrypt md5 = new Encrypt();
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
        public ActionResult DangKy([Bind(Include = "TenKhachHang,DiaChi,SoDienThoai,Email")] KhachHang kh, FormCollection f)
        {
            if (ModelState.IsValid)
            {
                if (kh.TenKhachHang == null || kh.SoDienThoai == null || kh.SoDienThoai == null || f["txtTaiKhoan"].ToString() == "" || f["txtMatKhau"].ToString() == "")
                {
                    ViewBag.ThongBao = "Nhập thiếu thông tin!";
                    return View();
                }
                if (f["txtMatKhau"].ToString().Length < 8)
                {
                    ViewBag.ThongBao = "Mật khẩu phải nhiều hơn 7 ký tự!";
                    return View();
                }
                var strTk = f["txtTaiKhoan"].ToString();
                if (db.TaiKhoans.SingleOrDefault(n => n.TenTaiKhoan == strTk) != null)
                {
                    ViewBag.ThongBao = "Tên tài khoản đã tồn tại!";
                    return View();
                }
                else
                {
                    db.KhachHangs.Add(kh);
                    db.SaveChanges();

                    TaiKhoan tk = new TaiKhoan();
                    tk.TenTaiKhoan = f["txtTaiKhoan"].ToString();
                    //tk.MatKhau = f["txtMatKhau"].ToString();
                    tk.MatKhau = md5.Hash(f["txtMatKhau"].ToString());
                    tk.MaKhachHang = kh.MaKhachHang;
                    tk.ThoiGianTao = DateTime.Now;
                    tk.LoaiTaiKhoan = 2;
                    db.TaiKhoans.Add(tk);
                    db.SaveChanges();
                    TempData["ThongBao"] = "Tạo tài khoản thành công!";
                    return RedirectToAction("DangNhap", "Login");
                }
            }

            //ViewBag.ThongBao = "Tạo tài khoản không thành công!";
            TempData["ThongBao"] = "Tạo tài khoản không thành công!";
            return View();
        }

        [HttpGet]
        public ActionResult TaiKhoan()
        {
            TaiKhoan tk = Session["TaiKhoan"] as TaiKhoan;
            int id = tk.MaTaiKhoan;
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan.LoaiTaiKhoan == 0 || taiKhoan.LoaiTaiKhoan == 1)
            {
                return RedirectToAction("Details", "NhanViens");
            }
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.ThongTin = db.KhachHangs.Find(tk.MaKhachHang);
            return View(taiKhoan);
        }
        [HttpPost]
        public ActionResult TaiKhoan([Bind(Include = "MaTaiKhoan,LoaiTaiKhoan,TenTaiKhoan,MatKhau,MaKhachHang")] TaiKhoan tk, string tenkhachhang, string diachi, string sdt, string email, string matkhauxacnhan)
        {
            if (ModelState.IsValid)
            {
                if (matkhauxacnhan == null || matkhauxacnhan == "")
                {
                    TaiKhoan tmp = Session["TaiKhoan"] as TaiKhoan;
                    int id = tmp.MaTaiKhoan;
                    TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
                    ViewBag.ThongBao = "Nhập mật khẩu cũ để xác nhận!";
                    return View(taiKhoan);
                }
                if (md5.Hash(matkhauxacnhan) != db.TaiKhoans.Find(tk.MaTaiKhoan).MatKhau)
                {
                    TaiKhoan tmp = Session["TaiKhoan"] as TaiKhoan;
                    int id = tmp.MaTaiKhoan;
                    TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
                    ViewBag.ThongBao = "Mật khẩu xác nhận không chính xác!";
                    return View(taiKhoan);
                }
                KhachHang kh = new KhachHang();
                //if(tk.MaKhachHang != null)
                kh.MaKhachHang = (int)tk.MaKhachHang;
                kh.TenKhachHang = tenkhachhang;
                kh.DiaChi = diachi;
                kh.SoDienThoai = sdt;
                kh.Email = email;
                db.Entry(tk).State = EntityState.Modified;
                db.SaveChanges();
                db.Entry(kh).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("I);
            }
            ViewBag.ThongBao = "Đổi thông tin thành công!";
            return View();
        }

        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            if (Session["TaiKhoan"] != null)
            {
                return RedirectToAction("TaiKhoan");
            }
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = md5.Hash(f.Get("txtMatKhau").ToString());
            var tk = db.TaiKhoans.SingleOrDefault(n => n.TenTaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if (tk != null)
            {
                //ViewBag.ThongBao = "Đăng nhập thành công!";
                Session["TaiKhoan"] = tk;
                if (tk.LoaiTaiKhoan == 0 || tk.LoaiTaiKhoan == 1)
                    return RedirectToAction("Index", "Admin");
                else
                    return RedirectToAction("Index", "Home");
            }
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng!";
            return View();
        }
    }
}
