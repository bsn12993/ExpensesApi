using Expenses.Data.Context;
using Expenses.Data.Services;
using Expenses.Data.UnitOfWork;
using ExpensesApp.Core.Models.Expense;
using System.Net.Http;
using System.Web.Http;

namespace Expenses.Api.Controllers
{
    [RoutePrefix("api/expenses")]
    public class ExpensesController : BaseController
    {
        // GET: Expenses
        private ExpenseService _expenseService { get; set; }
        private UnitOfWorkContainer _uow { get; set; }
        private EntityContext _context;

        public ExpensesController()
        {
            _context = new EntityContext();
            _uow = new UnitOfWorkContainer(_context);
            _expenseService = new ExpenseService(_uow);
        }

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetExpenses()
        {
            return GetResponse(_expenseService.GetExpenses());
        }

        [HttpGet]
        [Route("history/byuser/{id}")]
        public HttpResponseMessage GetExpenses(int id)
        {
            return GetResponse(_expenseService.GetExpencesHistory(id));
        }

        [HttpGet]
        [Route("byid/{id}")]
        public HttpResponseMessage GetExpenseById(int id)
        {
            return GetResponse(_expenseService.GetExpensesById(id));
        }

        [HttpGet]
        [Route("byuser/{iduser}")]
        public HttpResponseMessage GetExpenceByUser(int iduser)
        {
            return GetResponse(_expenseService.GetExpenceByUser(iduser));
        }

        /**
        [HttpGet]
        [Route("totalcategory/byuser/{iduser}")]
        public HttpResponseMessage GetTotalExpenceByCategoryAndUser(int iduser)
        {
            var response = _expenseService.GetTotalExpenceByCategoryAndUser(iduser);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message, "application/json");
        }
        **/

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage PostExpense([FromBody] CreateExpenseModel createExpense)
        {
            return GetResponse(_expenseService.PostExpense(createExpense));
        }


        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage PutExpense([FromBody] UpdateExpenseModel updateExpense,int id)
        {
            return GetResponse(_expenseService.PutExpense(updateExpense, id));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteExpense(int id)
        {
            return GetResponse(_expenseService.DeleteExpense(id));
        }
    }
}