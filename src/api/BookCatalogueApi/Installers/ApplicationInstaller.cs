using BookCatalogueApi.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookCatalogueApi.Installers
{
    public class ApplicationInstaller : IInstallers
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationServices();
        }
    }
}