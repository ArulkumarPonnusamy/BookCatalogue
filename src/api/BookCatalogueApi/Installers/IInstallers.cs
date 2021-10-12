using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookCatalogueApi.Installers
{
    public interface IInstallers
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}