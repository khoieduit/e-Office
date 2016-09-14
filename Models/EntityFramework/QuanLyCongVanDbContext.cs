namespace Models.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyCongVanDbContext : DbContext
    {
        public QuanLyCongVanDbContext()
            : base("name=QuanLyCongVan")
        {
        }

        public virtual DbSet<BAOCAOCONGVIEC> BAOCAOCONGVIECs { get; set; }
        public virtual DbSet<CANBO> CANBOes { get; set; }
        public virtual DbSet<CONGVANDEN> CONGVANDENs { get; set; }
        public virtual DbSet<CONGVANDI> CONGVANDIs { get; set; }
        public virtual DbSet<CONGVIEC> CONGVIECs { get; set; }
        public virtual DbSet<DONVI> DONVIs { get; set; }
        public virtual DbSet<DONVINGOAI> DONVINGOAIs { get; set; }
        public virtual DbSet<GIAOVIEC> GIAOVIECs { get; set; }
        public virtual DbSet<LICH> LICHes { get; set; }
        public virtual DbSet<LOAIVANBAN> LOAIVANBANs { get; set; }
        public virtual DbSet<MEMUTYPE> MEMUTYPEs { get; set; }
        public virtual DbSet<MENU> MENUs { get; set; }
        public virtual DbSet<QUYENHAN> QUYENHANs { get; set; }
        public virtual DbSet<TINHTRANG> TINHTRANGs { get; set; }
        public virtual DbSet<TINNOIBO> TINNOIBOes { get; set; }
        public virtual DbSet<USER> USERs { get; set; }
        public virtual DbSet<XULYCONGVANDI> XULYCONGVANDIs { get; set; }
        public virtual DbSet<XULYCVDEN> XULYCVDENs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CANBO>()
                .Property(e => e.SDT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<USER>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.CreateBy)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.ModifieBy)
                .IsUnicode(false);
        }
    }
}
