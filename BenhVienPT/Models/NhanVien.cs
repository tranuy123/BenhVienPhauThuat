using System;
using System.Collections.Generic;
using System.Linq;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BenhVienPT.Models
{
    public partial class NhanVien
    {
        public NhanVien()
        {
            BenhAn = new HashSet<BenhAn>();
            ChiTietVatTu = new HashSet<ChiTietVatTu>();
            LichMo = new HashSet<LichMo>();
            LichTruc = new HashSet<LichTruc>();
        }

        public int Id { get; set; }
        public string MaNv { get; set; }
        public string TenNv { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public int? IdtaiKhoan { get; set; }

        public virtual TaiKhoan IdtaiKhoanNavigation { get; set; }
        public virtual ICollection<BenhAn> BenhAn { get; set; }
        public virtual ICollection<ChiTietVatTu> ChiTietVatTu { get; set; }
        public virtual ICollection<LichMo> LichMo { get; set; }
        public virtual ICollection<LichTruc> LichTruc { get; set; }
        public static NhanVien GetIdNV(int id)
        {
            WebBenhVienPTContext context = new WebBenhVienPTContext();
            return context.NhanVien.FirstOrDefault(b => b.IdtaiKhoan == id);
        }
    }
}
