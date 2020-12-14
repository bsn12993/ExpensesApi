using Expenses.Data.Context;
using Expenses.Data.EntityModel;
using Expenses.Data.Services;
using Expenses.Data.UnitOfWork;
using ExpensesApp.Core.Models.Expense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Expenses.Api.Controllers
{
    [RoutePrefix("api/expenses")]
    public class ExpensesController : ApiController
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
            var response = _expenseService.GetExpenses();
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message, "application/json");
        }

        [HttpGet]
        [Route("history/byuser/{id}")]
        public HttpResponseMessage GetExpenses(int id)
        {
            var response = _expenseService.GetExpencesHistory(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message, "application/json");
        }

        [HttpGet]
        [Route("byid/{id}")]
        public HttpResponseMessage GetExpenseById(int id)
        {
            var response = _expenseService.GetExpensesById(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message, "application/json");
        }

        [HttpGet]
        [Route("byuser/{iduser}")]
        public HttpResponseMessage GetExpenceByUser(int iduser)
        {
            var response = _expenseService.GetExpenceByUser(iduser);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message, "application/json");
        }

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

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage PostExpense([FromBody] CreateExpenseModel createExpense)
        {
            var response = _expenseService.PostExpense(createExpense);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message, "application/json");
        }


        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage PutExpense([FromBody] UpdateExpenseModel updateExpense,int id)
        {
            var response = _expenseService.PutExpense(updateExpense, id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message, "application/json");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteExpense(int id)
        {
            var response = _expenseService.DeleteExpense(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response.Message, "application/json");
        }
    }
}