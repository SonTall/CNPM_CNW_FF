using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastFoodManagement.Models;

namespace FastFoodManagement.Controllers
{
    public class GioHangController : Controller
    {
        FastFoodManagementEntities1 db = new FastFoodManagementEntities1();
        #region Func
        //Tính tổng số lượng và tổng tiền
        //Tính tổng số lượng
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        //Tính tổng thành tiền
        private double TongTien(double tongTien, double? giatri)
        {
            //double dTongTien = 0;
            //List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            //if (lstGioHang != null)
            //{
            //dTongTien = lstGioHang.Sum(n => n.ThanhTien);
            if (giatri != null)
            {
                tongTien = tongTien - tongTien * Convert.ToDouble(giatri) / 100;
            }
            //}
            return tongTien;
        }
        #endregion
        #region Giỏ hàng
        //Lấy giỏ hàng 
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì mình tiến hành khởi tao list giỏ hàng (sessionGioHang)
                lstGioHang = new List<GioHang>();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        //Thêm giỏ hàng
        public ActionResult ThemGioHang(int iMaMonAn, string strURL)
        {
            MonAn monAn = db.MonAns.SingleOrDefault(n => n.MaMonAn == iMaMonAn);
            if (monAn == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session giỏ hàng
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sách này đã tồn tại trong session[giohang] chưa
            GioHang sanpham = lstGioHang.Find(n => n.iMaMonAn == iMaMonAn);
            if (sanpham == null)
            {
                sanpham = new GioHang(iMaMonAn);
                //Add sản phẩm mới thêm vào list
                lstGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }
        }

        //Cập nhật giỏ hàng 
        public ActionResult CapNhatGioHang(int id, FormCollection f)
        {
            //Kiểm tra masp
            MonAn monAn = db.MonAns.SingleOrDefault(n => n.MaMonAn == id);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (monAn == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            //Kiểm tra sp có tồn tại trong session["GioHang"]
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMaMonAn == id);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("GioHang");
        }

        //Xóa giỏ hàng
        public ActionResult XoaGioHang(int id)
        {
            //Kiểm tra masp
            MonAn monAn = db.MonAns.SingleOrDefault(n => n.MaMonAn == id);
            //Nếu get sai masp thì sẽ trả về trang lỗi 404
            if (monAn == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<GioHang> lstGioHang = LayGioHang();
            GioHang sanpham = lstGioHang.SingleOrDefault(n => n.iMaMonAn == id);
            //Nếu mà tồn tại thì chúng ta cho sửa số lượng
            if (sanpham != null)
            {
                lstGioHang.RemoveAll(n => n.iMaMonAn == id);

            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }

        //Xây dựng trang giỏ hàng
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();

            // tinh tien co khuyen mai
            var khuyenMai = db.KhuyenMais.Where(n => n.ThoiGianBatDau < DateTime.Now && n.ThoiGianKetThuc > DateTime.Now).ToList();
            double dkhuyenMai = Convert.ToDouble(khuyenMai.Sum(n => n.GiaTri));

            ViewBag.KhuyenMai = khuyenMai;
            ViewBag.TongGiaTri = dkhuyenMai;
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien(lstGioHang.Sum(n => n.ThanhTien), dkhuyenMai);
            return View(lstGioHang);
        }

        //tạo partial giỏ hàng
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            return PartialView();
        }
        //Xây dựng 1 view cho người dùng chỉnh sửa giỏ hàng
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> lstGioHang = LayGioHang();
            return View(lstGioHang);

        }
        #endregion

        #region Đặt hàng
        public ActionResult DatHangTrucTiep()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DatHangTrucTiep([Bind(Include = "HoTen,DiaChi,SoDienThoai")] KhachVangLai khachVangLai)
        {
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                //Session["KhachVangLai"] = khachVangLai;
                db.KhachVangLais.Add(khachVangLai);
                db.SaveChanges();
                HoaDonThanhToan hoaDonThanhToan = new HoaDonThanhToan();
                hoaDonThanhToan.MaKhachVangLai = khachVangLai.MaKhachVangLai;
                hoaDonThanhToan.ThanhToan = false;
                hoaDonThanhToan.ThoiGianDatHang = DateTime.Now;
                hoaDonThanhToan.GiaoHang = false;
                db.HoaDonThanhToans.Add(hoaDonThanhToan);
                db.SaveChanges();

                List<GioHang> gioHangs = LayGioHang();
                foreach (var item in gioHangs)
                {
                    DonHang donHang = new DonHang();
                    donHang.MaHoaDon = hoaDonThanhToan.MaHoaDon;
                    donHang.MaMonAn = item.iMaMonAn;
                    donHang.SoLuong = item.iSoLuong;
                    db.DonHangs.Add(donHang);
                    db.SaveChanges();
                }
                //ViewBag.ThongBao = "Đặt hàng thành công!";
                TempData["ThongBao"] = "Mua hàng thành công!";
                return RedirectToAction("GioHang", "GioHang");
            }
            ViewBag.ThongBao = "Đặt hàng không thành công!";
            return View();
        }


        [HttpPost]
        public ActionResult DatHang()
        {
            //Kiểm tra đăng đăng nhập
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                //string str = "GioHang";
                TempData["Redirection"] = "Đăng nhập thành công vào lại giỏ hàng để đặt hàng!";

                //TempData["Redirection"] = "<script>" + " $("#out").click(function() {" +
                //    "</script>";
                //    $("#out").click(function() {
                //    window.location.href = '@Url.Action("DangXuat", "Login")';
                //});
                return RedirectToAction("DangNhap", "Login");
            }
            //Kiểm tra giỏ hàng
            if (Session["GioHang"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            //Thêm đơn hàng
            TaiKhoan taiKhoan = Session["TaiKhoan"] as TaiKhoan;
            HoaDonThanhToan hoaDonThanhToan = new HoaDonThanhToan();
            hoaDonThanhToan.MaKhachHang = taiKhoan.MaKhachHang;
            hoaDonThanhToan.ThanhToan = false;
            hoaDonThanhToan.ThoiGianDatHang = DateTime.Now;
            hoaDonThanhToan.GiaoHang = false;
            db.HoaDonThanhToans.Add(hoaDonThanhToan);
            db.SaveChanges();

            List<GioHang> gioHangs = LayGioHang();
            foreach (var item in gioHangs)
            {
                DonHang donHang = new DonHang();
                donHang.MaHoaDon = hoaDonThanhToan.MaHoaDon;
                donHang.MaMonAn = item.iMaMonAn;
                donHang.SoLuong = item.iSoLuong;
                db.DonHangs.Add(donHang);
                db.SaveChanges();
            }
            TempData["ThongBao"] = "Mua hàng thành công!";
            return RedirectToAction("GioHang", "GioHang");
            //return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}
