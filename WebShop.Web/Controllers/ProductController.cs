﻿using System.Web.Mvc;

namespace WebShop.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Detail(int id)
        {
            return View();
        }

        public ActionResult Category(int id)
        {
            return View();
        }
    }
}