namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QUYENHAN")]
    public partial class QUYENHAN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaQuyenHan { get; set; }

        [StringLength(50)]
        public string TenQuyenHan { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }

    }
}
