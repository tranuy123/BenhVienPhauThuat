using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BenhVienPT.Models
{
    public partial class BenhAn
    {
        public BenhAn()
        {
            CaMo = new HashSet<CaMo>();
            ChiTietBenhAn = new HashSet<ChiTietBenhAn>();
        }

        public int Id { get; set; }
        public string MaBenhAn { get; set; }
        public int? IdbenhNhan { get; set; }
        public int? Idnv { get; set; }
        public string GhiChu { get; set; }
        public bool? TrangThai { get; set; }
        public string Ylenh { get; set; }

        public virtual BenhNhan IdbenhNhanNavigation { get; set; }
        public virtual NhanVien IdnvNavigation { get; set; }
        public virtual ICollection<CaMo> CaMo { get; set; }
        public virtual ICollection<ChiTietBenhAn> ChiTietBenhAn { get; set; }
    }
}
