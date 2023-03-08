using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BenhVienPT.Models
{
    public partial class PhongMo
    {
        public PhongMo()
        {
            CaMo = new HashSet<CaMo>();
            ChiTietPhongBenh = new HashSet<ChiTietPhongBenh>();
            ChiTietPhongMo = new HashSet<ChiTietPhongMo>();
            ChiTietVatTu = new HashSet<ChiTietVatTu>();
        }

        public int Id { get; set; }
        public string MaPhongMo { get; set; }
        public string TenPhongMo { get; set; }
        public bool? TrangThai { get; set; }
        public string Loai { get; set; }

        public virtual ICollection<CaMo> CaMo { get; set; }
        public virtual ICollection<ChiTietPhongBenh> ChiTietPhongBenh { get; set; }
        public virtual ICollection<ChiTietPhongMo> ChiTietPhongMo { get; set; }
        public virtual ICollection<ChiTietVatTu> ChiTietVatTu { get; set; }
    }
}
