using BookCatalogueApi.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookCatalogueApi.Installers
{
    public class PersistenceInstaller : IInstallers
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistentServices();
        }
    }
}