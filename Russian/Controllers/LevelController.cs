using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Russian.Controllers
{
    public class LevelController : Controller
    {
        // GET: Level
        public JsonResult Index()
        {
            return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
        }
    }
}