using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BenhVienPT.Models
{
    public partial class PhongMoKt
    {
        public int Id { get; set; }
        public int? IdphongMo { get; set; }
        public string TenPhongMo { get; set; }
        public int? Idtgmo { get; set; }
        public bool? TrangThai { get; set; }
    }
}
