using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Guestbooks
    {
        [DisplayName("編號:")]
        public int Id { get; set; }
        [DisplayName("姓名:")]
        public string Name { get; set; }
        [DisplayName("內容:")]
        public string Content { get; set; }
    }
}