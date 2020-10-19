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
        ExpensesServices ExpensesServices { get; set; }

        public ExpensesController()
        {
            ExpensesServices = new ExpensesServices();
        }

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetExpenses()
        {
            var response = ExpensesServices.GetExpenses();
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpGet]
        [Route("history/byuser/{id}")]
        public HttpResponseMessage GetExpenses(int id)
        {
            var response = ExpensesServices.GetExpencesHistory(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpGet]
        [Route("byid/{id}")]
        public HttpResponseMessage GetExpenseById(int id)
        {
            var response = ExpensesServices.GetExpensesById(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpGet]
        [Route("byuser/{iduser}")]
        public HttpResponseMessage GetExpenceByUser(int iduser)
        {
            var response = ExpensesServices.GetExpenceByUser(iduser);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpGet]
        [Route("totalcategory/byuser/{iduser}")]
        public HttpResponseMessage GetTotalExpenceByCategoryAndUser(int iduser)
        {
            var response = ExpensesServices.GetTotalExpenceByCategoryAndUser(iduser);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage PostExpense([FromBody] Expense expense)
        {
            var response = ExpensesServices.PostExpense(expense);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }


        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage PutExpense([FromBody] Expense expense,int id)
        {
            var response = ExpensesServices.PutExpense(expense, id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteExpense(int id)
        {
            var response = ExpensesServices.DeleteExpense(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }
    }
}