using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BenhVienPT.Models
{
    public partial class VatTuYte
    {
        public VatTuYte()
        {
            ChiTietVatTu = new HashSet<ChiTietVatTu>();
        }

        public int Id { get; set; }
        public string MaVt { get; set; }
        public string TenVt { get; set; }
        public bool? TrangThai { get; set; }

        public virtual ICollection<ChiTietVatTu> ChiTietVatTu { get; set; }
    }
}
