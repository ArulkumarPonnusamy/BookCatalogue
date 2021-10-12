using AutoMapper;
using BookCatalogueApi.Domain.Models;
using BookCatalogueApi.Persistence.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BookCatalogueApi.Application.Catalogue.Query
{
    public class CatalogueQuery : CatalogEntity, IRequest<List<CatalogEntity>>
    {
        public CatalogueQuery(string isbn, string author, string title)
        {
            ISBN = isbn;
            Author = author;
            Title = title;
        }
    }
}