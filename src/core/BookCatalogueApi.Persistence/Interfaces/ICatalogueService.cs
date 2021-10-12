using BookCatalogueApi.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookCatalogueApi.Persistence.Interfaces
{
    public interface ICatalogueService
    {
        public Task<List<CatalogEntity>> Create(CatalogEntity catalogEntity, CancellationToken cancellationToken);
        public Task<bool> IsCatalogueExist(string Isbn, CancellationToken cancellationToken);
        public Task<List<CatalogEntity>> Modify(CatalogEntity catalogEntity, CancellationToken cancellationToken);
        public Task<List<CatalogEntity>> Delete(CatalogEntity catalogEntity, CancellationToken cancellationToken);
        public Task<List<CatalogEntity>> Search(CatalogEntity catalogEntity, CancellationToken cancellationToken);
    }
}
