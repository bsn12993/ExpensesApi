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
    [RoutePrefix("api/expenses")]
    public class ExpensesController : ApiController
    {
        // GET: Expenses
        private ExpenseService _expenseService { get; set; }

        public ExpensesController()
        {
            _expenseService = new ExpenseService();
        }

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetExpenses()
        {
            var response = _expenseService.GetExpenses();
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpGet]
        [Route("history/byuser/{id}")]
        public HttpResponseMessage GetExpenses(int id)
        {
            var response = _expenseService.GetExpencesHistory(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpGet]
        [Route("byid/{id}")]
        public HttpResponseMessage GetExpenseById(int id)
        {
            var response = _expenseService.GetExpensesById(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpGet]
        [Route("byuser/{iduser}")]
        public HttpResponseMessage GetExpenceByUser(int iduser)
        {
            var response = _expenseService.GetExpenceByUser(iduser);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpGet]
        [Route("totalcategory/byuser/{iduser}")]
        public HttpResponseMessage GetTotalExpenceByCategoryAndUser(int iduser)
        {
            var response = _expenseService.GetTotalExpenceByCategoryAndUser(iduser);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage PostExpense([FromBody] Expense expense)
        {
            var response = _expenseService.PostExpense(expense);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }


        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage PutExpense([FromBody] Expense expense,int id)
        {
            var response = _expenseService.PutExpense(expense, id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteExpense(int id)
        {
            var response = _expenseService.DeleteExpense(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }
    }
}