﻿
using Expenses.Api.Security;
using Expenses.Core.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Expenses.Api.Controllers
{
    [RoutePrefix("api/token")]
    public class TokenController : ApiController
    {
        [Route("generatetoken")]
        [HttpPost]
        public HttpResponseMessage GenerateToken([FromBody]string user)
        {
            if (string.IsNullOrEmpty(user))
                return Request.CreateResponse(HttpStatusCode.BadRequest, new Response
                {
                    Code = 200,
                    Message = "El usuario no es valido"
                }, "application/json");
            var token = TokenGenerator.GenerateTokenJwt(user);
            if (!string.IsNullOrEmpty(token))
                return Request.CreateResponse(HttpStatusCode.OK, new Response
                {
                    Code = 200,
                    Result = token
                }, "application/json");
            else
                return Request.CreateResponse(HttpStatusCode.BadGateway, new Response
                {
                    Code = 200,
                    Message = "No se pudo generar el token"
                }, "application/json");
        }
    }
}