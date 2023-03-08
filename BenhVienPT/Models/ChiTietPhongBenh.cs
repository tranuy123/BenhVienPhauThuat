using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BenhVienPT.Models
{
    public partial class ChiTietPhongBenh
    {
        public int Id { get; set; }
        public string MaCtb { get; set; }
        public int? Idb { get; set; }
        public int? Idpm { get; set; }

        public virtual Benh IdbNavigation { get; set; }
        public virtual PhongMo IdpmNavigation { get; set; }
    }
}
