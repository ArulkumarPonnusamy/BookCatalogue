using BookCatalogueApi.Persistence.Interfaces;
using BookCatalogueApi.Persistence.Services;
using Microsoft.Extensions.DependencyInjection;
namespace BookCatalogueApi.Persistence
{
    public static class PersistentServiceRegistration
    {
        public static void AddPersistentServices(this IServiceCollection services)
        {
            services.AddScoped<ICatalogueService, CatalogueService>();
        }
    }
}
