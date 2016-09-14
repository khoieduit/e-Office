namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GIAOVIEC")]
    public partial class GIAOVIEC
    {
        [StringLength(50)]
        public string ID_CongViec { get; set; }

        [Key]
        [StringLength(50)]
        public string ID_GiaoViec { get; set; }

        [StringLength(50)]
        public string ID_CanBoNhanViec { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayGiaoViec { get; set; }

        [StringLength(50)]
        public string ID_CanBoGiaoViec { get; set; }

        public bool? TrangThai { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STT { get; set; }
    }
}
