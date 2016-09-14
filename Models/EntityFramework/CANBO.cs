namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CANBO")]
    public partial class CANBO
    {
        [Key]
        [StringLength(50)]
        public string MaCanBo { get; set; }

        [StringLength(50)]
        public string TenCanBo { get; set; }

        [StringLength(50)]
        public string MaDonVi { get; set; }

        public decimal? SDT { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int MaQuyenHan { get; set; }

        [StringLength(50)]
        public string TaiKhoan { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STT { get; set; }
    }
}
