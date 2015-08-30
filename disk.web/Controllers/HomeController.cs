using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace disk.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult LoadMenu()
        {
            var zNodes = "[" +
                         "{id:1, pId:0, name:\"[core] 基本功能 演示\", open:true}," +
                         "{ id: 101, pId: 1, name: \"最简单的树1\", file: \"/Home/About\" }," +
                         "{id:102, pId:1, name:\"最简单的树2\", file:\"http://www.163.com\"}]";
            var json = new JsonResult();
            json.Data = zNodes;
            return json;
        }
    }
}