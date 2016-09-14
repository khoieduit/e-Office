using Eoffice.Common;
using Models.Dao;
using Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Eoffice.Controllers
{
    public class DangNhapController : Controller
    {
        //
        QuanLyCongVanDbContext _db = new QuanLyCongVanDbContext();
        // GET: /TaiKhoan/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Eoffice.Models.DangNhapModel model)
        {
            if(ModelState.IsValid){
                var dao = new TaiKhoanDao(_db);
                var result = dao.DangNhap(model.TaiKhoan,Common.Encrypt.MD5Hash(model.MatKhau));
                var login= new CanBoLogin();
                if (result)
                {
                    var taikhoan=dao.GetById(model.TaiKhoan);
                    //login.MaCanBo=taikhoan.MaCanBo;
                    //login.TaiKhoan=taikhoan.TaiKhoan;
                    //login.QuyenHan = taikhoan.MaQuyenHan;
                    Session["MACANBO"] = taikhoan.MaCanBo;
                    Session["TAIKHOAN"] = taikhoan.TaiKhoan;
                    Session["MAQUYENHAN"] = taikhoan.MaQuyenHan;
                    //Session.Add(Common.CommonConstants.CANBO_SESSION,login);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("message", "Vui lòng kiểm tra lại tài khoản hoặc mật khẩu !");
                }
            }
            return View("Index");  
        }
	}
}