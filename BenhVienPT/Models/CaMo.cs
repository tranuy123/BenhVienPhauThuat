using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BenhVienPT.Models
{
    public partial class CaMo
    {
        public CaMo()
        {
            LichMo = new HashSet<LichMo>();
        }

        public int Id { get; set; }
        public string MaCaMo { get; set; }
        public string TenCaMo { get; set; }
        public bool? TinhTrang { get; set; }
        public int? IdphongMo { get; set; }
        public int? IdbenhAn { get; set; }
        public int? IdphongHoiTinh { get; set; }

        public virtual BenhAn IdbenhAnNavigation { get; set; }
        public virtual PhongHoiTinh IdphongHoiTinhNavigation { get; set; }
        public virtual PhongMo IdphongMoNavigation { get; set; }
        public virtual ICollection<LichMo> LichMo { get; set; }
    }
}
