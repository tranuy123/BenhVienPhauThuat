using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BenhVienPT.Models
{
    public partial class PhongHoiTinh
    {
        public PhongHoiTinh()
        {
            CaMo = new HashSet<CaMo>();
        }

        public int Id { get; set; }
        public string MaPhongHt { get; set; }
        public string TenPhong { get; set; }
        public bool? TrangThai { get; set; }

        public virtual ICollection<CaMo> CaMo { get; set; }
    }
}
