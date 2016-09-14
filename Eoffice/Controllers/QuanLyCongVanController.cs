using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.EntityFramework;
using Models.Dao;
namespace Eoffice.Controllers
{
    public class QuanLyCongVanController : BaseController
    {
        //
        // GET: /QuanLyCongVan/
        QuanLyCongVanDbContext _db = new QuanLyCongVanDbContext();
        public ActionResult Index()
        {
            
            return View();
        }
        // Thêm công văn đến
        [HttpGet]
        public ActionResult QLCV_ThemCongVanDen()
        {
            DanhSachLoaiVanBan();
            return View();
        }
        //end thêm công văn đến
        [HttpPost, ValidateInput(false)]
        public ActionResult QLCV_ThemCongVanDen(CONGVANDEN data)//, FormCollection col
        
        {
            var dao = new QLCV_CongVanDenDao(_db);
            if (ModelState.IsValid)
            {
                string canbo=(string)(Session["MACANBO"]);
                var result = dao.Insert(data,canbo);
                if (result>0)
                {
                    TempData["shortMessage"] = "Thêm thành công !";
                    return RedirectToAction("QLCV_DanhSachCongVanDen", "QuanLyCongVan");
                }
                else
                {
                    ModelState.AddModelError("message","thêm thất bại !");
                }
            }
            DanhSachLoaiVanBan();
            return View("QLCV_ThemCongVanDen");
        }
        //danh sách công văn đến
        
        // văn thư xác nhận gởi công văn cho hiểu trưởng
        public ActionResult QLCV_GoiCongVan(int id,XULYCVDEN entity)
        {
            var dao = new QLCV_CongVanDenDao(_db);
            bool result =dao.ChuyenCongVan(entity, id);
            TempData["shortMessage"]="Công văn đã được gởi !";
            TempData["alert"] = "success";
            return RedirectToAction("QLCV_DanhSachCongVanDen", "QuanLyCongVan");
        }
        // end văn thư xác nhận gởi công văn cho hiểu trưởng
        
        // xoá công văn
        public ActionResult QLCV_Delete(int id)
        {
            var dao = new QLCV_CongVanDenDao(_db);
            dao.Delete(id);
            TempData["shortMessage"] = "Xoá thành công !";
            TempData["alert"] = "success";
            return RedirectToAction("QLCV_DanhSachCongVanDen", "QuanLyCongVan");
        }
        //xoá công văn

        //sửa công văn đến
        [HttpGet]
        public ActionResult QLCV_SuaCongVanDen(int id)
        {   
            var dao = new QLCV_CongVanDenDao(_db);
            var viewEdit = dao.DetailEdit(id);
            
            if (viewEdit.NgayTrinh != null)
            {
                TempData["shortMessage"]= "Công văn đã đc gởi nên không thể sửa được !";
                TempData["alert"] = "danger";
                return RedirectToAction("QLCV_DanhSachCongVanDen", "QuanLyCongVan");
                
            }
            DanhSachLoaiVanBan();
            return View(viewEdit);
        }
        [HttpPost]
        public ActionResult QLCV_SuaCongVanDen(CONGVANDEN data, int id) {
            var edit = new QLCV_CongVanDenDao(_db);
            edit.SuaCongVanDen(data, id);
            TempData["shortMessage"]="Sửa thành công !";
            TempData["alert"] = "success";
            return RedirectToAction("QLCV_DanhSachCongVanDen", "QuanLyCongVan");
        }
        //end sửa công văn đến
        //kiểm tra trùng mã số công văn đến
        [AllowAnonymous]
        [HttpPost]
        public ActionResult checkUniqueID_CongVanDen(string ID_CongVanDen)
        {
            try
            {
                var tag = _db.CONGVANDENs.Single(m => m.ID_CongVanDen == ID_CongVanDen);
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
        //end kiểm tra mã số công văn đến

        // danh sách loại văn bản
        public void DanhSachLoaiVanBan(long? selected=null)
        {
            var dao = new QLCV_CongVanDenDao(_db);
            ViewBag.MaLoai = new SelectList(dao.DanhSachLoaiVanBan(), "MaLoai", "TenLoai", selected);
        }
        //end danh sách loại văn bản

        //danh sách công văn đến
        public ActionResult QLCV_DanhSachCongVanDen()
        {
            ViewBag.Message = TempData["shortMessage"];
            ViewBag.Alert = TempData["alert"];
            var DanhSachCongVan = new QLCV_CongVanDenDao(_db);
            var Result = DanhSachCongVan.DanhSachCongVanDen();
            return View(Result);
        }
        //end danh sách công văn đến
        
        //hiệu trưởng chuyển phân công
        [HttpGet]
        public ActionResult QLCV_ChuyenPhanCong( int id)
        {
            if ((int)Session["MAQUYENHAN"] == 2)
            {
                var dao = new QLCV_CongVanDenDao(_db);
                var result = dao.DanhSachCongVanDaPhanCong();
                ViewBag.id_congvanden = id;
                return View(result);
            }
            else
            {
                TempData["shortMessage"] = "Bạn không có quyền chuyển phân công !";
                TempData["alert"] = "danger";
                return RedirectToAction("QLCV_DanhSachCongVanDen", "QuanLyCongVan");
            }
        }

        [HttpPost]
        public ActionResult QLCV_ChuyenPhanCong(XULYCVDEN data,FormCollection fr)
        {
            var dao = new QLCV_CongVanDenDao(_db);
            var chuyenphancong = dao.ChuyenPhanCong(data, fr,(string)Session["MACANBO"]);
            TempData["shortMessage"] = "Công văn đã được chuyển phân công !";
            TempData["alert"] = "danger";
            return RedirectToAction("QLCV_DanhSachCongVanDen", "QuanLyCongVan");
        }    
        //end hiệu trưởng chuyển phân công

        // phân công đơn vị xử lý
        [HttpGet]
        public ActionResult QLCV_PhanCongDonVi(int id)
        {
            if ((int)Session["MAQUYENHAN"] == 2 || (int)Session["MAQUYENHAN"]==3)
            {
                var dao = new QLCV_CongVanDenDao(_db);
                var detail = dao.DetailEdit(id);
                string ID_CongVanDen = detail.ID_CongVanDen;
                string NamDen = detail.NgayDen.Value.Year.ToString();
                var DanhSachXuLyCongVan = QLCV_CongVanDenDao.DanhSachXuLyCV(ID_CongVanDen, NamDen);
                string MaCanBo = (string)Session["MACANBO"];
                if ((int)Session["MAQUYENHAN"] == 2)
                {

                    if ( DanhSachXuLyCongVan.ChuyenPhanCong == true ||  DanhSachXuLyCongVan.MaCanBoXuLy != null )
                    {
                        if (DanhSachXuLyCongVan.ChuyenPhanCong == true)
                        {
                            TempData["shortMessage"] = "Văn bản này đã phân công cho Phó Hiệu trưởng " + QLCV_CongVanDenDao.TenCanBo(DanhSachXuLyCongVan.MaCanBoNhanPhanCong).TenCanBo+" xử lý.";
                        }
                        else
                        {
                            TempData["shortMessage"] = "Văn bản này đã phân công cho cán bộ "+ QLCV_CongVanDenDao.TenCanBo(DanhSachXuLyCongVan.MaCanBoXuLy).TenCanBo+" thực hiện.";
                        }
                        TempData["alert"] = "danger";
                        return RedirectToAction("QLCV_DanhSachCongVanDen", "QuanLyCongVan");
                    }
                    else
                    {
                        var result = dao.DanhSachCongVanDaPhanCongDVXL((string)Session["MACANBO"]);
                        ViewBag.id_congvanden = id;
                        return View(result);
                    }
                }
                else
                {
                    if (DanhSachXuLyCongVan.MaCanBoXuLy != null || DanhSachXuLyCongVan.MaCanBoXuLy!="")
                    {
                        var result = dao.DanhSachCongVanDaPhanCongDVXL((string)Session["MACANBO"]);
                        ViewBag.id_congvanden = id;
                        return View(result);
                    }
                    else
                    {
                        TempData["shortMessage"] = "Văn bản này đã phân công cho cán bộ "+QLCV_CongVanDenDao.TenCanBo(DanhSachXuLyCongVan.MaCanBoXuLy).TenCanBo+ " Thực hiện.";
                        TempData["alert"] = "danger";
                        return RedirectToAction("QLCV_DanhSachCongVanDen", "QuanLyCongVan");
                    }
                }
                
            }
            else
            {
                TempData["shortMessage"] = "Bạn không có quyền phân công !";
                TempData["alert"] = "danger";
                return RedirectToAction("QLCV_DanhSachCongVanDen", "QuanLyCongVan");
            }
            
        }
        [HttpPost]
        public ActionResult QLCV_PhanCongDonVi(XULYCVDEN entity, FormCollection fr)
        {
            if ((int)Session["MAQUYENHAN"] == 2 || (int)Session["MAQUYENHAN"] == 3)
            {
                var dao = new QLCV_CongVanDenDao(_db);
                string id = fr["id_cvden"];
                var phancongdv = dao.PhanDonViXuLy(entity, fr, (string)Session["MACANBO"], (int)Session["MAQUYENHAN"]);
                TempData["shortMessage"] = "Công văn đã được chuyển phân công !";
                TempData["alert"] = "success";
                return RedirectToAction("QLCV_DanhSachCongVanDen", "QuanLyCongVan");
            }else{
                TempData["shortMessage"] = "Bạn không có quyền phân công !";
                TempData["alert"] = "danger";
                return RedirectToAction("QLCV_DanhSachCongVanDen", "QuanLyCongVan");
            }
        }
        //end phân công đơn vị xử lý
	}
}