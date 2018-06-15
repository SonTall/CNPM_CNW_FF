using FastFoodManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FastFoodManagement.Models
{
    public class GioHang
    {
        FastFoodManagementEntities1 db = new FastFoodManagementEntities1();
        public int iMaMonAn { get; set; }
        public int iMaChuDe { get; set; }
        public string sTenMonAn { get; set; }
        public string sHinhAnh { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        //Hàm tạo cho giỏ hàng
        public GioHang(int MaMonAn)
        {
            iMaMonAn = MaMonAn;
            MonAn monAn = db.MonAns.Single(n => n.MaMonAn == iMaMonAn);
            iMaChuDe = monAn.MaChuDe;
            sTenMonAn = monAn.TenMonAn;
            sHinhAnh = monAn.HinhAnh;
            dDonGia = double.Parse(monAn.DonGia.ToString());
            iSoLuong = 1;
        }

    }
}