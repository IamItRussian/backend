using LevelsLogic.Interfaces;
using LevelsLogic.Logic;
using LevelsLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Russian.Controllers
{
    public class LevelController : Controller
    {
        private ILevelLogic _levelLogic = new LevelLogic();

        // GET: Level

        public JsonResult Index()
        {
            return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet, Route("level/{level}/{part}")]
        public JsonResult GetTask(int level, int part)
        {
            TaskRussian task = _levelLogic.GetTaskRussian(level, part);
            if (task == null)
                return Json(new { Result = "Task not found" }, JsonRequestBehavior.AllowGet);
            else
                return Json(new { Result = task }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost, Route("level/{level}/{part}/new")]
        public JsonResult AddTask(int level, int part, string text, string ans, string description)
        {
            _levelLogic.AddTakRussian(level, part, text, ans, description);
            return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
        }
    }
}