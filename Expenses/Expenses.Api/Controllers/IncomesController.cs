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
    [RoutePrefix("api/incomes")]
    public class IncomesController : ApiController
    {
        // GET: Incomes
        private IncomeService _incomeService { get; set; }

        public IncomesController()
        {
            _incomeService = new IncomeService();
        }

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetIncomes()
        {
            var response = _incomeService.GetIncomes();
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpGet]
        [Route("history/byuser/{id}")]
        public HttpResponseMessage GetIncomesByUser(int id)
        {
            var response = _incomeService.GetIncomesByUser(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpGet]
        [Route("byid/{id}")]
        public HttpResponseMessage GetIncomeById(int id)
        {
            var response = _incomeService.GetIncomeById(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpGet]
        [Route("total/byuser/{iduser}")]
        public HttpResponseMessage GetIncomeByUser(int iduser)
        {
            var response = _incomeService.GetIncomesTotal(iduser);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage PostIncome([FromBody] Income income)
        {
            var response = _incomeService.PostIncome(income);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpPut]
        [Route("update/{id}")]
        public HttpResponseMessage PutIncome([FromBody] Income income, int id)
        {
            var response = _incomeService.PutIncome(income, id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteIncome(int id)
        {
            var response = _incomeService.DeleteIncome(id);
            if (response.IsSuccess)
                return Request.CreateResponse(HttpStatusCode.OK, response, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, response, "application/json");
        }
    }
}