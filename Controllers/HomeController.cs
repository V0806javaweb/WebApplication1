using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Filters;

namespace WebApplication1.Controllers
{
    //也能加在這裡，作用範圍更廣
    //[Authorize]
    public class HomeController : Controller
    {
        //登入才可進入Index
        //[Authorize]
        //紀錄用戶成功進入此ActionResult時間

        [CustomFilter]
        public ActionResult Index()
        {
            ViewData["TInfo"] = "首頁訊息版";
            ViewBag.Btest = "訊息版2號";
            TempData["tempM"] = "訊息版3號";
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
        //version 1
        /*public ActionResult TestAction(string Content)
        {
            ViewData["Content"] = Content;
            return View();
        }*/

        //version 2
        /*public ActionResult TestAction(FormCollection form)
        {
            ViewData["Content"] = form["Content"];
            return View();
        }*/

        //version 3
        //Time 不可被自動繫結 Content、UserId 自動繫結(綁定、連動)到View中的TestAction.cshtml
        //public ActionResult TestAction([Bind(Exclude ="Time", Include = "Content,UserId")]TestFormModel form)
        /*public ActionResult TestAction([Bind(Exclude ="Time")]TestFormModel form)
        {
            if(!ModelState.IsValid)
            {
                ViewData["TInfo"] = "未驗證";
                //清除模型繫結，同時清除ModelState資訊
                //不合規輸入會被清除，故前端不會顯示
                ModelState.Clear();
                return View();
            }else
            {
                form.Time = DateTime.Now;
                ViewData["TInfo"] = "已驗證";
                ViewData["Content"] = form.Content;
                ViewData["UserId"] = form.UserId;
                ViewData["Time"] = form.Time;
                return View();
            }
        }*/
        public ActionResult TestAction(TestFormModel form)
        {
            //UpdateModel 用戶端欄位自動繫結(關聯)到對應模型，但若繫結不成功會產生例外程式停住
            //UpdateModel<TestFormModel>(form);
            if(!TryUpdateModel<TestFormModel>(form))
            {
                ViewData["TInfo"] = "連結失敗";
                return View();
            }
            return Redirect("/");
        }

        //Authorize內依序為 Order Roles Users
        //[Authorize(Order =1,Roles ="SuperUser",Users="Tony,Amy")]
        //必須是Tony或Amy才能進入
        //[Authorize(Users = "Tony,Amy")]
        //必須是SuperUser身分的用戶才能進入ForDelete
        [Authorize(Roles ="SuperUser")]
        public ActionResult ForDelete()
        {
            return View();
        }
    }
}