using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using disk.Core;
using disk.Core.Caching;
using disk.Core.Domain.Articles;
using disk.Core.Log;
using disk.Services.Articles;
using disk.web.Models.Article;
using disk.web.Models.Common;

namespace disk.web.Controllers.Article
{
    public class ArticlePostController : Controller
    {
        #region Fields
        private static readonly IDiskLogger logger = DiskLogProvider.LogInstance.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IArticlePostService _articlePostService;
        private readonly ICacheManager _cacheManager;
        #endregion

        #region Ctor
        public ArticlePostController(IArticlePostService articlePostService, ICacheManager cacheManager)
        {
            _articlePostService = articlePostService;
            _cacheManager = cacheManager;
        }
        #endregion

        #region Method
        [GenerateStaticFileAttribute]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Manage()
        {
            return View();
        }

        public JsonResult PageData()
        {
            int pageIndex = 0;
            int rows = 15;
            string pageStr = HttpContext.Request.Form["page"];
            string rowsstr = HttpContext.Request.Form["rows"];
            int.TryParse(pageStr, out pageIndex);
            int.TryParse(rowsstr, out rows);
            if (pageIndex < 0) pageIndex = 0;
            else pageIndex--;
            if (rows < 1) rows = 15;
            IPagedList<ArticlePost> list = _articlePostService.GetPagedList(pageIndex, rows);
            JsonResult jr = new JsonResult();
            PageJsonModels<ArticlePost> page = new PageJsonModels<ArticlePost>();
            page.total = list.TotalCount;
            page.rows = list;
            jr.Data = page;
            return jr;
        }

        public ActionResult List(ArticlePagingFilteringModel command)
        {
            //List
            var model = PrepareArticlePostListModel(command);
            return View("List", model);
        }

        public ActionResult Add()
        {
            ViewBag.Title = "添加文件";
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ArticlePostModels model)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    var m = new ArticlePost()
                    {
                        Title = model.Title, 
                        Body = model.Body, 
                        AllowComments = true, 
                        CreatedOnUtc = DateTime.Now, 
                        MetaDescription = model.MetaDescription, 
                        MetaKeywords = model.MetaKeywords, 
                        MetaTitle = model.MetaTitle,
                        CommentCount =  0, 
                        Intro = model.Intro, 
                        Tags = model.Tags
                    };
                    _articlePostService.Add(m);
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

        public ActionResult Show(int id)
        {
            ArticlePost ap = _articlePostService.GetById(id);
            if (ap == null) return Redirect("Index");

            var model = new ArticlePostModels();
            PrepareArticlePostModel(model,ap,true);
            ViewBag.Title = model.Title;
            ViewBag.Keywords = model.MetaKeywords;
            ViewBag.Description = model.MetaDescription;
            return View(model);
        }

        [HttpPost]
        public JsonResult Delete()
        {
            JsonResult jr = new JsonResult();
            string IdStr = HttpContext.Request.Form["Id"];
            if (string.IsNullOrEmpty(IdStr))
            {
                jr.Data = " {status = -1, msg = \"111\"}";
                return jr;
            }
            int id = 0;
            int.TryParse(IdStr, out id);
            if (id <= 0)
            {
                jr.Data = " {status = -1, msg = \"111\"}";
                return jr;
            }

            
            try
            {
                var model = _articlePostService.GetById(id);
                _articlePostService.Delete(model);
                jr.Data = " {status = 0, msg = \"111\"}";
                return jr;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                jr.Data = " {status = 0, msg = \""+ex.Message+"\"}";
                return jr;
            }
            
        }

        #endregion

        #region Utilities
        [NonAction]
        protected virtual void PrepareArticlePostModel(ArticlePostModels model, ArticlePost articlePost, bool prepareComments)
        {
            if(articlePost == null) throw new ArgumentNullException("articlePost");
            if(model == null) throw new ArgumentNullException("model");
            model.Id = articlePost.Id;
            model.Title = articlePost.Title;
            model.Body = articlePost.Body;
            model.MetaDescription = articlePost.MetaDescription;
            model.CreatedOnUtc = articlePost.CreatedOnUtc;
            model.MetaKeywords = articlePost.MetaKeywords;
            model.MetaTitle = articlePost.MetaTitle;
            model.Tags = articlePost.Tags;
            if (prepareComments)
            {
                var articleComments = articlePost.ArticleComments.OrderBy(pr => pr.CreatedOnUtc);
                foreach (var ac in articleComments)
                {
                    var commentModel = new ArticleCommentModels
                    {
                        Id = ac.Id,
                        MemberId = ac.MemberId,
                        MemberName = ac.Member.UName,
                        CommentText = ac.CommentText,
                        CreatedOnUtc = ac.CreatedOnUtc
                    };
                    model.Comments.Add(commentModel);
                }
            }
        }

        protected virtual ArticlePostListModels PrepareArticlePostListModel(ArticlePagingFilteringModel command)
        {
            if(command == null) throw new ArgumentNullException("command");

            var model = new ArticlePostListModels();
            if (command.PageSize <= 0) command.PageSize = 15;
            if (command.PageNumber <= 0) command.PageNumber = 1;

            IPagedList<ArticlePost> articlePosts;
            articlePosts = _articlePostService.GetPagedList(command.PageIndex, command.PageSize);
            model.PagingFilteringContext.LoadPagedList(articlePosts);

            
            model.ArticlePosts = articlePosts.Select(x =>
            {
                var articlePostModels = new ArticlePostModels();
                PrepareArticlePostModel(articlePostModels,x,false);
                return articlePostModels;
            }).ToList();

            return model;
        }

        #endregion
    }
}