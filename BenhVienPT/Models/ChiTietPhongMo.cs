using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BenhVienPT.Models
{
    public partial class ChiTietPhongMo
    {
        public int Id { get; set; }
        public int? Idpm { get; set; }
        public int? Idtgm { get; set; }
        public bool? TrangThai { get; set; }
        public DateTime? Ngay { get; set; }

        public virtual PhongMo IdpmNavigation { get; set; }
        public virtual Tgmo IdtgmNavigation { get; set; }
    }
}
