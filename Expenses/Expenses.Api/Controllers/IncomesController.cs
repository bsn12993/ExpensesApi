using Expenses.Data.EntityModel;
using ExpensesApp.Data.Services;
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
    public class IncomesController : ApiController
    {
        // GET: Incomes
        IncomesServices IncomesServices { get; set; }

        public IncomesController()
        {
            IncomesServices = new IncomesServices();
        }

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetIncomes()
        {
            var response = IncomesServices.GetIncomes();
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpGet]
        [Route("byid/{id}")]
        public HttpResponseMessage GetIncomeById(int id)
        {
            var response = IncomesServices.GetIncomeById(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage PostIncome([FromBody] Income income)
        {
            var response = IncomesServices.PostIncome(income);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage PutIncome([FromBody] Income income, int id)
        {
            var response = IncomesServices.PutIncome(income, id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteIncome(int id)
        {
            var response = IncomesServices.DeleteIncome(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }
    }
}