using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop.Web.Models
{
    public class ContactDetailViewModel
    {
        public int ID { set; get; }
        [Required(ErrorMessage="Ten khong dc trong")]
        public string Name { set; get; }
        [MaxLength(50, ErrorMessage ="SDT khong vuot qua 50 ky tu")]
        public string Phone { set; get; }
        [MaxLength(250, ErrorMessage = "Website khong qua 250 ky tu")]
        public string Website { set; get; }
        [MaxLength(250, ErrorMessage = "Email khong qua 250 ky tu")]
        public string Email { set; get; }
        [MaxLength(250, ErrorMessage = "Dia chi khong qua 250 ky tu")]
        public string Address { set; get; }
        public string Other { set; get; }
        public double? Lat { set; get; }
        public double? Lng { set; get; }
        public bool Status { set; get; }
    }
}