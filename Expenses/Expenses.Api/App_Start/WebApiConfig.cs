using Expenses.Api.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Expenses.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var mediaType = new MediaTypeHeaderValue("application/json");
            var formater = new JsonMediaTypeFormatter();
            formater.SupportedMediaTypes.Clear();
            formater.SupportedMediaTypes.Add(mediaType);

            var configuration = new HttpConfiguration();
            configuration.Formatters.Clear();
            configuration.Formatters.Add(formater);

        }
    }
}
