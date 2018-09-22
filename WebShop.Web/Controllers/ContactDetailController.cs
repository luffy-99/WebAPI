using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Model.Models;
using WebShop.Service;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class ContactDetailController : Controller
    {
        public IContactDetailService _contactDetailService;

        public ContactDetailController(IContactDetailService contactDetailService)
        {
            this._contactDetailService = contactDetailService;
        }
        // GET: ContactDetail
        public ActionResult Index()
        {
            var contactDetail = _contactDetailService.GetDefaultCotact();
            var contactDetailViewModel = Mapper.Map<ContactDetail,ContactDetailViewModel>(contactDetail);
            return View(contactDetailViewModel);
        }
    }
}