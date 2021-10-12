using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;

namespace BookCatalogueApi.Installers
{
    public class MvcInstaller : IInstallers
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(options =>
                {
                    options.Conventions.Add(new ControllerNameAttributeConvention());
                })
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver());
        }

        private class ControllerNameAttributeConvention : IControllerModelConvention
        {
            public void Apply(ControllerModel controller)
            {
                var controllerNameAttribute = controller.Attributes.OfType<ControllerNameAttribute>().SingleOrDefault();
                if (controllerNameAttribute != null)
                {
                    controller.ControllerName = controllerNameAttribute.Name;
                }
            }
        }
    }
}