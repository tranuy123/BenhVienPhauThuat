using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BenhVienPT.Models
{
    public partial class Tgmo
    {
        public Tgmo()
        {
            ChiTietPhongMo = new HashSet<ChiTietPhongMo>();
            LichTruc = new HashSet<LichTruc>();
        }

        public int Id { get; set; }
        public string MaTgmo { get; set; }
        public string TenTgmo { get; set; }
        public TimeSpan? TgbatDau { get; set; }
        public TimeSpan? TgketThuc { get; set; }

        public virtual ICollection<ChiTietPhongMo> ChiTietPhongMo { get; set; }
        public virtual ICollection<LichTruc> LichTruc { get; set; }
    }
}
