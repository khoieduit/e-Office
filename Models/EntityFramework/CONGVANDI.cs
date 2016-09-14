namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONGVANDI")]
    public partial class CONGVANDI
    {
        [Key]
        [StringLength(50)]
        public string ID_CongVanDi { get; set; }

        public int? SoVanBan { get; set; }

        [StringLength(50)]
        public string MaLoai { get; set; }

        [StringLength(50)]
        public string SoKyHieu { get; set; }

        [StringLength(50)]
        public string MaDonViNgoai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThangVanBan { get; set; }

        [StringLength(50)]
        public string NguoiKyVanBan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBanHanh { get; set; }

        [StringLength(50)]
        public string LinkNoiDung { get; set; }

        [Column(TypeName = "ntext")]
        public string TrichYeu { get; set; }

        public int? SoTrang { get; set; }

        public int? SoBan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTrinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDuyet { get; set; }

        [StringLength(50)]
        public string MaTinhTrang { get; set; }

        public bool? Web { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STT { get; set; }
    }
}
