using Newtonsoft.Json.Serialization;
using System;
using System.Web.Http;


namespace LudiaARQ.Negocio.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Configuración y Services de API web
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            // Add an Activator to handle errors only in the controller constructor


            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
                );
            
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new NotToStringContractResolver();
        }
    }

    class NotToStringContractResolver : CamelCasePropertyNamesContractResolver
    {
        protected override JsonContract CreateContract(Type objectType)
        {
            JsonContract contract = base.CreateContract(objectType);
            if (objectType != typeof(string) && (contract is JsonStringContract))
            {
                // We don't want a string contract unless the objectType was actually a string
                return base.CreateObjectContract(objectType);
            }
            return base.CreateContract(objectType);
        }
    }
}
