using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BenhVienPT.Models
{
    public partial class BenhNhan
    {
        public BenhNhan()
        {
            BenhAn = new HashSet<BenhAn>();
        }

        public int Id { get; set; }
        public string MaBn { get; set; }
        public string TenBn { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Sdt { get; set; }

        public virtual ICollection<BenhAn> BenhAn { get; set; }
    }
}
