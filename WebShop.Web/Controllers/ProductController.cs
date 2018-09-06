using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
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
            return View();
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
    }
}