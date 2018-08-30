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
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;
        IFooterService _IFooterService;
        IProductService _productService;
        public HomeController(IProductCategoryService productCategoryService, IFooterService IFooterService, IProductService productService)
        {
            this._productCategoryService = productCategoryService;
            this._IFooterService = IFooterService;
            this._productService = productService;
        }
        public ActionResult Index()
        {
            var slideModel = _IFooterService.GetSlides();
            var slideViewModel = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(slideModel);
            var homeViewModel = new HomeViewModel();
            homeViewModel.Slides = slideViewModel;

            var lastestProductModel = _productService.GetLastest(3);
            var topSaleProductModel = _productService.GetHotProduct(3);
            var lastestProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastestProductModel);
            var topSaleProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topSaleProductModel);
            homeViewModel.LastestProduct = lastestProductViewModel;
            homeViewModel.TopSaleProduct = topSaleProductViewModel;
            return View(homeViewModel);
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
        [ChildActionOnly]
        public ActionResult Footer()
        {
            var footer = _IFooterService.GetFooter();
            var footerViewModel = Mapper.Map<Footer, FooterViewModel>(footer);
            return PartialView("Footer", footerViewModel);
        }
        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView("Header");
        }
        [ChildActionOnly]
        public ActionResult Category()
        {
            var listProductCategory = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(listProductCategory);
            return PartialView("Category",listProductCategoryViewModel);
        }
    }
}