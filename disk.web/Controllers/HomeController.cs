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
            IList<MenuItem> list = new List<MenuItem>();
            list.Add(new MenuItem(){id=1,pId = 0,name="基本功能 演示",open=true});
            list.Add(new MenuItem() { id = 101, pId = 1, name = "最简单的树1", file = Url.Action("About", "Home") });
            list.Add(new MenuItem() { id = 102, pId = 1, name = "最简单的树2", file = Url.Action("Index", "Member") });
            var json = new JsonResult();
            json.Data = list;
            return json;
            
        }
    }

    
}