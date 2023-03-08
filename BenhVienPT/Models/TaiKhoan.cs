using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BenhVienPT.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            NhanVien = new HashSet<NhanVien>();
        }

        public int Id { get; set; }
        public string TaiKhoan1 { get; set; }
        public string MatKhau { get; set; }
        public int? IdvaiTro { get; set; }

        public virtual VaiTro IdvaiTroNavigation { get; set; }
        public virtual ICollection<NhanVien> NhanVien { get; set; }
    }
}
