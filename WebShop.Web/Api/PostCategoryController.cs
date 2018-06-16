using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebShop.Model.Models;
using WebShop.Service;
using WebShop.Web.Infrastructure.Core;
using WebShop.Web.Infrastructure.Extensions;
using WebShop.Web.Models;

namespace WebShop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;
        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService): base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }
        
        [Route("GetAll")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listPostCategory = _postCategoryService.GetAll();
                var listPostCategoryViewModel = Mapper.Map<List<PostCategoryViewModel>>(listPostCategory);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listPostCategoryViewModel);
                return response;
            });
        }
        [Route("Add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    PostCategory newPostCategory = new PostCategory();
                    newPostCategory.UpdatePostCategory(postCategoryViewModel);

                    var postCategory = _postCategoryService.Add(newPostCategory);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.Created, postCategory);
                }
                return response;
            });
        }
        [Route("Update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryViewModel)
        {
            
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategory = _postCategoryService.GetById(postCategoryViewModel.ID);
                    postCategory.UpdatePostCategory(postCategoryViewModel);
                    _postCategoryService.Update(postCategory);
                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK); 
                }
                return response;
            });
        }
    }
}
