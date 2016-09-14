using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eoffice.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public String Index(FormCollection fr)
        {
            string name = Convert.ToString(fr["name"]);
            return name;
        }
	}
}