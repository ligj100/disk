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
           //文章子菜单
            IList<MenuItem> clist = new List<MenuItem>();
            clist.Add(new MenuItem() { id = 101, pId = 1, text = "所有文章", file = Url.Action("List", "ArticlePost") });
            clist.Add(new MenuItem() { id = 102, pId = 1, text = "写文章", file = Url.Action("Add", "ArticlePost") });
            clist.Add(new MenuItem() { id = 102, pId = 1, text = "分类目录", file = Url.Action("Index", "Category") });

            IList<MenuItem> list = new List<MenuItem>();
            list.Add(new MenuItem() { id = 1, pId = 0, text = "文章", open = true, children = clist});

            var json = new JsonResult();
            json.Data = list;
            return json;
            
        }
    }

    
}