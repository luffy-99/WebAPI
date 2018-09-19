using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebShop.Common;
using WebShop.Model.Models;
using WebShop.Service;
using WebShop.Web.Infrastructure.Core;
using WebShop.Web.Models;

namespace WebShop.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IProductCategoryService _productCategoryService;

        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
        }

        // GET: Product
        public ActionResult Detail(int id)
        {
            var productModel = _productService.GetById(id);
            var viewModel = Mapper.Map<Product, ProductViewModel>(productModel);
            var relatedProduct = _productService.GetReatedProducts(id, 6);
            ViewBag.RelatedProducts = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(relatedProduct);

            //List<string> listImages = new JavaScriptSerializer().Deserialize<List<string>>(viewModel.MoreImages);
            //ViewBag.MoreImages = listImages;\

            ViewBag.Tags = Mapper.Map<IEnumerable<Tag>, IEnumerable<TagViewModel>>(_productService.GetListTagByProduct(id));
            return View(viewModel);
        }

        public ActionResult Category(int id, int page=1, string sort="")
        {
            int totalRow = 0;
            int pageSize = CommonConstants.PageSize;
            var productList = _productService.GetProductByCategoryIdPaging(id, page, pageSize,sort, out totalRow);
            var productListViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productList);
            var totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var Category = _productCategoryService.GetById(id);
            ViewBag.category = Mapper.Map<ProductCategory, ProductCategoryViewModel>(Category);
            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productListViewModel,
                Page = page,
                MaxPage = CommonConstants.MaxPage,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            return View(paginationSet);
        }
        public JsonResult GetListProductByName(string keyword)
        {
            var model = _productService.GetListProductByName(keyword);
            return Json(new
            {
                data = model
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Search(string keyword, int page = 1, string sort = "")
        {
            int totalRow = 0;
            int pageSize = CommonConstants.PageSize;
            var productList = _productService.Search(keyword, page, pageSize, sort, out totalRow);
            var productListViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productList);
            var totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            ViewBag.Keyword = keyword;
            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productListViewModel,
                Page = page,
                MaxPage = CommonConstants.MaxPage,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            return View(paginationSet);
        }
    }
}