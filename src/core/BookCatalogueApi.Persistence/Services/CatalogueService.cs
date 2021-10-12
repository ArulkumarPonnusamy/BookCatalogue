using BookCatalogueApi.Domain.Models;
using BookCatalogueApi.Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookCatalogueApi.Persistence.Services
{

    public class CatalogueService : ICatalogueService
    {
        private static readonly List<CatalogEntity> CatalogList = new();
        public Task<List<CatalogEntity>> Create(CatalogEntity catalogEntity, CancellationToken cancellationToken)
        {
 
            CatalogList.Add(catalogEntity);
            return Task.FromResult(CatalogList);
        }

        public Task<bool> IsCatalogueExist(string Isbn, CancellationToken cancellationToken)
        {
            var isExist = CatalogList.FirstOrDefault(t => t.ISBN == Isbn) != null;
            return Task.FromResult(isExist);
        }

        public Task<List<CatalogEntity>> Modify(CatalogEntity catalogEntity, CancellationToken cancellationToken)
        {
            CatalogList.Where(t => t.ISBN == catalogEntity.ISBN)
                .ToList()
                .ForEach(t =>
                {
                    t.Author = catalogEntity.Author is not null ? catalogEntity.Author : t.Author;
                    t.Title = catalogEntity.Title is not null ? catalogEntity.Title : t.Title;
                    t.PublicationDate = catalogEntity.PublicationDate != DateTime.MinValue ? catalogEntity.PublicationDate : t.PublicationDate;
                });
            return Task.FromResult(CatalogList);
        }
        public Task<List<CatalogEntity>> Delete(CatalogEntity catalogEntity, CancellationToken cancellationToken)
        {
            var catalogue = CatalogList.FirstOrDefault(t => t.ISBN == catalogEntity.ISBN);
            CatalogList.Remove(catalogue);
            return Task.FromResult(CatalogList);
        }

        public Task<List<CatalogEntity>> Search(CatalogEntity catalogEntity, CancellationToken cancellationToken)
        {
            var res = CatalogList.Where(t => (t.Author == (catalogEntity.Author ?? t.Author))
             && (t.ISBN == (catalogEntity.ISBN ?? t.ISBN))
             && (t.Title == (catalogEntity.Title ?? t.Title))).ToList();
            return Task.FromResult(res);
        }
    }
}
