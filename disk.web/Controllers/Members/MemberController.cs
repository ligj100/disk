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
using disk.Web.Controllers;

namespace disk.web.Controllers.Members
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly ICacheManager _cacheManager;

        public MemberController(IMemberService memberService,ICacheManager cacheManager)
        {
            _memberService = memberService;
            _cacheManager = cacheManager;
        }

        //
        // GET: /Member/
        public ActionResult Index()
        {
            /*
            //InstallController install = new InstallController();
            //install.Index();
            Member m = new Member()
            {
                Name = "aaa"
                
            };
            _memberService.InsertMember(m);
             * */
            return View();
        }

         //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(MemberModels model)
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
                var m = new Member(){Name = model.Name};
                _memberService.InsertMember(m);
                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}