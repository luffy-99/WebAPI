using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop.Web.Models
{
    public class FooterViewModel
    {
        public string ID { get; set; }

        [Required]
        public string Content { get; set; }
    }
}