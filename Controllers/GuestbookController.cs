using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class GuestbookController : Controller
    {
        //Service商業邏輯引入區
        private readonly GuestbookService service = new GuestbookService();

        // GET: Guestbook
        public ActionResult Index()
        {
            GuestbookViewModel model = new GuestbookViewModel();
            model.DataList = service.GetDataList();
            //傳遞顯示資料至畫面
            return View(model);
        }
    }
}