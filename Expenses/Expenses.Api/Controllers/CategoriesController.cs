using Expenses.Data.Services;
using ExpensesApp.Data.Models;
using System.Net;
using System.Net.Http;
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
                return Request.CreateResponse(HttpStatusCode.NotFound, response.Message, "application/json");
        }

        [HttpGet]
        [Route("byid/{id}")]
        public HttpResponseMessage GetCategoryById(int id)
        {
            var response = CategoriesServices.GetCategoryById(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, response.Message, "application/json");
        }

        [HttpGet]
        [Route("byuser/{id}")]
        public HttpResponseMessage GetCategoryByUser(int id)
        {
            var response = CategoriesServices.GetCategoryByUser(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, response.Message, "application/json");
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage PostCategory([FromBody] CategoryModel categoryModel)
        {
            var response = CategoriesServices.PostCategory(categoryModel);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message, "application/json");
        }

        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage PutCategory([FromBody] CategoryModel categoryModel, int id)
        {
            var response = CategoriesServices.PutCategory(categoryModel, id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message, "application/json");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteCategory(int id)
        {
            var response = CategoriesServices.DeleteCategory(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message, "application/json");
        }

        [HttpDelete]
        [Route("delete/{id}/{iduser}")]
        public HttpResponseMessage DeleteUserCategory(int id, int iduser)
        {
            var response = CategoriesServices.DeleteUserCategory(id, iduser);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message, "application/json");
        }
    }
}