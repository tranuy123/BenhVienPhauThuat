using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BenhVienPT.Models
{
    public partial class LichMo
    {
        public int Id { get; set; }
        public string MaLm { get; set; }
        public int? Idnv { get; set; }
        public int? Idcm { get; set; }
        public int? CaMo { get; set; }
        public DateTime? Ngay { get; set; }

        public virtual CaMo IdcmNavigation { get; set; }
        public virtual NhanVien IdnvNavigation { get; set; }
    }
}
