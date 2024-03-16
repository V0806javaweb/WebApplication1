using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    [Authorize]//所有ActionResult都要登入驗證
    public class AccountController : Controller
    {
        // GET: Account/Login
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]//此ActionResult不用登入驗證
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [AllowAnonymous, ChildActionOnly]//只能作為子系動作呼叫
        public ActionResult ForPartialView()
        {
            return PartialView();
        }

        [RequireHttps]//限制僅能以https通訊協定連線
        public ActionResult SecretPage()
        {
            return View();
        }

        [ValidateInput(false)]//取消asp.net預設的表單資料驗證
        public ActionResult Edit(FormCollection form)
        {

            return View();
        }
    }
}