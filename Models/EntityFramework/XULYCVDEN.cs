namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("XULYCVDEN")]
    public partial class XULYCVDEN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_XuLy { get; set; }

        [StringLength(50)]
        public string ID_CongVanDen { get; set; }

        public bool? ChuyenPhanCong { get; set; }

        [StringLength(50)]
        [Display(Name="Cán bộ nhận phân công")]
        public string MaCanBoNhanPhanCong { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung phân công")]
        public string NoiDungPhanCong { get; set; }

        [StringLength(50)]
        public string MaDonViXuLy { get; set; }

        [StringLength(50)]
        public string MaCanBoXuLy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiHanXuLy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayPhanCong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayPhanCongCBXuLy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayPhanCongDVXuLy { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDungCBXuLy { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDungDVXuLy { get; set; }

        [StringLength(50)]
        public string MaTinhTrang { get; set; }

        [StringLength(50)]
        public string MaCanBoDuyet { get; set; }

        public string NoiDungBaoCaoPHT { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBaoCaoPHT { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }

        [StringLength(50)]
        [Display(Name="Ghi chú")]
        public string GhiChuPhanCong { get; set; }

        [StringLength(50)]
        public string MaCBChuyenPhanCongDVXL { get; set; }

        [StringLength(50)]
        public string MaCBChuyenPhanCongCBXL { get; set; }

        [StringLength(50)]
        public string MaCBChuyenPhanCong { get; set; }

        [StringLength(4)]
        public string NamDen { get; set; }

        public string NoiDungBaoCaoDV { get; set; }

        public string NoiDungBaoCaoCB { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBaoCaoDV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBaoCaoCB { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? ThoiHanXuLyCB { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ThoiHanXuLyDV { get; set; }
    }
}
