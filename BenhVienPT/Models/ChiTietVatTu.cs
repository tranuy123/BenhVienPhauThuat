using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BenhVienPT.Models
{
    public partial class ChiTietVatTu
    {
        public int Id { get; set; }
        public string MaCtvt { get; set; }
        public int? IdphongMo { get; set; }
        public int? IdvatTuYte { get; set; }
        public DateTime? Ngay { get; set; }
        public int? Idnv { get; set; }
        public int? Sl { get; set; }

        public virtual NhanVien IdnvNavigation { get; set; }
        public virtual PhongMo IdphongMoNavigation { get; set; }
        public virtual VatTuYte IdvatTuYteNavigation { get; set; }
    }
}
