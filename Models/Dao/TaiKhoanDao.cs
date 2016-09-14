using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EntityFramework;
using System.Web.Mvc;
namespace Models.Dao
{
    public class TaiKhoanDao
    {
        QuanLyCongVanDbContext _db;
        public TaiKhoanDao(QuanLyCongVanDbContext db)
        {
            _db = db;
        }

        // insert
        public bool Insert(CANBO entity)
        {
            _db.CANBOes.Add(entity);
            _db.SaveChanges();
            return true;
        }
        public CANBO GetById(string taikhoan)
        {
            return _db.CANBOes.SingleOrDefault(x => x.TaiKhoan==taikhoan);
        }
        public bool DangNhap(string TaiKhoan, string MatKhau)
        {
            var result = _db.CANBOes.Count(x => x.TaiKhoan == TaiKhoan && x.MatKhau == MatKhau);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
