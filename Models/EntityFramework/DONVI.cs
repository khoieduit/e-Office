namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONVI")]
    public partial class DONVI
    {
        [Key]
        [StringLength(50)]
        public string MaDonVi { get; set; }

        [StringLength(50)]
        public string TenDonVi { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STT { get; set; }
    }
}
