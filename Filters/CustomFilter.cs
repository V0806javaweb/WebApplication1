using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Filters
{
    public class CustomFilter:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //設定顯示訊息
            string message = string.Format("a user enter {0} 's {1} at {2}",
                filterContext.Controller,filterContext.RouteData.Values["action"] as String,
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            System.Diagnostics.Debug.WriteLine(message, "Action Filter Log");
            base.OnActionExecuted(filterContext);
        }
    }
}