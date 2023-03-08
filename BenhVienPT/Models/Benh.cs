using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BenhVienPT.Models
{
    public partial class Benh
    {
        public Benh()
        {
            ChiTietBenhAn = new HashSet<ChiTietBenhAn>();
            ChiTietPhongBenh = new HashSet<ChiTietPhongBenh>();
        }

        public int Id { get; set; }
        public string MaBenh { get; set; }
        public string TenBenh { get; set; }
        public int? MucDo { get; set; }

        public virtual ICollection<ChiTietBenhAn> ChiTietBenhAn { get; set; }
        public virtual ICollection<ChiTietPhongBenh> ChiTietPhongBenh { get; set; }
    }
}
