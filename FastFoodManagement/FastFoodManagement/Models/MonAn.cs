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
    
    public partial class MonAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MonAn()
        {
            this.DonHangs = new HashSet<DonHang>();
        }
    
        public int MaMonAn { get; set; }
        public string TenMonAn { get; set; }
        public string DonGia { get; set; }
        public string HinhAnh { get; set; }
        public string GhiChu { get; set; }
        public int MaChuDe { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
        public virtual ChuDe ChuDe { get; set; }
    }
}