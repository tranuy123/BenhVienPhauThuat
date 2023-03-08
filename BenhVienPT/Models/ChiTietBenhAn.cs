using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BenhVienPT.Models
{
    public partial class ChiTietBenhAn
    {
        public int Id { get; set; }
        public string MaCtba { get; set; }
        public int? Idbenh { get; set; }
        public int? IdbenhAn { get; set; }

        public virtual BenhAn IdbenhAnNavigation { get; set; }
        public virtual Benh IdbenhNavigation { get; set; }
    }
}
