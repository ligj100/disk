using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using disk.Core.Caching;
using disk.Core.Domain.Members;
using disk.Services.Members;
using disk.web.Models.Members;

namespace disk.web.Controllers.Members
{
    public class RoleController : Controller
    {
         private readonly IRoleService _roleService;
        private readonly ICacheManager _cacheManager;

        public RoleController(IRoleService roleService, ICacheManager cacheManager)
        {
            _roleService = roleService;
            _cacheManager = cacheManager;
        }

        //
        // GET: /Role/
        public ActionResult Index()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(RoleModels model)
        {
            if (ModelState.IsValid)
            {
                /*
                var user = new ApplicationUser() { UserName = model.UserName };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddErrors(result);
                }*/
                var m = new Role() { Name = model.Name,Desc = model.Desc};
                _roleService.Insert(m);
                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
	}
}