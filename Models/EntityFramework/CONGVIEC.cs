namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CONGVIEC")]
    public partial class CONGVIEC
    {
        [Key]
        [StringLength(50)]
        public string ID_CongViec { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }

        public bool? TrangThaiGiaoViec { get; set; }

        public bool? TrangThaiBaoCao { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STT { get; set; }
    }
}
