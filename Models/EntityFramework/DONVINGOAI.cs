namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DONVINGOAI")]
    public partial class DONVINGOAI
    {
        [Key]
        [StringLength(50)]
        public string MaDonViNgoai { get; set; }

        [StringLength(50)]
        public string TenDonViNgoai { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STT { get; set; }
    }
}
