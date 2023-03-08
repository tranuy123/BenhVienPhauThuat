using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BenhVienPT.Models
{
    public partial class VaiTro
    {
        public VaiTro()
        {
            LichTruc = new HashSet<LichTruc>();
            TaiKhoan = new HashSet<TaiKhoan>();
        }

        public int Id { get; set; }
        public string MaVt { get; set; }
        public string TenVaiTro { get; set; }

        public virtual ICollection<LichTruc> LichTruc { get; set; }
        public virtual ICollection<TaiKhoan> TaiKhoan { get; set; }
    }
}
