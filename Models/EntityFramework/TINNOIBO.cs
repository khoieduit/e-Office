namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TINNOIBO")]
    public partial class TINNOIBO
    {
        [Key]
        [StringLength(50)]
        public string ID_Tin { get; set; }

        [Column(TypeName = "ntext")]
        public string NoiDung { get; set; }

        public bool? TrangThai { get; set; }

        [StringLength(50)]
        public string NguoiDang { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDang { get; set; }

        public bool? TinhTrang { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STT { get; set; }
    }
}
