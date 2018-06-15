//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FastFoodManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoaDonThanhToan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDonThanhToan()
        {
            this.DonHangs = new HashSet<DonHang>();
            this.KhuyenMais = new HashSet<KhuyenMai>();
        }
    
        public int MaHoaDon { get; set; }
        public int MaNhanVien { get; set; }
        public Nullable<int> MaKhachHang { get; set; }
        public Nullable<int> MaKhachVangLai { get; set; }
        public string GhiChu { get; set; }
        public Nullable<System.DateTime> ThoiGian { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual KhachVangLai KhachVangLai { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhuyenMai> KhuyenMais { get; set; }
    }
}