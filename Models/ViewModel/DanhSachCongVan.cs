namespace Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Mvc;
    [Table("CONGVANDEN")]
    public partial class DanhSachCongVan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int STT { get; set; }

        [StringLength(50)]
        [Display(Name = "Số công văn đến")]
        [Required(ErrorMessage = "Vui lòng nhập số công văn đến !")]
        public string ID_CongVanDen { get; set; }

        [Display(Name = "Số ký hiệu")]
        [Required(ErrorMessage = "Vui lòng nhập số ký hiệu !")]
        public string SoVanBan { get; set; }

        [StringLength(50)]
        [Display(Name = "Loại văn bản")]
        public string MaLoai { get; set; }

        [StringLength(50)]
        [Display(Name = "Nơi gởi")]
        [Required(ErrorMessage = "Vui lòng nhập nơi gởi !")]
        public string DonViNgoai { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày, tháng của văn bản")]
        [Required(ErrorMessage = "Vui lòng chọn ngày tháng văn bản !")]
        public DateTime? NgayThangVanban { get; set; }

        [StringLength(50)]
        [Display(Name = "Người ký văn bản")]
        [Required(ErrorMessage = "Vui lòng nhập người ký văn bản !")]
        public string NguoiKyVanBan { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày tháng đến")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Vui lòng chọn ngày tháng văn bản đến !")]
        public DateTime? NgayDen { get; set; }

        [StringLength(50)]
        [Display(Name = "File đính kèm")]
        [Required(ErrorMessage = "Vui lòng chọn file đính kèm !")]
        public string LinknoiDung { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Trích yếu")]
        [Required(ErrorMessage = "Vui lòng nhập nội dung trích yếu !")]
        public string TrichYeu { get; set; }

        [Display(Name = "Số trang")]
        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập số !")]
        [Required(ErrorMessage = "Vui lòng nhập số trang !")]
        public int? SoTrang { get; set; }

        [Display(Name = "Số bản")]
        [Range(0, int.MaxValue, ErrorMessage = "Vui lòng nhập số !")]
        [Required(ErrorMessage = "Vui lòng nhập số bản !")]
        public int? SoBan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTrinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDuyet { get; set; }

        [StringLength(50)]
        public string NguoiNhan { get; set; }

        [StringLength(50)]
        public string MaTinhTrang { get; set; }

        public bool? Web { get; set; }

        [StringLength(50)]
        public string MaCanBo { get; set; }

        [Column(TypeName = "ntext")]
        public string GhiChu { get; set; }
        
        [StringLength(50)]
        public string TenLoai { get; set; }

        public bool? Trinh { get; set; }

        public bool? PheDuyet { get; set; }
    }
}
