using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using disk.Core.Caching;
using disk.Core.Domain.Catalogs;
using disk.Core.Log;
using disk.Services.Articles;
using disk.Services.Catalogs;
using disk.web.Models.Article;

namespace disk.web.Controllers.Article
{
    public class CategoryController : Controller
    {
        private static readonly IDiskLogger logger = DiskLogProvider.LogInstance.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IArticleCategoryService _articleCategoryService;
        private readonly ICacheManager _cacheManager;

        public CategoryController(IArticleCategoryService articleCategoryService, ICacheManager cacheManager)
        {
            _articleCategoryService = articleCategoryService;
            _cacheManager = cacheManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Title = "添加分类";
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CategoryModels model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var m = new ArticleCategory
                    {  
                        Name = model.Name,
                        Description = model.Description, 
                        DisplayOrder = model.DisplayOrder, 
                        IncludeInTopMenu = model.IncludeInTopMenu, 
                        ParentCategoryId = model.ParentCategoryId??0, 
                        Published = model.Published, 
                        ShowOnHomePage = model.ShowOnHomePage,
                        MetaDescription = model.MetaDescription, 
                        MetaKeywords = model.MetaKeywords,
                        MetaTitle = model.MetaTitle, 
                        CreatedOnUtc = DateTime.Now, 
                        UpdatedOnUtc = DateTime.Now 
                    };
                    _articleCategoryService.Add(m);
                    if (m.Id > 0)
                    {
                        return View("Add", model);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }

                //return RedirectToAction("Index", "Home");

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult JsonTree()
        {
            //_articleCategoryService
            JsonResult jr = new JsonResult();
            IList<CategoryTree> list = new List<CategoryTree>();
            list.Add(new CategoryTree(){id=1, text = "文章分类 "});
            list.Add(new CategoryTree(){id = 2, text = "图片分类"});
            jr.Data = list;
            return jr;
        }
    }

    public class CategoryTree
    {
        public CategoryTree()
        {
            children = new List<CategoryTree>();
        }

        public int id { get; set; }
        public string text { get; set; }

        public IList<CategoryTree> children { get; set; }
    }
}