using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.ExtensionHelper
{
    public static class ImageHelpers
    {
        public static MvcHtmlString Image(this HtmlHelper helper,string src,string alt)
        {
            //自訂HTML標籤
            return MvcHtmlString.Create(String.Format("<img src='{0}' alt='{1}' />", src, alt));
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string id, string src, string alt)
        {
            //產生TagBuilder物件
            var builder = new TagBuilder("img");

            //指定id值
            builder.GenerateId(id);

            //附加屬姓
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", alt);

            //自訂HTML標籤 多載
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}