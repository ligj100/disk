using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using disk.web.Models.Common;
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
            IList<MenuModels> clist = new List<MenuModels>();
            clist.Add(new MenuModels() { id = 101, pId = 1, text = "所有文章", file = Url.Action("Manage", "ArticlePost") });
            clist.Add(new MenuModels() { id = 102, pId = 1, text = "写文章", file = Url.Action("Add", "ArticlePost") });
            clist.Add(new MenuModels() { id = 102, pId = 1, text = "分类目录", file = Url.Action("Index", "Category") });

            IList<MenuModels> list = new List<MenuModels>();
            list.Add(new MenuModels() { id = 1, pId = 0, text = "文章", open = true, children = clist});

            var json = new JsonResult();
            json.Data = list;
            return json;
            
        }
    }

    
}