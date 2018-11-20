using Expenses.Data.EntityModel;
using Expenses.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Expenses.Api.Controllers
{
    [RoutePrefix("api/category")]
    public class CategoriesController : ApiController
    {
        // GET: Categories
        CategoriesServices CategoriesServices { get; set; }

        public CategoriesController()
        {
            CategoriesServices = new CategoriesServices();
        }

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetCategories()
        {
            var response = CategoriesServices.GetCategories();
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, response, "application/json");
        }

        [HttpGet]
        [Route("byid/{id}")]
        public HttpResponseMessage GetCategoryById(int id)
        {
            var response = CategoriesServices.GetCategoryById(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, response, "application/json");
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage PostCategory([FromBody] Category category)
        {
            var response = CategoriesServices.PostCategory(category);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, response, "application/json");
        }

        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage PutCategory([FromBody] Category category, int id)
        {
            var response = CategoriesServices.PutCategory(category, id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, response, "application/json");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteCategory(int id)
        {
            var response = CategoriesServices.DeleteCategory(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, response, "application/json");
        }
    }
}