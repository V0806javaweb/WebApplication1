using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    //套用Include到整個Action中 不只一個屬性時以逗號間隔
    //[Bind(Include ="UserId,Content")]
    public class TestFormModel
    {
        [Required(ErrorMessage ="說點什麼吧")]
        public string Content { get; set; }
        [Required(ErrorMessage ="你寄吧誰?")]
        public string UserId { get; set; }
        public int Age { get; set; }
        public DateTime? Time { get; set; }
    }
}