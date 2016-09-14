namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LICH")]
    public partial class LICH
    {
        [Key]
        [StringLength(50)]
        public string ID_Lich { get; set; }

        [StringLength(50)]
        public string ID_DonViDangKy { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDungDangKy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDangKy { get; set; }

        public bool? HieuTruongDuyet { get; set; }

        public bool? YeuCauSua { get; set; }

        public bool? VanThuBanHanh { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STT { get; set; }
    }
}
