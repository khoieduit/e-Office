using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class CongVanDenViewModel
    {
        public string SoVanBan { get; set; }
        public string MaLoai { get; set; }
        public string DonViNgoai { get; set; }
        public DateTime? NgayThangVanban { get; set; }
        public string NguoiKyVanBan { get; set; }
        public DateTime? NgayDen { get; set; }
        public string LinknoiDung { get; set; }
        public string TrichYeu { get; set; }
        public int? SoTrang { get; set; }
        public int? SoBan { get; set; }
        public DateTime? NgayTrinh { get; set; }
        public string GhiChu { get; set; }
        public string NoiDungPhanCong { get; set; }
        public string MaCanBoNhanPhanCong { get; set; }
        public string NguoiNhan { get; set; }
        public string NoiDungBaoCao { get; set; }
        public bool? Trinh { get; set; }
        public bool? PheDuyet { get; set; }
    }
}
