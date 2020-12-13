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
        private CategoryService _categoryService { get; set; }

        public CategoriesController()
        {
            _categoryService = new CategoryService();
        }

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetCategories()
        {
            var response = _categoryService.GetCategories();
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, response.Message, "application/json");
        }

        [HttpGet]
        [Route("byid/{id}")]
        public HttpResponseMessage GetCategoryById(int id)
        {
            var response = _categoryService.GetCategoryById(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, response.Message, "application/json");
        }

        [HttpGet]
        [Route("byuser/{id}")]
        public HttpResponseMessage GetCategoryByUser(int id)
        {
            var response = _categoryService.GetCategoryByUser(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, response.Message, "application/json");
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage PostCategory([FromBody] CategoryModel categoryModel)
        {
            var response = _categoryService.PostCategory(categoryModel);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message, "application/json");
        }

        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage PutCategory([FromBody] CategoryModel categoryModel, int id)
        {
            var response = _categoryService.PutCategory(categoryModel, id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message, "application/json");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteCategory(int id)
        {
            var response = _categoryService.DeleteCategory(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message, "application/json");
        }

        [HttpDelete]
        [Route("delete/{id}/{iduser}")]
        public HttpResponseMessage DeleteUserCategory(int id, int iduser)
        {
            var response = _categoryService.DeleteUserCategory(id, iduser);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message, "application/json");
        }
    }
}