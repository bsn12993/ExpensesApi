using Expenses.Core.Models.Category;
using Expenses.Data.Context;
using Expenses.Data.Services;
using Expenses.Data.UnitOfWork;
using System.Net.Http;
using System.Web.Http;

namespace Expenses.Api.Controllers
{
    [RoutePrefix("api/category")]
    public class CategoriesController : BaseController
    {
        // GET: Categories
        private CategoryService _categoryService { get; set; }
        private UnitOfWorkContainer _uow { get; set; }
        private EntityContext _context;

        public CategoriesController()
        {
            _context = new EntityContext();
            _uow = new UnitOfWorkContainer(_context);
            _categoryService = new CategoryService(_uow);
        }

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetCategories()
        {
            return GetResponse(_categoryService.GetCategories());
        }

        [HttpGet]
        [Route("byid/{id}")]
        public HttpResponseMessage GetCategoryById(int id)
        {
            return GetResponse(_categoryService.GetCategoryById(id));
        }

        [HttpGet]
        [Route("byuser/{id}")]
        public HttpResponseMessage GetCategoryByUser(int id)
        {
            return GetResponse(_categoryService.GetCategoryByUser(id));
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage PostCategory([FromBody] CreateCategoryModel createCategory)
        {
            return GetResponse(_categoryService.PostCategory(createCategory));
        }

        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage PutCategory([FromBody] UpdateCategoryModel updateCategory, int id)
        {
            return GetResponse(_categoryService.PutCategory(updateCategory, id));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteCategory(int id)
        {
            return GetResponse(_categoryService.DeleteCategory(id));
        }
    }
}