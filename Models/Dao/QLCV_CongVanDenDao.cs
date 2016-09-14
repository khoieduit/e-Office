using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Models.ViewModel;
namespace Models.Dao
{
    public class QLCV_CongVanDenDao
    {
        QuanLyCongVanDbContext _db;
        public QLCV_CongVanDenDao(QuanLyCongVanDbContext db)
        {
            _db = db;
        }
        // insert
        public int Insert(CONGVANDEN entity,string macb)//, FormCollection col
        {
            var vanthu = _db.CANBOes.Where(x => x.MaCanBo == macb).First();
            entity.NguoiNhan = vanthu.TenCanBo;
            entity.PheDuyet = false;
            entity.Trinh = false;
            _db.CONGVANDENs.Add(entity);
            _db.SaveChanges();
            return entity.STT;
        }

        public List<LOAIVANBAN> DanhSachLoaiVanBan()
        {
            return _db.LOAIVANBANs.ToList();
        }
        //danh sách phó hiệu trưởng
        public static List<CANBO> DanhSachCanBo(int quyenhan)
        {
            QuanLyCongVanDbContext _db = new QuanLyCongVanDbContext();
            return _db.CANBOes.Where(x => x.MaQuyenHan == quyenhan).ToList();
        }
        // end danh sách phó hiệu trưởng
        //danh sách công văn đến
        public List<DanhSachCongVan> DanhSachCongVanDen()
        {
            var cate = from a in _db.CONGVANDENs
                       join b in _db.LOAIVANBANs on a.MaLoai equals b.MaLoai
                       select new DanhSachCongVan()
                       {
                          ID_CongVanDen=a.ID_CongVanDen,
                          DonViNgoai=a.DonViNgoai,
                          NgayThangVanban=a.NgayThangVanban,
                          NguoiKyVanBan=a.NguoiKyVanBan,
                          NgayDen=a.NgayDen,
                          LinknoiDung=a.LinknoiDung,
                          TrichYeu=a.TrichYeu,
                          SoTrang=a.SoTrang,
                          SoBan=a.SoBan,
                          NgayTrinh=a.NgayTrinh,
                          NgayDuyet=a.NgayDuyet,
                          TenLoai=b.TenLoai,
                          NguoiNhan=a.NguoiNhan,
                          SoVanBan=a.SoVanBan,
                          PheDuyet=a.PheDuyet,
                          STT=a.STT,
                          
                       };
            return cate.ToList();
        }
        //end danh sách công văn đến

        //văn thử gởi công văn đến hiệu trưởng
        public bool ChuyenCongVan(XULYCVDEN entity, int id)
        {
            var update = _db.CONGVANDENs.Find(id);
            string id_CongVanDen = update.ID_CongVanDen;
            update.NgayTrinh = DateTime.Now;
            update.Trinh = true;
            string namden=update.NgayDen.Value.Year.ToString();
            _db.SaveChanges();
            entity.ID_CongVanDen = id_CongVanDen;
            entity.NamDen = namden;
            _db.XULYCVDENs.Add(entity);
            _db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var delete = _db.CONGVANDENs.Find(id);
            _db.CONGVANDENs.Remove(delete);
            _db.SaveChanges();
            return true;
        }
        //end văn thử gởi công văn đến hiệu trưởng

        // sửa công văn đến
        public bool SuaCongVanDen(CONGVANDEN entity, int id)
        {
            var edit = _db.CONGVANDENs.Find(id);
            edit.DonViNgoai = entity.DonViNgoai;
            edit.SoVanBan = entity.SoVanBan;
            edit.MaLoai = entity.MaLoai;
            edit.NgayThangVanban = entity.NgayThangVanban;
            edit.NgayTrinh = null;
            edit.NguoiKyVanBan = entity.NguoiKyVanBan;
            edit.TrichYeu = entity.TrichYeu;
            edit.SoTrang = entity.SoTrang;
            edit.SoBan = entity.SoBan;
            edit.LinknoiDung = entity.LinknoiDung;
            edit.NgayDen = entity.NgayDen;
            edit.GhiChu = entity.GhiChu;
            _db.SaveChanges();
            return true;
        }

        public CONGVANDEN DetailEdit(int id)
        {
            return _db.CONGVANDENs.Find(id);
        }
        //end sửa công văn đến

        // hiệu truwongr chuyển phân công công văn đến
        public int ChuyenPhanCong(XULYCVDEN entity,FormCollection fr,string macb)
        {
            QuanLyCongVanDbContext dbCVD = new QuanLyCongVanDbContext();
            int id = Convert.ToInt32(fr["id_cvden"]);
            var detailCongVanDen = dbCVD.CONGVANDENs.Find(id);
            string NamDen=detailCongVanDen.NgayDen.Value.Year.ToString();
            string ID_CongVanDen=detailCongVanDen.ID_CongVanDen;
            dbCVD.Dispose();
            var updateXuLyCongVanDen = _db.XULYCVDENs.Where(x => x.ID_CongVanDen == ID_CongVanDen && x.NamDen == NamDen).First();
            if(updateXuLyCongVanDen== null)
            {
                return 1;
            }
            else
            {
                updateXuLyCongVanDen.ChuyenPhanCong = true;
                updateXuLyCongVanDen.MaCanBoNhanPhanCong = fr["CBnhanphancong"];
                updateXuLyCongVanDen.NoiDungPhanCong = fr["noidung"];
                updateXuLyCongVanDen.NgayPhanCong = DateTime.Now;
                _db.SaveChanges();
                QuanLyCongVanDbContext db = new QuanLyCongVanDbContext();
                var update = db.CONGVANDENs.Where(x => x.ID_CongVanDen == fr["id_cvden"]).First();
                update.PheDuyet = true;
                db.SaveChanges();
                db.Dispose();
                return entity.ID_XuLy;
            }
        }
        // hiệu truwongr chuyển phân công công văn đến
        // kiểm tra công văn đã chuyển phân công hay chưa
        //public bool kiemtra(string id_congvanden)
        //{
        //    var count = _db.XULYCVDENs.Where(x => x.ID_CongVanDen == id_congvanden).Count();
        //    if (count > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        // end kiểm tra công văn đã chuyển phân công hay chưa
        //public static bool checkCV(string id_congvanden)
        //{
        //    QuanLyCongVanDbContext _db = new QuanLyCongVanDbContext();
        //    var count = _db.XULYCVDENs.Where(x => x.ID_CongVanDen == id_congvanden).Count();
        //    if (count > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        // kiểm tra công văn đã chuyển phân công hay chưa trang view của hiểu trưởng

        // end kiểm tra công văn đã chuyển phân công hay chưa trang view của hiểu trưởng

        // hiệu trưởng phân công cho đơn vị
        public int PhanDonViXuLy(XULYCVDEN entity, FormCollection fr, string macb,int maquyenhan)
        {
            QuanLyCongVanDbContext dbCVD = new QuanLyCongVanDbContext();
            int id = Convert.ToInt32(fr["id_cvden"]);
            var detailCongVanDen = dbCVD.CONGVANDENs.Find(id);
            string NamDen = detailCongVanDen.NgayDen.Value.Year.ToString();
            string ID_CongVanDen = detailCongVanDen.ID_CongVanDen;
            dbCVD.Dispose();
            var updateXuLyCongVanDen = _db.XULYCVDENs.Where(x => x.ID_CongVanDen == ID_CongVanDen && x.NamDen == NamDen).First();
            if (updateXuLyCongVanDen == null)
            {
                return 1;
            }
            else
            {
                DateTime ThoiHanDVXuLy = Convert.ToDateTime(fr["thoigianxuly"]);
                updateXuLyCongVanDen.ChuyenPhanCong = false;
                updateXuLyCongVanDen.MaDonViXuLy = fr["DVnhanphancong"];
                updateXuLyCongVanDen.NoiDungDVXuLy = fr["noidung"];
                updateXuLyCongVanDen.NgayPhanCongDVXuLy = DateTime.Now;
                updateXuLyCongVanDen.ThoiHanXuLyDV = ThoiHanDVXuLy;
                updateXuLyCongVanDen.MaCBChuyenPhanCongDVXL = macb;
                _db.SaveChanges();
                QuanLyCongVanDbContext db = new QuanLyCongVanDbContext();
                var update = db.CONGVANDENs.Where(x => x.STT == id).First();
                update.PheDuyet = true;
                db.SaveChanges();
                db.Dispose();
                return entity.ID_XuLy;
            }
        }
        // end hiệu trưởng phân công cho đơn vị
        //danh sách công văn hiệu trưởng đã phân công cho phó hiệu trưởng
        public List<CongVanDenViewModel> DanhSachCongVanDaPhanCong()
        {
            var DanhSachPhanCong = from a in _db.CONGVANDENs
                                   join b in _db.XULYCVDENs on a.ID_CongVanDen equals b.ID_CongVanDen
                                   where b.ChuyenPhanCong == true
                                   select new CongVanDenViewModel()
                                   {
                                       SoVanBan = a.SoVanBan,
                                       MaLoai = a.MaLoai,
                                       DonViNgoai = a.DonViNgoai,
                                       NgayThangVanban = a.NgayThangVanban,
                                       NguoiKyVanBan = a.NguoiKyVanBan,
                                       NgayDen = a.NgayDen,
                                       LinknoiDung = a.LinknoiDung,
                                       TrichYeu = a.TrichYeu,
                                       SoTrang = a.SoTrang,
                                       SoBan = a.SoBan,
                                       NgayTrinh = a.NgayTrinh,
                                       GhiChu = a.GhiChu,
                                       NoiDungPhanCong = b.NoiDungPhanCong,
                                       MaCanBoNhanPhanCong=b.MaCanBoNhanPhanCong,
                                       NguoiNhan=a.NguoiNhan,
                                       NoiDungBaoCao=b.NoiDungBaoCaoPHT,
                                   };
            return DanhSachPhanCong.ToList();
        }
        //end danh sách công văn hiệu trưởng đã phân công cho phó hiệu trưởng
        //end hiệu trưởng chuyển phan công công văn đến
        
        //kiểm tra công văn đã phê duyệt hay chưa
        public static bool checkpheduyet(string ID_CongVanDen, string NamDen)
        {
            QuanLyCongVanDbContext _db = new QuanLyCongVanDbContext();
            var count = _db.XULYCVDENs.SingleOrDefault(x => x.ID_CongVanDen == ID_CongVanDen && x.NamDen == NamDen);
            if (count.ID_CongVanDen != null)
            {
                if (count.ChuyenPhanCong == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //end kiểm tra công văn đã phê duyệt hay chưa

        //lấy tên cán bộ trong chuyển phân công
        public static CANBO TenCanBo(string id)
        {
            if (id == "" || id == null)
            {
                return null;
            }
            else
            {
                QuanLyCongVanDbContext _db = new QuanLyCongVanDbContext();
                var result = _db.CANBOes.Find(id);
                return result;
            }
        }
        public static string TenLoaiVanBan(string id)
        {
            QuanLyCongVanDbContext _db = new QuanLyCongVanDbContext();
            var result = _db.LOAIVANBANs.Find(id);
            return result.TenLoai;
        }
        //end lấy tên cán bộ trong chuyển phân công

        //DANH SÁCH CÔNG VĂN PHÂN CÔNG ĐƠN VỊ XỬ LÝ
        public List<CongVanDenViewModel> DanhSachCongVanDaPhanCongDVXL(string MACB)
        {
            var DanhSachPhanCong = from a in _db.CONGVANDENs
                                   join b in _db.XULYCVDENs on a.ID_CongVanDen equals b.ID_CongVanDen
                                   where b.ChuyenPhanCong == false && b.MaCBChuyenPhanCongDVXL==MACB
                                   select new CongVanDenViewModel()
                                   {
                                       SoVanBan = a.SoVanBan,
                                       MaLoai = a.MaLoai,
                                       DonViNgoai = a.DonViNgoai,
                                       NgayThangVanban = a.NgayThangVanban,
                                       NguoiKyVanBan = a.NguoiKyVanBan,
                                       NgayDen = a.NgayDen,
                                       LinknoiDung = a.LinknoiDung,
                                       TrichYeu = a.TrichYeu,
                                       SoTrang = a.SoTrang,
                                       SoBan = a.SoBan,
                                       NgayTrinh = a.NgayTrinh,
                                       GhiChu = a.GhiChu,
                                       NoiDungPhanCong = b.NoiDungPhanCong,
                                       MaCanBoNhanPhanCong = b.MaCanBoNhanPhanCong,
                                       NguoiNhan = a.NguoiNhan,
                                       NoiDungBaoCao = b.NoiDungBaoCaoDV,
                                   };
            return DanhSachPhanCong.ToList();
        }
        //END DANH SÁCH CÔNG VĂN PHÂN CÔNG ĐƠN VỊ XỬ LÝ

        // danh sách đơn vị
        public static DONVI TenDonVi(string MADV)
        {
            QuanLyCongVanDbContext _db = new QuanLyCongVanDbContext();
            var result = _db.DONVIs.Find(MADV);
            return result;
        }
        // end danh sách đơn vị

        // danh sách các công văn đã xử lý
        public static XULYCVDEN DanhSachXuLyCV(string id_cv, string namden)
        {
            QuanLyCongVanDbContext _db = new QuanLyCongVanDbContext();
            var result= _db.XULYCVDENs.Where(x=>x.ID_CongVanDen==id_cv && x.NamDen==namden).First();
            return result;
        }

        //end danh sách công văn đã xử lý

        //lấy mã cán bộ tìm theo mã đơn vị
        public static string MaDV(string madv)
        {
            QuanLyCongVanDbContext _db = new QuanLyCongVanDbContext();
            var result = _db.CANBOes.Where(x => x.MaDonVi == madv && x.MaQuyenHan == 4).First();
            return result.MaCanBo;
        }
        //end lấy mã cán bộ tìm theo mã đơn vị

        //kiểm tra công văn đã đc phê duyệt hay chưa

        public static bool kiemtrapheduyet(int stt)
        {
            QuanLyCongVanDbContext _db = new QuanLyCongVanDbContext();
            var count = _db.CONGVANDENs.Find(stt);
            if (count != null)
            {
                if (count.PheDuyet == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //
    }
}
