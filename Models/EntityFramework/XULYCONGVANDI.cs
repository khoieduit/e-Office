namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XULYCONGVANDI")]
    public partial class XULYCONGVANDI
    {
        [Key]
        [StringLength(50)]
        public string MaDuThao { get; set; }

        [StringLength(50)]
        public string ID_CongVanDi { get; set; }

        [StringLength(50)]
        public string MaDonVi { get; set; }

        [StringLength(50)]
        public string MaCanBo { get; set; }

        public bool? GoiDonVi { get; set; }

        public bool? DonViDuyet { get; set; }

        public bool? GoiVanThu { get; set; }

        public bool? VanThuDuyet { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBanHanhDuThao { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        [StringLength(50)]
        public string MaTinhTrang { get; set; }

        public bool? ChuyenDuyet { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDungChuyenDuyet { get; set; }

        [StringLength(50)]
        public string MaCanBoChuyenDuyet { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDungBaoCao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBaoCao { get; set; }

        public bool? DongYBanHanhDuThao { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STT { get; set; }
    }
}
