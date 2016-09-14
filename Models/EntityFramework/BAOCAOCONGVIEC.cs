namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BAOCAOCONGVIEC")]
    public partial class BAOCAOCONGVIEC
    {
        [Key]
        [StringLength(50)]
        public string ID_BaoCao { get; set; }

        [StringLength(50)]
        public string ID_CongViec { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDungBaoCao { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayBaoCao { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STT { get; set; }
    }
}
